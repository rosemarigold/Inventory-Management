using ProjetInventaire.TableInventaire;
using ProjetInventaire.TableInventaire.DetailsProduit;
using ProjetInventaire.TableInventaire.ListeFournisseur;
using ProjetInventaire.TableInventaire.ListeProduit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetInventaire.TableInventaire.View_Inventory
{
    public partial class ViewInventoryForm : Form
    {
        string numeroFournisseur = "";


        public ViewInventoryForm()
        {
            InitializeComponent();

            // Les colonnes remplissent l'espace du DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set invisible extra columns in the datagridViews
            dataGridView1.RowHeadersVisible = false;

            // Disable resizable property on datagrid cell
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Création d'une instance de la classe ViewInventoryDAO
            ViewInventoryDAO viewInventory = new ViewInventoryDAO();

            // Création d'une instance de la classe ViewInventoryVO
            List<ViewInventoryVO> viewInventoryVO = new List<ViewInventoryVO>();

            // Lien entre les classes VO et DAO
            viewInventoryVO = viewInventory.getInventory();

            // La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView1.DataSource = viewInventoryVO;

            // Identifier les noms de chaque colonnes du dataGriedView (Numéro Produit, Nom)
            dataGridView1.Columns[0].HeaderText = "Product ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[3].HeaderText = "Type";
            dataGridView1.Columns[4].HeaderText = "Current Quantity";
            dataGridView1.Columns[5].HeaderText = "Minimum Quantity";
            dataGridView1.Columns[6].HeaderText = "Provider ID";

            // Disable the ability to select into the dataGridViews
            dataGridView1.Enabled = false; 
            dataGridView2.Enabled = false;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();         

            // dataGridView2: Provider's info

            // Création d'une instance de la classe DetailsProduitDAO
            ListeFournisseurDAO AfficheFournisseur = new ListeFournisseurDAO();

            // Création d'une instance de la classe DetailsProduitVO
            List<ListeFournisseurVO> listeFournisseurVO = new List<ListeFournisseurVO>();

            // Lien entre les classes VO et DAO
            listeFournisseurVO = AfficheFournisseur.getListeDesFournisseurs();

            // La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView2.DataSource = listeFournisseurVO;

            // Identifier les noms de chaque colonnes du dataGriedView (Numéro Fournisseur, Nom)
            dataGridView2.Columns[0].HeaderText = "Provider ID";
            dataGridView2.Columns[1].HeaderText = "First name";
            dataGridView2.Columns[2].HeaderText = "Last name";
            dataGridView2.Columns[3].HeaderText = "Address";
            dataGridView2.Columns[4].HeaderText = "Email";
            dataGridView2.Columns[5].HeaderText = "Telephone";

            // Les colonnes remplissent l'espace du DataGridView
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set invisible extra columns in the datagridViews
            dataGridView2.RowHeadersVisible = false;

            // Disable resizable property on datagrid cell
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dataGridView1: Product list
            /*if (e.RowIndex >= 0 && !(sender is DataGridViewHeaderCell))
            {
                numeroFournisseur = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            } 
            numeroFournisseur = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            // Source: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.readonly?view=windowsdesktop-6.0
            // Set the selection background color for all the cells
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // dataGridView2: Product info

            // Création d'une instance de la classe DetailsProduitDAO
            /*DetailsProduitDAO AfficheDetailsProduit = new DetailsProduitDAO();

            // Création d'une instance de la classe DetailsProduitVO
            List<DetailsProduitVO> listeDetailsProduitVO = new List<DetailsProduitVO>();

            // Lien entre les classes VO et DAO
            listeDetailsProduitVO = AfficheDetailsProduit.getListeDetailsProduits(numeroProduit);

            // La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView2.DataSource = listeDetailsProduitVO;

            // Identifier les noms de chaque colonnes du dataGriedView (Description, Type, Quantité Actuelle, Seuil Minimum)
            dataGridView2.Columns[0].HeaderText = "Description";
            dataGridView2.Columns[1].HeaderText = "Type";
            dataGridView2.Columns[2].HeaderText = "Quantité Actuelle";
            dataGridView2.Columns[3].HeaderText = "Seuil minimum";

            // Les colonnes remplissent l'espace du DataGridView
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // dataGridView3: Provider's info

            // Création d'une instance de la classe DetailsProduitDAO
            ListeFournisseurDAO AfficheFournisseur = new ListeFournisseurDAO();

            // Création d'une instance de la classe DetailsProduitVO
            List<ListeFournisseurVO> listeFournisseur2VO = new List<ListeFournisseurVO>();

            // Lien entre les classes VO et DAO
            listeFournisseur2VO = AfficheFournisseur.getListeDesFournisseurs2(numeroFournisseur);

            // La liste "listeProduitVO" est la source de donnée du dataGridView1 
            dataGridView2.DataSource = listeFournisseur2VO;

            // Identifier les noms de chaque colonnes du dataGriedView (Numéro Fournisseur, Nom)
            dataGridView2.Columns[0].HeaderText = "Provider ID";
            dataGridView2.Columns[1].HeaderText = "First name";
            dataGridView2.Columns[2].HeaderText = "Last name";
            dataGridView2.Columns[3].HeaderText = "Address";
            dataGridView2.Columns[4].HeaderText = "Email";
            dataGridView2.Columns[5].HeaderText = "Telephone"; 

             // Les colonnes remplissent l'espace du DataGridView3 (Provider's info)
             dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // DatagriedView2 "Provider's info"
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Gray;

            // Les colonnes remplissent l'espace du DataGridView
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set invisible extra columns in the datagridViews
            dataGridView2.RowHeadersVisible = false;

            // Disable resizable property on datagrid cell
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            */
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewInventoryForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
