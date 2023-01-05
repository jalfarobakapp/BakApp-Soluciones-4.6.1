USE [#Base#]

CREATE TABLE [dbo].[Zw_Fincred_Config](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Token]				[varchar](50)		NOT NULL DEFAULT (''),
	[Usuario]			[varchar](50)		NOT NULL DEFAULT (''),
	[Clave]				[varchar](50)		NOT NULL DEFAULT (''),
	[NombreSucursal]	[varchar](50)		NOT NULL DEFAULT (''),
	[AmbientePruebas]	[bit]				NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Fincred_Config] PRIMARY KEY CLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



