using System;
using System.Collections.Generic;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl{
    public abstract class AbstractObservable : IObservable {

        private readonly List<IObserver> Observers = new List<IObserver>();

        public void AddObserver(IObserver observer) {
            this.Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) {
            this.Observers.Remove(observer);
        }

        public void NotifyAllObservers(string command, Object source) {
            foreach (IObserver observer in Observers) {
                observer.NotifyObserver(command, source);
            }
        }
    }
}


