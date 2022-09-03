USE [#Base#]


CREATE TABLE [dbo].[Zw_Licencia](
	[Rut]				[varchar](20)	NOT NULL DEFAULT (''),
	[Razon]				[varchar](100)	NOT NULL DEFAULT (''),
	[NombreCorto]		[varchar](100)	NOT NULL DEFAULT (''),
	[Direccion]			[varchar](100)	NOT NULL DEFAULT (''),
	[Giro]				[varchar](200)	NOT NULL DEFAULT (''),
	[Ciudad]			[varchar](100)	NOT NULL DEFAULT (''),
	[Pais]				[varchar](50)	NOT NULL DEFAULT (''),
	[Telefonos]			[varchar](50)	NOT NULL DEFAULT (((1)-(1))-(2000)),
	[Libre]				[bit]			NOT NULL DEFAULT (1),
	[Fecha_caduca]		[datetime]		NOT NULL DEFAULT (0),
	[Cant_licencias]	[int]			NOT NULL DEFAULT (0),
	[Llave1]			[varchar](50)	NOT NULL DEFAULT (''),
	[Llave2]			[varchar](50)	NOT NULL DEFAULT (''),
	[Llave3]			[varchar](50)	NOT NULL DEFAULT (''),
	[Llave4]			[varchar](50)	NOT NULL DEFAULT (''),
	[Activa]			[bit]			NOT NULL DEFAULT (1),
 CONSTRAINT [PK_Zw_Licencia] PRIMARY KEY CLUSTERED 
(
	[Rut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



