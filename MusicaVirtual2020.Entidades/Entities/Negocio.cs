using System;
using System.Security.AccessControl;

namespace MusicaVirtual2020.Entidades.Entities
{
    public class Negocio:ICloneable
    {
        public int NegocioId { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
