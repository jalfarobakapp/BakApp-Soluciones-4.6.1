USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_ConfProgramacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]			[varchar](50)	NOT NULL DEFAULT (''),
	[Tbl_Padre]				[varchar](30)	NOT NULL DEFAULT (''),
	[Id_Padre]				[int]			NOT NULL DEFAULT (0),
	[Nombre]				[varchar](50)	NOT NULL DEFAULT (''),
	[FrecuDiaria]			[bit]			NOT NULL DEFAULT (0),
	[FrecuSemanal]			[bit]			NOT NULL DEFAULT (0),
	[Lunes]					[bit]			NOT NULL DEFAULT (0),
	[Martes]				[bit]			NOT NULL DEFAULT (0),
	[Miercoles]				[bit]			NOT NULL DEFAULT (0),
	[Jueves]				[bit]			NOT NULL DEFAULT (0),
	[Viernes]				[bit]			NOT NULL DEFAULT (0),
	[Sabado]				[bit]			NOT NULL DEFAULT (0),
	[Domingo]				[bit]			NOT NULL DEFAULT (0),
	[SucedeUnaVez]			[bit]			NOT NULL DEFAULT (0),
	[HoraUnaVez]			[datetime]		NULL,
	[SucedeCada]			[bit]			NOT NULL DEFAULT (0),
	[IntervaloCada]			[int]			NOT NULL DEFAULT (0),
	[TipoIntervaloCada]		[varchar](2)	NOT NULL DEFAULT (''),
	[ApartirDeCada]			[datetime]		NULL,
	[FinalizaCada]			[datetime]		NULL,
	[Resumen]				[varchar](500)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Demonio_ConfProgramacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
