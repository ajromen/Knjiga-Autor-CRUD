using KnjigaAutorCRUD.Data;
using KnjigaAutorCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KnjigaAutorCRUD.Controllers
{
    public class AutoriKnjigeController : Controller
    {
        private readonly AutorKnjigaDbContext _context;

        public AutoriKnjigeController(AutorKnjigaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var autor_knjiga = await _context.AutoriKnjige
                                                .Include(s => s.Knjiga)
                                                .Include(s => s.Autor)
                                                .ToListAsync();
            return View(autor_knjiga);
        }

        private void PopulateSelectLists()
        {
            var autori = _context.Autori
                                 .Select(a => new
                                 {
                                     a.Id,
                                     FullName = a.Ime + " " + a.Prezime
                                 })
                                 .ToList();

            ViewBag.Autori = new SelectList(autori, "Id", "FullName");
            ViewData["Knjige"] = new SelectList(_context.Knjige, "Id", "Naslov");
        }

        public IActionResult Dodaj()
        {
            PopulateSelectLists();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Dodaj([Bind("KnjigaId,AutorId")] AutorKnjiga autor_knjiga)
        {
            if (ModelState.IsValid)
            {
                _context.AutoriKnjige.Add(autor_knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");                
            }

            PopulateSelectLists();
            return View(autor_knjiga);
        }


        public async Task<IActionResult> Izmeni(int knjigaId, int autorId)
        {
            var autor_knjiga = await _context.AutoriKnjige
                .Include(ak => ak.Autor)
                .Include(ak => ak.Knjiga)
                .FirstOrDefaultAsync(ak => ak.KnjigaId == knjigaId && ak.AutorId == autorId);

            if (autor_knjiga == null)
            {
                return NotFound();
            }

            ViewData["Autori"] = new SelectList(_context.Autori, "Id", "Ime", autor_knjiga.AutorId);
            ViewData["Knjige"] = new SelectList(_context.Knjige, "Id", "Naslov", autor_knjiga.KnjigaId);
            return View(autor_knjiga);
        }

        [HttpPost]
        public async Task<IActionResult> Izmeni(int knjigaId, int autorId, [Bind("KnjigaId,AutorId")] AutorKnjiga autor_knjiga)
        {
            var stari_autor_knjiga = await _context.AutoriKnjige.FirstOrDefaultAsync(a=>a.KnjigaId==knjigaId && a.AutorId==autorId);
            if (ModelState.IsValid && stari_autor_knjiga!=null)
            {
                try
                {
                    _context.AutoriKnjige.Remove(stari_autor_knjiga);
                    await _context.SaveChangesAsync();
                    _context.AutoriKnjige.Add(autor_knjiga); 
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error updating the record: " + ex.Message);
                }
            }

            PopulateSelectLists();
            return View(autor_knjiga);
        }

        public async Task<IActionResult> Obrisi(int knjigaId, int autorId)
        {
            var autor_knjiga = await _context.AutoriKnjige
               .Include(ak => ak.Autor)
               .Include(ak => ak.Knjiga)
               .FirstOrDefaultAsync(ak => ak.KnjigaId == knjigaId && ak.AutorId == autorId);

            if (autor_knjiga == null)
            {
                return NotFound();
            }

            return View(autor_knjiga);
        }

        [HttpPost, ActionName("Obrisi")]
        public async Task<IActionResult> ObrisiConfirmed(int knjigaId,int autorId)
        {
            var autor_knjiga = await _context.AutoriKnjige.FirstOrDefaultAsync(ak => ak.KnjigaId == knjigaId && ak.AutorId == autorId);
            if (autor_knjiga != null)
            {
                _context.AutoriKnjige.Remove(autor_knjiga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            autor_knjiga = await _context.AutoriKnjige
               .Include(ak => ak.Autor)
               .Include(ak => ak.Knjiga)
               .FirstOrDefaultAsync(ak => ak.KnjigaId == knjigaId && ak.AutorId == autorId);
            return View(autor_knjiga);
        }
    }
}
