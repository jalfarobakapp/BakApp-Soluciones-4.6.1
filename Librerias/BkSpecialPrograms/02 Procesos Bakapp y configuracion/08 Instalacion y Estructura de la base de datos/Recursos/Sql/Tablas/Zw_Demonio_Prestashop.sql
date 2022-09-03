USE [#Base#]


CREATE TABLE [dbo].[Zw_Demonio_Prestashop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [varchar](50) NOT NULL DEFAULT (''),
	[Idmaeedo] [int] NOT NULL DEFAULT (0),
	[Idmaeddo] [int] NOT NULL DEFAULT (0),
	[Codigo] [varchar](13) NOT NULL DEFAULT (''),
	[Descripcion] [varchar](50) NOT NULL DEFAULT (''),
	[Fecha] [datetime] NULL,
	[Revisado] [bit] NOT NULL DEFAULT (0),
	[Error] [bit] NOT NULL DEFAULT (0),
	[Log_Error] [varchar](5000) NOT NULL DEFAULT (''),
	[Peticion_Manual] [bit] NOT NULL DEFAULT (0),
	[Fecha_Hora] [datetime] NOT NULL DEFAULT (Getdate()),
 CONSTRAINT [PK_Zw_Demonio_Prestashop_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

