using System;

namespace Ensciens.Models
{
    public abstract class Organisateur : Publicateur
    {
        Evenement CreerEvenement()
        {
            throw new NotImplementedException();
        }

        bool AnnulerEvenement()
        {
            throw new NotImplementedException();
        }

        void ModifierEvenement(Evenement evenement, String contenu)
        {
            throw new NotImplementedException();
        }
    }
}
