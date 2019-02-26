/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class OrderValidatorBuilder {
        public static AbstractOrderValidator buildSalesOrderValidator(){
            AbstractOrderValidator validator = new SalesOrderValidator();
            validator.addValidator(buildCustomerValidator());
            validator.addValidator(new OrderItemValidator());
            validator.addValidator(new CreditValidator());
            return validator;
        }
        
        private static AbstractOrderValidator buildCustomerValidator(){
            AbstractOrderValidator validator = new CustomerValidator();
            validator.addValidator(buildContributorValidator());
            return validator;
        }
        
        private static AbstractOrderValidator buildContributorValidator(){
            AbstractOrderValidator validator = new ContributorValidator();
            validator.addValidator(new AddressValidator());
            validator.addValidator(new TelephoneValidator());
            return validator;
        }
    }

}


