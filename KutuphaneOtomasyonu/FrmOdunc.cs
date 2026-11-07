using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FrmOdunc : Form
    {
        // Tablodan seçilen ödünç kaydının Id'si (0 ise seçim yok)
        int seciliOduncId = 0;
        // Seçilen kitap daha önce iade edilmiş mi?
        bool seciliIadeEdilmis = false;

        public FrmOdunc()
        {
            InitializeComponent();
        }

        private void FrmOdunc_Load(object sender, EventArgs e)
        {
            if (Oturum.Rol == "Admin")
            {
                this.Text = "Tüm Ödünç Kayıtları";
                btnIadeEt.Visible = false; // iadeyi kullanıcı yapar
            }
            else
            {
                this.Text = "Ödünç Aldıklarım";
            }

            Listele();
        }

        private void Listele()
        {
            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                // Durum sütununu SQL içinde hesaplıyoruz
                string sorgu =
                    "SELECT o.Id, k.KitapAdi, u.AdSoyad, o.VerilisTarihi, o.TeslimTarihi, o.IadeTarihi, " +
                    "CASE WHEN o.IadeTarihi IS NOT NULL THEN N'İade edildi' " +
                    "WHEN o.TeslimTarihi < GETDATE() THEN N'Gecikmiş' " +
                    "ELSE N'Ödünçte' END AS Durum " +
                    "FROM Odunc o " +
                    "INNER JOIN Kitaplar k ON o.KitapId = k.Id " +
                    "INNER JOIN Kullanicilar u ON o.KullaniciId = u.Id ";

                // Kullanıcıysa sadece kendi kayıtlarını getir
                if (Oturum.Rol != "Admin")
                {
                    sorgu = sorgu + "WHERE o.KullaniciId = @kid ";
                }

                sorgu = sorgu + "ORDER BY o.Id DESC";

                SqlDataAdapter adaptor = new SqlDataAdapter(sorgu, baglanti);

                if (Oturum.Rol != "Admin")
                {
                    adaptor.SelectCommand.Parameters.AddWithValue("@kid", Oturum.KullaniciId);
                }

                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                dgvOdunc.DataSource = tablo;

                // Görünümü düzenle
                dgvOdunc.Columns["Id"].Visible = false;
                dgvOdunc.Columns["KitapAdi"].HeaderText = "Kitap Adı";
                dgvOdunc.Columns["AdSoyad"].HeaderText = "Üye";
                dgvOdunc.Columns["VerilisTarihi"].HeaderText = "Veriliş";
                dgvOdunc.Columns["TeslimTarihi"].HeaderText = "Son Teslim";
                dgvOdunc.Columns["IadeTarihi"].HeaderText = "İade Tarihi";

                dgvOdunc.Columns["VerilisTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvOdunc.Columns["TeslimTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvOdunc.Columns["IadeTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";

                // Kullanıcı kendi adını görmesin, gereksiz
                if (Oturum.Rol != "Admin")
                {
                    dgvOdunc.Columns["AdSoyad"].Visible = false;
                }

                // Gecikmiş kayıtları kırmızı yap
                foreach (DataGridViewRow satir in dgvOdunc.Rows)
                {
                    if (satir.Cells["Durum"].Value.ToString() == "Gecikmiş")
                    {
                        satir.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }

                // Hiçbir satır seçili görünmesin
                dgvOdunc.ClearSelection();
                dgvOdunc.CurrentCell = null;

                // Yenilenince seçim sıfırlansın
                seciliOduncId = 0;
                seciliIadeEdilmis = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
        }

        // Tabloda bir satıra tıklanınca hangi kaydın seçildiğini hatırla
        private void dgvOdunc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow satir = dgvOdunc.Rows[e.RowIndex];
            seciliOduncId = Convert.ToInt32(satir.Cells["Id"].Value);
            seciliIadeEdilmis = satir.Cells["IadeTarihi"].Value != DBNull.Value;
        }

        private void btnIadeEt_Click(object sender, EventArgs e)
        {
            if (seciliOduncId == 0)
            {
                MessageBox.Show("Önce tablodan bir kayıt seçin!");
                return;
            }

            if (seciliIadeEdilmis)
            {
                MessageBox.Show("Bu kitap zaten iade edilmiş!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                // İade tarihini bugün yap ve kitabın stoğunu 1 artır
                SqlCommand komut = new SqlCommand(
                    "UPDATE Odunc SET IadeTarihi = GETDATE() WHERE Id=@id; " +
                    "UPDATE Kitaplar SET Adet = Adet + 1 WHERE Id = (SELECT KitapId FROM Odunc WHERE Id=@id)", baglanti);
                komut.Parameters.AddWithValue("@id", seciliOduncId);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap iade edildi, teşekkürler!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
            finally
            {
                baglanti.Close();
            }

            Listele();
        }

        private void FrmOdunc_Click(object sender, EventArgs e)
        {
            dgvOdunc.ClearSelection();
            dgvOdunc.CurrentCell = null;
            seciliOduncId = 0;
            seciliIadeEdilmis = false;
        }

        private void FrmOdunc_Shown(object sender, EventArgs e)
        {
            dgvOdunc.ClearSelection();
            dgvOdunc.CurrentCell = null;
        }
    }
}