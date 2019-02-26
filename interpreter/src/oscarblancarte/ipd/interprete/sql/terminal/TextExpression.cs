using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.terminal{
    public class TextExpression : LiteralExpression {

        public TextExpression(string literal) : base(literal){
        }
        
        public override Object interpret(Context context) {
            return literal;
        }

        public override string ToString() {
            return "'"+literal+"'";
        }
    }

}


