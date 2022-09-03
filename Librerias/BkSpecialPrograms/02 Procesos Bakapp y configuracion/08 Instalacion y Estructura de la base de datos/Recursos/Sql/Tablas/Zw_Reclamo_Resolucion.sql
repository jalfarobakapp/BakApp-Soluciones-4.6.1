USE [#Base#]


CREATE TABLE [dbo].[Zw_Reclamo_Resolucion](
	[Id_Resolucion] [int] IDENTITY(1,1) NOT NULL,
	[Id_Reclamo] [int] NOT NULL  DEFAULT (0),
	[CodFuncionario] [char](3) NOT NULL  DEFAULT (''),
	[Resolucion] [text] NOT NULL  DEFAULT (''),
	[Respuesta_Cliente] [text] NOT NULL  DEFAULT (''),
	[Activa] [bit] NOT NULL  DEFAULT (1),
	[Motivo_Rechazo] [text] NOT NULL  DEFAULT (''),
	[Rechazada] [bit] NOT NULL  DEFAULT (0),
	[Metod_Utilizar] [varchar](1000) NOT NULL  DEFAULT (''),
	[Conclusion] [varchar](1000) NOT NULL  DEFAULT (''),
	[Medidas_Preventivas] [text] NOT NULL  DEFAULT (''),
	[Acciones_Correctivas] [text] NOT NULL  DEFAULT (''),
	[Acciones_Preventivas] [text] NOT NULL  DEFAULT (''),
	[Causa_Raiz] [text] NOT NULL  DEFAULT (''),
	[Visita_Cliente] [bit] NOT NULL  DEFAULT (0),
	[Detalle_Visita] [text] NOT NULL  DEFAULT (''),
 CONSTRAINT [PK_Zw_Reclamo_Resolucion] PRIMARY KEY CLUSTERED 
(
	[Id_Resolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
