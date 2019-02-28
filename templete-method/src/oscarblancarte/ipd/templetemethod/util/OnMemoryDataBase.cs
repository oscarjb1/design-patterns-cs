using System;
using System.IO;
using System.Collections.Generic;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.templetemethod.util{
    public class OnMemoryDataBase {

        public static readonly Dictionary<string, string> PROCESS_DOCUMENTS = new Dictionary<string, string>();
        public static readonly int[] CUSTOMERS = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

        public static String GetFileStatus(String fileName) {
            if (PROCESS_DOCUMENTS.ContainsKey(fileName)) {
                return PROCESS_DOCUMENTS[fileName];
            }
            return null;
        }

        public static void SetProcessFile(String fileName) {
            PROCESS_DOCUMENTS.Add(fileName, "Processed");
        }

        public static bool CustomerExist(int id) {
            foreach(int i in CUSTOMERS) {
                if (i == id) {
                    return true;
                }
            }
            return false;
        }
    }
}


