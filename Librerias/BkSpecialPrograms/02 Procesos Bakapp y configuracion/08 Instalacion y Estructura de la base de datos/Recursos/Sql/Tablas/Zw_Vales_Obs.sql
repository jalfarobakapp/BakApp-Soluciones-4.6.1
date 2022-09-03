USE [#Base#]


CREATE TABLE [dbo].[Zw_Vales_Obs](
	[NroVale] [char](10) NOT NULL DEFAULT (''),
	[Observaciones] [varchar](500) NOT NULL DEFAULT (''),
	[Direccion_Desp] [varchar](100) NOT NULL DEFAULT (''),
	[Comuna_Desp] [varchar](50) NOT NULL DEFAULT (''),
	[Ciudad_Desp] [varchar](50) NOT NULL DEFAULT (''),
	[Telefono_Desp] [varchar](100) NOT NULL DEFAULT (''),
	[Horario_Desp] [varchar](100) NOT NULL DEFAULT (''),
	[Fecha_Desp] [datetime] NULL,
	[Contacto_Desp] [varchar](100) NOT NULL DEFAULT (''),
	[Contacto_Desp_Fono] [varchar](100) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_Vales_Obs] PRIMARY KEY CLUSTERED 
(
	[NroVale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


