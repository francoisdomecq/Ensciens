using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ensciens.Models
{
    public class Publication
    {
        public int Id { get; set; }



        [StringLength(50, MinimumLength = 4), Required]
        public string Titre { get; set; }

        [StringLength(500, MinimumLength = 1), Required]
        public string Contenu { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DatePublication { get; set; }

        public string Medias { get; set; }

        public ICollection<Commentaire> Commentaires { get; set; }

        public Evenement Evenement { get; set; }
        [Display(Name = "Évènement associé")]
        public int? EvenementId { get; set; }

        public int PublicateurId { get; set; }
        public Publicateur Publicateur { get; set; }
    }
}
