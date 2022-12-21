USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_ImpAdicional](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[Codigo]					[varchar](13)		NOT NULL DEFAULT (''),
	[Tido]						[char](3)			NOT NULL DEFAULT (''),
	[Subtido]					[char](3)			NOT NULL DEFAULT (''),
	[NombreFormato_Origen]		[varchar](50)		NOT NULL DEFAULT (''),
	[NombreFormato_Destino]		[varchar](50)		NOT NULL DEFAULT (''),
	[Reemplazar_Formato_Origen]	[bit]       		NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Prod_ImpAdicional] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC,
	[Tido] ASC,
	[Subtido] ASC,
	[NombreFormato_Origen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


