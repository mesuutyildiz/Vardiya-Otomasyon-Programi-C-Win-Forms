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
    public partial class PersonelSil : Form
    {
        public PersonelSil()
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
        private void button1_Click(object sender, EventArgs e)            // Seçtiğim Personelin Kaydını Sil
        {
            var personelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Personeller WHERE personelİd = '" + personelId + "'", connection))
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Personel silindi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }

        private void PersonelSil_Load(object sender, EventArgs e)       //Sayfa Açıldığında Gerçekleşecekler
        {
            VeriGetir();
        }

        private void PersonelSil_FormClosed(object sender, FormClosedEventArgs e)       //Sayfa Kapatıldığında Gerçekleşecekler
        {
            YoneticiEkran yoneticiEkran = new YoneticiEkran();
            yoneticiEkran.Show();
        }
    }
}
