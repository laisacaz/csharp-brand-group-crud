using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries
{
    public class BrandAllBrandsQuery : IRequest<IEnumerable<Brand>>
    {
        public BrandAllBrandsQuery()
        {

        }
    }
}
