using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;
using VideoLibrary;

namespace Youboop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            MessageBox.Show("İndirme İşlemi Başlatıldı Lütfen Bekleyiniz...");
            
            //try
            //{
                YouTube youtube = YouTube.Default;
                Video vid = youtube.GetVideo(textBox1.Text);
                System.IO.File.WriteAllBytes(Application.StartupPath + "\\" + vid.FullName, vid.GetBytes());
                var inputfile = new MediaFile { Filename = Application.StartupPath + "\\" + vid.FullName };
                
                if (true)
                {
                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputfile);
                        MessageBox.Show("İndirme İşlemi Tamamlandı");
                            System.Diagnostics.Process.Start(Application.StartupPath);
                        
                    }
                }
            else
            {
                MessageBox.Show("İndirme Başarısız, bu link henüz Youtube'a işlenmemiş.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
    }


    }

