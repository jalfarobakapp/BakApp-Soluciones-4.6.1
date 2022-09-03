USE [#Base#]


CREATE TABLE [dbo].[Zw_Picking_Doc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyReg] [varchar](50) NOT NULL DEFAULT (''),
	[TipoDoc] [char](3) NOT NULL DEFAULT (''),
	[NombreDoc] [varchar](100) NULL,
	[Traer] [bit] NOT NULL DEFAULT (0),
	[Imprimir] [bit] NOT NULL DEFAULT (0),
	[Nro_Copias_Impresion] [int] NOT NULL DEFAULT (0),
	[Correo] [bit] NOT NULL DEFAULT (0),
	[Nombre_Correo] [varchar](50) NOT NULL DEFAULT (''),
	[Imprimir_Barras] [bit] NOT NULL DEFAULT (0),
	[NombreFormato] [varchar](50) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Picking_Doc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
