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
    public partial class InsertGuest : Form
    {
        // 插入信息界面的构造函数
        public InsertGuest()
        {
            InitializeComponent();
        }

        // 添加顾客信息按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            // 获取输入的顾客信息
            String nametext = nameText.Text.Trim();
            String sextext = sexText.Text.Trim();
            String agetext = ageText.Text.Trim();
            String phonetext = phoneText.Text.Trim();
            String addresstext = addressText.Text.Trim();

            // 检查输入的顾客信息是否为空
            if (string.IsNullOrEmpty(nametext) || string.IsNullOrEmpty(sextext) || string.IsNullOrEmpty(agetext)
                                                || string.IsNullOrEmpty(phonetext) || string.IsNullOrEmpty(addresstext))
            {
                MessageBox.Show("请输入要添加顾客信息"); // 显示错误消息
                return;
            }

            try
            {
                // 打开SQL连接
                HotelSQLConnection.SqlConnection.Open();

                // 执行插入顾客数据的SQL语句
                string insertQuery = $"INSERT guest(name,sex,age,phone,address)VALUES " +
                                     $"('{nameText.Text.ToString()}','{sexText.Text.ToString()}'," +
                                     $"'{ageText.Text.ToString()}','{phoneText.Text.ToString()}','{addressText.Text.ToString()}')";
                SqlCommand command = new SqlCommand(insertQuery, HotelSQLConnection.SqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("顾客信息添加成功"); // 显示成功消息
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); // 显示异常错误消息
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close(); // 总是关闭SQL连接
            }

            // 清空输入框并将焦点设置到姓名输入框
            nameText.Clear();
            sexText.Clear();
            ageText.Clear();
            phoneText.Clear();
            addressText.Clear();
            nameText.Focus();
        }

        // 返回按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭当前窗体
            new ShowGuest().Show(); // 显示顾客信息界面
        }
    }
}
