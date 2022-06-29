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
            ExCL frm = new ExCL();
            frm.ShowDialog();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //clear data in datagridview
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView2.Rows.Clear();
            string filtername = SearchBox.Text;
            filter(filtername);


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

        private void AllBtn_Click(object sender, EventArgs e)
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView2.Rows.Clear();
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string filtername = SearchBox.Text;
            UpdateForm update = new UpdateForm();
            update.filterBox = filtername;
            update.ShowDialog();
            
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

        public bool filter(string filter)
        {
            try
            {
                if (openConnection())
                {
                    string query = $"SELECT * FROM booking WHERE Name = '{filter}';";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string room = reader.GetString("room_name");
                        string adult = reader.GetString("adult");
                        string child = reader.GetString("child");
                        string cin = reader.GetString("cin");
                        string cout = reader.GetString("cout");
                        string price = reader.GetString("price");
                        bunifuDataGridView1.Rows.Add(room, adult, child, cin, cout, price);
                        UpdateBtn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No data found");
                        UpdateBtn.Enabled = false;
                    }
                    
                    reader.Close();
                    query = $"SELECT * FROM customer WHERE Full_Name = '{filter}';";
                    cmd = new MySqlCommand(query, con);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader.GetString("Full_Name");
                        string address = reader.GetString("Address");
                        string phone = reader.GetString("Phone_Number");
                        string email = reader.GetString("Email");
                        bunifuDataGridView2.Rows.Add(name, address, email, phone);
                        UpdateBtn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No data found");
                        UpdateBtn.Enabled = false;
                    }
                        
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
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
