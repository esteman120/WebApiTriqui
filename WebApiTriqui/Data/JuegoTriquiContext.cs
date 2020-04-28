using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTriqui.Models;

namespace WebApiTriqui.Data
{
    public class JuegoTriquiContext: DbContext
    {
        public JuegoTriquiContext(DbContextOptions<JuegoTriquiContext> options): base(options)
        {

        }

        
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TiposIdentificacion> TipoIdentificacion { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Usuarios>(usuario =>
            {
                usuario.ToTable("Usuarios");
                usuario.Property(x => x.Id).HasColumnName("Id");
                usuario.Property(x => x.Nombre).HasColumnName("Nombre");
                usuario.Property(x => x.Apellido).HasColumnName("Apellido");
                
                usuario.Property(x => x.NumeroIdentificacion).HasColumnName("NumeroIdentificacion");
                usuario.Property(x => x.Contrasena).HasColumnName("Contrasena");
                usuario.Property(x => x.Correo).HasColumnName("Correo");

                usuario.HasOne(x => x.TipoIdentificacion).WithMany(t => t.usuarios).HasForeignKey(y => y.TipoIdentificacionId);
            });

            model.Entity<TiposIdentificacion>(TipoIdentificacion =>
            {
                TipoIdentificacion.ToTable("TipoIdentificacion");
                TipoIdentificacion.Property(x => x.Tipo).HasColumnName("TipoIdentificacion");
            });
           
        }
    }
}
