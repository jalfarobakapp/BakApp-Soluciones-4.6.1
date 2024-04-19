USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos](
	[Id_Despacho]				[int] IDENTITY(1,1) Not Null,
	[Id_Despacho_Padre]			[int]			Not Null Default (0),
	[Nro_Despacho]				[varchar](10)	Not Null Default (''),
	[Nro_Sub]					[varchar](3)	Not Null Default (''),
	[Empresa]					[char](2)		Not Null Default (''),
	[Sucursal]					[varchar](3)	Not Null Default (''),
	[Bodega]					[varchar](3)	Not Null Default (''),
	[Confirmado]				[bit]			Not Null Default (0),
	[CodFuncionario]			[char](3)		Not Null Default (''),
	[Fecha_Emision]				[datetime]		Null,
	[Fecha_Compromiso]			[datetime]		Null,
	[Fecha_Despacho]			[datetime]		Null,
	[Fecha_Cierre]				[datetime]		Null,
	[Tipo_Despacho]				[varchar](30)	Not Null Default (''),
	[Tipo_Envio]				[varchar](5)	Not Null Default (''),
	[Tipo_Venta]				[varchar](20)	Not Null Default (''),
	[Estado]					[varchar](3)	Not Null Default (''),
	[Referencia]				[varchar](100)	Not Null Default (''),
	[CodEntidad]				[varchar](13)	Not Null Default (''),
	[CodSucEntidad]				[varchar](10)	Not Null Default (''),
	[Rut]						[varchar](20)	Not Null Default (''),	
	[Nombre_Entidad]			[varchar](50)	Not Null Default (''),
	[Pais]						[varchar](30)	Not Null Default (''),
	[Ciudad]					[varchar](50)	Not Null Default (''),
	[Comuna]					[varchar](50)	Not Null Default (''),
	[Direccion]					[varchar](100)	Not Null Default (''),
	[Telefono]					[varchar](30)	Not Null Default (''),
	[Email]						[varchar](100)	Not Null Default (''),
	[Transportista]				[varchar](13)	Not Null Default (''),
	[Transpor_Por_Pagar]		[bit]			Not Null Default (0),
	[Entregar_Con_Doc_Pagados]	[bit]			Not Null Default (0),
	[Tipo_Entrega]				[varchar](3)	Not Null Default (''),
	[Fecha_Entrega_Transpor]	[datetime]		Null,
	[CodFuncionario_Transpor]	[varchar](3)	Not Null Default (''),
	[Entregado_Por]				[char](3)		Not Null Default (''),
	[Nombre_Transpor]			[varchar](100)	Not Null Default (''),
	[Nro_Encomienda]			[varchar](25)	Not Null Default (''),
	[Observaciones]				[varchar](500)	Not Null Default (''),	
	[Sucursal_Retiro]			[char](3)	    Not Null Default (''),	
    [CodPais]					[char](3)	    Not Null Default (''),
	[CodCiudad]					[char](3)	    Not Null Default (''),
	[CodComuna]					[char](6)	    Not Null Default (''),
    [Nombre_Contacto]			[varchar](50)	Not Null Default (''),
    [EntregaPaletizada]	        [bit]           Not Null DEFAULT(0),
 CONSTRAINT [PK_Zw_Despachos] PRIMARY KEY CLUSTERED 
(
	[Id_Despacho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



