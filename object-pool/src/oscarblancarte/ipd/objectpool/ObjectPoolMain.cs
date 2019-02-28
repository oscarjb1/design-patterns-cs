using oscarblancarte.ipd.objectpool.impl.poolable;
using oscarblancarte.ipd.objectpool.impl.factory;
using oscarblancarte.ipd.objectpool.impl;
using System.Threading;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool{
    public class ObjectPoolMain {
        static readonly ExecutorThreadPool pool = new ExecutorThreadPool(2, 6, 1000*100, new ExecutorTaskFactory());

        public static void TaskThread() {
            try {
                ExecutorTask task = pool.GetObject();
                task.Execute();
                pool.ReleaceObject(task);
            } catch (PoolException e) {
                Console.WriteLine("Error ==> " + e.ToString());
            }
        }

        static void Main(string[] args) {
            

            for (int c = 0; c < 10; c++) {
                ThreadStart childref = new ThreadStart(TaskThread);
                Console.WriteLine("In Main: Creating the Child thread");
                Thread childThread = new Thread(childref);
                childThread.Start();
            }
            
            try {
                //System.in.read();
                Console.ReadKey();
                Console.WriteLine(pool);
            } catch (Exception e) {
                Console.WriteLine("Out disponible " + e.ToString());
            }

        }
    }
} 