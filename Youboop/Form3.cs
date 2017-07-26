using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Youboop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOUBOOP, Youtube.com üzerinden seçtiğiniz video veya müzik linklerine göre indirmeler yapıp size ücretsiz bir imkan sağlayak programdır.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        MySqlConnection bag = new MySqlConnection("Server=176.53.65.71;Database=bavagirc_program;Uid=bavagirc_program;Pwd=123456789a;");
        MySqlDataAdapter kurye;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        MySqlCommand kmt;
        void baglan()
        {
            ds.Clear();
            string sorgu;
            sorgu = "select*from guncelleme";
            kurye = new MySqlDataAdapter(sorgu, bag);
            kurye.Fill(ds);
            bs.DataSource = ds.Tables[0];
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                baglan();
                label2.DataBindings.Add("text", bs, "guncelleme");
                if (label2.Text == "var")
                {
                    Application.Exit();
                    MessageBox.Show("Programın yeni güncellenmiş verisyonu gelmiştir. Yeni verisyonu Karakuş Bilişim Facebook sayfasına girerek yapabilirsiniz. Facebook Adresi: www.facebook.com/karakusbilisimcom");
                    System.Diagnostics.Process.Start("http://www.facebook.com/karakusbilisimcom");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("İnternete bağlı değilsiniz veya sunucudan cevap alınamıyor. İletişime yönlendiriliyorsunuz.");
                System.Diagnostics.Process.Start("http://www.facebook.com/karakusbilisimcom");
            }
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
