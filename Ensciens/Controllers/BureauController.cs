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
    public class BureauController : Controller
    {
        private readonly EnsciensContext _context;

        public BureauController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: Bureau
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bureau.ToListAsync());
        }

        // GET: Bureau/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bureau == null)
            {
                return NotFound();
            }

            return View(bureau);
        }

        // GET: Bureau/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bureau/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Logo,Description")] Bureau bureau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bureau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bureau);
        }

        // GET: Bureau/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureau.FindAsync(id);
            if (bureau == null)
            {
                return NotFound();
            }
            return View(bureau);
        }

        // POST: Bureau/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Logo,Description")] Bureau bureau)
        {
            if (id != bureau.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bureau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BureauExists(bureau.Id))
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
            return View(bureau);
        }

        // GET: Bureau/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bureau = await _context.Bureau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bureau == null)
            {
                return NotFound();
            }

            return View(bureau);
        }

        // POST: Bureau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bureau = await _context.Bureau.FindAsync(id);
            _context.Bureau.Remove(bureau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BureauExists(int id)
        {
            return _context.Bureau.Any(e => e.Id == id);
        }
    }
}
