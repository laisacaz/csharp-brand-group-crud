using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.BrandQueries
{
    public class BrandSearchQuery : IRequest<BasePagedSearchDTO<BrandPagedSearchDTO>>
    {
        public BrandSearchQuery(BrandPagedSearchPayload payload)
        {
            Payload = payload;
        }
        public BrandPagedSearchPayload Payload { get; }
    }
}
