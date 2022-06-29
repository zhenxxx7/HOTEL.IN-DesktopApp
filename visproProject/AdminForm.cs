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
    public partial class AdminForm : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //select name from bookingid filter by id
            string query = "SELECT FUll_Name, Address, Phone_Number, Email FROM customer";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("Full_Name");
                    string address = reader.GetString("Address");
                    string phone = reader.GetString("Phone_Number");
                    string email = reader.GetString("Email");
                    bunifuDataGridView2.Rows.Add(name, address, email, phone);
                }
                reader.Close();
                con.Close();
            }

            query = "SELECT Name, room_name, adult, child, cin, cout, price FROM booking";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string room = reader.GetString("room_name");
                    string adult = reader.GetString("adult");
                    string child = reader.GetString("child");
                    string cin = reader.GetString("cin");
                    string cout = reader.GetString("cout");
                    string price = reader.GetString("price");
                    bunifuDataGridView1.Rows.Add(room, adult, child, cin, cout, price);
                }
                reader.Close();
                con.Close();
            }

        }

        public AdminForm()
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


        private void AdminForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT Name, room_name, adult, child, cin, cout, price FROM booking";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string room = reader.GetString("room_name");
                    string adult = reader.GetString("adult");
                    string child = reader.GetString("child");
                    string cin = reader.GetString("cin");
                    string cout = reader.GetString("cout");
                    string price = reader.GetString("price");
                    bunifuDataGridView1.Rows.Add(room, adult, child, cin, cout, price);
                }
                reader.Close();
                con.Close();
            }

            query = "SELECT Full_Name, Address, Phone_Number, Email FROM customer";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("Full_Name");
                    string address = reader.GetString("Address");
                    string phone = reader.GetString("Phone_Number");
                    string email = reader.GetString("Email");
                    bunifuDataGridView2.Rows.Add(name, address, email, phone);
                }
                reader.Close();
                con.Close();
            }
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
    }
}
