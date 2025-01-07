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
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DN5E969\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel", baglanti);
            SqlDataReader okuyucu1 = komut1.ExecuteReader();
            while (okuyucu1.Read())
            {
                pertotallbl.Text = okuyucu1[0].ToString();
            }
            baglanti.Close();

            
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum = 'Evli' ",baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while(okuyucu2.Read())
            {
                perevlilbl.Text = okuyucu2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum = 'Bekar' ", baglanti);
            SqlDataReader okuyucu3 = komut3.ExecuteReader();
            while (okuyucu3.Read())
            {
                perbekarlbl.Text = okuyucu3[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) from Tbl_Personel ", baglanti);
            SqlDataReader okuyucu4 = komut4.ExecuteReader();
            while (okuyucu4.Read())
            {
                totalsehirlbl.Text = okuyucu4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel  ", baglanti);
            SqlDataReader okuyucu5 = komut5.ExecuteReader();
            while (okuyucu5.Read())
            {
                totalmaaslbl.Text = okuyucu5[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from Tbl_Personel  ", baglanti);
            SqlDataReader okuyucu6 = komut6.ExecuteReader();
            while (okuyucu6.Read())
            {
                ortmaaslbl.Text = okuyucu6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
