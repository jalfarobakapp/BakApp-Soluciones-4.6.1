USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_Licencia_Mod](
	[Codigo_Modulo] [varchar](10) NOT NULL,
	[Modulo] [varchar](200) NOT NULL,
	[Llave] [varchar](50) NOT NULL,
	[Fecha_Expiracion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Zw_Licencia_Mod] PRIMARY KEY CLUSTERED 
(
	[Codigo_Modulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--[#Tabla#]
