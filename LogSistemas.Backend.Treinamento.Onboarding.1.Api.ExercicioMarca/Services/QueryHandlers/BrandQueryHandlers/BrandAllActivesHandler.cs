
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.QuerieHandlers
{
    public class BrandAllActivesHandler : IRequestHandler<BrandAllActivesQuery, IEnumerable<BrandActivesDTO>>
    {
        private readonly BrandRepository _repository;
        public BrandAllActivesHandler(BrandRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BrandActivesDTO>> Handle(BrandAllActivesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetActivesAsync();
        }
    }
}
