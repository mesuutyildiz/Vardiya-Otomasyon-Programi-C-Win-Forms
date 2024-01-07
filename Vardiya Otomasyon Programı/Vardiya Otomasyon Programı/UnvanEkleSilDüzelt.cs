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
    public partial class UnvanEkleSilDüzelt : Form
    {
        public UnvanEkleSilDüzelt()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();

        void VeriGetir()            //Unvanlar Tablosunu Getirme
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Unvanlar", connection);

                DataTable tablo = new DataTable();

                dataAdapter.Fill(tablo);

                dataGridView1.DataSource = tablo;

                connection.Close();
            }
       }
        private void UnvanEkleSilDüzelt_Load(object sender, EventArgs e)        //Sayfa Açıldığında Gerçekleşecekler
        {
            VeriGetir();
        }

        private void UnvanEkleSilDüzelt_FormClosed(object sender, FormClosedEventArgs e)  //Form Kapatıldığında Yönetici Ekranına Yönlendir
        {
            YoneticiEkran yoneticiEkran = new YoneticiEkran();
            yoneticiEkran.Show();
        }


        private void btnEkle_Click(object sender, EventArgs e)  //Unvan Ekle İşlemi
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Unvanlar VALUES ('" + txtUnvan.Text + "')", connection))
                {
                    connection.Open();

                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Ünvan eklendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connection.Close();

                    VeriGetir();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)  //Unvan Sil İşlemi
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Unvanlar WHERE Unvanİd = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", connection))
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Ünvan Silindi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)  //Unvan Güncelle İşlemi
        {
            var Unvanİd = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Unvanlar SET Unvan = '" + txtUnvan.Text + "' WHERE Unvanİd ='" + Unvanİd + "'", connection))
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Ünvan Güncellendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)        //Tıkladığımız Satırın Unvanını Textboxa doldurma
        {
            txtUnvan.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
