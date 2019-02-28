using oscarblancarte.ipd.objectpool.impl.poolable;
using System;
using System.Threading;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl.poolable{
    
    public class ExecutorTask : IPooledObject {
        private int Uses;
        private static int Invalidated;
        private static int Counter;

        public void Execute() {
            int c = ++Counter ;
            Uses++;
            Console.WriteLine("execute ==> " + c);
            try {
                Thread.Sleep(5000);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("execute end ==> " + c);
        }

        public bool Validate() {
            return Uses < 2;
        }

        public void Invalidate() {
            Invalidated++;
            Console.WriteLine("Invalidate Counter ==> " + Invalidated);
        }
    }
} 