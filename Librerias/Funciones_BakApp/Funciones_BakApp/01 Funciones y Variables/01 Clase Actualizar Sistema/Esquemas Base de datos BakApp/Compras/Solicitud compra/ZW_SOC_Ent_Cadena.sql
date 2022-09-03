USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ZW_SOC_Ent_Cadena](
	[CodProveedor]           [char](13) NOT NULL DEFAULT (''),
	[CodSucProveedor]        [char](10) NOT NULL DEFAULT (''),
	[CodProveedor_Cadena]    [char](13) NOT NULL DEFAULT (''),
	[CodSucProveedor_Cadena] [char](10) NOT NULL DEFAULT (''),
	[CodLista]               [char](3)  NOT NULL DEFAULT (''),
 CONSTRAINT [PK_ZW_SOC_Ent_Cadena] PRIMARY KEY CLUSTERED 
(
	[CodProveedor] ASC,
	[CodSucProveedor] ASC,
	[CodProveedor_Cadena] ASC,
	[CodSucProveedor_Cadena] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


