using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Entidades.Mapas;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioInterpretes : IRepositorioInterpretes
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioInterpretes(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool EstaRelacionado(Interprete interprete)
        {
            return false;
        }

        public void Borrar(Interprete interprete)
        {
            try
            {
                var interpreteInDb =
                    _dbContext.Interpretes.SingleOrDefault(i => i.InterpreteId == interprete.InterpreteId);
                if (interpreteInDb!=null)
                {
                    _dbContext.Entry(interpreteInDb).State = EntityState.Deleted;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Existe(Interprete interprete)
        {
            try
            {

                if (interprete.InterpreteId == 0)
                {
                    return _dbContext.Interpretes.Any(i =>
                        i.Nombre == interprete.Nombre && i.Pais.Nombre == interprete.Pais.Nombre);

                }

                return _dbContext.Interpretes.Any(i =>
                    i.Nombre == interprete.Nombre && i.Pais.Nombre == interprete.Pais.Nombre
                                                  && i.InterpreteId != interprete.InterpreteId);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public void Guardar(Interprete interprete)
        {
            try
            {
                _dbContext.Interpretes.Add(interprete);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        public List<Interprete> GetInterpretes(Pais pais)
        {
            try
            {
                IQueryable<Interprete> query = _dbContext.Interpretes.Include(i => i.Pais);
                if (pais!=null)
                {
                    query = query.Where(i => i.Pais.PaisId== pais.PaisId);
                }

                var lista = query.ToList();
                return lista;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        //private Interprete ConstruirInterprete(SqlDataReader reader)
        //{
        //    return new Interprete
        //    {
        //        InterpreteId = reader.GetInt32(0),
        //        Nombre = reader.GetString(1),
        //        Pais = _repositorioPaises.GetPaisPorId(reader.GetInt32(2))
        //    };
        //}

        public Interprete GetInterpretePorId(int id)
        {
            try
            {
                return _dbContext.Interpretes
                    .Include(i=>i.Pais).SingleOrDefault(i=>i.InterpreteId==id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //private Interprete ConstruirInterprete(SqlDataReader reader)
        //{
        //    return new Interprete
        //    {
        //        InterpreteId = reader.GetInt32(0),
        //        Nombre = reader.GetString(1)
        //    };
        //}
    }
}
