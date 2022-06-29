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
    public partial class LoginAdmin : Form
    {
        private MySqlConnection con;
        private string server, database, uid, password;
        private string userType;
        public LoginAdmin()
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

        private void LogBtn_Click(object sender, EventArgs e)
        {
            string user = UsernameTxt.Text;
            string password = PasswordTxt.Text;

            if (isLogin(user, password))
            {
                if(userType == "Admin")
                {
                    /*MessageBox.Show("Login Successful!");*/
                    this.Hide();
                    AdminForm f = new AdminForm();
                    f.Show();
                }
                else if (userType == "User")
                {
                    MessageBox.Show("Invalid user type");
                }
            }
            else
            {
                MessageBox.Show("Login Failed!");
                UsernameTxt.Clear();
                PasswordTxt.Clear();
                UsernameTxt.Focus();
            }
        }

        public bool isLogin(string user, string password)
        {
            string query = $"SELECT * FROM userlog WHERE Username = '{user}' AND Password = '{password}';";
            try
            {
                if (openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userType = reader.GetString("user_type");
                        reader.Close();
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
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

        //create login filter by type = Admin

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frm = new Login();
            frm.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
