using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.terminal{
    public class TextExpression : LiteralExpression {

        public TextExpression(string Literal) : base(Literal){
        }
        
        public override Object Interpret(Context Context) {
            return Literal;
        }

        public override string ToString() {
            return "'"+Literal+"'";
        }
    }

}


