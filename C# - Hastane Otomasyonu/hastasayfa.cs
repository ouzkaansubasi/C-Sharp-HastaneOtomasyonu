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
    public partial class hastasayfa : Form
    {
        public hastasayfa()
        {
            InitializeComponent();
        }
        public void kayitlarilistele()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from randevual", baglanti);
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
        private void button1_Click(object sender, EventArgs e)
        {
            randevual ra = new randevual();
            ra.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label2.Text = dt.ToShortDateString();
            label1.Text = dt.ToShortTimeString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hakkimizda hak = new hakkimizda();
            hak.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            covid19x cvd19 = new covid19x();
            cvd19.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hastabilgi hb = new hastabilgi();
            hb.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void hastasayfa_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kayitlarilistele();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen hastanın tcsini girin...");
            }
            else
            {
                OleDbDataAdapter adtr = new OleDbDataAdapter("select * from randevual where TC like '" + textBox1.Text + "%'", baglanti);
                DataSet ds = new DataSet();

                adtr.Fill(ds, "randevual");
                dataGridView1.DataSource = ds.Tables["randevual"];
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            if (MessageBox.Show(" randevuyu silmek istediğinize emin misiniz?", "uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                baglanti.Open();
                string sorgu = "DELETE FROM randevual WHERE TC=@TC";
                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[1].Value);            
                komut.ExecuteNonQuery();
                baglanti.Close();
                kayitlarilistele();
            }
            else
                kayitlarilistele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
