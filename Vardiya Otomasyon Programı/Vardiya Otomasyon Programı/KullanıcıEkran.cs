using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static Vardiya_Otomasyon_Programı.Program;


namespace Vardiya_Otomasyon_Programı
{
    public partial class KullanıcıEkran : Form
    {
        public KullanıcıEkran(string tc)
        {
            InitializeComponent();
            this.tc = tc;       //Giris Ekranından Tcyi çekiyoruz
        }

        baglantı bgl = new baglantı();

        private void KullanıcıEkran_FormClosed(object sender, FormClosedEventArgs e)        //Form Kapatıldığında Neler Gerçekleşsin
        {
            Giris giris = new Giris();
            giris.Show();
            
        }

        public string tc = "";
        private void KullanıcıEkran_Load(object sender, EventArgs e)
        {
            var personelId = 0;

            using (SqlConnection connection = new SqlConnection(bgl.Adres))     //Giriş Ekranında Tcsi Alınan Personelin İDsini Bulma
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT personelİd FROM Personeller WHERE Tc = '" + tc + "'", connection))
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

            using (SqlConnection connection = new SqlConnection(bgl.Adres))                 // Tc'ye ait nöbetleri listele 
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT p.Ad AS PersonelIsim, n.Tarih,n.Konum,n.Saat  FROM Nobetler n INNER JOIN Personeller p ON n.personel = p.personelİd WHERE personel = '" + personelId + "'", connection))
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


        private void btnCıktı_Click_1(object sender, EventArgs e)       //Listenin Çıktısını alma
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
    }
}
