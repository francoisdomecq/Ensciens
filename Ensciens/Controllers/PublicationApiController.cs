using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ensciens.Models;
using System.Text.Json;
using Microsoft.Extensions.Primitives;

namespace Ensciens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationApiController : ControllerBase
    {
        private readonly EnsciensContext _context;

        public PublicationApiController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: api/PublicationApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublication()
        {
            List<Publication> listePublications = await _context.Publication.ToListAsync();
            return new JsonResult(listePublications, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // GET: api/PublicationApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublication(int id)
        {
            var publication = await _context.Publication.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return new JsonResult(publication, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // PUT: api/PublicationApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublication(int id, Publication publication)
        {
            if (id != publication.Id)
            {
                return BadRequest();
            }

            Publication publicationAModifier = await _context.Publication.FindAsync(id);
            if (!await IsAuthorized(publicationAModifier))
            {
                return Unauthorized();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/PublicationApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publication>> PostPublication(Publication publication)
        {
            _context.Publication.Add(publication);
            await _context.SaveChangesAsync();

            if (!await IsAuthorized(publication))
            {
                return Unauthorized();
            }

            return CreatedAtAction("GetPublication", new { id = publication.Id }, publication);
        }

        // DELETE: api/PublicationApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            if (!await IsAuthorized(publication))
            {
                return Unauthorized();
            }

            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationExists(int id)
        {
            return _context.Publication.Any(e => e.Id == id);
        }

        private async Task<bool> IsAuthorized(Publication publication)
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


            Publicateur publicateur = await _context.Publicateur.FindAsync(publication.PublicateurId);
            if (publicateur == null)
            {
                return false;
            }


            if (publicateur is Eleve eleve)
            {
                // Si le publicateur de la publication est un élève, seul lui peut modifier sa publication.
                return mailHeader[0] == eleve.Email && passwordHeader[0] == eleve.MotDePasse;
            }
            else if (publicateur is Club club)
            {
                ClubApiController clubApiController = new ClubApiController(_context);
                return await clubApiController.IsAuthorized(club, mailHeader[0], passwordHeader[0]);
            }
            else if (publicateur is Bureau bureau)
            {
                BureauApiController bureauApiController = new BureauApiController(_context);
                return await bureauApiController.IsAuthorized(bureau, mailHeader[0], passwordHeader[0]);
            }
            return false;

        }
    }
}
