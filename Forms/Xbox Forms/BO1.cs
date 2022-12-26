using JRPC_Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDevkit;
using XRPCLib;

namespace CMTE.Forms
{
    public partial class BO1 : Form
    {
        public BO1()
        {
            InitializeComponent();
            LoadTheme();

            jtag.Connect(out jtag);

        }


        IXboxConsole jtag;
        

        XRPC jtag1 = new XRPC();

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
                button2.BackColor = ThemeColor.PrimaryColor;
                button2.ForeColor = Color.White;
                button2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
        }


        private void BO1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            jtag.Connect(out jtag);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void BO1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
