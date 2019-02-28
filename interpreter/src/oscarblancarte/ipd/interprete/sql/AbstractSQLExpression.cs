using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql{
    public interface AbstractSQLExpression {
        Object Interpret(Context context) ;
    }
}


