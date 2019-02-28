using System.Collections.Generic;

namespace oscarblancarte.ipd.command{
    public class CommandUtil {

        public static string[] TokenizerArgs(string args) {
            List<string> tokens = new List<string>();
            char[] charArray = args.ToCharArray();

            string contact = "";
            bool inText = false;
            foreach (char c in charArray) {
                if (c == ' ' && !inText) {
                    if (contact.Length != 0) {
                        tokens.Add(contact);
                        contact = "";
                    }
                } else if (c == '"') {
                    if (inText) {
                        tokens.Add(contact);
                        contact = "";
                        inText = false;
                    } else {
                        inText = true;
                    }
                } else {
                    contact += c;
                }
            }
            if (contact.Trim().Length != 0) {
                tokens.Add(contact.Trim());
            }

            string[] argsArray = new string[tokens.Count];
            argsArray = tokens.ToArray();
            return argsArray;
        }
    }

}
