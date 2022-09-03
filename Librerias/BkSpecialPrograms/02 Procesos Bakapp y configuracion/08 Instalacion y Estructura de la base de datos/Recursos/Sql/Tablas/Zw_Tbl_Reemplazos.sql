USE [#Base#]


CREATE TABLE [dbo].[Zw_Tbl_Reemplazos](
	[Codigo_Madre] [varchar](13) NOT NULL DEFAULT (''),
	[Descripcion_Madre] [varchar](100) NOT NULL DEFAULT (''),
	[Codigo_Nodo] [int] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Tbl_Reemplazos] PRIMARY KEY CLUSTERED 
(
	[Codigo_Madre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



