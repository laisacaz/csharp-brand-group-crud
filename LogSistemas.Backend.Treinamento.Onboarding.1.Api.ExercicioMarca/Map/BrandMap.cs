using AutoMapper;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;



namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Map
{
    public class BrandMap : Profile
    {
        public BrandMap()
        {
            CreateMap<BrandInsertPayload, Brand>();
            CreateMap<BrandUpdatePayload, Brand>();

        }
    }
}
