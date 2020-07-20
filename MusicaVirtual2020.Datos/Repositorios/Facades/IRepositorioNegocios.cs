using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios.Facades
{
    public interface IRepositorioNegocios
    {
        bool EstaRelacionado(Negocio negocio);
        void Borrar(Negocio negocio);
        bool Existe(Negocio negocio);
        void Guardar(Negocio negocio);
        List<Negocio> GetNegocios(Pais pais = null);
    }
}