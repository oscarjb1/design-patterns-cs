using oscarblancarte.ipd.command;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace oscarblancarte.ipd.command.impl{
    public class BatchCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "batch";

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {

            if (args == null || args.Length < 1) {
                Write(output, "Insufficient arguments");
                return;
            }

            CommandManager manager = CommandManager.GetIntance();
            string[] lines = ReadLinesFromFile(args[0]);
            foreach (string line in lines) {
                string[] argsCommand = CommandUtil.TokenizerArgs(line);
                ICommand command = manager.GetCommand(argsCommand[0]);

                string[] reduce = new string[argsCommand.Length-1];
                Array.Copy(argsCommand, 1, reduce, 0, argsCommand.Length);
                command.Execute(reduce, output);
                Write(output, "\n");
            }
            Write(output, "Batch executed");
        }

        private string[] ReadLinesFromFile(string filePath)  {
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