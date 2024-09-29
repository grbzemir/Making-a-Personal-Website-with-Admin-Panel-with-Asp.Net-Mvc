

using Microsoft.EntityFrameworkCore;

namespace Admin.Models.Sınıflar
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options): base(options)
        {
        }


       
        public DbSet<Admin> Admins { get; set; }
        public DbSet<İkonlar> İkons { get; set; }
        public DbSet<Anasayfa> Anasayfas { get; set; }

    }
}
