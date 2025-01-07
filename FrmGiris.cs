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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DN5E969\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand yonetici = new SqlCommand("Select * from Tbl_YoneticiGiris where KullaniciAdi=@kullanici and Sifre=@sifre ", baglanti);
            yonetici.Parameters.AddWithValue("@kullanici", kullaniciaditxt.Text);
            yonetici.Parameters.AddWithValue("@sifre", sifretxt.Text);
            SqlDataReader okuyucu = yonetici.ExecuteReader();
            if (okuyucu.Read())
            {
                FrmAnaform frm = new FrmAnaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }

            baglanti.Close();
        }

        
    }
}
