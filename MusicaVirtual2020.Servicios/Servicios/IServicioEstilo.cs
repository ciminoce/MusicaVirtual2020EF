using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Servicios.Servicios
{
    public interface IServicioEstilo
    {
        bool Existe(Estilo estilo);
        bool EstaRelacionado(Estilo estilo);
        void Borrar(Estilo estilo);
        void Guardar(Estilo estilo);
        List<Estilo> GetLista();
    }
}