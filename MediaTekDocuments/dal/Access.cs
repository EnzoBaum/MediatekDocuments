using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                authenticationString = "admin:adminpwd";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }

        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// Retourne la ou les commande(s) d'un livre ou d'un dvd
        /// </summary>
        /// <param name="idDocument">id du livre concernée</param>
        /// <returns>Liste d'objets Commande</returns>
        public List<Commande> GetAllCommandes(string idDocument)
        {
            // Récupère les informations de la table commandeDocument
            String jsonIdDocument = convertToJson("idLivreDvd", idDocument);
            List<Commande> lesCommandesDoc = TraitementRecup<Commande>(GET, "commandeDocument/" + jsonIdDocument, null);

            // Récupère les informations de la table commande
            List<Commande> lesCommandes = TraitementRecup<Commande>(GET, "commande", null);

            // Fusionne les informations des deux tables
            foreach (var commandeDoc in lesCommandesDoc)
            {
                var commande = lesCommandes.Find(c => c.Id == commandeDoc.Id);
                if (commande != null)
                {
                    commande.NbExemplaire = commandeDoc.NbExemplaire;
                    commande.IdSuivi = commandeDoc.IdSuivi;
                    commande.IdLivreDvd = commandeDoc.IdLivreDvd;
                }
            }

            return lesCommandes.FindAll(c => lesCommandesDoc.Exists(cd => cd.Id == c.Id));
        }

        /// <summary>
        /// Retourne toutes les commandes (tous livres confondus)
        /// </summary>
        /// <returns>Liste d'objets Commande</returns>
        public List<Commande> GetToutesLesCommandes()
        {
            // Récupère toutes les commandes (sans filtrer par idDocument)
            List<Commande> lesCommandes = TraitementRecup<Commande>(GET, "commande", null);

            // Récupère tous les documents associés
            List<Commande> lesCommandesDoc = TraitementRecup<Commande>(GET, "commandeDocument", null);

            // Fusionne les informations des deux tables
            foreach (var commande in lesCommandes)
            {
                var commandeDoc = lesCommandesDoc.Find(cd => cd.Id == commande.Id);
                if (commandeDoc != null)
                {
                    commande.NbExemplaire = commandeDoc.NbExemplaire;
                    commande.IdSuivi = commandeDoc.IdSuivi;
                    commande.IdLivreDvd = commandeDoc.IdLivreDvd;
                }
            }

            return lesCommandes;
        }

        /// <summary>
        /// Retourne les étapes de suivi d'une commande
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetLesSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Création d'une commande en base de données
        /// </summary>
        /// <param name="commande">commande à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerCommande(Commande commande)
        {
            try
            {
                // Création du JSON pour la table commande
                var jsonCommande = new
                {
                    id = commande.Id,
                    dateCommande = commande.DateCommande.ToString("yyyy-MM-dd"),
                    montant = commande.Montant
                };

                string jsonCommandeStr = JsonConvert.SerializeObject(jsonCommande);
                List<Commande> listeCommande = TraitementRecup<Commande>(
                    POST, "commande", "champs=" + jsonCommandeStr
                );

                if (listeCommande == null)
                {
                    Console.WriteLine("Erreur lors du POST sur la table commande");
                    return false;
                }

                // Création du JSON pour la table commandeDocument
                var jsonCommandeDoc = new
                {
                    id = commande.Id,
                    nbExemplaire = commande.NbExemplaire,
                    idLivreDvd = commande.IdLivreDvd,
                    idSuivi = int.Parse(commande.IdSuivi)
                };

                string jsonCommandeDocStr = JsonConvert.SerializeObject(jsonCommandeDoc);
                List<Commande> listeCommandeDoc = TraitementRecup<Commande>(
                    POST, "commandeDocument", "champs=" + jsonCommandeDocStr
                );

                if (listeCommandeDoc == null)
                {
                    Console.WriteLine("Erreur lors du POST sur la table commandeDocument");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de la commande : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifie l'étape de suivi d'une commande
        /// </summary>
        /// <param name="idCommande"></param>
        /// <param name="idSuivi"></param>
        public void ModifierSuiviCommande(string idCommande, string idSuivi)
        {
            try
            {
                // Création du JSON avec les champs à mettre à jour
                var jsonChamps = new
                {
                    idSuivi = int.Parse(idSuivi)
                };

                string jsonStr = JsonConvert.SerializeObject(jsonChamps);

                // Passage de l'id de la commande dans l'URL pour la liaison avec l'API
                TraitementRecup<Commande>(
                    "PUT",
                    "commandeDocument/" + idCommande,
                    "champs=" + jsonStr
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification du suivi : " + ex.Message);
            }
        }

        /// <summary>
        /// Supprime une commande
        /// </summary>
        /// <param name="idCommande"></param>
        public void SupprimerCommande(string idCommande)
        {
            try
            {
                // Suppression dans commandeDocument
                string jsonId = convertToJson("id", idCommande);
                TraitementRecup<Commande>(
                    "DELETE",
                    "commandeDocument/" + jsonId,
                    null
                );

                // Suppression dans commande
                TraitementRecup<Commande>(
                    "DELETE",
                    "commande/" + jsonId,
                    null
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur suppression commande : " + ex.Message);
            }
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

    }
}
