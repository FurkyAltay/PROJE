using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJE
{
    public partial class Form3 : Form
    {
        public SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V9T25RC\\SQLEXPRESS;Initial Catalog = PROJE; Integrated Security = TRUE");
        public DataSet ds = new DataSet();
        public Form3()
        {
            InitializeComponent();
        }

        void KullaniciEkle()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Furkan Altay Teknoloji");
            }
            else
            {
                baglan.Open();
                SqlCommand KullaniciKaydet = new SqlCommand("INSERT INTO kullanici(k_adi, sifre, re_sifre, e_mail) values(@k_adi, @sifre, @re_sifre, @e_mail)", baglan);
                KullaniciKaydet.Parameters.AddWithValue("@k_adi", textBox1.Text);
                KullaniciKaydet.Parameters.AddWithValue("@sifre", textBox2.Text);
                KullaniciKaydet.Parameters.AddWithValue("@re_sifre", textBox3.Text);
                KullaniciKaydet.Parameters.AddWithValue("@e_mail", textBox4.Text);
                KullaniciKaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kullanıcı kaydedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Sifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Sifre";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Sifre")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }       

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Sifre";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "E-Mail")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "E-Mail";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciEkle();
        }
    }
}
