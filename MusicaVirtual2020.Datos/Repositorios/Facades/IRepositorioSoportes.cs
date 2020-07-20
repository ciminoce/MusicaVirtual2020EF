using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios.Facades
{
    public interface IRepositorioSoportes
    {
        List<Soporte> GetLista();
        void Guardar(Soporte soporte);
        bool Existe(Soporte soporte);
        bool EstaRelacionado(Soporte soporte);
        void Borrar(Soporte soporte);
        Soporte GetSoportePorId(int id);
    }
}