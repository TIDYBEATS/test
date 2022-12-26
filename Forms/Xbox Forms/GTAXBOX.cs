using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMTE.Forms.Xbox_Forms
{
    public partial class GTAXBOX : Form
    {
        public GTAXBOX()
        {
            InitializeComponent();
        }
        private void GTAXBOX_Load(object sender, EventArgs e)
        {
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
        }
    }
}
