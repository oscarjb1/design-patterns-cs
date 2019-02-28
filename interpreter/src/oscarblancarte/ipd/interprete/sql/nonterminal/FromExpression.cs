using oscarblancarte.ipd.interprete.sql;
using oscarblancarte.ipd.interprete.sql.terminal;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class FromExpression : AbstractSQLExpression {
        
        private LiteralExpression Table;
        
        public FromExpression(LiteralExpression from){
            this.Table = from;
        }

        public Object Interpret(Context context) {
            string tableName = Table.Interpret(context).ToString();
            if(!context.TableExist(tableName)){
                throw new InterpreteException("The table '"+tableName+"' not exist");
            }
            return null;
        }

        public override string ToString() {
            return "FROM " + Table.ToString();
        }
    }

}



