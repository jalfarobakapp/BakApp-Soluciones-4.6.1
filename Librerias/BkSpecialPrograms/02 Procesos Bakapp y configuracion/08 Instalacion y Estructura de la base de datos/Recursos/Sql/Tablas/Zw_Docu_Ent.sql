USE [#Base#]

CREATE TABLE [dbo].[Zw_Docu_Ent](
    [Id]                [int]           IDENTITY(1,1) NOT NULL,
	[Idmaeedo]			[int]			NOT NULL DEFAULT (0),
	[NombreEquipo]		[varchar](50)	NOT NULL DEFAULT (''),
	[TipoEstacion]		[char](3)		NOT NULL DEFAULT (''),
	[Empresa]			[char](2)		NOT NULL DEFAULT (''),
	[Modalidad]			[varchar](5)	NOT NULL DEFAULT (''),
	[Tido]				[char](3)		NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)	NOT NULL DEFAULT (''),
	[FechaHoraGrab]		[datetime]		NULL	 DEFAULT (getdate()),
	[HabilitadaFac]		[bit]			NOT NULL DEFAULT (0),
	[FunAutorizaFac]	[varchar](3)	NOT NULL DEFAULT (''),
    [FechaHoraAutoriza]	[datetime]		NULL,
    [Pickear]   		[bit]			NOT NULL DEFAULT (0),
    [Estaenwms]   		[bit]			NOT NULL DEFAULT (0),
    [Customizable]      [bit]			NOT NULL DEFAULT (0),
    [PreVenta]          [bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Docu_Ent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
