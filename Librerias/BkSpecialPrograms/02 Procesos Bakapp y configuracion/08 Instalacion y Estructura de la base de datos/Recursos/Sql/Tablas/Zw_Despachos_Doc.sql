USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Doc](
	[Id_Documentos]			[int] IDENTITY(1,1) Not Null,
	[Id_Despacho]			[int]			Not Null Default (0),
	[Nro_Despacho]			[varchar](10)	Not Null Default (''),
	[Archidrst]				[varchar](20)	NOT NULL Default (''),
	[Idrst]					[int]			NOT NULL Default (0),
	[Tido]					[varchar](3)	Not Null Default (''),
	[Nudo]					[varchar](10)	Not Null Default (''),
	[CantC]					[float]			NOT NULL Default (0),
	[CantD]					[float]			NOT NULL Default (0),
	[CantE]					[float]			NOT NULL Default (0),
	[CantR]					[float]			NOT NULL Default (0),
	[CantDesp]				[float]			NOT NULL Default (0),
	[Activo]				[bit]			NOT NULL Default (1),
	[Nudonodefi]			[bit]			NOT NULL Default (0),
	[Id_Documentos_Padre]	[Int]			NOT NULL Default (0),
	[Reasignado]			[bit]			NOT NULL Default (0),	
 CONSTRAINT [PK_Zw_Despachos_Doc] PRIMARY KEY CLUSTERED 
(
	[Id_Documentos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

