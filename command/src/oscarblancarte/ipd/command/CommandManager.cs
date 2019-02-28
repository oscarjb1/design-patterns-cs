using System.Collections.Generic;
using oscarblancarte.ipd.command.impl;
using System; 

namespace oscarblancarte.ipd.command{
    public class CommandManager {

        private static CommandManager ConfManager;

        private static readonly Dictionary<String, Type> COMMANDS = new Dictionary<String, Type>();

        private CommandManager() {

            RegistCommand(EchoCommand.COMMAN_NAME, typeof(EchoCommand));
            RegistCommand(DirCommand.COMMAND_NAME, typeof(DirCommand));
            RegistCommand(DateTimeCommand.COMMAND_NAME, typeof(DateTimeCommand));
            RegistCommand(MemoryCommand.COMMAN_NAME, typeof(MemoryCommand));
            RegistCommand(FileCommand.COMMAND_NAME, typeof(FileCommand));
            RegistCommand(ExitCommand.COMMAND_NAME, typeof(ExitCommand));
            RegistCommand(BatchCommand.COMMAND_NAME, typeof(BatchCommand));
            RegistCommand(WaitAndSayHello.COMMAND_NAME, typeof(WaitAndSayHello));
        }

        public static CommandManager GetIntance() {
            if (ConfManager == null) {
                ConfManager = new CommandManager();
            }

            return ConfManager;
        }

        public ICommand GetCommand(String commandName) {

            if (COMMANDS.ContainsKey(commandName.ToUpper())) {
                try {
                    return (ICommand) Activator.CreateInstance(COMMANDS[commandName.ToUpper()]);
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                    return new ErrorCommand();
                }
            } else {
                return new NotFoundCommand();
            }
        }

        public void RegistCommand(string commandName, Type command) {
            COMMANDS.Add(commandName.ToUpper(), command);
        }
    }
}



