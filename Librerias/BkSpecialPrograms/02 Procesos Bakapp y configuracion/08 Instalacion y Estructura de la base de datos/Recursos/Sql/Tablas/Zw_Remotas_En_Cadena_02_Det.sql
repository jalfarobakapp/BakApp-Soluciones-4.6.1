USE [#Base#]


CREATE TABLE [dbo].[Zw_Remotas_En_Cadena_02_Det](
	[Id_Enc]			[int] NOT NULL DEFAULT (0),
	[Id_Det]			[int] IDENTITY(1,1) NOT NULL,
	[Nro_RCadena]		[varchar](10) NOT NULL DEFAULT (''),
	[Orden]				[int] NOT NULL DEFAULT (0),
	[CodPermiso]		[varchar](10) NOT NULL DEFAULT (''),
	[Descripcion]		[varchar](150) NOT NULL DEFAULT (''),
	[NroRemota]			[varchar](10) NOT NULL DEFAULT (''),
	[New_Id_DocEnc]		[int] NOT NULL DEFAULT (0),
	[Monto_Aprobacion]	[float] NOT NULL DEFAULT (0),
 CONSTRAINT [PK_Zw_Remotas_En_Cadena_02_Det] PRIMARY KEY CLUSTERED 
(
	[Id_Det] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



