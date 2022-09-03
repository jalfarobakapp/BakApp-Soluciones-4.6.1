USE [#Base#]

CREATE TABLE [dbo].[Zw_Correos_Cuentas](
	[Nombre_Usuario]	[varchar](200)  NOT NULL DEFAULT (''),
	[Contrasena]		[varchar](30)   NOT NULL DEFAULT (''),
	[Host]				[varchar](100)  NOT NULL DEFAULT (''),
	[Puerto]			[int]           NOT NULL DEFAULT (0),
	[SSL]				[bit]           NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Correos_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Nombre_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



