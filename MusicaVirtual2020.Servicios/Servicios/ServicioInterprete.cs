using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioInterprete : IServicioInterprete
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioInterpretes _repositorio;

        public ServicioInterprete(IUnitOfWork unitOfWork, IRepositorioInterpretes repositorio)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
        }

        public void Borrar(Interprete interprete)
        {
            _repositorio.Borrar(interprete);
            _unitOfWork.Save();
        }
        public bool Existe(Interprete interprete)
        {
            return _repositorio.Existe(interprete);
        }
        public void Guardar(Interprete interprete)
        {
            _repositorio.Guardar(interprete);
            _unitOfWork.Save();
        }
        public List<Interprete> GetInterpretes(Pais pais=null)
        {
            return _repositorio.GetInterpretes(pais);
        }

        public bool EstaRelaciona(Interprete interprete)
        {
            return _repositorio.EstaRelacionado(interprete);
        }
    }
}
