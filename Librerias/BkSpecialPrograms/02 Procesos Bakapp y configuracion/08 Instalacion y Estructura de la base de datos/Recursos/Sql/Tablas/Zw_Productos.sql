USE [#Base#]

CREATE TABLE [dbo].[Zw_Productos](
	[Codigo]			[varchar](13)	NOT NULL Default(''),
	[Descripcion]		[varchar](50)	NOT NULL Default(''),
	[ExluyeTipoVenta]	[bit]			NOT NULL Default(0),
    [RtuXWms]	        [bit]			NOT NULL Default(0),
 CONSTRAINT [PK_Zw_Productos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
