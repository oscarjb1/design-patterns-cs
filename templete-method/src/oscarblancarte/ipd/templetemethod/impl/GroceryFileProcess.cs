using oscarblancarte.ipd.templetemethod.util;
using System;
using System.IO;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.impl{
    public class GroceryFileProcess : AbstractFileProcessTemplete {

        private string log = "";

        public GroceryFileProcess(FileInfo file, string logPath, string movePath): base(file, logPath, movePath) {
            
        }

        protected override void validateName()  {
            string fileName = file.Name;
            if (!fileName.EndsWith(".gry")) {
                throw new Exception("Invalid file name" + ", must end with .gry");
            }

            if (fileName.Length != 7) {
                throw new Exception("Invalid document format");
            }
        }

        protected override void processFile()  {
            try {
                StreamReader stream = new StreamReader(file.OpenRead());  
                string line;
                while((line = stream.ReadLine()) != null)  
                { 
                    string[] fields = line.Split(",");
                    string id = fields[0];
                    string customer = fields[1];
                    double amount = double.Parse(fields[2]);
                    string date = fields[3];
                    bool exist = OnMemoryDataBase.customerExist(int.Parse(customer));

                    if (!exist) {
                        log += id + " E" + customer + "\t\t" + date + " Customer not exist\n";
                    } else if (amount > 200) {
                        log += id + " E" + customer + "\t\t" + date + " The amount exceeds the maximum\n";
                    } else {
                        log += id + " E" + customer + "\t\t" + date + " Successfully applied\n";
                    }
                }
                stream.Close(); 
            }catch(Exception e){
                throw new SystemException(e.ToString());
            }
        }

        protected override void createLog()  {
            try {
                File.WriteAllText(logPath + "/" + file.Name, log);
            } catch(Exception e) {
                throw new SystemException(e.ToString());
            }
        }
    }

}



