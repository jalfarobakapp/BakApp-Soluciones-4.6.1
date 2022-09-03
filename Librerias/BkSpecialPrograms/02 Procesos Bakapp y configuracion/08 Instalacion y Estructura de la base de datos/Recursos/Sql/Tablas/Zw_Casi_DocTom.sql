USE [#Base#]


CREATE TABLE [dbo].[Zw_Casi_DocTom](
	[Id_DocEnc]      [int]         NOT NULL,
	[CodFuncionario] [char](3)     NOT NULL DEFAULT (''),
	[Fecha_Hora]     [datetime]    NULL,
	[NombreEquipo]   [varchar](50) NOT NULL DEFAULT (''),
	[NroRemota]      [varchar](10) NOT NULL DEFAULT ('')
 CONSTRAINT [PK_Zw_Casi_DocTom] PRIMARY KEY CLUSTERED 
(
	[Id_DocEnc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

