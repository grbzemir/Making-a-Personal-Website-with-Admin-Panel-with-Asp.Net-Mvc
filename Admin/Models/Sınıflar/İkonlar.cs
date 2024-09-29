using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Sınıflar
{
    public class İkonlar
    {
        [Key]
        public int Id { get; set; }
        public string İkon { get; set; }
        public string Link { get; set; }
    }
}
