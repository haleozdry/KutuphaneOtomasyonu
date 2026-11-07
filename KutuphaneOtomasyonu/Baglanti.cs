using System.Data.SqlClient;

namespace KutuphaneOtomasyonu
{
    public static class Baglanti
    {
        public static SqlConnection BaglantiGetir()
        {
            string adres = @"Data Source=.\SQLEXPRESS;Initial Catalog=KutuphaneDB;Integrated Security=True";
            return new SqlConnection(adres);
        }
    }
}