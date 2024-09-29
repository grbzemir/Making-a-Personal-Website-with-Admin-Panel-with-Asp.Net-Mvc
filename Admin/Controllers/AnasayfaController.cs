using Admin.Models.Sınıflar;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Admin.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly Context _context;

        public AnasayfaController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deger = _context.Anasayfas.ToList();
            return View(deger);
        }

        public PartialViewResult İkonlar()
        {
            var deger = _context.İkons.ToList();  
            return PartialView(deger);  
        }
    }
}
