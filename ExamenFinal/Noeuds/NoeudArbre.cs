namespace ExamenFinal
{
    public class NoeudArbre
    {
        public int Valeur { get; set; }
        public NoeudArbre Gauche { get; set; }
        public NoeudArbre Droite { get; set; }

        public NoeudArbre(int valeur)
        {
            Valeur = valeur;
            Gauche = null;
            Droite = null;
        }
    }
}