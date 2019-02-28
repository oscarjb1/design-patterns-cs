using oscarblancarte.ipd.interprete.sql;
using oscarblancarte.ipd.interprete.sql.terminal;
using System;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Record;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.Globalization;


/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql.nonterminal{
    public class BooleanExpression : StatementExpression {

        private readonly LiteralExpression LeftExpression;
        private readonly LiteralExpression BooleanOperator;
        private readonly LiteralExpression RightExpression;

        public BooleanExpression(LiteralExpression leftExp, LiteralExpression operators, LiteralExpression rightExp) {
            this.LeftExpression = leftExp;
            this.BooleanOperator = operators;
            this.RightExpression = rightExp;
        }

        public Object Interpret(Context context)  {
            IRow currentRow = context.GetCurrentRow();

            String left = LeftExpression.Interpret(context).ToString();
            String opr = BooleanOperator.Interpret(context).ToString();
            Object right = RightExpression.Interpret(context);

            int columnIndex = context.ColumnIndex(left);
            ICell cell = currentRow.GetCell(columnIndex);

            if (RightExpression.GetType() == typeof(NumericExpression)) {
                cell.SetCellType(CellType.Numeric);
                double cellValue = cell.NumericCellValue;
                double rightVal = ((Int64) right);
                if (opr.Equals("=")) {
                    return cellValue == rightVal;
                } else if (opr.Equals("<>") || opr.Equals("!=")) {
                    return cellValue != rightVal;
                } else if (opr.Equals(">")) {
                    return cellValue > rightVal;
                } else if (opr.Equals(">=")) {
                    return cellValue >= rightVal;
                } else if (opr.Equals("<")) {
                    return cellValue < rightVal;
                } else if (opr.Equals("<=")) {
                    return cellValue <= rightVal;
                } else {
                    throw new SystemException("Unexpected operator '" + opr + "'");
                }
            } else if (RightExpression.GetType() == typeof(DateExpression)) {
                cell.SetCellType(CellType.String);
                String cellValue = cell.StringCellValue;
                long cellDateLong = 0;
                long expressionDateLong = ((DateTime) right).Ticks;
                try {
                    DateTime date = DateTime.ParseExact(cellValue, context.GetDateFormat(),CultureInfo.InvariantCulture);
                    cellDateLong = date.Ticks;
                } catch (Exception e) {
                    throw new InterpreteException("Invalid date > " + cellValue + ", " + e.ToString());
                }
                if (opr.Equals("=")) {
                    return cellDateLong == expressionDateLong;
                } else if (opr.Equals("<>") || opr.Equals("!=")) {
                    return cellDateLong != expressionDateLong;
                } else if (opr.Equals(">")) {
                    return cellDateLong > expressionDateLong;
                } else if (opr.Equals(">=")) {
                    return cellDateLong >= expressionDateLong;
                } else if (opr.Equals("<")) {
                    return cellDateLong < expressionDateLong;
                } else if (opr.Equals("<=")) {
                    return cellDateLong <= expressionDateLong;
                } else {
                    throw new SystemException("Unexpected operator '" + opr + "'");
                }
            } else if ( (RightExpression.GetType() == typeof(LiteralExpression)) || (RightExpression.GetType() == typeof(TextExpression))) {
                cell.SetCellType(CellType.String);
                string cellValue = cell.StringCellValue;
                string rightVal = right.ToString();
                if (opr.Equals("=")) {
                    return cellValue.Equals(rightVal);
                } else if (opr.Equals("<>") || opr.Equals("!=")) {
                    return !string.Equals(cellValue, rightVal, StringComparison.OrdinalIgnoreCase);
                } else if (opr.Equals(">")) {
                    int result = String.Compare(cellValue.ToString(), rightVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return result > 0;
                } else if (opr.Equals(">=")) {
                    int result = String.Compare(cellValue.ToString(), rightVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return result >= 0;
                } else if (opr.Equals("<")) {
                    int result = String.Compare(cellValue.ToString(), rightVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return result < 0;
                } else if (opr.Equals("<=")) {
                    int result = String.Compare(cellValue.ToString(), rightVal.ToString(), StringComparison.OrdinalIgnoreCase);
                    return result <= 0;
                } else {
                    throw new SystemException("Unexpected operator '" + opr + "'");
                }
            } else {
                throw new SystemException("Type of cell not supported " + right.GetType().Name );
            }
        }

        public override string ToString() {
            return LeftExpression.ToString() + " " + BooleanOperator.ToString() + " " + RightExpression.ToString();
        }

        
    }
}


