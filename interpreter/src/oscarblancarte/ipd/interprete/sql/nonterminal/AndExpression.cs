using oscarblancarte.ipd.interprete.sql;
using System;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class AndExpression : StatementExpression {

        private readonly StatementExpression LeftStatement;
        private readonly StatementExpression RightStatement;

        public AndExpression(StatementExpression LeftStatement,StatementExpression RightStatement) {
            this.LeftStatement = LeftStatement;
            this.RightStatement = RightStatement;
        }

        public Object Interpret(Context context) {
            bool leftReslt = (bool) LeftStatement.Interpret(context);
            bool rightReslt = (bool) RightStatement.Interpret(context);
            return leftReslt && rightReslt;
        }

        public override string ToString() {
            return "( " + LeftStatement.ToString() + " AND " + RightStatement.ToString() + " )";
        }
    }

}


