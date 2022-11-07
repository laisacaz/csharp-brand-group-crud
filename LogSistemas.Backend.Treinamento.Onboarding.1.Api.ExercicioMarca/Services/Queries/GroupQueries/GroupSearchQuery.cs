using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries
{
    public class GroupSearchQuery : IRequest<BasePagedSearchDTO<GroupPagedSearchDTO>>
    {
        public GroupSearchQuery(GroupPagedSearchPayload payload)
        {
            Payload = payload;
        }
        public GroupPagedSearchPayload Payload { get; }
    }
}
