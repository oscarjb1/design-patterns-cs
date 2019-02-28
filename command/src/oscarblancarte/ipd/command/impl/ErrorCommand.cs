using System.IO;
using System;

namespace oscarblancarte.ipd.command.impl{
    public class ErrorCommand : BaseCommand {

        private static readonly string COMMAND_NAME = "ERROR";

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {
            string message = "Invocation error";
            Write(output, message);
        }

    }
}



