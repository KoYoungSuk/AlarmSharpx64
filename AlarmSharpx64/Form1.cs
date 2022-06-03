using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace AlarmSharpx64
{
    public partial class Form1 : Form
    {
        Boolean setting = false;
        int time = 0;
        int originaltime = 0;
        SoundPlayer sp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
            progressBar1.Maximum = originaltime;
            if (setting == true)
            {
                time = time - 1;
                label8.Text = time + " SECONDS";
                progressBar1.Value++;
                if (time <= 0 || progressBar1.Value >= originaltime)
                {
                    setting = false;
                    time = 0;
                    originaltime = 0;
                    progressBar1.Value = 0;
                    if (label7.Text == "Default(Beep Sound)")
                    {
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                        Console.Beep(1234, 350);
                    }
                    else
                    {
                        sp = new SoundPlayer(label7.Text);
                        sp.PlayLooping();
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String filepath = null;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                label7.Text = filepath;
                
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            String filepath = label7.Text;
            if(filepath == "Default(Beep Sound)")
            {
                Console.Beep(1234, 350);
                Console.Beep(1234, 350);
                Console.Beep(1234, 350);
                Console.Beep(1234, 350);
            }
            else
            {
                sp = new SoundPlayer(filepath);
                sp.Play();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String filepath = label7.Text;
            sp.Stop();
  
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int hour = Int32.Parse(textBox1.Text);
            int min = Int32.Parse(textBox2.Text);
            if(hour == 0)
            {
                linkLabel1.Text = "SECRET LINK";
            }
                for (; hour >= 1; hour--)
                {
                    time = time + 3600;
                }
                for (; min >= 1; min--)
                {
                    time = time + 60;
                }
            originaltime = time;
            setting = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setting = false;
            time = 0;
            originaltime = 0;
            label8.Text = "0 SECONDS";
            label7.Text = "Default(Beep Sound)";
            progressBar1.Value = 0; 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Text = "I THINK IT IS TIMER!!";
            Form2 timer = new Form2();
            timer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 help = new Form3();
            help.Show();
        }
    }
}
