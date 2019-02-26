using System;
using System.IO;

    namespace oscarblancarte.ipd.command.impl{
    public class NotFoundCommand : BaseCommand {

        private static readonly string COMMAND_NAME = "NOT FOUND";

        public override string getCommandName() {
            return COMMAND_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {
            write(output, "Command not found");
        }
    }

}


