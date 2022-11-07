using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QueryHandlers.GroupQueryHandlers
{
    public class GroupAllGroupsHandler : IRequestHandler<GroupAllGroupsQuery, IEnumerable<Group>>
    {
        private readonly GroupRepository _repository;
        public GroupAllGroupsHandler(GroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Group>> Handle(GroupAllGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
