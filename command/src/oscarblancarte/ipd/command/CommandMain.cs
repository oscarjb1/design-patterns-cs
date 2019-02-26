using System;
using System.IO;

namespace oscarblancarte.ipd.command{
    public class CommandMain {

        static void Main(string[] args) {
            Console.WriteLine("Command Line is Start");
            CommandManager manager = CommandManager.getIntance();

            
            //Scanner in = new Scanner(System.in);
            while (true) {
                string line = Console.ReadLine();
                if (line.Trim().Length == 0) {
                    continue;
                }
                string[] commands = CommandUtil.tokenizerArgs(line);
                string commandName = commands[0];
                string[] commandArgs = new string[commands.Length-1];
                if (commands.Length > 1) {
                    Array.Copy(commands, 1, commandArgs, 0, commands.Length-1);
                }
                ICommand command = manager.getCommand(commandName);

                StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
                sw.AutoFlush = true;
                Console.SetOut(sw);

                command.execute(commandArgs, sw);
                Console.WriteLine("");
            }
        }
    }

}



