using oscarblancarte.ipd.interprete.sql;
using System.Collections.Generic;
using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
 
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class SelectExpression {

        private readonly TargetExpression target;
        private readonly FromExpression from;
        private readonly WhereExpression where;
        
        public SelectExpression(TargetExpression columns, FromExpression table,WhereExpression where){
            this.target = columns;
            this.from = table;
            this.where = where;
        }
        
        public SelectExpression(TargetExpression columns, FromExpression table){
            this.target = columns;
            this.from = table;
            this.where = new WhereExpression(null);
        }
        
        public List<Object[]> interpret(Context context) {
            from.interpret(context);
            where.interpret(context);
            target.interpret(context);
            return context.getResultArray();
        }

        public override string ToString() {
            return "SELECT " + target.ToString() + " " + from.ToString() + " " +  where.ToString();
        }
    }

}


