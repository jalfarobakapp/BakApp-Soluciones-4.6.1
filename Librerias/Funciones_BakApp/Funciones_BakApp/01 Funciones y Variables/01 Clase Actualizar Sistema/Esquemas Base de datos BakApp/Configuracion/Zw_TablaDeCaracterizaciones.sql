USE [#Base#]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[Zw_TablaDeCaracterizaciones](
	[Tabla]            [varchar](20)  NOT NULL DEFAULT (''),
	[DescripcionTabla] [varchar](100) NOT NULL DEFAULT (''),
	[CodigoTabla]      [varchar](20)  NOT NULL DEFAULT (''),
	[NombreTabla]      [varchar](100) NOT NULL DEFAULT (''),
	[Orden]            [float]        NULL DEFAULT ((0)),
	[ApColor]          [bit]          NULL DEFAULT ((0)),
	[ApModelo]         [bit]          NULL DEFAULT ((0)),
	[ApMedida]         [bit]          NULL DEFAULT ((0)),
	[Porcentaje]       [float]        NOT NULL DEFAULT ((0)),
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Zw_TablaDeCaracterizaciones_1] PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC,
	[CodigoTabla] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','UN','UNIDAD',1)

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','UD','UNIDAD',2)

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','CJ','CAJA',3)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','DP','DISPLAY',4)

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','GL','GALON',5)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','GR','GRUESA',6)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','KG','KILO',7)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','LT','LITRO',8)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','M2','METRO CUADRADO',9)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','ML','METRO LINEAL',10)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','PL','PLANCHA',11)
            
Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('RTU','Razon de transformacion','RO','ROLLO',12)                                    

-- TIPO DE PRODUCTOS

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FPN','Articulo estándar',1)     

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FPS','Articulo seriado',2)     

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FIN','Insumo productivo',3)     

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FUN','Herramienta estándar',4)     

Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FUS','Herramienta seriada',5)     


Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','FLN','Artículo multiproposito',6)     


Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','SSN','Servicios y similares',7)     


Insert Into Zw_TablaDeCaracterizaciones (Tabla,DescripcionTabla,CodigoTabla,NombreTablaOrden,Orden) Values
            ('TIPR','Tipo de productos','GEN','Génerico o agrupador de artículos',8)     
