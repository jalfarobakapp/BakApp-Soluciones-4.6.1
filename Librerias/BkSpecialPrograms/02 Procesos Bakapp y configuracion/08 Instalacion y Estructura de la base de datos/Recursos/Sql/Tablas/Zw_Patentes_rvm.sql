USE [#Base#]

CREATE TABLE [dbo].[Zw_Patentes_rvm](
	[Id]				[int] IDENTITY(1,1) NOT NULL,
	[Patente]			[varchar](10)		NOT NULL DEFAULT (''),
	[Marca]				[varchar](30)		NOT NULL DEFAULT (''),
	[Modelo]			[varchar](50)		NOT NULL DEFAULT (''),
	[AFabricacion]		[varchar](4)		NOT NULL DEFAULT (''),
	[ModeloBusqueda]	[varchar](50)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Patentes_rvm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


