USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_Hoja_Detalle](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[IdHoja]				[int]				NULL DEFAULT (0),
	[Nro_Hoja]				[varchar](5)		NOT NULL DEFAULT (''),
	[IdInventario]			[int]				NOT NULL DEFAULT (0),
	[Empresa]				[char](2)			NOT NULL DEFAULT (''),
	[Sucursal]				[char](3)			NOT NULL DEFAULT (''),
	[Bodega]				[char](3)			NOT NULL DEFAULT (''),
	[Responsable]			[char](3)			NOT NULL DEFAULT (''),
	[IdContador1]			[int]				NOT NULL DEFAULT (0),
	[IdContador2]			[int]				NOT NULL DEFAULT (0),
	[Item_Hoja]				[varchar](5)		NOT NULL DEFAULT (''),
	[IdSector]				[int]				NOT NULL DEFAULT (0),
	[Sector]				[varchar](30)		NOT NULL DEFAULT (''),
	[Ubicacion]				[varchar](20)		NOT NULL DEFAULT (''),
	[TipoConteo]			[char](1)			NOT NULL DEFAULT (''),
	[Codigo]				[char](13)			NOT NULL DEFAULT (''),
	[EsSeriado]				[bit]				NOT NULL DEFAULT (0),
	[NroSerie]				[varchar](50)		NOT NULL DEFAULT (''),
	[FechaHoraToma]			[datetime]			NULL,
	[Rtu]					[float]				NOT NULL DEFAULT (0),
	[RtuVariable]			[bit]				NOT NULL DEFAULT (0),
	[Udtrpr]				[int]				NOT NULL DEFAULT (0),
	[Cantidad]				[float]				NOT NULL DEFAULT (0),
	[Ud1]					[char](2)			NOT NULL DEFAULT (''),
	[CantidadUd1]			[float]				NOT NULL DEFAULT (0),
	[Ud2]					[char](2)			NOT NULL DEFAULT (''),
	[CantidadUd2]			[float]				NOT NULL DEFAULT (0),
	[Observaciones]			[varchar](300)		NOT NULL DEFAULT (''),
	[Recontado]				[bit]				NOT NULL DEFAULT (0),
	[Actualizado_por]		[char](3)			NOT NULL DEFAULT (''),
	[Obs_Actualizacion]		[varchar](300)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Inv_Hoja_Detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
