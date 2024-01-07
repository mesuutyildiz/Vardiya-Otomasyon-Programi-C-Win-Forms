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
    public partial class NobetSil : Form
    {
        public NobetSil()
        {
            InitializeComponent();
        }


        baglantı bgl = new baglantı();

        void VeriGetir()    //Yenilenen Listeyi Getiren Method
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres)) //comboboxta seçilen personelin id'sini Alma
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

            using (SqlConnection connection = new SqlConnection(bgl.Adres)) //Personel İd'sini Aldıktan Sonra Bu idyi Kullanarak o personelin nöbet listesini çekmek
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

        private void button1_Click(object sender, EventArgs e)  //Seçilen Nöbetin Nöbet idsini Alıp O Nöbeti Silen Buton
        {
            var nobetid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Nobetler WHERE nobetId = '" + nobetid + "'", connection))
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Nöbet Silindi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir(); //Yenilenen Verileri Getiren Method
                }
            }
        }

        private void NobetSil_Load(object sender, EventArgs e) //Combobox'a Personelleri Getirme
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

        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e) //comboboxta seçilen personelin id'sini Alma
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
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

            using (SqlConnection connection = new SqlConnection(bgl.Adres))  //Personel İd'sini Aldıktan Sonra Bu idyi Kullanarak o personelin nöbet listesini çekmek
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

        private void NobetSil_FormClosed(object sender, FormClosedEventArgs e)  //Form Kapatıldığında Nöbet işlemleri Formuna geç
        {
            Nöbetİşlemleri nöbetİşlemleri = new Nöbetİşlemleri();
            nöbetİşlemleri.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)  //Seçilen Personelin Bütün Nöbetlerini Silen Buton
        {
            var personel = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Nobetler WHERE personel = '" + personel + "'", connection))
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Nöbetler Silindi!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    VeriGetir();
                }
            }
        }
    }
}
