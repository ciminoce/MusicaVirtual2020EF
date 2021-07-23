using System.Collections.Generic;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.Repositorios.Facades
{
    public interface IRepositorioTemas
    {
        void Guardar(Tema tema);
        void Borrar(Tema tema);
        List<Tema> GetTemasPorAlbum(int id);
        void RenumerarTemas(int albumId);
    }
}