using Model;
using System;
using Model.AdmLibros;
using Model.Reservas;
using Model.Usuarios;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntity
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Data Source=BLX-CO-DRICAURT\\SQLEXPRESS;Initial Catalog=LibrayDB;Integrated Security=True")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libros> Libro { get; set; }
        public DbSet<EstadoReserva> Estados { get; set; }
        public DbSet<Reservas> Reserva { get; set; }
        public DbSet<TipoDocumento> TDocumento { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Autor Fluent API
            modelBuilder.Entity<Autor>().HasKey(s => s.IdAutor);
            modelBuilder.Entity<Autor>()
             .Property(a => a.IdAutor)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Autor>().Property(x => x.Nombres).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Autor>().Property(x => x.Apellidos).HasMaxLength(30).IsRequired();

            //Categoria Fluent API
            modelBuilder.Entity<Categoria>().HasKey(s => s.IdCategoria);
            modelBuilder.Entity<Categoria>()
             .Property(a => a.IdCategoria)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Categoria>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Categoria>().Property(x => x.Descripcion).HasMaxLength(500);

            //Editorial Fluent API 
            modelBuilder.Entity<Editorial>().HasKey(s => s.IdEditorial);
            modelBuilder.Entity<Editorial>()
             .Property(a => a.IdEditorial)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Editorial>().Property(x => x.NIT).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Editorial>().Property(x => x.NombreEditorial).HasMaxLength(30).IsRequired();

            //Libros Fluent API 
            modelBuilder.Entity<Libros>().HasKey(s => s.IdLibro);
            modelBuilder.Entity<Libros>()
           .Property(a => a.IdLibro)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Libros>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Libros>().Property(x => x.Idioma).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Libros>().Property(x => x.Disponible).IsRequired();
            modelBuilder.Entity<Libros>().Property(x => x.Sinapsis).HasMaxLength(3000).IsRequired();

            //Relaciones
            modelBuilder.Entity<Libros>()
           .HasRequired<Autor>(s => s.AutorLibro)
           .WithMany(g => g.AutoresLibros)
           .HasForeignKey<int>(s => s.IdAutor);

            modelBuilder.Entity<Libros>()
            .HasRequired<Categoria>(s => s.CategoriaLibro)
            .WithMany(g => g.CategoriaLibro)
            .HasForeignKey<int>(s => s.IdCategoria);

            modelBuilder.Entity<Libros>()
            .HasRequired<Editorial>(s => s.EditorialLibro)
            .WithMany(g => g.EditorialLibros)
            .HasForeignKey<int>(s => s.IdEditorial);

            //Estado Reserva Fluent API
            modelBuilder.Entity<EstadoReserva>().HasKey(s => s.IdEstado);
            modelBuilder.Entity<EstadoReserva>()
             .Property(a => a.IdEstado)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EstadoReserva>().Property(x => x.DescripcionEstado).HasMaxLength(30).IsRequired();

            //Reserva Fluent API 
            modelBuilder.Entity<Reservas>().HasKey(s => s.IdReserva);
            modelBuilder.Entity<Reservas>()
             .Property(a => a.IdReserva)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Reservas>().Property(x => x.FechaReserva).IsRequired();
            modelBuilder.Entity<Reservas>()
            .Property(f => f.FechaReserva)
            .HasColumnType("datetime2")
            .HasPrecision(0);
            modelBuilder.Entity<Reservas>().Property(x => x.FechaFinReserva).IsRequired();
            modelBuilder.Entity<Reservas>()
            .Property(f => f.FechaFinReserva)
            .HasColumnType("datetime2")
            .HasPrecision(0);

            //Relaciones 
            modelBuilder.Entity<Reservas>()
           .HasRequired<Usuarios>(s => s.UsuarioReserva)
           .WithMany(g => g.ReservasUsuario)
           .HasForeignKey<int>(s => s.IdUsuario);

            modelBuilder.Entity<Reservas>()
           .HasRequired<EstadoReserva>(s => s.ReservasEstado)
           .WithMany(g => g.EstadoReservas)
           .HasForeignKey<int>(s => s.IdEstadoReserva);

            modelBuilder.Entity<Reservas>()
            .HasRequired<Libros>(s => s.LibroReservado)
            .WithMany(g => g.ReservasLibro)
            .HasForeignKey<int>(s => s.IdLibro);

            //Tipo Documento FluentAPI 
            modelBuilder.Entity<TipoDocumento>().HasKey(s => s.Id);
            modelBuilder.Entity<TipoDocumento>()
             .Property(a => a.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TipoDocumento>().Property(x => x.Tipo).HasMaxLength(4).IsRequired();

            //Usuarios FluentAPI
            modelBuilder.Entity<Usuarios>().HasKey(s => s.IdUsuario);
            modelBuilder.Entity<Usuarios>()
             .Property(a => a.IdUsuario)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Usuarios>().Property(x => x.Nombres).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Apellidos).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.NumeroIdentificacion).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Direccion).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Telefono).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Usuarios>().Property(x => x.Estado).IsRequired();

            //Relaciones
            modelBuilder.Entity<Usuarios>()
            .HasRequired<TipoDocumento>(s => s.TipoDocumento)
            .WithMany(g => g.TDocumentoUsuarios)
            .HasForeignKey<int>(s => s.IdTipoDocumento);

            base.OnModelCreating(modelBuilder);
        }
    }
}
