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
    public partial class asirandevu : Form
    {
        public asirandevu()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            covid19x cv = new covid19x();
            cv.ShowDialog();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            try
            {
                baglanti.Open();
                if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "")
                    MessageBox.Show("lütfen eksiz doldurmadığınızdan emin olun !", "hata");
                else
                {
                    OleDbDataAdapter komut = new OleDbDataAdapter("insert into asi(TC,Aşı_Seçimi,Saat,Tarih,Yaş) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
                    DataSet hafiza = new DataSet();
                    komut.Fill(hafiza);
                    MessageBox.Show("randevunuz başarıyla alındı");
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void asirandevu_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");

            if (textBox1.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kullanicigiris where TC like '" + textBox1.Text + "'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox4.Text = read[7].ToString();
                int sayi1 = Convert.ToInt32(textBox4.Text);
                int sonuc = 2021 - sayi1;
                textBox3.Text = sonuc.ToString();

                if (sonuc > 40)
                {
                    MessageBox.Show("aşı sıranız gelmiştir. Lütfen randevu alın");
                }
                else
                {
                    MessageBox.Show("40 yaşından küçüksünüz randevu almayın");
                    hastasayfa hs = new hastasayfa();
                    hs.ShowDialog();
                    this.Close();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "09:00";
            button3.BackColor = Color.Green;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "09:20";
            button4.BackColor = Color.Green;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "09:40";
            button5.BackColor = Color.Green;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "10:00";
            button6.BackColor = Color.Green;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "10:20";
            button7.BackColor = Color.Green;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "10:40";
            button8.BackColor = Color.Green;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "11:00";
            button9.BackColor = Color.Green;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "11:20";
            button10.BackColor = Color.Green;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "11:40";
            button11.BackColor = Color.Green;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "12:00";
            button12.BackColor = Color.Green;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "12:20";
            button13.BackColor = Color.Green;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "12:40";
            button14.BackColor = Color.Green;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "13:00";
            button15.BackColor = Color.Green;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "13:20";
            button16.BackColor = Color.Green;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "13:40";
            button17.BackColor = Color.Green;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "14:00";
            button18.BackColor = Color.Green;
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "14:20";
            button19.BackColor = Color.Green;
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "14:40";
            button20.BackColor = Color.Green;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "15:00";
            button21.BackColor = Color.Green;
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "15:20";
            button22.BackColor = Color.Green;
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "15:40";
            button23.BackColor = Color.Green;
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "16:00";
            button24.BackColor = Color.Green;
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "16:20";
            button25.BackColor = Color.Green;
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "16:40";
            button26.BackColor = Color.Green;
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "17:00";
            button27.BackColor = Color.Green;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
