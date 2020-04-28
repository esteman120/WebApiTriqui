﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiTriqui.Data;

namespace WebApiTriqui.Migrations
{
    [DbContext(typeof(JuegoTriquiContext))]
    [Migration("20200428001004_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiTriqui.Models.TiposIdentificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnName("TipoIdentificacion");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TipoIdentificacion");
                });

            modelBuilder.Entity("WebApiTriqui.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnName("Apellido");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnName("Contrasena");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnName("Correo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Nombre");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasColumnName("NumeroIdentificacion");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApiTriqui.Models.TiposIdentificacion", b =>
                {
                    b.HasOne("WebApiTriqui.Models.Usuarios", "Usuario")
                        .WithOne("TipoIdentificacion")
                        .HasForeignKey("WebApiTriqui.Models.TiposIdentificacion", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
