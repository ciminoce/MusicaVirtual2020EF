﻿using System.Data.Entity.ModelConfiguration;
using MusicaVirtual2020.Entidades.Entities;

namespace MusicaVirtual2020.Datos.EntityTypeConfigurations
{
    public class NegocioEntityTypeConfigurations:EntityTypeConfiguration<Negocio>
    {
        public NegocioEntityTypeConfigurations()
        {
            ToTable("Negocios");
        }
    }
}
