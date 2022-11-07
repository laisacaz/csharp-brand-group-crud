using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using Swashbuckle.AspNetCore.Filters;


namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Example
{
    public class BrandUpdatePayloadExamples : IExamplesProvider<BrandUpdatePayload>
    {
        public BrandUpdatePayload GetExamples()
        {
            return new BrandUpdatePayload
            {
                Description = "Rolex and group",
                MainSupplier = null,
                Since = DateTime.UtcNow.AddDays(-3596),

            };
        }
    }
}
