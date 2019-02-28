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
        private string DateFormat;
        private HSSFWorkbook Workboook;
        private ISheet Sheets;
        private string[] Columns;
        private readonly string DbPath;
        private IEnumerator<IRow> TableIterator;
        private readonly List<IRow> ResultRows = new List<IRow>();
        private IRow CurrentRow;
        private List<Object[]> Result;
        private int ResultColumnCount;

        public Context(string dbPath) {
            this.DbPath = dbPath;
            InitiateFileRead();
        }
        
        public void CreateResultArray(int columns){
            this.ResultColumnCount = columns;
            Result = new List<Object[]>();
        }

        public string GetDateFormat() {
            return DateFormat;
        }

        public void SetDateFormat(string dateFormat) {
            this.DateFormat = dateFormat;
        }
        
        public List<Object[]> GetResultArray(){
            return Result;
        }
        
        public Object[] CreateRow(){
            Object[] row = new Object[ResultColumnCount];
            Result.Add(row);
            return row;
        }
        
        public List<IRow> GetResultRow(){
            return ResultRows;
        }

        

        private void InitiateFileRead() {
            try {
                FileStream SourceStream = File.Open(DbPath, FileMode.Open);
                Workboook = new HSSFWorkbook(SourceStream);
            } catch (IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void CreateRowIterator() {
            TableIterator = (IEnumerator<IRow>) Sheets.GetRowEnumerator();
            TableIterator.MoveNext();
        }

        public IRow GetCurrentRow() {
            return CurrentRow;
        }

        public bool NextRow() {
            bool next = TableIterator.MoveNext();
            CurrentRow = TableIterator.Current;
            return next;
            /*if (tableIterator.hasNext()) {
                currentRow = tableIterator.next();
                return true;
            }
            return false;*/
        }

        public IEnumerator<IRow> GetRowIterator() {
            return TableIterator;
        }

        public void AddCurrentRowToResults() {
            ResultRows.Add(CurrentRow);
        }

        public void Destroy() {
            try {
                Workboook.Close();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public bool TableExist(string table) {
            return LoadTable(table);
        }

        private bool LoadTable(string table) {

            if (Columns != null) {
                return true;
            }
            
            Sheets = Workboook.GetSheet(table);
            if (Sheets == null) {
                return false;
            }
            foreach (IRow row in Sheets) {
                int lastRow = row.LastCellNum;
                Columns = new string[lastRow];
                int index = 0;
                foreach (ICell cell in row) {
                    Columns[index++] = cell.StringCellValue;
                }
                Console.WriteLine("Table > '" + table + "' Colums > '" + string.Join(" ", Columns) + "'");
                break;
            }
            return true;
        }

        public bool TableColumn(string column) {
            foreach (string col in Columns) {
                if (string.Equals(col,column,StringComparison.InvariantCultureIgnoreCase)) {
                    return true;
                }
            }
            return false;
        }

        public int ColumnIndex( string column) {
            for (int c = 0; c < Columns.Length; c++) {
                if (string.Equals(Columns[c],column,StringComparison.InvariantCultureIgnoreCase)) {
                    return c;
                }
            }
            throw new SystemException("Column '" + column + "' not exist");
        }
    }

}




