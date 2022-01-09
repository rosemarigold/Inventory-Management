using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.Common;


namespace ProjetInventaire
{
    class TableMaListeDAchatDAO
    {
        public List<TableMaListeDAchatVO> getLaListeDesProduitsManquants()
        {
            //Créer une liste CoursVO
            List<TableMaListeDAchatVO> listeProduitManquantVO = new List<TableMaListeDAchatVO>();

            //Ouvre une connection et interroge la table Client.
            string appelConnexion = "System.Data.SqlCLient";

            //Clé de connexion à la base de données
            string cleDeConnexion = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            //Permet d'avoir le "factory provider"
            DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion);

            //Trouve l'objet de connexion
            using (DbConnection connection = trouveFactoryProvider.CreateConnection())
            {

                //Affiche à la console
                Console.WriteLine("Connexion = {0}", connection.GetType().Name);
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                //Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();

                //Affiche à la console
                Console.WriteLine("Commande = {0}", command.GetType().Name);

                //Connexion
                command.Connection = connection;

                //On utilise la commande suivante pour sélectionné tous les produits considéré être en achat
                command.CommandText = "select Inventaire.NumeroProduit, InfoProduit.Nom ,Inventaire.SeuilMinimum, Inventaire.QuantiteActuelle " +
                "from Inventaire, InfoProduit where(Inventaire.QuantiteActuelle < Inventaire.SeuilMinimum) AND (Inventaire.NumeroProduit = InfoProduit.NumeroProduit)";

                
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    //Lire tous les éléments
                    while (dataReader.Read())
                    {
                        TableMaListeDAchatVO ajouteProduitManquant = new TableMaListeDAchatVO();

                        //Lire les attributs "NumeroProduit", "Quantite" provenant de la table "ListeAchat"
                        Debug.WriteLine("NumeroProduit = {0}, Nom = {1}, Quantite = {2}.",
                        dataReader["NumeroProduit"].ToString(),
                        dataReader["Nom"].ToString(),
                        dataReader["SeuilMinimum"].ToString(),
                        dataReader["QuantiteActuelle"].ToString());
                        ajouteProduitManquant.getAndSetNumeroProduit = int.Parse(dataReader["NumeroProduit"].ToString());
                        ajouteProduitManquant.getAndSetNomProduitManquant = (dataReader["Nom"].ToString());
                        ajouteProduitManquant.getAndSetSeuilMinimum= int.Parse(dataReader["SeuilMinimum"].ToString());
                        ajouteProduitManquant.getAndSetQuantiteActuelle = int.Parse(dataReader["QuantiteActuelle"].ToString());

                        listeProduitManquantVO.Add(ajouteProduitManquant);
                    }
                }
                return listeProduitManquantVO;
            }
        }
    }
}
