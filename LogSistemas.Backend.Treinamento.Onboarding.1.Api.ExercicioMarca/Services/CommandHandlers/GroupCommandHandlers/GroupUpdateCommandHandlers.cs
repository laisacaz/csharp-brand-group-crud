using AutoMapper;
using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.GroupCommands;
using MediatR;


namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers.GroupCommandHandlers
{
    public class GroupUpdateCommandHandlers : IRequestHandler<GroupUpdateCommand, Unit>
    {
        private readonly IValidator<GroupUpdatePayload> _validatorUpdate;
        private readonly IMapper _mapper;
        private readonly GroupRepository _repository;
        public GroupUpdateCommandHandlers(IValidator<GroupUpdatePayload> validatorUpdate,
             IMapper mapper,
             GroupRepository repository)
        {
            _mapper = mapper;
            _validatorUpdate = validatorUpdate;
            _repository = repository;
        }

        public async Task<Unit> Handle(GroupUpdateCommand request, CancellationToken cancellationToken)
        {

            request.Payload.SetId(request.Id);
            await _validatorUpdate.ValidateAndThrowAsync(request.Payload);
            Group? group = _mapper.Map<Group>(request.Payload);
            group.Id = request.Id;
            await _repository.UpdateAsync(group);
            return Unit.Value;
        }
    }
}
