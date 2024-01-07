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
    public partial class NöbetDüzenle : Form
    {
        public NöbetDüzenle()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();

        void VeriGetir()        //Güncellenen Verileri Getiren Method
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçilen Personelin İDsini Bulma
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

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçilen personelin Nöbet listesini Getir
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

        private void NöbetDüzenle_Load(object sender, EventArgs e)          //Sayfa Açıldığında neler gerçekleşsin
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))         //Personel isimlerini comboboxa getirmes
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

        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)       //comboboxtaki personel seçildiğinde gerçekleşenler
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //seçtiğimiz personelin İDSini bulma
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

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçtiğimiz personelin Nöbet Listesini Getir
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)        //Nöbet Günü Seçildiğinde Konum ve saati otomatik doldur
        {
            cmbKonum.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmbSaat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)      //Güncelle butonu
        {
            var nobetid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //seçilen Konum ve saati Güncelleyen sql sorgusu
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Nobetler SET konum = '" + cmbKonum.Text + "', saat = '" + cmbSaat.Text + "' WHERE nobetId = '" + nobetid + "'", connection))  //Sql Update Komutu
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Nöbet Güncellendi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }

        private void NöbetDüzenle_FormClosed(object sender, FormClosedEventArgs e)      //Form Kapatıldığında Ne Gerçekleşsin
        {
            Nöbetİşlemleri nöbetİşlemleri = new Nöbetİşlemleri();
            nöbetİşlemleri.Show();
            this.Hide();
        }
    }
}
