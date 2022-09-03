USE [#Base#]


CREATE TABLE [dbo].[Zw_Negocios_04_Doc](
	[Semilla]		[int] IDENTITY(1,1) NOT NULL,
	[NroNegocio]	[varchar](10) NOT NULL DEFAULT (''),
	[Nom_Documento] [varchar](100) NOT NULL DEFAULT (''),
	[Tipo_Obs]		[varchar](20) NOT NULL DEFAULT (''),
	[Archivo]		[image] NULL,
	[Fecha]			[datetime] NULL,
	[Garantia]		[bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Negocios_04_Doc] PRIMARY KEY CLUSTERED 
(
	[NroNegocio] ASC,
	[Nom_Documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
