namespace ExamenFinal
{
    public interface IPile<T> : IStructureDonnees<T>
    {
        void Empiler(T element);    // Push
        T Depiler();              // Pop  — lève InvalidOperationException si vide
        T Sommet();               // Peek — lève InvalidOperationException si vide
    }
}