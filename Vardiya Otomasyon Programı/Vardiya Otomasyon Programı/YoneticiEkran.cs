using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vardiya_Otomasyon_Programı.Program;

namespace Vardiya_Otomasyon_Programı
{
    public partial class YoneticiEkran : Form
    {
        public YoneticiEkran()
        {
            InitializeComponent();

            Image originalImage = Properties.Resources.Plus;
            Image resizedImage = new Bitmap(originalImage, new Size(30, 30)); 
            button1.Image = resizedImage;

            Image originalImage2 = Properties.Resources.Delete; 
            Image resizedImage2 = new Bitmap(originalImage2, new Size(30, 30)); 
            button2.Image = resizedImage2;

            Image originalImage3 = Properties.Resources.Edit;
            Image resizedImage3 = new Bitmap(originalImage3, new Size(30, 30));         //İconları ayarlama
            button3.Image = resizedImage3;

            Image originalImage4 = Properties.Resources.calendar_icon; 
            Image resizedImage4= new Bitmap(originalImage4, new Size(30, 30)); 
            button4.Image = resizedImage4; 

            Image originalImage5 = Properties.Resources.MySpace;
            Image resizedImage5 = new Bitmap(originalImage5, new Size(30, 30));
            button5.Image = resizedImage5;

        }

        baglantı bgl = new baglantı();

        void VeriGetir()  //Sql Personeller Tablosunu Çağır
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Ad, Soyad, Tc, Adres, Telefon, Mail, Sicilno, Kadro, Unvan, Sifre, IzinGunleri FROM Personeller", connection);
                
                DataTable tablo = new DataTable();

                dataAdapter.Fill(tablo);

                dataGridView1.DataSource = tablo;

                connection.Close();
            }
        }


        private void YoneticiEkran_Load(object sender, EventArgs e)  //Method Çalıştır (sayfa açıldığında direkt yüklenir)
        {
            VeriGetir();

        }


        private void YoneticiEkran_FormClosed(object sender, FormClosedEventArgs e)  //Form Kapatıldığında 
        {
            Giris giris = new Giris();
            giris.Show();
        }

        private void button1_Click(object sender, EventArgs e) //Personel Ekle Kısmına Yönlendir
        {
            PersonekEkle personekEkle = new PersonekEkle();
            personekEkle.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e) //Personel Sil Kısmına Yönlendir
        {
            PersonelSil personelSil = new PersonelSil();
            personelSil.Show();
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e) //Personel Bilgileri Güncelleme Kısmına Yönlendir
        {
            PersonelDüzenle personelDüzenle = new PersonelDüzenle();
            personelDüzenle.Show();
            this.Hide();
        }

        private void YoneticiEkran_FormClosed_1(object sender, FormClosedEventArgs e)  //Form Kapatıldığında Giriş Ekranına Yönlendir
        {
            Giris giris = new Giris();
            giris.Show();
        }

        private void button5_Click(object sender, EventArgs e)  //Unvan İşlemleri Kısmına Yönlendir
        {
            UnvanEkleSilDüzelt unvanEkleSilDüzelt = new UnvanEkleSilDüzelt();
            unvanEkleSilDüzelt.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)      //Nöbet Düzenle Formuna Yönlendir
        {
            Nöbetİşlemleri nöbetDüzenle = new Nöbetİşlemleri();
            nöbetDüzenle.Show();
            this.Hide();
        }
    }
}
