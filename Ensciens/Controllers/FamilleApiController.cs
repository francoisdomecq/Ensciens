using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ensciens.Models;
using Microsoft.Extensions.Primitives;

namespace Ensciens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilleApiController : ControllerBase
    {
        private readonly EnsciensContext _context;
        private readonly static int ID_BDF = 65;

        public FamilleApiController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: api/FamilleApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Famille>>> GetFamille()
        {
            return await _context.Famille.ToListAsync();
        }

        // GET: api/FamilleApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Famille>> GetFamille(int id)
        {
            var famille = await _context.Famille.FindAsync(id);

            if (famille == null)
            {
                return NotFound();
            }

            return famille;
        }

        // PUT: api/FamilleApi/<id>?nbPoints=<nbPoints>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> AjoutePoints(int id, int nbPoints)
        {
            if (!await IsAuthorized())
            {
                return Unauthorized();
            }
            Famille famille = await _context.Famille.FindAsync(id);
            famille.Points += Math.Max(nbPoints,0);
            _context.Entry(famille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool FamilleExists(int id)
        {
            return _context.Famille.Any(e => e.Id == id);
        }

        private async Task<bool> IsAuthorized()
        {
            // Récupération des champs Mail et Password en entête de requête
            StringValues mailHeader = new StringValues();
            Request.Headers.TryGetValue("Mail", out mailHeader);
            StringValues passwordHeader = new StringValues();
            Request.Headers.TryGetValue("Password", out passwordHeader);
            // Pas d'autorisation à l'API si n'y a pas exactement 1 champ mail et password
            if (mailHeader.Count != 1 || passwordHeader.Count != 1)
            {
                return false;
            }

            // Sont autorisés à attribuer des points les Respo Famille
            Bureau bureauDesFamilles = await _context.Bureau.FindAsync(ID_BDF);
            BureauApiController bureauApiController = new BureauApiController(_context);
            return await bureauApiController.IsAuthorized(bureauDesFamilles, mailHeader[0], passwordHeader[0]);
        }
    }
}
