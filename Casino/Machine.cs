using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Machine
    {
        private int id;
        private string nom;
        private static List<Machine> collMachines = new List<Machine>();
        private Rouleau rouleau;
        private List<Joueur> listJoueur;
        private int mise;

        public Machine(int id, string nom, Rouleau rouleau, int mise)
        {
            this.id = id;
            this.nom = nom;
            this.rouleau = rouleau;
            listJoueur = new List<Joueur>();
            collMachines.Add(this);
            this.mise = mise;
        }

        public int nombreJoueur()
        {
            return listJoueur.Count;
        }
        public static void afficherMachines()
        {
            Console.WriteLine("Voici les machines a disposition : ");
            foreach(Machine m in collMachines)
            {
                Console.WriteLine(m.id +" - "+m.nom);
            }
        }
        public void ajouterJoueur(int i, Joueur j)
        {
            foreach(Machine m in collMachines)
            {
                if(m.id == i)
                {
                    m.listJoueur.Add(j);
                }
            }
        }
        public static Machine chercherMachine(int i)
        {
            Machine t = collMachines[1];
            foreach(Machine m in collMachines)
            {
                if(m.id == i)
                {
                    t = m;
                }
            }
            return t;
        }
        public void afficherJoueurs()
        {
            foreach (Joueur j in listJoueur)
            {
                j.afficherJoueur();
            }
        }

        public void jouer()
        {
            foreach(Joueur j in listJoueur)
            {
                Joueur joueur = j;
                bool test = joueur.verifierSolde(mise);
                if (!test)
                {
                    joueur.afficherJoueur();
                    joueur.Solde -= mise;
                    joueur.afficherSolde();
                    Random rand = new Random();
                    int nbE = rouleau.compterElement() + 1;
                    int i1 = rand.Next(2, nbE);
                    int i2 = rand.Next(2, nbE);
                    int i3 = rand.Next(2, nbE);
                    Console.WriteLine("Voici le lancer : ");
                    Console.WriteLine("- " + rouleau.chercherElement(i1));
                    Console.WriteLine("- " + rouleau.chercherElement(i2));
                    Console.WriteLine("- " + rouleau.chercherElement(i3));

                    if (i1 == i2)
                    {
                        if (i1 == i3)
                        {
                            joueur.modifierSolde(i1 * mise);
                        }
                        else
                        {
                            joueur.modifierSolde(i1 * (mise / 2));
                        }
                    }
                    else if (i2 == i3)
                    {
                        joueur.modifierSolde(i2 * (mise / 2));
                    }
                    else if (i1 == i3)
                    {
                        joueur.modifierSolde(i1 * (mise / 2));
                    }
                }
                else
                {
                    Console.WriteLine("Votre solde n'est pas suffisant pour jouer.");
                }
            }
           
           
        }
    }
}
