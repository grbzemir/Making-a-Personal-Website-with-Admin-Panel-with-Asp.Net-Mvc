using Admin.Models.Sınıflar;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        [HttpGet]
        public IActionResult YeniIkon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniIkon(İkonlar p)
        {

            _context.İkons.Add(p);
            _context.SaveChanges();
            return RedirectToAction("İkonListesi");
        }

        public IActionResult İkonGetir(int Id)
        {

            var ig = _context.İkons.Find(Id);
            return View("İkonGetir", ig);

        }

        public IActionResult İkonGüncelle(İkonlar x)
          {
    
                var ig = _context.İkons.Find(x.Id);
                ig.İkon = x.İkon;
                ig.Link = x.Link;
                _context.SaveChanges();
                return RedirectToAction("İkonListesi");
    
          }

        public IActionResult İkonSil(int Id)
        {

            var sl = _context.İkons.Find(Id);
            _context.İkons.Remove(sl);
            _context.SaveChanges();
            return RedirectToAction("İkonListesi");

        }


    }
}
