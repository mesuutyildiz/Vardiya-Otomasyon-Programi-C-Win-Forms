using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using static Vardiya_Otomasyon_Programı.Program;

namespace Vardiya_Otomasyon_Programı
{
    public partial class Nöbetİşlemleri : Form
    {
        public Nöbetİşlemleri() 
        {
            InitializeComponent();
        }



        baglantı bgl = new baglantı();


        List<int> GetPersonelIDs()      //Veri Tabanındaki Personellerin Personelİdlerini Alan Ve Lisleyen Metho
        {
            List<int> personelIDs = new List<int>();

            string query = "SELECT Personelİd FROM Personeller;";       // Personel tablosundan PersonelID'leri getiren SQL sorgusu

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int personelID = reader.GetInt32(0);        // Eğer PersonelID INT ise
                    personelIDs.Add(personelID);
                }

                reader.Close();
            }

            return personelIDs;
        }



        private List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)        //İki Tarih Arasını Alan ve Bu Tarihleri Listeleyen Method
        {
            TimeSpan fark = endDate - startDate;
            int gunSayisi = (int)fark.TotalDays;

            List<DateTime> tarihListesi = new List<DateTime>();
            for (int i = 0; i <= gunSayisi; i++)
            {
                DateTime tarih = startDate.AddDays(i);
                tarihListesi.Add(tarih);
            }

            return tarihListesi;
        }


        
        private bool TarihVarMi(DateTime tarih)     //Veri Tabanında Oluşturulan Nöbet Programında ki Tarih Var mı Yok mu Kontrol Eden Method
        {
            string turkceTarih = tarih.ToString(" dd MMMM yyyy, dddd", new CultureInfo("tr-TR"));

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Nobetler WHERE Tarih = @Tarih";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tarih", turkceTarih);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }


        private void SilIzinGunlerineGoreNobetler(DateTime baslangicTarihi, DateTime bitisTarihi)       //Nöbet Listesi Oluştuktan Sonra Personelin
                                                                                                        //İzin Günü Hangisiyse Onu Silen Method
        {
            List<DateTime> tarihListesi = GetDatesBetween(baslangicTarihi, bitisTarihi);

            foreach (DateTime tarih in tarihListesi)
            {
                string turkceTarih = tarih.ToString(" dd MMMM yyyy, dddd", new CultureInfo("tr-TR"));

                foreach (int personelID in GetPersonelIDs())
                {
                    using (SqlConnection connection = new SqlConnection(bgl.Adres))
                    {
                        connection.Open();

                        string izinGunuSorgusu = "SELECT IzinGunleri FROM Personeller WHERE Personelİd = @PersonelID";

                        using (SqlCommand izinCommand = new SqlCommand(izinGunuSorgusu, connection))
                        {
                            izinCommand.Parameters.AddWithValue("@PersonelID", personelID);

                            string izinGunleri = izinCommand.ExecuteScalar()?.ToString();

                            if (!string.IsNullOrEmpty(izinGunleri))
                            {
                                string[] izinGunlerListesi = izinGunleri.Split(',');

                                foreach (string izinGun in izinGunlerListesi)
                                {
                                    string turkceIzinGun = izinGun.Trim();

                                    // Veritabanındaki izin günleri ile tarihlerin gün adını karşılaştır

                                    if (tarih.ToString("dddd", new CultureInfo("tr-TR")).Equals(turkceIzinGun, StringComparison.OrdinalIgnoreCase))
                                    { 
                                        string query = "DELETE FROM Nobetler WHERE personel = @PersonelID AND tarih = @Tarih";
                                        using (SqlCommand deleteCommand = new SqlCommand(query, connection))
                                        {
                                            deleteCommand.Parameters.AddWithValue("@PersonelID", personelID);
                                            deleteCommand.Parameters.AddWithValue("@Tarih", turkceTarih);

                                            deleteCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }


        private void btnAta_Click(object sender, EventArgs e)  //Nöbet Programı Oluştur Butonu
        {
            DateTime baslangicTarihi = dateTimePicker1.Value;
            DateTime bitisTarihi = dateTimePicker2.Value;

            List<DateTime> tarihListesi = GetDatesBetween(baslangicTarihi, bitisTarihi);

            Random random = new Random();

            string[] saatDilimleriKampusİci = { "08:00-16:00", "09:00-17:00" };
            string[] saatDilimleriKampusGiris = { "00:00-08:00", "08:00-16:00", "16:00-00:00" };
            string[] konumlar = { "Kampüs Girisi", "Kampüs içi" };


            List<int> personelIDs = GetPersonelIDs(); // Örnek olarak personel ID'lerini alın


            foreach (DateTime tarih in tarihListesi)        // Personellere Nöbet Atayan Döngü
            {
                if (TarihVarMi(tarih))
                {
                    MessageBox.Show("Seçtiğiniz Tarih veya Tarihlerde Zaten Nöbet Bulunmakta", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }


                personelIDs = personelIDs.OrderBy(x => random.Next()).ToList();     // Liste içindeki personelleri karıştır

                int index = 0;      // Liste içindeki personel indexini takip etmek için

                string turkceTarih = tarih.ToString(" dd MMMM yyyy, dddd", new CultureInfo("tr-TR"));


                foreach (string saatDilimi in saatDilimleriKampusGiris)     //Kampüs Girişi Vardiyalarını Nöbet Tablosuna Ekleyen Döngü
                {
                    if (index >= personelIDs.Count)     // Personel sayısı saat dilimi sayısından azsa sıfırdan başla
                        index = 0;

                    string randomKonum = konumlar[0];

                    using (SqlConnection connection = new SqlConnection(bgl.Adres))
                    {
                        connection.Open();

                        string query = "INSERT INTO Nobetler (personel, Tarih, Konum, Saat) VALUES (@PersonelID, @Tarih, @Konum, @Saat)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int currentPersonelID = personelIDs[index];
                            command.Parameters.AddWithValue("@PersonelId", currentPersonelID);
                            command.Parameters.AddWithValue("@Tarih", turkceTarih);
                            command.Parameters.AddWithValue("@Konum", randomKonum);
                            command.Parameters.AddWithValue("@Saat", saatDilimi);

                            command.ExecuteNonQuery();

                            connection.Close();
                        }

                        index++; // Bir sonraki saat dilimine geçmek için index'i artır
                    }
                }

                

                foreach (string saatDilimi in saatDilimleriKampusİci)       //Kampüs İçi Vardiyalarını Nöbet Tablosuna Ekleyen Döngü
                {
                    if (index >= personelIDs.Count)
                        index = 0;

                    string randomKonum = konumlar[1];       // Kampüs Girişi için atama yapılacak

                    using (SqlConnection connection = new SqlConnection(bgl.Adres))
                    {
                        connection.Open();

                        string query = "INSERT INTO Nobetler (personel, Tarih, Konum, Saat) VALUES (@PersonelID, @Tarih, @Konum, @Saat)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            int currentPersonelID = personelIDs[index];
                            command.Parameters.AddWithValue("@PersonelId", currentPersonelID);
                            command.Parameters.AddWithValue("@Tarih", turkceTarih);
                            command.Parameters.AddWithValue("@Konum", randomKonum);
                            command.Parameters.AddWithValue("@Saat", saatDilimi);

                            command.ExecuteNonQuery();

                            connection.Close();
                        }

                        index++;
                    }
                }

                SilIzinGunlerineGoreNobetler(baslangicTarihi, bitisTarihi);

            }
            VeriGetir();        //Güncellenmiş Verileri Göster
        }
        

        private void button2_Click(object sender, EventArgs e)      //Nöbet Düzenle Formuna Yönlendir
        {
            NöbetDüzenle nöbetDüzenle = new NöbetDüzenle();
            nöbetDüzenle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)      //Nöbet Silme Formuna Yönlendir
        {
            NobetSil nobetSil = new NobetSil();
            nobetSil.Show();
            this.Hide();
        }

        private void Nöbetİşlemleri_FormClosed(object sender, FormClosedEventArgs e)        //Form Kapatıldığında Ne Gerçekleşecek
        {
            YoneticiEkran yoneticiEkran = new YoneticiEkran(); 
            yoneticiEkran.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)        //Nöbet Ekleme Formuna Yönlendir
        {
            NöbetEkle nöbetEkle = new NöbetEkle();
            nöbetEkle.Show();
            this.Hide();
        }

        void VeriGetir()        //Nöbet Listesini datagridviewe çağıran method 
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT p.Ad AS PersonelIsim, n.Tarih,n.Konum,n.Saat  FROM Nobetler n INNER JOIN Personeller p ON n.personel = p.personelİd", connection))
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

        private void Nöbetİşlemleri_Load(object sender, EventArgs e)        //Sayfa Yüklendiğinde Yani Açıldığında Tabloyu ve Gerekli Bilgileri Çağır
        {
            VeriGetir();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CıktıAl cıktıAl = new CıktıAl();
            cıktıAl.Show();
        }

    }
}
