using ObjectPool.Factory;
using ObjectPool.Others;
using ObjectPool.Poolable;

namespace ObjectPool
{
    /// <summary>
    /// Con tiene el funcionamiento básico de un ObjectPool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AbstractObjectPool<T> : IObjectPool<T> where T : IPooledObject
    {
        internal readonly int MinInstances; // Número mínimo de instancias
        internal readonly int MaxInstances; //Número máximo de instancias.
        internal readonly int WaitTime;

        /// <summary>
        /// Representa al factory utilizado para crear los nuevos objetos, 
        /// este objeto es recibido en el constructor
        /// </summary>
        private readonly IPoolableObjectFactory<T> PoolableObjectFactory;

        /// <summary>
        /// Se encuentran los que están disponibles como los que no
        /// </summary>
        private readonly List<PooledObjectStatus<T>> FullStack = new List<PooledObjectStatus<T>>();

        /// <summary>
        /// Objetos que están siendo usados.
        /// </summary>
        private readonly List<PooledObjectStatus<T>> UseStack = new List<PooledObjectStatus<T>>();

        /// <summary>
        /// Contiene los objetos que están disponibles.
        /// </summary>
        private readonly Stack<PooledObjectStatus<T>> FreeStack = new Stack<PooledObjectStatus<T>>();

        public AbstractObjectPool(int minInstances, int maxInstances, int waitTime, IPoolableObjectFactory<T> poolableObjectFactory)
        {
            Console.WriteLine("=========== STARTING ============");
            this.MinInstances = minInstances;
            this.MaxInstances = maxInstances;
            this.WaitTime = waitTime;
            this.PoolableObjectFactory = poolableObjectFactory;
            InitPool();
            Console.WriteLine("=========== FINISH ============");
            Console.WriteLine();
        }

        /// <summary>
        /// Inicializa el Object pool con los objetos mínimos 
        /// delimitado por la variable minInstance
        /// </summary>
        private void InitPool()
        {
            for (int i = FullStack.Count; i < MinInstances; i++)
            {
                PooledObjectStatus<T> createNewPooledObject = CreateNewPooledObject();
            }
        }

        /// <summary>
        /// Método para crear un objeto nuevo mediante el uso del 
        /// IObjectFactory, el cual es enviado como parámetro en la creación del pool
        /// y es almacenado en la variable PoolableObjectFactory
        /// </summary>
        private PooledObjectStatus<T> CreateNewPooledObject()
        {
            T newObect = PoolableObjectFactory.CreateNew();
            PooledObjectStatus<T> pooled = new PooledObjectStatus<T>(newObect);
            FullStack.Add(pooled);
            Console.WriteLine("New PoolableObject{UUID=" + pooled.Uuid.ToString() + ", poolSize=" + FullStack.Count + "}");
            return pooled;
        }

        private T GetInternalObect()
        {
            lock (FreeStack)
            {
                if (FreeStack.Count != 0)
                {
                    PooledObjectStatus<T>? first = this.FreeStack.Pop();
                    first.Used = true;
                    Console.WriteLine("Provisioning Object > " + first.Uuid);
                    UseStack.Add(first);
                    return first.PooledObject;
                }

                lock (FullStack)
                {
                    if (FullStack.Count < MaxInstances)
                    {
                        PooledObjectStatus<T> returnObject = CreateNewPooledObject();
                        returnObject.Used = true;
                        Console.WriteLine("Provisioning object > " + returnObject.Uuid);
                        UseStack.Add(returnObject);
                        return returnObject.PooledObject;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }

        public T GetObject()
        {
            T internalObject = GetInternalObect();

            if (internalObject == null)
            {
                return internalObject;
            }

            return WaitForResource();
        }

        private T WaitForResource()
        {
            DateTime future = DateTime.Now.AddMilliseconds(WaitTime);
            do
            {
                PooledObjectStatus<T> returnObject = null;
                lock (FreeStack)
                {
                    if (!(FreeStack.Count == 0) && !FreeStack.Peek().Used)
                    {
                        returnObject = FreeStack.Pop();
                        returnObject.Used = true;
                        UseStack.Add(returnObject);
                        Console.WriteLine("Provisioning Object > " + returnObject.Uuid.ToString());
                        return returnObject.PooledObject;
                    }
                }

                if (returnObject == null || returnObject.Used)
                {
                    long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (WaitTime != 0 && milliseconds >= future.Millisecond)
                    {
                        throw new PoolException("Tiempo de espera agotado");
                    }
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

            } while (true);
        }

        public void ReleaseObject(T pooledObject)
        {

            foreach (PooledObjectStatus<T> item in this.FullStack)
            {
                if (item.PooledObject.Equals(pooledObject))
                {
                    if (pooledObject.Validate())
                    {
                        FreeStack.Push(item);
                        UseStack.Remove(item);
                        item.Used = false;
                        Console.WriteLine("Object returned > " + item.Uuid.ToString());
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Object Invalidate ==> " + item.Uuid.ToString());
                        pooledObject.Invalidate();
                        FullStack.Remove(item);
                        UseStack.Remove(item);
                        lock (FreeStack)
                        {
                            InitPool();
                        }
                        return;
                    }
                }
            }
        }
    }
}
