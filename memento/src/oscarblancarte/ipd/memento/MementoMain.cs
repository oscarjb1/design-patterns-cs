
using oscarblancarte.ipd.memento.gui;
using System.Windows.Forms;

namespace oscarblancarte.ipd.memento{
    public class MementoMain {

        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmployeeGUI());
        }
    }
}