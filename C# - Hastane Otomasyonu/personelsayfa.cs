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
    public partial class personelsayfa : Form
    {
        public personelsayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            poliklinik pol = new poliklinik();
            pol.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doktorekle de = new doktorekle();
            de.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            covid19 cvd19 = new covid19();
            cvd19.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hakkimizda hak = new hakkimizda();
            hak.ShowDialog();
        }

        private void personelsayfa_Load(object sender, EventArgs e)
        {
            goster();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void goster()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from doktorekle order by ad_soyad", baglanti);
            adtr.Fill(ds, "Okunan Veri");
            dataGridView1.DataSource = ds.Tables["Okunan Veri"];
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (kontrol == true)
            {
                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
                baglanti.Open();
                OleDbCommand sil = new OleDbCommand("delete from doktorekle where doktorID = @doktorID", baglanti);
                sil.Parameters.AddWithValue("@doktorID", secili_kayit);

                DialogResult onay = MessageBox.Show(secili_kayit + "Nolu kayıtı silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme işlemi başarı ile gerçekleşti...");
                }
                baglanti.Close();
                goster();
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!");
            }
        }

        string secili_kayit;
        bool kontrol = false;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            secili_kayit = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            kontrol = true;
            Program.doktorID = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            Program.Ad_Soyad = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            Program.Cinsiyet = dataGridView1.Rows[secili].Cells[2].Value.ToString();
            Program.Doğum_Yeri = dataGridView1.Rows[secili].Cells[3].Value.ToString();
            Program.Doğum_Tarihi = dataGridView1.Rows[secili].Cells[4].Value.ToString();
            Program.Tel_No = dataGridView1.Rows[secili].Cells[5].Value.ToString();
            Program.Email = dataGridView1.Rows[secili].Cells[6].Value.ToString();
            Program.Poliklinik = dataGridView1.Rows[secili].Cells[7].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (kontrol == true)
            {
                doktorguncelle dg = new doktorguncelle();
                dg.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from doktorekle where ad_soyad like '" + textBox1.Text + "%' order by adsoyad", baglanti);
            adtr.Fill(ds, "tablo");
            dataGridView1.DataSource = ds.Tables["tablo"];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToShortDateString();
            label3.Text = dt.ToShortTimeString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from doktorekle where ad_soyad like '" + textBox1.Text + "%' order by ad_soyad", baglanti);
            adtr.Fill(ds, "tablo");
            dataGridView1.DataSource = ds.Tables["tablo"];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
