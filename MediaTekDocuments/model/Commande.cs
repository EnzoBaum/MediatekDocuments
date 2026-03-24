using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Commande (Commande d'un livre ou d'un DVD)
    /// </summary>
    public class Commande
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public double Montant { get; set; }
        public int NbExemplaire { get; set; }
        public string IdLivreDvd { get; set; }
        public string IdSuivi { get; set; }

        public Commande(string id, DateTime dateCommande, double montant, int nbExemplaire, string idLivreDvd, string idSuivi)
        {
            Id = id;
            DateCommande = dateCommande;
            Montant = montant;
            NbExemplaire = nbExemplaire;
            IdLivreDvd = idLivreDvd;
            IdSuivi = idSuivi;
        }
    }
}
