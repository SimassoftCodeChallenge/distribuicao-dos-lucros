using System.Collections.Generic;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum
{
    public interface IRepositorioBase<T> where T: class
    {        
         bool Apagar(T obj);
         void Atualizar(T obj);
         long? Inserir(T obj);
         void Inserir(IEnumerable<T> obj);                          
         IEnumerable<T> ListarTodos();   
         IEnumerable<T> ListarPor(object filtro);        
    }    
}