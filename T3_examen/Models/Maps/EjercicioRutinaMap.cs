using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models.Maps
{
    public class EjercicioRutinaMap : IEntityTypeConfiguration<EjercicioRutina>
    {
        public void Configure(EntityTypeBuilder<EjercicioRutina> builder)
        {
            builder.ToTable("EjercicioRutina");
            builder.HasKey(o => o.idEjercicioRutina);


            builder.HasOne(o => o.ejercicios).WithMany().HasForeignKey(o => o.idEjercicio);
            builder.HasOne(o => o.rutina).WithMany().HasForeignKey(o => o.idRutina);
        }
    }
}
