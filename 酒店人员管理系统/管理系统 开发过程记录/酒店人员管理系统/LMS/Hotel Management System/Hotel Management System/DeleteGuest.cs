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
    public partial class DeleteGuest : Form
    {
        public DeleteGuest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameTextValue = nameText.Text.Trim();
            string sexTextValue = sexText.Text.Trim();
            string ageTextValue = ageText.Text.Trim();
            string phoneTextValue = phoneText.Text.Trim();
            string addressTextValue = addressText.Text.Trim();

            string whereCondition = "";

            if (!string.IsNullOrEmpty(nameTextValue))
                whereCondition += $"name = '{nameTextValue}' AND ";

            if (!string.IsNullOrEmpty(sexTextValue))
                whereCondition += $"sex = '{sexTextValue}' AND ";

            if (!string.IsNullOrEmpty(ageTextValue))
                whereCondition += $"age = {ageTextValue} AND ";

            if (!string.IsNullOrEmpty(phoneTextValue))
                whereCondition += $"phone = '{phoneTextValue}' AND ";

            if (!string.IsNullOrEmpty(addressTextValue))
                whereCondition += $"address = '{addressTextValue}' AND ";

            if (string.IsNullOrEmpty(nameTextValue) && string.IsNullOrEmpty(sexTextValue) && string.IsNullOrEmpty(ageTextValue)
                                             && string.IsNullOrEmpty(phoneTextValue) && string.IsNullOrEmpty(addressTextValue))
            {
                MessageBox.Show("请输入要删除顾客信息");
                return;
            }
            /* ===============================================================================*/
            string confirmationMessage = "你确定要删除";

            // 判断是否输入了姓名
            if (!string.IsNullOrEmpty(nameTextValue))
            {
                confirmationMessage += $"姓名为'{nameTextValue}',";
            }

            // 判断是否输入了性别
            if (!string.IsNullOrEmpty(sexTextValue))
            {
                confirmationMessage += $"性别为'{sexTextValue}',";
            }

            // 判断是否输入了年龄
            if (!string.IsNullOrEmpty(ageTextValue))
            {
                confirmationMessage += $"年龄为'{ageTextValue}',";
            }

            // 判断是否输入了电话
            if (!string.IsNullOrEmpty(phoneTextValue))
            {
                confirmationMessage += $"电话为'{phoneTextValue}',";
            }

            // 判断是否输入了地址
            if (!string.IsNullOrEmpty(addressTextValue))
            {
                confirmationMessage += $"地址为'{addressTextValue}',";
            }

            confirmationMessage += "的顾客信息吗？";

            // 在删除之前，弹出确认消息框
            DialogResult result = MessageBox.Show(confirmationMessage,
                                                  "确认删除",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            /* ===============================================================================*/
            if (whereCondition.EndsWith(" AND "))
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);

            if (result == DialogResult.Yes)
            {
                try
                {
                    HotelSQLConnection.SqlConnection.Open();
                    string deleteQuery = $"DELETE FROM guest WHERE {whereCondition}";
                    using (SqlCommand command = new SqlCommand(deleteQuery, HotelSQLConnection.SqlConnection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("顾客信息删除成功");
                        }
                        else
                        {
                            MessageBox.Show("未找到匹配的顾客信息");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (HotelSQLConnection.SqlConnection.State == ConnectionState.Open)
                    {
                        HotelSQLConnection.SqlConnection.Close();
                    }
                }
            }
            else
            {
                // 用户选择了“否”，取消删除操作
                MessageBox.Show("取消删除顾客信息");
            }
            nameText.Clear();
            sexText.Clear();
            ageText.Clear();
            phoneText.Clear();
            addressText.Clear();
            nameText.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new ShowGuest().Show();
        }
    }
}
