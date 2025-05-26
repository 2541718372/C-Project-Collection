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
        // 登录界面的构造函数
        public Login()
        {
            InitializeComponent();
        }

        // 登录按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            // 获取输入的用户名和密码
            String usertexBox = userTextBox.Text.Trim();
            String pwdtextBox = pwdTextBox.Text.Trim();

            try
            {
                // 打开SQL连接
                HotelSQLConnection.SqlConnection.Open();

                // 查询用户表中的用户名和密码
                String selectUserSql = "select username,password from users";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = HotelSQLConnection.SqlConnection;
                sqlCommand.CommandText = selectUserSql;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // 登录成功标志
                Boolean loginType = false;

                // 检查查询是否有结果
                if (sqlDataReader.HasRows)
                {
                    // 遍历用户数据
                    while (sqlDataReader.Read())
                    {
                        // 获取每一行的用户数据
                        Object[] usersList = new Object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(usersList);

                        // 检查输入的用户名和密码是否匹配
                        if (usersList[0].ToString().Trim().Equals(usertexBox) &&
                            usersList[1].ToString().Trim().Equals(pwdtextBox))
                        {
                            loginType = true; // 设置登录标志为true
                        }
                    }
                }

                // 根据登录状态执行相应操作
                if (loginType)
                {
                    this.Hide(); // 隐藏登录界面
                    HotelSQLConnection.SqlConnection.Close(); // 关闭SQL连接
                    new ShowGuest().Show(); // 显示顾客信息界面
                }
                else if (string.IsNullOrEmpty(usertexBox) || string.IsNullOrEmpty(pwdtextBox))
                {
                    MessageBox.Show("用户名或密码不能为空，请输入并尝试登录"); // 显示空字段错误消息
                }
                else
                {
                    MessageBox.Show("用户名或密码有误，请输入输入"); // 显示登录失败错误消息
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); // 显示异常错误消息
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close(); // 总是关闭SQL连接
            }

            // 清空输入框并将焦点设置到用户名输入框
            userTextBox.Clear();
            pwdTextBox.Clear();
            userTextBox.Focus();
        }

        // 窗体加载事件处理
        private void Login_Load(object sender, EventArgs e)
        {
            HotelSQLConnection.loginFrom = this; // 在HotelSQLConnection中设置loginFrom为当前窗体
        }

        // 注册按钮点击事件处理
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // 隐藏登录界面
            new Register().Show(); // 显示注册界面
        }

        // 退出按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭应用程序
        }
    }
}
