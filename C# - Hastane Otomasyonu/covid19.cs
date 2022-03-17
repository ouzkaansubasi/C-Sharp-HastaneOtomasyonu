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

namespace Hastane_Otomasyonu
{
    public partial class covid19 : Form
    {
        public covid19()
        {
            InitializeComponent();
        }

        private void covid19_Load(object sender, EventArgs e)
        {
            string[] jsonVerileri, bugunkiKoronaCozumle;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://raw.githubusercontent.com/ozanerturk/covid19-turkey-api/master/dataset/timeline.json");
                jsonVerileri = json.ToString().Split('{');
            }

            bugunkiKoronaCozumle = jsonVerileri[jsonVerileri.Length - 1].Split('"');

            label7.Text = bugunkiKoronaCozumle[3];
            label8.Text = bugunkiKoronaCozumle[31];
            label9.Text = bugunkiKoronaCozumle[35];
            label10.Text = bugunkiKoronaCozumle[55];
            label11.Text = bugunkiKoronaCozumle[51];
            label12.Text = bugunkiKoronaCozumle[39];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelsayfa ps = new personelsayfa();
            ps.Show();
            this.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
