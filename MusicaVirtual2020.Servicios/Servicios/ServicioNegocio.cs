using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioNegocio : IServicioNegocio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioNegocios _repositorio;

        public ServicioNegocio(IUnitOfWork unitOfWork, IRepositorioNegocios repositorio)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
        }

        public void Borrar(Negocio negocio)
        {
            _repositorio.Borrar(negocio);
            _unitOfWork.Save();
        }
        public bool Existe(Negocio negocio)
        {
            return _repositorio.Existe(negocio);
        }
        public void Guardar(Negocio negocio)
        {
            _repositorio.Guardar(negocio);
            _unitOfWork.Save();
            
        }
        public List<Negocio> GetNegocios(Pais pais = null)
        {
            return _repositorio.GetNegocios(pais);
        }

        public bool EstaRelaciona(Negocio negocio)
        {
            return _repositorio.EstaRelacionado(negocio);
        }

    }
}
