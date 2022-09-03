USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Tom](
	[Id_Despacho]		[int]			NOT NULL,
	[CodFuncionario]	[char](3)		NOT NULL Default(''),
	[Fecha_Hora]		[datetime]		NULL Default (Getdate()),
	[NombreEquipo]		[varchar](50)	NOT NULL Default(''),
 CONSTRAINT [PK_Zw_Despachos_Tom] PRIMARY KEY CLUSTERED 
(
	[Id_Despacho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



