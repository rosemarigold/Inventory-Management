using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.ListeProduit
{
    class ListeProduitVO
    {
        // Constructeur de ListeProduitVO
        public ListeProduitVO() { }

        // Fonction #1: Get and set la variable numeroProduit
        public int getAndSetNumeroProduit
        {
            get { return this.numeroProduit; }
            set { this.numeroProduit = value; }

        }
        // Fonction #2: Get and set la variable NomProduit
        public String getAndSetNomProduit
        {
            get { return this.nomProduit; }
            set { this.nomProduit = value; }

        }

        private int numeroProduit;      // Variable du numéro du produit
        private String nomProduit = ""; // Variable du Nom du produit

    }
}
