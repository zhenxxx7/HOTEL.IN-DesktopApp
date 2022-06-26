using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace visproProject
{
    public partial class Main : Form
    {
        string varName;
        private MySqlConnection con;
        private string server, database, uid, password;
        public Main()
        {
            InitializeComponent();
            server = "localhost";
            database = "visprosummer";
            uid = "root";
            password = "";

            string conString;
            conString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(conString);
            
            ContentPanel.Controls.Clear();
            HomePanel frm = new HomePanel();
            frm.TopLevel = false;
            ContentPanel.Controls.Add(frm);
            frm.Show();
        }

        private bool openConnection()
        {
            try
            {
                con.Open();
                return true;

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to server failed!");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username or password, please try again");
                        break;
                }
                return false;
            }
        }
        
        public void getname(string nama)
        {
            string query = $"SELECT * FROM customer WHERE Name = '{nama}';";
            try
            {
                if (openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        varName = reader.GetString("Name");
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();
                    }
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Exitbtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MyRoomBtn_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            MyRoom frm = new MyRoom();
            frm.TopLevel = false;
            ContentPanel.Controls.Add(frm);
            frm.Show();
        }

        private void BookingBtn_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            BookingPanel frm = new BookingPanel();
            frm.TopLevel = false;
            ContentPanel.Controls.Add(frm);
            frm.Show();
        }

        private void HomeBtn_Load(object sender, EventArgs e)
        {
            
        }

        private void ServiceBtn_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            ServicePanel frm = new ServicePanel();
            frm.TopLevel = false;
            ContentPanel.Controls.Add(frm);
            frm.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //username login generate
            /*string query = $"SELECT * FROM customer WHERE Name = '{varName}';";
            try
            {
                if (openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UsernameLbl.Text = reader.GetString("Name");
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();
                    }
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }*/
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            ContentPanel.Controls.Clear();
            HomePanel frm = new HomePanel();
            frm.TopLevel = false;
            ContentPanel.Controls.Add(frm);
            frm.Show();
        }
    }
}
