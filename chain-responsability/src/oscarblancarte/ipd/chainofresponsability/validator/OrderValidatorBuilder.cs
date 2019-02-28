/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.chainofresponsability.validator{
    public class OrderValidatorBuilder {
        public static AbstractOrderValidator BuildSalesOrderValidator(){
            AbstractOrderValidator validator = new SalesOrderValidator();
            validator.AddValidator(BuildCustomerValidator());
            validator.AddValidator(new OrderItemValidator());
            validator.AddValidator(new CreditValidator());
            return validator;
        }
        
        private static AbstractOrderValidator BuildCustomerValidator(){
            AbstractOrderValidator validator = new CustomerValidator();
            validator.AddValidator(BuildContributorValidator());
            return validator;
        }
        
        private static AbstractOrderValidator BuildContributorValidator(){
            AbstractOrderValidator validator = new ContributorValidator();
            validator.AddValidator(new AddressValidator());
            validator.AddValidator(new TelephoneValidator());
            return validator;
        }
    }

}


