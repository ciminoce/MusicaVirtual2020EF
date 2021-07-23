using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Entidades.Entities;
using MusicaVirtual2020.Entidades.Entities.Enums;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public class RepositorioTemas : IRepositorioTemas
    {
        private readonly MusicaDbContext _dbContext;

        public RepositorioTemas(MusicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Guardar(Tema tema)
        {
            try
            {
                if (tema.TemaId==0)
                {
                    _dbContext.Temas.Add(tema);
                }
                else
                {
                    //TODO:Ver como hacer para los casos de edición

                    _dbContext.Temas.Attach(tema);
                    _dbContext.Entry(tema).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public List<Tema> GetTemasPorAlbum(int Id)
        {
            try
            {
                return _dbContext.Temas.Where(t => t.AlbumId == Id)
                    .OrderBy(t => t.PistaNro)
                    .ToList();
                //var lista= _dbContext.Temas.Where(t => t.AlbumId == Id)
                //    .OrderBy(t => t.PistaNro)
                //    .ToList();
                //lista.ForEach(t=>t.Estado=Estado.SinCambios);
                //return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RenumerarTemas(int albumId)
        {
            try
            {
                var listaTemas = _dbContext.Temas.Where(t => t.AlbumId == albumId).ToList();
                short contadorTemas = 0;
                listaTemas.ForEach(t =>
                {
                    contadorTemas++;
                    t.PistaNro = contadorTemas;
                    _dbContext.Temas.Attach(t);
                    _dbContext.Entry(t).State = EntityState.Modified;
                });
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Tema tema)
        {
            try
            {
                _dbContext.Temas.Attach(tema);
                _dbContext.Entry(tema).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Tema> GetAll()
        {
            try
            {
                return _dbContext.Temas.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
