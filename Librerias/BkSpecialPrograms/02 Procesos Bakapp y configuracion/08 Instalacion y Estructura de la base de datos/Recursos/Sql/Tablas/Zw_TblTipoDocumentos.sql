USE [#Base#]


CREATE TABLE [dbo].[Zw_TblTipoDocumentos](
	[Semilla] [int] IDENTITY(1,1) NOT NULL,
	[Tipodoc] [varchar](3) NOT NULL DEFAULT (''),
	[Nombre_Documento] [varchar](50) NOT NULL DEFAULT (''),
	[Es_Electrinico] [bit] NOT NULL DEFAULT (0),
	[Nro_DTE] [int] NOT NULL DEFAULT (0),
	[Negativo_Positivo] [int] NOT NULL DEFAULT (0),
	[Neto_Bruto] [char](1) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_TblTipoDocumentos] PRIMARY KEY CLUSTERED 
(
	[Tipodoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



