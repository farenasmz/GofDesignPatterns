using ObjectPool.Factory;
using ObjectPool.Others;
using ObjectPool.Poolable;

namespace ObjectPool
{
    public class ObjectPoolMain
    {
        static readonly ExecutorTreadPool pool = new ExecutorTreadPool(2, 6, 1000 * 100, new ExecutorTaskFactory());

        public static void TaskThread()
        {
            try
            {
                ExecutorTask task = pool.GetObject();
                task.Execute();
                pool.ReleaseObject(task);
            }
            catch (PoolException e)
            {
                Console.WriteLine("Error ==> " + e.ToString());
            }
        }

        static void Action(string[] args)
        {
            for (int c = 0; c < 10; c++)
            {
                ThreadStart childref = new ThreadStart(TaskThread);
                Console.WriteLine("In Main: Creating the Child thread");
                Thread childThread = new Thread(childref);
                childThread.Start();
            }

            try
            {
                //System.in.read();
                Console.ReadKey();
                Console.WriteLine(pool);
            }
            catch (Exception e)
            {
                Console.WriteLine("Out disponible " + e.ToString());
            }
        }
    }
}