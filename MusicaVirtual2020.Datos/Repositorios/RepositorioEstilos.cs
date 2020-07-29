using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioEstilos : IRepositorioEstilos
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioEstilos(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EstaRelacionado(Estilo estilo)
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public bool Existe(Estilo estilo)
        {
            try
            {
                if (estilo.EstiloId==0)
                {
                    return _dbContext.Estilos.Any(e => e.Nombre == estilo.Nombre);
                }

                return _dbContext.Estilos
                    .Any(e => e.Nombre == estilo.Nombre && e.EstiloId != estilo.EstiloId);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public void Guardar(Estilo estilo)
        {
            try
            {
                if (estilo.EstiloId==0)
                {
                    _dbContext.Estilos.Add(estilo);

                }
                else
                {
                    _dbContext.Estilos.Attach(estilo);
                    _dbContext.Entry(estilo).State = EntityState.Modified;
                }
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
                return _dbContext.Estilos.ToList();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Estilo estilo)
        {
            try
            {
                _dbContext.Estilos.Attach(estilo);
                _dbContext.Entry(estilo).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Estilo GetEstiloPorId(int id)
        {
            return _dbContext.Estilos.SingleOrDefault(e => e.EstiloId == id);
        }
      
    }
}
