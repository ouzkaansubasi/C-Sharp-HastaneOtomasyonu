using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hastane_Otomasyonu
{
    public partial class doktorekle : Form
    {
        public doktorekle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into doktorekle(Ad_Soyad,Cinsiyet,Doğum_Yeri,Doğum_Tarihi,Tel_No,Email,Poliklinik,polID) values(@Ad_Soyad,@Cinsiyet,@dogumyeri,@Doğum_Tarihi,@Tel_No,@Email,@Poliklinik,@polID)", baglanti);
            komut.Parameters.AddWithValue("@Ad_Soyad", textBox1.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@Doğum_Yeri", textBox4.Text);
            komut.Parameters.AddWithValue("@Dogum_Tarihi", textBox8.Text);
            komut.Parameters.AddWithValue("@Tel_No", textBox5.Text);
            komut.Parameters.AddWithValue("@Email", textBox6.Text);
            komut.Parameters.AddWithValue("@Poliklinik", comboBox2.Text);
            komut.Parameters.AddWithValue("@polID", textBox7.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı...");
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doktorekle_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from polekle", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["Poliklinik"]);
            }
            baglanti.Close();
        }
    }
}
