using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QueryHandlers.GroupQueryHandlers
{
    public class GroupSearchHandler : IRequestHandler<GroupSearchQuery, BasePagedSearchDTO<GroupPagedSearchDTO>>
    {
        private readonly GroupRepository _repository;
        private readonly IValidator<GroupPagedSearchPayload> _validator;

        public GroupSearchHandler(GroupRepository repository, IValidator<GroupPagedSearchPayload> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<BasePagedSearchDTO<GroupPagedSearchDTO>> Handle(GroupSearchQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Payload);
            return await _repository.Search(
                 active: request.Payload.Active,
                 description: request.Payload.Description,
                 enablesubgroup: request.Payload.EnableSubgroup,
                 limit: request.Payload.GetLimit(),
                 offset: request.Payload.GetOffSet());
        }
    }
}
