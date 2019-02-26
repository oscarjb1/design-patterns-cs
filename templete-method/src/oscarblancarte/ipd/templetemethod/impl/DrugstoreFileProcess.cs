using System;
using System.IO;
using oscarblancarte.ipd.templetemethod.util;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.impl{
    public class DrugstoreFileProcess : AbstractFileProcessTemplete {

        private string log = "";

        public DrugstoreFileProcess(FileInfo file, string logPath, string movePath) : base(file, logPath, movePath){
            
        }

        protected override void validateName()  {
            string fileName = file.Name;
            if (!fileName.EndsWith(".drug")) {
                throw new Exception("Invalid file name format"
                        + ", must end with .drug");
            }

            if (fileName.Length != 16) {
                throw new Exception("Invalid document format");
            }
        }

        protected override void processFile()  {
            try {
                StreamReader stream = new StreamReader(file.OpenRead());  
                string line;
                while((line = stream.ReadLine()) != null)  
                { 
                    string id = line.Substring(0, 3);
                    string customer = line.Substring(3, 2);
                    double amount = double.Parse(line.Substring(5, 3));
                    string date = line.Substring(8, 8);
                    bool exist = OnMemoryDataBase.customerExist(int.Parse(customer));

                    if (!exist) {
                        log += id + " E" + customer + "\t\t" + date + " Customer not exist\n";
                    } else if (amount > 200) {
                        log += id + " E" + customer + "\t\t" + date + " The amount exceeds the maximum\n";
                    } else {
                        //TODO Aplicar el pago en algún lugar.
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


