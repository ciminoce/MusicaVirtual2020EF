using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public interface IServicioSoporte
    {
        List<Soporte> GetLista();
        void Guardar(Soporte soporte);
        bool Existe(Soporte soporte);
        bool EstaRelacionado(Soporte soporte);
        void Borrar(Soporte soporte);
    }
}