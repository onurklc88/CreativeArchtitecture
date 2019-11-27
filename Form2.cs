using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creative_Artitecture
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.k_adi.ToString();
            label2.Text = Form1.soyisim.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 =new Form5();
            frm5.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           frmMyPlayer frm6 = new frmMyPlayer();
            frm6.Show();
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 frmv = new Form6();
            frmv.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 fmr8 = new Form8();
            fmr8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
        }
    }
}
