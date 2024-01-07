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
    public partial class PersonelDüzenle : Form
    {
        public PersonelDüzenle()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();

        void VeriGetir()  //Personeller Tablosunu Getir
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Personeller", connection);

                DataTable tablo = new DataTable();

                dataAdapter.Fill(tablo);

                dataGridView1.DataSource = tablo;

                connection.Close();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)     // Güncellemek istediğim Personele Tıkladığımda Personel Bilgilerini Doldur
        {
                txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtAdres.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtTel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtMail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtSicil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                cmbKadro.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                cmbUnvan.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtSifre.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)                  // Seçtiğim Personeli Güncelle
        {
            var personelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());  //Seçtiğim Personelin id'sini integer'a Dönüştür

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Personeller SET Ad = '" + txtAd.Text + "', Soyad = '" + txtSoyad.Text + "', Tc = '" + txtTc.Text + "', Adres = '" + txtAdres.Text + "', Telefon = '" + txtTel.Text + "', Mail = '" + txtMail.Text + "' , SicilNo = '" + txtSicil.Text + "', Kadro = '" + cmbKadro.Text + "', Unvan = '" + cmbUnvan.Text + "', Sifre = '" + txtSifre.Text + "' WHERE personelİd = '" + personelId + "'", connection))  //Sql Update Komutu
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Personel güncellendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }

        private void PersonelDüzenle_Load(object sender, EventArgs e)       //Sayfa Açıldığında Hangi İşlemler gerçekleşceği
        {
            VeriGetir();

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Veritabanındaki Ünvanları Comboboxa çağır
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Unvan FROM Unvanlar", connection))
                {
                    connection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            cmbUnvan.Items.Add(sqlDataReader.GetValue(0));  //Her birini döngüyle ekle
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void PersonelDüzenle_FormClosed(object sender, FormClosedEventArgs e)  //Form Kapatıldığında Yönetici Ekranına Yönlendir
        {   
            YoneticiEkran yonetici = new YoneticiEkran();
            yonetici.Show();
        }
    }
}
