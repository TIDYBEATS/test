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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using CMTE;
using NPOI.SS.Formula.Functions;

namespace CMTE.Forms
{
    public partial class Call_Of_Duty : Form
    {
        public Call_Of_Duty()
        {
            InitializeComponent();
            jtag.Connect(out jtag);

        }

        IXboxConsole jtag;
        XRPC XRPC = new XRPC();
        byte[] array = new byte[4];
        public uint norecoil = 2183502792u;
        private string string_0 = "0000000000";
        private string string_1 = "name";
        private string string_2 = "xuid";
        private string string_3 = "clanabbrev";



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
                button3.BackColor = ThemeColor.PrimaryColor;
                button3.ForeColor = Color.White;
                button3.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                button4.BackColor = ThemeColor.PrimaryColor;
                button4.ForeColor = Color.White;
                button4.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                button1.BackColor = ThemeColor.PrimaryColor;
                button1.ForeColor = Color.White;
                button1.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                button5.BackColor = ThemeColor.PrimaryColor;
                button5.ForeColor = Color.White;
                button5.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                button13.BackColor = ThemeColor.PrimaryColor;
                button13.ForeColor = Color.White;
                button13.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            label1.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
            label3.ForeColor = ThemeColor.PrimaryColor;
            label4.ForeColor = ThemeColor.PrimaryColor;

        }


        private void Call_Of_Duty_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            jtag.WriteByte(2183093119u, 1);
            jtag.XNotify("Red Boxes On");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            jtag.WriteByte(2183093119u, 0);
            jtag.XNotify("Red Boxes Off");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            JRPC.WriteString(jtag, 2181054320U, textBox1.Text);
            JRPC.WriteBool(jtag, 2210767803U, true);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            jtag.WriteByte(0x82259bc8, 1);
            // no recoil on (not working)

        }
        private void button5_Click(object sender, EventArgs e)
        {
            jtag.WriteByte(0x821c5567, 1);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            byte[] data11 = { 0x84, 0x00, 0x08, 0x00 };
            jtag.SetMemory(0x832A8A2C, data11);
            jtag.SetMemory(0x84000800, Encoding.ASCII.GetBytes(textBox2.Text + "\0"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] data20 = { 0x84, 0x00, 0x08, 0x00 };
            jtag.SetMemory(0x832A896C, data20);
            jtag.SetMemory(0x84000800, Encoding.ASCII.GetBytes(textBox3.Text + "\0"));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] data1 = { 0x84, 0x00, 0x00, 0x00 };
            jtag.SetMemory(0x832b50fc, data1);
            jtag.SetMemory(0x84000000, Encoding.ASCII.GetBytes("" + textBox4.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            jtag.WriteByte(0x821c5567, 0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            jtag.SetMemory(0x82255e1c, new byte[] { 0x2b, 11, 0, 1 });

        }

        private void button6_Click(object sender, EventArgs e)
        {
            jtag.WriteByte(0x824015e0, 1);
        }
        public static uint uint_9 = uint_0;
        public static uint uint_0;
        public uint BO2CMD = 2185237984U;

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(this.jtag, this.BO2CMD, new object[]
            {
                0,
                "party_connecttoOthers 00; partyMigrate_disabled 01; sv_endgameIfISuck 0; badhost_endgameifisuck 0; set party_gamestarttimelength 2; set party_pregamestarttimerlength 2; set party_timer 25"
            });
            MessageBox.Show("Force Host On");
        }

        private byte[] byte_15;

        public static Form code;
        private void method_58()
        {
            JRPC.CallVoid(jtag, uint_0, new object[]
            {
                0,
                "setPublicMatchClassSetNameFromLocString 0 \"^11337 ^2Hax\""
            });
            JRPC.CallVoid(jtag, uint_0, new object[]
            {
                0,
                "uploadstats; updategamerprofile"
            });
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Code bo2ac;
            JRPC.SetMemory(this.jtag, 2218082975U, this.byte_15);
            JRPC.SetMemory(this.jtag, 2218083244U, new byte[]
                    {
                byte.MaxValue
        });
            JRPC.SetMemory(this.jtag, 2218083241U, new byte[]
            {
                byte.MaxValue
            });
            this.method_58();
        }
    }


}