using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace _2024_bil2_program
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("server='DESKTOP-520STTO'; database='2024_Bahar_Bil_2'; uid='sa'; pwd='12345'");

        SqlConnection baglanti2 = new SqlConnection("server='DESKTOP-520STTO'; database='deneme2'; uid='sa'; pwd='12345'");
        CRUD cr=new CRUD();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource=cr.verigetir("select * from Tbl_Ogrenci",baglanti);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x=cr.VToperasyon("insert into Tbl_Ogrenci (OgrNO,Adi,Soyadi,Yas)\r\nvalues('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")", baglanti, "Ekleme iþlemi baþarýlý");
            
            if (x> 0)
                dataGridView1.DataSource = cr.verigetir("select * from Tbl_Ogrenci", baglanti);

        }

        private void button3_Click(object sender, EventArgs e)
        {


            int x = cr.VToperasyon("update [dbo].[Tbl_Ogrenci] \r\nset adi='" + textBox2.Text + "', soyadi='" + textBox3.Text + "',yas=" + textBox4.Text + "\r\nwhere id=" + label5.Text + "", baglanti, "Güncelleme iþlemi baþarýlý");

            if (x > 0)
                dataGridView1.DataSource = cr.verigetir("select * from Tbl_Ogrenci", baglanti);

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int sirano=dataGridView1.CurrentCell.RowIndex;

            label5.Text = dataGridView1.Rows[sirano].Cells["id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[sirano].Cells["OgrNo"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sirano].Cells["Adi"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sirano].Cells["Soyadi"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sirano].Cells["Yas"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = cr.VToperasyon("delete from Tbl_Ogrenci where id=" + label5.Text + "", baglanti, "silme iþlemi baþarýlý");

            if (x > 0)
                dataGridView1.DataSource = cr.verigetir("select * from Tbl_Ogrenci", baglanti);

        }
    }
}