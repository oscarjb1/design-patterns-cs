using System.IO;

namespace oscarblancarte.ipd.command{
    public interface ICommand {

        string GetCommandName();

        void Execute(string[] args, StreamWriter output);
    }
}


