using System.Collections.Generic;
namespace Catalogo.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T serie);

        void Exclui(int id);

        void Ataliza(int id, T serie);

        int ProximoId();
    }
}