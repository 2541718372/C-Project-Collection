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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usertexBox = userTextBox.Text.Trim();
            String pwdtextBox = pwdTextBox.Text.Trim();
            try
            {
                HotelSQLConnection.SqlConnection.Open();
                String selectUserSql = "select username,password from users";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = HotelSQLConnection.SqlConnection;
                sqlCommand.CommandText = selectUserSql;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Boolean loginType = false;
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Object[] usersList = new Object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(usersList);
                        if (usersList[0].ToString().Trim().Equals(usertexBox) &&
                            usersList[1].ToString().Trim().Equals(pwdtextBox))
                        {
                            loginType = true;
                        }
                    }
                }
                if (loginType)
                {
                    this.Hide();
                    HotelSQLConnection.SqlConnection.Close();
                    new ShowGuest().Show();
                }
                else if (string.IsNullOrEmpty(usertexBox) || string.IsNullOrEmpty(pwdtextBox))
                {
                    MessageBox.Show("用户名或密码不能为空，请输入并尝试登录");
                }
                else
                {
                    MessageBox.Show("用户名或密码有误，请输入输入");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
            userTextBox.Clear();
            pwdTextBox.Clear();
            userTextBox.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {
              HotelSQLConnection.loginFrom = this;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
