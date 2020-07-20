using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioNegocios : IRepositorioNegocios
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioNegocios(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EstaRelacionado(Negocio negocio)
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

        public void Borrar(Negocio negocio)
        {
            try
            {
                _dbContext.Negocios.Remove(negocio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Existe(Negocio negocio)
        {
            try
            {
                if (negocio.NegocioId == 0)
                {
                    return _dbContext.Negocios.Any(n => n.Nombre == negocio.Nombre && n.Pais.Nombre==negocio.Pais.Nombre) ;

                }

                return _dbContext.Negocios.Any(n => n.Nombre == negocio.Nombre && n.Pais.Nombre == negocio.Pais.Nombre
                                                                               && n.NegocioId != negocio.NegocioId);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void Guardar(Negocio negocio)
        {
            try
            {
                if (negocio.NegocioId==0)
                {
                    _dbContext.Negocios.Add(negocio);
                }
                else
                {
                    _dbContext.Negocios.Attach(negocio);
                    _dbContext.Entry(negocio).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<Negocio> GetNegocios(Pais pais = null)
        {
            try
            {
                IQueryable<Negocio> query = _dbContext.Negocios.Include(n=>n.Pais);
                if (pais!=null)
                {
                    query = query.Where(n => n.Pais.Nombre == pais.Nombre);
                }

                return query.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
