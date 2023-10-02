using Casino;

Dictionary<int, string> d1 = new Dictionary<int, string>
{

    { 2, "D" },
    { 3, "C" },
    { 4, "B" },
    { 5, "A" },
    { 6, "S" },
    { 7, "SSS" }
};
Dictionary<int, string> d2 = new Dictionary<int, string>
{

    { 2, "4" },
    { 3, "3" },
    { 4, "2" },
    { 5, "1" },
    { 6, "69" },
    { 7, "42" }
};


Rouleau r1 = new Rouleau(1, "lettre", d1);
Rouleau r2 = new Rouleau(1, "nombre", d2);

Machine m1 = new Machine(1, "Rouellettre", r1, 10);
Machine m2 = new Machine(2, "Chiffromania", r2, 20);

int choix = 0;

while(choix != -1)
{

    Console.WriteLine("Bienvenue dans casino le plus coté de la France :");
    Console.WriteLine("A quelle machine voulez-vous jouer ?");
    Machine.afficherMachines();
    int nbm = Int32.Parse(Console.ReadLine());
    Machine m =Machine.chercherMachine(nbm);
    Console.WriteLine("Combien de joueur veulent jouer ?");
    int nbj = 0;
    nbj = int.Parse(Console.ReadLine());
    for(int i = 1; i<nbj+1;i++)
    {
        Console.WriteLine("Veuillez donner le nom du joueur " + i + " ;");
        string s = Console.ReadLine();
        
        m.ajouterJoueur(i, new Joueur(s, i));
    }
    m.afficherJoueurs();
    while(choix != -1)
    {
        Console.WriteLine("Appuyer sur 1 pour jouer, -1 pour quitter");
        choix = int.Parse(Console.ReadLine());
        if (choix == 1)
        {
            m.jouer();
        }
    }
    
}