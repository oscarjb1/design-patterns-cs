
using System.IO;
using oscarblancarte.ipd.command;
using System;

namespace oscarblancarte.ipd.command.impl{

    public class ExitCommand : ICommand {

        public static readonly string COMMAND_NAME = "exit";

        public string getCommandName() {
            return COMMAND_NAME;
        }

        public void execute(string[] args, StreamWriter output) {
            Environment.Exit(0);
        }
    }
}

