using ObjectPool.Poolable;

namespace ObjectPool
{
    /*
     Ésta interface será utilizada para establecer las operaciones
    mínimas que deberán tener los ObjectPool

    *OBJECT POOL?
     */
    public interface IObjectPool<T> where T : IPooledObject
    {
        /// <summary>
        /// Método que utilizaremos para solicitar un objecto del pool,
        /// éste método lanza la excepción PoolException tras agotarse el tiempo
        /// de espera.
        /// </summary>
        /// <returns></returns>
        T GetObject();

        /// <summary>
        /// Método utilizado para regresar un objecto al pool una vez que ya no sea requerido.
        /// </summary>
        void ReleaseObject(T pooledObject);
    }
}
