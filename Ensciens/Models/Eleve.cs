using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Ensciens.Models
{
    public class Eleve : Publicateur
    {
        public override int Id { get; set; }

        public override string Nom { get; set; }



        [Required, EmailAddress]
        public string Email { get; set; }



        [Display(Name = "Mot de passe"), Required, DataType(DataType.Password)]
        public string MotDePasse { get; set; }


        //PhotoProfil est une chaîne de caractère qui représente le lien vers l'image de la photo de profil de l'élève
        [Display(Name = "Photo de profil")]
        public string PhotoProfil { get; set; }

        public string Promotion { get; set; }

        public Famille Famille { get; set; }

        [Display(Name = "Famille")]
        public int FamilleId { get; set; }
    }
}
