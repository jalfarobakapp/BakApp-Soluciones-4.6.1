USE [#Base#]

CREATE TABLE [dbo].[Zw_Prod_SobreStock_Tom](
	[Id]                [int] IDENTITY(1,1) NOT NULL,
	[CodFuncionario]    [varchar](3)        NOT NULL,
	[Fecha_Hora]        [datetime]          NULL,
	[NombreEquipo]      [varchar](20)       NOT NULL
) ON [PRIMARY]


