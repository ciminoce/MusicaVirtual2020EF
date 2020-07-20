using AutoMapper;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Entidades.Mapas
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadMappingInterpretes();
        }

        public void LoadMappingInterpretes()
        {
            CreateMap<Interprete,InterpreteListDto>()
                .ForMember(dest => dest.Pais, act => act.MapFrom(src => $"{src.Pais.Nombre}"));

        }
    }
}
