using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries
{
    public class GroupByIdQuery : IRequest<Group>
    {
        public GroupByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
