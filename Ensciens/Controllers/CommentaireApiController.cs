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
    public class CommentaireApiController : ControllerBase
    {
        private readonly EnsciensContext _context;

        public CommentaireApiController(EnsciensContext context)
        {
            _context = context;
        }

        // GET: api/CommentaireApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaire()
        {
            var commentaire = await _context.Commentaire.ToListAsync();

            return new JsonResult(commentaire, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // GET: api/CommentaireApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
            var commentaire = await _context.Commentaire.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }

        // PUT: api/CommentaireApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (id != commentaire.Id)
            {
                return BadRequest();
            }
            Commentaire commentaireAModifier = await _context.Commentaire.FindAsync(id);
            if (!await IsAuthorized(commentaireAModifier))
            {
                return Unauthorized();
            }

            _context.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/CommentaireApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commentaire>> PostCommentaire(Commentaire commentaire)
        {
            _context.Commentaire.Add(commentaire);
            await _context.SaveChangesAsync();

            if (!await IsAuthorized(commentaire))
            {
                return Unauthorized();
            }

            return CreatedAtAction("GetCommentaire", new { id = commentaire.Id }, commentaire);
        }

        // DELETE: api/CommentaireApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            var commentaire = await _context.Commentaire.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            if (!await IsAuthorized(commentaire))
            {
                return Unauthorized();
            }

            _context.Commentaire.Remove(commentaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentaireExists(int id)
        {
            return _context.Commentaire.Any(e => e.Id == id);
        }

        private async Task<bool> IsAuthorized(Commentaire commentaire)
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

            Publicateur publicateur = await _context.Publicateur.FindAsync(commentaire.PublicateurId);
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
