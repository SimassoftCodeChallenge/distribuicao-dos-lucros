using DapperExtensions.Mapper;
using Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Infra.Sqlite.Mapeamentos
{
    public class FuncionarioMap : ClassMapper<Funcionario>
    {
        public FuncionarioMap()
        {
            Table("funcionario");
            Map(f => f.Id).Column("id").Key(KeyType.Identity);
            Map(f => f.Matricula).Column("matricula");
            Map(f => f.Nome).Column("nome");
            Map(f => f.Area).Column("area");
            Map(f => f.Cargo).Column("cargo");
            Map(f => f.SalarioBruto).Column("salariobruto");
            Map(f => f.Estagiario).Column("estagiario");            
        }
    }
}
