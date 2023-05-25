USE [#Base#]


CREATE TABLE [dbo].[Zw_Tbl_DisenoBarras_SalPtoxEstacion](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Semilla_Padre]		[int]				NOT NULL,
	[NombreEquipo]		[varchar](20)		NOT NULL DEFAULT (''),
	[Puerto]			[varchar](5)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Tbl_DisenoBarras_SalPtoxEstacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


