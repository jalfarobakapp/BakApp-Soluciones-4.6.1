USE [#Base#]

CREATE TABLE [dbo].[Zw_Format_02](
	[Id]				    [int] IDENTITY(1,1) NOT NULL,
	[TipoDoc]			    [char](3)		NOT NULL DEFAULT (''),
	[NombreFormato]		    [varchar](100)	NOT NULL DEFAULT (''),
	[NombreObjeto]		    [varchar](50)	NOT NULL DEFAULT (''),
	[Seccion]			    [char](1)		NOT NULL DEFAULT (''),
	[TipoDato]			    [char](1)		NOT NULL DEFAULT (''),
	[Funcion]			    [varchar](100)	NOT NULL DEFAULT (''),
	[Formato]			    [char](2)		NOT NULL DEFAULT (''),
	[CantDecimales]		    [float]			NOT NULL DEFAULT (0),
	[Fuente]			    [varchar](50)	NOT NULL DEFAULT (''),
	[Tamano]			    [float]			NOT NULL DEFAULT (0),
	[Alto]				    [float]			NOT NULL DEFAULT (0),
	[Ancho]				    [float]			NOT NULL DEFAULT (0),
	[Estilo]			    [int]			NOT NULL DEFAULT (0),
	[Color]				    [float]			NOT NULL DEFAULT (0),
	[Fila_Y]		    	[float]			NOT NULL DEFAULT (0),
	[Columna_X]			    [float]			NOT NULL DEFAULT (0),
	[Texto]			    	[varchar](1000) NOT NULL DEFAULT (''),
	[RutaImagen]		    [varchar](1000) NOT NULL DEFAULT (''),
	[Imagen]			    [image]			NULL,
	[Borde_Variable]	    [bit]			NOT NULL DEFAULT (0),
	[Orden_Detalle]		    [int]			NOT NULL DEFAULT (0),
	[Emdp]				    [varchar](13)	NOT NULL DEFAULT (''),
    [Mostrar_En_Concepto]	[bit]			NOT NULL DEFAULT (0),    
    [Subtido]				[char](3)		NOT NULL DEFAULT (''),
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


