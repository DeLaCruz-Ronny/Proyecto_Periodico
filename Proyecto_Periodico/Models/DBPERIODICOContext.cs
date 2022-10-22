using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_Periodico.Models
{
    public partial class DBPERIODICOContext : DbContext
    {
        public DBPERIODICOContext()
        {
        }

        public DBPERIODICOContext(DbContextOptions<DBPERIODICOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Noticia> Noticia { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-SC15GE0; DataBase=DBPERIODICO;Integrated Security=true");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1027C60CA8");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.Property(e => e.Contenido).HasColumnType("text");

                entity.Property(e => e.Extracto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaP)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_P")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Noticia__IdCateg__29572725");


                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Noticia__IdUsuar__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97957C962E");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
