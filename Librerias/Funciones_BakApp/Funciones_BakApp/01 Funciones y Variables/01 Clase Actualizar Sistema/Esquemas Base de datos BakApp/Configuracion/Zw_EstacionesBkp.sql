USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_EstacionesBkp](
	[IpEstacion]   [varchar](20) NOT NULL Default '',
	[NombreEquipo] [varchar](50) NOT NULL Default '',
	[TipoEstacion] [char](1) NOT NULL Default '',
	[IpRandom]     [varchar](20) NULL Default '',
	[KeyReg]       [varchar](100) NOT NULL Default '',
	[Conectado]    [bit] NOT NULL Default (0),
 CONSTRAINT [PK_Zw_EstacionesBkp] PRIMARY KEY CLUSTERED 
(
	[IpEstacion] ASC,
	[NombreEquipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


