using System.Data.Entity.ModelConfiguration;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.EntityTypeConfigurations
{
    public class TemasEntityTypeConfigurations:EntityTypeConfiguration<Tema>
    {
        public TemasEntityTypeConfigurations()
        {
            ToTable("Temas");
            //Notación utilizada para cambiar el nombre de una property
            //con respecto al campo de la bd
            Property(t => t.PistaNro).HasColumnName("PistaNumero");
            /*Se le dice EF que ignore dichas properties */
            Ignore(t => t.Duracion);
        }
    }
}
