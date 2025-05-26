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
        public InsertGuest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nametext = nameText.Text.Trim();
            String sextext = sexText.Text.Trim();
            String agetext = ageText.Text.Trim();
            String phonetext = phoneText.Text.Trim();
            String addresstext = addressText.Text.Trim();

            if (string.IsNullOrEmpty(nametext) || string.IsNullOrEmpty(sextext) || string.IsNullOrEmpty(agetext)
                                                || string.IsNullOrEmpty(phonetext) || string.IsNullOrEmpty(addresstext))
            {
                MessageBox.Show("请输入要添加顾客信息");
                return;
            }
            try
            {
                HotelSQLConnection.SqlConnection.Open();
                string insertQuery = "INSERT guest(name,sex,age,phone,address)VALUES ('" + nameText.Text.ToString() + "','" + sexText.Text.ToString() + "'" +
                                                 ",'" + ageText.Text.ToString() + "','" + phoneText.Text.ToString() + "','" + addressText.Text.ToString() + "')";
                SqlCommand command = new SqlCommand(insertQuery, HotelSQLConnection.SqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("顾客信息添加成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HotelSQLConnection.SqlConnection.Close();
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
