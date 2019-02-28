using oscarblancarte.ipd.templetemethod.impl;
using System;
using System.Threading;
using System.IO;
using System.Timers;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod{
    public class TempleteMethodMain  {
        
        private static readonly string[] PATHS = new string[]{"C:/files/drugstore", "C:/files/grocery"};
        private static readonly string LOG_DIR = "C:/files/logs";
        private static readonly string PROCESS_DIR = "C:/files/process";

        static void Main(string[] args) {
            new TempleteMethodMain().Start();
        }

        public void Start() {
            try {
                //Timer timer = new Timer();
                //timer.schedule(this, DateTime.Now, (long) 1000 * 10);
                //System.in.read();

                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
                // Set the Interval to 5 seconds.
                aTimer.Interval=5000;
                aTimer.Enabled=true;

                while(Console.Read()!='q');
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs eea){
            Console.WriteLine("> Monitoring start");
            if(!Directory.Exists(PATHS[0])){
                throw new SystemException("El path '"+PATHS[0]+"' no existe");
            }
            Console.WriteLine("> Read Path " + PATHS[0]);

            string[] drugstoreFiles = Directory.GetFiles(PATHS[0]);
            foreach(string file in drugstoreFiles) {
                try {
                    Console.WriteLine("> File found > " + file);
                    FileInfo fileInfo = new FileInfo(file);
                    new DrugstoreFileProcess(fileInfo,LOG_DIR,PROCESS_DIR).Execute();
                    Console.WriteLine("Processed file > " + file);
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
            
            if(!Directory.Exists(PATHS[1])){
                throw new SystemException("El path '"+PATHS[1]+"' no existe");
            }
            Console.WriteLine("> Read Path " + PATHS[1]);

            string[] groceryFiles = Directory.GetFiles(PATHS[1]);
            foreach (string file in groceryFiles) {
                try {
                    Console.WriteLine("> File found > " + file);
                    FileInfo fileInfo = new FileInfo(file);
                    new GroceryFileProcess(fileInfo,LOG_DIR,PROCESS_DIR).Execute();
                    Console.WriteLine("Processed file > " + file);
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}


