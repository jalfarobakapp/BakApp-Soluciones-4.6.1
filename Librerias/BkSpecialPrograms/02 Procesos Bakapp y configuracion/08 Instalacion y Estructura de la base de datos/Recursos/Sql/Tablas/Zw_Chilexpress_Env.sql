USE [#Base#]

CREATE TABLE [dbo].[Zw_Chilexpress_Env](
	[Idenvio]			[int] IDENTITY(1,1) NOT NULL,
	[IdDespacho]		[int]			NOT NULL Default(''),
	[Estatusenvio]		[varchar](20)   NOT NULL Default(''),
	[Regionorigen]		[varchar](50)	NOT NULL Default(''),
	[Comunaorigen]		[varchar](50)	NOT NULL Default(''),
	[Direccionorigen]	[varchar](100)	NOT NULL Default(''),
	[Numorigen]			[varchar](50)	NOT NULL Default(''),
	[Comporigen]		[varchar](50)	NOT NULL Default(''),
	[Nombreorigen]		[varchar](50)	NOT NULL Default(''),
	[Telorigen]			[varchar](50)	NOT NULL Default(''),
	[Mailorigen]		[varchar](50)	NOT NULL Default(''),
	[Referencia]		[varchar](100)	NOT NULL Default(''),
	[Peso]				[varchar](50)	NOT NULL Default(''),
	[Alto]				[varchar](50)	NOT NULL Default(''),
	[Largo]				[varchar](50)	NOT NULL Default(''),
	[Ancho]				[varchar](50)	NOT NULL Default(''),
	[Nombredestino]		[varchar](100)	NOT NULL Default(''),
	[Telefonodestino]	[varchar](20)	NOT NULL Default(''),
	[Maildestino]		[varchar](200)	NOT NULL Default(''),
	[Producto]			[varchar](100)	NOT NULL Default(''),
	[Valor]				[float]			NOT NULL Default(0),
	[Regiondestino]		[varchar](100)	NOT NULL Default(''),
	[Comunadestino]		[varchar](100)	NOT NULL Default(''),
	[Direcciondestino]	[varchar](100)	NOT NULL Default(''),
	[Numerodestino]		[varchar](50)	NOT NULL Default(''),
	[Compdestino]		[varchar](50)	NOT NULL Default(''),
	[Idoficina]			[varchar](50)	NOT NULL Default(''),
	[Idservicio]		[varchar](50)	NOT NULL Default(''),
	[Tipoenvio]			[varchar](50)	NOT NULL Default(''),
	[Costoenvio]		[float]			NOT NULL Default(0),
	[Contenido]			[varchar](50)	NOT NULL Default(''),
	[Json]				[varchar](max)	NOT NULL Default(''),
	[Etiqueta]			[varchar](max)	NOT NULL Default(''),
	[Respuesta]			[varchar](max)	NOT NULL Default(''),
	[Nro_Encomienda]	[varchar](50)	NOT NULL Default(''),
	[Codigo_Barras]		[varchar](50)	NOT NULL Default(''),
	[FechaHoraGrab]		[datetime]	        NULL Default(getdate()),
 CONSTRAINT [PK_Zw_Chilexpress_Env] PRIMARY KEY CLUSTERED 
(
	[Idenvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

