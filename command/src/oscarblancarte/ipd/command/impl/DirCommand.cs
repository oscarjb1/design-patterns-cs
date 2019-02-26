using System;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class DirCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "dir";

        public override string getCommandName() {
            return COMMAND_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {
            if (args == null || args.Length < 2) {
                write(output, COMMAND_NAME + " insufficient arguments");
            }

            string operation = args[0];
            if ("-D".Equals(operation.ToUpper())) {
                write(output, deleteDir(args[1]));
            } else if ("-N".Equals(operation.ToUpper())) {
                write(output, newDir(args[1]));
            } else {
                write(output, "Invalid argument {-d | -n}");
            }
        }

        private string deleteDir(string url) {
            try {
                
                FileAttributes attr = File.GetAttributes(url);

                if (attr.HasFlag(FileAttributes.Directory))
                    Directory.Delete(url);
                else
                    File.Delete(url);
                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }

        }

        private string newDir(string url) {
            try {
                if (File.Exists(url)) {
                    return "File not found";
                }

                Directory.CreateDirectory(url);
                return "";
            } catch (Exception e) {
                return "ERROR: " + e.ToString();
            }
        }

    }
}


