USE [#Base#]


CREATE TABLE [dbo].[Zw_Remotas_En_Cadena_01_Enc](
	[Id_Enc]			[int] IDENTITY(1,1) NOT NULL,
	[Empresa]			[char](2) NOT NULL DEFAULT (''),
	[Estado]			[char](1) NOT NULL DEFAULT (''),
	[Nro_RCadena]		[char](10) NOT NULL DEFAULT (''),
	[CodEntidad]		[varchar](13) NOT NULL DEFAULT (''),
	[CodSucEntidad]		[varchar](10) NOT NULL DEFAULT (''),
	[Nombre_Entidad]	[varchar](50) NOT NULL DEFAULT (''),
	[Id_DocEnc]			[int] NOT NULL DEFAULT (0),
	[Usuario_Solicita]	[char](3) NOT NULL DEFAULT (''),
	[Fecha_Hora]		[datetime] NOT NULL DEFAULT (Getdate()),
	[Idmaeedo]			[int] NOT NULL DEFAULT (0),
	[Tido]				[char](3) NOT NULL DEFAULT (''),
	[Nudo]				[char](10) NOT NULL DEFAULT (''),
	[Total_Original]	[float] NOT NULL DEFAULT (0),
	[Total_Documento]	[float] NOT NULL DEFAULT (0),
	[Fecha_Hora_Grab]	[datetime] NULL,
	[Id_Enc_Padre]		[int] NOT NULL DEFAULT (0),
	[Modalidad]			[char](5) NOT NULL DEFAULT (''),
	[Eliminar]			[bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Remotas_En_Cadena_01_Enc] PRIMARY KEY CLUSTERED 
(
	[Id_Enc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


