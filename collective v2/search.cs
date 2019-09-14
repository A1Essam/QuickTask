using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace collective_v2
{
    public partial class search : Form
    {


        string type1 = "Google";
        string type2 = "chrome";

        public search()
        {
            InitializeComponent();
            comboBox1.Items.Add("Google");
            comboBox1.Items.Add("Youtube");
            comboBox1.Items.Add("Bing");
            comboBox1.Items.Add("Wikipedia");
            comboBox2.Items.Add("chrome");
            comboBox2.Items.Add("firefox");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                type1 = comboBox1.Text;
            
        }

        private void search_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            type2 = comboBox2.Text;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (type1 == "Google")
                Process.Start(type2 + ".exe", "https://www.google.com/search?q=" + richTextBox1.Text);
            if (type1 == "Youtube")
                Process.Start(type2 + ".exe", "https://www.youtube.com/results?search_query=" + richTextBox1.Text);
            if (type1 == "Bing")
                Process.Start(type2 + ".exe", "https://www.bing.com/search?q=" + richTextBox1.Text);
            if (type1 == "Wikipedia")
                Process.Start(type2 + ".exe", "https://en.wikipedia.org/wiki/" + richTextBox1.Text);
        }
    }
}
