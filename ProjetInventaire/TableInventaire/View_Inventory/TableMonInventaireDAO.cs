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
    class TableMonInventaireDAO
    {
        public List<TableMonInventaireVO> getLaListeDesProduits()
        {
            //Créer une liste CoursVO
            List<TableMonInventaireVO> listeTableInventaireVO = new List<TableMonInventaireVO>();

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
                Console.WriteLine("Connexion = {0}", connection.GetType().Name);
                connection.ConnectionString = cleDeConnexion;
                connection.Open();

                //Création d'une nouvelle commande
                DbCommand command = trouveFactoryProvider.CreateCommand();


                //Connexion
                command.Connection = connection;

                //On utilise la commande suivante pour afficher les tous les éléments de la table tblCours
                command.CommandText = "select Inventaire.NumeroProduit, Nom, QuantiteActuelle, SeuilMinimum from Inventaire, InfoProduit Where Inventaire.NumeroProduit = InfoProduit.NumeroProduit;";

                using (DbDataReader dataReader = command.ExecuteReader())
                {

                    //Lire tous les éléments
                    while (dataReader.Read())
                    {

                        TableMonInventaireVO ajouteProduitInventaire = new TableMonInventaireVO();

                        //Lire les attributs "NumeroCours" et "Titre" provenant de la table "tblCours"
                        Debug.WriteLine("NumeroProduit = {0}, Nom = {1}, QuantiteActuelle = {2}, SeuilMinimum = {3}.",
                        dataReader["NumeroProduit"].ToString(),
                        dataReader["Nom"].ToString(),
                        dataReader["QuantiteActuelle"].ToString(),
                        dataReader["SeuilMinimum"].ToString());
                        ajouteProduitInventaire.getAndSetNumeroProduit = int.Parse(dataReader["NumeroProduit"].ToString());
                        ajouteProduitInventaire.getAndSetNomProduit = (dataReader["Nom"]).ToString();
                        ajouteProduitInventaire.getAndSetQuantiteActuelle = int.Parse(dataReader["QuantiteActuelle"].ToString());
                        ajouteProduitInventaire.getAndSetSeuilMinimum = int.Parse(dataReader["SeuilMinimum"].ToString());

                        listeTableInventaireVO.Add(ajouteProduitInventaire);
                    }
                }
                return listeTableInventaireVO;
            }
        }
        public List<TableMonInventaireVO> getLaListeDesProduitsRechercher(string text)
        {
            //Créer une liste CoursVO
            List<TableMonInventaireVO> listeTableInventaireVO = new List<TableMonInventaireVO>();

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
                command.CommandText = "select distinct Inventaire.NumeroProduit, InfoProduit.Nom, Inventaire.QuantiteActuelle, Inventaire.SeuilMinimum from InfoProduit JOIN Inventaire on InfoProduit.NumeroProduit = Inventaire.NumeroProduit where Nom like '%" + text.Replace("'","''") + "%';";
               
                    using (DbDataReader dataReader = command.ExecuteReader())
                    {

                        //Lire tous les éléments
                        while (dataReader.Read())
                        {

                            TableMonInventaireVO ajouteProduitInventaire = new TableMonInventaireVO();

                        //Lire les attributs "NumeroCours" et "Titre" provenant de la table "tblCours"
                        Debug.WriteLine("NumeroProduit = {0}, Nom = {1}, QuantiteActuelle = {2}, SeuilMinimum = {3}.",
                        dataReader["NumeroProduit"].ToString(),
                        dataReader["Nom"].ToString(),
                        dataReader["QuantiteActuelle"].ToString(),
                        dataReader["SeuilMinimum"].ToString());
                        ajouteProduitInventaire.getAndSetNumeroProduit = int.Parse(dataReader["NumeroProduit"].ToString());
                        ajouteProduitInventaire.getAndSetNomProduit = (dataReader["Nom"]).ToString();
                        ajouteProduitInventaire.getAndSetQuantiteActuelle = int.Parse(dataReader["QuantiteActuelle"].ToString());
                        ajouteProduitInventaire.getAndSetSeuilMinimum = int.Parse(dataReader["SeuilMinimum"].ToString());

                        listeTableInventaireVO.Add(ajouteProduitInventaire);
                        }
                    }
                    return listeTableInventaireVO;             
            }
        }
    }
}