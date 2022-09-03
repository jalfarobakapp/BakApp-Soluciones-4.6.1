USE [#Base#]


CREATE TABLE [dbo].[Zw_TblChoferes_Empresa](
	[CodChofer] [char](3) NOT NULL DEFAULT (''),
	[NomChofer] [varchar](50) NOT NULL DEFAULT (''),
	[Direccion] [varchar](50) NOT NULL DEFAULT (''),
	[Telefono] [varchar](30) NOT NULL DEFAULT (''),
	[Email] [varchar](50) NOT NULL DEFAULT (''),
	[Pais] [char](3) NOT NULL DEFAULT (''),
	[Ciudad] [char](3) NOT NULL DEFAULT (''),
	[Comuna] [char](3) NOT NULL DEFAULT (''),
	[Informacion] [varchar](1000) NOT NULL DEFAULT (''),
	[Licencia] [varchar](10) NOT NULL DEFAULT (''),
	[Habilitado] [bit] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_TblChoferes_Empresa] PRIMARY KEY CLUSTERED 
(
	[CodChofer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
