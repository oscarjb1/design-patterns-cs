using oscarblancarte.ipd.builder.dto;
using System;

/**
 * @author oblancarte
 */
namespace oscarblancarte.ipd.builder{
        public class BuilderMain {

                static void Main(string[] args) {
                        Employee emp = new Employee.EmployeeBuilder()
                                .setName("Oscar Javier Blancarte Iturralde")
                                .setGender("Male")
                                .setAge(29)
                                .setAdress("Benito " 
                                        + "Juarez", "Mexico D.F.", "Mexico", "03400")
                                .addContacs("Rene Blancarte", "1122334455", "123", "Casa", 
                                        "Chapultepect No. 123 Col. Militar", "Mexico"
                                        , "Mexico", "10023")
                                .addContacs("Jaime Blancarte", "3344556677", null, "Celular")
                                .addPhones("4567890234", null, "Celular")
                                .addPhones("7788990099", null, "Casa")
                                .Build();
                                Console.WriteLine(emp);
                }
        }
}