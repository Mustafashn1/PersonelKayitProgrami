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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LC9R15P\\;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False");

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@g1 and Sifre=@g2", baglanti);
            komut.Parameters.AddWithValue("@g1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@g2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre");
            }
            baglanti.Close();


            
        }
    }
}
