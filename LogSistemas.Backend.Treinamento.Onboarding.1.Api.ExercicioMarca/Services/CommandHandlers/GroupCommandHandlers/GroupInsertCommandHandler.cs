using AutoMapper;
using FluentValidation;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.GroupCommands;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers.GroupCommandHandlers
{
    public class GroupInsertCommandHandler : IRequestHandler<GroupInsertCommand, int>
    {
        private readonly GroupRepository _repository;
        private readonly IValidator<GroupInsertPayload> _validatorInsert;
        private readonly IMapper _mapper;
        public GroupInsertCommandHandler
            (IValidator<GroupInsertPayload> validatorInsert,
             IMapper mapper,
             GroupRepository repository)
        {
            _mapper = mapper;
            _validatorInsert = validatorInsert;
            _repository = repository;
        }

        public async Task<int> Handle(GroupInsertCommand request, CancellationToken cancellationToken)
        {
            _validatorInsert.ValidateAndThrow(request.Payload);

            Group group = _mapper.Map<Group>(request.Payload);
            group.Id = await _repository.InsertAsync(group);
            group.Active = true;
            return group.Id;
        }
    }
}
