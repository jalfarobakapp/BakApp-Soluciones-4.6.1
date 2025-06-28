USE [#Base#]


CREATE TABLE [dbo].[Zw_Format_01](
	[TipoDoc]			    	[char](3)		NOT NULL DEFAULT (''),
	[NombreFormato]		    	[varchar](50)	NOT NULL DEFAULT (''),
	[Cod_Pagina]		    	[char](10)		NOT NULL DEFAULT (''),
	[LargoDoc]			    	[float]			NOT NULL DEFAULT (0),
	[AnchoDoc]			    	[float]			NOT NULL DEFAULT (0),
	[NroLineasXpag]		    	[float]			NOT NULL DEFAULT (0),
	[Fila_InicioDetalle]    	[float]			NOT NULL DEFAULT (0),
	[Fila_FinDetalle]		    [float]			NOT NULL DEFAULT (0),
	[Col_InicioDetalle]	    	[float]			NOT NULL DEFAULT (0),
	[Col_FinDetalle]    		[float]			NOT NULL DEFAULT (0),
	[Largo_Variable]    		[bit]			NOT NULL DEFAULT (0),
	[Doc_Electronico]   		[bit]			NOT NULL DEFAULT (0),
	[Copias]			    	[int]			NOT NULL DEFAULT (1),
	[Emdp]				    	[varchar](13)	NOT NULL DEFAULT (''),
	[Subtido]				    [char](3)		NOT NULL DEFAULT (''),
	[Es_Picking]			    [bit]			NOT NULL DEFAULT (0),
	[Detalle_Doc_Incluye]	    [varchar](50)	NOT NULL DEFAULT (''),	
    [Agrupar_CodDescripcion]	[bit]			NOT NULL DEFAULT (0),
    [IncluyePickWms]        	[bit]			NOT NULL DEFAULT (0),
    [ImprimirDocAdjuntos]       [bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Format_01] PRIMARY KEY CLUSTERED 
(
	[TipoDoc] ASC,
	[NombreFormato] ASC,
	[Emdp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


