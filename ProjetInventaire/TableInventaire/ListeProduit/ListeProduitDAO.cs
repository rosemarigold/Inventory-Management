using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.ListeProduit
{
    class ListeProduitDAO
    {
        public List<ListeProduitVO> getListeProduit()
        {
            //Créer une liste CoursVO
            List<ListeProduitVO> listeDesProduitsVO = new List<ListeProduitVO>();

            //Ouvre une connection et interroge la table Client.
            string appelConnexion = "System.Data.SqlCLient";

            //Clé de connexion à la base de données
            //string cleDeConnexion = "user id=ETU_C2_1;password=MSSQLSERVER10;server=MS-SQL-ETU\\MSSQLSERVER10;database=DB_ETU_C2_1;";
            string cleDeConnexion = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            //Permet d'avoir le "factory provider"
            DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion);

            //Trouve l'objet de connexion
            using (DbConnection connection = trouveFactoryProvider.CreateConnection())
            {

                //Affiche à la console
                //Console.WriteLine("Connexion = {0}", connection.GetType().Name);
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                //Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();

                //Connexion
                command.Connection = connection;

                //On utilise la commande suivante pour afficher les tous les éléments de la table tblCours
                command.CommandText = "select Inventaire.NumeroProduit, Nom from Inventaire, InfoProduit Where Inventaire.NumeroProduit = InfoProduit.NumeroProduit;";

                using (DbDataReader dataReader = command.ExecuteReader())
                {

                    //Lire tous les éléments
                    while (dataReader.Read())
                    {

                        ListeProduitVO ListeDesProduits = new ListeProduitVO();

                        //Lire les attributs "NumeroCours" et "Titre" provenant de la table "tblCours"
                        Debug.WriteLine("NumeroProduit = {0}, Nom = {1}.",
                        dataReader["NumeroProduit"].ToString(),
                        dataReader["Nom"].ToString());
                        ListeDesProduits.getAndSetNumeroProduit = int.Parse(dataReader["NumeroProduit"].ToString());
                        ListeDesProduits.getAndSetNomProduit = (dataReader["Nom"]).ToString();

                        listeDesProduitsVO.Add(ListeDesProduits);
                    }
                }
                return listeDesProduitsVO;
            }
        }
    }
}
