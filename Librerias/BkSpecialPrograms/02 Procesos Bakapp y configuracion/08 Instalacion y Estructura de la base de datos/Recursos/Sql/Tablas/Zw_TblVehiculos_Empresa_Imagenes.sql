USE [#Base#]


CREATE TABLE [dbo].[Zw_TblVehiculos_Empresa_Imagenes](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Patente]			[varchar](10)		NOT NULL DEFAULT (''),
	[Nombre_Archivo]	[varchar](200)		NOT NULL DEFAULT (''),
	[Archivo]			[image]				NOT NULL DEFAULT (''),
	[Fecha]				[datetime]			NOT NULL DEFAULT (Getdate()),
 CONSTRAINT [PK_Zw_TblVehiculos_Empresa_Imagenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



