using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace CMTE.Forms
{
    public partial class Profile : Form
    {
        public Profile()
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
            version.ForeColor = ThemeColor.SecondaryColor;
            ip.ForeColor = ThemeColor.PrimaryColor;
            subscription.ForeColor = ThemeColor.PrimaryColor;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.KeyAuthApp.response.success)
            {
                key.Text = "Username: " + Form1.KeyAuthApp.user_data.username;
                expiry.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry));
                subscription.Text = "Subscription: " + Form1.KeyAuthApp.user_data.subscriptions[0].subscription;
                ip.Text = "IP Address: " + Form1.KeyAuthApp.user_data.ip;
                version.Text = "Current version: " + Form1.KeyAuthApp.app_data.version;
                label1.Text = "Hardware ID: " + Form1.KeyAuthApp.user_data.hwid;
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadTheme();
            if (Form1.KeyAuthApp.response.success)
            {
                key.Text = "Username: " + Form1.KeyAuthApp.user_data.username;
                expiry.Text = "Expiry: " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry));
                subscription.Text = "Subscription: " + Form1.KeyAuthApp.user_data.subscriptions[0].subscription;
                ip.Text = "IP Address: " + Form1.KeyAuthApp.user_data.ip;
                version.Text = "Current version: " + Form1.KeyAuthApp.app_data.version;
                label1.Text = "Hardware ID: " + Form1.KeyAuthApp.user_data.hwid;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
