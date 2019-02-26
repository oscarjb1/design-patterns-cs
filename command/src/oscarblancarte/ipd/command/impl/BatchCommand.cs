using oscarblancarte.ipd.command;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace oscarblancarte.ipd.command.impl{
    public class BatchCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "batch";

        public override string getCommandName() {
            return COMMAND_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {

            if (args == null || args.Length < 1) {
                write(output, "Insufficient arguments");
                return;
            }

            CommandManager manager = CommandManager.getIntance();
            string[] lines = readLinesFromFile(args[0]);
            foreach (string line in lines) {
                string[] argsCommand = CommandUtil.tokenizerArgs(line);
                ICommand command = manager.getCommand(argsCommand[0]);

                string[] reduce = new string[argsCommand.Length-1];
                Array.Copy(argsCommand, 1, reduce, 0, argsCommand.Length);
                command.execute(reduce, output);
                write(output, "\n");
            }
            write(output, "Batch executed");
        }

        private string[] readLinesFromFile(string filePath)  {
            try {
                if (!File.Exists(filePath)) {
                    throw new SystemException("File not Found");
                }
                IEnumerable<string> linesEnum = File.ReadLines(filePath);
                string[] lines = linesEnum.ToArray();
                return lines;
            } catch (Exception e) {
                throw new SystemException(e.ToString());
            } 
        }

    }
}