using System.Collections.Generic;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios
{
    public interface IRepositorioInterpretes
    {
        bool EstaRelacionado(Interprete interprete);
        void Borrar(Interprete interprete);
        bool Existe(Interprete interprete);
        void Guardar(Interprete interprete);
        List<Interprete> GetInterpretes(Pais pais);
        Interprete GetInterpretePorId(int id);
    }
}