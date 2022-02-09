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

// Source: https://www.c-sharpcorner.com/UploadFile/mahesh/understanding-message-box-in-windows-forms-using-C-Sharp/
// Source: https://www.dotnetperls.com/global-variable
// Source: https://stackoverflow.com/questions/6098646/object-cannot-be-cast-from-dbnull-to-other-types

namespace ProjetInventaire.TableInventaire
{
    public partial class AjouterProduitForm : Form
    {

        public AjouterProduitForm()
        {
            InitializeComponent();

            // Font (Text) color
            button1.ForeColor = Color.Black;

            // Button color
            //button1.BackColor = System.Drawing.Color.LightGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.White;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {//Boite de texte Nom du Produit

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {//Boite de texte Description

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {//Boite de texte Type

        }
        private void label5_Click(object sender, EventArgs e)
        {//Boite de texte Quantité actuelle

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {//Boite de texte Seuil minimum

        }

        private void button1_Click(object sender, EventArgs e)
        {// Bouton ajouter le produit

            // Compteur pour représenter le nombre de produits qui a dans l'inventaire.
            int nombreDeProduitDansInventaire = 0;

            // Compteur pour représenter le nombre de Fournisseurs qui a dans la table "Fournissuer".
            int nombreDeFournisseur = 0;

            // Ouvre une connection et interroge la table Client.
            string appelConnexion1 = "System.Data.SqlCLient";

            // Clé de connexion à la base de données
            string cleDeConnexion1 = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            // Commande pour obtenir le nombre de produits de la table Inventaire
            string getNombreDeProduit = "select Max(NumeroProduit) from InfoProduit;";

            string getNombreFournisseur = "select Max(NumeroFournisseur) from Fournisseur;";

            // Permet d'avoir le "factory provider"
            DbProviderFactory trouveFactoryProvider1 = DbProviderFactories.GetFactory(appelConnexion1);

            // Trouve l'objet de connexion
            using (DbConnection connection = trouveFactoryProvider1.CreateConnection())
            {
                //  Ouvre la connection
                connection.ConnectionString = cleDeConnexion1;
                connection.Open();

                // Création d'une nouvelle commande
                DbCommand command1 = trouveFactoryProvider1.CreateCommand();
                DbCommand command2 = trouveFactoryProvider1.CreateCommand();

                // Connexion
                command1.Connection = connection;
                command2.Connection = connection;

                // On utilise la commande pour obtenir le nombre de produits de la table Inventaire
                command1.CommandText = getNombreDeProduit;
                command2.CommandText = getNombreFournisseur;

               // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();

                //Si la valeur du NumeroProduit n'est pas null, il y a donc un au moins 1 produit dans l'inventaire.
                if (!(command1.ExecuteScalar() is DBNull))
                {
                    // On prend la valeur max du NumeroProduit et on l'incrémente de 1 pour ajouter le prochain produit.
                    nombreDeProduitDansInventaire = (int)command1.ExecuteScalar() + 1;
                }
                // Si l'inventaire est vide, la valeur du NumeroProduit sera null.
                else
                {
                    nombreDeProduitDansInventaire = 0;
                }

                //Si la valeur du NumeroProduit n'est pas null, il y a donc un au moins 1 produit dans l'inventaire.
                if (!(command2.ExecuteScalar() is DBNull))
                {
                    // On prend la valeur max du NumeroProduit et on l'incrémente de 1 pour ajouter le prochain produit.
                    nombreDeFournisseur = (int)command2.ExecuteScalar() + 1;
                }
                // Si l'inventaire est vide, la valeur du NumeroProduit sera null.
                else
                {
                    nombreDeFournisseur = 0;
                }
            }
      
            // Liste d'erreurs possibles lorsque le client insère un nouveau produit
            // Si la quantité actuelle inséré n'est pas une valeur numérique entière
            if (!this.textBoxProductCurrentQuantity.Text.All(char.IsDigit) || !this.textBoxProductMinimumQuantity.Text.All(char.IsDigit))
            {
                string message = "Please enter an integer numeric value (1,2,3,...).";
                string title = "Incorrect Input";
                MessageBox.Show(message, title);
            }
            // Si un textbox est vide
            else if (this.textBoxProductName.Text == "" || this.textBoxProductDescription.Text == "" || this.textBoxProductType.Text == "" || this.textBoxProductCurrentQuantity.Text == "" || this.textBoxProductMinimumQuantity.Text == ""
                || this.textBoxProviderFirstName.Text == "" || this.textBoxProviderLastName.Text == "" || this.textBoxProviderAddress.Text == "" || this.textBoxProivderEmail.Text == "") {

                string message = "Please fill all fields.";
                string title = "Missing value";
                MessageBox.Show(message, title);
            }

            // Si toutes les textbox requis sont remplis avec les bonnes valeurs, on insère le nouveau produit aux tables "Infoproduit" et "Inventaire".
            else
            {
                // Ouvre une connection et interroge la table Client.
                string appelConnexion = "System.Data.SqlCLient";

                // Clé de connexion à la base de données
                string cleDeConnexion = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

                // Commande pour ajouter le nouveau produit dans la table InfoProduit
                string ajouterProduitDansTableInfoProduit = "Insert into InfoProduit (NumeroProduit, Nom, Description, TypeProduit) Values ('"
                        + nombreDeProduitDansInventaire + "','" + this.textBoxProductName.Text.Replace("'","''") + "','" + this.textBoxProductDescription.Text.Replace("'", "''") + "','" 
                        + this.textBoxProductType.Text.Replace("'", "''") + "');";

                // Commande pour ajouter le nouveau produit dans la table Inventaire
                string ajouterProduitDansTableInventaire = "Insert into Inventaire (NumeroProduit, QuantiteActuelle, SeuilMinimum) Values ('" + nombreDeProduitDansInventaire + "','" + 
                    this.textBoxProductCurrentQuantity.Text + "','" + this.textBoxProductMinimumQuantity.Text + "');";

                // Commande pour ajouter le fournisseur dans la table Fournisseur
                string ajouterFournisseurDansTableFournisseur = 
                    "Insert into Fournisseur (NumeroFournisseur, Prenom, Nom, Adresse, Courriel, Telephone) Values ( '"
                    + nombreDeFournisseur + "','" 
                    + this.textBoxProviderFirstName.Text.Replace("'", "''") + "','"
                    + this.textBoxProviderTelephone.Text.Replace("'", "''") + "','"
                    + this.textBoxProviderLastName.Text.Replace("'", "''") + "','" 
                    + this.textBoxProviderAddress.Text.Replace("'", "''") + "','" 
                    + this.textBoxProivderEmail.Text.Replace("'", "''") + " ');";

                // Commande pour ajouter le fournisseur et le produit dans la table ListeFournisseur
                string ajouterFournisseurEtProduitDansTableListeFournisseur = "Insert into ListeFournisseur (NumeroProduit, NumeroFournisseur) Values ('" + nombreDeProduitDansInventaire
                    + "','" + nombreDeFournisseur + "');";

                // Permet d'avoir le "factory provider"
                DbProviderFactory trouveFactoryProvider = DbProviderFactories.GetFactory(appelConnexion);

                // Trouve l'objet de connexion
                using (DbConnection connection = trouveFactoryProvider.CreateConnection())
                {
                    // Ouvre la connection
                    connection.ConnectionString = cleDeConnexion;
                    connection.Open();

                    // Création d'une nouvelle commande
                    DbCommand command1 = trouveFactoryProvider.CreateCommand();
                    DbCommand command2 = trouveFactoryProvider.CreateCommand();
                    DbCommand command3 = trouveFactoryProvider.CreateCommand();
                    DbCommand command4 = trouveFactoryProvider.CreateCommand();

                    // Connexion
                    command1.Connection = connection;
                    command2.Connection = connection;
                    command3.Connection = connection;
                    command4.Connection = connection;

                    // On ajoute le produit dans la table InfoProduit 
                    command1.CommandText = ajouterProduitDansTableInfoProduit;

                    // On ajoute le produit dans la table Inventaire
                    command2.CommandText = ajouterProduitDansTableInventaire;

                    // On ajoute le produit dans la table Fournisseur
                    command3.CommandText = ajouterFournisseurDansTableFournisseur;

                    // On ajoute le produit dans la table Fournisseur
                    command4.CommandText = ajouterFournisseurEtProduitDansTableListeFournisseur;

                    // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                }

                // On affiche une fenêtre qui confirme l'ajout du nouveau produit.
                string message2 = this.textBoxProductName.Text + " was added to your inventory.";
                string title2 = "New product";
                MessageBox.Show(message2, title2);

                // Après l'insertion du nouveau produit, les boites de texte sont vidées.
                this.textBoxProductName.Text = "";
                this.textBoxProductDescription.Text = "";
                this.textBoxProductType.Text = "";
                this.textBoxProductCurrentQuantity.Text = "";
                this.textBoxProductMinimumQuantity.Text = "";

                this.textBoxProviderFirstName.Text = "";
                this.textBoxProviderTelephone.Text = "";
                this.textBoxProviderLastName.Text = "";
                this.textBoxProviderAddress.Text = "";
                this.textBoxProivderEmail.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AjouterProduitForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }   
}
