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

namespace QLTHUOC
{
    public partial class Form1 : Form
    {
        ham f = new ham();
        SqlConnection conn = new SqlConnection();
        string path = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            f.ketnoi(conn);
            f.hienthiDuLieu(conn,"select* from toa", dataGridView1);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            f.ketnoi(conn);
            f.hienthiDuLieu(conn,"select* from thuoc", dataGridView1);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    // Get the search keyword from the RichTextBox and trim it
                    string tukhoa = richTextBox1.Text.Trim();

                    // Clear the DataGridView's DataSource to avoid old data lingering
                    if (dataGridView1.DataSource != null)
                    {
                        dataGridView1.DataSource = null;
                    }

                    // Check which RadioButton is selected and build the appropriate SQL query
                    if (string.IsNullOrEmpty(tukhoa))
                    {
                        MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!");
                        return;
                    }

                    string sql_tim = "";

                    if (radioButton1.Checked) // Search in "toa" table by mabn
                    {
                        sql_tim = "SELECT * FROM toa WHERE mabn LIKE N'%" + tukhoa + "%'";
                    }
                    else if (radioButton2.Checked) // Search in "toa" table by mabs
                    {
                        sql_tim = "SELECT * FROM toa WHERE mabs LIKE N'%" + tukhoa + "%'";
                    }
                    else if (radioButton3.Checked) // Search in "toa" table by ngayke
                    {
                        sql_tim = "SELECT * FROM toa WHERE ngayke LIKE N'%" + tukhoa + "%'";
                    }
                    else if (radioButton4.Checked) // Search in "thuoc" table by chucnang
                    {
                        sql_tim = "SELECT * FROM thuoc WHERE chucnang LIKE N'%" + tukhoa + "%'";
                    }
                    else if (radioButton5.Checked) // Search in "thuoc" table by giaban (numeric)
                    {
                        if (decimal.TryParse(tukhoa, out decimal price))
                        {
                            sql_tim = "SELECT * FROM thuoc WHERE giaban = " + price;
                        }
                        else
                        {
                            MessageBox.Show("Giá bán phải là một số hợp lệ!");
                            return;
                        }
                    }
                    else if (radioButton6.Checked) // Search in "thuoc" table by tenthuoc
                    {
                        sql_tim = "SELECT * FROM thuoc WHERE tenthuoc LIKE N'%" + tukhoa + "%'";
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một tiêu chí tìm kiếm (toa hoặc thuốc)!");
                        return;
                    }

                    // If a valid SQL query is built, display the data
                    if (!string.IsNullOrEmpty(sql_tim))
                    {
                        f.hienthiDuLieu(conn,sql_tim, dataGridView1);

                        // Check if no data was returned and inform the user
                        if (dataGridView1.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}


   
