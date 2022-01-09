using ProjetInventaire.TableInventaire.ModiferProduit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Source: https://www.youtube.com/watch?v=6y65Qf8GzcI

namespace ProjetInventaire.TableInventaire
{
    public partial class ModifierProduitForm : Form
    {
        // Pour capturer le numéro du produit à modifier
        string numeroProduit = "";

        public ModifierProduitForm()
        {
            InitializeComponent();

            //Création d'une instance de la classe DetailsProduitDAO
            ModifierProduitDAO afficherDetailsProduit = new ModifierProduitDAO();

            //Création d'une instance de la classe DetailsProduitVO
            List<ModifierProduitVO> listeDetailsProduitVO = new List<ModifierProduitVO>();

            //Lien entre les classes VO et DAO
            listeDetailsProduitVO = afficherDetailsProduit.getListeDetailsProduits();

            //La liste "listeDetailsProduitVO" est la source de donnée du dataGridView1 
            dataGridView1.DataSource = listeDetailsProduitVO;

            //Identifier les noms de chaque colonnes du dataGriedView
            dataGridView1.Columns[0].HeaderText = "Product ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[3].HeaderText = "Type";
            dataGridView1.Columns[4].HeaderText = "Current Quantity";
            dataGridView1.Columns[5].HeaderText = "Minimum Quantity";

            //Les colonnes remplissent l'espace du DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set invisible extra columns in the datagridViews
            dataGridView1.RowHeadersVisible = false;

            // Disable the ability to select into the dataGridViews
            //dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();

            // Disable resizable property on datagrid cell
            // dataGridView1: Product list
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Make datagridView1 selectable but not editable
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Button color
            //button1.BackColor = System.Drawing.Color.LightGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.White;

            // to avoid selecting multiple cells
            dataGridView1.MultiSelect = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int numberOfRows = dataGridView1.Rows.Count;

            //dataGridView1.Rows[0]= Color.Red;
            dataGridView1.Rows[1].DefaultCellStyle.BackColor = Color.Red;
           

            for (int i = 0; i < numberOfRows; i++) {

                //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                /*if (i % 2 != 0) {
                    dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Beige;
                }*/
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numeroProduit = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();

            // if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            // if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            /* if (dataGridView1.SelectedCells != null)
             {
                 // MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                 // Pour capturer le numéro du produit à modifier
                 numeroProduit = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();            
             }*/
            //numeroProduit = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        // Bouton Mettre à jour
        private void button1_Click(object sender, EventArgs e)
        {

            // Liste d'erreurs possibles lorsque le client insère un nouveau produit
            // Si la quantité actuelle inséré n'est pas une valeur numérique entière
            if (!this.textBox5.Text.All(char.IsDigit) || !this.textBox6.Text.All(char.IsDigit))
            {
                string message = "SVP insérer une valeur numérique entière (0,1,2,3,...).";
                string title = "Mauvaise valeur";
                MessageBox.Show(message, title);
            }
            // Si un textbox est vide
            else if (this.textBox2.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "" || this.textBox5.Text == "" || this.textBox6.Text == "")
            {

                string message = "SVP entrez toutes les boites de texte en rouge.";
                string title = "Valeur manquante";
                MessageBox.Show(message, title);
            }
            else
            {
                // Ouvre une connection et interroge la table Client.
                string appelConnexion1 = "System.Data.SqlCLient";

                // Clé de connexion à la base de données
                string cleDeConnexion1 = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

                // Commande pour 
                string mettreAJourProduitDansLaTableInfoProduit = "Update InfoProduit set Nom = '" + this.textBox2.Text.Replace("'", "''") + "', Description = '" + this.textBox3.Text
                    + "', TypeProduit = '" + this.textBox4.Text.Replace("'", "''") + "' where NumeroProduit = " + this.numeroProduit + ";";

                string mettreAJourProduitDansLaTableInventaire = "Update Inventaire set QuantiteActuelle = " + this.textBox5.Text.Replace("'", "''") + ", SeuilMinimum = "
                    + this.textBox6.Text.Replace("'", "''") + " where NumeroProduit = " + this.numeroProduit + ";";

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

                    // Connexion
                    command1.Connection = connection;

                    // On utilise la commande pour obtenir le nombre de produits de la table Inventaire
                    command1.CommandText = mettreAJourProduitDansLaTableInfoProduit;

                    // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes
                    command1.ExecuteNonQuery();

                    // Création d'une nouvelle commande
                    DbCommand command2 = trouveFactoryProvider1.CreateCommand();

                    // Connexion
                    command2.Connection = connection;

                    // On utilise la commande pour obtenir le nombre de produits de la table Inventaire
                    command2.CommandText = mettreAJourProduitDansLaTableInventaire;

                    // Utiliser pour effectuer des commandes SQL (update, insert, delete, etc) et executer les commandes
                    command2.ExecuteNonQuery();

                }
                //On vide les boites de texte
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";

                //Mettre à jour le datagriedView
                //Création d'une instance de la classe DetailsProduitDAO
                ModifierProduitDAO afficherDetailsProduit = new ModifierProduitDAO();

                //Création d'une instance de la classe DetailsProduitVO
                List<ModifierProduitVO> listeDetailsProduitVO = new List<ModifierProduitVO>();

                //Lien entre les classes VO et DAO
                listeDetailsProduitVO = afficherDetailsProduit.getListeDetailsProduits();

                //La liste "listeDetailsProduitVO" est la source de donnée du dataGridView1 
                dataGridView1.DataSource = listeDetailsProduitVO;

                //Les colonnes remplissent l'espace du DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ModifierProduitForm_Load(object sender, EventArgs e)
        {

        }
    }

}