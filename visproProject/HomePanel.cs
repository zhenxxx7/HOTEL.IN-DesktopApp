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
    public partial class HomePanel : Form
    {
        public HomePanel()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox6_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuToolTip1_Popup(object sender, Bunifu.UI.WinForms.BunifuToolTip.PopupEventArgs e)
        {

        }

        private void bunifuImageButton1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void HomePanel_Load(object sender, EventArgs e)
        {
            bunifuToolTip1.DisplayControl = new prev1();
        }
    }
}
