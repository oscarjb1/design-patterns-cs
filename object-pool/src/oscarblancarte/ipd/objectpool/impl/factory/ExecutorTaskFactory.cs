
using oscarblancarte.ipd.objectpool.impl.poolable;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl.factory{
    public class ExecutorTaskFactory  : IPoolableObjectFactory<ExecutorTask>{
        public ExecutorTask createNew(){
            return new ExecutorTask();
        }
    }
} 