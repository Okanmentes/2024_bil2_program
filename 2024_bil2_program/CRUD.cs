using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_bil2_program
{
    internal class CRUD
    {
        public DataTable verigetir(string sql,SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public int VToperasyon(string sql, SqlConnection conn,string mesaj)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);

            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc > 0)
            {
                MessageBox.Show(mesaj);  
            }


            conn.Close();
            return sonuc;
        }
    }
}
