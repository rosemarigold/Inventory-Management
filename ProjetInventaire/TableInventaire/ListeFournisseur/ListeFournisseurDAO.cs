using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.ListeFournisseur
{
    class ListeFournisseurDAO
    {
        public List<ListeFournisseurVO> getListeDesFournisseurs()
        {
            // Créer une liste CoursVO
            List<ListeFournisseurVO> listeFournisseurstVO = new List<ListeFournisseurVO>();

            // Ouvre une connection et interroge la table Client.
            string appelConnexion = "System.Data.SqlCLient";

            // Clé de connexion à la base de données
            string cleDeConnexion = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            // Permet d'avoir le "factory provider"
            DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion);

            // Trouve l'objet de connexion
            using (DbConnection connection = trouveFactoryProvider.CreateConnection())
            {

                // Affiche à la console
                //Console.WriteLine("Connexion = {0}", connection.GetType().Name);
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                // Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();

                // Connexion
                command.Connection = connection;

                // On utilise la commande suivante pour afficher les tous les éléments des tables "InfoProduit" et "Inventaire"
                 command.CommandText = "select NumeroFournisseur, nom, prenom, adresse, courriel, telephone from Fournisseur";

                using (DbDataReader dataReader = command.ExecuteReader())
                {

                    // Lire tous les éléments
                    while (dataReader.Read())
                    {

                        ListeFournisseurVO ajouteFournisseur = new ListeFournisseurVO();

                        // Lire les attributs " Description, Type, QuantiteActuelle, SeuilMinimum" des tables "InfoProduit" et "Inventaire".
                        System.Diagnostics.Debug.WriteLine("NumeroFournisseur = {0}, nom = {1}, prenom = {2}, adresse = {3}, courriel = {4}, telephone = {5}.",
                        dataReader["NumeroFournisseur"].ToString(),
                        dataReader["nom"].ToString(),
                        dataReader["prenom"].ToString(),
                        dataReader["adresse"].ToString(),
                        dataReader["courriel"].ToString(),
                        dataReader["telephone"].ToString());
                        ajouteFournisseur.getAndSetNumeroFournisseur = int.Parse(dataReader["NumeroFournisseur"].ToString());
                        ajouteFournisseur.getAndSetNomFournisseur = (dataReader["nom"]).ToString();
                        ajouteFournisseur.getAndSetPrenomFournisseur = (dataReader["prenom"]).ToString();
                        ajouteFournisseur.getAndSetAdresseFournisseur = (dataReader["adresse"]).ToString();
                        ajouteFournisseur.getAndSetCourrielFournisseur = (dataReader["courriel"]).ToString();
                        ajouteFournisseur.getAndSetTelephoneFournisseur = (dataReader["telephone"]).ToString();

                        listeFournisseurstVO.Add(ajouteFournisseur);
                    }
                }
                return listeFournisseurstVO;
            }
        }
        public List<ListeFournisseurVO> getListeDesFournisseurs2(string numeroFournisseur)
        {
            // Créer une liste CoursVO
            List<ListeFournisseurVO> listeFournisseurstVO = new List<ListeFournisseurVO>();

            // Ouvre une connection et interroge la table Client.
            string appelConnexion = "System.Data.SqlCLient";

            // Clé de connexion à la base de données
            string cleDeConnexion = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            // Permet d'avoir le "factory provider"
            DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion);

            // Trouve l'objet de connexion
            using (DbConnection connection = trouveFactoryProvider.CreateConnection())
            {
                // cle de connexion
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                // Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();

                // Connexion
                command.Connection = connection;

                // On utilise la commande suivante pour afficher tous les éléments des tables "InfoProduit" et "Inventaire"
                command.CommandText = "select NumeroFournisseur, nom, prenom, adresse, courriel, telephone from Fournisseur where numeroFournisseur = " + numeroFournisseur;

                using (DbDataReader dataReader = command.ExecuteReader())
                {

                    // Lire tous les éléments
                    while (dataReader.Read())
                    {

                        ListeFournisseurVO ajouteFournisseur = new ListeFournisseurVO();

                        // Lire les attributs " Description, Type, QuantiteActuelle, SeuilMinimum" des tables "InfoProduit" et "Inventaire".
                        System.Diagnostics.Debug.WriteLine("NumeroFournisseur = {0}, nom = {1}, prenom = {2}, adresse = {3}, courriel = {4}, telephone = {5}.",
                        dataReader["NumeroFournisseur"].ToString(),
                        dataReader["nom"].ToString(),
                        dataReader["prenom"].ToString(),
                        dataReader["adresse"].ToString(),
                        dataReader["courriel"].ToString(),
                        dataReader["telephone"].ToString());
                        ajouteFournisseur.getAndSetNumeroFournisseur = int.Parse(dataReader["NumeroFournisseur"].ToString());
                        ajouteFournisseur.getAndSetNomFournisseur = (dataReader["nom"]).ToString();
                        ajouteFournisseur.getAndSetPrenomFournisseur = (dataReader["prenom"]).ToString();
                        ajouteFournisseur.getAndSetAdresseFournisseur = (dataReader["adresse"]).ToString();
                        ajouteFournisseur.getAndSetCourrielFournisseur = (dataReader["courriel"]).ToString();
                        ajouteFournisseur.getAndSetTelephoneFournisseur = (dataReader["telephone"]).ToString();

                        listeFournisseurstVO.Add(ajouteFournisseur);
                    }
                }
                return listeFournisseurstVO;
            }
        }
    }
}
