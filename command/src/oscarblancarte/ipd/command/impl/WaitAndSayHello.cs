using System;
using System.IO;
using System.Threading;

namespace oscarblancarte.ipd.command.impl{

    public class WaitAndSayHello : AsyncCommand {

        public static readonly string COMMAND_NAME = "waithello";

        public override void ExecuteOnBackground(string[] args, StreamWriter output) {
            if (args == null || args.Length < 1) {
                Write(output, "Insufficient parameters");
                return;
            }

            int time = 0;
            try {
                time = int.Parse(args[0]);
            } catch (Exception e) {
                Write(output, "Invalid time");
                return;
            }

            try {
                Thread.Sleep(time);
                Write(output, "Hello!!");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

    }
}