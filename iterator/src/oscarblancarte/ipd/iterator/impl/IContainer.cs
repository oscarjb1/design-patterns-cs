/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.iterator.impl{

    public interface IContainer<T> {
        IIterator<T> createIterator();
    }
}

