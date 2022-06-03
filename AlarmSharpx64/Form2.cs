using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlarmSharpx64
{
    public partial class Form2 : Form
    {
        int i;
        int count;
        int time = 0;
        int originaltime;
        Boolean timersetting;
        Boolean stopwatchsetting;
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            progressBar1.Maximum = originaltime;
            if(stopwatchsetting == true)
            {
                i++;
                label9.Text = i + "초";
            }
            if(timersetting == true)
            {
                label10.Text = "타이머 시작";
                time = time - 1;
                label7.Text = time + " SECONDS";
                progressBar1.Value++;
                if(time <= 0 || progressBar1.Value >= progressBar1.Maximum)
                {
                    
                    label10.Text = "타이머 종료";
                    progressBar1.Value = 0;
                    timersetting = false;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            label8.Text = "비밀 스톱워치 작동!!";
            stopwatchsetting = true;
            int hour = Int32.Parse(textBox1.Text);
            int min = Int32.Parse(textBox2.Text);
            int sec = Int32.Parse(textBox3.Text);
            for (; hour >= 1; hour--)
            {
                time = time + 3600;
            }
            for (; min >= 1; min--)
            {
                time = time + 60;
            }
            for(; sec >= 1; sec--)
            {
                time = time + 1;
            }
            originaltime = time;
            timersetting = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            timersetting = false;
            stopwatchsetting = false;
            String datetimetxt = DateTime.Now.ToString();
            if(count == 1)
            {
                saveFileDialog1.FileName = "오늘의 스톱워치.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
                    writer.WriteLine(datetimetxt + "스톱워치 기록:" + label9.Text);
                    writer.Dispose();
                    writer.Close();
                }
            }
            else
            {
                StreamWriter writer2 = new StreamWriter(saveFileDialog1.OpenFile());
                writer2.WriteLine(datetimetxt + "스톱워치 기록:" + label9.Text);
                writer2.Dispose();
                writer2.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            time = 0;
            originaltime = 0;
            label7.Text = "0 SECONDS";
            label10.Text = "타이머가 아직 시작되지 않았습니다.";
            timersetting = false;
            stopwatchsetting = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
