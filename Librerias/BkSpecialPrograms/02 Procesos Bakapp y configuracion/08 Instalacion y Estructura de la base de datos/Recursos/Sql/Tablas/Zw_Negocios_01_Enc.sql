USE [#Base#]


CREATE TABLE [dbo].[Zw_Negocios_01_Enc](
	[Id_Negocio] [int] IDENTITY(1,1) NOT NULL,
	[Nro_Negocio] [varchar](10) NOT NULL DEFAULT (''),
	[Stand_By] [bit] NOT NULL DEFAULT (0),
	[Estado] [char](2) NOT NULL DEFAULT (''),
	[Estado_Cerrado] [varchar](20) NOT NULL DEFAULT (''),
	[Tipo] [char](2) NOT NULL DEFAULT (''),
	[NomTipo] [varchar](100) NOT NULL DEFAULT (''),
	[Fecha_Emision] [datetime] NULL,
	[Fecha_Cierre] [datetime] NULL,
	[CodEntidad] [varchar](13) NOT NULL DEFAULT (''),
	[CodSucursal] [varchar](10) NOT NULL DEFAULT (''),
	[RutEntidad] [varchar](10) NOT NULL DEFAULT (''),
	[NomEntidad] [varchar](50) NOT NULL DEFAULT (''),
	[CodFuncionario] [char](3) NOT NULL DEFAULT (''),
	[NomFuncionario] [char](30) NOT NULL DEFAULT (''),
	[Empresa] [char](2) NOT NULL DEFAULT (''),
	[Sucursal] [char](3) NOT NULL DEFAULT (''),
	[NomSucursal] [char](30) NOT NULL DEFAULT (''),
	[Cadena_Conexion] [varchar](300) NOT NULL DEFAULT (''),
	[Motivo_Anula] [varchar](200) NOT NULL DEFAULT (''),
	[Nom_Clas_Crediticia] [varchar](30) NOT NULL DEFAULT (''),
	[Visado_Jefe] [bit] NOT NULL DEFAULT (0),
	[Fun_Corregir] [char](3) NOT NULL DEFAULT (''),
	[Fun_Corregir_Motivo] [varchar](200) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Negocios_01_Enc] PRIMARY KEY CLUSTERED 
(
	[Nro_Negocio] ASC,
	[Stand_By] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
