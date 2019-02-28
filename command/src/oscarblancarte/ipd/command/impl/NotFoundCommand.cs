using System;
using System.IO;

    namespace oscarblancarte.ipd.command.impl{
    public class NotFoundCommand : BaseCommand {

        private static readonly string COMMAND_NAME = "NOT FOUND";

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {
            Write(output, "Command not found");
        }
    }

}


