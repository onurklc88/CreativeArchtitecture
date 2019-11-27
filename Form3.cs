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


namespace Creative_Artitecture
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\onrk\Documents\Projects\Sony vegas");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\onrk\Documents\Projects\Cinema 4d");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\onrk\Documents\Projects\Autodesk");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\onrk\Documents\Projects\After effects");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\onrk\Documents\Projects\Panaroma");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Sony\Vegas Pro 13.0\vegas130.exe");
        }
    }
}
