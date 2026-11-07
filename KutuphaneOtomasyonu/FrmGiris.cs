using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // 1) Kutular boşsa uyar ve çık
            if (txtKullaniciAdi.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifreyi girin!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                // 2) Veritabanını aç
                baglanti.Open();

                // 3) Sorguyu hazırla
                SqlCommand komut = new SqlCommand(
                    "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@ad AND Sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                // 4) Sorguyu çalıştır, sonucu oku
                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.Read())
                {
                    // 5) Kullanıcı bulundu, bilgileri Oturum'a kaydet
                    Oturum.KullaniciId = Convert.ToInt32(okuyucu["Id"]);
                    Oturum.KullaniciAdi = okuyucu["KullaniciAdi"].ToString();
                    Oturum.Rol = okuyucu["Rol"].ToString();

                    // 6) Ana menüyü aç, giriş formunu gizle
                    FrmAnaMenu menu = new FrmAnaMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }

                okuyucu.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FrmKayit kayit = new FrmKayit();
            kayit.ShowDialog();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}