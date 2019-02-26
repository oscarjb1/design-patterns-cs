using System;

namespace oscarblancarte.ipd.mediator.module{
    public class ModuleMessage {
        private string source;
        private string target;
        private string messageType;
        private Object payload;

        public ModuleMessage(string source, string target, string messageType, Object payload) {
            this.source = source;
            this.target = target;
            this.messageType = messageType;
            this.payload = payload;
        }

        public string getTarget() {
            return target;
        }

        public void setTarget(string target) {
            this.target = target;
        }

        public string getMessageType() {
            return messageType;
        }

        public void setMessageType(string messageType) {
            this.messageType = messageType;
        }

        public Object getPayload() {
            return payload;
        }

        public void setPayload(Object payload) {
            this.payload = payload;
        }

        public string getSource() {
            return source;
        }

        public void setSource(string source) {
            this.source = source;
        }
    }
}

