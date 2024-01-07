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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static Vardiya_Otomasyon_Programı.Program;

namespace Vardiya_Otomasyon_Programı
{
    public partial class CıktıAl : Form
    {
        public CıktıAl()
        {
            InitializeComponent();
        }

        baglantı bgl = new baglantı();


        private void Listele_Click(object sender, EventArgs e)      //Nöbet Programını Listeleyen buton
        {
            var personel = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Seçilen Personelin İdsini Alma
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



            DateTime baslangicTarihi = dtpBaslangic.Value; // Başlangıç tarihi
            DateTime bitisTarihi = dtpBitis.Value; // Bitiş tarihi

            string baslangicStr = baslangicTarihi.ToString(" dd MMMM yyyy, dddd", new System.Globalization.CultureInfo("tr-TR"));   //Tarihleri Türkçeye çevirme
            string bitisStr = bitisTarihi.ToString(" dd MMMM yyyy, dddd", new System.Globalization.CultureInfo("tr-TR"));



            // Veritabanından nöbetleri çekmek için SQL sorgusu
            string query = @"SELECT p.Ad AS PersonelAdi, n.Tarih, n.Konum, n.Saat FROM Nobetler n INNER JOIN Personeller p ON n.personel = p.personelİd WHERE n.personel = @PersonelID AND n.Tarih BETWEEN @BaslangicTarihi AND @BitisTarihi";

            using (SqlConnection connection = new SqlConnection(bgl.Adres))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonelID", personel);
                    command.Parameters.AddWithValue("@BaslangicTarihi", baslangicStr);
                    command.Parameters.AddWithValue("@BitisTarihi", bitisStr);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable; // DataGridView'e verileri yükle
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)      //Çıktı Almaya Yarayan Buton 
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Veriler diske yazılamıyor!" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    if (dcell.Value != null) // Null kontrolü
                                    {
                                        pTable.AddCell(dcell.Value.ToString());
                                    }
                                    else
                                    {
                                        pTable.AddCell(""); // Boş hücreye varsayılan değer ekleme
                                    }
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Yazdırma başarılı!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Veriler aktarılırken hata oluştu!" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CıktıAl_Load(object sender, EventArgs e)       //Sayfa Açıldığında gerçekleşenler
        {
            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Personelleri Comboboxa Eklemek
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
    }
}