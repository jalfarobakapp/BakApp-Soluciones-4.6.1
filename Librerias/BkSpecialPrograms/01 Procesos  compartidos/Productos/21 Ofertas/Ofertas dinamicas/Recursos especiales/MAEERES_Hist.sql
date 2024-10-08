
--Esta tabla es especial para el Supermercado la Colchaguina
--Si esta tabla existe en la base de datos de Random el sistema grabara una fila cada vez que se modigique la tabla MAEERES_Hist

CREATE TABLE [dbo].[MAEERES_Hist](
	[ID]				[int]			IDENTITY(1,1) NOT NULL,
	[CODIGO]			[char]	(13)	NOT NULL DEFAULT(''),
	[CANTIDAD]			[float]			NULL DEFAULT(0),
	[UDAD]				[char](2)		NULL DEFAULT(''),
	[DESCRIPTOR]		[varchar](50)	NULL DEFAULT(''),
	[ESTARESE]			[char](1)		NULL DEFAULT(''),
	[TIPORESE]			[char](3)		NULL DEFAULT(''),
	[CONCEPTO]			[char](13)		NULL DEFAULT(''),
	[LISTAS]			[varchar](200)	NULL DEFAULT(''),
	[FIOFERTA]			[datetime]		NULL,
	[FTOFERTA]			[datetime]		NULL,
	[APLICAUT]			[bit]			NOT NULL DEFAULT(0),
	[PORDESC]			[float]			NULL DEFAULT(0),
	[ECUPORDESC]		[varchar](242)	NULL DEFAULT(''),
	[DESC_LUN]			[char](1)		NULL DEFAULT(''),
	[DESC_MAR]			[char](1)		NULL DEFAULT(''),
	[DESC_MIE]			[char](1)		NULL DEFAULT(''),
	[DESC_JUE]			[char](1)		NULL DEFAULT(''),
	[DESC_VIE]			[char](1)		NULL DEFAULT(''),
	[DESC_SAB]			[char](1)		NULL DEFAULT(''),
	[DESC_DOM]			[char](1)		NULL DEFAULT(''),
	[DESCVALOR]			[bit]			NOT NULL DEFAULT(0),
	[VALDESC]			[float]			NULL DEFAULT(0),
	[ECUVALDESC]		[varchar](242)	NULL DEFAULT(''),
	[KOGEN]				[char](13)		NULL DEFAULT(''),
	[CANTMIN]			[float]			NULL DEFAULT(0),
	[TIPOTRAT]			[int]			NULL DEFAULT(0),
	[RANGOS]			[bit]			NOT NULL DEFAULT(0),
	[INCLUYENVV]		[bit]			NOT NULL DEFAULT(0),
	[TGRANEL]			[int]			NULL DEFAULT(0),
	[FGRABACION]		[datetime]		NULL,
	[KOFUGRABA]			[char](3)		NULL DEFAULT(''),
    [OFERTAELIMINADA]   [bit]			NOT NULL DEFAULT(0),
)
	
