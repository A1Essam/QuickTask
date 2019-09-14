using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace collective_v2
{
    public partial class file2 : Form
    {
        string fp;
        FileInfo fi;

        public file2(string fp2, string type)
        {
            InitializeComponent();
            fp = type;
            fi = new FileInfo(file1.fpp);

            dataGridView1.Hide();
            label1.Hide();
            textBox1.Hide();
            button1.Hide();
            button2.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button3.Hide();
            label2.Hide();
            label3.Hide();
            button4.Hide();
            label4.Hide();

            try
            {

                if (type == "detils") detils();
                if (type == "Rename") Rename();
                if (type == "Delete") Delete();
                if (type == "add") addtoend();
                if (type == "replace") replace();
                if (type == "find" || type == "dlt") find();
            }
            catch (Exception e) { }
        }

        void find()
        {
            button4.Show();
            if (fp == "find") button4.Text = "Find!";
            else button4.Text = "Remove!";
            if (fp == "find") label4.Show();
            label2.Show();
            label4.Text = " ";

            textBox3.Show();
            this.ClientSize = new Size(457, 190);


        }



        void detils()
        {


            dataGridView1.Show();
            dataGridView1.Rows.Add("Name", fi.Name);
            dataGridView1.Rows.Add("Size", fi.Length);
            dataGridView1.Rows.Add("Last Modified ", fi.LastWriteTime);
            dataGridView1.Rows.Add("Creation", fi.CreationTime);
            dataGridView1.Rows.Add("Directory", fi.Directory);
            dataGridView1.Rows.Add("Full path", fi.FullName);
            dataGridView1.Rows.Add("Extension", fi.Extension);

        }

        void Rename()
        {
            label1.Show();
            textBox1.Show();
            button1.Show();

            this.ClientSize = new Size(391, 110);


        }

        void Delete()
        {
            label1.Show();
            label1.Text = "Done ! File deleted.";

            this.ClientSize = new Size(391, 110);


        }


        void addtoend()
        {

            textBox2.Show();
            button2.Show();
        }

        void replace()
        {
            button3.Show();
            label2.Show();
            label3.Show();
            textBox4.Show();
            textBox3.Show();
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            file1.w = textBox3.Text;
            file1.rw = textBox4.Text;
            file1.rplc();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] arr = file1.ftxt.Split(' ');
            if (fp == "find")
            {
                int c = 0;
                for (int i = 0; i < arr.Length; i++)
                {

                    if (arr[i] == textBox3.Text) c++;

                }
                label4.Text = textBox3.Text + " found " + c + " times";
            }
            else
            {
                string text = "";
                for (int i = 0; i < arr.Length; i++)
                {

                    if (arr[i] == textBox3.Text) arr[i] = "";
                    text += arr[i];
                }
                file1.ftxt = text;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nn = fi.Directory + @"\" + textBox1.Text + ".txt";
            File.Move(file1.fpp, nn);
            file1.fpp = nn;
            file1.ti = textBox1.Text + ".txt";
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.AppendAllText(file1.fpp, textBox2.Text);
            file1.ftxt += textBox2.Text;
            this.Close();
        }

        private void file2_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
