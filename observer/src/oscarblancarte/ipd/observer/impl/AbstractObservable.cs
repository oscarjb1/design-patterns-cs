using System;
using System.Collections.Generic;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.observer.impl{
    public abstract class AbstractObservable : IObservable {

        private readonly List<IObserver> observers = new List<IObserver>();

        public void addObserver(IObserver observer) {
            this.observers.Add(observer);
        }

        public void removeObserver(IObserver observer) {
            this.observers.Remove(observer);
        }

        public void notifyAllObservers(string command, Object source) {
            foreach (IObserver observer in observers) {
                observer.notifyObserver(command, source);
            }
        }
    }
}


