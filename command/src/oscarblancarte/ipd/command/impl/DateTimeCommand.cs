using System;
using System.IO;

namespace oscarblancarte.ipd.command.impl{
    public class DateTimeCommand : BaseCommand {

        public static readonly string COMMAND_NAME = "date";

        public override string GetCommandName() {
            return COMMAND_NAME;
        }

        public override void Execute(string[] args, StreamWriter output) {

            string dateFormater = null;
            if (args == null || args.Length == 0) {
                dateFormater = "dd/MM/yyyy hh:mm:ss";
            } else {
                dateFormater = args[0];
            }
            DateTime date = DateTime.Now;
            try {
                Write(output, date.ToString(dateFormater));
            } catch (Exception e) {
                Write(output, "invalid format");
            }
        }
    }
}

