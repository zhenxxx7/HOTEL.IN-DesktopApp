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
    public partial class BookingPanel : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;
        public BookingPanel()
        {
            InitializeComponent();
            server = "localhost";
            database = "visprosummer";
            uid = "root";
            password = "";

            string conString;
            conString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(conString);

            RoomCallPanel.Controls.Clear();
            LuxuryExPanel frm = new LuxuryExPanel();
            frm.TopLevel = false;
            RoomCallPanel.Controls.Add(frm);
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

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void BookingPanel_Load(object sender, EventArgs e)
        {
            string query = "SELECT Full_Name from customer ORDER BY customer_id DESC LIMIT 1";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("Full_Name");
                    NameOrderLabel.Text = name;
                }
                reader.Close();
                con.Close();
            }
            
        }

        private void ContentPanel_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuPictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void addAdult_Click(object sender, EventArgs e)
        {
            adultLbl.Text = (Convert.ToInt32(adultLbl.Text) + 1).ToString();
        }

        private void minAdult_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(adultLbl.Text) > 0)
            {
                adultLbl.Text = (Convert.ToInt32(adultLbl.Text) - 1).ToString();
            }
        }

        private void addChild_Click(object sender, EventArgs e)
        {
            childLbl.Text = (Convert.ToInt32(childLbl.Text) + 1).ToString();
        }

        private void minChild_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(childLbl.Text) > 0)
            {
                childLbl.Text = (Convert.ToInt32(childLbl.Text) - 1).ToString();
            }
        }

        private void cinDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void coutDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LuxBtn_Click(object sender, EventArgs e)
        {
            RoomCallPanel.Controls.Clear();
            LuxuryExPanel frm = new LuxuryExPanel();
            frm.TopLevel = false;
            RoomCallPanel.Controls.Add(frm);
            frm.Show();
        }

        private void DexBtn_Click(object sender, EventArgs e)
        {
            RoomCallPanel.Controls.Clear();
            DeluxeExPanel frm = new DeluxeExPanel();
            frm.TopLevel = false;
            RoomCallPanel.Controls.Add(frm);
            frm.Show();
        }

        private void StandBtn_Click(object sender, EventArgs e)
        {
            RoomCallPanel.Controls.Clear();
            StandardExPanel frm = new StandardExPanel();
            frm.TopLevel = false;
            RoomCallPanel.Controls.Add(frm);
            frm.Show();
        }

        private void bookNowBtn_Click(object sender, EventArgs e)
        {
            //insert booking_id selalu ditambah 1
            //insert customer_id selalu ditambah 1
            string query = "SELECT MAX(booking_id) FROM booking";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string booking_id = reader.GetString(0);
                    string customer_id = reader.GetString(0);
                    if (booking_id == "")
                    {
                        booking_id = "1";
                        customer_id = "1";
                    }
                    else
                    {
                        booking_id = (Convert.ToInt32(booking_id) + 1).ToString();
                        customer_id = (Convert.ToInt32(customer_id) + 1).ToString();
                    }
                    reader.Close();
                    query = "INSERT INTO booking (booking_id, customer_id, adult, child, cin, cout, Name, room_name, price) VALUES ('" + booking_id + "','" + customer_id + "', '" + adultLbl.Text + "','" + childLbl.Text + "','" + cinDate.Value.ToString("yyyy-MM-dd") + "','" + coutDate.Value.ToString("yyyy-MM-dd") + "','" + NameOrderLabel.Text + "','" + roomNmBox.Text + "','" + TotalPymntTxt.Text + "')";
                    cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MyRoom frm = new MyRoom();
                    frm.room_name = roomNmBox.Text;
                    MessageBox.Show("Booking Success!");
                    ContentPanel.Controls.Clear();
                    MyRoom fr = new MyRoom();
                    fr.TopLevel = false;
                    ContentPanel.Controls.Add(fr);
                    fr.Show();
                }    
                con.Close();
            }
        }

        private void RoomCallPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roomNmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT price FROM room WHERE room_name = '" + roomNmBox.Text + "'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    /*hitung hari dikali price*/
                    int days = (coutDate.Value - cinDate.Value).Days;
                    TotalPymntTxt.Text = (Convert.ToInt32(reader["price"]) * days).ToString();
                }
                con.Close();
            }
            
        }

        private void NameOrderLabel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel30_Click(object sender, EventArgs e)
        {

        }
    }
}
