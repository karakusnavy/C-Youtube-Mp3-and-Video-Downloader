using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youboop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //indirmek için tıklayınız
            int i = 0;
            foreach (HtmlElement _a in webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (_a.InnerText == "Download")
                {
                    i++;
                }
                if (i == 3)
                {
                    try
                    {
                        _a.Focus();
                        _a.InvokeMember("click");
                        MessageBox.Show("İndirme Başarılı");
                        button1.Visible = false;
                        button2.Visible = true;

                        webBrowser1.Navigate("http://youtube-mp3.org");
                        button1.Visible = true;
                        button2.Visible = false;
                        textBox1.Clear();
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu link bakımda");
                        
                    }
                    

                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string link;
                link = textBox1.Text;
                webBrowser1.Document.GetElementById("youtube-url").InnerText = link;
                webBrowser1.Document.GetElementById("submit").InvokeMember("Click");
                button1.Visible = false;
                button2.Visible = true;
                if (textBox1.Text.Length >= 50)
                {
                    MessageBox.Show("Geçersiz Link");
                    textBox1.Clear();
                }
            }
            catch (Exception)
            {
                Application.Exit();
                MessageBox.Show("Çok hızlı davrandınız veya sunucuya bağlanırken hata oluştu! Önemsemeyiniz programı yeniden açınız.");

            }

           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://youtube-mp3.org");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string link;
            //    link = textBox1.Text;
            //    webBrowser1.Document.GetElementById("youtube-url").InnerText = link;
            //    webBrowser1.Document.GetElementById("submit").InvokeMember("Click");

            //    if (textBox1.Text.Length >= 50)
            //    {
            //        MessageBox.Show("Geçersiz Link");
            //        textBox1.Clear();
            //    }
            //}
            //catch (Exception)
            //{
            //    Application.Exit();
            //    MessageBox.Show("Çok hızlı davrandınız veya sunucuya bağlanırken hata oluştu! Önemsemeyiniz programı yeniden açınız.");

            //}
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
