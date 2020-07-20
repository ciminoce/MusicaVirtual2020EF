using System.Data.Entity.ModelConfiguration;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.EntityTypeConfigurations
{
    public class InterpreteEntityTypeConfigurations:EntityTypeConfiguration<Interprete>
    {
        public InterpreteEntityTypeConfigurations()
        {
            ToTable("Interpretes");
        }
    }
}
