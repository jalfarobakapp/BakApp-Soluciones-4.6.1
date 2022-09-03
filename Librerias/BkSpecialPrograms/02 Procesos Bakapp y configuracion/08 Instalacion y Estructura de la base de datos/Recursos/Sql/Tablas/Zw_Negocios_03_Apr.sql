USE [#Base#]


CREATE TABLE [dbo].[Zw_Negocios_03_Apr](
	[Nro_Negocio] [varchar](10) NOT NULL DEFAULT (''),
	[CodFuncionario] [char](3) NOT NULL DEFAULT (''),
	[NombreAprueba] [varchar](50) NOT NULL DEFAULT (''),
	[Fecha_Hora_Aprueba] [datetime] NULL,
	[Autorizado] [bit] NOT NULL DEFAULT (0),
	[CodAprobacion] [char](2) NOT NULL DEFAULT (''),
	[NomAprobacion] [varchar](100) NOT NULL DEFAULT (''),
	[Observaciones] [varchar](500) NOT NULL DEFAULT (''),
	[Chk_01] [bit] NOT NULL DEFAULT (0),
	[Chk_02] [bit] NOT NULL DEFAULT (0),
	[Chk_03] [bit] NOT NULL DEFAULT (0),
	[Chk_04] [bit] NOT NULL DEFAULT (0),
	[Chk_05] [bit] NOT NULL DEFAULT (0),
	[CodAutoriza] [char](3) NOT NULL DEFAULT (''),
	[NombreAutoriza] [varchar](50) NOT NULL DEFAULT (''),
	[Ausente] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Negocios_03_Apr] PRIMARY KEY CLUSTERED 
(
	[Nro_Negocio] ASC,
	[CodAprobacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
