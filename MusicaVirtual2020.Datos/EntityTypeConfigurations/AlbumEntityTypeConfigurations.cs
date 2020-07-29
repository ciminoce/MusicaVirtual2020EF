using System.Data.Entity.ModelConfiguration;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.EntityTypeConfigurations
{
    public class AlbumEntityTypeConfigurations : EntityTypeConfiguration<Album>
    {
        public AlbumEntityTypeConfigurations()
        {
            ToTable("Albumes");
            
        }
    }
}
