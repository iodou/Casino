using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Joueur
    {
        private int id;
        private string nom;
        private float solde;
        private static List<Joueur> collJoueur = new List<Joueur>();


        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public float Solde { get => solde; set => solde = value; }
        #endregion

        #region Contructeur
        public Joueur(string nom, int id)
        {
            this.nom = nom;
            this.solde = 100;
            this.id = id;
        }

        #endregion

        #region Methodes
        public void afficherSolde()
        {
            Console.WriteLine("Solde : " + solde + " euros.");
        }
        public void afficherJoueur()
        {
            Console.WriteLine("Joueur : " + nom);
        }
        public void afficherJoueurs()
        {
            foreach(Joueur j in collJoueur)
            {
                Console.WriteLine("Joueur : " + j.nom);
            }
        }
        public float modifierSolde(float n)
        {
            float test = solde;
            this.solde = solde + n;
            if(solde > test)
            {
                Console.WriteLine("Vous avez gagné " + n + " euros !");
            }
            else
            {
                float x = test - solde;
                Console.WriteLine("Vous avez perdu " + x + " euros...");
            }
            return solde;
        }
        public bool verifierSolde(int i)
        {
            bool b = false;
            if(solde - i < 0)
            {
                b = true;
            }
            return b;
        }
        #endregion
    }
}
