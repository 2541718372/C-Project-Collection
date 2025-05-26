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
    public partial class UpdateGuest : Form
    {
        public UpdateGuest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*查找字段*/
            string nameTextValue = nameText.Text.Trim();
            string sexTextValue = sexText.Text.Trim();

            string GreaterageTextValue = GreaterageText.Text.Trim();
            string LessageTextValue = LessageText.Text.Trim();
            string ageTextValue = ageText.Text.Trim();

            string phoneTextValue = phoneText.Text.Trim();
            string addressTextValue = addressText.Text.Trim();


            /*设置字段*/
            string setNameTextValue = setNameText.Text.Trim();
            string setSexTextValue = setSexText.Text.Trim();
            string setAgeTextValue = setAgeText.Text.Trim();
            string setPhoneTextValue = setPhoneText.Text.Trim();
            string setAddressTextValue = setAddressText.Text.Trim();

            string whereCondition = "";

            if (!string.IsNullOrEmpty(nameTextValue))
                whereCondition += $"name = '{nameTextValue}' AND ";

            if (!string.IsNullOrEmpty(sexTextValue))
                whereCondition += $"sex = '{sexTextValue}' AND ";

            if (!string.IsNullOrEmpty(GreaterageTextValue))
                whereCondition += $"age > '{GreaterageTextValue}' AND ";

            if (!string.IsNullOrEmpty(LessageTextValue))
                whereCondition += $"age < '{LessageTextValue}' AND ";

            if (!string.IsNullOrEmpty(ageTextValue))
                whereCondition += $"age = '{ageTextValue}' AND ";

            if (!string.IsNullOrEmpty(phoneTextValue))
                whereCondition += $"phone = '{phoneTextValue}' AND ";

            if (!string.IsNullOrEmpty(addressTextValue))
                whereCondition += $"address = '{addressTextValue}' AND ";


            if (string.IsNullOrEmpty(whereCondition))
            {
                MessageBox.Show("查找字段内容不能为空");
                return;
            }
            if (whereCondition.EndsWith(" AND "))
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);

            try
            {
                HotelSQLConnection.SqlConnection.Open();

                string setClause = "";

                if (!string.IsNullOrEmpty(setNameTextValue))
                    setClause += $"name = '{setNameTextValue}', ";

                if (!string.IsNullOrEmpty(setSexTextValue))
                    setClause += $"sex = '{setSexTextValue}', ";

                if (!string.IsNullOrEmpty(setAgeTextValue))
                    setClause += $"age = '{setAgeTextValue}', ";

                if (!string.IsNullOrEmpty(setPhoneTextValue))
                    setClause += $"phone = '{setPhoneTextValue}', ";

                if (!string.IsNullOrEmpty(setAddressTextValue))
                    setClause += $"address = '{setAddressTextValue}', ";

                if (string.IsNullOrEmpty(setClause))
                {
                    MessageBox.Show("设置字段内容不能为空");
                    return;
                }

                if (setClause.EndsWith(", "))
                    setClause = setClause.Substring(0, setClause.Length - 2);
                //--------------------------------匹配查找字段是否存在于原表----------------------------------
                string checkExistenceQuery = $"SELECT COUNT(*) FROM guest WHERE {whereCondition}";
                SqlCommand checkExistenceCommand = new SqlCommand(checkExistenceQuery, HotelSQLConnection.SqlConnection);

                // 添加参数化查询，以支持不固定的字段内容判断
                if (!string.IsNullOrEmpty(nameTextValue))
                    checkExistenceCommand.Parameters.AddWithValue("@Name", nameTextValue);
                if (!string.IsNullOrEmpty(sexTextValue))
                    checkExistenceCommand.Parameters.AddWithValue("@Sex", sexTextValue);
                if (!string.IsNullOrEmpty(ageTextValue))
                    checkExistenceCommand.Parameters.AddWithValue("@Age", ageTextValue);
                if (!string.IsNullOrEmpty(phoneTextValue))
                    checkExistenceCommand.Parameters.AddWithValue("@Phone", phoneTextValue);
                if (!string.IsNullOrEmpty(addressTextValue))
                    checkExistenceCommand.Parameters.AddWithValue("@Address", addressTextValue);

                int rowCount = Convert.ToInt32(checkExistenceCommand.ExecuteScalar());

                if (rowCount == 0)
                {
                    MessageBox.Show("原表中没有该内容数据存在，无法修改");
                    return;
                }
                //-------------------------------------------------------------------------
                string updateQuery = $"UPDATE guest SET {setClause} WHERE {whereCondition}";

                SqlCommand command = new SqlCommand(updateQuery, HotelSQLConnection.SqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("顾客信息更新成功");
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
            this.Close();
            new ShowGuest().Show();
        }
    }
}
