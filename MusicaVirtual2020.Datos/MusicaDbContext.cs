using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos
{
    public class MusicaDbContext:DbContext
    {
        public MusicaDbContext():base("MiConexion")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MusicaDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que tome las configuraciones del  mismo assembly
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Soporte> Soportes { get; set; }
        public DbSet<Interprete> Interpretes { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
    }
}
