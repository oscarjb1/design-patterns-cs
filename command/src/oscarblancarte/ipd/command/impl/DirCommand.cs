using System;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class DirCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "dir";

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {
            if (args == null || args.Length < 2) {
                Write(output, COMMAND_NAME + " insufficient arguments");
            }

            string operation = args[0];
            if ("-D".Equals(operation.ToUpper())) {
                Write(output, DeleteDir(args[1]));
            } else if ("-N".Equals(operation.ToUpper())) {
                Write(output, NewDir(args[1]));
            } else {
                Write(output, "Invalid argument {-d | -n}");
            }
        }

        private string DeleteDir(string url) {
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

        private string NewDir(string url) {
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


