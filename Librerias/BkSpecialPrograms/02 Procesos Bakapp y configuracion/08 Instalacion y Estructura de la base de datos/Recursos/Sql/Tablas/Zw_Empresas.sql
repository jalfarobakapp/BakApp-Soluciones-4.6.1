USE [#Base#]

CREATE TABLE [dbo].[Zw_Empresas](
	[Empresa]       [char](2)     NOT NULL DEFAULT (''),
	[Rut]           [varchar](13) NOT NULL DEFAULT (''),
	[Razon]         [varchar](50) NOT NULL DEFAULT (''),
	[Ncorto]        [varchar](20) NOT NULL DEFAULT (''),
	[Direccion]     [varchar](50) NOT NULL DEFAULT (''),
	[Pais]          [varchar](20) NOT NULL DEFAULT (''),
	[Ciudad]        [varchar](30) NOT NULL DEFAULT (''),
	[Comuna]        [varchar](30) NOT NULL DEFAULT (''),
	[Giro]          [varchar](50) NOT NULL DEFAULT (''),
	[Acteco]        [varchar](10) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Empresas] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

