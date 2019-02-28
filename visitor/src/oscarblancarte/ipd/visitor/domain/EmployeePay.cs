namespace oscarblancarte.ipd.visitor.domain{
    public class EmployeePay {

        public string EmployeeName{get; set;}
        public double TotalPay{get; set;}

        public EmployeePay(string EmployeeName, double TotalPay) {
            this.EmployeeName = EmployeeName;
            this.TotalPay = TotalPay;
        }

        
        
    }
}