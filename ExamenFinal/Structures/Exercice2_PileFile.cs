using System;

namespace ExamenFinal
{
    // ===========================================================
    //  PARTIE A — Pile avec tableau dynamique  (15 pts)
    // ===========================================================
    public class PileTableau<T> : IPile<T>
    {
        private T[] _donnees;
        private int _sommet;          // index du prochain emplacement libre
        private const int CapaciteInitiale = 4;

        public PileTableau()
        {
            _donnees = new T[CapaciteInitiale];
            _sommet = 0;
        }

        public int Taille => _sommet;
        public bool EstVide => _sommet == 0;

        public void Empiler(T element)
        {
            if (_sommet == _donnees.Length)
                Redimensionner(_donnees.Length * 2);

            _donnees[_sommet++] = element;
        }

        public T Depiler()
        {
            if (EstVide) throw new InvalidOperationException("La pile est vide.");

            T valeur = _donnees[--_sommet];
            _donnees[_sommet] = default;

            if (_sommet > 0 && _sommet <= _donnees.Length / 4 && _donnees.Length / 2 >= CapaciteInitiale)
                Redimensionner(_donnees.Length / 2);

            return valeur;
        }

        public T Sommet()
        {
            if (EstVide) throw new InvalidOperationException("La pile est vide.");
            return _donnees[_sommet - 1];
        }

        public void Vider()
        {
            _donnees = new T[CapaciteInitiale];
            _sommet = 0;
        }

        public string Afficher()
        {
            if (EstVide) return "Vide";
            T[] temp = new T[_sommet];
            for (int i = 0; i < _sommet; i++) temp[i] = _donnees[_sommet - 1 - i];
            return string.Join(" | ", temp);
        }

        private void Redimensionner(int nouvelleCapacite)
        {
            T[] nouveauTableau = new T[nouvelleCapacite];
            Array.Copy(_donnees, nouveauTableau, _sommet);
            _donnees = nouveauTableau;
        }
    }

    // ===========================================================
    //  PARTIE B — File circulaire avec tableau  (15 pts)
    // ===========================================================
    public class FileCirculaire<T> : IFile<T>
    {
        private T[] _donnees;
        private int _debut;    // index du premier élément (tête)
        private int _fin;      // index du prochain emplacement libre (queue)
        private int _taille;   // nombre d'éléments actuels
        private readonly int _capacite;

        public FileCirculaire(int capacite)
        {
            _capacite = capacite;
            _donnees = new T[_capacite];
            _debut = 0;
            _fin = 0;
            _taille = 0;
        }

        public int Taille => _taille;
        public bool EstVide => _taille == 0;
        public bool EstPleine => _taille == _capacite;

        public void Enfiler(T element)
        {
            if (EstPleine) throw new InvalidOperationException("La file est pleine.");
            _donnees[_fin] = element;
            _fin = (_fin + 1) % _capacite;
            _taille++;
        }

        public T Defiler()
        {
            if (EstVide) throw new InvalidOperationException("La file est vide.");
            T valeur = _donnees[_debut];
            _donnees[_debut] = default;
            _debut = (_debut + 1) % _capacite;
            _taille--;
            return valeur;
        }

        public T Tete()
        {
            if (EstVide) throw new InvalidOperationException("La file est vide.");
            return _donnees[_debut];
        }

        public void Vider()
        {
            _debut = 0; _fin = 0; _taille = 0;
            Array.Clear(_donnees, 0, _capacite);
        }

        public string Afficher()
        {
            if (EstVide) return "Vide";
            T[] temp = new T[_taille];
            for (int i = 0; i < _taille; i++)
                temp[i] = _donnees[(_debut + i) % _capacite];
            return string.Join(" -> ", temp);
        }
    }
}