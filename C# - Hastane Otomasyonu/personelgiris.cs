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
    public partial class personelgiris : Form
    {
        public personelgiris()
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select kad,sifre from personelgiris where kad=@kad and sifre=@sifre", baglanti);
                sorgu.Parameters.AddWithValue("@kad", textBox1.Text);
                sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = sorgu.ExecuteReader();

                if (dr.Read())
                {
                    if (gkod == Convert.ToInt16(textBox3.Text))
                    {
                        personelsayfa ps = new personelsayfa();
                        ps.Show();
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
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyiniz.");
                }
            }
            catch
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreniz ile giriş yapınız.");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
        int gkod;
        private void personelgiris_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
