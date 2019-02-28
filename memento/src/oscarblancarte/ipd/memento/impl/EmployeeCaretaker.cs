using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.memento.impl{


    public class EmployeeCaretaker {
        private int CurrentIndex = -1;
        
        private readonly List<EmployeeMemento> States = new List<EmployeeMemento>();

        public void addNewMemento(EmployeeMemento m) {
            States.Add(m);
            CurrentIndex++;
        }
        public EmployeeMemento getCurrentMemento() {
            return States[CurrentIndex];
        }
        
        public EmployeeMemento getNextMemento() {
            int newIndex = CurrentIndex +1;
            if( newIndex >= States.Count){
                return null;
            }
            CurrentIndex = newIndex;
            return States[CurrentIndex];
        }
        
        public EmployeeMemento getPreviousMemento() {
            int newIndex = CurrentIndex-1;
            
            if(newIndex  <= -1 || newIndex >= States.Count-1){
                return null;
            }
            CurrentIndex= newIndex;
            return States[CurrentIndex];
        }
    }

}

