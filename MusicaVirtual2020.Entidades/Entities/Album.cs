using System;
using System.Collections.Generic;

namespace MusicaVirtual2020.Entidades.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        public int InterpreteId { get; set; }
        public Interprete Interprete { get; set; }
        public int EstiloId { get; set; }
        public Estilo Estilo { get; set; }
        public int SoporteId { get; set; }
        public Soporte Soporte { get; set; }
        public Int16 Pistas { get; set; }
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
        public int AnioCompra { get; set; }
        public decimal Costo { get; set; }
        public List<Tema> Temas { get; set; }=new List<Tema>();
    }
}
