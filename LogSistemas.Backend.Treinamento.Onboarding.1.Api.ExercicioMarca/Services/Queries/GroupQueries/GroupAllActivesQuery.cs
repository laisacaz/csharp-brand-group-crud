using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries
{
    public class GroupAllActivesQuery : IRequest<IEnumerable<GroupActivesDTO>>
    {
        public GroupAllActivesQuery()
        {

        }
    }
}
