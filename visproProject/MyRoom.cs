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
    public partial class MyRoom : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;
        public string room_name { get; set; }

        private void ContentPanel_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        public MyRoom()
        {
            InitializeComponent();
            server = "localhost";
            database = "visprosummer";
            uid = "root";
            password = "";

            string conString;
            conString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(conString);


            string query = "SELECT room_name FROM booking ORDER BY booking_id DESC LIMIT 1";
            //save data room_name from database and save to string


        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void MyRoom_Load(object sender, EventArgs e)
        {
            String query = "SELECT room_name FROM booking ORDER BY booking_id DESC LIMIT 1";
            if(openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    room_name = reader.GetString("room_name");
                    if (room_name == "Luxury Bed 1F")
                    {
                        Lux1 frm = new Lux1();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else if (room_name == "Luxury Bed 2F")
                    {
                        Lux2 frm = new Lux2();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else if (room_name == "Luxury Bed 3F")
                    {
                        Lux3 frm = new Lux3();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else if (room_name == "Deluxe Bed 1A")
                    {
                        Dex1 frm = new Dex1();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else if (room_name == "Deluxe Bed 2A")
                    {
                        Dex2 frm = new Dex2();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                    else if (room_name == "Standard Bed 1G")
                    {
                        Stand1 frm = new Stand1();
                        frm.TopLevel = false;
                        panel1.Controls.Add(frm);
                        frm.Show();
                    }
                }
                reader.Close();
                con.Close();
            }
            query = "SELECT Name, room_name, adult, child, cin, cout, price FROM booking ORDER BY booking_id DESC LIMIT 1";
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

            query = "SELECT Full_Name, Address, Phone_Number, Email FROM customer ORDER BY customer_id DESC LIMIT 1";
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

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            //select last booking_id
            string query = "SELECT booking_id from booking ORDER BY booking_id DESC LIMIT 1";
            if(openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string booking_id = reader.GetString("booking_id");
                }
                reader.Close();
                con.Close();
            }
            //send booking_id to report1 form
            report pn = new report();
            pn.Show();
        }

    }
}
