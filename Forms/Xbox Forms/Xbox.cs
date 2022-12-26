using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPC_Client;
using MetroFramework.Controls;
using XDevkit;
using XRPCLib;

namespace CMTE.Forms
{
    public partial class Xbox : Form
    {

        public Xbox()
        {
            InitializeComponent();
            LoadTheme();
        }

        IXboxConsole jtag;

        XRPC XRPC = new XRPC();


        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    button1.BackColor = ThemeColor.PrimaryColor;
                    button1.ForeColor = Color.White;
                    button1.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    button2.BackColor = ThemeColor.PrimaryColor;
                    button2.ForeColor = Color.White;
                    button2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    button3.BackColor = ThemeColor.PrimaryColor;
                    button3.ForeColor = Color.White;
                    button3.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    button4.BackColor = ThemeColor.PrimaryColor;
                    button4.ForeColor = Color.White;
                    button4.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.SecondaryColor;
            label7.ForeColor = ThemeColor.SecondaryColor;
            label8.ForeColor = ThemeColor.SecondaryColor;
            label9.ForeColor = ThemeColor.SecondaryColor;
            label19.ForeColor = ThemeColor.SecondaryColor;
            label20.ForeColor = ThemeColor.SecondaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
            label12.ForeColor = ThemeColor.PrimaryColor;
            label13.ForeColor = ThemeColor.PrimaryColor;
            label14.ForeColor = ThemeColor.PrimaryColor;
            label15.ForeColor = ThemeColor.PrimaryColor;
            label16.ForeColor = ThemeColor.PrimaryColor;
            label17.ForeColor = ThemeColor.PrimaryColor;
            label18.ForeColor = ThemeColor.PrimaryColor;
            label21.ForeColor = ThemeColor.PrimaryColor;
            label22.ForeColor = ThemeColor.PrimaryColor;


        }

        private void Xbox_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (jtag.Connect(out jtag))
                {
                    jtag.XNotify("Welcome To TIDYBEATS Multi-Tool");
                    label1.Text = "" + ((XDevkit.IXboxConsole)jtag).GetKernalVersion();
                    label2.Text = "" + ((XDevkit.IXboxConsole)jtag).GetCPUKey();
                    label3.Text = "" + ((XDevkit.IXboxConsole)jtag).XboxIP();
                    label4.Text = "" + ((XDevkit.IXboxConsole)jtag).XamGetCurrentTitleId();
                    label5.Text = "" + ((XDevkit.IXboxConsole)jtag).ConsoleType();
                    label19.Text = "" + ((XDevkit.IXboxConsole)jtag).GetHashCode();
                    label20.Text = "" + ((XDevkit.IXboxConsole)jtag).GetType();
                    label6.Text = "" + jtag.GetTemperature(JRPC.TemperatureType.CPU);
                    label7.Text = "" + jtag.GetTemperature(JRPC.TemperatureType.GPU);
                    label8.Text = "" + jtag.GetTemperature(JRPC.TemperatureType.MotherBoard);
                    label9.Text = "" + jtag.GetTemperature(JRPC.TemperatureType.EDRAM);
                    button3.Enabled = true;
                    button1.Text = ("Connected");
                    Form1.Form1Instance.label1.Text = ("Status: Connected");
                    Form1.Form1Instance.button10.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error Check Plugins Or Connection");
                    Form1.Form1Instance.label1.Text = ("Status: Unable To Connect");
                    button1.Text = ("Try Again");
                    Form1.Form1Instance.button10.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error Check Plugins Or Connection");
                Form1.Form1Instance.label1.Text = ("Status: Unable To Connect");
                button1.Text = ("Try Again");
                Form1.Form1Instance.button10.Enabled = false;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
            Form1.Form1Instance.label1.Text = ("Status: Copied CPU Key To Clipboard");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = "http://avatar.xboxlive.com/avatar/"
                + textBox1.Text + "/avatar-body.png#.USkt3x02aIM";
                pictureBox2.ImageLocation = "http://avatar.xboxlive.com/avatar/" + "/avatarpic-l.png";

            }
            catch
            {
                MessageBox.Show("Your avatar couldn't be retrieved");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jtag.ScreenShot(Application.StartupPath + "\\" + textBox2.Text + ".bmp");
            {
                Form1.Form1Instance.label1.Text = ("Status : Screenshot Taken");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            jtag.ShutDownConsole();
        }
    }
}
