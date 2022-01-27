namespace ObjectPool.Poolable
{
    public interface IPooledObject
    {
        bool Validate();
        void Invalidate();
    }
}
