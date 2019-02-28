
using System.IO;
using oscarblancarte.ipd.command;
using System;

namespace oscarblancarte.ipd.command.impl{

    public class ExitCommand : ICommand {

        public static readonly string COMMAND_NAME = "exit";

        public string GetCommandName() {
            return COMMAND_NAME;
        }

        public void Execute(string[] args, StreamWriter output) {
            Environment.Exit(0);
        }
    }
}

