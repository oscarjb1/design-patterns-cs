using System.IO;
using System;

namespace oscarblancarte.ipd.command.impl{
    public class ErrorCommand : BaseCommand {

        private static readonly string COMMAND_NAME = "ERROR";

        public override string getCommandName() {
            return COMMAND_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {
            string message = "Invocation error";
            write(output, message);
        }

    }
}



