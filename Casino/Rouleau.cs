using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Rouleau
    {
        private int id;
        private string nom;
        private static List<Rouleau> collROuleau = new List<Rouleau>();
        private Dictionary<int, string> dicElement = new Dictionary<int, string>();
        #region Getters
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        internal static List<Rouleau> CollROuleau { get => collROuleau; set => collROuleau = value; }
        #endregion


        public Rouleau(int id, string nom,  Dictionary<int, string> dicElement)
        {
            this.id = id;
            this.nom = nom;
            this.dicElement = dicElement;
        }

        public void ajouterElement(int i, string s)
        {
            dicElement.Add(i, s);
        }

        public string chercherElement(int i)
        {
            string valeur = "test";
            foreach(var paire in  dicElement)
            {
                if(paire.Key == i)
                {
                    valeur = paire.Value;
                }
            }
            return valeur;
        }
        public int chercherCle(string i)
        {
            int cle = 0;
            foreach (var paire in dicElement)
            {
                if (paire.Value == i)
                {
                    cle = paire.Key;
                }
            }
            return cle;
        }
        public int compterElement()
        {
            int i = 0;
            foreach (var paire in dicElement)
            {
                i++;
            }
            return i;
        }
       
    }
}
