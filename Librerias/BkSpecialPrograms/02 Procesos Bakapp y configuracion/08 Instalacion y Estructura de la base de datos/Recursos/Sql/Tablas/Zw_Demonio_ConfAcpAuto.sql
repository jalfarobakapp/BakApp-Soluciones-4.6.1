USE [#Base#]

CREATE TABLE [dbo].[Zw_Demonio_ConfAcpAuto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo]		[varchar](50)	NOT NULL DEFAULT (''),
	[Modalidad]			[varchar](5)	NOT NULL DEFAULT (''),
	[NVI]				[bit]			NOT NULL DEFAULT (0),
	[OCC_Star]			[bit]			NOT NULL DEFAULT (0),
	[OCC_Prov]			[bit]			NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Demonio_ConfAsisCompra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



