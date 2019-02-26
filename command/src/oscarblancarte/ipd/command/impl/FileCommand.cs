using System;
using System.IO;


namespace oscarblancarte.ipd.command.impl{
    public class FileCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "file";
        private static readonly string WRITE_APPEND = "-WA";
        private static readonly string WRITE_OVERRIDE = "-WO";
        private static readonly string WRITE_NEW = "-WN";
        private static readonly string RENAME_FILE = "-R";
        private static readonly string DELETE_FILE = "-D";

        public override void execute(string[] args, StreamWriter output) {
            if (args.Length < 2) {
                write(output, "Insufficient parameters");
                return;
            }

            String operation = args[0].ToUpper();

            //String[] reduce = Arrays.copyOfRange(args, 1, args.length);

            string[] reduce = new String[args.Length-1];
            Array.Copy(args, 1, reduce, 0, args.Length);
            
            if (WRITE_APPEND.Equals(operation)) {
                write(output, writeAppend(reduce));
            } else if (WRITE_NEW.Equals(operation)) {
                write(output, writeNew(reduce));
            } else if (WRITE_OVERRIDE.Equals(operation)) {
                write(output, writeOverride(reduce));
            } else if (RENAME_FILE.Equals(operation)) {
                write(output, renameFile(reduce));
            } else if (DELETE_FILE.Equals(operation)) {
                write(output, deleteFile(reduce));
            } else {
                write(output, "Invalid operation {" + WRITE_APPEND + "|" + WRITE_NEW + "|" + WRITE_OVERRIDE + "|" + RENAME_FILE + "|DELETE_FILE}");
            }
        }

        private string renameFile(string[] args) {
            string filePath = args[0];
            string newFileName = args[1];
            try {
                File.Move(filePath, newFileName);
                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }
        }

        private string writeOverride(string[] args) {
            string filePath = args[0];
            string fileContent = args[1];

            try {
                if (!File.Exists(filePath)) {
                    using (StreamWriter sw = File.CreateText(filePath)){
                        sw.Write(fileContent);
                        sw.Flush();
                        sw.Close();
                    }
                }
                
                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }
        }

        private String writeAppend(String[] args) {
            String filePath = args[0];
            String fileContent = args[1];

            try {
                if (!File.Exists(filePath)) {
                    return "ERRRO: File not found";
                }

                using (StreamWriter sw = File.CreateText(filePath)){
                    sw.Write(fileContent);
                    sw.Flush();
                    sw.Close();
                }

                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }
        }

        private String writeNew(String[] args) {
            if(args.Length<2){
                return "Invalid arguments";
            }
            String filePath = args[0];
            String fileContent = args[1];

            try {
                if (File.Exists(filePath)) {
                    return "ERRRO: The file already exists";
                }
                using (StreamWriter sw = File.CreateText(filePath)){
                    sw.Write(fileContent);
                    sw.Flush();
                    sw.Close();
                }

                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }
        }

        private String deleteFile(String[] args) {
            String filePath = args[0];
            try{
                File.Delete(filePath);
            }
            catch (Exception e){
                return "ERROR: " + e.ToString();
            }
            
            return "";
        }

        public override String getCommandName() {
            return COMMAND_NAME;
        }
    }
}



