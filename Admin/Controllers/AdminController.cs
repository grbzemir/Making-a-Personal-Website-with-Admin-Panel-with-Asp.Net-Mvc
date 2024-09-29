using Admin.Models.Sınıflar;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AdminController : Controller
    {

        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var deger = _context.Anasayfas.ToList();
            return View(deger);
        }

        public IActionResult AnaSayfaGetir(int Id)
        {
            var ag = _context.Anasayfas.Find(Id);
            return View("AnaSayfaGetir", ag);
        }

        public IActionResult AnaSayfaGüncelle(Anasayfa x)
        {

            var ag = _context.Anasayfas.Find(x.Id);
            ag.Profil = x.Profil;
            ag.İsim = x.İsim;
            ag.Unvan = x.Unvan;
            ag.Aciklama = x.Aciklama;
            ag.İletisim = x.İletisim;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult İkonListesi() 
        {
            var deger = _context.İkons.ToList();
            return View(deger);
        }

    }
}
