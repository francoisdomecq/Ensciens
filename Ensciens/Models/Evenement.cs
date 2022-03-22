using System;
using System.ComponentModel.DataAnnotations;

namespace Ensciens.Models
{
    public class Evenement
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 4), Required]
        public string Titre { get; set; }


        [StringLength(100, MinimumLength = 4), Required]
        public string Lieu { get; set; }


        [StringLength(500, MinimumLength = 4), Required]
        public string Description { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int OrganisateurId { get; set; }

        public Organisateur Organisateur { get; set; }

    }
}
