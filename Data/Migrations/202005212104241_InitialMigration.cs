namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        IdAutor = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 30),
                        Apellidos = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdAutor);
            
            CreateTable(
                "dbo.Libros",
                c => new
                    {
                        IdLibro = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        IdAutor = c.Int(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        IdEditorial = c.Int(nullable: false),
                        Sinapsis = c.String(nullable: false, maxLength: 3000),
                        Idioma = c.String(nullable: false, maxLength: 20),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdLibro)
                .ForeignKey("dbo.Autors", t => t.IdAutor, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Editorials", t => t.IdEditorial, cascadeDelete: true)
                .Index(t => t.IdAutor)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdEditorial);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Editorials",
                c => new
                    {
                        IdEditorial = c.Int(nullable: false, identity: true),
                        NIT = c.String(nullable: false, maxLength: 10),
                        NombreEditorial = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdEditorial);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        IdReserva = c.Int(nullable: false, identity: true),
                        FechaReserva = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        IdUsuario = c.Int(nullable: false),
                        IdLibro = c.Int(nullable: false),
                        IdEstadoReserva = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReserva)
                .ForeignKey("dbo.Libros", t => t.IdLibro, cascadeDelete: true)
                .ForeignKey("dbo.EstadoReservas", t => t.IdEstadoReserva, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdLibro)
                .Index(t => t.IdEstadoReserva);
            
            CreateTable(
                "dbo.EstadoReservas",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        DescripcionEstado = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 30),
                        Apellidos = c.String(nullable: false, maxLength: 30),
                        IdTipoDocumento = c.Int(nullable: false),
                        NumeroIdentificacion = c.String(nullable: false, maxLength: 30),
                        Direccion = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.TipoDocumentoes", t => t.IdTipoDocumento, cascadeDelete: true)
                .Index(t => t.IdTipoDocumento);
            
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "IdTipoDocumento", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.Reservas", "IdEstadoReserva", "dbo.EstadoReservas");
            DropForeignKey("dbo.Reservas", "IdLibro", "dbo.Libros");
            DropForeignKey("dbo.Libros", "IdEditorial", "dbo.Editorials");
            DropForeignKey("dbo.Libros", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Libros", "IdAutor", "dbo.Autors");
            DropIndex("dbo.Usuarios", new[] { "IdTipoDocumento" });
            DropIndex("dbo.Reservas", new[] { "IdEstadoReserva" });
            DropIndex("dbo.Reservas", new[] { "IdLibro" });
            DropIndex("dbo.Reservas", new[] { "IdUsuario" });
            DropIndex("dbo.Libros", new[] { "IdEditorial" });
            DropIndex("dbo.Libros", new[] { "IdCategoria" });
            DropIndex("dbo.Libros", new[] { "IdAutor" });
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.EstadoReservas");
            DropTable("dbo.Reservas");
            DropTable("dbo.Editorials");
            DropTable("dbo.Categorias");
            DropTable("dbo.Libros");
            DropTable("dbo.Autors");
        }
    }
}
