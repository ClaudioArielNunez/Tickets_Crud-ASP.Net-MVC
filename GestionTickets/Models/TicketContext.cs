using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GestionTickets.Models
{
    public partial class TicketContext : DbContext
    {
        public TicketContext()
            : base("name=TicketContext")
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Responsable> Responsable { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.IdEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Responsable>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Responsable)
                .HasForeignKey(e => e.IdResponsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Solucion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
