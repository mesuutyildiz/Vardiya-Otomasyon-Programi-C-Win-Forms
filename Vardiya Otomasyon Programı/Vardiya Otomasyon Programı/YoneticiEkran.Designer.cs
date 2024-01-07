namespace Vardiya_Otomasyon_Programı
{
    partial class YoneticiEkran
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
            this.components = new System.ComponentModel.Container();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.personellerBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.personellerBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.personellerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.personellerBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.personellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DimGray;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(26, 302);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(255, 39);
            this.button5.TabIndex = 4;
            this.button5.Text = "Unvan İşlemleri";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DimGray;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = global::Vardiya_Otomasyon_Programı.Properties.Resources.calendar_icon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(26, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(255, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "Nöbet İşlemleri";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = global::Vardiya_Otomasyon_Programı.Properties.Resources.Edit;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(26, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(255, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Personel Güncelle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Vardiya_Otomasyon_Programı.Properties.Resources.Delete;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(26, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Personel Sil";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::Vardiya_Otomasyon_Programı.Properties.Resources.Plus;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(26, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Personel Ekle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personellerBindingSource4
            // 
            this.personellerBindingSource4.DataMember = "Personeller";
            // 
            // personellerBindingSource3
            // 
            this.personellerBindingSource3.DataMember = "Personeller";
            // 
            // personellerBindingSource1
            // 
            this.personellerBindingSource1.DataMember = "Personeller";
            // 
            // personellerBindingSource2
            // 
            this.personellerBindingSource2.DataMember = "Personeller";
            // 
            // personellerBindingSource
            // 
            this.personellerBindingSource.DataMember = "Personeller";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "___________________________________________\r\n";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "___________________________________________\r\n";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(314, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(460, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // YoneticiEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 376);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "YoneticiEkran";
            this.Text = "YoneticiEkran";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.YoneticiEkran_FormClosed_1);
            this.Load += new System.EventHandler(this.YoneticiEkran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personellerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.BindingSource personellerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn adDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sicilnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personellerBindingSource1;
        private System.Windows.Forms.BindingSource personellerBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifreDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personellerBindingSource3;
        private System.Windows.Forms.BindingSource personellerBindingSource4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}