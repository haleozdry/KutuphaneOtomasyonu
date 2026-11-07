namespace KutuphaneOtomasyonu
{
    partial class FrmAnaMenu
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
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.btnKitaplar = new System.Windows.Forms.Button();
            this.btnOdunc = new System.Windows.Forms.Button();
            this.btnKullanicilar = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(600, 155);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(0, 16);
            this.lblHosgeldin.TabIndex = 0;
            // 
            // btnKitaplar
            // 
            this.btnKitaplar.Location = new System.Drawing.Point(302, 218);
            this.btnKitaplar.Name = "btnKitaplar";
            this.btnKitaplar.Size = new System.Drawing.Size(132, 107);
            this.btnKitaplar.TabIndex = 1;
            this.btnKitaplar.Text = "Kitaplar";
            this.btnKitaplar.UseVisualStyleBackColor = true;
            this.btnKitaplar.Click += new System.EventHandler(this.btnKitaplar_Click);
            // 
            // btnOdunc
            // 
            this.btnOdunc.Location = new System.Drawing.Point(502, 218);
            this.btnOdunc.Name = "btnOdunc";
            this.btnOdunc.Size = new System.Drawing.Size(139, 107);
            this.btnOdunc.TabIndex = 2;
            this.btnOdunc.Text = "Ödünç İşlemleri";
            this.btnOdunc.UseVisualStyleBackColor = true;
            this.btnOdunc.Click += new System.EventHandler(this.btnOdunc_Click);
            // 
            // btnKullanicilar
            // 
            this.btnKullanicilar.Location = new System.Drawing.Point(302, 356);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new System.Drawing.Size(132, 110);
            this.btnKullanicilar.TabIndex = 3;
            this.btnKullanicilar.Text = "Kullanıcı Yönetimi";
            this.btnKullanicilar.UseVisualStyleBackColor = true;
            this.btnKullanicilar.Click += new System.EventHandler(this.btnKullanicilar_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(502, 356);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(139, 110);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 735);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnKullanicilar);
            this.Controls.Add(this.btnOdunc);
            this.Controls.Add(this.btnKitaplar);
            this.Controls.Add(this.lblHosgeldin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmAnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAnaMenu_FormClosed_1);
            this.Load += new System.EventHandler(this.FrmAnaMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHosgeldin;
        private System.Windows.Forms.Button btnKitaplar;
        private System.Windows.Forms.Button btnOdunc;
        private System.Windows.Forms.Button btnKullanicilar;
        private System.Windows.Forms.Button btnCikis;
    }
}