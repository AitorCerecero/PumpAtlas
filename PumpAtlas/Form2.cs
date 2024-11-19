using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpAtlas
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            form1 = parentForm;
            textBox1.PasswordChar = '*';
        }

        public String password = "PumpAtlas2025";
        public bool Accessed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string user_input = textBox1.Text;

            if (user_input == password)
            {
                form1.button7.Enabled = true;
                this.Close();
                Accessed = true;
            }
            else if(user_input != password){
                MessageBox.Show("Incorrect Password, try again");
                form1.button7.Enabled = false;
                textBox1.Text = "";
            }
        }
    }
}
