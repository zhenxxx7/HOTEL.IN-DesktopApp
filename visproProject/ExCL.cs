using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visproProject
{
    public partial class ExCL : Form
    {
        public ExCL()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            Main obj = (Main)Application.OpenForms["Main"];
            AdminForm obj2 = (AdminForm)Application.OpenForms["AdminForm"];

            if (obj2 == null)
            {

                obj.Close();
            }
            else
            {

                obj2.Close();
            }

            Login login = new Login();
            login.Show();
        }
    }
}
