using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using MouseBT_Tool;

namespace MouseBT_Tool
{
    public partial class MouseAndCatForm : Form
    {
        private SerialPort myPort;
        private byte[,] myMap = new byte[16,16];
        private Map m = new Map(16, 16);

        public MouseAndCatForm()
        {
            InitializeComponent();

        }

        private void InitializeComPort(string PortName)
        {
            int BaudRate = 9600;
            Parity Parity = Parity.None;
            int DataBits = 8;
            StopBits StopBits = StopBits.One;

            myPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
            myPort.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] temp;
            //int rbyte = myPort.BytesToRead; 
            //byte[] buffer = new byte[rbyte];
            //int read = 0; 
            //while (read < rbyte) 
            //{ 
            //    int length = myPort.Read(buffer, read, rbyte - read);
            //    read += length;
            //}

            //textBox1.AppendText(Encoding.ASCII.GetString(buffer).Replace("\r", "\r\n"));
            temp = textBox1.Text.Split(' ');
            int x_idx = int.Parse(temp[0], System.Globalization.NumberStyles.HexNumber);
            for (int i = 0; i < 16; i++ )
            {
                myMap[x_idx, i] = byte.Parse(temp[i + 2], System.Globalization.NumberStyles.HexNumber);

                m.pos[x_idx, i].northWall = ((myMap[0x0F, i] & 0x01) == 0x01) ? wall.Exist : wall.None;
                m.pos[x_idx, i].eastWall = ((myMap[0x0F, i] & 0x02) == 0x02) ? wall.Exist : wall.None;
                m.pos[x_idx, i].southWall = ((myMap[0x0F, i] & 0x04) == 0x04) ? wall.Exist : wall.None;
                m.pos[x_idx, i].westWall = ((myMap[0x0F, i] & 0x08) == 0x08) ? wall.Exist : wall.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            //InitializeComPort(comboBox1.SelectedText);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen boldPen = new Pen(Color.Red, 3);
            int x_offset = 10;

            for (int i = 0; i < 16; i++)
            {
                if (m.pos[0x0F, i].northWall == wall.Exist) g.DrawLine(boldPen, (x_offset*i), 10, (x_offset*(i+1)), 10);
                if (m.pos[0x0F, i].eastWall == wall.Exist) g.DrawLine(boldPen, (x_offset * (i + 1)), 10, (x_offset * (i + 1)), 20);
                if (m.pos[0x0F, i].southWall == wall.Exist) g.DrawLine(boldPen, (x_offset * i), 20, (x_offset * (i + 1)), 20);
                if (m.pos[0x0F, i].westWall == wall.Exist) g.DrawLine(boldPen, (x_offset * i), 10, (x_offset * i), 20);
            }

            //boldPen.Dispose;
            //g.Dispose;
        }

    }
}
