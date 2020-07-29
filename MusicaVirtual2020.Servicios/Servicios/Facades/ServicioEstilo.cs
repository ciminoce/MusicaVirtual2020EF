using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public class ServicioEstilo : IServicioEstilo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioEstilos _repositorio;

        public ServicioEstilo(IUnitOfWork unitOfWork, IRepositorioEstilos repositorio)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
        }

        public bool Existe(Estilo estilo)
        {
            return _repositorio.Existe(estilo);
        }

        public bool EstaRelacionado(Estilo estilo)
        {
            return _repositorio.EstaRelacionado(estilo);
        }

        public void Borrar(Estilo estilo)
        {
            _repositorio.Borrar(estilo);
            _unitOfWork.Save();
        }
        public void Guardar(Estilo estilo)
        {
            _repositorio.Guardar(estilo);
            _unitOfWork.Save();
        }
        public List<Estilo> GetLista()
        {
            return _repositorio.GetLista();
        }
    }
}
