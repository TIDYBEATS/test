using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMTE.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            LoadTheme();
        }


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


        private void Settings_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Program Files (x86)\\TIDYBEATS\\Multi Tool\\XBOX360SDK.exe"))
            {
                MessageBox.Show("File Missing");
            }
            else
            {
                Process.Start("C:\\Program Files (x86)\\TIDYBEATS\\Multi Tool\\XBOX360SDK.exe");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\TIDYBEATS\\Multi Tool\\XEX\\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\TIDYBEATS\\Multi Tool\\XEX\\");
        }
    }
}
