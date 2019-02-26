using System;
using System.IO;
using oscarblancarte.ipd.templetemethod.util;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.impl{
    public abstract class AbstractFileProcessTemplete {

        protected FileInfo file;
        protected string logPath;
        protected string movePath;

        public AbstractFileProcessTemplete(FileInfo file, string logPath, string movePath) {
            this.file = file;
            this.logPath = logPath;
            this.movePath = movePath;
        }

        public void execute()  {
            validateName();
            validateProcess();
            processFile();
            createLog();
            moveDocument();
            markAsProcessFile();
        }

        protected abstract void validateName() ;

        protected void validateProcess()  {
            string fileStatus = OnMemoryDataBase.getFileStatus(file.Name);
            if (fileStatus != null && fileStatus.Equals("Processed")) {
                throw new Exception("The file '" + file.Name + "' has already been processed");
            }
        }

        protected abstract void processFile();

        protected abstract void createLog();

        private void moveDocument()  {
            string newPath = movePath+"/"+file.Name;
            Console.WriteLine("Move file => " + newPath);
            file.MoveTo(newPath);
        }
        
        protected void markAsProcessFile() {
            OnMemoryDataBase.setProcessFile(file.Name);
        }
    }
}


