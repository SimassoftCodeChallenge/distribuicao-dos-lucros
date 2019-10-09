using System.Collections.Generic;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum;

namespace Simasoft.Challenge.Lucro.Infra.Repositorios.Bases
{
    public abstract class RepositorioBase<T> : IConnectionFactory, IRepositorioBase<T> where T : class
    {
        public abstract bool Apagar(T obj);        
        public abstract void Atualizar(T obj);        
        public abstract long? Inserir(T obj);
        public abstract void Inserir(IEnumerable<T> obj);
        public abstract IEnumerable<T> ListarPor(object filtro);        
        public abstract IEnumerable<T> ListarTodos();
        public abstract void RepositorioConnectionFactory(string connectionString);        
    }
}