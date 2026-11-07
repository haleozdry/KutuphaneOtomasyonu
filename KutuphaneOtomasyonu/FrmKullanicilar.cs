using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FrmKullanicilar : Form
    {
        // Tablodan seçilen kullanıcının Id'si (0 ise seçim yok)
        int seciliId = 0;

        public FrmKullanicilar()
        {
            InitializeComponent();
        }

        private void FrmKullanicilar_Load(object sender, EventArgs e)
        {
            // Rol listesini doldur
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("Kullanici");
            cmbRol.SelectedIndex = 1; // varsayılan: Kullanici

            Listele();
        }

        // Kullanıcıları tabloya doldurur (şifreyi göstermiyoruz)
        private void Listele()
        {
            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                SqlDataAdapter adaptor = new SqlDataAdapter(
                    "SELECT Id, KullaniciAdi, AdSoyad, Telefon, Email, Rol FROM Kullanicilar ORDER BY Id", baglanti);

                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                dgvKullanicilar.DataSource = tablo;

                dgvKullanicilar.Columns["Id"].Visible = false;
                dgvKullanicilar.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                dgvKullanicilar.Columns["AdSoyad"].HeaderText = "Ad Soyad";
                dgvKullanicilar.Columns["Email"].HeaderText = "E-posta";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
        }

        // Kutuları temizler
        private void Temizle()
        {
            txtAdSoyad.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            cmbRol.SelectedIndex = 1;
            seciliId = 0;
        }

        // Tabloda satıra tıklayınca bilgileri kutulara doldur
        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow satir = dgvKullanicilar.Rows[e.RowIndex];
            seciliId = Convert.ToInt32(satir.Cells["Id"].Value);
            txtAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
            txtKullaniciAdi.Text = satir.Cells["KullaniciAdi"].Value.ToString();
            txtTelefon.Text = satir.Cells["Telefon"].Value.ToString();
            txtEmail.Text = satir.Cells["Email"].Value.ToString();
            cmbRol.SelectedItem = satir.Cells["Rol"].Value.ToString();
            txtSifre.Clear(); // şifre güvenlik için kutuya doldurulmaz
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == "" || txtKullaniciAdi.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Ad soyad, kullanıcı adı ve şifre boş bırakılamaz!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                // Kullanıcı adı daha önce alınmış mı?
                SqlCommand kontrol = new SqlCommand(
                    "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@ad", baglanti);
                kontrol.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                int sayi = (int)kontrol.ExecuteScalar();

                if (sayi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten alınmış!");
                    return;
                }

                SqlCommand komut = new SqlCommand(
                    "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, AdSoyad, Telefon, Email, Rol) " +
                    "VALUES (@ad, @sifre, @adsoyad, @tel, @mail, @rol)", baglanti);
                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
                komut.Parameters.AddWithValue("@mail", txtEmail.Text);
                komut.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());
                komut.ExecuteNonQuery();

                MessageBox.Show("Kullanıcı eklendi!");
                Temizle();
                Listele();
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliId == 0)
            {
                MessageBox.Show("Önce tablodan bir kullanıcı seçin!");
                return;
            }

            if (txtAdSoyad.Text == "" || txtKullaniciAdi.Text == "")
            {
                MessageBox.Show("Ad soyad ve kullanıcı adı boş bırakılamaz!");
                return;
            }

            // Admin kendi yetkisini düşürmesin
            if (seciliId == Oturum.KullaniciId && cmbRol.SelectedItem.ToString() != "Admin")
            {
                MessageBox.Show("Kendi rolünüzü değiştiremezsiniz!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                // Aynı kullanıcı adını başka biri kullanıyor mu? (kendisi hariç)
                SqlCommand kontrol = new SqlCommand(
                    "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@ad AND Id<>@id", baglanti);
                kontrol.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                kontrol.Parameters.AddWithValue("@id", seciliId);
                int sayi = (int)kontrol.ExecuteScalar();

                if (sayi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adını başka biri kullanıyor!");
                    return;
                }

                // Şifre kutusu doluysa şifreyi de güncelle, boşsa eski şifre kalsın
                string sorgu = "UPDATE Kullanicilar SET KullaniciAdi=@ad, AdSoyad=@adsoyad, " +
                               "Telefon=@tel, Email=@mail, Rol=@rol";

                if (txtSifre.Text != "")
                {
                    sorgu = sorgu + ", Sifre=@sifre";
                }

                sorgu = sorgu + " WHERE Id=@id";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@ad", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
                komut.Parameters.AddWithValue("@mail", txtEmail.Text);
                komut.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@id", seciliId);

                if (txtSifre.Text != "")
                {
                    komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                }

                komut.ExecuteNonQuery();

                // Admin kendi kullanıcı adını değiştirdiyse oturumu da güncelle
                if (seciliId == Oturum.KullaniciId)
                {
                    Oturum.KullaniciAdi = txtKullaniciAdi.Text;
                }

                MessageBox.Show("Kullanıcı güncellendi!");
                Temizle();
                Listele();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliId == 0)
            {
                MessageBox.Show("Önce tablodan bir kullanıcı seçin!");
                return;
            }

            // Admin kendi hesabını silemesin
            if (seciliId == Oturum.KullaniciId)
            {
                MessageBox.Show("Kendi hesabınızı silemezsiniz!");
                return;
            }

            DialogResult cevap = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo);

            if (cevap == DialogResult.No)
            {
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("DELETE FROM Kullanicilar WHERE Id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", seciliId);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kullanıcı silindi!");
                Temizle();
                Listele();
            }
            catch (SqlException hata)
            {
                // 547: bu kullanıcıya bağlı ödünç kaydı var
                if (hata.Number == 547)
                {
                    MessageBox.Show("Bu kullanıcının ödünç kaydı olduğu için silinemez!");
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: " + hata.Message);
                }
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}