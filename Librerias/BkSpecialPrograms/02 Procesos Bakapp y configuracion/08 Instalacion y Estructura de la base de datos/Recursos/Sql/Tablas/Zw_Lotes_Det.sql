USE [#Base#]

CREATE TABLE [dbo].[Zw_Lotes_Det](
	[Id]            [int] IDENTITY(1,1) NOT NULL,
	[Id_Lote]       [int]               NOT NULL Default(0),
	[NroLote]       [varchar](20)       NOT NULL Default(''),
	[NomTabla]      [varchar](20)       NOT NULL Default(''),
	[IdTabla]       [int]               NOT NULL Default(0),
 CONSTRAINT [PK_Zw_Lotes_Det] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]




