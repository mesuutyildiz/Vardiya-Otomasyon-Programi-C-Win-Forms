using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class PersonekEkle : Form
    {
        public PersonekEkle()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();

        void VeriGetir()        //ComboBox'a Unvan Verilerini Getirme
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Unvan FROM Unvanlar", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            cmbUnvan.Items.Add(sqlDataReader.GetValue(0));
                        }

                    }
                    connection.Close();
                }
            }
        }

        int sonEklenenPersonelId = -1;

        private void btnKaydet_Click(object sender, EventArgs e) //Personel Bilgileri Girildikten Sonra Kaydet 
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtTc.Text == "" || txtAdres.Text == "" || txtTel.Text == "" || txtSicil.Text == "" || txtMail.Text == "" || txtSifre.Text == "" || cmbKadro.SelectedItem == null || cmbUnvan.SelectedItem == null)
            {
                MessageBox.Show("Boş Alanları Doldurunuz!");            //Boş değer varsa uyar
            }
            else if (cmbKadro.SelectedItem.ToString() == "Memur" && listBoxİzinGunleri.SelectedItems.Count > 2)
            {
                MessageBox.Show("Memur için maksimum 2 izin günü seçilebilir!");        //seçilen kadro Memur ve izin günü 2 den fazlaysa uyar
            }
            else if (cmbKadro.SelectedItem.ToString() == "İşçi" && listBoxİzinGunleri.SelectedItems.Count > 1)
            {
                MessageBox.Show("Işçi için maksimum 1 izin günü seçilebilir!");         //seçilen kadro işçi ve izin günü 1 den fazlaysa uyar
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Girdiğimiz Tcyi veritabanında sorgula
                {
                    using (SqlCommand komut = new SqlCommand("SELECT * FROM Personeller WHERE Tc = '" + txtTc.Text + "'", connection))
                    {
                        connection.Open();

                        using (SqlDataReader oku = komut.ExecuteReader())  //Veri tabanında Zaten Olan Personeli Kontrol Etme
                        {
                            if (oku.Read())
                            {
                                MessageBox.Show("Bu Kullanıcı Sistemde Kayıtlı!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                oku.Close();

                                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Personeller (Ad, Soyad, Tc, Adres, Telefon, Mail, Sicilno, Kadro, Unvan, Sifre) VALUES (@Ad, @Soyad, @Tc, @Adres, @Tel, @Mail, @Sicil, @Kadro, @Unvan, @Sifre)", connection))
                                {
                                    sqlCommand.Parameters.AddWithValue("@Ad", txtAd.Text);              //Girdiğimiz değerleri Sql'e Ekleme
                                    sqlCommand.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                                    sqlCommand.Parameters.AddWithValue("@Tc", txtTc.Text);
                                    sqlCommand.Parameters.AddWithValue("@Adres", txtAdres.Text);
                                    sqlCommand.Parameters.AddWithValue("@Tel", txtTel.Text);
                                    sqlCommand.Parameters.AddWithValue("@Mail", txtMail.Text);
                                    sqlCommand.Parameters.AddWithValue("@Sicil", txtSicil.Text);
                                    sqlCommand.Parameters.AddWithValue("@Kadro", cmbKadro.SelectedItem.ToString());
                                    sqlCommand.Parameters.AddWithValue("@Unvan", cmbUnvan.SelectedItem.ToString());
                                    sqlCommand.Parameters.AddWithValue("@Sifre", txtSifre.Text);

                                    sqlCommand.ExecuteNonQuery();
                                }


                                using (SqlCommand idCommand = new SqlCommand("SELECT IDENT_CURRENT('Personeller') AS SonEklenenId", connection))        //Son Eklenen Personelin İdsini Al
                                {

                                    sonEklenenPersonelId = Convert.ToInt32(idCommand.ExecuteScalar());
                                    connection.Close();
                                }

                            }


                            if (listBoxİzinGunleri.SelectedItems.Count > 0)     //İzin Günleri 0 dan fazlaysa İzin gününü veya günlerini veritabanına ekleme
                            {
                                string izinGunleri = string.Join(", ", listBoxİzinGunleri.SelectedItems.Cast<string>());

                                
                                    connection.Open();

                                    string updateQuery = "UPDATE Personeller SET IzinGunleri = COALESCE(IzinGunleri + ', ', '') + @IzinGunleri WHERE personelİd = @PersonelId";     //İzin günlerini güncelleme

                                    using (SqlCommand izinEkleKomut = new SqlCommand(updateQuery, connection))
                                    {
                                        izinEkleKomut.Parameters.AddWithValue("@PersonelId", sonEklenenPersonelId);
                                        izinEkleKomut.Parameters.AddWithValue("@IzinGunleri", izinGunleri);

                                        izinEkleKomut.ExecuteNonQuery();
                                    }

                                    connection.Close();
                                
                            }

                            MessageBox.Show("Personel eklendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void PersonekEkle_Load(object sender, EventArgs e)      //Sayfa Açıldığında Gerçekleşecekler
        {
            VeriGetir();
        }

        private void PersonekEkle_FormClosed(object sender, FormClosedEventArgs e)      //Sayfa Kapatıldığında Gerçekleşecekler
        {
            YoneticiEkran yoneticiEkran = new YoneticiEkran();
            yoneticiEkran.Show();
        }
    }
}
