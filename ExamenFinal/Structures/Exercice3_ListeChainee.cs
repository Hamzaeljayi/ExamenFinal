using System;

namespace ExamenFinal
{
    public abstract class ListeChaineeBase<T> : IStructureDonnees<T>
    {
        protected Noeud<T> _tete;
        protected Noeud<T> _queue;
        protected int _taille;

        public int Taille => _taille;
        public bool EstVide => _taille == 0;

        public abstract void InsererEnTete(T valeur);
        public abstract void InsererEnQueue(T valeur);
        public abstract T SupprimerEnTete();
        public abstract T SupprimerEnQueue();
        public abstract void Vider();
        public abstract string Afficher();
    }

    // ===========================================================
    //  PARTIE A — Liste doublement chaînée  (20 pts)
    // ===========================================================
    public class ListeDoublementChainee<T> : ListeChaineeBase<T>
    {
        public override void InsererEnTete(T valeur)
        {
            Noeud<T> nouveau = new Noeud<T>(valeur);
            if (EstVide) _tete = _queue = nouveau;
            else
            {
                nouveau.Suivant = _tete;
                _tete.Precedent = nouveau;
                _tete = nouveau;
            }
            _taille++;
        }

        public override void InsererEnQueue(T valeur)
        {
            Noeud<T> nouveau = new Noeud<T>(valeur);
            if (EstVide) _tete = _queue = nouveau;
            else
            {
                nouveau.Precedent = _queue;
                _queue.Suivant = nouveau;
                _queue = nouveau;
            }
            _taille++;
        }

        public override T SupprimerEnTete()
        {
            if (EstVide) throw new InvalidOperationException();
            T valeur = _tete.Valeur;
            _tete = _tete.Suivant;
            if (_tete == null) _queue = null;
            else _tete.Precedent = null;
            _taille--;
            return valeur;
        }

        public override T SupprimerEnQueue()
        {
            if (EstVide) throw new InvalidOperationException();
            T valeur = _queue.Valeur;
            _queue = _queue.Precedent;
            if (_queue == null) _tete = null;
            else _queue.Suivant = null;
            _taille--;
            return valeur;
        }

        public override void Vider() { _tete = _queue = null; _taille = 0; }

        public override string Afficher()
        {
            if (EstVide) return "Vide";
            string s = "";
            Noeud<T> courant = _tete;
            while (courant != null)
            {
                s += courant.Valeur + (courant.Suivant != null ? " <-> " : "");
                courant = courant.Suivant;
            }
            return s;
        }

        public void AfficherInverseRecursif()
        {
            AfficherInverseHelper(_queue);
            Console.WriteLine();
        }

        private void AfficherInverseHelper(Noeud<T> noeud)
        {
            if (noeud == null) return;
            Console.Write(noeud.Valeur + " ");
            AfficherInverseHelper(noeud.Precedent);
        }
    }

    // ===========================================================
    //  PARTIE B — Sous-classe spécialisée (10 pts)
    // ===========================================================
    public class ListeOrdonneeCroissante : ListeDoublementChainee<int>
    {
        public void InsererTrie(int valeur)
        {
            if (EstVide || valeur <= _tete.Valeur) { InsererEnTete(valeur); return; }
            if (valeur >= _queue.Valeur) { InsererEnQueue(valeur); return; }

            Noeud<int> courant = _tete;
            while (courant != null && courant.Valeur < valeur)
                courant = courant.Suivant;

            Noeud<int> nouveau = new Noeud<int>(valeur);
            nouveau.Suivant = courant;
            nouveau.Precedent = courant.Precedent;
            courant.Precedent.Suivant = nouveau;
            courant.Precedent = nouveau;
            _taille++;
        }

        public override string Afficher() => "[ORDONNÉE] " + base.Afficher();
    }
}