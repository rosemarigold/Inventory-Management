using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInventaire.TableInventaire.ListeFournisseur
{
    class ListeFournisseurVO
    {
        // Constructeur de TableMonInventaireVO
        public ListeFournisseurVO() { }

        // Fonction #1: Get and set la variable numeroFournisseur
        public int getAndSetNumeroFournisseur
        {
            get { return this.numeroFournisseur; }
            set { this.numeroFournisseur = value; }

        }
        // Fonction #2: Get and set la variable NomProduit
        public String getAndSetNomFournisseur
        {
            get { return this.nom; }
            set { this.nom = value; }

        }
        // Fonction #3: Get and set la variable prenom
        public String getAndSetPrenomFournisseur
        {
            get { return this.prenom; }
            set { this.prenom = value; }

        }
        // Fonction #4: Get and set la variable adresse
        public String getAndSetAdresseFournisseur
        {
            get { return this.adresse; }
            set { this.adresse = value; }

        }
        // Fonction #5: Get and set la variable courriel
        public String getAndSetCourrielFournisseur
        {
            get { return this.courriel; }
            set { this.courriel = value; }

        }
        // Fonction #6: Get and set la variable telephone
        public String getAndSetTelephoneFournisseur
        {
            get { return this.telephone; }
            set { this.telephone = value; }

        }

        private int numeroFournisseur;      // Variable du numéro du produit
        private String nom = "";            // Variable du nom du fournisseur
        private String prenom = "";         // Variable du prenom du fournisseur
        private String adresse = "";        // Variable de l'adresse du fournisseur
        private String courriel = "";       // Variable du courriel du fournisseur
        private String telephone = "";      // Variable du telephone du fournisseur

    }
}
