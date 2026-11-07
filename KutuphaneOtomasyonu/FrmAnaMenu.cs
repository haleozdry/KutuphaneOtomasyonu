using System;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FrmAnaMenu : Form
    {
        public FrmAnaMenu()
        {
            InitializeComponent();
        }

        private void FrmAnaMenu_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = "Hoş geldin, " + Oturum.KullaniciAdi + " (" + Oturum.Rol + ")";

            if (Oturum.Rol != "Admin")
            {
                btnKullanicilar.Visible = false;
            }

            if (Oturum.Rol == "Admin")
            {
                btnOdunc.Text = "Tüm Ödünç Kayıtları";
            }
            else
            {
                btnOdunc.Text = "Ödünç Aldıklarım";
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void FrmAnaMenu_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            FrmKitaplar kitaplar = new FrmKitaplar();
            kitaplar.ShowDialog();
        }

        private void btnOdunc_Click(object sender, EventArgs e)
        {
            FrmOdunc odunc = new FrmOdunc();
            odunc.ShowDialog();
        }

        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            FrmKullanicilar kullanicilar = new FrmKullanicilar();
            kullanicilar.ShowDialog();
        }
    }
}