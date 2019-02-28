using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.terminal
{
    public class LiteralExpression
    {

        protected string Literal;

        public LiteralExpression(string Literal)
        {
            this.Literal = Literal;
        }

        public virtual Object Interpret(Context context)
        {
            return Literal;
        }

        public override string ToString()
        {
            return Literal;
        }
    }

}


