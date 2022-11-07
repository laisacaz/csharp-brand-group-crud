using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.BrandCommands
{
    public class BrandUpdateCommand : IRequest
    {
        public BrandUpdateCommand(int id, BrandUpdatePayload payload)
        {
            Id = id;
            Payload = payload;
        }
        public int Id { get; }
        public BrandUpdatePayload Payload { get; }
    }
}
