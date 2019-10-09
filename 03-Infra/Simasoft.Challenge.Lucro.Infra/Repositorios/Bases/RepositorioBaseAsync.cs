using System.Collections.Generic;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum;

namespace Simasoft.Challenge.Lucro.Infra.Repositorios.Bases
{
    public abstract class RepositorioBaseAsync<T> : IConnectionFactory ,IRepositorioBaseAsync<T> where T : class
    {             
        public abstract Task<bool> ApagarAsync(T obj);        
        public abstract Task AtualizarAsync(T obj);
        public abstract Task<long> InserirAsync(T obj);
        public abstract Task InserirAsync(IEnumerable<T> obj);
        public abstract Task<IEnumerable<T>> ListarPor(object filtro);      
        public abstract Task<IEnumerable<T>> ListarTodosAsync(); 
        public abstract void RepositorioConnectionFactory(string connectionString);       
    }
}