using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMTE.Forms.PS4_Forms
{
    public partial class BO3PS4 : Form
    {
        public BO3PS4()
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
                    btns.Enabled = false;
                }
            }
        }
        private void BO3PS4_Load(object sender, EventArgs e)
        {

        }

    }
}