using Microsoft.Data.SqlClient;
using System.Data;

namespace _2024_bil2_program
{
    /// <summary>
    /// CRUD Eğlemlerini yapar.
    /// </summary>
    public class CRUD
    {
        public DataTable GatherData(string sql, SqlConnection conn)
        {
            SqlDataAdapter data = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public int SQLCommand(string sql, SqlConnection conn, string mesaj)
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
