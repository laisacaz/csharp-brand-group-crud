using Dapper.FluentMap.Dommel.Mapping;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.MapDb
{
    public class GroupMap : DommelEntityMap<Group>
    {
        public GroupMap()
        {
            ToTable("pro_grupo");
            Map(x => x.Id)
             .IsKey()
                .IsIdentity()
                .ToColumn("cod", false);
            Map(x => x.Active)
              .ToColumn("ativo", false);
            Map(x => x.Description)
                .ToColumn("descricao", false);
            Map(x => x.EnableSubgroup)
                .ToColumn("subgrupo", false);
            Map(x => x.Since)
                .ToColumn("data_inicial", false);
        }
    }
}
