-- Kütüphane Otomasyonu veritabanı kurulum betiği

IF DB_ID('KutuphaneDB') IS NULL
    CREATE DATABASE KutuphaneDB;
GO

USE KutuphaneDB;
GO

-- Varsa eski tabloları sil (sıra önemli)
IF OBJECT_ID('Odunc') IS NOT NULL DROP TABLE Odunc;
IF OBJECT_ID('Kullanicilar') IS NOT NULL DROP TABLE Kullanicilar;
IF OBJECT_ID('Kitaplar') IS NOT NULL DROP TABLE Kitaplar;
GO

CREATE TABLE Kitaplar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    KitapAdi NVARCHAR(100) NOT NULL,
    Yazar NVARCHAR(100),
    Kategori NVARCHAR(50),
    Adet INT NOT NULL
);

CREATE TABLE Kullanicilar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    KullaniciAdi NVARCHAR(50) NOT NULL UNIQUE,
    Sifre NVARCHAR(50) NOT NULL,
    AdSoyad NVARCHAR(100) NOT NULL,
    Telefon NVARCHAR(20),
    Email NVARCHAR(100),
    Rol NVARCHAR(20) NOT NULL DEFAULT 'Kullanici'
);

CREATE TABLE Odunc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    KitapId INT NOT NULL FOREIGN KEY REFERENCES Kitaplar(Id),
    KullaniciId INT NOT NULL FOREIGN KEY REFERENCES Kullanicilar(Id),
    VerilisTarihi DATETIME NOT NULL,
    TeslimTarihi DATETIME NOT NULL,
    IadeTarihi DATETIME NULL
);
GO

-- Örnek veriler
INSERT INTO Kullanicilar (KullaniciAdi, Sifre, AdSoyad, Rol)
VALUES ('admin', '1234', N'Kütüphane Yöneticisi', 'Admin');
INSERT INTO Kullanicilar (KullaniciAdi, Sifre, AdSoyad, Rol)
VALUES ('ali', '1234', N'Ali Yılmaz', 'Kullanici');

INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (N'Sefiller', N'Victor Hugo', N'Roman', 3);
INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (N'Suç ve Ceza', N'Dostoyevski', N'Roman', 2);
INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (N'Nutuk', N'Mustafa Kemal Atatürk', N'Tarih', 5);
INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (N'Küçük Prens', N'Antoine de Saint-Exupéry', N'Çocuk', 4);
INSERT INTO Kitaplar (KitapAdi, Yazar, Kategori, Adet) VALUES (N'Sapiens', N'Yuval Noah Harari', N'Bilim', 1);
GO