/**
 *
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder.dto{
    public class Phone {
        public string PhoneNumber{get; set;}
        public string Ext{get; set;}
        public string PhoneType{get; set;}

        public Phone() {
        }

        public Phone(string phoneNumber, string ext, string phoneType) {
            this.PhoneNumber = phoneNumber;
            this.Ext = ext;
            this.PhoneType = phoneType;
        }
        
        

        public override string ToString() {
            return "Phone{" + "phoneNumber=" + PhoneNumber + ", ext=" + Ext + ", phoneType=" + PhoneType + '}';
        }
    }
}


