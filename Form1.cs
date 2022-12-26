using CMTE.Forms;
using CustomControls.RJControls;
using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JRPC_Client;
using XDevkit;

namespace CMTE
{
    public partial class Form1 : Form
    {
        private const bool V = false;
        private const bool V1 = false;

        IXboxConsole jtag;


        //Fields
        public static Form1 Form1Instance;
        public Label lbl;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public static api KeyAuthApp = new api(
            name: "MODTOOL",
            ownerid: "grpfx2QNFf",
            secret: "7f842ec9c5c05a850ddbc04dbd918e2eacb5a43fa42ed27ab79ba8d31992b828",
            version: "1.0"
        );
        public Form1()
        {
           
            InitializeComponent();
            Form1Instance = this;
            lbl = label1;
            button6.Visible = false;
            customisingPanel();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            KeyAuthApp.init();

            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            break;
                        case DialogResult.No:
                            WebClient webClient = new WebClient();
                            string destFile = Application.ExecutablePath;

                            string rand = random_string();

                            destFile = destFile.Replace(".exe", $"-{rand}.exe");
                            webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                            Process.Start(destFile);
                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });

                            break;
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }

            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show(KeyAuthApp.response.message);
                Environment.Exit(0);
            }
            // if(KeyAuthApp.checkblack())
            // {
            //     MessageBox.Show("user is blacklisted");
            // }
            // else
            // {
            //     MessageBox.Show("user is not blacklisted");
            // }
            KeyAuthApp.check();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void Reset()
        {
            DisableButton();
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelMenu.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            Form1.Form1Instance.button6.Enabled = true;
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
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void OpenChildForm(Form childForm, object btnSender, bool v)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Title.Text = childForm.Text;

        }


        private void customisingPanel()
        {
            panelConsoleMenu.Visible = false;
            panelGames.Visible = false;
            panel1.Visible = false;

        }

        private void hidesubmenu()
        {
            if (panelConsoleMenu.Visible == true)
                panelConsoleMenu.Visible = false;
            if (panelGames.Visible == true)
                panelGames.Visible = false;
            if (panel1.Visible == true)
                panel1.Visible = false;

        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    button7.BackColor = color;
                    panelMenu.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button6.Visible = true;
                    button7.Visible = true;
                }
            }
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
                    button6.Visible = true;
                    button7.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Profile(), sender, V);
            LoadTheme();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Xbox(), sender, V);
            LoadTheme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.PS4(), sender, V);
            LoadTheme();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Login_Register(), sender, V);
            LoadTheme();

        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Settings(), sender, V);
            LoadTheme();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            jtag.Connect(out jtag);
            if (KeyAuthApp.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(KeyAuthApp.app_data.downloadLink))
                {
                    DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Process.Start(KeyAuthApp.app_data.downloadLink);
                            break;
                        case DialogResult.No:
                            WebClient webClient = new WebClient();
                            string destFile = Application.ExecutablePath;

                            string rand = random_string();

                            destFile = destFile.Replace(".exe", $"-{rand}.exe");
                            webClient.DownloadFile(KeyAuthApp.app_data.downloadLink, destFile);

                            Process.Start(destFile);
                            Process.Start(new ProcessStartInfo()
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });

                            break;
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void showSubMenu(Panel subMenu)
        {
            if (panelConsoleMenu.Visible == false)
            {
                hidesubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void showGames(Panel subMenu)
        {
            if (panelGames.Visible == false)
            {
                hidesubmenu();
                panelGames.Visible = true;
            }
            else
                panelGames.Visible = false;
        }

        private void PS4Panel(Panel subMenu)
        {
            if (panel1.Visible == false)
            {
                hidesubmenu();
                panel1.Visible = true;
            }
            else
                panel1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panelConsoleMenu);
            LoadTheme();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            showGames(panelGames);
            LoadTheme();

        }

        private void panelCOD_Paint(object sender, PaintEventArgs e)
        {
    
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Call_Of_Duty(), sender, V);
            LoadTheme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BO1(), sender, V);
            LoadTheme();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.WAW(), sender, V);
            LoadTheme();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BO3(), sender, V);
            LoadTheme();


        }

        private void panelGames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            PS4Panel(panel1);
            LoadTheme();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.PS4_Forms.BO3PS4(), sender, V);
            LoadTheme();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Xbox_Forms.GTAXBOX(), sender, V);
            LoadTheme();
        }
    }
}