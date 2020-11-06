using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_examen.Models.Maps;

namespace T3_examen.Models
{
    public class EjercicioContext : DbContext
    {

        public EjercicioContext(DbContextOptions<EjercicioContext> options) : base(options) { }

        public DbSet<Ejercicios> ejercicios { get; set; }

        public virtual DbSet<Usuarios> usuarios{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EjerciciosMap()); 
        }

    }
}
