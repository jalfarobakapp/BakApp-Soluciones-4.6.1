USE [#Base#]


CREATE TABLE [dbo].[Zw_CashDro_Transbank_Cierre](
	[Id]                  [int] IDENTITY(1,1)	NOT NULL,
	[NombreEquipo]        [varchar](20)			NOT NULL DEFAULT (''),
	[Fecha_Hora_Cierre]   [datetime]			NOT NULL DEFAULT (Getdate()),
	[Respuesta_Transbank] [varchar](3000)		NOT NULL DEFAULT (''),
	[Detalle]             [varchar](3000)		NOT NULL DEFAULT (''),
 CONSTRAINT [PK_Zw_CashDro_Transbank_Cierre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



