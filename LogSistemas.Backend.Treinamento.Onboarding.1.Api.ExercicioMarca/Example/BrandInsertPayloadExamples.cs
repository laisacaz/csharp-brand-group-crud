using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using Swashbuckle.AspNetCore.Filters;
using Type = LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload.Type;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Example
{
    public class BrandInsertPayloadExamples : IExamplesProvider<BrandInsertPayload>
    {
        public BrandInsertPayload GetExamples()
        {
            return new BrandInsertPayload
            {
                Description = "Rolex and group",
                MainSupplier = null,
                Since = DateTime.UtcNow.AddDays(-3596),
                type = Type.Clothes
            };
        }
    }
}
