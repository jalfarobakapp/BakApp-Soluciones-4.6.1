USE [#Base#]


CREATE TABLE [dbo].[Zw_Tbl_DisenoBarras](
	[Semilla]           [int] IDENTITY(1,1) NOT NULL,
	[NombreEtiqueta]    [varchar](80)       NOT NULL DEFAULT (''),
	[TIPO]              [char](1)           NOT NULL DEFAULT (''),
	[CAMPO]             [char](15)          NOT NULL DEFAULT (''),
	[FUNCION]           [text]              NOT NULL DEFAULT (''),
	[CantPorLinea]      [float]             NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Tbl_DisenoBarras] PRIMARY KEY CLUSTERED 
(
	[Semilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



