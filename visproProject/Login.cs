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
    public partial class Login : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;
        public Login()
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

        public bool isLogin(string user, string password)
        {
            string query = $"SELECT * FROM userlog WHERE Username = '{user}' AND Password = '{password}';";
            try
            {
                if(openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            string user = UsernameTxt.Text;
            string password = PasswordTxt.Text;

            if (isLogin(user, password))
            {
                /*MessageBox.Show("Login Successful!");*/
                this.Hide();
                Main f = new Main();
                
                f.Show();
            }
            else
            {
                MessageBox.Show("Login Failed!");
                UsernameTxt.Clear();
                PasswordTxt.Clear();
                UsernameTxt.Focus();
            }
        }

        private void UsernameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
