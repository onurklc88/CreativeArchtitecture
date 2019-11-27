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

namespace Creative_Artitecture
    
{
   
    public partial class Form4 : Form
{
        SqlConnection baglanti = new SqlConnection("Data Source =.; Initial Catalog = creativearti; Integrated Security = True");
        SqlCommand command;
        string imgLoc = "";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Empleyee Picture";
                if (dlg.ShowDialog()== DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picEmp.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql = "INSERT INTO Empleyee(id,FIRST_NAME,LAST_NAME,IMAGE)VALUES(" + textBoxid.Text + ",'" + textBoxFName.Text + "','" + textBoxLName.Text + "',@img)";
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
                command = new SqlCommand(sql, baglanti);
                command.Parameters.Add(new SqlParameter("@img", img));
                int x = command.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(x.ToString() + " record(s) saved.");
                textBoxid.Text = "";
                textBoxFName.Text = "";
                textBoxLName.Text = "";
                picEmp.Image = null;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT FIRST_NAME,LAST_NAME,IMAGE FROM Empleyee WHERE id="+textBoxid.Text+"";
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
                command = new SqlCommand(sql, baglanti);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    textBoxFName.Text = reader[0].ToString();
                    textBoxLName.Text = reader[1].ToString();
                    byte[] img = (byte[])(reader[2]);
                    if (img == null)
                        picEmp.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        picEmp.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    textBoxFName.Text = "";
                    textBoxLName.Text = "";
                    picEmp.Image = null;
                    MessageBox.Show("This ID does not exist.");
                }
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void picEmp_Click(object sender, EventArgs e)
        {

        }
    }
}
