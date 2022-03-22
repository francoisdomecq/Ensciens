using System;

namespace Ensciens.Models
{
    public abstract class Publicateur
    {
        public abstract int Id { get; set; }

        public abstract string Nom { get; set; }

        public string Prenom { get; set; }

        void ModifiePublication(Publication publication)
        {
            throw new NotImplementedException();
        }
        Publication Publie(String titre, String contenu)
        {
            throw new NotImplementedException();
        }
        void SupprimePublication(Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}
