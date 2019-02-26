using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl{
    public interface IObservable {

        void addObserver(IObserver observer);

        void removeObserver(IObserver observer);

        void notifyAllObservers(string command, Object source);
    }
}


