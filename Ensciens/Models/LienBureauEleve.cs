using System;
using System.ComponentModel.DataAnnotations;
namespace Ensciens.Models
{
    public class LienBureauEleve
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 4), Required]
        public string Role { get; set; }
        public Eleve Eleve { get; set; }
        public int EleveId { get; set; }
        public Bureau Bureau { get; set; }
        public int BureauId { get; set; }
    }
}