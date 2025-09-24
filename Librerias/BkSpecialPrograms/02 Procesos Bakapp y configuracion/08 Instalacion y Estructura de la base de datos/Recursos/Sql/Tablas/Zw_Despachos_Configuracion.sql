USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Configuracion](
	[Empresa]                       [char](2)       NOT NULL DEFAULT(''),
	[Pedir_Sucursal_Retiro]         [bit]           NOT NULL DEFAULT(0),
	[Tipo_Venta_X_Defecto]          [varchar](20)   NOT NULL DEFAULT(''),
	[Transportista_X_Defecto]       [varchar](13)   NOT NULL DEFAULT(''),
	[Obs_Retira_Cliente]            [varchar](50)   NOT NULL DEFAULT(''),
    [Obs_DirCom]                    [bit]           NOT NULL DEFAULT(0),
    [Transpor_Por_Pagar]            [bit]           NOT NULL DEFAULT(0),
    [Valor_Min_Despacho]            [float]         NOT NULL DEFAULT(0),
    [Peso_Min_Despacho]             [float]         NOT NULL DEFAULT(0),
    [Mostrar_RetiraTransportista]   [bit]           NOT NULL DEFAULT(0),
    [Mostrar_Agencia]               [bit]           NOT NULL DEFAULT(0),
    [ConfirmarLecturaDespacho]      [bit]           NOT NULL DEFAULT(0),
    [Sucursal]                      [varchar](3)    NOT NULL DEFAULT(''),
    [NoObligadatosRetiraCliente]    [bit]           NOT NULL DEFAULT(0),
 CONSTRAINT [PK_Zw_Despachos_Configuracion] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
