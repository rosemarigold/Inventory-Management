using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire
{
    class TableMonInventaireVO
    {
        // Constructeur de TableMonInventaireVO
        public TableMonInventaireVO() { }

        // Fonction #1: Get and set la variable numeroProduit
        public int getAndSetNumeroProduit
        {
            get { return this.numeroProduit;  }
            set { this.numeroProduit = value; }

        }
        // Fonction #2: Get and set la variable NomProduit
        public String getAndSetNomProduit
        {
            get { return this.nomProduit; }
            set { this.nomProduit = value; }

        }
        // Fonction #3: Get and set la variable quantiteActuelle
        public int getAndSetQuantiteActuelle
        {
            get { return this.quantiteActuelle; }
            set { this.quantiteActuelle = value; }

        }
        // Fonction #4: Get and set la variable seuilMinimum
        public int getAndSetSeuilMinimum
        {
            get { return this.seuilMinimum; }
            set { this.seuilMinimum = value; }

        }

        private int numeroProduit;      // Variable du numéro du produit
        private String nomProduit = ""; // Variable du Nom du produit
        private int quantiteActuelle;   // Variable de la quantité acutelle du produit
        private int seuilMinimum;       // Variable du seuil minimum du produit 

    }
}
