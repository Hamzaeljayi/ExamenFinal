namespace ExamenFinal
{
    public interface IArbreBST
    {
        void Inserer(int valeur);
        bool Contient(int valeur);
        int TrouverMin();
        int TrouverMax();
        int Hauteur();
        void ParcoursInfixe();     // gauche → racine → droite  (résultat trié)
        void ParcoursPrefixe();    // racine → gauche → droite
        void ParcoursParNiveau();  // BFS avec Queue<NoeudArbre>
    }
}