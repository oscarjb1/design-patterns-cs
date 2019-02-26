using System.IO;

namespace oscarblancarte.ipd.command{
    public interface ICommand {

        string getCommandName();

        void execute(string[] args, StreamWriter output);
    }
}


