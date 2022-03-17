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
    public partial class hastabilgi : Form
    {
        public hastabilgi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Visible = false;
        }

        private void hastabilgi_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            
            if (textBox1.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from randevual where TC like '" + textBox1.Text + "'", baglanti);
            OleDbDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                textBox2.Text = read[2].ToString();
                textBox3.Text = read[3].ToString();
                textBox4.Text = read[4].ToString();
                textBox5.Text = read[5].ToString();
            }
            baglanti.Close();
        }
    }
}
