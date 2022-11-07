using AutoMapper;
using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.BrandCommands;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers.BrandCommandHandlers
{
    public class BrandUpdateCommandHandler : IRequestHandler<BrandUpdateCommand, Unit>
    {
        private readonly IValidator<BrandUpdatePayload> _validatorUpdate;
        private readonly IMapper _mapper;
        private readonly BrandRepository _repository;
        public BrandUpdateCommandHandler(IValidator<BrandUpdatePayload> validatorUpdate,
            IMapper mapper,
            BrandRepository repository)
        {
            _validatorUpdate = validatorUpdate;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(BrandUpdateCommand request, CancellationToken cancellationToken)
        {
            request.Payload.SetId(request.Id);
            await _validatorUpdate.ValidateAndThrowAsync(request.Payload);
            Brand? brand = _mapper.Map<Brand>(request.Payload);
            brand.Id = request.Id;
            await _repository.UpdateAsync(brand);
            return Unit.Value;
        }
    }
}
