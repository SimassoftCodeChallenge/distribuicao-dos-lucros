using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Infra.Colaborador
{
    public class ColaboradorMap : ClassMapper<Colaborador>
    {
        public ColaboradorMap()
        {
            Table("funcionario");
            Map(f => f.Id).Column("id").Key(KeyType.Identity);
            Map(f => f.Matricula).Column("matricula");
            Map(f => f.Nome).Column("nome");
            Map(f => f.Area).Column("area");
            Map(f => f.Cargo).Column("cargo");
            Map(f => f.SalarioBruto).Column("salariobruto");
            Map(f => f.Estagiario).Column("estagiario");
            AutoMap();
        }
    }
}
