using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public interface IServicioNegocio
    {
        void Borrar(Negocio negocio);
        bool Existe(Negocio negocio);
        void Guardar(Negocio negocio);
        List<Negocio> GetNegocios(Pais pais = null);
        bool EstaRelaciona(Negocio negocio);
    }
}