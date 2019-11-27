using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
namespace Creative_Artitecture

{
    public partial class Form6 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source =.; Initial Catalog = creativearti; Integrated Security = True");

        SqlCommand command;

        SqlDataAdapter da;
        string imgLoc = "";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PictureBox picEml = new PictureBox();
            picEml.ImageLocation = imgLoc;
            label7.Text = Form1.k_adi.ToString();
            label8.Text = Form1.soyisim.ToString();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id=" + textBoxid.Text + "";
            command = new SqlCommand(selectQuery, baglanti);
            da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            textBoxFName.Text = table.Rows[0].ToString();
            textBoxLName.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][2];
            MemoryStream ms = new MemoryStream(img);
            picEml.Image = Image.FromStream(ms);
            da.Dispose();







        }
           











   

        private void picEml_Click(object sender, EventArgs e)
        {

        }
        int a = 0, b = 0, c = 0, d = 0, q = 0, toplam = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id=" + textBox1.Text + "";
            command = new SqlCommand(selectQuery, baglanti);
            da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            textBox2.Text = table.Rows[0].ToString();
            textBox3.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][2];
            MemoryStream ms = new MemoryStream(img);
            picEml.Image = Image.FromStream(ms);
            da.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id=" + textBox4.Text + "";
            command = new SqlCommand(selectQuery, baglanti);
            da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            textBox7.Text = table.Rows[0].ToString();
            textBox10.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][2];
            MemoryStream ms = new MemoryStream(img);
            picEml.Image = Image.FromStream(ms);
            da.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id=" + textBox5.Text + "";
            command = new SqlCommand(selectQuery, baglanti);
            da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            textBox8.Text = table.Rows[0].ToString();
            textBox11.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][2];
            MemoryStream ms = new MemoryStream(img);
            picEml.Image = Image.FromStream(ms);
            da.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id=" + textBox6.Text + "";
            command = new SqlCommand(selectQuery, baglanti);
            da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            textBox9.Text = table.Rows[0].ToString();
            textBox12.Text = table.Rows[0][2].ToString();
            byte[] img = (byte[])table.Rows[0][2];
            MemoryStream ms = new MemoryStream(img);
            picEml.Image = Image.FromStream(ms);
            da.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
           

            q++;
            toplam++;
            progressBar1.Value = (a * 100) / toplam;
            progressBar2.Value = (b * 100) / toplam;
            progressBar3.Value = (c * 100) / toplam;
            progressBar4.Value = (d * 100) / toplam;
            progressBar5.Value = (q * 100) / toplam;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            d++;
            toplam++;
            progressBar1.Value = (a * 100) / toplam;
            progressBar2.Value = (b * 100) / toplam;
            progressBar3.Value = (c * 100) / toplam;
            progressBar4.Value = (d * 100) / toplam;
            progressBar5.Value = (q * 100) / toplam;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c++;
            toplam++;
            progressBar1.Value = (a * 100) / toplam;
            progressBar2.Value = (b * 100) / toplam;
            progressBar3.Value = (c * 100) / toplam;
            progressBar4.Value = (d * 100) / toplam;
            progressBar5.Value = (q * 100) / toplam;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b++;
            toplam++;
            progressBar1.Value = (a * 100) / toplam;
            progressBar2.Value = (b * 100) / toplam;
            progressBar3.Value = (c * 100) / toplam;
            progressBar4.Value = (d * 100) / toplam;
            progressBar5.Value = (q * 100) / toplam;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a++;
            toplam++;
            progressBar1.Value = (a * 100) / toplam;
            progressBar2.Value = (b * 100) / toplam;
            progressBar3.Value = (c * 100) / toplam;
            progressBar4.Value = (d * 100) / toplam;
            progressBar5.Value = (q * 100) / toplam;
            
        }
    }

    internal class MemoryStream1
    {
        private object img;

        public MemoryStream1(object img)
        {
            this.img = img;
        }
    }
}

