using oscarblancarte.ipd.interprete.sql;
using oscarblancarte.ipd.interprete.sql.nonterminal;
using oscarblancarte.ipd.interprete.sql.terminal;
using System;
using System.Linq;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete{
    public class InterpreteMain {

        static void Main(string[] args) {
            //Abstract Syntactic Tree
            SelectExpression select = GetById();
            Console.WriteLine(select.ToString());
            Context context = new Context("./Employee.xls");
            context.SetDateFormat("MM/dd/yyyy");
            try {
                List<Object[]> output = select.Interpret(context);
                foreach(Object[] obj in output) {
                    Console.WriteLine(string.Join(" ", obj) );
                }
            } catch (InterpreteException e) {
                Console.WriteLine(e.ToString());
            } finally {
                context.Destroy();
            }
        }

        public static SelectExpression GetById() {
            SelectExpression select = new SelectExpression(
                    new TargetExpression(
                            new LiteralExpression("FIRST_NAME"),
                            new LiteralExpression("LAST_NAME")
                    ),
                    new FromExpression(
                            new LiteralExpression("EMPLOYEES")),
                    new WhereExpression(
                            new BooleanExpression(
                                    new LiteralExpression("ID"),
                                    new LiteralExpression("="),
                                    new NumericExpression(10)
                            )
                    )
            );
            return select;
        }

        public static SelectExpression FindByDate() {
            SelectExpression select = new SelectExpression(
                    new TargetExpression(
                            new LiteralExpression("ID"),
                            new LiteralExpression("BORN_DATE"),
                            new LiteralExpression("DEPARTMENT"),
                            new LiteralExpression("FIRST_NAME"),
                            new LiteralExpression("LAST_NAME")
                    ),
                    new FromExpression(
                            new LiteralExpression("EMPLOYEES")),
                    new WhereExpression(
                            new BooleanExpression(
                                    new LiteralExpression("BORN_DATE"),
                                    new LiteralExpression(">"),
                                    new DateExpression("01/01/1990")
                            )
                    )
            );
            return select;
        }

        public static SelectExpression FindByTwoID() {
            SelectExpression select = new SelectExpression(
                    new TargetExpression(
                            
                            new LiteralExpression("FIRST_NAME"),
                            new LiteralExpression("DEPARTMENT"),
                            new LiteralExpression("ID")
                    ),
                    new FromExpression(
                            new LiteralExpression("EMPLOYEES")),
                    new WhereExpression(
                            new OrExpression(
                                    new BooleanExpression(
                                            new LiteralExpression("ID"),
                                            new LiteralExpression("="),
                                            new NumericExpression(5)
                                    ),
                                    new BooleanExpression(
                                            new LiteralExpression("ID"),
                                            new LiteralExpression("="),
                                            new NumericExpression(14)
                                    )
                            )
                    )
            );
            return select;
        }

        public static SelectExpression ComplexQuery() {
            SelectExpression select = new SelectExpression(
            new TargetExpression(
                new LiteralExpression("FIRST_NAME"),
                new LiteralExpression("LAST_NAME")
            ),
            new FromExpression(
                new LiteralExpression("EMPLOYEES")),
            new WhereExpression(
                new AndExpression(
                    new BooleanExpression(
                        new LiteralExpression("STATUS"),
                        new LiteralExpression("="),
                        new TextExpression("Active")
                    ),
                    new AndExpression(
                        new BooleanExpression(
                            new LiteralExpression("BORN_DATE"),
                            new LiteralExpression("<="),
                            new DateExpression("01/01/1981")
                        ),
                        new OrExpression(
                            new BooleanExpression(
                                new LiteralExpression("DEPARTMENT"),
                                new LiteralExpression("="),
                                new TextExpression("IT")
                            ),
                            new BooleanExpression(
                                new LiteralExpression("DEPARTMENT"),
                                new LiteralExpression("="),
                                new TextExpression("Accounting")
                            )
                        )
                    )
                )
            )
            );
            return select;
        }
    }

}


