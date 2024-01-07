namespace Vardiya_Otomasyon_Programı
{
    partial class PersonelDüzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbKadro = new System.Windows.Forms.ComboBox();
            this.cmbUnvan = new System.Windows.Forms.ComboBox();
            this.lblKadro = new System.Windows.Forms.Label();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtSicil = new System.Windows.Forms.TextBox();
            this.lblSicil = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblTc = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(254, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(436, 405);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmbKadro
            // 
            this.cmbKadro.FormattingEnabled = true;
            this.cmbKadro.Items.AddRange(new object[] {
            "İşçi",
            "Memur"});
            this.cmbKadro.Location = new System.Drawing.Point(103, 361);
            this.cmbKadro.Name = "cmbKadro";
            this.cmbKadro.Size = new System.Drawing.Size(121, 21);
            this.cmbKadro.TabIndex = 42;
            // 
            // cmbUnvan
            // 
            this.cmbUnvan.FormattingEnabled = true;
            this.cmbUnvan.Location = new System.Drawing.Point(103, 318);
            this.cmbUnvan.Name = "cmbUnvan";
            this.cmbUnvan.Size = new System.Drawing.Size(121, 21);
            this.cmbUnvan.TabIndex = 41;
            // 
            // lblKadro
            // 
            this.lblKadro.AutoSize = true;
            this.lblKadro.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKadro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblKadro.Location = new System.Drawing.Point(24, 363);
            this.lblKadro.Name = "lblKadro";
            this.lblKadro.Size = new System.Drawing.Size(59, 20);
            this.lblKadro.TabIndex = 40;
            this.lblKadro.Text = "Kadro :";
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUnvan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUnvan.Location = new System.Drawing.Point(24, 320);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(61, 20);
            this.lblUnvan.TabIndex = 39;
            this.lblUnvan.Text = "Unvan :";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(103, 407);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(124, 20);
            this.txtSifre.TabIndex = 38;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSifre.Location = new System.Drawing.Point(24, 406);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(51, 20);
            this.lblSifre.TabIndex = 37;
            this.lblSifre.Text = "Şifre :";
            // 
            // txtSicil
            // 
            this.txtSicil.Location = new System.Drawing.Point(103, 276);
            this.txtSicil.Name = "txtSicil";
            this.txtSicil.Size = new System.Drawing.Size(124, 20);
            this.txtSicil.TabIndex = 36;
            // 
            // lblSicil
            // 
            this.lblSicil.AutoSize = true;
            this.lblSicil.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSicil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSicil.Location = new System.Drawing.Point(24, 274);
            this.lblSicil.Name = "lblSicil";
            this.lblSicil.Size = new System.Drawing.Size(68, 20);
            this.lblSicil.TabIndex = 35;
            this.lblSicil.Text = "Sicil No :";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(103, 236);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(124, 20);
            this.txtMail.TabIndex = 34;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMail.Location = new System.Drawing.Point(24, 234);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(46, 20);
            this.lblMail.TabIndex = 33;
            this.lblMail.Text = "Mail :";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTel.Location = new System.Drawing.Point(24, 197);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(68, 20);
            this.lblTel.TabIndex = 32;
            this.lblTel.Text = "Telefon :";
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdres.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAdres.Location = new System.Drawing.Point(24, 154);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(57, 20);
            this.lblAdres.TabIndex = 31;
            this.lblAdres.Text = "Adres :";
            // 
            // lblTc
            // 
            this.lblTc.AutoSize = true;
            this.lblTc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTc.Location = new System.Drawing.Point(24, 108);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(34, 20);
            this.lblTc.TabIndex = 30;
            this.lblTc.Text = "Tc :";
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSoyad.Location = new System.Drawing.Point(24, 62);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(62, 20);
            this.lblSoyad.TabIndex = 29;
            this.lblSoyad.Text = "Soyadı :";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAd.Location = new System.Drawing.Point(24, 22);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(41, 20);
            this.lblAd.TabIndex = 28;
            this.lblAd.Text = "Adı :";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(103, 199);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(124, 20);
            this.txtTel.TabIndex = 27;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(103, 152);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(124, 20);
            this.txtAdres.TabIndex = 26;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(103, 109);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(124, 20);
            this.txtTc.TabIndex = 25;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(103, 63);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(124, 20);
            this.txtSoyad.TabIndex = 24;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(103, 23);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(124, 20);
            this.txtAd.TabIndex = 23;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Image = global::Vardiya_Otomasyon_Programı.Properties.Resources.Done20;
            this.btnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelle.Location = new System.Drawing.Point(27, 456);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(663, 27);
            this.btnGuncelle.TabIndex = 43;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // PersonelDüzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(716, 495);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.cmbKadro);
            this.Controls.Add(this.cmbUnvan);
            this.Controls.Add(this.lblKadro);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtSicil);
            this.Controls.Add(this.lblSicil);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.lblTc);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.MaximizeBox = false;
            this.Name = "PersonelDüzenle";
            this.Text = "PersonelDüzenle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PersonelDüzenle_FormClosed);
            this.Load += new System.EventHandler(this.PersonelDüzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbKadro;
        private System.Windows.Forms.ComboBox cmbUnvan;
        private System.Windows.Forms.Label lblKadro;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtSicil;
        private System.Windows.Forms.Label lblSicil;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblTc;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Button btnGuncelle;
    }
}