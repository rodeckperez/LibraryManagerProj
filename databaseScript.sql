
CREATE DATABASE [LibrayDB] 

go 

USE [LibrayDB] 

go 

CREATE TABLE [dbo].[autors] 
  ( 
     [idautor]   [INT] IDENTITY(1, 1) NOT NULL, 
     [nombres]   [NVARCHAR](30) NOT NULL, 
     [apellidos] [NVARCHAR](30) NOT NULL, 
     CONSTRAINT [PK_dbo.Autors] PRIMARY KEY CLUSTERED ( [idautor] ASC )WITH ( 
     pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[categorias] 
  ( 
     [idcategoria] [INT] IDENTITY(1, 1) NOT NULL, 
     [nombre]      [NVARCHAR](30) NOT NULL, 
     [descripcion] [NVARCHAR](500) NULL, 
     CONSTRAINT [PK_dbo.Categorias] PRIMARY KEY CLUSTERED ( [idcategoria] ASC ) 
     WITH (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[editorials] 
  ( 
     [ideditorial]     [INT] IDENTITY(1, 1) NOT NULL, 
     [nit]             [NVARCHAR](10) NOT NULL, 
     [nombreeditorial] [NVARCHAR](30) NOT NULL, 
     CONSTRAINT [PK_dbo.Editorials] PRIMARY KEY CLUSTERED ( [ideditorial] ASC ) 
     WITH (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[estadoreservas] 
  ( 
     [idestado]          [INT] IDENTITY(1, 1) NOT NULL, 
     [descripcionestado] [NVARCHAR](30) NOT NULL, 
     CONSTRAINT [PK_dbo.EstadoReservas] PRIMARY KEY CLUSTERED ( [idestado] ASC ) 
     WITH (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[libros] 
  ( 
     [idlibro]     [INT] IDENTITY(1, 1) NOT NULL, 
     [nombre]      [NVARCHAR](30) NOT NULL, 
     [idautor]     [INT] NOT NULL, 
     [idcategoria] [INT] NOT NULL, 
     [ideditorial] [INT] NOT NULL, 
     [sinapsis]    [NVARCHAR](3000) NOT NULL, 
     [idioma]      [NVARCHAR](20) NOT NULL, 
     [disponible]  [BIT] NOT NULL, 
     CONSTRAINT [PK_dbo.Libros] PRIMARY KEY CLUSTERED ( [idlibro] ASC )WITH ( 
     pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[reservas] 
  ( 
     [idreserva]       [INT] IDENTITY(1, 1) NOT NULL, 
     [fechareserva]    [DATETIME2](0) NOT NULL, 
     [idusuario]       [INT] NOT NULL, 
     [idlibro]         [INT] NOT NULL, 
     [idestadoreserva] [INT] NOT NULL, 
     [fechafinreserva] [DATETIME2](0) NOT NULL, 
     CONSTRAINT [PK_dbo.Reservas] PRIMARY KEY CLUSTERED ( [idreserva] ASC )WITH 
     (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[tipodocumentoes] 
  ( 
     [id]   [INT] IDENTITY(1, 1) NOT NULL, 
     [tipo] [NVARCHAR](4) NOT NULL, 
     CONSTRAINT [PK_dbo.TipoDocumentoes] PRIMARY KEY CLUSTERED ( [id] ASC )WITH 
     (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE TABLE [dbo].[usuarios] 
  ( 
     [idusuario]            [INT] IDENTITY(1, 1) NOT NULL, 
     [nombres]              [NVARCHAR](30) NOT NULL, 
     [apellidos]            [NVARCHAR](30) NOT NULL, 
     [idtipodocumento]      [INT] NOT NULL, 
     [numeroidentificacion] [NVARCHAR](30) NOT NULL, 
     [direccion]            [NVARCHAR](30) NOT NULL, 
     [telefono]             [NVARCHAR](30) NOT NULL, 
     [estado]               [BIT] NOT NULL, 
     CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED ( [idusuario] ASC )WITH 
     (pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF, 
     allow_row_locks = on, allow_page_locks = on, optimize_for_sequential_key = 
     OFF) ON [PRIMARY] 
  ) 
ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdAutor] 
  ON [dbo].[Libros] ( [idautor] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdCategoria] 
  ON [dbo].[Libros] ( [idcategoria] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdEditorial] 
  ON [dbo].[Libros] ( [ideditorial] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdEstadoReserva] 
  ON [dbo].[Reservas] ( [idestadoreserva] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdLibro] 
  ON [dbo].[Reservas] ( [idlibro] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdUsuario] 
  ON [dbo].[Reservas] ( [idusuario] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

CREATE NONCLUSTERED INDEX [IX_IdTipoDocumento] 
  ON [dbo].[Usuarios] ( [idtipodocumento] ASC ) 
  WITH (pad_index = OFF, statistics_norecompute = OFF, sort_in_tempdb = OFF, 
drop_existing = OFF, online = OFF, allow_row_locks = ON, allow_page_locks = ON, 
optimize_for_sequential_key = OFF) ON [PRIMARY] 

go 

ALTER TABLE [dbo].[reservas] 
  ADD DEFAULT ('1900-01-01T00:00:00.000') FOR [FechaFinReserva] 

go 

ALTER TABLE [dbo].[usuarios] 
  ADD DEFAULT ((0)) FOR [Estado] 

go 

ALTER TABLE [dbo].[libros] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Libros_dbo.Autors_IdAutor] FOREIGN KEY( 
  [idautor]) REFERENCES [dbo].[autors] ([idautor]) ON DELETE CASCADE 

go 

ALTER TABLE [dbo].[libros] 
  CHECK CONSTRAINT [FK_dbo.Libros_dbo.Autors_IdAutor] 

go 

ALTER TABLE [dbo].[libros] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Libros_dbo.Categorias_IdCategoria] FOREIGN 
  KEY([idcategoria]) REFERENCES [dbo].[categorias] ([idcategoria]) ON DELETE 
  CASCADE 

go 

ALTER TABLE [dbo].[libros] 
  CHECK CONSTRAINT [FK_dbo.Libros_dbo.Categorias_IdCategoria] 

go 

ALTER TABLE [dbo].[libros] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Libros_dbo.Editorials_IdEditorial] FOREIGN 
  KEY([ideditorial]) REFERENCES [dbo].[editorials] ([ideditorial]) ON DELETE 
  CASCADE 

go 

ALTER TABLE [dbo].[libros] 
  CHECK CONSTRAINT [FK_dbo.Libros_dbo.Editorials_IdEditorial] 

go 

ALTER TABLE [dbo].[reservas] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Reservas_dbo.EstadoReservas_IdEstadoReserva] 
  FOREIGN KEY([idestadoreserva]) REFERENCES [dbo].[estadoreservas] ([idestado]) 
  ON DELETE CASCADE 

go 

ALTER TABLE [dbo].[reservas] 
  CHECK CONSTRAINT [FK_dbo.Reservas_dbo.EstadoReservas_IdEstadoReserva] 

go 

ALTER TABLE [dbo].[reservas] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Reservas_dbo.Libros_IdLibro] FOREIGN KEY( 
  [idlibro]) REFERENCES [dbo].[libros] ([idlibro]) ON DELETE CASCADE 

go 

ALTER TABLE [dbo].[reservas] 
  CHECK CONSTRAINT [FK_dbo.Reservas_dbo.Libros_IdLibro] 

go 

ALTER TABLE [dbo].[reservas] 
  WITH CHECK ADD CONSTRAINT [FK_dbo.Reservas_dbo.Usuarios_IdUsuario] FOREIGN KEY 
  ([idusuario]) REFERENCES [dbo].[usuarios] ([idusuario]) ON DELETE CASCADE 

go 

ALTER TABLE [dbo].[reservas] 
  CHECK CONSTRAINT [FK_dbo.Reservas_dbo.Usuarios_IdUsuario] 

go 

ALTER TABLE [dbo].[usuarios] 
  WITH CHECK ADD CONSTRAINT 
  [FK_dbo.Usuarios_dbo.TipoDocumentoes_IdTipoDocumento] FOREIGN KEY( 
  [idtipodocumento]) REFERENCES [dbo].[tipodocumentoes] ([id]) ON DELETE CASCADE 

go 

ALTER TABLE [dbo].[usuarios] 
  CHECK CONSTRAINT [FK_dbo.Usuarios_dbo.TipoDocumentoes_IdTipoDocumento] 

go 

ALTER DATABASE [LibrayDB] 

SET read_write 

go 