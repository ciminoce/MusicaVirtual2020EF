using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios.Facades
{
    public interface IServicioPais
    {
        List<Pais> GetLista();
        void Guardar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        void Borrar(Pais pais);
    }
}