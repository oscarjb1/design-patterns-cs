using oscarblancarte.ipd.interprete.sql;
using oscarblancarte.ipd.interprete.sql.terminal;
using System;
using System.Collections.Generic;
using System.Linq;

using NPOI.HSSF.UserModel;
using NPOI.HSSF.Record;
using System.Text;
using NPOI.SS.UserModel;
/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class TargetExpression : AbstractSQLExpression {

    private List<LiteralExpression> targets = new List<LiteralExpression>();

    public TargetExpression(params LiteralExpression[] expressions) {
        //this.targets = Arrays.asList(expressions);
        targets = expressions.OfType<LiteralExpression>().ToList(); // this isn't going to be fast.
    }

    public Object interpret(Context context) {
        context.createResultArray(targets.Count);

        List<IRow> resultRow = context.getResultRow();
        foreach (IRow row in resultRow) {
            Object[] result = context.createRow();
            int col = 0;
            
            foreach (LiteralExpression literalExpression in targets) {
                string column = literalExpression.interpret(context).ToString();
                context.tableColumn(column);
                int columnIndex = context.columnIndex(column);
                ICell cell = row.GetCell(columnIndex);
                cell.SetCellType(CellType.String);
                string value = cell.StringCellValue;
                result[col++] = value;
            }
        }
        return null;
    }

    public override string ToString() {
        string output = "";
        foreach (LiteralExpression literalExpression in targets) {
            output += ", " + literalExpression.ToString();
        }
        Console.WriteLine("outpu > " + output);
        return output.Substring(2);
    }
}

}


