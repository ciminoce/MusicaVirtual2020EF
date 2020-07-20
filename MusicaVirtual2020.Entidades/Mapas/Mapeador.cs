using AutoMapper;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Entidades.Mapas
{
    public class Mapeador
    {
        private static Mapper _mapper;
        static readonly MapperConfiguration Config = new MapperConfiguration(cfg =>
            cfg.AddProfile<MappingProfile>());

        public static Mapper CrearMapper()
        {
            _mapper = new Mapper(Config);
            return _mapper;
        }

        //public static AlbumListDto ConvertirDesdeAlbum(Album album)
        //{
        //    return new AlbumListDto
        //    {
        //        AlbumId = album.AlbumId,
        //        Titulo = album.Titulo,
        //        Interprete = album.Interprete.Nombre,
        //        Pistas = album.Pistas,
        //    };
        //}

    }
}
