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
    public partial class kullanicigiris : Form
    {
        public kullanicigiris()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void kullanicigiris_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            gkod = r.Next(1000, 9999);
            label4.Text = gkod.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int gkod;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select tc,Şifre from kullanicigiris where tc=@tc and Şifre=@Şifre", baglanti);
                sorgu.Parameters.AddWithValue("@tc", textBox1.Text);
                sorgu.Parameters.AddWithValue("@Şifre", textBox2.Text);
                OleDbDataReader hs;
                hs = sorgu.ExecuteReader();

                if (hs.Read())
                {
                    if (gkod == Convert.ToInt16(textBox3.Text))
                    {
                        hastasayfa ks = new hastasayfa();
                        ks.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik kodunu yanlış girdiniz. Lütfen tekrar deneyiniz.");
                    }
                }
                else
                {
                    baglanti.Close();
                    MessageBox.Show("T.C. Kimlik No veya şifre hatalı. Lütfen tekrar deneyiniz.");
                }
            }
            catch
            {
                MessageBox.Show("Lütfen T.C. Kimlik No ve şifreniz ile giriş yapınız.");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kayıtol ko = new kayıtol();
            ko.ShowDialog();
            this.Close();
        }
    }
}