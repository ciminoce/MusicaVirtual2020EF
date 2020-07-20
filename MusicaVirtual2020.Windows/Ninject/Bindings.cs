using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios;
using MusicaVirtual2020.Datos.Repositorios.Facades;
using MusicaVirtual2020.Servicios.Servicios;
using MusicaVirtual2020.Servicios.Servicios.Facades;
using Ninject.Modules;

namespace MusicaVirtual2020.Windows.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<MusicaDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioPaises>().To<RepositorioPaises>();
            Bind<IServicioPais>().To<ServicioPais>();

            Bind<IRepositorioSoportes>().To<RepositorioSoportes>();
            Bind<IServicioSoporte>().To<ServicioSoporte>();

            Bind<IRepositorioInterpretes>().To<RepositorioInterpretes>();
            Bind<IServicioInterprete>().To<ServicioInterprete>();

        }
    }
}
