USE [#Base#]


CREATE TABLE [dbo].[Zw_Tmp_Filtros_Busqueda](
	[Funcionario]   [varchar](3)    NOT NULL DEFAULT (''),
	[Informe]       [varchar](30)   NOT NULL DEFAULT (''),
	[Filtro]        [varchar](30)   NOT NULL DEFAULT (''),
	[Chk]           [bit]           NOT NULL DEFAULT (0),
	[Codigo]        [varchar](30)   NOT NULL DEFAULT (''),
	[Descripcion]   [varchar](100)  NOT NULL DEFAULT (''),
	[NombreEquipo]  [varchar](50)   NOT NULL DEFAULT (''),
    [Modalidad]     [varchar](5)    NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Tmp_Filtros_Busqueda] PRIMARY KEY CLUSTERED 
(
	[Funcionario] ASC,
	[Informe] ASC,
	[Filtro] ASC,
	[Codigo] ASC,
	[NombreEquipo] ASC,
    [Modalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


