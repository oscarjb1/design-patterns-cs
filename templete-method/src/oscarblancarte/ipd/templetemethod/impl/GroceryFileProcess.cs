using oscarblancarte.ipd.templetemethod.util;
using System;
using System.IO;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.impl{
    public class GroceryFileProcess : AbstractFileProcessTemplete {

        private string Log = "";

        public GroceryFileProcess(FileInfo File, string LogPath, string MovePath): base(File, LogPath, MovePath) {
            
        }

        protected override void ValidateName()  {
            string fileName = File.Name;
            if (!fileName.EndsWith(".gry")) {
                throw new Exception("Invalid file name" + ", must end with .gry");
            }

            if (fileName.Length != 7) {
                throw new Exception("Invalid document format");
            }
        }

        protected override void ProcessFile()  {
            try {
                StreamReader stream = new StreamReader(File.OpenRead());  
                string line;
                while((line = stream.ReadLine()) != null)  
                { 
                    string[] fields = line.Split(",");
                    string id = fields[0];
                    string customer = fields[1];
                    double amount = double.Parse(fields[2]);
                    string date = fields[3];
                    bool exist = OnMemoryDataBase.CustomerExist(int.Parse(customer));

                    if (!exist) {
                        Log += id + " E" + customer + "\t\t" + date + " Customer not exist\n";
                    } else if (amount > 200) {
                        Log += id + " E" + customer + "\t\t" + date + " The amount exceeds the maximum\n";
                    } else {
                        Log += id + " E" + customer + "\t\t" + date + " Successfully applied\n";
                    }
                }
                stream.Close(); 
            }catch(Exception e){
                throw new SystemException(e.ToString());
            }
        }

        protected override void CreateLog()  {
            try {
                System.IO.File.WriteAllText(LogPath + "/" + File.Name, Log);
            } catch(Exception e) {
                throw new SystemException(e.ToString());
            }
        }
    }

}



