using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.GroupCommands
{
    public class GroupUpdateCommand : IRequest
    {
        public GroupUpdateCommand(int id, GroupUpdatePayload payload)
        {
            Id = id;
            Payload = payload;
        }
        public int Id { get; }
        public GroupUpdatePayload Payload { get; }
    }
}
