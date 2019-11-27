using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Creative_Artitecture
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("onurklc08@gmail.com", "Alsifre5");
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxTo.Text);
                msg.From = new MailAddress("onurklc08@gmail.com");
                msg.Subject = textBoxSubject.Text;
                msg.Body = textBoxMsg.Text;
                client.Send(msg);
                Attachment data = new Attachment(textBoxAttachment.Text);
                msg.Attachments.Add(data);
                client.Send(msg);
                MessageBox.Show("Seccessfuly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                textBoxAttachment.Text = dlg.FileName.ToString();
            }
        }
    }
}
