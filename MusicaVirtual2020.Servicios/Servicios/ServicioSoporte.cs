using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioSoporte : IServicioSoporte
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioSoportes _repositorio;

        public ServicioSoporte(IUnitOfWork unitOfWork, IRepositorioSoportes repositorio)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
        }
        public List<Soporte> GetLista()
        {
            return _repositorio.GetLista();
        }

        public void Guardar(Soporte soporte)
        {
            _repositorio.Guardar(soporte);
            _unitOfWork.Save();
            
        }

        public bool Existe(Soporte soporte)
        {
            return _repositorio.Existe(soporte);
        }

        public bool EstaRelacionado(Soporte soporte)
        {
            return _repositorio.EstaRelacionado(soporte);
        }
        public void Borrar(Soporte soporte)
        {
            _repositorio.Borrar(soporte);
            _unitOfWork.Save();
        }

    }
}
