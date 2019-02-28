using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl{
    public interface IObservable {

        void AddObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyAllObservers(string command, Object source);
    }
}


