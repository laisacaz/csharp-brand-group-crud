using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.GroupCommands
{
    public class GroupInsertCommand : IRequest<int>
    {
        public GroupInsertCommand(GroupInsertPayload payload)
        {
            Payload = payload;
        }
        public GroupInsertPayload Payload { get; }
    }
}
