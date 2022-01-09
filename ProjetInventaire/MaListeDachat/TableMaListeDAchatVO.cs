using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire
{
    class TableMaListeDAchatVO
    {
        //Constructeur de TableMaListeDAchatVO
        public TableMaListeDAchatVO() { }

        //Fonction #1: Get and set la variable numeroProduit_a_acheter
        public int getAndSetNumeroProduit
        {
            get { return this.numeroProduit; }
            set { this.numeroProduit = value; }

        }
        //Fonction #2: Get and set la variable nomProduit_a_acheter
        public String getAndSetNomProduitManquant
        {
            get { return this.nomProduit; }
            set { this.nomProduit = value; }

        }
        //Fonction #3: Get and set la variable quantite_a_acheter
        public int getAndSetQuantiteActuelle
        {
            get { return this.quantiteActuelle; }
            set { this.quantiteActuelle = value; }

        }
        //Fonction #3: Get and set la variable quantite_a_acheter
        public int getAndSetSeuilMinimum
        {
            get { return this.seuilMinimum; }
            set { this.seuilMinimum = value; }

        }

        //Variable du numéro du produit à acheter
        private int numeroProduit;
        //Variable du nom du produit à acheter
        private String nomProduit;
        //Variable de la quantité actuelle
        private int quantiteActuelle;
        //Variable du seuil minimum
        private int seuilMinimum;

    }
}
