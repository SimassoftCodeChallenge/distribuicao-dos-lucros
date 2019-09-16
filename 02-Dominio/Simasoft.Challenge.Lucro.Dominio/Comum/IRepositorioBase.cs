using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simasoft.Challenge.Lucro.Dominio.Comum
{
    public interface IRepositorioBase<T> where T : class
    {
        T Listar(object predicado);
        IEnumerable<T> ListarTodos();
        IEnumerable<T> PegaLista(object predicate);
        void Inserir(T obj);
        void Inserir(IEnumerable<T> obj);
        long InserirRetornandoId(T obj);
        IEnumerable<long> InserirRetornandoId(IEnumerable<T> obj);
        void Atualizar(T obj);
        void Apagar(object predicado);
        bool Apagar(T obj);
    }
}
