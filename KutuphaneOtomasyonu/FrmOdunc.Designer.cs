namespace KutuphaneOtomasyonu
{
    partial class FrmOdunc
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
            this.dgvOdunc = new System.Windows.Forms.DataGridView();
            this.btnIadeEt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdunc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOdunc
            // 
            this.dgvOdunc.AllowUserToAddRows = false;
            this.dgvOdunc.AllowUserToDeleteRows = false;
            this.dgvOdunc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOdunc.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvOdunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdunc.Location = new System.Drawing.Point(264, 109);
            this.dgvOdunc.MultiSelect = false;
            this.dgvOdunc.Name = "dgvOdunc";
            this.dgvOdunc.ReadOnly = true;
            this.dgvOdunc.RowHeadersVisible = false;
            this.dgvOdunc.RowHeadersWidth = 51;
            this.dgvOdunc.RowTemplate.Height = 24;
            this.dgvOdunc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdunc.Size = new System.Drawing.Size(659, 276);
            this.dgvOdunc.TabIndex = 0;
            this.dgvOdunc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOdunc_CellClick);
            // 
            // btnIadeEt
            // 
            this.btnIadeEt.BackColor = System.Drawing.Color.Gold;
            this.btnIadeEt.Location = new System.Drawing.Point(463, 405);
            this.btnIadeEt.Name = "btnIadeEt";
            this.btnIadeEt.Size = new System.Drawing.Size(255, 70);
            this.btnIadeEt.TabIndex = 1;
            this.btnIadeEt.Text = "Seçili Kitabı İade Et";
            this.btnIadeEt.UseVisualStyleBackColor = false;
            this.btnIadeEt.Click += new System.EventHandler(this.btnIadeEt_Click);
            // 
            // FrmOdunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 760);
            this.Controls.Add(this.btnIadeEt);
            this.Controls.Add(this.dgvOdunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmOdunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOdunc";
            this.Load += new System.EventHandler(this.FrmOdunc_Load);
            this.Shown += new System.EventHandler(this.FrmOdunc_Shown);
            this.Click += new System.EventHandler(this.FrmOdunc_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOdunc;
        private System.Windows.Forms.Button btnIadeEt;
    }
}