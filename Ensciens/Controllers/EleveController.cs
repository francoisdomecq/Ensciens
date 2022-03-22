using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ensciens.Models;

namespace Ensciens.Controllers
{
    public class EleveController : Controller
    {
        private readonly EnsciensContext _context;

        public EleveController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: Eleve
        public async Task<IActionResult> Index()
        {
            var ensciensContext = _context.Eleve.Include(e => e.Famille);
            return View(await ensciensContext.ToListAsync());
        }

        // GET: Eleve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve
                .Include(e => e.Famille)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // GET: Eleve/Create
        public IActionResult Create()
        {
            ViewData["FamilleId"] = new SelectList(_context.Set<Famille>(), "Id", "Couleur");
            return View();
        }

        // POST: Eleve/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,MotDePasse,PhotoProfil,Promotion,FamilleId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilleId"] = new SelectList(_context.Set<Famille>(), "Id", "Id", eleve.FamilleId);
            return View(eleve);
        }

        // GET: Eleve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }
            ViewData["FamilleId"] = new SelectList(_context.Set<Famille>(), "Id", "Couleur");
            return View(eleve);
        }

        // POST: Eleve/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,MotDePasse,PhotoProfil,Promotion,FamilleId")] Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleveExists(eleve.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamilleId"] = new SelectList(_context.Set<Famille>(), "Id", "Id", eleve.FamilleId);
            return View(eleve);
        }

        // GET: Eleve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleve
                .Include(e => e.Famille)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // POST: Eleve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
            _context.Eleve.Remove(eleve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleveExists(int id)
        {
            return _context.Eleve.Any(e => e.Id == id);
        }
    }
}
