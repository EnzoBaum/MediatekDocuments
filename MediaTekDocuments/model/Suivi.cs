
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi (Etape de suivi d'une commande)
    /// </summary>
    public class Suivi
    {
        public string Id { get; set; }
        public string Libelle { get; set; }

        public Suivi(string id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }
    }
}