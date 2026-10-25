namespace ExamenFinal
{
    /// <summary>Nœud d'une liste doublement chaînée.</summary>
    public class Noeud<T>
    {
        public T Valeur { get; set; }
        public Noeud<T> Suivant { get; set; }
        public Noeud<T> Precedent { get; set; }

        public Noeud(T valeur)
        {
            Valeur = valeur;
            Suivant = null;
            Precedent = null;
        }
    }
}