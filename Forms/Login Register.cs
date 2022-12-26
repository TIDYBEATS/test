using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Threading;
using MetroFramework.Controls;
using System.Linq.Expressions;

namespace CMTE.Forms
{
    public partial class Login_Register : Form
    {
        public Login_Register()
        {
            InitializeComponent();
        }

public static api KeyAuthApp = new api(
    name: "MODTOOL",
    ownerid: "grpfx2QNFf",
    secret: "7f842ec9c5c05a850ddbc04dbd918e2eacb5a43fa42ed27ab79ba8d31992b828",
    version: "1.0"
);


        private void Login_Register_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.username != String.Empty)
            {
                textBox1.Text = Properties.Settings.Default.username;
                textBox2.Text = Properties.Settings.Default.password;
            }

            LoadTheme();

        }

        static string random_string()
        {
            string str = null;

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                str += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
            }
            return str;

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
            label4.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
        }




        private void button3_Click(object sender, EventArgs e)
        {
            KeyAuthApp.upgrade(textBox1.Text, textBox3.Text); // success is set to false so people can't press upgrade then press login and skip logging in. it doesn't matter, since you shouldn't take any action on succesfull upgrade anyways. the only thing that needs to be done is the user needs to see the message from upgrade function
           Form1.Form1Instance.label1.Text = "Status: " + KeyAuthApp.response.message;
            // don't login, because they haven't authenticated. this is just to extend expiry of user with new key.
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.username = textBox1.Text;
                Properties.Settings.Default.password = textBox2.Text;
                Properties.Settings.Default.Save();
            }

            if (checkBox1.Checked == false)
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }




            Form1.KeyAuthApp.login(textBox1.Text, textBox2.Text);
            if (Form1.KeyAuthApp.response.success)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                Form1.Form1Instance.label1.Text = ("Status : Welcome : " + textBox1.Text) ;;

                var form = Form1.ActiveForm as Form1;
                if (form != null)
                {
                    form.button2.Visible = true;
                    form.button9.Visible = true;
                    form.button10.Visible = true;
                    form.button2.Enabled = true;
                    form.button9.Enabled = true;
                    form.button10.Enabled = true;
                    form.button2.Enabled = true;
                    form.button3.Enabled = true;
                    form.button4.Enabled = true;
                    form.button14.Enabled = true;
                }
            }
            else
                Form1.Form1Instance.label1.Text = ("Status: " + Form1.KeyAuthApp.response.message);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.KeyAuthApp.register(textBox1.Text, textBox2.Text, textBox3.Text);
            if (Form1.KeyAuthApp.response.success)
            {

            }
            else
                Form1.Form1Instance.label1.Text = "Status: " + Form1.KeyAuthApp.response.message;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
