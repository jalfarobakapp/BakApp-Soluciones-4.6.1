USE [#Base#]


CREATE TABLE [dbo].[Zw_Turnos](
	[Empresa]		[char](2)	NOT NULL DEFAULT (''),
	[CodTurno]		[char](1)	NOT NULL DEFAULT (''),
	[Hora_Inicio]	[datetime]	NULL,
	[Hora_Fin]		[datetime]	NULL,
	[Nombre_Turno]	[varchar](30) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Turnos] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[CodTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

