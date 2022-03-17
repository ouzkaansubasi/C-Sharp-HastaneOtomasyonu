using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.OleDb;

namespace Hastane_Otomasyonu
{
    public partial class covid19x : Form
    {
        public covid19x()
        {
            InitializeComponent();
        }

        public void kayitlarilistele()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from asi", baglanti);
                DataSet hafiza = new DataSet();
                listele.Fill(hafiza);
                dataGridView1.DataSource = hafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void covid19x_Load(object sender, EventArgs e)
        {
                string[] jsonVerileri, bugunkiKoronaCozumle;

                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("https://raw.githubusercontent.com/ozanerturk/covid19-turkey-api/master/dataset/timeline.json");
                    jsonVerileri = json.ToString().Split('{');
                }

                bugunkiKoronaCozumle = jsonVerileri[jsonVerileri.Length - 1].Split('"');

                label8.Text = bugunkiKoronaCozumle[3];
                label9.Text = bugunkiKoronaCozumle[31];
                label10.Text = bugunkiKoronaCozumle[35];
                label11.Text = bugunkiKoronaCozumle[55];
                label12.Text = bugunkiKoronaCozumle[51];
                label13.Text = bugunkiKoronaCozumle[39];

            kayitlarilistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hastasayfa hs = new hastasayfa();
            hs.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kayitlarilistele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            if (MessageBox.Show(" randevuyu silmek istediğinize emin misiniz?", "uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baglanti.Open();
                string sorgu = "DELETE FROM asi WHERE TC=@TC";
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[2].Value);
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayitlarilistele();
            }
            else
                kayitlarilistele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            asirandevu ar = new asirandevu();
            ar.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            randevubilgi rb = new randevubilgi();
            rb.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen hastanın tcsini girin...");
            }
            else
            {
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from asi where TC like '" + textBox1.Text + "%'", baglanti);
                DataSet ds = new DataSet();

                adtr.Fill(ds, "asi");
                dataGridView1.DataSource = ds.Tables["asi"];
            }
            baglanti.Close();
        }
    }
}
