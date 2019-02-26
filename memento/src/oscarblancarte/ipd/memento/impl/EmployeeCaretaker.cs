using System;
using System.Collections.Generic;

namespace oscarblancarte.ipd.memento.impl{


    public class EmployeeCaretaker {
        private int currentIndex = -1;
        
        private readonly List<EmployeeMemento> states = new List<EmployeeMemento>();

        public void addNewMemento(EmployeeMemento m) {
            states.Add(m);
            currentIndex++;
        }
        public EmployeeMemento getCurrentMemento() {
            return states[currentIndex];
        }
        
        public EmployeeMemento getNextMemento() {
            int newIndex = currentIndex +1;
            if( newIndex >= states.Count){
                return null;
            }
            currentIndex = newIndex;
            return states[currentIndex];
        }
        
        public EmployeeMemento getPreviousMemento() {
            int newIndex = currentIndex-1;
            
            if(newIndex  <= -1 || newIndex >= states.Count-1){
                return null;
            }
            currentIndex= newIndex;
            return states[currentIndex];
        }
    }

}

