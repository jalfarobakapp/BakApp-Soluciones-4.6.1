USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_Turnos](
	[Empresa]      [char](2) NOT NULL DEFAULT (''),
	[CodTurno]     [char](1) NOT NULL DEFAULT (''),
	[Hora_Inicio]  [time](7) NULL ,
	[Hora_Fin]     [time](7) NULL ,
	[Nombre_Turno] [varchar](30) NULL,
 CONSTRAINT [PK_Zw_Turnos] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[CodTurno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


Insert Into Zw_Turnos (Empresa,CodTurno,Hora_Inicio,Hora_Fin,Nombre_Turno) 
                       Values 
                      ('01','1','08:30','18:30','TURNO UNICO')

