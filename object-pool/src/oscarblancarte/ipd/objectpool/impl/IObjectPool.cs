using oscarblancarte.ipd.objectpool.impl.poolable;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl{
    public interface IObjectPool<T> 
        where T: IPooledObject
    {
        T GetObject() ;
        void ReleaceObject(T pooledObject);
    }
} 