USE [#Base#]

CREATE TABLE [dbo].[Zw_PagosBloqueados](
	[Idmaedpce]			[int]			NOT NULL DEFAULT (0),
	[Bloqueado]			[bit]			NOT NULL DEFAULT (0),
	[MotivoBloqueo]		[varchar](max)	NOT NULL DEFAULT (''),
	[CodFuncionario]	[varchar](3)	NOT NULL DEFAULT (''),
	[NombreEquipo]		[varchar](50)	NOT NULL DEFAULT (''),
	[FechaBloqueo]		[datetime]		NULL,
 CONSTRAINT [PK_Zw_PagosBloqueados] PRIMARY KEY CLUSTERED 
(
	[Idmaedpce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
