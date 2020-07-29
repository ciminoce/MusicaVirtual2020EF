using System;
using System.Collections.Generic;
using System.Transactions;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.DTOs.Album;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.DTOs.Negocio;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioAlbumes : IServicioAlbumes
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioAlbumes _repositorioAlbumes;
        private readonly IRepositorioTemas _repositorioTemas;
        private readonly MusicaDbContext _dbContext;

        public ServicioAlbumes(IUnitOfWork unitOfWork, IRepositorioAlbumes repositorioAlbumes, IRepositorioTemas repositorioTemas, MusicaDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _repositorioAlbumes = repositorioAlbumes;
            _repositorioTemas = repositorioTemas;
            _dbContext = dbContext;
        }

        public List<AlbumListDto> GetAlbumes()
        {
            return _repositorioAlbumes.GetLista();
        }

        public void Guardar(Album album)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorioAlbumes.Guardar(album);
                    _unitOfWork.Save();
                    
                    if (album.Temas.Count > 0)
                    {
                        album.Temas.ForEach(t =>
                        {
                            t.AlbumId = album.AlbumId;
                            _repositorioTemas.Guardar(t);
                            _unitOfWork.Save();
                        });
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

        }

        public List<InterpreteAlbumesDto> GetCantidadPorInterprete()
        {
            return _repositorioAlbumes.GetCantidadPorInterprete();
        }

        public List<NegocioAlbumesDto> GetCantidadPorNegocio()
        {
            return _repositorioAlbumes.GetCantidadPorNegocio();
        }

        public Album GetAlbumPorId(int id)
        {
            return _repositorioAlbumes.GetAlbumPorId(id);
        }

        public void Borrar(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var temas = _repositorioTemas.GetTemasPorAlbum(id);
                    temas.ForEach(t => _repositorioTemas.Borrar(t));
                    _repositorioAlbumes.Borrar(id);
                    _unitOfWork.Save();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
