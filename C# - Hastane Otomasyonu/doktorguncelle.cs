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
    public partial class doktorguncelle : Form
    {
        public doktorguncelle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void doktorguncelle_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.Ad_Soyad;
            comboBox1.Text = Program.Cinsiyet;
            textBox4.Text = Program.Doğum_Yeri;
            textBox5.Text = Program.Doğum_Tarihi;
            textBox6.Text = Program.Tel_No;
            textBox7.Text = Program.Email;
            textBox8.Text = Program.Poliklinik;
            textBox9.Text = Program.doktorID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update doktorekle set Ad_Soyad=@Ad_Soyad,Cinsiyet=@Cinsiyet,Doğum_Yeri=@Doğum_Yeri,Doğum_Tarihi=@Doğum_Tarihi,Tel_No=@Tel_No,Email=@Email,Poliklinik=@Poliklinik where doktorID=@doktorID", baglanti);
            komut.Parameters.AddWithValue("@Ad_Soyad", textBox1.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@Doğum_Yeri", textBox4.Text);
            komut.Parameters.AddWithValue("@Doğum_Tarihi", textBox5.Text);
            komut.Parameters.AddWithValue("@Tel_No", textBox6.Text);
            komut.Parameters.AddWithValue("@Email", textBox7.Text);
            komut.Parameters.AddWithValue("@Poliklinik", textBox8.Text);
            komut.Parameters.AddWithValue("@doktorID", textBox9.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi başarı ile gerçekleştirildi...");
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Visible = false;
        }
    }
}
