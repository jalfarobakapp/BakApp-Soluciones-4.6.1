USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_AcpAuto](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]		[varchar](50)		NOT NULL DEFAULT (''),
	[Modalidad]			[varchar](5)		NOT NULL DEFAULT (''),
	[Idmaeedo]			[int]				NOT NULL DEFAULT (0),
	[Tido]				[varchar](3)		NOT NULL DEFAULT (''),
	[Nudo]				[varchar](10)		NOT NULL DEFAULT (''),
	[FechaEmision]		[datetime]			NULL,
	[Informacion]		[varchar](max)		NOT NULL DEFAULT (''),
	[ErrorGrabar]		[bit]				NOT NULL DEFAULT (0),
	[EmailEnviado]		[bit]				NOT NULL DEFAULT (0),
	[Destinatarios]		[varchar](300)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Demonio_AsisCompAuto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
