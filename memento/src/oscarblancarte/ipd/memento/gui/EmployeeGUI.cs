using oscarblancarte.ipd.memento.entity;
using oscarblancarte.ipd.memento.impl;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

namespace oscarblancarte.ipd.memento.gui{

    public class EmployeeGUI : Form {
        private Employee Employee = new Employee();
        private EmployeeCaretaker caretaker = new EmployeeCaretaker();
        
        public EmployeeGUI() {
            initComponents();
        }


        private void initComponents() {

            firstName = new Label();
            nameTxt = new TextBox();
            lastNameTxt = new TextBox();
            empNumberTxt = new TextBox();
            lastName = new Label();
            empNumber = new Label();
            btnSave = new Button();
            prevBtn = new Button();
            nextBtn = new Button();

            btnSave.Click += (object sender, EventArgs e) => {
                save(e);
            };

            firstName.Text = "First name";
            lastName.Text = "Last name";
            empNumber.Text = "Employee number";
            btnSave.Text = "Save";

            /*btnSave.addActionListener(new ActionListener() {
                public void actionPerformed(ActionEvent evt) {
                    save(evt);
                }
            });

            prevBtn.setText("<");
            prevBtn.addActionListener(new ActionListener() {
                public void actionPerformed(ActionEvent evt) {
                    previous(evt);
                }
            });

            nextBtn.setText(">");
            nextBtn.addActionListener(new java.awt.event.ActionListener() {
                public void actionPerformed(java.awt.event.ActionEvent evt) {
                    next(evt);
                }
            });*/

            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.empNumberTxt);
            this.Text = "Patrón de diseño Memento ";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void save(EventArgs evt) {
            Employee.Name = nameTxt.Text;
            Employee.LastName = lastNameTxt.Text;
            Employee.EmployeeNumber = empNumberTxt.Text;
            caretaker.addNewMemento(Employee.createMemento());

            MessageBox.Show("OK","Saved state") ;
        }

            
        private void previous(EventArgs evt) {
            
            EmployeeMemento menento = caretaker.getPreviousMemento();
            if(menento==null){
                MessageBox.Show("Previous","There are no more states") ;
                return;
            }
            Employee.restoreMemento(menento);
            updateModel();
        }

        private void next(EventArgs evt) {
            EmployeeMemento memento = caretaker.getNextMemento();
            if(memento==null){
                MessageBox.Show("Next","There are no more states") ;
                return;
            }
            Employee.restoreMemento(memento);
            updateModel();
        }

        private void updateModel(){
            nameTxt.Text = Employee.Name;
            lastNameTxt.Text = Employee.LastName;
            empNumberTxt.Text = Employee.EmployeeNumber;
        }
        
        private TextBox empNumberTxt;
        private Button btnSave;
        private Label firstName;
        private Label lastName;
        private Label empNumber;
        private TextBox lastNameTxt;
        private TextBox nameTxt;
        private Button nextBtn;
        private Button prevBtn;
    }
}
