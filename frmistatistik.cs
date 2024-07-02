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

namespace personel_kayıt_programı
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LC9R15P\\;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False");


        private void frmistatistik_Load(object sender, EventArgs e)
        {

            // Toplam Personel Sayısı
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader rd1 = komut1.ExecuteReader();
            while (rd1.Read())
            {
                lblToplamPersonel.Text = rd1[0].ToString();

            }
            baglanti.Close();

            // Evli Personel Sayısı

            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader rd2 = komut2.ExecuteReader();
            while (rd2.Read())
            {
                LblEvliPersonel.Text = rd2[0].ToString();
            }

            baglanti.Close();

            // Bekar Personel Sayısı

            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader rd3 = komut3.ExecuteReader();
            while (rd3.Read())
            {
                LblBekarPersonel.Text = rd3[0].ToString();
            }


            baglanti.Close();

            // Şehir Sayısı 

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select Count(Distinct(PerSehir)) from Tbl_Personel", baglanti);
            SqlDataReader rd4 = komut4.ExecuteReader();
            while (rd4.Read())
            {
                LblFarklıSehir.Text = rd4[0].ToString();
            }


            baglanti.Close();



            // Personelin Toplam Maaşı
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader rd5 = komut5.ExecuteReader();
            while (rd5.Read())
            {
                LblToplamMaas.Text = rd5[0].ToString();
            }
            baglanti.Close();


            // Personel Ortama Maaş

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select Avg(PerMaas) from Tbl_Personel",baglanti);
            SqlDataReader rd6 = komut6.ExecuteReader();
            while (rd6.Read())
            {
                LblOrtalamaMaas.Text = rd6[0].ToString();
            }


            baglanti.Close();




        }


    }
}
