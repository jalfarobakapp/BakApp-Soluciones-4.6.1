USE [#Base#]

CREATE TABLE [dbo].[Zw_Inv_HojaEli](
	[Id]					[int]			NOT NULL DEFAULT (0),
	[IdInventario]			[int]			NOT NULL DEFAULT (0),
	[Nro_Hoja]				[varchar](5)	NOT NULL DEFAULT (''),
	[NombreEquipo]			[varchar](20)	NOT NULL DEFAULT (''),
	[FechaCreacion]			[datetime]		NULL,
	[CodResponsable]		[char](3)		NOT NULL DEFAULT (''),
	[IdContador1]			[int]			NOT NULL DEFAULT (0),
	[IdContador2]			[int]			NOT NULL DEFAULT (0),
	[FechaLevantamiento]	[datetime]		NULL,
	[Reconteo]				[bit]			NOT NULL DEFAULT (0),
	[CodFuncionarioEli]		[char](3)		NOT NULL DEFAULT (''),
	[FechaEli]				[datetime]		NULL,
	[NombreEquipoEli]		[varchar](20)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Inv_HojaEli] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
