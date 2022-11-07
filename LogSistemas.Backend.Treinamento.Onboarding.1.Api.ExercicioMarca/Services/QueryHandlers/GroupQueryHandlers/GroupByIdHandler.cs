using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QueryHandlers.GroupQueryHandlers
{
    public class GroupByIdHandler : IRequestHandler<GroupByIdQuery, Group>
    {
        private readonly GroupRepository _repository;
        public GroupByIdHandler(GroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Group> Handle(GroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
