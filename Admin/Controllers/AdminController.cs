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
    }
}
