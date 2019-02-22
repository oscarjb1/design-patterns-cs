using oscarblancarte.ipd.objectpool.impl.poolable;
using System;
using System.Threading;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl.poolable{
    
    public class ExecutorTask : IPooledObject {
        private int uses;
        private static int invalidate;
        private static int counter;

        public void execute() {
            int c = ++counter ;
            uses++;
            Console.WriteLine("execute ==> " + c);
            try {
                Thread.Sleep(5000);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("execute end ==> " + c);
        }

        public bool validate() {
            return uses < 2;
        }

        public void Invalidate() {
            invalidate++;
            Console.WriteLine("Invalidate Counter ==> " + invalidate);
        }
    }
} 