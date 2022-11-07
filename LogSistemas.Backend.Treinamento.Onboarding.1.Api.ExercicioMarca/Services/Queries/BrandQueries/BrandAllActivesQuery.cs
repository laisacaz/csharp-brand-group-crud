using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers
{
    public class BrandAllActivesQuery : IRequest<IEnumerable<BrandActivesDTO>>
    {
        public BrandAllActivesQuery()
        {

        }
    }
}
