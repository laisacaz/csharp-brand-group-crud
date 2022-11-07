using AutoMapper;
using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers
{
    public class BrandInsertCommandHandler : IRequestHandler<BrandInsertCommand, int>
    {
        private readonly IValidator<BrandInsertPayload> _validatorInsert;
        private readonly IMapper _mapper;
        private readonly BrandRepository _repository;

        public BrandInsertCommandHandler(
            IValidator<BrandInsertPayload> validatorInsert,
            IMapper mapper,
            BrandRepository repository)
        {
            _validatorInsert = validatorInsert;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(BrandInsertCommand request, CancellationToken cancellationToken)
        {
            _validatorInsert.ValidateAndThrow(request.Payload);
            Brand brand = _mapper.Map<Brand>(request.Payload);
            brand.Id = await _repository.InsertAsync(brand);
            return brand.Id;
        }
    }
}
