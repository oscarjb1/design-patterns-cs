// using org.apache.poi.hssf.usermodel;
// using org.apache.poi.hssf.usermodel.HSSFWorkbook;
// using org.apache.poi.ss.usermodel.Cell;
// using org.apache.poi.ss.usermodel.Row;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.interprete.sql{
    public class Context {
        private string dateFormat;
        private HSSFWorkbook workboook;
        private ISheet sheets;
        private string[] columns;
        private readonly string dbPath;
        private IEnumerator<IRow> tableIterator;
        private readonly List<IRow> resultRows = new List<IRow>();
        private IRow currentRow;
        private List<Object[]> result;
        private int resultColumnCount;

        public Context(string dbPath) {
            this.dbPath = dbPath;
            initiateFileRead();
        }
        
        public void createResultArray(int columns){
            this.resultColumnCount = columns;
            result = new List<Object[]>();
        }

        public string getDateFormat() {
            return dateFormat;
        }

        public void setDateFormat(string dateFormat) {
            this.dateFormat = dateFormat;
        }
        
        public List<Object[]> getResultArray(){
            return result;
        }
        
        public Object[] createRow(){
            Object[] row = new Object[resultColumnCount];
            result.Add(row);
            return row;
        }
        
        public List<IRow> getResultRow(){
            return resultRows;
        }

        

        private void initiateFileRead() {
            try {
                FileStream SourceStream = File.Open(dbPath, FileMode.Open);
                workboook = new HSSFWorkbook(SourceStream);
            } catch (IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void createRowIterator() {
            tableIterator = (IEnumerator<IRow>) sheets.GetRowEnumerator();
            tableIterator.MoveNext();
        }

        public IRow getCurrentRow() {
            return currentRow;
        }

        public bool nextRow() {
            bool next = tableIterator.MoveNext();
            currentRow = tableIterator.Current;
            return next;
            /*if (tableIterator.hasNext()) {
                currentRow = tableIterator.next();
                return true;
            }
            return false;*/
        }

        public IEnumerator<IRow> getRowIterator() {
            return tableIterator;
        }

        public void addCurrentRowToResults() {
            resultRows.Add(currentRow);
        }

        public void destroy() {
            try {
                workboook.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public bool tableExist(string table) {
            return loadTable(table);
        }

        private bool loadTable(string table) {

            if (columns != null) {
                return true;
            }
            
            sheets = workboook.GetSheet(table);
            if (sheets == null) {
                return false;
            }
            foreach (IRow row in sheets) {
                int lastRow = row.LastCellNum;
                columns = new string[lastRow];
                int index = 0;
                foreach (ICell cell in row) {
                    columns[index++] = cell.StringCellValue;
                }
                Console.WriteLine("Table > '" + table + "' Colums > '" + string.Join(" ", columns) + "'");
                break;
            }
            return true;
        }

        public bool tableColumn(string column) {
            foreach (string col in columns) {
                if (string.Equals(col,column,StringComparison.InvariantCultureIgnoreCase)) {
                    return true;
                }
            }
            return false;
        }

        public int columnIndex( string column) {
            for (int c = 0; c < columns.Length; c++) {
                if (string.Equals(columns[c],column,StringComparison.InvariantCultureIgnoreCase)) {
                    return c;
                }
            }
            throw new SystemException("Column '" + column + "' not exist");
        }
    }

}




