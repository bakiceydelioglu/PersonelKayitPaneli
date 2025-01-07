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
    public partial class YoneticiEkle : Form
    {
        public YoneticiEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DN5E969\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (sifretxt.Text == sifretekrartxt.Text)
            {
                baglanti.Open();
                SqlCommand yonetici = new SqlCommand("insert into Tbl_YoneticiGiris(KullaniciAdi,Sifre) values (@kullaniciadi,@sifre)", baglanti);
                yonetici.Parameters.AddWithValue("@kullaniciadi", kullaniciaditxt.Text);
                yonetici.Parameters.AddWithValue("@sifre", sifretxt.Text);
                yonetici.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Yönetici Başarıyla Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmuyor Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
            }

        }
    }
}
