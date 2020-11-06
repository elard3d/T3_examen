using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models.Maps
{
    public class RutinaMap : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutina");

            builder.HasKey(o => o.id);

            builder.HasOne(o => o.usuario).WithMany().HasForeignKey(o => o.idUsuario);
        }
    }
}
