using System;
using System.IO;
using System.Threading;

namespace oscarblancarte.ipd.command.impl{

    public class WaitAndSayHello : AsyncCommand {

        public static readonly string COMMAND_NAME = "waithello";

        public override void executeOnBackground(string[] args, StreamWriter output) {
            if (args == null || args.Length < 1) {
                write(output, "Insufficient parameters");
                return;
            }

            int time = 0;
            try {
                time = int.Parse(args[0]);
            } catch (Exception e) {
                write(output, "Invalid time");
                return;
            }

            try {
                Thread.Sleep(time);
                write(output, "Hello!!");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public override string getCommandName() {
            return COMMAND_NAME;
        }

    }
}