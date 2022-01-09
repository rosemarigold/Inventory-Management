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

namespace ProjetInventaire.RechercherProduit
{
    public partial class RechercherProduitForm : Form
    {

        public RechercherProduitForm()
        {
            InitializeComponent();

            // Disable resizable property on datagrid cell
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;

            // Set invisible extra columns in the datagridViews
            dataGridView1.RowHeadersVisible = false;

            // Font color
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            // Disable the ability to select into the dataGridViews
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = false;

            // Button color
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.White;
        }

        private void RechercherProduitForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {// Bouton "Rechercher produit"

            // Si la barre de recherche n' est pas vide
            if (this.textBox1.Text != "") {

                //Création d'une instance de la classe TableMonInventaireDAO
                TableMonInventaireDAO AfficheProduit = new TableMonInventaireDAO();

                //Création d'une instance de la classe TableMonInventaireVO
                List<TableMonInventaireVO> listeProduitVO = new List<TableMonInventaireVO>();

                //Lien entre les classes VO et DAO
                listeProduitVO = AfficheProduit.getLaListeDesProduitsRechercher(this.textBox1.Text);

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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
