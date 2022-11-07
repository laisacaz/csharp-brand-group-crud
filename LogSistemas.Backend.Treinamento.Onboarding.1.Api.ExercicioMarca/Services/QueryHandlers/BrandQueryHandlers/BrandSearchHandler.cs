using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.BrandQueries;

using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QuerieHandlers.BrandQuerieHandlers
{
    public class BrandSearchHandler : IRequestHandler<BrandSearchQuery, BasePagedSearchDTO<BrandPagedSearchDTO>>
    {
        private readonly BrandRepository _repository;
        private readonly IValidator<BrandPagedSearchPayload> _validatorSearch;
        public BrandSearchHandler(BrandRepository repository, IValidator<BrandPagedSearchPayload> validatorSearch)
        {
            _repository = repository;
            _validatorSearch = validatorSearch;
        }
        public async Task<BasePagedSearchDTO<BrandPagedSearchDTO>> Handle(BrandSearchQuery request, CancellationToken cancellationToken)
        {
            _validatorSearch.ValidateAndThrow(request.Payload);
            return await _repository.PagedSearchAsync(
              Active: request.Payload.Active,
              Description: request.Payload.Description,
              MainSupplier: request.Payload.MainSupplier,
             limit: request.Payload.GetLimit(),
             offset: request.Payload.GetOffSet());

        }
    }
}
