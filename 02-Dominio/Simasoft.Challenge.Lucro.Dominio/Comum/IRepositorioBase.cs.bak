using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simasoft.Challenge.Lucro.Dominio.Comum
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> Listar(object predicado);
        Task<IEnumerable<T>> ListarTodos();
        Task<IEnumerable<T>> PegaLista(object predicate);
        Task Inserir(T obj);
        Task Inserir(IEnumerable<T> obj);
        Task<long> InserirRetornandoId(T obj);
        Task<IEnumerable<long>> InserirRetornandoId(IEnumerable<T> obj);
        Task Atualizar(T obj);
        Task Apagar(object predicado);        
    }
}
