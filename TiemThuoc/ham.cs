using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLTHUOC
{
    internal class ham
    {
        private string connectionString = "Data Source=DESKTOP-0MAFNOJ\\SQLEXPRESS;Initial Catalog=QLTHUOC;Integrated Security=True";
        public void ketnoi(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                string chuoiketnoi = "Server=DESKTOP-0MAFNOJ\\SQLEXPRESS; database=QLTHUOC; integrated security=True";
                conn.ConnectionString = chuoiketnoi;
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void hienthiDuLieu(SqlConnection conn, string sql, DataGridView dg)
        {
            try
            {
                SqlDataAdapter adt = new SqlDataAdapter(sql, conn);
                DataSet dt = new DataSet();
                adt.Fill(dt, "name");
                dg.DataSource = dt;
                dg.DataMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void capNhat(SqlConnection conn,string sql) { 
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
        public void dataCombobox(SqlConnection conn,string sql,ComboBox cb, string gt, string hthi)
        {
            SqlCommand cmd= new SqlCommand(sql,conn);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            cb.DataSource = dt;
            cb.DisplayMember = hthi;
            cb.ValueMember = gt;
        }

    }
}
