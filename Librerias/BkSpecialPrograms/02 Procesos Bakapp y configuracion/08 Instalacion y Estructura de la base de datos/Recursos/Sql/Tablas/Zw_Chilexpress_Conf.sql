USE [#Base#]

CREATE TABLE [dbo].[Zw_Chilexpress_Conf](
	[Id] [int] IDENTITY(1,1)		NOT NULL,
	[Key_Cotizador]     [varchar](50)	NOT NULL Default(''),
	[Key_Cobertura]     [varchar](50)	NOT NULL Default(''),
	[Key_Envios]	    [varchar](50)	NOT NULL Default(''),
	[TCC]			    [float]			NOT NULL Default(''),
	[Rut_Seller]	    [varchar](20)	NOT NULL Default(''),
	[Rut_Mark]		    [varchar](20)	NOT NULL Default(''),
	[CodigoRd]		    [varchar](13)	NOT NULL Default(''),
	[CodTransportista]	[varchar](20)	NOT NULL Default(''),
	[NombreEtiqueta]	[varchar](80)	NOT NULL Default(''),
	[Activo]        	[bit]           NOT NULL Default(0),
    [Observacion]	    [varchar](100)	NOT NULL Default(''),
    [Es_Test]        	[bit]           NOT NULL Default(0),
    [Cond_Peso]	        [varchar](20)	NOT NULL Default(''),
    [Cond_Alto]	        [varchar](20)	NOT NULL Default(''),
    [Cond_Largo]	    [varchar](20)	NOT NULL Default(''),
    [Cond_Ancho]	    [varchar](20)	NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Chilexpress_Conf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



