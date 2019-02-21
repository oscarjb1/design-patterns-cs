/**
 *
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Phone {
        private string phoneNumber;
        private string ext;
        private string phoneType;

        public Phone() {
        }

        public Phone(string phoneNumber, string ext, string phoneType) {
            this.phoneNumber = phoneNumber;
            this.ext = ext;
            this.phoneType = phoneType;
        }
        
        public string getPhoneNumber() {
            return phoneNumber;
        }

        public void setPhoneNumber(string phoneNumber) {
            this.phoneNumber = phoneNumber;
        }

        public string getExt() {
            return ext;
        }

        public void setExt(string ext) {
            this.ext = ext;
        }

        public string getPhoneType() {
            return phoneType;
        }

        public void setPhoneType(string phoneType) {
            this.phoneType = phoneType;
        }

        public override string ToString() {
            return "Phone{" + "phoneNumber=" + phoneNumber + ", ext=" + ext + ", phoneType=" + phoneType + '}';
        }
    }
}


