using System;

namespace MusicaVirtual2020.Entidades.Entities
{
    public class Estilo:ICloneable
    {
        public int EstiloId { get; set; }
        public string Nombre { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
