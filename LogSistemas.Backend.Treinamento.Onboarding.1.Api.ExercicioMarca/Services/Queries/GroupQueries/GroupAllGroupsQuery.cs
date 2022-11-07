using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries
{
    public class GroupAllGroupsQuery : IRequest<IEnumerable<Group>>
    {
        public GroupAllGroupsQuery()
        {

        }
    }
}
