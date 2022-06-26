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
    public partial class ServicePanel : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;

        public ServicePanel()
        {
            InitializeComponent();
            server = "localhost";
            database = "visprosummer";
            uid = "root";
            password = "";

            string conString;
            conString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(conString);
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

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void InputBtn_Click(object sender, EventArgs e)
        {
            //insert data customer to database
            string query = "SELECT MAX(customer_id) from customer";
            if(openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string customer_id = reader.GetString(0);
                    if(customer_id == "")
                    {
                        customer_id = "1";
                    }
                    else
                    {
                        customer_id = (Convert.ToInt32(customer_id) + 1).ToString();
                    }
                    reader.Close();
                    query = "INSERT INTO `customer` (`customer_id`, `Full_Name`, `Address`, `Email`, `Phone_Number`) VALUES ('" + customer_id + "','" + namaTxtBox.Text + "', '" + addressTxtBox.Text + "','" + emailTxtBox.Text + "', '" + phoneTxtBox.Text + "')";
                    cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Input Success!");
                    ContentPanel.Controls.Clear();
                    BookingPanel frm = new BookingPanel();
                    frm.TopLevel = false;
                    ContentPanel.Controls.Add(frm);
                    frm.Show();
                }
                con.Close();
            }
        }
    }
}
