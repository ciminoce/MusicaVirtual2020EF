using AutoMapper;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Entidades.Mapas
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadMappingInterpretes();
            LoadMappingAlbumes();
        }

        public void LoadMappingInterpretes()
        {
            CreateMap<Interprete,InterpreteListDto>()
                .ForMember(dest => dest.Pais, act => act.MapFrom(src => $"{src.Pais.Nombre}"));

        }

        public void LoadMappingAlbumes()
        {
            CreateMap<Album, AlbumListDto>()
                .ForMember(dest => dest.Interprete, act => act.MapFrom(src => $"{src.Interprete.Nombre}"));
        }
    }
}
