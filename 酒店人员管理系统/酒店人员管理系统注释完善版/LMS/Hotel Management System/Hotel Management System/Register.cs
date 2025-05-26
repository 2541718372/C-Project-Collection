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
        // 注册界面的构造函数
        public Register()
        {
            InitializeComponent();
        }

        // 注册按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            // 获取输入的用户名和密码
            String usertext = userText.Text.Trim();
            String passwordtext = passwordText.Text.Trim();

            // 检查用户名和密码是否为空
            if (string.IsNullOrEmpty(usertext) || string.IsNullOrEmpty(passwordtext))
            {
                MessageBox.Show("请添加用户名和密码"); // 显示错误消息
                return;
            }

            try
            {
                // 打开SQL连接
                HotelSQLConnection.SqlConnection.Open();

                // 执行插入管理员数据的SQL语句
                string insertQuery = $"INSERT users(username,password)VALUES " +
                                     $"('{userText.Text.ToString()}','{passwordText.Text.ToString()}')";
                SqlCommand command = new SqlCommand(insertQuery, HotelSQLConnection.SqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("管理员注册成功"); // 显示成功消息
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); // 显示异常错误消息
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close(); // 总是关闭SQL连接
            }
        }

        // 取消按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭当前窗体
        }

        // 注册窗体关闭事件处理
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotelSQLConnection.loginFrom.Show(); // 显示登录界面
        }
    }
}
