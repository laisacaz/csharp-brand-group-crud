using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QuerieHandlers
{
    public class BrandByIdHandler : IRequestHandler<BrandByIdQuery, Brand>
    {
        private readonly BrandRepository _repository;
        public BrandByIdHandler(BrandRepository repository)
        {
            _repository = repository;
        }
        public async Task<Brand> Handle(BrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
