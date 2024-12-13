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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace PROJE
{
    public partial class Form5 : Form
    {
        public SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V9T25RC\\SQLEXPRESS;Initial Catalog = PROJE; Integrated Security = TRUE");
        public DataSet ds = new DataSet();
        public Form5()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        void MüsteriEkle()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Furkan Altay Teknoloji");
            }
            else
            {
                baglan.Open();
                SqlCommand MüsteriKaydet = new SqlCommand("INSERT INTO müsteri1(müsteri_adi, müsteri_soyadi, tel) values(@müsteri_adi,  @müsteri_soyadi, @tel)", baglan);
                MüsteriKaydet.Parameters.AddWithValue("@müsteri_adi", textBox1.Text);
                MüsteriKaydet.Parameters.AddWithValue("@müsteri_soyadi", textBox2.Text);
                MüsteriKaydet.Parameters.AddWithValue("@tel", textBox3.Text);
                MüsteriKaydet.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Müsteri kaydedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Temizle();
            }
        }
        void MüsteriSil()
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Müşteri id alanı dolu olmalıdır..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand MüsteriSil = new SqlCommand("DELETE FROM müsteri1 WHERE müsteri_id=@müsteri_id", baglan);
                MüsteriSil.Parameters.AddWithValue("@müsteri_id", textBox4.Text);
                baglan.Open();
                MüsteriSil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
        }
        void MüsteriGuncelle()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand MüsteriGuncelle = new SqlCommand("UPDATE müsteri1 SET müsteri_adi=@müsteri_adi, müsteri_soyadi=@müsteri_soyadi, tel=@tel WHERE müsteri_id=@müsteri_id", baglan);
                MüsteriGuncelle.Parameters.AddWithValue("@müsteri_id", textBox4.Text);
                MüsteriGuncelle.Parameters.AddWithValue("@müsteri_adi", textBox1.Text);
                MüsteriGuncelle.Parameters.AddWithValue("@müsteri_soyadi", textBox2.Text);
                MüsteriGuncelle.Parameters.AddWithValue("@tel", textBox3.Text);
                baglan.Open();
                MüsteriGuncelle.ExecuteNonQuery();
                baglan.Close();
                MüsteriGetir();
                Temizle();
                MessageBox.Show("Müşteri Güncellenmiştir..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void MüsteriGetir()
        {
            //baglan.Open();
            //da = new SqlDataAdapter("INSERT * FROM marka", baglan);
            //DataTable markatbl = new DataTable();
            //da.Fill(markatbl);
            //dataGridView1.DataSource = markatbl;
            //baglan.Close();

            ds.Clear();
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT müsteri_id, müsteri_adi, müsteri_soyadi, tel FROM müsteri1", baglan);
            da.Fill(ds, "müsteri1");
            dataGridView1.DataSource = ds.Tables["müsteri1"];
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

        private void button2_Click(object sender, EventArgs e)
        {
            MüsteriEkle();
            MüsteriGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MüsteriGetir();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MüsteriSil();
            MüsteriGetir();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "MÜŞTERİ İD GİRİNİZ :")
            {
                textBox4.Text = "";
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MüsteriGuncelle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
