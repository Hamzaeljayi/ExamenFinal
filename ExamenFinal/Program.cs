using System;
using System.Reflection;
using System.Text; // Nécessaire pour Encoding

namespace ExamenFinal
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Force la console à accepter les symboles spéciaux (UTF-8)
            // Cela remplace les '?' par les vraies icônes.
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║      EXAMEN FINAL - STRUCTURES       ║");
            Console.WriteLine("╚══════════════════════════════════════╝\n");

            // Orchestration via réflexion : aucune logique métier ici
            RunAll();

            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

       
        static void RunAll()
        {
            // Trouve toutes les méthodes privées statiques de cette classe
            MethodInfo[] methodes = typeof(Program)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

            foreach (MethodInfo m in methodes)
            {
                // On n'exécute que les méthodes qui commencent par "Test"
                if (m.Name.StartsWith("Test"))
                {
                    Console.WriteLine($"▶ Exécution : {m.Name}");
                    try
                    {
                        m.Invoke(null, null);
                        Console.WriteLine("  ✔ Succès\n");
                    }
                    catch (Exception ex)
                    {
                        // Affiche l'erreur précise si un test échoue
                        Console.WriteLine($"  ✘ Erreur : {ex.InnerException?.Message ?? ex.Message}\n");
                    }
                }
            }
        }

     
        static void TestExercice2_PileEtFile()
        {
            // Test de la Pile (LIFO)
            PileTableau<int> pile = new PileTableau<int>();
            pile.Empiler(10);
            pile.Empiler(20);
            Console.WriteLine($"  Pile (Sommet -> Bas) : {pile.Afficher()}");

            // Test de la File (FIFO)
            FileCirculaire<string> file = new FileCirculaire<string>(5);
            file.Enfiler("Adnan");
            file.Enfiler("LaSalle");
            Console.WriteLine($"  File (Tête -> Queue) : {file.Afficher()}");
        }

        static void TestExercice3_ListeDoublementChainee()
        {
            var liste = new ListeDoublementChainee<int>();
            liste.InsererEnQueue(100);
            liste.InsererEnQueue(200);
            liste.InsererEnTete(50);
            Console.WriteLine($"  Liste : {liste.Afficher()}");

            if (liste.Taille != 3) throw new Exception("La taille devrait être de 3.");
        }

        static void TestExercice3_ListeOrdonnee()
        {
            var ordonnee = new ListeOrdonneeCroissante();
            ordonnee.InsererTrie(30);
            ordonnee.InsererTrie(10);
            ordonnee.InsererTrie(20);
            Console.WriteLine($"  {ordonnee.Afficher()}");
        }

        static void TestExercice4_ArbreBST()
        {
            ArbreBST arbre = new ArbreBST();
            int[] valeurs = { 50, 30, 70, 20, 40 };
            foreach (int v in valeurs) arbre.Inserer(v);

            Console.Write("  ");
            arbre.ParcoursInfixe(); // Doit afficher : 20 30 40 50 70

            if (arbre.TrouverMin() != 20) throw new Exception("Le minimum est incorrect.");
        }
    }
}