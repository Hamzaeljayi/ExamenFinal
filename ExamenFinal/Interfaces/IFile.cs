using System; 

namespace ExamenFinal
{
    public interface IFile<T> : IStructureDonnees<T>
    {
        void Enfiler(T element);    // Enqueue
        T Defiler();              // Dequeue
        T Tete();                 // Peek
    }
}