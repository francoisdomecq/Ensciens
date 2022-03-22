using System;
using System.ComponentModel.DataAnnotations;
namespace Ensciens.Models
{
    public class LienClubEleve
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 4), Required]
        public string Role { get; set; }
        public Eleve Eleve { get; set; }

        public int EleveId { get; set; }
        public Club Club { get; set; }

        public int ClubId { get; set; }

    }
}