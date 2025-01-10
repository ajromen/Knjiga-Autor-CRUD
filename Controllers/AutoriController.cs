using KnjigaAutorCRUD.Data;
using KnjigaAutorCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Controllers
{
    public class AutoriController : Controller
    {
        private AutorKnjigaDbContext _context;

        public AutoriController(AutorKnjigaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var autor = await _context.Autori.ToListAsync();
            return View(autor);
        }

        public IActionResult Dodaj() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("Id,Ime,Prezime")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autori.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Izmeni(int id)
        {
            var autor = await _context.Autori.FirstOrDefaultAsync(x => x.Id == id); 
            return View(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Izmeni([Bind("Id,Ime,Prezime")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Obrisi(int id)
        {
            var autor = await _context.Autori.FirstOrDefaultAsync(x => x.Id == id);
            return View(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Obrisi([Bind("Id,Ime,Prezime")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
