using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class FrmKitaplar : Form
    {
        // Tablodan seçilen kitabın Id'si (0 ise kimse seçilmemiş)
        int seciliId = 0;

        public FrmKitaplar()
        {
            InitializeComponent();
        }

        private void FrmKitaplar_Load(object sender, EventArgs e)
        {
            if (Oturum.Rol == "Admin")
            {
                // Admin kitap yönetir, ödünç almaz
                btnOduncAl.Visible = false;
            }
            else
            {
                // Kullanıcı yönetim panelini görmez
                grpYonetim.Visible = false;
            }

            Listele("");
        }

        // Kitapları tabloya doldurur, aranan yazıya göre filtreler
        private void Listele(string aranan)
        {
            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                SqlDataAdapter adaptor = new SqlDataAdapter(
                    "SELECT Id, KitapAdi, Yazar, Kategori, Adet FROM Kitaplar " +
                    "WHERE KitapAdi LIKE @ara OR Yazar LIKE @ara OR Kategori LIKE @ara", baglanti);
                adaptor.SelectCommand.Parameters.AddWithValue("@ara", "%" + aranan + "%");

                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                dgvKitaplar.DataSource = tablo;

                dgvKitaplar.ClearSelection();
                dgvKitaplar.CurrentCell = null;

                // Id sütununu gizle, başlıkları düzelt
                dgvKitaplar.Columns["Id"].Visible = false;
                dgvKitaplar.Columns["KitapAdi"].HeaderText = "Kitap Adı";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
        }

        // Kutuları temizler
        private void Temizle()
        {
            txtKitapAdi.Clear();
            txtYazar.Clear();
            txtKategori.Clear();
            txtAdet.Clear();
            seciliId = 0;
        }

        // Arama kutusuna her harf yazıldığında listeyi yeniler
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            Listele(txtAra.Text);
        }

        // Tabloda bir satıra tıklayınca bilgileri kutulara doldurur
        private void dgvKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // başlığa tıklandıysa bir şey yapma
            }

            DataGridViewRow satir = dgvKitaplar.Rows[e.RowIndex];
            seciliId = Convert.ToInt32(satir.Cells["Id"].Value);
            txtKitapAdi.Text = satir.Cells["KitapAdi"].Value.ToString();
            txtYazar.Text = satir.Cells["Yazar"].Value.ToString();
            txtKategori.Text = satir.Cells["Kategori"].Value.ToString();
            txtAdet.Text = satir.Cells["Adet"].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Kitap adı boş mu? Adet sayı mı?
            int adet;
            if (txtKitapAdi.Text == "" || !int.TryParse(txtAdet.Text, out adet) || adet < 0)
            {
                MessageBox.Show("Kitap adını ve geçerli bir adet girin!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                    "INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (@ad, @yazar, @kategori, @adet)", baglanti);
                komut.Parameters.AddWithValue("@ad", txtKitapAdi.Text);
                komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
                komut.Parameters.AddWithValue("@kategori", txtKategori.Text);
                komut.Parameters.AddWithValue("@adet", adet);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap eklendi!");
                Temizle();
                Listele(txtAra.Text);
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
                MessageBox.Show("Önce tablodan bir kitap seçin!");
                return;
            }

            int adet;
            if (txtKitapAdi.Text == "" || !int.TryParse(txtAdet.Text, out adet) || adet < 0)
            {
                MessageBox.Show("Kitap adını ve geçerli bir adet girin!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand(
                    "UPDATE Kitaplar SET KitapAdi=@ad, Yazar=@yazar, Kategori=@kategori, Adet=@adet WHERE Id=@id", baglanti);
                komut.Parameters.AddWithValue("@ad", txtKitapAdi.Text);
                komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
                komut.Parameters.AddWithValue("@kategori", txtKategori.Text);
                komut.Parameters.AddWithValue("@adet", adet);
                komut.Parameters.AddWithValue("@id", seciliId);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap güncellendi!");
                Temizle();
                Listele(txtAra.Text);
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
                MessageBox.Show("Önce tablodan bir kitap seçin!");
                return;
            }

            // Emin misin sorusu
            DialogResult cevap = MessageBox.Show("Bu kitabı silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo);

            if (cevap == DialogResult.No)
            {
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("DELETE FROM Kitaplar WHERE Id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", seciliId);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap silindi!");
                Temizle();
                Listele(txtAra.Text);
            }
            catch (SqlException hata)
            {
                // 547 numaralı hata: bu kitaba bağlı ödünç kaydı var
                if (hata.Number == 547)
                {
                    MessageBox.Show("Bu kitabın ödünç kaydı olduğu için silinemez!");
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

        private void btnOduncAl_Click(object sender, EventArgs e)
        {
            if (seciliId == 0)
            {
                MessageBox.Show("Önce tablodan bir kitap seçin!");
                return;
            }

            SqlConnection baglanti = Baglanti.BaglantiGetir();

            try
            {
                baglanti.Open();

                // 1) Kitaptan stokta var mı?
                SqlCommand stokKomut = new SqlCommand("SELECT Adet FROM Kitaplar WHERE Id=@id", baglanti);
                stokKomut.Parameters.AddWithValue("@id", seciliId);
                int stok = (int)stokKomut.ExecuteScalar();

                if (stok <= 0)
                {
                    MessageBox.Show("Bu kitabın stokta kopyası kalmadı!");
                    return;
                }

                // 2) Bu kullanıcı aynı kitabı zaten almış ve iade etmemiş mi?
                SqlCommand varMiKomut = new SqlCommand(
                    "SELECT COUNT(*) FROM Odunc WHERE KitapId=@kitap AND KullaniciId=@kullanici AND IadeTarihi IS NULL", baglanti);
                varMiKomut.Parameters.AddWithValue("@kitap", seciliId);
                varMiKomut.Parameters.AddWithValue("@kullanici", Oturum.KullaniciId);
                int varMi = (int)varMiKomut.ExecuteScalar();

                if (varMi > 0)
                {
                    MessageBox.Show("Bu kitabı zaten ödünç aldınız, önce iade etmelisiniz!");
                    return;
                }

                // 3) Ödünç kaydını ekle ve stoğu 1 azalt
                DateTime verilis = DateTime.Now;
                DateTime teslim = DateTime.Now.AddDays(14);

                SqlCommand ekle = new SqlCommand(
                    "INSERT INTO Odunc (KitapId, KullaniciId, VerilisTarihi, TeslimTarihi) " +
                    "VALUES (@kitap, @kullanici, @verilis, @teslim); " +
                    "UPDATE Kitaplar SET Adet = Adet - 1 WHERE Id=@kitap", baglanti);
                ekle.Parameters.AddWithValue("@kitap", seciliId);
                ekle.Parameters.AddWithValue("@kullanici", Oturum.KullaniciId);
                ekle.Parameters.AddWithValue("@verilis", verilis);
                ekle.Parameters.AddWithValue("@teslim", teslim);
                ekle.ExecuteNonQuery();

                MessageBox.Show("Kitap ödünç alındı! Son teslim tarihi: " + teslim.ToString("dd.MM.yyyy"));
                Temizle();
                Listele(txtAra.Text);
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

        private void FrmKitaplar_Click(object sender, EventArgs e)
        {
            dgvKitaplar.ClearSelection();
            dgvKitaplar.CurrentCell = null;
            Temizle();
        }
    }
}