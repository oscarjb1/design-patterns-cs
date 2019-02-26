using oscarblancarte.ipd.interprete.sql;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.terminal{
    public class NumericExpression : LiteralExpression{
        
        private readonly Int64 number;
        
        public NumericExpression(Int64 num): base(null){
            this.number = num;
        }

        public override Object interpret(Context context) {
            return number;
        }

        public override string ToString() {
            return number.ToString();
        }
        
    }

}


