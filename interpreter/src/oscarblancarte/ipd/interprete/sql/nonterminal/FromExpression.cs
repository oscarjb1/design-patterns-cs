using oscarblancarte.ipd.interprete.sql;
using oscarblancarte.ipd.interprete.sql.terminal;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class FromExpression : AbstractSQLExpression {
        
        private LiteralExpression table;
        
        public FromExpression(LiteralExpression from){
            this.table = from;
        }

        public Object interpret(Context context) {
            string tableName = table.interpret(context).ToString();
            if(!context.tableExist(tableName)){
                throw new InterpreteException("The table '"+tableName+"' not exist");
            }
            return null;
        }

        public override string ToString() {
            return "FROM " + table.ToString();
        }
    }

}



