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

namespace PROJE
{
    public partial class Form1 : Form
    {
        public SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V9T25RC\\SQLEXPRESS;Initial Catalog = PROJE; Integrated Security = TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor= Color.Black;
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
        
        Form4 frm4 = new Form4();

        bool isThere;
        private void button2_Click(object sender, EventArgs e)
        {
            string k_adi = textBox1.Text;
            string sifre = textBox2.Text;

            baglan.Open();
            SqlCommand command = new SqlCommand("Select * from kullanici", baglan);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                if (k_adi == reader["k_adi"].ToString().TrimEnd() && sifre == reader["sifre"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }        

                else 
                {
                    isThere = false;
                }
            }

            baglan.Close();

            if (isThere) 
            {
                MessageBox.Show("Başarıyla Giriş Yaptınız.", "Furkan Altay Teknoloji");
                Form4 frm4 = new Form4();
                frm4.Show();
            }

            else 
            {
                MessageBox.Show("Giriş Yapamadınız!", "Furkan Altay Teknoloji");
            }

            textBox1.Clear();
            textBox2.Clear();
        }

        Form3 frm3 = new Form3();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm3.Show();
        }
    }
}
