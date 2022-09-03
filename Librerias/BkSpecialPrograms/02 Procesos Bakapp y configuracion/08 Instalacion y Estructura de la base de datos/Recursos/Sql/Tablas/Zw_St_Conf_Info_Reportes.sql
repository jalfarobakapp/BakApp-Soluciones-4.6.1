USE [#Base#]


CREATE TABLE [dbo].[Zw_St_Conf_Info_Reportes](
	[Semilla]       [int] IDENTITY(1,1)     NOT NULL,
	[Reporte]       [varchar](20)           NOT NULL DEFAULT (''),
	[Condiciones]   [varchar](8000)         NOT NULL DEFAULT (''),
	[Garantia]      [varchar](8000)         NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_St_Conf_Info_Reportes] PRIMARY KEY CLUSTERED 
(
	[Semilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



