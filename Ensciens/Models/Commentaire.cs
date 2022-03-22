using System;
using System.ComponentModel.DataAnnotations;
namespace Ensciens.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string Contenu { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateEnvoi { get; set; }

        public Publicateur Publicateur { get; set; }
        public int PublicateurId { get; set; }
    }
}
