using System;
using System.ComponentModel.DataAnnotations;

namespace Ensciens.Models
{
    public enum Couleur
    {
        Orange,
        Jaune,
        Vert,
        Rouge,
        Bleu,
    }
    public class Famille
    {
        public int Id { get; set; }

        [Display(Name = "Nombre d'élèves")]
        public int NombreEleves { get; set; }
        public int Points { get; set; }
        public Couleur Couleur { get; set; }
    }
}
