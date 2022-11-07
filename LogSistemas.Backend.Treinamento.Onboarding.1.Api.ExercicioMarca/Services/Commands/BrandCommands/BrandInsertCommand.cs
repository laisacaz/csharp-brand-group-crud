using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands
{
    public class BrandInsertCommand : IRequest<int>
    {
        public BrandInsertCommand(BrandInsertPayload payload)
        {
            Payload = payload;
        }
        public BrandInsertPayload Payload { get; }

    }
}
