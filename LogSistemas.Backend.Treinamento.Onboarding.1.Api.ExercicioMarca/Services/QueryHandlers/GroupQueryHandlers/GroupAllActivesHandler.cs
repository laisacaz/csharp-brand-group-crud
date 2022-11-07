using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QueryHandlers.GroupQueryHandlers
{
    public class GroupAllActivesHandler : IRequestHandler<GroupAllActivesQuery, IEnumerable<GroupActivesDTO>>
    {
        private readonly GroupRepository _repository;
        public GroupAllActivesHandler(GroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GroupActivesDTO>> Handle(GroupAllActivesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetActivesAsync();
        }
    }
}
