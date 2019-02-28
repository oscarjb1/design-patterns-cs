using System;
using System.IO;
using oscarblancarte.ipd.templetemethod.util;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.impl{
    public abstract class AbstractFileProcessTemplete {

        protected FileInfo File;
        protected string LogPath;
        protected string MovePath;

        public AbstractFileProcessTemplete(FileInfo File, string LogPath, string MovePath) {
            this.File = File;
            this.LogPath = LogPath;
            this.MovePath = MovePath;
        }

        public void Execute()  {
            ValidateName();
            ValidateProcess();
            ProcessFile();
            CreateLog();
            MoveDocument();
            MarkAsProcessFile();
        }

        protected abstract void ValidateName() ;

        protected void ValidateProcess()  {
            string fileStatus = OnMemoryDataBase.GetFileStatus(File.Name);
            if (fileStatus != null && fileStatus.Equals("Processed")) {
                throw new Exception("The file '" + File.Name + "' has already been processed");
            }
        }

        protected abstract void ProcessFile();

        protected abstract void CreateLog();

        private void MoveDocument()  {
            string newPath = MovePath+"/"+File.Name;
            Console.WriteLine("Move file => " + newPath);
            File.MoveTo(newPath);
        }
        
        protected void MarkAsProcessFile() {
            OnMemoryDataBase.SetProcessFile(File.Name);
        }
    }
}


