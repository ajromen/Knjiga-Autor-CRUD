using KnjigaAutorCRUD.Data;
using KnjigaAutorCRUD.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly AutorKnjigaDbContext _context;

        public KnjigeController(AutorKnjigaDbContext context)
        {
            _context = context;
        }

        public  async Task<IActionResult> Index()
        {
            var knjiga= await _context.Knjige.ToListAsync();
            return View(knjiga);
        }

        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("Id,Naslov,GodinaIzdanja")] Knjiga knjiga)
        {
            
            if (ModelState.IsValid)
            {
                _context.Knjige.Add(knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(knjiga);
        }

    }
}
