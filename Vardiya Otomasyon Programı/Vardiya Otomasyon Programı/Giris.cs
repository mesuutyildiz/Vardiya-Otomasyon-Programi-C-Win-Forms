using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vardiya_Otomasyon_Programı.Program;

namespace Vardiya_Otomasyon_Programı
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();

        private void btnGiris_Click(object sender, EventArgs e)   //Personel ve Admin kullanıcı adı parola kontrolü
        {
            if (txtKulAd.Text == "" || txtParola.Text == "")    //Boş İşe Hata ver
            {
                MessageBox.Show("Boş Alanları Doldurunuz!");
            }
            else if (txtKulAd.Text == "admin" && txtParola.Text == "admin")     //doğruysa Yönetici Paneline aktar
            {
                YoneticiEkran yoneticiEkran = new YoneticiEkran();
                yoneticiEkran.Show();
                this.Hide();
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(bgl.Adres)) 
                    {
                        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Personeller WHERE Tc = @Tc and Sifre = @Sifre ", connection);
                        sqlCommand.Parameters.AddWithValue("@Tc", txtKulAd.Text);
                        sqlCommand.Parameters.AddWithValue("@Sifre", txtParola.Text);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();

                        sqlDataAdapter.Fill(dataTable);


                        if (dataTable.Rows.Count > 0)       //Girilen Tc İle Şifre Doğruysa Kullanıcı Paneline Yönlendir
                        {
                            MessageBox.Show("Giriş Başarılı");
                            string tc = txtKulAd.Text;
                            KullanıcıEkran kullanıcıEkran = new KullanıcıEkran(tc);
                            kullanıcıEkran.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tc Veya Şifre Yanlış!");
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void Giris_KeyPress(object sender, KeyPressEventArgs e) //Enter Tuşuna Basıldığında Giriş Tuşuna bas
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGiris.PerformClick();
                e.Handled = true;
            }
        }
    }
}
