namespace ObjectPool.Others
{
    public class PooledObjectStatus<T>
    {
        public bool Used;
        public Guid Uuid;
        public T PooledObject;

        public PooledObjectStatus(T pooledObject)
        {
            Used = false;
            Uuid = Guid.NewGuid();
            PooledObject = pooledObject;
        }
    }
}
