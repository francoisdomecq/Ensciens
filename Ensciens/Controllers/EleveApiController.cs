using System;
using System.Security;
using System.Net;
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
    public class EleveApiController : ControllerBase
    {
        private readonly EnsciensContext _context;

        public EleveApiController(EnsciensContext context)
        {
            _context = context;
        }


        // GET: api/EleveApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleve()
        {
            List<Eleve> listeEleves = await _context.Eleve.ToListAsync();
            foreach (Eleve eleve in listeEleves)
                eleve.MotDePasse = SecurePassword(eleve.MotDePasse);
            return new JsonResult(listeEleves, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // GET: api/EleveApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);

            if (eleve == null)
            {
                return NotFound();
            }

            eleve.MotDePasse = SecurePassword(eleve.MotDePasse);

            return new JsonResult(eleve, new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });
        }

        // PUT: api/EleveApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(int id, Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return BadRequest();
            }

            if (!IsAuthorized(eleve))
            {
                return Unauthorized();
            }

            _context.Entry(eleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
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

        // POST: api/EleveApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve)
        {
            _context.Eleve.Add(eleve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleve", new { id = eleve.Id }, eleve);
        }

        // DELETE: api/EleveApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleve(int id)
        {
            var eleve = await _context.Eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            if (!IsAuthorized(eleve))
            {
                return Unauthorized();
            }

            _context.Eleve.Remove(eleve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleveExists(int id)
        {
            return _context.Eleve.Any(e => e.Id == id);
        }

        //Cette fonction renvoie une chaine de caractère de la longueur du mot de passe. Cependant, tous les caractères sont remplacés par des * 
        private string SecurePassword(string password)
        {
            return new String('*', password.Length);
        }

        // On vérifie que l'élève à modifier a les mêmes identifiants et mdp que ceux en entête
        // de requête.
        private bool IsAuthorized(Eleve eleve)
        {
            StringValues mailHeader = new StringValues();
            Request.Headers.TryGetValue("Mail", out mailHeader);
            StringValues passwordHeader = new StringValues();
            Request.Headers.TryGetValue("Password", out passwordHeader);

            return mailHeader.Count == 1
                && passwordHeader.Count == 1
                && mailHeader[0] == eleve.Email
                && passwordHeader[0] == eleve.MotDePasse;

        }


    }
}
