using ObjectPool.Poolable;

namespace ObjectPool.Factory
{
    public class ExecutorTaskFactory : IPoolableObjectFactory<ExecutorTask>
    {
        public ExecutorTask CreateNew()
        {
            return new ExecutorTask();
        }
    }
}
