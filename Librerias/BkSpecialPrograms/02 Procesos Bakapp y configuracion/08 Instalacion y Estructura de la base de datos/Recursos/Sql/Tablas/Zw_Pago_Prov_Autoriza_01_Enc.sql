USE [#Base#]


CREATE TABLE [dbo].[Zw_Pago_Prov_Autoriza_01_Enc](
	[Id_Autoriza]		[int] IDENTITY(1,1) NOT NULL,
	[Referencia]		[varchar](100) NOT NULL DEFAULT (''),
	[Funcionario]		[varchar](3) NOT NULL DEFAULT (''),
	[Fecha_Autoriza]	[datetime] NOT NULL,
	[Fecha_Pago]		[datetime] NULL,
	[Tipo_Pago]			[char](3) NOT NULL DEFAULT (''),
	[Total]				[float] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Pago_Prov_Autoriza_01_Enc] PRIMARY KEY CLUSTERED 
(
	[Id_Autoriza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

