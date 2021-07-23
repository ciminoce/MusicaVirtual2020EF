using System;
using System.Data.Entity;
using MusicaVirtual2020.Datos;
using MusicaVirtual2020.Datos.Repositorios;

namespace ConvertirATicks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Programa de consola usado para convertir la duración
             en tiempo de tipo bigint para luego tratarla como un objeto
            TimeSpan (intervalo de tiempo) que es más adecuado*/
            //MusicaDbContext dbContext=new MusicaDbContext();
            //RepositorioTemas repositorioTemas=new RepositorioTemas(dbContext);
            //var temas = repositorioTemas.GetAll();
            //temas.ForEach(t =>
            //{
            //    if (t.Duracion!=null && t.Duracion!=0.0)
            //    {
            //        var tiempos = t.Duracion.ToString().Split(',');
            //        if (tiempos.Length>1)
            //        {
            //            var ticks=new TimeSpan(0,0,int.Parse(tiempos[0]),int.Parse(tiempos[1])).Ticks;
            //            Console.WriteLine($"{t.Duracion} {tiempos[0]} {tiempos[1]} {ticks}");
            //            //t.Tiempo = ticks;
            //        }
            //        else
            //        {
            //            var ticks=new TimeSpan(0,0,int.Parse(tiempos[0]),0).Ticks;
            //            Console.WriteLine($"{t} {tiempos[0]} {ticks} ");
            //            //t.Tiempo = ticks;
            //        }

            //        dbContext.Entry(t).State = EntityState.Modified;
            //        dbContext.SaveChanges();
            //    }

            //});
            //Console.ReadLine();
        }
    }
}
