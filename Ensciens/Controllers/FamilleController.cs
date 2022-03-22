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
    public class FamilleController : Controller
    {
        private readonly EnsciensContext _context;

        public FamilleController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: Famille
        public async Task<IActionResult> Index()
        {
            return View(await _context.Famille.ToListAsync());
        }

        // GET: Famille/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famille = await _context.Famille
                .FirstOrDefaultAsync(m => m.Id == id);
            if (famille == null)
            {
                return NotFound();
            }

            return View(famille);
        }

        private bool FamilleExists(int id)
        {
            return _context.Famille.Any(e => e.Id == id);
        }
    }
}
