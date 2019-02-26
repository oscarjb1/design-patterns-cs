using System;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class DateTimeCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "date";

        public override string getCommandName() {
            return COMMAND_NAME;
        }

        public override void execute(string[] args, StreamWriter output) {

            string dateFormater = null;
            if (args == null || args.Length == 0) {
                dateFormater = "dd/MM/yyyy hh:mm:ss";
            } else {
                dateFormater = args[0];
            }
            DateTime date = DateTime.Now;
            try {
                write(output, date.ToString(dateFormater));
            } catch (Exception e) {
                write(output, "invalid format");
            }
        }
    }
}

