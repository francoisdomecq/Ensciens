using System;
using System.ComponentModel.DataAnnotations;
namespace Ensciens.Models
{
    public class Club : Organisateur
    {
        public override int Id { get; set; }

        public override string Nom { get; set; }

        //Chaîne de caractère stockant un lien vers le logo
        public string Logo { get; set; }

        [StringLength(1000, MinimumLength = 4), Required]
        public string Description { get; set; }
        public Bureau Bureau { get; set; }
        public int BureauId { get; set; }
    }
}
