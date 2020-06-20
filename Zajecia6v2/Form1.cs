using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zajecia6v2
{
    public partial class Form1 : Form
    {
        int cd = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var path = dialog.FileName;

            string data = File.ReadAllText(path);

            //odpal resztę UI

            foreach(string item in data.Split(new[] { "\n","\r"}, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNUmberTextBox(Convert.ToInt32(item)));
            }
            button1.Enabled = true;
        }

        private TextBox GenerateNUmberTextBox(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                ReadOnly = true,
                Width = 25

            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            
            button1.Enabled = false;
            int x = rand.Next(100);
            textBox1.Text = x.ToString();
            flowLayoutPanel2.Controls.Add(GenerateNUmberTextBox(x));
            cd++;
            int score = 0;
            if (cd == 6) {

                button2.Enabled = false;
                timer1.Stop();
                button3.Enabled = true;
                textBox2.Text = score.ToString();

                foreach (TextBox textb in flowLayoutPanel1.Controls)
                {
                    foreach(TextBox textb2 in flowLayoutPanel2.Controls)
                    {
                        if (textb.Text == textb2.Text) {
                            score += 1;
                            textBox2.Text = score.ToString();
                        }
                    }
                }

                if (score != 0) textBox2.BackColor = Color.Green;
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
