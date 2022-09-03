USE [#Base#]


CREATE TABLE [dbo].[Zw_Licencia_Mod](
	[Cod_Modulo]		[varchar](10) NOT NULL DEFAULT (''),
	[Modulo]			[varchar](200) NOT NULL DEFAULT (''),
	[Llave]				[varchar](50) NOT NULL DEFAULT (''),
	[Fecha_Expiracion]	[datetime] NULL,
 CONSTRAINT [PK_Zw_Licencia_Mod] PRIMARY KEY CLUSTERED 
(
	[Cod_Modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


