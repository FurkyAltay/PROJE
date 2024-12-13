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

namespace PROJE
{
    public partial class Form7 : Form
    {
        public SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V9T25RC\\SQLEXPRESS;Initial Catalog = PROJE; Integrated Security = TRUE");
        public DataSet dsm = new DataSet();
        public DataSet dsar = new DataSet();
        public Form7()
        {
            InitializeComponent();
        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
        }
        void MüsteriGetir()
        {
            dsm.Clear();
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT müsteri_adi, müsteri_soyadi, tel FROM müsteri1", baglan);
            da.Fill(dsm, "müsteri1");
            dataGridView1.DataSource = dsm.Tables["müsteri1"];
            baglan.Close();
        }
        void ArızaGetir()
        {
            dsar.Clear();
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT id, " +
                "müsteri_adi, müsteri_soyadi, tel, marka_adi, parca_adi  FROM arıza", baglan);
            da.Fill(dsar, "arıza");
            dataGridView2.DataSource = dsar.Tables["arıza"];
            baglan.Close();
        }
        void MarkaCombo()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM marka", baglan);
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["marka_adi"]);
            }
            baglan.Close();
        }
        void ParcaCombo()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM parca1", baglan);
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["parca_adi"]);
            }
            baglan.Close();
        }
        void ArızaEkle()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Boş Alan bırakmayınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                baglan.Open();
                SqlCommand ArızaKaydet = new SqlCommand("INSERT INTO arıza(müsteri_adi, müsteri_soyadi, tel, marka_adi, parca_adi) values(@ad, @soyad, @tel, @marka, @parca)", baglan);
                ArızaKaydet.Parameters.AddWithValue("@ad", textBox1.Text);
                ArızaKaydet.Parameters.AddWithValue("@soyad", textBox2.Text);
                ArızaKaydet.Parameters.AddWithValue("@tel", textBox3.Text);
                ArızaKaydet.Parameters.AddWithValue("@marka", comboBox1.Text);
                ArızaKaydet.Parameters.AddWithValue("@parca", comboBox2.Text);
                ArızaKaydet.ExecuteNonQuery();
                dsar.Clear();
                baglan.Close();
                Temizle();
                MessageBox.Show("Arıza kaydedildi..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void ArızaSil()
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Arıza id alanı dolu olmalıdır..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand ArızaSil = new SqlCommand("DELETE FROM arıza WHERE id=@id", baglan);
                ArızaSil.Parameters.AddWithValue("@id", textBox4.Text);
                baglan.Open();
                ArızaSil.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kayıt Silindi..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
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

        private void Form7_Load(object sender, EventArgs e)
        {
            MüsteriGetir();
            ArızaGetir();
            MarkaCombo();
            ParcaCombo();
            Temizle();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Müşteri Adı")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Müşteri Adı";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Müşteri Soyadı")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Müşteri Soyadı";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Tel")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Tel";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArızaEkle();
            ArızaGetir();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArızaSil();
            ArızaGetir();
        }
    }
}
