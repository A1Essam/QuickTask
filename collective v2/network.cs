using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;

namespace collective_v2
{
    public partial class network : Form
    {
        int type = 0;
        public network()
        {
            InitializeComponent();
        }

        private void network_Load(object sender, EventArgs e)
        {
            hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(546, 278);
            hide();
            richTextBox1.Show();
            button7.Show();
            type = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (type == 1)
            {
                hide();
                richTextBox2.Show();
                this.ClientSize = new Size(546, 392);
                
                IPAddress[] ips = Dns.GetHostAddresses(richTextBox1.Text);
                richTextBox2.Clear();
                foreach (var ip in ips)
                {
                    richTextBox2.Text += ip.ToString() + "\n";
                }

            }else if(type == 2)
            {
                hide();
                dataGridView1.Show();
                this.ClientSize = new Size(546, 392);
                Ping p = new Ping();
                PingReply pr = p.Send(richTextBox1.Text);
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("Address", pr.Address);
                  dataGridView1.Rows.Add("Buffer", pr.Buffer);
                  dataGridView1.Rows.Add("Status", pr.Status);
                  dataGridView1.Rows.Add("Nodes", pr.Options.Ttl);


            }else if(type == 3)
            {
                WebClient wc = new WebClient();
                byte[] con = wc.DownloadData("https://" + richTextBox1.Text);
                string content = ASCIIEncoding.Default.GetString(con);
                file1 go = new file1(content);
                go.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(546, 278);
            hide();
            richTextBox1.Show();
            button7.Show();
            type = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            hide();
            dataGridView1.Show();
            this.ClientSize = new Size(546, 514);
            NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
            dataGridView1.Rows.Clear();
            foreach (var ni in nis)
            {
                dataGridView1.Rows.Add("Network ID", ni.Id);
                dataGridView1.Rows.Add("Network name", ni.Name);
                dataGridView1.Rows.Add("Network description", ni.Description);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(546, 278);
            hide();
            richTextBox1.Show();
            button7.Show();
            type = 2;
        }

        void hide()
        {
            richTextBox2.Hide();
            richTextBox1.Hide();
            button7.Hide();
            dataGridView1.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
