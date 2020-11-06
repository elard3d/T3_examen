
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models.Maps
{
    public class EjerciciosMap : IEntityTypeConfiguration<Ejercicios>
    {
        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Ejercicios");
            builder.HasKey(o => o.id);
        }
    }
}
