using System.IO;
using System.Threading;
using System;

namespace oscarblancarte.ipd.command.impl{
    public abstract class AsyncCommand : BaseCommand {
        

        public void StartThread(string[] args,  StreamWriter output){
            executeOnBackground(args, output);
        }

        public override void execute(string[] args,  StreamWriter output) {

            Thread thread = new Thread( () => StartThread(args, output));
            thread.Start();

        }

        public abstract void executeOnBackground(string[] args, StreamWriter output);
    }

}


