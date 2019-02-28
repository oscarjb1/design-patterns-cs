using oscarblancarte.ipd.objectpool.impl.poolable;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl.factory{
    public interface IPoolableObjectFactory<T> {
        T CreateNew();
    }
} 