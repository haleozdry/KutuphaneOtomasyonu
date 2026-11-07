namespace KutuphaneOtomasyonu
{
    partial class FrmKitaplar
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
            this.lblAra = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.dgvKitaplar = new System.Windows.Forms.DataGridView();
            this.grpYonetim = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.txtKitapAdi = new System.Windows.Forms.TextBox();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lblKategori = new System.Windows.Forms.Label();
            this.lblYazar = new System.Windows.Forms.Label();
            this.lblKitapAdi = new System.Windows.Forms.Label();
            this.btnOduncAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).BeginInit();
            this.grpYonetim.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAra
            // 
            this.lblAra.AutoSize = true;
            this.lblAra.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAra.Location = new System.Drawing.Point(254, 98);
            this.lblAra.Name = "lblAra";
            this.lblAra.Size = new System.Drawing.Size(248, 19);
            this.lblAra.TabIndex = 0;
            this.lblAra.Text = "Ara (kitap, yazar, kategori):";
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(508, 97);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(135, 22);
            this.txtAra.TabIndex = 1;
            this.txtAra.TextChanged += new System.EventHandler(this.txtAra_TextChanged);
            // 
            // dgvKitaplar
            // 
            this.dgvKitaplar.AllowUserToAddRows = false;
            this.dgvKitaplar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitaplar.Location = new System.Drawing.Point(257, 141);
            this.dgvKitaplar.MultiSelect = false;
            this.dgvKitaplar.Name = "dgvKitaplar";
            this.dgvKitaplar.ReadOnly = true;
            this.dgvKitaplar.RowHeadersVisible = false;
            this.dgvKitaplar.RowHeadersWidth = 51;
            this.dgvKitaplar.RowTemplate.Height = 24;
            this.dgvKitaplar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKitaplar.Size = new System.Drawing.Size(377, 222);
            this.dgvKitaplar.TabIndex = 2;
            this.dgvKitaplar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKitaplar_CellClick);
            // 
            // grpYonetim
            // 
            this.grpYonetim.Controls.Add(this.btnTemizle);
            this.grpYonetim.Controls.Add(this.btnSil);
            this.grpYonetim.Controls.Add(this.btnGuncelle);
            this.grpYonetim.Controls.Add(this.btnEkle);
            this.grpYonetim.Controls.Add(this.txtAdet);
            this.grpYonetim.Controls.Add(this.txtKategori);
            this.grpYonetim.Controls.Add(this.txtYazar);
            this.grpYonetim.Controls.Add(this.txtKitapAdi);
            this.grpYonetim.Controls.Add(this.lblAdet);
            this.grpYonetim.Controls.Add(this.lblKategori);
            this.grpYonetim.Controls.Add(this.lblYazar);
            this.grpYonetim.Controls.Add(this.lblKitapAdi);
            this.grpYonetim.Location = new System.Drawing.Point(257, 411);
            this.grpYonetim.Name = "grpYonetim";
            this.grpYonetim.Size = new System.Drawing.Size(399, 276);
            this.grpYonetim.TabIndex = 3;
            this.grpYonetim.TabStop = false;
            this.grpYonetim.Text = "Kitap Yönetimi";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemizle.Location = new System.Drawing.Point(286, 196);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(91, 34);
            this.btnTemizle.TabIndex = 11;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSil.Location = new System.Drawing.Point(188, 196);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 34);
            this.btnSil.TabIndex = 10;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuncelle.Location = new System.Drawing.Point(94, 196);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(88, 34);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEkle.Location = new System.Drawing.Point(6, 196);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(82, 34);
            this.btnEkle.TabIndex = 8;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtAdet
            // 
            this.txtAdet.Location = new System.Drawing.Point(204, 121);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(139, 22);
            this.txtAdet.TabIndex = 7;
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(204, 89);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(139, 22);
            this.txtKategori.TabIndex = 6;
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(204, 55);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(139, 22);
            this.txtYazar.TabIndex = 5;
            // 
            // txtKitapAdi
            // 
            this.txtKitapAdi.Location = new System.Drawing.Point(204, 21);
            this.txtKitapAdi.Name = "txtKitapAdi";
            this.txtKitapAdi.Size = new System.Drawing.Size(139, 22);
            this.txtKitapAdi.TabIndex = 4;
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdet.Location = new System.Drawing.Point(62, 127);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(51, 22);
            this.lblAdet.TabIndex = 3;
            this.lblAdet.Text = "Adet";
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKategori.Location = new System.Drawing.Point(40, 95);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(85, 22);
            this.lblKategori.TabIndex = 2;
            this.lblKategori.Text = "Kategori";
            // 
            // lblYazar
            // 
            this.lblYazar.AutoSize = true;
            this.lblYazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYazar.Location = new System.Drawing.Point(55, 61);
            this.lblYazar.Name = "lblYazar";
            this.lblYazar.Size = new System.Drawing.Size(61, 22);
            this.lblYazar.TabIndex = 1;
            this.lblYazar.Text = "Yazar";
            // 
            // lblKitapAdi
            // 
            this.lblKitapAdi.AutoSize = true;
            this.lblKitapAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapAdi.Location = new System.Drawing.Point(37, 27);
            this.lblKitapAdi.Name = "lblKitapAdi";
            this.lblKitapAdi.Size = new System.Drawing.Size(91, 22);
            this.lblKitapAdi.TabIndex = 0;
            this.lblKitapAdi.Text = "Kitap Adı";
            // 
            // btnOduncAl
            // 
            this.btnOduncAl.Location = new System.Drawing.Point(660, 92);
            this.btnOduncAl.Name = "btnOduncAl";
            this.btnOduncAl.Size = new System.Drawing.Size(77, 33);
            this.btnOduncAl.TabIndex = 4;
            this.btnOduncAl.Text = "Ödünç Al";
            this.btnOduncAl.UseVisualStyleBackColor = true;
            this.btnOduncAl.Click += new System.EventHandler(this.btnOduncAl_Click);
            // 
            // FrmKitaplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 774);
            this.Controls.Add(this.btnOduncAl);
            this.Controls.Add(this.grpYonetim);
            this.Controls.Add(this.dgvKitaplar);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.lblAra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmKitaplar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitaplar";
            this.Load += new System.EventHandler(this.FrmKitaplar_Load);
            this.Click += new System.EventHandler(this.FrmKitaplar_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).EndInit();
            this.grpYonetim.ResumeLayout(false);
            this.grpYonetim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAra;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.DataGridView dgvKitaplar;
        private System.Windows.Forms.GroupBox grpYonetim;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.TextBox txtKitapAdi;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblYazar;
        private System.Windows.Forms.Label lblKitapAdi;
        private System.Windows.Forms.Button btnOduncAl;
    }
}