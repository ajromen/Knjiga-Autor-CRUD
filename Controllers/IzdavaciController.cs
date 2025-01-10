using KnjigaAutorCRUD.Data;
using KnjigaAutorCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Controllers
{
    public class IzdavaciController : Controller
    {
        private AutorKnjigaDbContext _context;

        public IzdavaciController(AutorKnjigaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var izdavaci = await _context.Izdavaci.ToListAsync();
            return View(izdavaci);
        }

        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("Id,Ime")] Izdavac izdavac)
        {
            if (ModelState.IsValid)
            {
                _context.Izdavaci.Add(izdavac);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Izmeni(int id)
        {
            var izdavac = await _context.Izdavaci.FirstOrDefaultAsync(x => x.Id == id);
            return View(izdavac);
        }

        [HttpPost]
        public async Task<IActionResult> Izmeni([Bind("Id,Ime")] Izdavac izdavac)
        {
            if (ModelState.IsValid)
            {
                _context.Update(izdavac);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Obrisi(int id)
        {
            var izdavac = await _context.Izdavaci.FirstOrDefaultAsync(x => x.Id == id);
            return View(izdavac);
        }

        [HttpPost]
        public async Task<IActionResult> Obrisi([Bind("Id,Ime")] Izdavac izdavac)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(izdavac);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
