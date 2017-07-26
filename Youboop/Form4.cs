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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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
            sorgu = "select*from youboop";
            kurye = new MySqlDataAdapter(sorgu, bag);
            kurye.Fill(ds);
            bs.DataSource = ds.Tables[0];
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                baglan();
            }
            catch (Exception)
            {

                MessageBox.Show("Birşeyler ters gidiyor.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length>=250)
            {
                MessageBox.Show("Mesajınızın uzunluğu 250'yi geçmemelidir.");
            }
            try
            {
                baglan();

                bag.Open();
                kmt = new MySqlCommand("insert into youboop (mesaj,eposta) values ('" + textBox1.Text + "', '"+textBox2.Text+"')", bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                baglan();
                MessageBox.Show("Gönderildi");
            }
            catch (Exception)
            {

                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
        }
    }
}
