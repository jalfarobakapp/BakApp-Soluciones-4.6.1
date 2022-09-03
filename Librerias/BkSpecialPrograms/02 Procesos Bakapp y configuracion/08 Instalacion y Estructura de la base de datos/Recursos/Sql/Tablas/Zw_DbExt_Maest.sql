USE [#Base#]

CREATE TABLE [dbo].[Zw_DbExt_Maest](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[Id_Conexion]	[int]			NOT NULL DEFAULT ((0)),
	[Empresa_Ori]	[char](2)		NOT NULL DEFAULT (''),
	[Sucursal_Ori]	[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega_Ori]	[varchar](3)	NOT NULL DEFAULT (''),
	[Activo]		[bit]			NOT NULL DEFAULT (0),
	[Empresa_Des]	[char](2)		NOT NULL DEFAULT (''),
	[Sucursal_Des]	[varchar](3)	NOT NULL DEFAULT (''),
	[Bodega_Des]	[varchar](3)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_DbExt_Maest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

