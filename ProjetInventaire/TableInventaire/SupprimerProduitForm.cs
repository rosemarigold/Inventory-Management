using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

// Source: https://www.sqlservercentral.com/forums/topic/how-to-return-null-or-value-when-nothing-is-returned-from-query

namespace ProjetInventaire.TableInventaire
{
    public partial class SupprimerProduitForm : Form
    {

        public SupprimerProduitForm()
        {
            InitializeComponent();

            // Création d'une instance de la classe TableMonInventaireDAO
            TableMonInventaireDAO AfficheProduit = new TableMonInventaireDAO();

            // Création d'une instance de la classe TableMonInventaireVO
            List<TableMonInventaireVO> listeProduitVO = new List<TableMonInventaireVO>();

            // Lien entre les classes VO et DAO
            listeProduitVO = AfficheProduit.getLaListeDesProduits();

            // La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView1.DataSource = listeProduitVO;

            // Identifier les noms de chaque colonnes du dataGriedView (Numéro Produit, Quantité Actuelle, Seuil Minimum)
            dataGridView1.Columns[0].HeaderText = "Product ID";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Current Quantity";
            dataGridView1.Columns[3].HeaderText = "Minimum Quantity";

            // Les colonnes remplissent l'espace du DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set invisible extra columns in the datagridViews
            dataGridView1.RowHeadersVisible = false;

            // Disable resizable property on datagrid cell
            // dataGridView1: Product list
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Disable the ability to select into the dataGridViews
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();

            // Button color
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.White;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {// Bouton supprimer le produit

            // Si la boite de texte est vide
            if (this.textBox1.Text == "") {
                string message1 = "SVP insérer un numéro de produit.";
                string title1 = "Numéro de produit manquant";
                MessageBox.Show(message1, title1);
            }
            // Si la valeur inséré n'est pas une valeur numérique entière
            else if (!this.textBox1.Text.All(char.IsDigit)){

                string message = "SVP insérer une valeur numérique entière (0,1,2,3,...) à la quantité actuelle.";
                string title = "Mauvaise valeur";
                MessageBox.Show(message, title);
            }

            // Si le client a inséré une valeur numérique entière comme numéro de produit
            else{
                // String représentant le numéro du produit à supprimer
                string numeroDuProduitASupprimer = textBox1.Text;

                int numeroDuFournisseurASupprimer = 0;

                // Ouvre une connection et interroge la table Client.
                string appelConnexion1 = "System.Data.SqlCLient";

                // Clé de connexion à la base de données
                string cleDeConnexion1 = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

                // Commande pour vérifier si le numéro du produit existe dans de la table InfoProduit
                // Si oui, la commande retourne le numéro du produit
                // Si non, la commande retourne null 
                string cmd = "if exists(SELECT NumeroProduit FROM InfoProduit WHERE NumeroProduit =  " + numeroDuProduitASupprimer
                    + ") SELECT NumeroProduit FROM InfoProduit WHERE NumeroProduit =  " + numeroDuProduitASupprimer + " else select null";

                // Permet d'avoir le "factory provider"
                DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion1);

                // Trouve l'objet de connexion
                using (DbConnection connection = trouveFactoryProvider.CreateConnection())
                {
                    // Ouvre la connection
                    connection.ConnectionString = cleDeConnexion1;
                    connection.Open();

                    // Création d'une nouvelle commande
                    DbCommand command = trouveFactoryProvider.CreateCommand();

                    // Connexion
                    command.Connection = connection;

                    // On utilise la commande pour supprimer le produit de la table InfoProduit
                    command.CommandText = cmd;

                    // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes
                    command.ExecuteNonQuery();

                    // Si le numéro du produit inséré existe dans la table InfoProduit
                    if (!(command.ExecuteScalar() is DBNull)) 
                    {
                        // Commande pour supprimer le produit de la table InfoProduit
                        string supprimerProduitDeLaTableListeAchat = "delete from ListeAchat where NumeroProduit = " + numeroDuProduitASupprimer + ";";

                        // Commande pour supprimer le produit de la table InfoProduit
                        string supprimerProduitDeLaTableInfoProduit = "delete from InfoProduit where NumeroProduit = " + numeroDuProduitASupprimer + ";";
                        // Commande pour supprimer le produit de la table Inventaire
                        string supprimerProduitDeLaTableInventaire = "delete from Inventaire where NumeroProduit = " + numeroDuProduitASupprimer + ";";
                        //
                        string selectionnerFournisseurdDuProduitASupprimer = "select NumeroFournisseur from Fournisseur where NumeroFournisseur = (select NumeroFournisseur from ListeFournisseur  " +
                            "where ListeFournisseur.NumeroProduit = " + numeroDuProduitASupprimer + ")";

                        // Permet d'avoir le "factory provider"
                        DbProviderFactory trouveFactoryProvider1 = DbProviderFactories.GetFactory(appelConnexion1);

                        // Trouve l'objet de connexion
                        using (DbConnection connection1 = trouveFactoryProvider1.CreateConnection())
                        {
                            // Ouvre la connection
                            connection1.ConnectionString = cleDeConnexion1;
                            connection1.Open();

                            // Création d'une nouvelle commande
                            DbCommand command1 = trouveFactoryProvider1.CreateCommand();
                            DbCommand command2 = trouveFactoryProvider1.CreateCommand();
                            DbCommand command3 = trouveFactoryProvider1.CreateCommand();
                            DbCommand command4 = trouveFactoryProvider1.CreateCommand();
                            DbCommand command5 = trouveFactoryProvider1.CreateCommand();
                            DbCommand command6 = trouveFactoryProvider1.CreateCommand();

                            // Connexion
                            command1.Connection = connection1;
                            command2.Connection = connection1;
                            command3.Connection = connection1;
                            command4.Connection = connection1;
                            command5.Connection = connection1;
                            command6.Connection = connection1;

                            // On utilise la commande pour supprimer le produit des tables InfoProduit et Inventaire
                            //command1.CommandText = supprimerProduitDeLaTableInfoProduit;
                            //command2.CommandText = supprimerProduitDeLaTableInventaire;
                            command6.CommandText = supprimerProduitDeLaTableListeAchat;
                            command6.ExecuteNonQuery();
                            command5.CommandText = selectionnerFournisseurdDuProduitASupprimer;
                            command5.ExecuteNonQuery();

                            // Recevoir le numéro du Fournisseur à supprimer
                            numeroDuFournisseurASupprimer = (int)command5.ExecuteScalar();

                            // Commande pour supprimer le produit de la table ListeFournisseur
                            string supprimerProduitDeLaTableListeFournisseur = "delete from ListeFournisseur where NumeroFournisseur = " + numeroDuFournisseurASupprimer + ";";
                            //// Commande pour supprimer le fournisseur du produit dans la table Fournisseur
                            string supprimerFournisseurDeLaTableFournisseur = "delete from Fournisseur where NumeroFournisseur = " + numeroDuFournisseurASupprimer + ";";

                            // On utilise la commande pour supprimer le produit des tables ListeFournisseur et Fournisseur
                            command3.CommandText = supprimerFournisseurDeLaTableFournisseur;
                            command4.CommandText = supprimerProduitDeLaTableListeFournisseur;

                            // On supprime le produit de la table ListeFournisseur
                            command3.CommandText = supprimerProduitDeLaTableListeFournisseur; 
                            command3.ExecuteNonQuery();

                            // On supprime le produit de la table Fournisseur
                            command4.CommandText = supprimerFournisseurDeLaTableFournisseur;
                            command4.ExecuteNonQuery();

                            // On supprime le produit de la table Inventaire
                            command2.CommandText = supprimerProduitDeLaTableInventaire;
                            command2.ExecuteNonQuery();

                            // On supprime le produit de la table InfoProduit
                            command1.CommandText = supprimerProduitDeLaTableInfoProduit;
                            command1.ExecuteNonQuery();   // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes

                        }
                        // Affiche une fenêtre confirmant que le produit sélectionné a été supprimé.
                        string message = "Produit suprimé!";
                        string title = "";
                        MessageBox.Show(message, title);

                        // On vide la boite de texte
                        textBox1.Text = "";
                    }
                    // Si le numéro du produit inséré n'est pas dans la table InfoProduit
                    else {
                        // Affiche une fenêtre indiquant que le produit n'est pas en inventaire.
                        string message3 = "Ce produit n'est pas en inventaire!";
                        string title3 = "";
                        MessageBox.Show(message3, title3);

                        // On vide la boite de texte
                        textBox1.Text = "";
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {// Buton actualiser l'inventaire

            //Création d'une instance de la classe TableMonInventaireDAO
            TableMonInventaireDAO AfficheProduit = new TableMonInventaireDAO();

            //Création d'une instance de la classe TableMonInventaireVO
            List<TableMonInventaireVO> listeProduitVO = new List<TableMonInventaireVO>();

            //Lien entre les classes VO et DAO
            listeProduitVO = AfficheProduit.getLaListeDesProduits();

            //La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView1.DataSource = listeProduitVO;

            //Identifier les noms de chaque colonnes du dataGriedView (Numéro Produit, Quantité Actuelle, Seuil Minimum)
            dataGridView1.Columns[0].HeaderText = "Product ID";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Current Quantity";
            dataGridView1.Columns[3].HeaderText = "Minimum Quantity";

            //Les colonnes remplissent l'espace du DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SupprimerProduitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
