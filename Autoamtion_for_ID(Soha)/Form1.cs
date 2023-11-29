using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoamtion_for_ID_Soha_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PortBarlaweDak()
        {
            serialPort1.Close();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine(ports);
            // Display each port name to the console.
            foreach (string port in ports)
            {
                serialPort1.PortName = port;
                label4.Text = serialPort1.PortName.ToString() + " detected!";
                label4.ForeColor = Color.Green;
                pictureBox1.Image = Properties.Resources.icons8_checkmark_480px_1;
            }
            try
            {
                serialPort1.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Arduinony birikdir!");
                label4.Text = " ";
                pictureBox1.Image = Properties.Resources.icons8_delete_480px;
                Form1_Load(MessageBoxButtons.OKCancel, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortBarlaweDak();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\ID.txt";
            File.AppendAllLines(path, new[] { "Checked!".ToString() });
            label3.Text = "Checked!".ToString();
            pictureBox2.Image = Properties.Resources.icons8_checkmark_480px_1;
            button1.BackColor = Color.Green;
        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadLine();
            data.Trim();
            long k = Int64.Parse(data);
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    yazdyr(k);
                }));
            }
        }

        private void yazdyr(long data)
        {
            string path = @"D:\ID.txt";
            File.AppendAllLines(path, new[] { data.ToString() });
            label3.Text = data.ToString();
            pictureBox2.Image = Properties.Resources.icons8_checkmark_480px_1;
        }

    }
}
