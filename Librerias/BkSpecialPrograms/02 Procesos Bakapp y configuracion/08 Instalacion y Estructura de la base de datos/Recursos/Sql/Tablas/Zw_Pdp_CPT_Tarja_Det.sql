USE [#Base#]

CREATE TABLE [dbo].[Zw_Pdp_CPT_Tarja_Det](
	[Id]						[int] IDENTITY(1,1) NOT NULL,
	[Id_CPT]					[int] NOT NULL Default(0),
	[Nro_Tipo]					[varchar](10) NULL,
	[Idmaeddo]					[int] NOT NULL Default(0),
	[Nro_CPT]					[varchar](10) NOT NULL Default(''),
	[Lote]						[varchar](20) NOT NULL Default(''),
	[Tipo]						[varchar](10) NOT NULL Default(''),
	[Nro]						[int] NOT NULL Default(0),
	[Codigo]					[varchar](13) NOT NULL Default(''),
	[CodAlternativo]			[varchar](21) NOT NULL Default(''),
	[CodAlternativo_Pallet]		[varchar](21) NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Pdp_CPT_Tarja_Det] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
