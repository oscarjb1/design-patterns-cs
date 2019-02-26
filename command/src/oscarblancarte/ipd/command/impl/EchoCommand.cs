using System;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class EchoCommand : BaseCommand {

        public static readonly string COMMAN_NAME = "echo";

        public override void execute(string[] args, StreamWriter output) {
            string message = getCommandName() + " " + string.Join(" ", args);
            write(output, message);
        }

        public override string getCommandName() {
            return COMMAN_NAME;
        }
    }
}



