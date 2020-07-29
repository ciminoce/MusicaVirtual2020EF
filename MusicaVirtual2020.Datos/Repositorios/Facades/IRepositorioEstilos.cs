using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios.Facades
{
    public interface IRepositorioEstilos
    {
        bool EstaRelacionado(Estilo estilo);
        bool Existe(Estilo estilo);
        void Guardar(Estilo estilo);
        List<Estilo> GetLista();
        void Borrar(Estilo estilo);
        Estilo GetEstiloPorId(int id);
    }
}