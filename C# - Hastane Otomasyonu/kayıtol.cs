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
    public partial class kayıtol : Form
    {
        public kayıtol()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void kayıtol_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullanicigiris kg = new kullanicigiris();
            kg.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into kullanicigiris(tc,Şifre,ad,soyad,cinsiyet,Doğum_Yeri,Doğum_Tarihi,tel,eposta) values(@tc,@Şifre,@ad,@soyad,@cinsiyet,@Doğum_Yeri,@Doğum_Tarihi,@tel,@eposta)", baglanti);
            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.Parameters.AddWithValue("@Şifre", textBox2.Text);
            komut.Parameters.AddWithValue("@ad", textBox3.Text);
            komut.Parameters.AddWithValue("@soyad", textBox4.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@Doğum_Yeri", textBox5.Text);
            komut.Parameters.AddWithValue("@Doğum_Tarihi", textBox6.Text);
            komut.Parameters.AddWithValue("@tel", textBox7.Text);
            komut.Parameters.AddWithValue("@eposta", textBox8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı...");
            hastasayfa hs = new hastasayfa();
            hs.Show();
            this.Close();
        }
    }
}
