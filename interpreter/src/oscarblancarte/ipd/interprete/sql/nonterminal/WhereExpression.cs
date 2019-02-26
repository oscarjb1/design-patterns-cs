using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class WhereExpression : AbstractSQLExpression {

        private StatementExpression statement;

        public WhereExpression(StatementExpression statement) {
            this.statement = statement;
        }

        public Object interpret(Context context)  {
            context.createRowIterator();
            while (context.nextRow()) {
                if (statement == null) {
                    context.addCurrentRowToResults();
                } else {
                    bool result = (bool) statement.interpret(context);
                    if (result) {
                        context.addCurrentRowToResults();
                    }
                }
            }
            return null;
        }

        public override string ToString() {
            if (statement != null) {
                return "\nWHERE " + statement.ToString();
            } else {
                return "";
            }
        }
    }

}


