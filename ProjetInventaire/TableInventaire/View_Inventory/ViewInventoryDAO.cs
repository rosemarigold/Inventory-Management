using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.View_Inventory
{
    class ViewInventoryDAO
    {

        public List<ViewInventoryVO> getInventory()
        {
            // Créer une liste CoursVO
            List<ViewInventoryVO> listeViewInventoryVO = new List<ViewInventoryVO>();

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
                Console.WriteLine("Connexion = {0}", connection.GetType().Name);
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                // Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();

                // Connexion
                command.Connection = connection;

                // On utilise la commande suivante pour afficher les tous les éléments des tables "InfoProduit" et "Inventaire"
                command.CommandText = "select InfoProduit.NumeroProduit, InfoProduit.Nom, InfoProduit.Description, InfoProduit.TypeProduit, Inventaire.QuantiteActuelle, Inventaire.SeuilMinimum, ListeFournisseur.NumeroFournisseur from InfoProduit, Inventaire, ListeFournisseur where InfoProduit.NumeroProduit = Inventaire.NumeroProduit AND ListeFournisseur.NumeroProduit = Inventaire.NumeroProduit;";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Lire tous les éléments
                    while (dataReader.Read())
                    {

                        ViewInventoryVO viewInventory = new ViewInventoryVO();

                        // Lire les attributs "Nom, Description, TypeProduit, QuantiteActuelle, SeuilMinimum, NumeroFournisseur" des tables "InfoProduit", "Inventaire" et "Liste Fournisseur".
                        System.Diagnostics.Debug.WriteLine("NumeroProduit = {0}, Nom = {1}, Description = {2}, TypeProduit = {3}, QuantiteActuelle = {4}, SeuilMinimum = {5}, NumeroFournisseur = {6}",
                        dataReader["NumeroProduit"].ToString(),
                        dataReader["Nom"].ToString(),
                        dataReader["Description"].ToString(),
                        dataReader["TypeProduit"].ToString(),
                        dataReader["QuantiteActuelle"].ToString(),
                        dataReader["SeuilMinimum"].ToString(),
                        dataReader["numeroFournisseur"].ToString());
                        viewInventory.getAndSetNumeroProduit = int.Parse(dataReader["NumeroProduit"].ToString());
                        viewInventory.getAndSetNomProduit = (dataReader["Nom"].ToString());
                        viewInventory.getAndSetDescription = (dataReader["Description"].ToString());
                        viewInventory.getAndSetType = (dataReader["TypeProduit"].ToString());
                        viewInventory.getAndSetQuantiteActuelle = int.Parse(dataReader["QuantiteActuelle"].ToString());
                        viewInventory.getAndSetSeuilMinimum = int.Parse(dataReader["SeuilMinimum"].ToString());
                        viewInventory.getAndSetNumeroFournisseur = int.Parse(dataReader["NumeroFournisseur"].ToString());

                        listeViewInventoryVO.Add(viewInventory);
                    }
                }
                return listeViewInventoryVO;
            }
        }
    }
}
