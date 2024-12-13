using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJE
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V9T25RC\\SQLEXPRESS;Initial Catalog = PROJE; Integrated Security = TRUE");
        public DataSet dsm = new DataSet();
        public DataSet dsp = new DataSet();

        void TemizleM()
        {
            textBox1.Clear();
            textBox4.Clear();
        }
        void TemizleP()
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        void MarkaEkle()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Furkan Altay Teknoloji");
            }
            else
            {
                baglan.Open();
                SqlCommand MarkaKaydet = new SqlCommand("INSERT INTO marka(marka_adi) values(@marka_adi)", baglan);
                MarkaKaydet.Parameters.AddWithValue("@marka_adi", textBox1.Text);
                MarkaKaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Marka kaydedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TemizleM();

            }
        }
        void MarkaSil()
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Marka id alanı dolu olmalıdır..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand MarkaSil = new SqlCommand("DELETE FROM marka WHERE id=@id", baglan);
                MarkaSil.Parameters.AddWithValue("@id", textBox4.Text);
                baglan.Open();
                MarkaSil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleM();
            }
        }
        void MarkaGuncelle()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand MarkaGuncelle = new SqlCommand("UPDATE marka SET marka_adi=@marka_adi WHERE id=@id", baglan);
                MarkaGuncelle.Parameters.AddWithValue("@marka_adi", textBox1.Text);
                MarkaGuncelle.Parameters.AddWithValue("id", textBox4.Text);
                baglan.Open();
                MarkaGuncelle.ExecuteNonQuery();
                baglan.Close();
                MarkaGetir();
                TemizleM();
                MessageBox.Show("Marka Adı Güncellenmiştir..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void MarkaGetir()
        {
            //baglan.Open();
            //da = new SqlDataAdapter("INSERT * FROM marka", baglan);
            //DataTable markatbl = new DataTable();
            //da.Fill(markatbl);
            //dataGridView1.DataSource = markatbl;
            //baglan.Close();

            dsm.Clear();
            baglan.Open();
            SqlDataAdapter dam = new SqlDataAdapter("SELECT id, marka_adi FROM marka", baglan);
            dam.Fill(dsm, "marka");
            dataGridView1.DataSource = dsm.Tables["marka"];
            baglan.Close();
        }

        void ParcaEkle()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Furkan Altay Teknoloji");
            }
            else
            {
                baglan.Open();
                SqlCommand ParcaKaydet = new SqlCommand("INSERT INTO parca1(parca_adi) values(@parca_adi)", baglan);
                ParcaKaydet.Parameters.AddWithValue("@parca_adi", textBox2.Text);
                ParcaKaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Parca kaydedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TemizleP();
            }
        }
        void ParcaSil()
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Parca id alanı dolu olmalıdır..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand ParcaSil = new SqlCommand("DELETE FROM parca1 WHERE id=@id", baglan);
                ParcaSil.Parameters.AddWithValue("@id", textBox3.Text);
                baglan.Open();
                ParcaSil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleP();
            }
        }
        void ParcaGuncelle()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand ParcaGuncelle = new SqlCommand("UPDATE parca1 SET parca_adi=@parca_adi WHERE id=@id", baglan);
                ParcaGuncelle.Parameters.AddWithValue("@parca_adi", textBox2.Text);
                ParcaGuncelle.Parameters.AddWithValue("id", textBox3.Text);
                baglan.Open();
                ParcaGuncelle.ExecuteNonQuery();
                baglan.Close();
                ParcaGetir();
                TemizleP();
                MessageBox.Show("Parça Adı Güncellenmiştir..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void ParcaGetir()
        {
            //baglan.Open();
            //da = new SqlDataAdapter("INSERT * FROM marka", baglan);
            //DataTable markatbl = new DataTable();
            //da.Fill(markatbl);
            //dataGridView1.DataSource = markatbl;
            //baglan.Close();

            dsp.Clear();
            baglan.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT id, parca_adi FROM parca1", baglan);
            dap.Fill(dsp, "parca1");
            dataGridView2.DataSource = dsp.Tables["parca1"];
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Uygulamayı kapatmaya eminmisin?", "Uygulama Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MarkaEkle();
            MarkaGetir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParcaEkle();
            ParcaGetir();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MarkaGetir();
            ParcaGetir();
            TemizleM();
            TemizleP();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            Form6 frm6 = new Form6();
            frm6.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "MARKA İD GİRİNİZ :")
            {
                textBox4.Text = "";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "PARÇA İD GİRİNİZ :")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "MARKA İD GİRİNİZ :";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "PARÇA İD GİRİNİZ :";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TemizleM();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TemizleP();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2 .CurrentRow.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MarkaSil();
            MarkaGetir();
            TemizleM();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ParcaSil();
            ParcaGetir();
            TemizleP();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ParcaGuncelle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MarkaGuncelle();
        }
    }
} 