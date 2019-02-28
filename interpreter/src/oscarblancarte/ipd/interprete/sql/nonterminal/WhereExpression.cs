using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class WhereExpression : AbstractSQLExpression {

        private StatementExpression Statement;

        public WhereExpression(StatementExpression Statement) {
            this.Statement = Statement;
        }

        public Object Interpret(Context context)  {
            context.CreateRowIterator();
            while (context.NextRow()) {
                if (Statement == null) {
                    context.AddCurrentRowToResults();
                } else {
                    bool result = (bool) Statement.Interpret(context);
                    if (result) {
                        context.AddCurrentRowToResults();
                    }
                }
            }
            return null;
        }

        public override string ToString() {
            if (Statement != null) {
                return "\nWHERE " + Statement.ToString();
            } else {
                return "";
            }
        }
    }

}


