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
    public partial class ShowGuest : Form
    {
        // 顾客信息显示界面的构造函数
        public ShowGuest()
        {
            InitializeComponent();
        }

        // 顾客信息显示窗体加载事件处理
        private void ShowGuest_Load(object sender, EventArgs e)
        {
            HotelSQLConnection.ShowGuestFrom = this; // 在HotelSQLConnection中设置ShowGuestFrom为当前窗体
            ListViewItem listViewItem = new ListViewItem();

            try
            {
                // 打开SQL连接
                HotelSQLConnection.SqlConnection.Open();

                // 执行查询顾客信息的SQL语句
                String selectSqlStr = "select * from guest";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = HotelSQLConnection.SqlConnection;
                sqlCommand.CommandText = selectSqlStr;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    // 遍历查询结果，加载到ListView控件中
                    while (sqlDataReader.Read())
                    {
                        Object[] studentMeg = new Object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(studentMeg);

                        // 通过listview控件中的Items属性的Add方法向ListView添加数据项
                        // 添加一项数据时需要传递一个序号
                        listViewItem = listView1.Items.Add(studentMeg[0].ToString().Trim());
                        for (int i = 1; i < studentMeg.Length; i++)
                        {
                            listViewItem.SubItems.Add(studentMeg[i].ToString().Trim());
                        }
                    }
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
        }

        // 顾客信息显示窗体关闭事件处理
        private void ShowGuest_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotelSQLConnection.loginFrom.Show(); // 显示登录界面
        }

        // 添加顾客信息按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); // 隐藏当前窗体
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView(); // 刷新ListView
                new InsertGuest().Show(); // 显示插入顾客信息界面
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

        // 刷新ListView控件的方法
        private void RefreshListView()
        {
            listView1.Items.Clear(); // 清空ListView
            try
            {
                // 执行查询顾客信息的SQL语句
                string selectSqlStr = "SELECT * FROM guest";
                SqlCommand sqlCommand = new SqlCommand(selectSqlStr, HotelSQLConnection.SqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    // 遍历查询结果，重新加载数据到ListView
                    while (sqlDataReader.Read())
                    {
                        Object[] studentMeg = new Object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(studentMeg);

                        ListViewItem listViewItem = listView1.Items.Add(studentMeg[0].ToString().Trim());
                        for (int i = 1; i < studentMeg.Length; i++)
                        {
                            listViewItem.SubItems.Add(studentMeg[i].ToString().Trim());
                        }
                    }
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
        }

        // 修改数据按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); // 隐藏当前窗体
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView(); // 刷新ListView
                new UpdateGuest().Show(); // 显示修改顾客信息界面
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

        // 删除数据按钮点击事件处理
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); // 隐藏当前窗体
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView(); // 刷新ListView
                new DeleteGuest().Show(); // 显示删除顾客信息界面
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

        // 返回按钮点击事件处理
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // 关闭当前窗体
            HotelSQLConnection.loginFrom.Show(); //

         }
    }
}
