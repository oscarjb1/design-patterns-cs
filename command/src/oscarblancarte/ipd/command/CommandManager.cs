using System.Collections.Generic;
using oscarblancarte.ipd.command.impl;
using System; 

namespace oscarblancarte.ipd.command{
    public class CommandManager {

        private static CommandManager commandManager;

        private static readonly Dictionary<String, Type> COMMANDS = new Dictionary<String, Type>();

        private CommandManager() {

            registCommand(EchoCommand.COMMAN_NAME, typeof(EchoCommand));
            registCommand(DirCommand.COMMAND_NAME, typeof(DirCommand));
            registCommand(DateTimeCommand.COMMAND_NAME, typeof(DateTimeCommand));
            registCommand(MemoryCommand.COMMAN_NAME, typeof(MemoryCommand));
            registCommand(FileCommand.COMMAND_NAME, typeof(FileCommand));
            registCommand(ExitCommand.COMMAND_NAME, typeof(ExitCommand));
            registCommand(BatchCommand.COMMAND_NAME, typeof(BatchCommand));
            registCommand(WaitAndSayHello.COMMAND_NAME, typeof(WaitAndSayHello));
        }

        public static CommandManager getIntance() {
            if (commandManager == null) {
                commandManager = new CommandManager();
            }

            return commandManager;
        }

        public ICommand getCommand(String commandName) {

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

        public void registCommand(string commandName, Type command) {
            COMMANDS.Add(commandName.ToUpper(), command);
        }
    }
}



