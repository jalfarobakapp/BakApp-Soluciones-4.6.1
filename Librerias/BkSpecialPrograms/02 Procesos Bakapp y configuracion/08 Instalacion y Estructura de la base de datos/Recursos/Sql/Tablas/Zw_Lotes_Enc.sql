USE [#Base#]

CREATE TABLE [dbo].[Zw_Lotes_Enc](
	[Id_Lote]		    [int] IDENTITY(1,1) NOT NULL,
	[NroLote]		    [varchar](20)	NOT NULL Default(''),
	[Codigo]		    [varchar](13)	NOT NULL Default(''),
	[FechaVenci]	    [datetime]		NULL,
    [CodAlternativo]	[varchar](13)	NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Lotes_Enc] PRIMARY KEY CLUSTERED 
(
	[NroLote] ASC,
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


