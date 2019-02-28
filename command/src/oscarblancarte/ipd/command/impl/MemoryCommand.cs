using System;
using System.Runtime;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class MemoryCommand : BaseCommand {

        public static readonly string COMMAN_NAME = "memory";

        public override string GetCommandName() {
            return COMMAN_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {
            double totalMemory = GC.GetTotalMemory(true); // 1000000d;
            string salida = "totalMemory: " + totalMemory;
            Write(output, salida);
        }

    }
}


