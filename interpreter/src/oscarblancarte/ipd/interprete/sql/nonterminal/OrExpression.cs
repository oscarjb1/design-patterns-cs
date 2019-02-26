using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class OrExpression : StatementExpression{
        private StatementExpression leftStatement;
        private StatementExpression rightStatement;

        public OrExpression(StatementExpression leftStatement, StatementExpression rightStatement) {
            this.leftStatement = leftStatement;
            this.rightStatement = rightStatement;
        }

        public Object interpret(Context context) {
            bool leftReslt = (bool) leftStatement.interpret(context);
            bool rightReslt = (bool) rightStatement.interpret(context);
            return leftReslt || rightReslt;
        }

        public override string ToString() {
            return "( "+leftStatement.ToString() + " OR " + rightStatement.ToString() + " )";
        }
    }

}


