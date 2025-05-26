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
        public ShowGuest()
        {
            InitializeComponent();
        }

        private void ShowGuest_Load(object sender, EventArgs e)
        {
            HotelSQLConnection.ShowGuestFrom = this;
            ListViewItem listViewItem = new ListViewItem();
            try
            {
                HotelSQLConnection.SqlConnection.Open();
                String selectSqlStr = "select * from guest";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = HotelSQLConnection.SqlConnection;
                sqlCommand.CommandText = selectSqlStr;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Object[] studentMeg = new Object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(studentMeg);
                        //通过listview控件中的Items属性的Add方法代表我要向当前
                        //listView控件添加一项（条）数据
                        //在添加一项（条）数据的时候需要传递一个序号
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
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
        }

        private void ShowGuest_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotelSQLConnection.loginFrom.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView();
                new InsertGuest().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
        }

        private void RefreshListView()
        {
            listView1.Items.Clear(); // 清空ListView
            // 重新加载数据到ListView
            // 示例代码（请根据实际情况修改）：
            try
            {
                //SchoolSQLConnection.SqlConnection.Open();
                string selectSqlStr = "SELECT * FROM guest";
                SqlCommand sqlCommand = new SqlCommand(selectSqlStr, HotelSQLConnection.SqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
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
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 修改数据按钮点击事件
            try
            {
                this.Hide();
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView();
                new UpdateGuest().Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                HotelSQLConnection.SqlConnection.Open();
                RefreshListView();
                new DeleteGuest().Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            HotelSQLConnection.loginFrom.Show();
        }
    }
}
