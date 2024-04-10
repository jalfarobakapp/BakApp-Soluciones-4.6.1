USE [#Base#]

CREATE TABLE [dbo].[Zw_Stmp_Enc](
	[Id]					[int] IDENTITY(1,1) NOT NULL,
	[Empresa]				[char](2)		NOT NULL DEFAULT (''),
	[Sucursal]				[varchar](3)	NOT NULL DEFAULT (''),
	[Numero]				[varchar](10)	NOT NULL DEFAULT (''),
	[CodFuncionario_Crea]	[char](3)		NOT NULL DEFAULT (''),
	[Idmaeedo]				[int]			NOT NULL DEFAULT (0),
	[Tido]					[char](3)		NOT NULL DEFAULT (''),
	[Nudo]					[varchar](10)	NOT NULL DEFAULT (''),
	[Endo]					[varchar](10)	NULL,
	[Suendo]				[varchar](20)	NOT NULL DEFAULT (''),
	[FechaCreacion]			[datetime]		NULL,
	[Estado]				[varchar](5)	NOT NULL DEFAULT (''),
	[FechaPickeado]			[datetime]		NULL,
	[FechaCierre]			[datetime]		NULL,
	[Accion]				[varchar](5)	NOT NULL DEFAULT (''),
	[Secueven]				[varchar](3)	NOT NULL DEFAULT (''),
	[TipoPago]				[varchar](10)	NOT NULL DEFAULT (''),
	[Facturar]				[bit]			NOT NULL DEFAULT (0),
	[DocEmitir]				[varchar](3)	NOT NULL DEFAULT (''),
	[Fecha_Facturar]		[datetime]		NULL,
	[IdmaeedoGen]			[int]       	NOT NULL DEFAULT (''),
	[TidoGen]				[varchar](3)	NOT NULL DEFAULT (''),
	[NudoGen]				[varchar](10)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Stmp_Enc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

