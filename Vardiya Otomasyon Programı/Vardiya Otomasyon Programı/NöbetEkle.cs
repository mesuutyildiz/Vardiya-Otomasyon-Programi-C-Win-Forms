using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vardiya_Otomasyon_Programı.Program;

namespace Vardiya_Otomasyon_Programı
{
    public partial class NöbetEkle : Form
    {
        public NöbetEkle()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();


        void VeriGetir()        //Güncellenen Verileri Getiren Method
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Personelin İDsini Getiren Kod
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT personelİd FROM Personeller WHERE Ad = '" + cmbPersonel.Text + "'", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            personelId = Convert.ToInt32(sqlDataReader.GetValue(0).ToString());
                        }
                    }

                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçilen Personelin Nöbet Listesini Getir
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Nobetler WHERE personel = '" + personelId + "'", connection))
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        connection.Open();

                        sqlDataAdapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        connection.Close();

                    }
                }
            }
        }

        private void NöbetEkle_Load_1(object sender, EventArgs e)       //Sayfa Açıldığında Gerçekleşicekler
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Ad FROM Personeller", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            cmbPersonel.Items.Add(sqlDataReader.GetValue(0));
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void NöbetEkle_FormClosed(object sender, FormClosedEventArgs e)     //Form Kapatıldığında Gerçekleşecekler
        {
            Nöbetİşlemleri nöbetİşlemleri = new Nöbetİşlemleri();
            nöbetİşlemleri.Show();
            this.Hide();
        }

        private void cmbPersonel_SelectedIndexChanged_1(object sender, EventArgs e)     //Comboboxta personel seçtiğimizde gerçekleşecekler
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçtiğimiz Personelin İDsini Bulma
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT personelİd FROM Personeller WHERE Ad = '" + cmbPersonel.Text + "'", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            personelId = Convert.ToInt32(sqlDataReader.GetValue(0).ToString());
                        }
                    }

                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçtiğimiz Personelin Nöbet listesini getiren Sql Sorgusu
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Nobetler WHERE personel = '" + personelId + "'", connection))
                {
                    using (DataTable dataTable = new DataTable())
                    {
                        connection.Open();

                        sqlDataAdapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        connection.Close();

                    }
                }
            }
        }

        private void btnOlustur_Click_1(object sender, EventArgs e)     //Nöbet Ekleme Butonu
        {
            var personel = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçilen personelin idsini al
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT personelİd FROM Personeller WHERE Ad = '" + cmbPersonel.Text + "'", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            personel = Convert.ToInt32(sqlDataReader.GetValue(0).ToString());
                        }
                    }
                    connection.Close();
                }
            }

            var tarih = dtpTarih.Value.Date;        //Seçtiğimiz tarih


            string turkceTarih = tarih.ToString(" dd MMMM yyyy, dddd", new CultureInfo("tr-TR"));       //Tarihi Türkçeye Çevir


            if (cmbPersonel.SelectedItem == null || cmbKonum.SelectedItem == null || cmbSaat.SelectedItem == null)      //Seçilen değerler boşsa uyar
            {
                MessageBox.Show("Boş Alanları Doldurunuz!");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(bgl.Adres)) //seçilen personel ve tarihi sorgulayan sql sorgusu
                {
                    using (SqlCommand komut = new SqlCommand("SELECT * FROM Nobetler WHERE Tarih = '" + tarih + "' AND personel = '" + personel + "'", connection))
                    {
                        connection.Open();

                        using (SqlDataReader oku = komut.ExecuteReader())  //seçilen personel ve tarih sqlde varsa uyar
                        {
                            if (oku.Read())
                            {
                                MessageBox.Show("Bu Tarihte Zaten Nöbet Kayıtlı!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else //yoksa nöbeti ekle
                            {
                                oku.Close();

                                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Nobetler VALUES (@personel,@tarih,@konum,@saat)", connection))
                                {
                                    sqlCommand.Parameters.AddWithValue("@personel", personel);  
                                    sqlCommand.Parameters.AddWithValue("@tarih", turkceTarih);
                                    sqlCommand.Parameters.AddWithValue("@konum", cmbKonum.Text);
                                    sqlCommand.Parameters.AddWithValue("@saat", cmbSaat.Text);

                                    sqlCommand.ExecuteNonQuery();

                                    MessageBox.Show("Nöbet eklendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    connection.Close();

                                    VeriGetir();        //Güncellenen Veriyi getir
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }
    }
}
