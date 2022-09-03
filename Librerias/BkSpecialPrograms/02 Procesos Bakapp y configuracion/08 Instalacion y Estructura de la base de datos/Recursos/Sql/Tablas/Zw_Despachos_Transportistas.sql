USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Transportistas](
	[CodTransportista]	[char](13)	    NOT NULL DEFAULT(''),
	[Mostrar]			[bit]		    NOT NULL DEFAULT(0),
	[Cant_Minima]		[float]		    NOT NULL DEFAULT(0),
    [Tipo_Envio]	    [varchar](10)	NOT NULL DEFAULT(''),
 CONSTRAINT [PK_Zw_Despachos_Transportistas] PRIMARY KEY CLUSTERED 
(
	[CodTransportista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


