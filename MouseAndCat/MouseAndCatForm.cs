using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using MouseAndCat;

namespace MouseAndCat
{
    public partial class MouseAndCatForm : Form
    {
        private SerialPort myPort;
        private MouseAndCatController controller;

        public MouseAndCatForm()
        {
            InitializeComponent();
            controller = new MouseAndCatController();
        }

        private void InitializeComPort(string PortName)
        {
            // TODO, serial port to be used serial port form
            int BaudRate = 9600;
            Parity Parity = Parity.None;
            int DataBits = 8;
            StopBits StopBits = StopBits.One;

            myPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
            myPort.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO, port reading to be another class
            //int rbyte = myPort.BytesToRead; 
            //byte[] buffer = new byte[rbyte];
            //int read = 0; 
            //while (read < rbyte) 
            //{ 
            //    int length = myPort.Read(buffer, read, rbyte - read);
            //    read += length;
            //}

            //textBox1.AppendText(Encoding.ASCII.GetString(buffer).Replace("\r", "\r\n"));
            controller.setMapData(textBox1.Lines);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
            //InitializeComPort(comboBox1.SelectedText);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen boldPen = new Pen(Color.Black, 3);
            int offsetX = 20;
            int offsetY = 20;

            for (int i = 0; i < controller.map.mapSizeX; i++)
            {
                int y1 = (offsetY * (controller.map.mapSizeX - i - 1));
                int y2 = y1 + offsetY;
                for (int j = 0; j < controller.map.mapSizeY; j++)
                {
                    int x1 = offsetX * j;
                    int x2 = x1 + offsetX;
                    if (controller.map.wall[i, j].west == WallStatus.Exist) g.DrawLine(boldPen, x1, y1, x1, y2);
                    if (controller.map.wall[i, j].north == WallStatus.Exist) g.DrawLine(boldPen, x1, y1, x2, y1);
                    if (controller.map.wall[i, j].south == WallStatus.Exist) g.DrawLine(boldPen, x1, y2, x2, y2);
                    if (controller.map.wall[i, j].east == WallStatus.Exist) g.DrawLine(boldPen, x2, y1, x2, y2);
                }
            }

            boldPen.Dispose();
        }

    }
}
