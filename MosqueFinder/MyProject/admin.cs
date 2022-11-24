using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace MyProject
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            //adminControlerOne1.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sideNav.Height = button1.Height;
            sideNav.Top = button1.Top;
            adminControlerOne2.Visible = true;
            adminControlerTwo2.Visible = false;
            adminControlerThree2.Visible = false;
            adminControlerFour2.Visible = false;
            adminControlerFive2.Visible = false;
            adminControlerSix2.Visible = false;
            adminControlerSeven2.Visible = false;
            adminControlerEight2.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sideNav.Height = button9.Height;
            sideNav.Top = button9.Top;
            adminControlerOne2.Visible = false;
            adminControlerTwo2.Visible = true;
            adminControlerThree2.Visible = false;
            adminControlerFour2.Visible = false;
            adminControlerFive2.Visible = false;
            adminControlerSix2.Visible = false;
            adminControlerSeven2.Visible = false;
            adminControlerEight2.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sideNav.Height = button2.Height;
            sideNav.Top = button2.Top;
            adminControlerOne2.Visible = false;
            adminControlerTwo2.Visible = false;
            adminControlerThree2.Visible = true;
            adminControlerFour2.Visible = false;
            adminControlerFive2.Visible = false;
            adminControlerSix2.Visible = false;
            adminControlerSeven2.Visible = false;
            adminControlerEight2.Visible = false;
        }
            private void button4_Click(object sender, EventArgs e)
        {
            sideNav.Height = button4.Height;
            sideNav.Top = button4.Top;
                adminControlerOne2.Visible = false;
                adminControlerTwo2.Visible = false;
                adminControlerThree2.Visible = false;
                adminControlerFour2.Visible = true;
                adminControlerFive2.Visible = false;
                adminControlerSix2.Visible = false;
                adminControlerSeven2.Visible = false;
                adminControlerEight2.Visible = false;
            }

        private void button7_Click(object sender, EventArgs e)
        {
            sideNav.Height = button7.Height;
            sideNav.Top = button7.Top;
                adminControlerOne2.Visible = false;
                adminControlerTwo2.Visible = false;
                adminControlerThree2.Visible = false;
                adminControlerFour2.Visible = false;
                adminControlerFive2.Visible = true;
                adminControlerSix2.Visible = false;
                adminControlerSeven2.Visible = false;
                adminControlerEight2.Visible = false;
            }

        private void button6_Click(object sender, EventArgs e)
        {
            sideNav.Height = button6.Height;
            sideNav.Top = button6.Top;
                adminControlerOne2.Visible = false;
                adminControlerTwo2.Visible = false;
                adminControlerThree2.Visible = false;
                adminControlerFour2.Visible = false;
                adminControlerFive2.Visible = false;
                adminControlerSix2.Visible = true;
                adminControlerSeven2.Visible = false;
                adminControlerEight2.Visible = false;
            }

        private void button5_Click(object sender, EventArgs e)
        {
            sideNav.Height = button5.Height;
            sideNav.Top = button5.Top;
                adminControlerOne2.Visible = false;
                adminControlerTwo2.Visible = false;
                adminControlerThree2.Visible = false;
                adminControlerFour2.Visible = false;
                adminControlerFive2.Visible = false;
                adminControlerSix2.Visible = false;
                adminControlerSeven2.Visible = true;
                adminControlerEight2.Visible = false;
            }

        private void button3_Click(object sender, EventArgs e)
        {
            sideNav.Height = button3.Height;
            sideNav.Top = button3.Top;
                adminControlerOne2.Visible = false;
                adminControlerTwo2.Visible = false;
                adminControlerThree2.Visible = false;
                adminControlerFour2.Visible = false;
                adminControlerFive2.Visible = false;
                adminControlerSix2.Visible = false;
                adminControlerSeven2.Visible = false;
                adminControlerEight2.Visible = true;
            } 

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                sign_in s = new sign_in();
                this.Hide();
                s.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }

        }

        private void admin_Load(object sender, EventArgs e)
        {
            
            adminControlerOne2.Visible = false;
            
            adminControlerTwo2.Visible = false;
            adminControlerThree2.Visible = false;
            adminControlerFour2.Visible = false;
            adminControlerFive2.Visible = false;
            adminControlerSix2.Visible = false;
            adminControlerSeven2.Visible = false;
            adminControlerEight2.Visible = false;
            

            
        }
    }
}
