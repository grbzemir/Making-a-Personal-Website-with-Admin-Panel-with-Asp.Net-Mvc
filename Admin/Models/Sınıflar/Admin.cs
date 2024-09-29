using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set;}
        public string Sifre { get; set; }

    }
}
