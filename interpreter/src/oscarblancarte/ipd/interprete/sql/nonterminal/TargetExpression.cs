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

    private List<LiteralExpression> Targets = new List<LiteralExpression>();

    public TargetExpression(params LiteralExpression[] expressions) {
        //this.targets = Arrays.asList(expressions);
        Targets = expressions.OfType<LiteralExpression>().ToList(); // this isn't going to be fast.
    }

    public Object Interpret(Context context) {
        context.CreateResultArray(Targets.Count);

        List<IRow> resultRow = context.GetResultRow();
        foreach (IRow row in resultRow) {
            Object[] result = context.CreateRow();
            int col = 0;
            
            foreach (LiteralExpression literalExpression in Targets) {
                string column = literalExpression.Interpret(context).ToString();
                context.TableColumn(column);
                int columnIndex = context.ColumnIndex(column);
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
        foreach (LiteralExpression literalExpression in Targets) {
            output += ", " + literalExpression.ToString();
        }
        Console.WriteLine("outpu > " + output);
        return output.Substring(2);
    }
}

}


