using System;
using System.ComponentModel.DataAnnotations;
using Ensciens.Models;

namespace Ensciens.Models
{
    public class Bureau : Organisateur
    {
        public override int Id { get; set; }

        public override string Nom { get; set; }

        //Chaîne de caractère stockant un lien vers le logo
        public string Logo { get; set; }
        public string Description { get; set; }

    }
}
