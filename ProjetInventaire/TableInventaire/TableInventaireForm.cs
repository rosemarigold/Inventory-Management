using ProjetInventaire.TableInventaire;
using ProjetInventaire.TableInventaire.DetailsProduit;
using ProjetInventaire.TableInventaire.ListeFournisseur;
using ProjetInventaire.TableInventaire.ListeProduit;
using ProjetInventaire.TableInventaire.View_Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetInventaire
{
    public partial class TableInventaireForm : Form
    {

        public TableInventaireForm()
        {
            InitializeComponent();

            // Font (Text) color
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;

            // Background color
            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button3.BackColor = System.Drawing.Color.White;
            button4.BackColor = System.Drawing.Color.White;

            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatStyle = FlatStyle.Flat;
            button4.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.White;
            button3.FlatAppearance.BorderColor = Color.White;
            button4.FlatAppearance.BorderColor = Color.White;
            //button1.FlatAppearance.BorderColor = Color.Transparent;
            /*button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;*/

        }

        private void TableInventaireForm_Load(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            ViewInventoryForm viewInventory = new ViewInventoryForm();

            // Send the form to the back to be able to add it to the panel
            viewInventory.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(viewInventory);

            // No border style
            viewInventory.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            viewInventory.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            viewInventory.Show();
        }

        // Bouton Ajouter
        private void button1_Click(object sender, EventArgs e)
        {
            //Dérige le client vers la fenêtre "Ajouter un produit" (AjouterProduitForm)
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            AjouterProduitForm ajouterUnProduit = new AjouterProduitForm();

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Send the form to the back to be able to add it to the panel
            ajouterUnProduit.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(ajouterUnProduit);

            // No border style
            ajouterUnProduit.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            ajouterUnProduit.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            ajouterUnProduit.Show();
        }

        // Bouton Modifer
        private void button2_Click(object sender, EventArgs e)
        {
            //Dérige le client vers la fenêtre "Modifier un produit" (ModifierProduitForm)
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            ModifierProduitForm modifierUnProduit = new ModifierProduitForm();  

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Send the form to the back to be able to add it to the panel
            modifierUnProduit.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(modifierUnProduit);

            // No border style
            modifierUnProduit.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            modifierUnProduit.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            modifierUnProduit.Show();
        }
        // Bouton Supprimer
        private void button3_Click(object sender, EventArgs e)
        {
            //Dérige le client vers la fenêtre "Supprimer un produit" (SupprimerProduitForm)
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            SupprimerProduitForm effacerUnProduit = new SupprimerProduitForm();          

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Send the form to the back to be able to add it to the panel
            effacerUnProduit.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "effacerUnProduit" to the panel
            panel2.Controls.Add(effacerUnProduit);

            // No border style
            effacerUnProduit.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            effacerUnProduit.Dock = DockStyle.Fill;

            // Show Form "effacerUnProduit" into the panel
            effacerUnProduit.Show();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Source: https://stackoverflow.com/questions/24821528/top-level-control-cannot-be-added-to-a-control
            ViewInventoryForm viewInventory = new ViewInventoryForm();

            // Send the form to the back to be able to add it to the panel
            viewInventory.TopLevel = false;

            // Remove the form shown in the panel if the panel already has a form in it
            panel2.Controls.Clear();

            // Add Form "tableInventaire" to the panel
            panel2.Controls.Add(viewInventory);

            // No border style
            viewInventory.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // Docked to its parent control and determines how a control is resized with its parent
            viewInventory.Dock = DockStyle.Fill;

            // Show Form "tableInventaire" into the panel
            viewInventory.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
