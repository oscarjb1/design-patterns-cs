using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class OrExpression : StatementExpression{
        private StatementExpression LeftStatement;
        private StatementExpression RightStatement;

        public OrExpression(StatementExpression LeftStatement, StatementExpression RightStatement) {
            this.LeftStatement = LeftStatement;
            this.RightStatement = RightStatement;
        }

        public Object Interpret(Context context) {
            bool leftReslt = (bool) LeftStatement.Interpret(context);
            bool rightReslt = (bool) RightStatement.Interpret(context);
            return leftReslt || rightReslt;
        }

        public override string ToString() {
            return "( "+LeftStatement.ToString() + " OR " + RightStatement.ToString() + " )";
        }
    }

}


