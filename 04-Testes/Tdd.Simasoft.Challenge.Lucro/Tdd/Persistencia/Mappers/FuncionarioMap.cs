using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using local = Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.Entidades;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.Mappers
{
    public class FuncionarioMap : ClassMapper<local.Funcionario>
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
