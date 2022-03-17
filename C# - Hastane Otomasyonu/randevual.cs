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
    public partial class randevual : Form
    {
        public randevual()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "09:00";
            button3.BackColor = Color.Green;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "09:20";
            button4.BackColor = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "09:40";
            button5.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10:00";
            button6.BackColor = Color.Green;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10:20";
            button7.BackColor = Color.Green;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10:40";
            button8.BackColor = Color.Green;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "11:00";
            button9.BackColor = Color.Green;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = "11:20";
            button10.BackColor = Color.Green;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = "11:40";
            button11.BackColor = Color.Green;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "12:00";
            button12.BackColor = Color.Green;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = "12:20";
            button13.BackColor = Color.Green;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "12:40";
            button14.BackColor = Color.Green;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = "13:00";
            button15.BackColor = Color.Green;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = "13:20";
            button16.BackColor = Color.Green;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "13:40";
            button17.BackColor = Color.Green;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = "14:00";
            button18.BackColor = Color.Green;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = "14:20";
            button19.BackColor = Color.Green;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = "14:40";
            button20.BackColor = Color.Green;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = "15:00";
            button21.BackColor = Color.Green;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox2.Text = "15:20";
            button22.BackColor = Color.Green;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text = "15:40";
            button23.BackColor = Color.Green;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox2.Text = "16:00";
            button24.BackColor = Color.Green;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox2.Text = "16:20";
            button25.BackColor = Color.Green;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox2.Text = "16:40";
            button26.BackColor = Color.Green;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox2.Text = "17:00";
            button27.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastasayfa hs = new hastasayfa();
            hs.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            try
            {
                baglanti.Open();
                if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" ||  textBox2.Text == "" || dateTimePicker1.Text == "")
                    MessageBox.Show("lütfen eksiz doldurmadığınızdan emin olun !", "hata");
                else
                {
                    OleDbDataAdapter komut = new OleDbDataAdapter("insert into randevual(tc,poliklinik,doktor,saat,tarih) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "')", baglanti);
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

        private void randevual_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from polekle", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["poliklinik"]);
            }
            baglanti.Close();

            baglanti.Open();
            OleDbCommand k = new OleDbCommand("select * from doktorekle", baglanti);
            OleDbDataReader o = k.ExecuteReader();
            while (o.Read())
            {
                comboBox2.Items.Add(o["ad_soyad"]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");    
            comboBox2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select ad_soyad from doktorekle where polID=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedIndex + 1);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            baglanti.Close();
        }
    }
}
