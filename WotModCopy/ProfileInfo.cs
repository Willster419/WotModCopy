using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WotModCopy
{
    public partial class ProfileInfo : Form
    {
        public bool cont = false;
        public ProfileInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                if (checkForInput())
                {
                    cont = true;
                    this.Close();
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkForInput()
        {
            if ((textBox1.Text == null) || (textBox1.Text.Equals("")))
            {
                MessageBox.Show("Profile title can't be blank");
                return false;
            }
            if ((textBox2.Text == null) || (textBox2.Text.Equals("")))
            {
                textBox2.Text = "";
            }
            return true;
        }
    }
}
