using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioSoportes : IRepositorioSoportes
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioSoportes(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Soporte> GetLista()
        {
            try
            {
                return _dbContext.Soportes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Soporte ConstruirSoporte(SqlDataReader reader)
        {
            return new Soporte
            {
                SoporteId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }



        public void Guardar(Soporte soporte)
        {
            try
            {
                if (soporte.SoporteId == 0)
                {
                    _dbContext.Soportes.Add(soporte);
                }
                else
                {
                    var soporteInDb = _dbContext.Soportes.SingleOrDefault(p => p.SoporteId == soporte.SoporteId);
                    if (soporteInDb != null)
                    {
                        soporteInDb.Descripcion = soporte.Descripcion;
                        _dbContext.Entry(soporteInDb).State = EntityState.Modified;
                    }
                    else
                    {
                        throw new Exception("Soporte inexistente");
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Soporte soporte)
        {
            try
            {

                if (soporte.SoporteId == 0)
                {
                    return _dbContext.Soportes.Any(p => p.Descripcion == soporte.Descripcion);

                }

                return _dbContext.Soportes.Any(p => p.Descripcion == soporte.Descripcion && p.SoporteId != soporte.SoporteId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Soporte soporte)
        {
            return false;
        }

        public void Borrar(Soporte soporte)
        {
            try
            {
                var soporteInDb = _dbContext.Soportes.SingleOrDefault(p => p.SoporteId == soporte.SoporteId);
                if (soporteInDb != null)
                {
                    _dbContext.Entry(soporteInDb).State = EntityState.Deleted;
                }
                else
                {
                    throw new Exception("Soporte inexistente");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public Soporte GetSoportePorId(int id)
        {
            try
            {
                return _dbContext.Soportes.SingleOrDefault(s=>s.SoporteId==id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
