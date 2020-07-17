using System;
using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Servicios.Servicios.Facades;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioPais : IServicioPais
    {
        private readonly IRepositorioPaises _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioPais(IRepositorioPaises repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }


        public List<Pais> GetLista()
        {
            return _repositorio.GetLista();
        }

        public void Guardar(Pais pais)
        {
            _repositorio.Guardar(pais);
            _unitOfWork.Save();
        }

        public bool Existe(Pais pais)
        {
            return _repositorio.Existe(pais);
        }

        public bool EstaRelacionado(Pais pais)
        {
            return false;
        }
        public void Borrar(Pais pais)
        {
            _repositorio.Borrar(pais);
            _unitOfWork.Save();
        }

    }
}
