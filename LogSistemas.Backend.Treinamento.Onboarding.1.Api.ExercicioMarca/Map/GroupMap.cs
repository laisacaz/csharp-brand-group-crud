using AutoMapper;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;


namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Map
{
    public class GroupMap : Profile
    {
        public GroupMap()
        {
            CreateMap<GroupInsertPayload, Group>();
            CreateMap<GroupUpdatePayload, Brand>();
            CreateMap<Group, GroupActivesDTO>();
            CreateMap<Brand, GroupPagedSearchDTO>();
        }
    }
}
