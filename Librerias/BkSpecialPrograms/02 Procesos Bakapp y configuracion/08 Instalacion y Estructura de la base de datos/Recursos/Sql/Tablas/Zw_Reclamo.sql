USE [#Base#]


CREATE TABLE [dbo].[Zw_Reclamo](
	[Id_Reclamo] [int] IDENTITY(1,1) NOT NULL,
	[Empresa] [varchar](2) NOT NULL DEFAULT (''),
	[Sucursal] [varchar](3) NOT NULL  DEFAULT (''),
	[Numero] [varchar](10) NOT NULL  DEFAULT (''),
	[Estado] [char](3) NOT NULL  DEFAULT (''),
	[Sub_Estado] [char](3) NOT NULL  DEFAULT (''),
	[Codigo_Accion] [varchar](2) NOT NULL  DEFAULT (''),
	[Fecha_Emision] [datetime] NOT NULL  DEFAULT (Getdate()),
	[Fecha_Cierre] [datetime] NOT NULL  DEFAULT (Getdate()),
	[Tipo_Reclamo] [varchar](3) NOT NULL  DEFAULT (''),
	[Sub_Tipo_Reclamo] [varchar](3) NOT NULL  DEFAULT (''),
	[Rut_Contacto] [nchar](10) NOT NULL  DEFAULT (''),
	[Nombre_Contacto] [varchar](50) NOT NULL  DEFAULT (''),
	[Email_Contacto] [varchar](100) NOT NULL  DEFAULT (''),
	[Telefono_Contacto] [varchar](20) NOT NULL  DEFAULT (''),
	[CodEntidad] [varchar](10) NOT NULL  DEFAULT (''),
	[SucEntidad] [varchar](20) NOT NULL  DEFAULT (''),
	[Rut_Entidad] [varchar](20) NOT NULL  DEFAULT (''),
	[Cod_Vendedor] [varchar](3) NOT NULL  DEFAULT (''),
	[Codigo] [char](13) NOT NULL  DEFAULT (''),
	[Descripcion] [varchar](50) NOT NULL  DEFAULT (''),
	[Fecha_Elab] [datetime] NOT NULL  DEFAULT (Getdate()),
	[Cantidad] [float] NOT NULL  DEFAULT (0),
	[Descripcion_Reclamo] [text] NOT NULL  DEFAULT (''),
	[Suc_Elaboracion] [varchar](3) NOT NULL  DEFAULT (''),
	[Observacion] [varchar](200) NOT NULL  DEFAULT (''),
 CONSTRAINT [PK_Zw_Reclamo] PRIMARY KEY CLUSTERED 
(
	[Id_Reclamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

