using System.Collections.Generic;
using MusicaVirtual2020.Entidades.DTOs.Interprete;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public interface IServicioInterprete
    {
        void Borrar(Interprete interprete);
        bool Existe(Interprete interprete);
        void Guardar(Interprete interprete);
        List<Interprete> GetInterpretes(Pais pais = null);
        bool EstaRelaciona(Interprete interprete);
    }
}