using System.Collections.Generic;
using System.Data.SqlClient;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.DTOs.Negocio;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios.Facades
{
    public interface IRepositorioAlbumes
    {
        List<AlbumListDto> GetLista();
        void Guardar(Album album);
        List<InterpreteAlbumesDto> GetCantidadPorInterprete();
        List<NegocioAlbumesDto> GetCantidadPorNegocio();
        void Borrar(int Id);
        Album GetAlbumPorId(int id);
    }
}