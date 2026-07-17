USE [#Base#]


CREATE TABLE [dbo].[Zw_InterStock_Enc](
	[Id_Enc]		[int]			IDENTITY(1,1) NOT NULL,
	[Idmaeedo]		[int]			NOT NULL DEFAULT (0),
	[Empresa]		[char](2)		NOT NULL DEFAULT (''),
	[Tido]			[char](3)		NOT NULL DEFAULT (''),
	[Nudo]			[varchar](10)	NOT NULL DEFAULT (''),
	[Endo]			[varchar](13)	NOT NULL DEFAULT (''),
	[Suendo]		[varchar](10)	NOT NULL DEFAULT (''),
	[Nokoen]		[varchar](50)	NOT NULL DEFAULT (''),
	[Estado]		[varchar](10)	NOT NULL DEFAULT (''),
	[Procesar]		[bit]			NOT NULL DEFAULT (0),
	[Procesando]	[bit]			NOT NULL DEFAULT (0),
	[Procesada]		[bit]			NOT NULL DEFAULT (0),
	[Error]			[bit]			NOT NULL DEFAULT (0),
	[Observacion]	[varchar](200)	NOT NULL DEFAULT (''),
	[FechaIngreso]	[datetime]		NULL,
	[FechaProceso]	[datetime]		NULL,
 CONSTRAINT [PK_Zw_InterStock_Enc] PRIMARY KEY CLUSTERED 
(
	[Id_Enc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




