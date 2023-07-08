using ExamenFinalIncomel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinalIncomel.Data
{
    public class UsuarioDBContext : DbContext
    {
        public UsuarioDBContext(DbContextOptions<UsuarioDBContext>options):base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }  

        public DbSet<EmpleadosModel> Empleados { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadosModel>().ToTable("empleados");
            modelBuilder.Entity<UsuarioModel>().ToTable("usuarios");
        }
    }
}
