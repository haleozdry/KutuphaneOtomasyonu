# Kütüphane Otomasyonu

Görsel Programlama dersi dönem projesi olarak geliştirilmiş, C# Windows Forms tabanlı bir kütüphane otomasyon uygulamasıdır. Kitap, kullanıcı ve ödünç işlemleri bir SQL Server veritabanında tutulur. Kullanıcının rolüne göre (Admin / Kullanıcı) arayüz ve yetkiler değişir.

**Hazırlayan:** Firdevs Hale Özderya 
**Ders:** Görsel Programlama 

## Özellikler

### Admin (kütüphaneci)
- Kitap ekleme, güncelleme, silme ve arama
- Kullanıcı ekleme, güncelleme ve silme (rol atama dahil)
- Tüm ödünç kayıtlarını görüntüleme, geciken kitapları takip etme

### Kullanıcı (üye)
- Giriş yapma ve kayıt olma
- Kitapları listeleme ve arama
- Kitap ödünç alma (14 gün süreyle) ve iade etme
- Sadece kendi ödünç kayıtlarını görüntüleme

### İş kuralları
- Stokta kopyası kalmayan kitap ödünç alınamaz.
- Bir kullanıcı, iade etmediği kitabı tekrar ödünç alamaz.
- Ödünç alınca stok azalır, iade edilince artar.
- Son teslim tarihi geçmiş ve iade edilmemiş kayıtlar "Gecikmiş" olarak kırmızı gösterilir.
- Ödünç kaydı olan kitap veya kullanıcı silinemez.
- Admin kendi hesabını silemez ve kendi rolünü düşüremez.

## Kullanılan Teknolojiler

- C# / Windows Forms (.NET Framework 4.8)
- SQL Server Express
- ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)
- Parametreli sorgular (SQL Injection'a karşı)

## Veritabanı

Veritabanı adı `KutuphaneDB`, üç tablodan oluşur:

| Tablo | Açıklama |
|---|---|
| `Kitaplar` | Kitap bilgileri ve stok adedi |
| `Kullanicilar` | Giriş bilgileri, kişisel bilgiler ve rol (Admin / Kullanici) |
| `Odunc` | Hangi kullanıcı hangi kitabı ne zaman aldı, ne zaman iade etti |

## Kurulum

1. Depoyu indir veya klonla.
2. SQL Server Management Studio'yu (SSMS) aç ve `Database/KutuphaneDB.sql` dosyasını çalıştır. Bu betik veritabanını, tabloları ve örnek verileri oluşturur.
3. Visual Studio ile `KutuphaneOtomasyonu.slnx` dosyasını aç.
4. Sunucu adın farklıysa `Baglanti.cs` içindeki `Data Source=.\SQLEXPRESS` kısmını kendi sunucu adınla değiştir.
5. `F5` ile uygulamayı çalıştır.

## Örnek Giriş Bilgileri

| Rol | Kullanıcı adı | Şifre |
|---|---|---|
| Admin | `admin` | `1234` |
| Kullanıcı | `hale` | `1231` |

## Proje Yapısı

```
KutuphaneOtomasyonu/
├── Database/
│   └── KutuphaneDB.sql        # Veritabanı kurulum betiği
└── KutuphaneOtomasyonu/
    ├── Baglanti.cs            # Veritabanı bağlantısı
    ├── Oturum.cs              # Giriş yapan kullanıcının bilgileri
    ├── FrmGiris.cs            # Giriş ekranı
    ├── FrmKayit.cs            # Kayıt ol ekranı
    ├── FrmAnaMenu.cs          # Role göre değişen ana menü
    ├── FrmKitaplar.cs         # Kitap listeleme, arama, yönetim, ödünç alma
    ├── FrmOdunc.cs            # Ödünç kayıtları ve iade
    └── FrmKullanicilar.cs     # Kullanıcı yönetimi (sadece Admin)
```