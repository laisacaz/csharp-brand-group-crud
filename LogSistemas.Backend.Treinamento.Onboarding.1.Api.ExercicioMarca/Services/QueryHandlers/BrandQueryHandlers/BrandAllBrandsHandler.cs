using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QuerieHandlers
{
    public class BrandAllBrandsHandler : IRequestHandler<BrandAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly BrandRepository _repository;
        public BrandAllBrandsHandler(BrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Brand>> Handle(BrandAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
