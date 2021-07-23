using System;
using MusicaVirtual2020.Entidades.Entities.Enums;

namespace MusicaVirtual2020.Entidades.Entities
{
    public class Tema
    {
        public int TemaId { get; set; }
        public short PistaNro { get; set; }
        public string Nombre { get; set; }

        /*El tiempo se almacena como un bigint en Sql
         que es la cantidad de ticks
         y se lee como long*/
        public long Tiempo { get; set; } 

        /*Campo de tipo TimeSpan (intervalo de tiempo)
         que se lee convirtiendo el valor de los ticks
        que está en la property Tiempo
         */
        public TimeSpan Duracion {
            get => new TimeSpan(Tiempo);
            private set => Tiempo = value.Ticks;
        }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public override bool Equals(object obj)
        {
            if (obj==null || !(obj is Tema))
            {
                return false;
            }

            return this.Nombre.ToUpper() == ((Tema) obj).Nombre.ToUpper();
        }
        public override int GetHashCode()
        {
            return this.TemaId;
        }
    }
}
