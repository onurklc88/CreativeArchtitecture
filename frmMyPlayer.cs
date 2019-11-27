
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
using System.Diagnostics;
using System.IO;
using System.Globalization;
using ICSharpCode.SharpZipLib.Zip;

namespace Creative_Artitecture
{
    public partial class frmMyPlayer : Form
    {
        private object path;


        public frmMyPlayer()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            get { return "Data Source =.; Initial Catalog = creativearti; Integrated Security = True"; }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var file = GetFile();
            var lst = new string[] { ".mov" };
            if (!lst.Contains(Path.GetExtension(file)))
            { MessageBox.Show("Please select proper file."); }
            else
            {
                var result = SaveToDataBase(Path.GetFileName(file), GetCompressedData(file, ConvertFileToByteData(file)));
                if (result)
                {
                    comboBox1.Items.Add(Path.GetFileName(file));
                    MessageBox.Show("File Saved Successfully");
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) { MessageBox.Show("Please select file to play."); return; }
            axQTControl1.URL = GetFromDataBase(comboBox1.SelectedItem.ToString()).ToString();
            axQTControl1.AutoPlay = "true";
        }

        private void frmMyPlayer_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(ConnectionString);

            String Query1 = "SELECT FileName FROM  [dbo].[MyPlay]";

            SqlDataAdapter adapter = new SqlDataAdapter(Query1, ConnectionString);

            DataSet Ds = new DataSet();

            adapter.Fill(Ds, "MyPlay");

            if (Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No data Found");
            }
            else
            {
                foreach (DataRow item in Ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(item["FileName"]);
                }
            }
        }

        private void cmbPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmMyPlayer_Resize(object sender, EventArgs e)
        {
            axQTControl1.Height = ((Form)sender).Size.Height - 615;
            axQTControl1.Width = ((Form)sender).Size.Width - 1300;
        }

        private void frmMyPlayer_MaximumSizeChanged(object sender, EventArgs e)
        {
            axQTControl1.Height = ((Form)sender).Size.Height - 615;
            axQTControl1.Width = ((Form)sender).Size.Width - 1300;
        }

        private void frmMyPlayer_MinimumSizeChanged(object sender, EventArgs e)
        {
            axQTControl1.Height = ((Form)sender).Size.Height - 615;
            axQTControl1.Width = ((Form)sender).Size.Width - 1300;
        }

        private void frmMyPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private string GetFile()
        {
            try
            {
                OpenFileDialog ofdPlayer = new OpenFileDialog();

                ofdPlayer.Filter = "Solution Files (*.*)|*.*";
                //ofdPlayer.InitialDirectory = @"E:\\";
                ofdPlayer.Multiselect = true;
                if (ofdPlayer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return ofdPlayer.FileName;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return string.Empty;
        }

        private bool SaveToDataBase(string fileName, byte[] data)
        {
            try
            {
                var ds = new DataSet();
                SqlCommand cmd = new SqlCommand("insert into MyPlay values('" + Guid.NewGuid() + "','" + fileName + "',@content)");
                SqlParameter param = cmd.Parameters.Add("@content", SqlDbType.VarBinary);
                param.Value = data;
                cmd.Connection = new SqlConnection(ConnectionString);
                cmd.CommandTimeout = 0;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw;
                return false;
            }
        }

        private string GetFromDataBase(string fileName)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConnectionString);
                String Query1 = "SELECT FileData FROM [dbo].[MyPlay] where FileName = '" + fileName + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(Query1, ConnectionString);
                DataSet Ds = new DataSet();
                adapter.Fill(Ds, "MyPlay");
                if (Ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No data Found");
                    return string.Empty;
                }
                return ConvertByteDataToFile(fileName, GetUnCompressedData((byte[])Ds.Tables[0].Rows[0]["FileData"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return string.Empty;
        }

        private string ConvertByteDataToFile(string targetFileName, byte[] value)
        {
            
            var str = string.Empty;
            try
            {
                try
                {
                    var path = Path.GetTempPath();
                    str = path + targetFileName;
                    if (File.Exists(str))
                        File.Delete(str);
                }
                catch (Exception ex) { }

                var file = (new BinaryWriter(new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write)));
                file.Write(value);
                file.Close();
                return str;
            }
            catch (Exception) { }
            // ReSharper restore EmptyGeneralCatchClause
            return string.Empty;
        }

        private static byte[] ConvertFileToByteData(string sourceFileName)
        {
            BinaryReader binaryReader = null;
            if (!File.Exists(sourceFileName))
                return null;

            try
            {
                binaryReader = new BinaryReader(new FileStream(sourceFileName, FileMode.Open, FileAccess.Read));
                return binaryReader.ReadBytes(ConvertToInt32(binaryReader.BaseStream.Length));
            }
            finally
            {
                if (null != binaryReader) binaryReader.Close();
            }
        }

        public static int ConvertToInt32(object parameter)
        {
            var returnvalue = Int32.MinValue;

            
            try
            {
                if (null != parameter)
                    returnvalue = Convert.ToInt32(parameter, CultureInfo.InvariantCulture);
            }
            catch
            {
                return returnvalue;
            }

            return returnvalue;
        }

        public static byte[] GetCompressedData(string fileName, byte[] value)
        {
            try
            {
                
                if (value != null && !string.IsNullOrEmpty(fileName))
                    using (var zippedMemoryStream = new MemoryStream())
                    {
                       
                        using (var zipOutputStream = new ZipOutputStream(zippedMemoryStream))
                        {
                            
                            zipOutputStream.SetLevel(9);

                            var entry = new ZipEntry(fileName) { DateTime = DateTime.Now };
                            zipOutputStream.PutNextEntry(entry);

                            zipOutputStream.Write(value, 0, ConvertToInt32(value.Length));

                            zipOutputStream.Finish();
                            zipOutputStream.Close();

                            return zippedMemoryStream.ToArray();
                        }
                    }
            }
            catch (Exception ex)
            {
                return value;
            }

            return null;
        }

        public static byte[] GetUnCompressedData(byte[] value)
        {
            try
            {
                if (value != null)
                    using (var zipInputStream = new ZipInputStream(new MemoryStream(value)))
                    {
                    while ((zipInputStream.GetNextEntry()) != null)
                    {
                        using (var zippedInMemoryStream = new MemoryStream())
                        {
                            var data = new byte[2048];
                            while (true)
                            {
                                var size = zipInputStream.Read(data, 0, data.Length);
                                if (size <= 0)
                                    break;

                                zippedInMemoryStream.Write(data, 0, size);
                            }
                            zippedInMemoryStream.Close();

                            return zippedInMemoryStream.ToArray();
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return value;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void frmMyPlayer_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            SqlConnection baglanti = new SqlConnection(ConnectionString);

            String Query1 = "SELECT FileName FROM [dbo].[MyPlay]";

            SqlDataAdapter adapter = new SqlDataAdapter(Query1, ConnectionString);

            DataSet Ds = new DataSet();

            adapter.Fill(Ds, "MyPlay");

            if (Ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No data Found");
            }
            else
            {
                foreach (DataRow item in Ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(item["FileName"]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axQTControl1.URL = GetFile();
            axQTControl1.AutoPlay = "true";
        }
    }
}


