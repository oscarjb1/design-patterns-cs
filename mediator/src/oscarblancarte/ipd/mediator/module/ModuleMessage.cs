using System;

namespace oscarblancarte.ipd.mediator.module{
    public class ModuleMessage {
        public string Source{get;set;}
        public string Target{get;set;}
        public string MessageType{get;set;}
        public Object Payload{get;set;}

        public ModuleMessage(string Source, string Target, string MessageType, Object Payload) {
            this.Source = Source;
            this.Target = Target;
            this.MessageType = MessageType;
            this.Payload = Payload;
        }
    }
}