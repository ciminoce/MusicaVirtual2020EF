using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.DTOs.Negocio;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioAlbumes : IRepositorioAlbumes
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioAlbumes(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<AlbumListDto> GetLista()
        {
            try
            {
                return _dbContext.Albumes.Include(a=>a.Interprete)
                    .Select(a=>
                        new AlbumListDto
                        {
                            AlbumId = a.AlbumId,
                            Titulo = a.Titulo,
                            Interprete = a.Interprete.Nombre,
                            Pistas = a.Pistas
                        }).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



        public void Guardar(Album album)
        {
            try
            {
                if (album.AlbumId==0)
                {
                    _dbContext.Albumes.Add(album);
                }
                else
                {
                    _dbContext.Albumes.Attach(album);
                    _dbContext.Entry(album).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<InterpreteAlbumesDto> GetCantidadPorInterprete()
        {
            try
            {
                var grupo=_dbContext.Albumes
                    .Include(a => a.Interprete)
                    .GroupBy(a => a.Interprete.Nombre);
                var lista=new List<InterpreteAlbumesDto>();
                foreach (var g in grupo)
                {
                    var item = new InterpreteAlbumesDto
                    {
                        Interprete = g.Key,
                        Cantidad = g.Count()
                    };
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        public List<NegocioAlbumesDto> GetCantidadPorNegocio()
        {
            try
            {
                var grupo = _dbContext.Albumes
                    .Include(a => a.Negocio)
                    .GroupBy(a => a.Negocio.Nombre);
                var lista = new List<NegocioAlbumesDto>();
                foreach (var g in grupo)
                {
                    var item = new NegocioAlbumesDto
                    {
                        Negocio = g.Key,
                        Cantidad = g.Count()
                    };
                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public void Borrar(int Id)
        {
            try
            {

                var albumInDb = _dbContext.Albumes
                    .SingleOrDefault(a => a.AlbumId == Id);
                if (albumInDb != null)
                {
                    _dbContext.Albumes.Attach(albumInDb);
                    _dbContext.Entry(albumInDb).State = EntityState.Deleted;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Album GetAlbumPorId(int id)
        {
            try
            {
                var album = _dbContext.Albumes
                    .Include(a=>a.Negocio)
                    .Include(a => a.Interprete)
                    .Include(a => a.Temas)
                    .Include(a=>a.Soporte)
                    .Include(a=>a.Estilo)
                    .SingleOrDefault(a => a.AlbumId == id);
                return album;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
