using System;
using System.Collections.Generic;

namespace ExamenFinal
{
    // ===========================================================
    //  ARBRE BST — À compléter
    // ===========================================================
    public class ArbreBST : IArbreBST
    {
        private NoeudArbre _racine;

        public ArbreBST() { _racine = null; }

        public void Inserer(int valeur) => _racine = InsererHelper(_racine, valeur);

        private NoeudArbre InsererHelper(NoeudArbre noeud, int valeur)
        {
            if (noeud == null) return new NoeudArbre(valeur);
            if (valeur < noeud.Valeur) noeud.Gauche = InsererHelper(noeud.Gauche, valeur);
            else if (valeur > noeud.Valeur) noeud.Droite = InsererHelper(noeud.Droite, valeur);
            return noeud;
        }

        public bool Contient(int valeur) => ContientHelper(_racine, valeur);

        private bool ContientHelper(NoeudArbre noeud, int valeur)
        {
            if (noeud == null) return false;
            if (valeur == noeud.Valeur) return true;
            return valeur < noeud.Valeur ? ContientHelper(noeud.Gauche, valeur) : ContientHelper(noeud.Droite, valeur);
        }

        public int TrouverMin()
        {
            if (_racine == null) throw new InvalidOperationException();
            NoeudArbre courant = _racine;
            while (courant.Gauche != null) courant = courant.Gauche;
            return courant.Valeur;
        }

        public int TrouverMax()
        {
            if (_racine == null) throw new InvalidOperationException();
            NoeudArbre courant = _racine;
            while (courant.Droite != null) courant = courant.Droite;
            return courant.Valeur;
        }

        public int Hauteur() => HauteurHelper(_racine);

        private int HauteurHelper(NoeudArbre noeud)
        {
            if (noeud == null) return 0;
            return 1 + Math.Max(HauteurHelper(noeud.Gauche), HauteurHelper(noeud.Droite));
        }

        public void ParcoursInfixe()
        {
            Console.Write("Infixe : ");
            InfixeHelper(_racine);
            Console.WriteLine();
        }

        private void InfixeHelper(NoeudArbre noeud)
        {
            if (noeud == null) return;
            InfixeHelper(noeud.Gauche);
            Console.Write(noeud.Valeur + " ");
            InfixeHelper(noeud.Droite);
        }

        public void ParcoursPrefixe()
        {
            Console.Write("Préfixe : ");
            PrefixeHelper(_racine);
            Console.WriteLine();
        }

        private void PrefixeHelper(NoeudArbre noeud)
        {
            if (noeud == null) return;
            Console.Write(noeud.Valeur + " ");
            PrefixeHelper(noeud.Gauche);
            PrefixeHelper(noeud.Droite);
        }

        public void ParcoursParNiveau()
        {
            if (_racine == null) return;
            Queue<NoeudArbre> file = new Queue<NoeudArbre>();
            file.Enqueue(_racine);
            while (file.Count > 0)
            {
                NoeudArbre n = file.Dequeue();
                Console.Write(n.Valeur + " ");
                if (n.Gauche != null) file.Enqueue(n.Gauche);
                if (n.Droite != null) file.Enqueue(n.Droite);
            }
        }
    }
}