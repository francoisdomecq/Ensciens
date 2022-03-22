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
    public class PublicationController : Controller
    {
        private readonly EnsciensContext _context;

        public PublicationController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: Publication
        public async Task<IActionResult> Index()
        {
            var ensciensContext = _context.Publication.Include(p => p.Evenement).Include(p => p.Publicateur);
            return View(await ensciensContext.ToListAsync());
        }

        // GET: Publication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .Include(p => p.Evenement)
                .Include(p => p.Commentaires)
                .ThenInclude(c => c.Publicateur)
                .Include(p => p.Publicateur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publication/Create
        public IActionResult Create()
        {
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Titre");
            return View();
        }

        // POST: Publication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Contenu,DatePublication,Medias,EvenementId")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Description", publication.EvenementId);
            return View(publication);
        }

        // GET: Publication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Titre", publication.EvenementId);
            return View(publication);
        }

        // POST: Publication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Contenu,DatePublication,Medias,EvenementId")] Publication publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.Id))
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
            ViewData["EvenementId"] = new SelectList(_context.Evenement, "Id", "Description", publication.EvenementId);
            return View(publication);
        }

        // GET: Publication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .Include(p => p.Evenement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publication.FindAsync(id);
            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publication.Any(e => e.Id == id);
        }
    }
}
