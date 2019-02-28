/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.objectpool.impl.poolable{
    public interface IPooledObject {
        bool Validate();
        void Invalidate();
    }
} 