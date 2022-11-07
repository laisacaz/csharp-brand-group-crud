using Dapper.FluentMap.Dommel.Mapping;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.MapDb
{
    public class BrandMap : DommelEntityMap<Brand>
    {
        public BrandMap()
        {
            ToTable("pro_marca");
            Map(x => x.Id)
                .IsKey()
                .IsIdentity()
                .ToColumn("cod", false);
            Map(x => x.Active)
                .ToColumn("ativo", false);
            Map(x => x.Description)
                .ToColumn("description", false);
            Map(x => x.MainSupplier)
                .ToColumn("fornecedor_principal", false);
            Map(x => x.Since)
                .ToColumn("data_inicial", false);
        }
    }
}
