using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using MediatR;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries
{
    public class BrandByIdQuery : IRequest<Brand>
    {
        public BrandByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
