using System.Collections.Generic;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.DTOs.Negocio;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public interface IServicioAlbumes
    {
        List<AlbumListDto> GetAlbumes();
        void Guardar(Album album);
        List<InterpreteAlbumesDto> GetCantidadPorInterprete();
        List<NegocioAlbumesDto> GetCantidadPorNegocio();
        Album GetAlbumPorId(int albumDtoAlbumId);
        void Borrar(int albumDtoAlbumId);
    }
}