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
    public partial class file1 : Form
    {
        string st;
        public file1(string s)
        {
            InitializeComponent();
            timer1.Start();
            st = s;
            comboBox1.Items.Add("Rename");
            comboBox1.Items.Add("Save");
            comboBox1.Items.Add("Save As");
            comboBox1.Items.Add("Add to End");
            comboBox1.Items.Add("Replace");
            comboBox1.Items.Add("Find");
            comboBox1.Items.Add("Remove");
            comboBox1.Items.Add("Details");
            comboBox1.Items.Add("Delete");
            comboBox1.Items.Add("Exit");
        }

        private void file1_Load(object sender, EventArgs e)
        {
            textBox1.Text=st;
        }

        public static string ftxt;

        public int linenum()
        {
            int lines = 1;
            string s = textBox1.Text.ToString().Trim();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n') { lines++; }
            }
            return lines;
        }

        static OpenFileDialog dialog = new OpenFileDialog();
        public static String fpp ="0";
        public static string rw;
        public static string w;
        public static string ti;

        static void openDialog()
        {

            dialog.InitialDirectory = @"D:\";
            dialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(dialog.FileName);
                fpp = dialog.FileName;
                ftxt = content;
                FileInfo fi = new FileInfo(fpp);
                ti = fi.Name;

            }


        }


        public int wordnum()
        {
            int word = 1;
            string s = textBox1.Text.ToString().Trim();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') { word++; }
            }
            return word;
        }

        public static void rplc()
        {
            string[] arr = ftxt.Split(' ');
            string text = "";
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] == w) arr[i] = " " + rw + " ";
                text += arr[i];
            }


            ftxt = text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ftxt = textBox1.Text;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Rename")
            {
                file2 form2nd = new file2(fpp, "Rename");
                form2nd.Text = "Rename";
                form2nd.Show();
            }
            if (comboBox1.Text == "Add to End")
            {
                file2 form2nd = new file2(fpp, "add");
                form2nd.Text = "Add to End";

                form2nd.Show();
            }
            if (comboBox1.Text == "Details")
            {
                file2 form2nd = new file2(fpp, "detils");
                form2nd.Text = "Details";
                form2nd.Show();
            }
            if (comboBox1.Text == "Delete")
            {
                File.Delete(fpp);
                ftxt = " ";
                MessageBox.Show("Done! File deleted");

            }
            if (comboBox1.Text == "Save As")
            {
                if (fpp != "0")
                {
                    File.WriteAllText(fpp, textBox1.Text);
                    SaveFileDialog filedialog;
                    filedialog = new SaveFileDialog();
                    filedialog.InitialDirectory = @"D:\";
                    FileInfo fi = new FileInfo(fpp);
                    filedialog.FileName = fi.Name;
                    if (filedialog.ShowDialog() == DialogResult.OK)
                    {

                        File.Move(fpp, filedialog.FileName + ".txt");
                        fpp = filedialog.FileName + ".txt";
                    }
                }
                else
                {
                    SaveFileDialog filedialog;
                    filedialog = new SaveFileDialog();
                    filedialog.InitialDirectory = @"D:\";
                    if (filedialog.ShowDialog() == DialogResult.OK)
                    {

                       StreamWriter st = new StreamWriter(filedialog.FileName + ".txt");
                        st.Write(ftxt);
                        st.Close();
                       fpp = filedialog.FileName + ".txt";
                    }
                }
                

            }

            if (comboBox1.Text == "Save")
            {

                File.WriteAllText(fpp, ftxt);

            }
            if (comboBox1.Text == "Exit")
            {

                this.Close();

            }
            if (comboBox1.Text == "Find")
            {
                file2 form2nd = new file2(fpp, "find");
                form2nd.Text = "Find";
                form2nd.Show();

            }

            if (comboBox1.Text == "Remove")
            {
                file2 form2nd = new file2(fpp, "dlt");
                form2nd.Text = "Remove";
                form2nd.Show();

            }

            if (comboBox1.Text == "Replace")
            {

                file2 form2nd = new file2(fpp, "replace");
                form2nd.Text = "Replace";
                form2nd.Show();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = ftxt;
            lablechar.Text = textBox1.Text.Length.ToString().Trim();
            labelline.Text = linenum().ToString().Trim();
            lableword.Text = wordnum().ToString().Trim();

            this.Text = ti;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lablechar_Click(object sender, EventArgs e)
        {

        }
    }
}
