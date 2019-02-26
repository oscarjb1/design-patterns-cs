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

        protected string literal;

        public LiteralExpression(string literal)
        {
            this.literal = literal;
        }

        public virtual Object interpret(Context context)
        {
            return literal;
        }

        public override string ToString()
        {
            return literal;
        }
    }

}


