using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usertext = userText.Text.Trim();
            String passwordtext = passwordText.Text.Trim();
            if (string.IsNullOrEmpty(usertext) || string.IsNullOrEmpty(passwordtext))
            {
                MessageBox.Show("请添加用户名或密码");
                return;
            }
            try
            {
                HotelSQLConnection.SqlConnection.Open();
                string insertQuery = "INSERT users(username,password)VALUES ('" + userText.Text.ToString() + "','" + passwordText.Text.ToString() + "')";
                SqlCommand command = new SqlCommand(insertQuery, HotelSQLConnection.SqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("管理员注册成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
            userText.Clear();
            passwordText.Clear();
            userText.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotelSQLConnection.loginFrom.Show();
        }
    }
}
