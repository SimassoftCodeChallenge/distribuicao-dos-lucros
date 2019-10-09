using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum
{
    public interface IRepositorioBaseAsync<T> where T: class
    {         
         Task<bool> ApagarAsync(T obj);
         Task AtualizarAsync(T obj);
         Task<long> InserirAsync(T obj);
         Task InserirAsync(IEnumerable<T> obj);                          
         Task InserirAsync(T[] obj);
         Task<IEnumerable<T>> ListarTodosAsync();  
         Task<IEnumerable<T>> ListarPorAsync(object filtro);
    }
}