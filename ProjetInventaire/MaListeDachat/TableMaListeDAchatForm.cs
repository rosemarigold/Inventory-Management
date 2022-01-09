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

// Source: https://stackoverflow.com/questions/10556556/insert-all-data-of-a-datagridview-to-database-at-once
namespace ProjetInventaire
{
    public partial class TableMaListeDAchatForm : Form
    {
        public TableMaListeDAchatForm()
        {

            InitializeComponent();

            // Disable resizable property on datagrid cell
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            //
            dataGridView1.ClearSelection();

            // Set invisible extra columns in the datagridViews
            dataGridView1.RowHeadersVisible = false;

            // Font color
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            // Disable the ability to select into the dataGridViews
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();

            //Création d'une instance de la classe TableDAchatDAO
            TableMaListeDAchatDAO AfficheProduitManquant = new TableMaListeDAchatDAO();

            //Création d'une instance de la classe TableDAchatVO
            List<TableMaListeDAchatVO> listeProduitManquantVO = new List<TableMaListeDAchatVO>();

            //Lien entre les classes VO et DAO
            listeProduitManquantVO = AfficheProduitManquant.getLaListeDesProduitsManquants();

            //La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView1.DataSource = listeProduitManquantVO;

            //Identifier les noms de chaque colonnes du dataGriedView (Numéro du Produit Manquant, Nom Produit du Manquant, Quantité Manquante)
            dataGridView1.Columns[0].HeaderText = "Product ID";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Current Quantity";
            dataGridView1.Columns[3].HeaderText = "Minimum Quantity";

            //Les colonnes remplissent l'espace du DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //On insère le produt manquant dans la table "ListeAchat"

            string appelConnexion1 = "System.Data.SqlCLient";

            // Clé de connexion à la base de données
            string cleDeConnexion1 = "Server=localhost\\SQLEXPRESS;Database=ProjetInventaire;Trusted_Connection=True;";

            // Commande pour obtenir le nombre de produits de la table Inventaire
            string insertProduitManquant = "";
            string effacerTableListeAchat = "DELETE from ListeAchat";
        
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

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int x1 = (int)dataGridView1.Rows[i].Cells["getAndSetSeuilMinimum"].Value;
                    int x2 = (int)dataGridView1.Rows[i].Cells["getAndSetQuantiteActuelle"].Value;
                    int x3 = x1 - x2;

                    insertProduitManquant = "INSERT INTO ListeAchat (NumeroProduit, Quantite) VALUES ("
                        + dataGridView1.Rows[i].Cells["getAndSetNumeroProduit"].Value + ", "
                        + x3.ToString() + ");";

                    command1.CommandText = effacerTableListeAchat;
                    command2.CommandText = insertProduitManquant;
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                }
            }
        }

        private void TableMaListeDAchat_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
