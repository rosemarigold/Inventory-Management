using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.DetailsProduit
{
    class DetailsProduitVO
    {
        // Constructeur de ModifierProduitVO
        public DetailsProduitVO() { }
  
        //Fonction #1: Get and set la variable description
        public string getAndSetDescription
        {
            get { return this.description; }
            set { this.description = value; }

        }
        //Fonction #2: Get and set la variable type
        public string getAndSetType
        {
            get { return this.type; }
            set { this.type = value; }

        }
        //Fonction #3: Get and set la variable quantiteActuelle
        public int getAndSetQuantiteActuelle
        {
            get { return this.quantiteActuelle; }
            set { this.quantiteActuelle = value; }

        }
        //Fonction #4: Get and set la variable seuilMinimum
        public int getAndSetSeuilMinimum
        {

            get { return this.seuilMinimum; }
            set { this.seuilMinimum = value; }

        }

        private string description;     // Variable de la description du produit
        private string type;            // Variable du type du produit
        private int quantiteActuelle;   // Variable de la quantité actuelle
        private int seuilMinimum;       // Variable du seuil minimum
    }
}
