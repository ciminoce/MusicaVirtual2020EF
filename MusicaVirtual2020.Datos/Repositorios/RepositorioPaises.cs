using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioPaises(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Pais> GetLista()
        {
            try
            {
                return _dbContext.Paises.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais
            {
                PaisId = reader.GetInt32(0),
                Nombre = reader.GetString(1)
            };
        }

 

        public void Guardar(Pais pais)
        {
            try
            {
                if (pais.PaisId==0)
                {
                    _dbContext.Paises.Add(pais);
                }
                else
                {
                    var paisInDb = _dbContext.Paises.SingleOrDefault(p => p.PaisId == pais.PaisId);
                    if (paisInDb!=null)
                    {
                        paisInDb.Nombre = pais.Nombre;
                        _dbContext.Entry(paisInDb).State = EntityState.Modified;
                    }
                    else
                    {
                        throw new Exception("País inexistente");
                    }
                }
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {

                if (pais.PaisId==0)
                {
                    return _dbContext.Paises.Any(p => p.Nombre == pais.Nombre);

                }

                return _dbContext.Paises.Any(p => p.Nombre == pais.Nombre && p.PaisId != pais.PaisId);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                //var cadenaComando = "SELECT COUNT(*) FROM Negocios WHERE PaisId=@id";
                //var comando=new SqlCommand(cadenaComando,_cn);
                //comando.Parameters.AddWithValue("@id", pais.PaisId);
                //int cantidadRegistros =(int) comando.ExecuteScalar();
                //if (cantidadRegistros>0)
                //{
                //    return true;
                //}

                //cadenaComando = "SELECT COUNT(*) FROM Interpretes WHERE PaisId=@id";
                //comando=new SqlCommand(cadenaComando,_cn);
                //comando.Parameters.AddWithValue("@id", pais.PaisId);
                //cantidadRegistros = (int) comando.ExecuteScalar();
                //return cantidadRegistros>0;
                return false;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Pais pais)
        {
            try
            {
                var paisInDb = _dbContext.Paises.SingleOrDefault(p => p.PaisId == pais.PaisId);
                if (paisInDb!=null)
                {
                    _dbContext.Entry(paisInDb).State = EntityState.Deleted;
                }
                else
                {
                    throw new Exception("Pais inexistente");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public Pais GetPaisPorId(int id)
        {
            try
            {
                return _dbContext.Paises.SingleOrDefault(p=>p.PaisId==id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
