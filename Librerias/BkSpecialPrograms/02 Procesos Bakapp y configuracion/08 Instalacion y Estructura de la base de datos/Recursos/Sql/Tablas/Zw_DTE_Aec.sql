USE [#Base#]

CREATE TABLE [dbo].[Zw_DTE_Aec](
	[Id_Aec]					[int] IDENTITY(1,1) NOT NULL,
	[Id_Dte]					[int]			NOT NULL DEFAULT (0),
	[Idmaeedo]					[int]			NOT NULL DEFAULT (0),
	[Tido]						[varchar](3)	NOT NULL DEFAULT (''),
	[Nudo]						[varchar](10)	NOT NULL DEFAULT (''),
	[FechaSolicitud]			[datetime]		NULL,
	[RutCedente]				[varchar](13)	NOT NULL DEFAULT (''),
	[RutCesionario]				[varchar](13)	NOT NULL DEFAULT (''),
	[RazonSocialCesionario]		[varchar](50)	NOT NULL DEFAULT (''),
	[DireccionCesionario]		[varchar](50)	NOT NULL DEFAULT (''),
	[eMailCesionario]			[varchar](100)	NOT NULL DEFAULT (''),
	[MontoCesion]				[float]			NOT NULL DEFAULT (0),
	[FUltimoVencimiento]		[datetime]		NULL,
	[RutAutoriza]				[varchar](13)	NOT NULL DEFAULT (''),
	[NombreAutoriza]			[varchar](50)	NOT NULL DEFAULT (''),
	[eMailCedente]				[varchar](100)	NULL,
	[NmbContacto]				[varchar](50)	NOT NULL DEFAULT (''),
	[FonoContacto]				[varchar](20)	NOT NULL DEFAULT (''),
	[MailContacto]				[varchar](100)	NOT NULL DEFAULT (''),
	[Xml]						[varchar](max)	NOT NULL DEFAULT (''),
	[Procesar]					[bit]			NOT NULL DEFAULT (0),
	[Procesado]					[bit]			NOT NULL DEFAULT (0),
	[ErrorEnvioAEC]				[bit]			NOT NULL DEFAULT (0),
	[AmbienteCertificacion]		[bit]			NOT NULL DEFAULT (0),
	[DeclaracionJurada]			[varchar](max)	NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_DTE_Aec] PRIMARY KEY CLUSTERED 
(
	[Id_Aec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

