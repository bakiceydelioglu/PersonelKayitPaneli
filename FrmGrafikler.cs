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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DN5E969\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand grafik1 = new SqlCommand("Select Persehir,count(*) from Tbl_Personel Group by Persehir", baglanti);
            SqlDataReader okuyucu1 = grafik1.ExecuteReader();
            while (okuyucu1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(okuyucu1[0], okuyucu1[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand grafik2 = new SqlCommand("Select Permeslek,avg(PerMaas) from Tbl_Personel Group by Permeslek", baglanti);
            SqlDataReader okuyucu2 = grafik2.ExecuteReader();
            while (okuyucu2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(okuyucu2[0], okuyucu2[1]);
            }
            baglanti.Close();


        }

      
    }
}
