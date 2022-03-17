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
    public partial class poliklinik : Form
    {
        public poliklinik()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            OleDbCommand komut = new OleDbCommand("insert into polekle(poliklinik) values(@poliklinik)", baglanti);
            komut.Parameters.AddWithValue("@poliklinik", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı...");
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Close();
        }

        private void poliklinik_Load(object sender, EventArgs e)
        {

        }
    }
}
