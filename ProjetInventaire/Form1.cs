using ProjetInventaire.RechercherProduit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetInventaire
{
    public partial class AccueilForm : Form
    {
        public AccueilForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            TableInventaireForm tableInventaire = new TableInventaireForm();

            // Send the form to the back to be able to add it to the panel
            tableInventaire.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(tableInventaire);

            // No border style
            tableInventaire.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            tableInventaire.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            tableInventaire.Show();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Bouton Rechercher produits
        private void button3_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            RechercherProduitForm rechercherProduit = new RechercherProduitForm();

            // Send the form to the back to be able to add it to the panel
            rechercherProduit.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableListeAchat" to the panel
            panel2.Controls.Add(rechercherProduit);

            // No border style
            rechercherProduit.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            rechercherProduit.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            rechercherProduit.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Bouton "Mon Inventaire"
        private void button_MonInventaire_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            TableInventaireForm tableInventaire = new TableInventaireForm();

            // Send the form to the back to be able to add it to the panel
            tableInventaire.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(tableInventaire);

            // No border style
            tableInventaire.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            tableInventaire.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            tableInventaire.Show();
        }

        // Bouton "Ma Liste d'achat"
        private void button_MaListeDachat_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            TableMaListeDAchatForm tableListeAchat = new TableMaListeDAchatForm();

            // Send the form to the back to be able to add it to the panel
            tableListeAchat.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableListeAchat" to the panel
            panel2.Controls.Add(tableListeAchat);

            // No border style
            tableListeAchat.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            tableListeAchat.Dock = DockStyle.Fill;

           // Show Form "tableInventaire" into the panel
           tableListeAchat.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
