using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libdebug;

namespace CMTE.Forms
{
    public partial class PS4 : Form
    {
        public PS4()
        {
            InitializeComponent();
        }

        private PS4DBG PS4_0;
        private ProcessList ProcessList_0 = null;
        private string string_0 = null;

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button Btn = (Button)btns;
                    Btn.BackColor = ThemeColor.PrimaryColor;
                    Btn.ForeColor = Color.White;
                    Btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
        }

        private void PS4_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PS4_0 = new PS4DBG(textBox1.Text);
            {
                MessageBox.Show("");
            }
            PS4_0.Connect();
            ProcessList_0 = PS4_0.GetProcessList();
            foreach (Process process in ProcessList_0.processes)
            {
                comboBox1.Items.Add(process.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                ProcessList_0 = PS4_0.GetProcessList();
                foreach(Process process in ProcessList_0.processes)
                {
                    comboBox1.Items.Add(process.name);
                }
                MessageBox.Show("Got Processes");
            }
            catch(Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PS4_0.Reboot();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PS4_0.Disconnect();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PS4_0.Notify(222, textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}