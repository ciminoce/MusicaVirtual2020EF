using System.Data.Entity.ModelConfiguration;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.EntityTypeConfigurations
{
    public class TemasEntityTypeConfigurations:EntityTypeConfiguration<Tema>
    {
        public TemasEntityTypeConfigurations()
        {
            ToTable("Temas");
            Property(t => t.PistaNro).HasColumnName("PistaNumero");
        }
    }
}
