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

        private readonly LiteralExpression leftExpression;
        private readonly LiteralExpression booleanOperator;
        private readonly LiteralExpression rightExpression;

        public BooleanExpression(LiteralExpression leftExp, LiteralExpression operators, LiteralExpression rightExp) {
            this.leftExpression = leftExp;
            this.booleanOperator = operators;
            this.rightExpression = rightExp;
        }

        public Object interpret(Context context)  {
            IRow currentRow = context.getCurrentRow();

            String left = leftExpression.interpret(context).ToString();
            String opr = booleanOperator.interpret(context).ToString();
            Object right = rightExpression.interpret(context);

            int columnIndex = context.columnIndex(left);
            ICell cell = currentRow.GetCell(columnIndex);

            if (rightExpression.GetType() == typeof(NumericExpression)) {
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
            } else if (rightExpression.GetType() == typeof(DateExpression)) {
                cell.SetCellType(CellType.String);
                String cellValue = cell.StringCellValue;
                long cellDateLong = 0;
                long expressionDateLong = ((DateTime) right).Ticks;
                try {
                    DateTime date = DateTime.ParseExact(cellValue, context.getDateFormat(),CultureInfo.InvariantCulture);
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
            } else if ( (rightExpression.GetType() == typeof(LiteralExpression)) || (rightExpression.GetType() == typeof(TextExpression))) {
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
            return leftExpression.ToString() + " " + booleanOperator.ToString() + " " + rightExpression.ToString();
        }

        
    }
}


