using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.View_Inventory
{
    class ViewInventoryVO
    {

            // Constructeur de ModifierProduitVO
            public ViewInventoryVO() { }

            // Fonction #1: Get and set la variable numeroProduit
            public int getAndSetNumeroProduit
            {
                get { return this.numeroProduit; }
                set { this.numeroProduit = value; }

            }
            // Fonction #2: Get and set la variable nomProduit
            public string getAndSetNomProduit
            {

                get { return this.nomProduit; }
                set { this.nomProduit = value; }

            }
            // Fonction #3: Get and set la variable description
            public string getAndSetDescription
            {
                get { return this.description; }
                set { this.description = value; }

            }
            // Fonction #4: Get and set la variable type
            public string getAndSetType
            {
                get { return this.type; }
                set { this.type = value; }

            }
            // Fonction #5: Get and set la variable quantiteActuelle
            public int getAndSetQuantiteActuelle
            {
                get { return this.quantiteActuelle; }
                set { this.quantiteActuelle = value; }

            }
            // Fonction #6: Get and set la variable seuilMinimum
            public int getAndSetSeuilMinimum
            {

                get { return this.seuilMinimum; }
                set { this.seuilMinimum = value; }

            }

            // Fonction #7: Get and set la variable seuilMinimum
            public int getAndSetNumeroFournisseur
            {

                get { return this.numeroFournisseur; }
                set { this.numeroFournisseur = value; }

            }

            private int numeroProduit;      // Variable du numéro du produit
            private string nomProduit;      // Variable du nom du produit
            private string description;     // Variable de la description du produit
            private string type;            // Variable du type du produit
            private int quantiteActuelle;   // Variable de la quantité actuelle
            private int seuilMinimum;       // Variable du seuil minimum
            private int numeroFournisseur;       // Variable du numéro du fournisseur

        
    }
}
