using System.IO;
using oscarblancarte.ipd.command;
using System;

namespace oscarblancarte.ipd.command.impl{

    public abstract class BaseCommand : ICommand {

        public abstract string getCommandName();

        public abstract void execute(string[] args, StreamWriter output);

        public void write(StreamWriter output, string message) {
            try {
                output.Write(message);
                output.Flush();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}


