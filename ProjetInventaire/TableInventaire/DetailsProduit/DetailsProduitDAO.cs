using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.DetailsProduit
{
    class DetailsProduitDAO
    {
        public List<DetailsProduitVO> getListeDetailsProduits(string numeroProduit)
        {
            // Créer une liste CoursVO
            List<DetailsProduitVO> listeDetailsProduitVO = new List<DetailsProduitVO>();

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
                command.CommandText = "select distinct InfoProduit.Description, InfoProduit.TypeProduit, Inventaire.QuantiteActuelle," +
                    "Inventaire.SeuilMinimum from InfoProduit, Inventaire where InfoProduit.NumeroProduit = " + numeroProduit + "AND Inventaire.NumeroProduit =" + numeroProduit;

                using (DbDataReader dataReader = command.ExecuteReader())
                {

                    // Lire tous les éléments
                    while (dataReader.Read())
                    {

                        DetailsProduitVO ajouteDetailsProduit = new DetailsProduitVO();

                        // Lire les attributs " Description, Type, QuantiteActuelle, SeuilMinimum" des tables "InfoProduit" et "Inventaire".
                        System.Diagnostics.Debug.WriteLine("Description = {0}, TypeProduit = {1}, QuantiteActuelle = {2}, SeuilMinimum = {3}.",
                        dataReader["Description"].ToString(),
                        dataReader["TypeProduit"].ToString(),
                        dataReader["QuantiteActuelle"].ToString(),
                        dataReader["SeuilMinimum"].ToString());
                        ajouteDetailsProduit.getAndSetDescription = (dataReader["Description"]).ToString();
                        ajouteDetailsProduit.getAndSetType = (dataReader["TypeProduit"].ToString());
                        ajouteDetailsProduit.getAndSetQuantiteActuelle = int.Parse(dataReader["QuantiteActuelle"].ToString());
                        ajouteDetailsProduit.getAndSetSeuilMinimum = int.Parse(dataReader["SeuilMinimum"].ToString());

                        listeDetailsProduitVO.Add(ajouteDetailsProduit);
                    }
                }
                return listeDetailsProduitVO;
            }
        }
    }
}
