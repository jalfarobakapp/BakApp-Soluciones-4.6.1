USE [#Base#]

CREATE TABLE [dbo].[Zw_Reclamo_Email_Aviso](
	[Id_Correo] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](3) NOT NULL  DEFAULT (''),
	[Accion] [varchar](10) NOT NULL  DEFAULT (''),
	[Tipo_Reclamo] [varchar](3) NOT NULL  DEFAULT (''),
	[Nombre_Correo] [varchar](50) NOT NULL  DEFAULT (''),
	[Para] [varchar](1000) NOT NULL  DEFAULT (''),
	[Suc_Elaboracion] [Char](3) NOT NULL  DEFAULT (''),
 CONSTRAINT [PK_Zw_Reclamo_Email_Aviso] PRIMARY KEY CLUSTERED 
(
	[Id_Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


