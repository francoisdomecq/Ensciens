using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ensciens.Models;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

namespace Ensciens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementApiController : ControllerBase
    {
        private readonly EnsciensContext _context;

        public EvenementApiController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: api/EvenementApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evenement>>> GetEvenement()
        {
            var evenement = await _context.Evenement.ToListAsync();
            return new JsonResult(evenement, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // GET: api/EvenementApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evenement>> GetEvenement(int id)
        {
            var evenement = await _context.Evenement.FindAsync(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return evenement;
        }

        // PUT: api/EvenementApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenement(int id, Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return BadRequest();
            }

            Evenement evenementAModifier = await _context.Evenement.FindAsync(id);
            if (!await IsAuthorized(evenement))
            {
                return Unauthorized();
            }

            _context.Entry(evenement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
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

        // POST: api/EvenementApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
        {
            _context.Evenement.Add(evenement);
            await _context.SaveChangesAsync();

            if (!await IsAuthorized(evenement))
            {
                return Unauthorized();
            }

            return CreatedAtAction("GetEvenement", new { id = evenement.Id }, evenement);
        }

        // DELETE: api/EvenementApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvenement(int id)
        {
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            if (!await IsAuthorized(evenement))
            {
                return Unauthorized();
            }

            _context.Evenement.Remove(evenement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvenementExists(int id)
        {
            return _context.Evenement.Any(e => e.Id == id);
        }

        private async Task<bool> IsAuthorized(Evenement evenement)
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

            Publicateur organisateur = await _context.Publicateur.FindAsync(evenement.OrganisateurId);
            if (organisateur == null)
            {
                return false;
            }


            if (evenement.Organisateur is Club club)
            {
                ClubApiController clubApiController = new ClubApiController(_context);
                return await clubApiController.IsAuthorized(club, mailHeader[0], passwordHeader[0]);
            }
            else if (evenement.Organisateur is Bureau bureau)
            {
                BureauApiController bureauApiController = new BureauApiController(_context);
                return await bureauApiController.IsAuthorized(bureau, mailHeader[0], passwordHeader[0]);
            }

            return false;

        }
    }
}
