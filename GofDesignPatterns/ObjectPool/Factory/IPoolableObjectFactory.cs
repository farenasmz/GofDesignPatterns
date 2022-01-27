namespace ObjectPool.Factory
{
    public interface IPoolableObjectFactory<T>
    {
        T CreateNew();
    }
}
