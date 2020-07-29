using System;
using System.Collections.Generic;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public class ServicioEstilo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly repositorio;

        public ServicioEstilo()
        {
        }

        public void Guardar(Estilo estilo)
        {
            try
            {
                conexion=new ConexionBd();
                repositorio=new RepositorioEstilos(conexion.AbrirConexion());
                //var estilo = Mapeador.ConvertirEstilo(estiloDto);
                repositorio.Agregar(estilo);
                
                conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public List<Estilo> GetLista()
        {
            try
            {
                conexion=new ConexionBd();
                repositorio=new RepositorioEstilos(conexion.AbrirConexion());
                var lista=repositorio.GetLista();
                
                conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}
