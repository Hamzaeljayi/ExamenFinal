// =============================================================
//  420-SD4-AS | Examen Final | Session Été 2025
//  Fichier : IStructureDonnees.cs
//  CONSIGNE : Ne pas modifier ce fichier.
// =============================================================

namespace ExamenFinal
{
    /// <summary>
    /// Interface commune à toutes les structures de données de l'examen.
    /// </summary>
    public interface IStructureDonnees<T>
    {
        /// <summary>Retourne le nombre d'éléments dans la structure.</summary>
        int Taille { get; }

        /// <summary>Retourne true si la structure est vide.</summary>
        bool EstVide { get; }

        /// <summary>Vide complètement la structure.</summary>
        void Vider();

        /// <summary>Retourne une représentation textuelle de la structure.</summary>
        string Afficher();
    }
}