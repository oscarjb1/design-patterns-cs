using System;
using System.Runtime;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class MemoryCommand : BaseCommand {

        public static readonly string COMMAN_NAME = "memory";

        public override string getCommandName() {
            return COMMAN_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {
            double totalMemory = GC.GetTotalMemory(true); // 1000000d;
            string salida = "totalMemory: " + totalMemory;
            write(output, salida);
        }

    }
}


