/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.iterator.impl{
    public interface IIterator<T> {
         bool HasNext();
        T Next();
    }
}