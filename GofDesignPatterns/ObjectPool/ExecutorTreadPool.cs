using ObjectPool.Factory;
using ObjectPool.Poolable;

namespace ObjectPool
{
    public class ExecutorTreadPool : AbstractObjectPool<ExecutorTask>
    {
        public ExecutorTreadPool(int minInstances, int maxInstances, int waitTime, IPoolableObjectFactory<ExecutorTask> poolableObjectFactory)
            : base(minInstances, maxInstances, waitTime, poolableObjectFactory)
        {
        }
    }
}
