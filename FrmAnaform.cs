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
namespace PersonelKayıt
{
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Adtxt.Focus();
            this.tbl_PersonelTableAdapter1.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DN5E969\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter1.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,Persehir,PerMaas,PerDurum,PerMeslek) values (@ad,@soyad,@sehir,@maas,@durum,@meslek)", baglanti);
            komut.Parameters.AddWithValue("@ad", Adtxt.Text);
            komut.Parameters.AddWithValue("@soyad", Soyadtxt.Text);
            komut.Parameters.AddWithValue("@sehir", comboBoxsehir.Text);
            komut.Parameters.AddWithValue("@maas", maskedTextBoxmaas.Text);
            komut.Parameters.AddWithValue("@meslek", meslektxt.Text);
            if (radioButtonevli.Checked)
            {
                komut.Parameters.AddWithValue("@durum", radioButtonevli.Text);

            }
            else
            {
                komut.Parameters.AddWithValue("@durum", radioButtonbekar.Text);

            }
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Idtxt.Text = "";
            Adtxt.Text = "";
            meslektxt.Text = "";
            Soyadtxt.Text = "";
            comboBoxsehir.Text = "";
            radioButtonbekar.Checked=false ;
            radioButtonevli.Checked=false;
            maskedTextBoxmaas.Text = " "; 
            Adtxt.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Idtxt.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Adtxt.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Soyadtxt.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBoxsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBoxmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "Evli ")
            {
                radioButtonevli.Checked = true ;       
            }
            else if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "Bekar")
            {
                radioButtonbekar.Checked = true ;             
            }
            meslektxt.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand personelSil = new SqlCommand("Delete From Tbl_Personel Where PerId=@personelid", baglanti); ;
            personelSil.Parameters.AddWithValue("@personelid", Idtxt.Text);
            personelSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand personelguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@ad, PerSoyad=@soyad, PerSehir=@sehir, PerMaas=@maas, PerDurum=@durum, PerMeslek=@meslek Where PerId=@id", baglanti);
            personelguncelle.Parameters.AddWithValue("@ad", Adtxt.Text);
            personelguncelle.Parameters.AddWithValue("@soyad", Soyadtxt.Text);
            personelguncelle.Parameters.AddWithValue("@sehir", comboBoxsehir.Text);
            personelguncelle.Parameters.AddWithValue("@maas", maskedTextBoxmaas.Text);
            if (radioButtonevli.Checked)
            {
                personelguncelle.Parameters.AddWithValue("@durum", radioButtonevli.Text);
            }
            else if (radioButtonbekar.Checked) 
                {
                personelguncelle.Parameters.AddWithValue("@durum", radioButtonbekar.Text);
            }
            personelguncelle.Parameters.AddWithValue("@meslek", meslektxt.Text);
            personelguncelle.Parameters.AddWithValue("@id", Idtxt.Text);
            personelguncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Personel Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            frmIstatistik fr = new frmIstatistik(); 
            fr.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frmG = new FrmGrafikler();
            frmG.Show();
        }

        private void btnyoneticiekle_Click(object sender, EventArgs e)
        {
            YoneticiEkle frm = new YoneticiEkle();
            frm.Show();

        }

        private void açıkGriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.BackgroundImage = null;
            this.BackgroundImage= pictureBoxacikgri.Image;
            groupBox1.ForeColor = Color.PaleGoldenrod;
            


        }

        private void açıkMaviToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.BackgroundImage = null;
            this.BackgroundImage = pictureBoxacikmavi.Image;
            groupBox1.ForeColor = Color.Black;

        }

        private void açıkYeşilToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.BackgroundImage = null;
             this.BackgroundImage = pictureBoxacikyesil.Image;
           
            groupBox1.ForeColor = Color.Black;

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult secim = new DialogResult();
          secim=  MessageBox.Show("Uygulamayı Kapatmak İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (secim == DialogResult.No)
            {
                MessageBox.Show("İşlem İptal Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu uygulama Bülent Baki CEYDELİOĞLU tarafında geliştirilmiştir", "Hakkımızda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Telefon:+90(555) 077 6826 \n Mail:ceydeliogluiletisim@gmail.com", "İletişim", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Uygulamayı Kapatmak İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (secim == DialogResult.No)
            {
                MessageBox.Show("İşlem İptal Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRaporlar frm = new FrmRaporlar();
            frm.Show();
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            this.BackgroundImage = pictureBoxstandart.Image;
            groupBox1.ForeColor = Color.PaleGoldenrod;


        }

        private void koyuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage=null;
            this.BackgroundImage = pictureBoxdark.Image;
            groupBox1.ForeColor = Color.PaleGoldenrod;


        }

        private void sıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idtxt.Text = "";
            Adtxt.Text = "";
            meslektxt.Text = "";
            Soyadtxt.Text = "";
            comboBoxsehir.Text = "";
            radioButtonbekar.Checked = false;
            radioButtonevli.Checked = false;
            maskedTextBoxmaas.Text = " ";
            Adtxt.Focus();
            this.BackgroundImage = null;
            this.BackgroundImage = pictureBoxstandart.Image;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
