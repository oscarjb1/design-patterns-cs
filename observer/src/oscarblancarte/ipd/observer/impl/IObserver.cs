using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl{
    public interface IObserver {
        
        void NotifyObserver(string command, Object source);
    }
}


