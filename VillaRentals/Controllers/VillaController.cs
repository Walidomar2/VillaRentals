using Microsoft.AspNetCore.Mvc;
using VillaRentals.Domain.Entities;
using VillaRentals.Infrastructure.Data;

namespace VillaRentals.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();

            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {

            if (ModelState.IsValid)
            {
                _context.Villas.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == villaId);

            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(villa);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {

            if (ModelState.IsValid && obj.Id > 0)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == villaId);

            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            var objFromDb = _context.Villas.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _context.Villas.Remove(objFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
