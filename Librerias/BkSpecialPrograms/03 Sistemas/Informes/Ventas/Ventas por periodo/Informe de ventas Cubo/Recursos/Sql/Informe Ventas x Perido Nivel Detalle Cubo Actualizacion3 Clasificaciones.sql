
-- ACTUALIZACION CLASIFICACIONES DE PRODUCTOS

UPDATE #Tabla_Paso# SET FMPR = '',PFPR = '',HFPR = '',MRPR = '',CLALIBPR = '',RUPR = '',ZOPR = '',SUPER_FAMILIA = '',
                        FAMILIA = '',SUB_FAMILIA = '',MARCA = '',RUBRO_PR = '',CLAS_LIBRE = '',ZONA_PR = '',
						RUEN = '',ZOEN = '',ACTIEN = '',TIPOEN = '',TAMAEN = '',RUBRO_EN = '',ZONA_EN = '', 
						ACTIVIDAD_ECONOMICA = '',TIPO_ENTIDAD = '',TAMANO_EMPRESA = '',
						BODEGA = '',VENDEDOR = '',FUNCIONARIO = ''
WHERE IDMAEEDO IN (#Idmaeedo#)


-- ACTUALIZACION DE FILTRO DE PRODUCTOS

UPDATE #Tabla_Paso# SET 
	FMPR = Isnull((SELECT FMPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''), 
	PFPR = Isnull((SELECT PFPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''),  
	HFPR = Isnull((SELECT HFPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''),  
	MRPR = Isnull((SELECT MRPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''), 
	CLALIBPR = Isnull((SELECT CLALIBPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''),  
	RUPR = Isnull((SELECT RUPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),''), 
	ZOPR = Isnull((SELECT ZONAPR FROM MAEPR WITH (NOLOCK) WHERE KOPR=KOPRCT),'') 
	WHERE IDMAEEDO IN (#Idmaeedo#)

-- ACTUALIZACION DE FILTRO DE ENTIDADES

Update #Tabla_Paso# Set KOFUEN = Isnull(Mn.KOFUEN,''),RUEN = Isnull(Mn.RUEN,''),ZOEN = Isnull(Mn.ZOEN,''),
                        ACTIEN = Isnull(Mn.ACTIEN,''),TIPOEN = Isnull(Mn.TIPOEN,''),TAMAEN = Isnull(Mn.TAMAEN,'')
From #Tabla_Paso# Z1
Inner Join MAEEN Mn On Mn.KOEN = Z1.ENDO And Mn.SUEN = Z1.SUENDO
WHERE IDMAEEDO IN (#Idmaeedo#)

Update #Tabla_Paso# Set VENDEDOR_ASIGNADO = Isnull(Tf.NOKOFU,'')
From #Tabla_Paso# Z1
Inner Join TABFU Tf On Tf.KOFU = Z1.KOFUEN
WHERE IDMAEEDO IN (#Idmaeedo#)

-- ACTUALIZA RESPONSABLE DOCUMENTO

Update #Tabla_Paso# Set KOFUDO = Edo.KOFUDO
From #Tabla_Paso# Z1
Inner Join MAEEDO Edo On Z1.IDMAEEDO = Edo.IDMAEEDO
WHERE Z1.IDMAEEDO In (#Idmaeedo#)

-- ACTUALIZA VENDEDOR DOCUMENTO

Update #Tabla_Paso# Set KOFULIDO = Edo.KOFULIDO
From #Tabla_Paso# Z1
Inner Join MAEDDO Edo On Z1.IDMAEDDO = Edo.IDMAEDDO
WHERE Z1.IDMAEEDO In (#Idmaeedo#)

-- ACTUALIZA LISTA PRECIOS POR DOCUMENTOS

Update #Tabla_Paso# Set KOLTPR = Ddo.KOLTPR,NOKOLTPR = Tp.NOKOLT
From #Tabla_Paso# Z1
Inner Join MAEDDO Ddo On Z1.IDMAEDDO = Ddo.IDMAEDDO
--Left Join TABPP Tp On 'TABPP'+Tp.KOLT = Ddo.KOLTPR 
Left Join TABPP Tp On Tp.KOLT = SUBSTRING(Ddo.KOLTPR ,6,3)
WHERE Z1.IDMAEEDO In (#Idmaeedo#)

-- ACTUALIZA LISTA PRECIOS POR CLIENTE

Update Zw_Informe_Venta Set LVEN = Isnull(En.LVEN,''),NOLVEN = Isnull(Tp.NOKOLT,'')
From #Tabla_Paso# Z1

Left Join MAEEN En On Z1.ENDO = En.KOEN And Z1.SUENDO = En.SUEN
--Left Join TABPP Tp On 'TABPP'+Tp.KOLT = En.LVEN
Left Join TABPP Tp On Tp.KOLT = SUBSTRING(En.LVEN,6,3)
WHERE Z1.IDMAEEDO In (#Idmaeedo#) 

UPDATE #Tabla_Paso# SET 
	BODEGA = ISNULL((SELECT TOP 1 NOKOBO FROM TABBO Tb WHERE Tb.EMPRESA = #Tabla_Paso#.EMPRESA And Tb.KOSU = SULIDO And Tb.KOBO = BOSULIDO ),''),
	VENDEDOR = ISNULL((SELECT TOP 1 NOKOFU FROM TABFU WHERE KOFU = KOFULIDO),''),
	FUNCIONARIO = ISNULL((SELECT TOP 1 NOKOFU FROM TABFU WHERE KOFU = KOFUDO),'')
	WHERE IDMAEEDO IN (#Idmaeedo#)


UPDATE #Tabla_Paso# SET

RUBRO_EN = ISNULL((SELECT TOP 1 NOKORU FROM TABRU Tr WHERE Tr.KORU = #Tabla_Paso#.RUEN),'Sin Rubro'),
ZONA_EN = ISNULL((SELECT TOP 1 NOKOZO FROM TABZO Tr WHERE Tr.KOZO = #Tabla_Paso#.ZOEN),'Sin Zona'), 

ACTIVIDAD_ECONOMICA = ISNULL((SELECT TOP 1 NOKOCARAC 
	FROM TABCARAC Tr WHERE Tr.KOTABLA = 'ACTIVIDADE' AND Tr.KOCARAC = #Tabla_Paso#.ACTIEN),'Sin Activadad Economica'),
TIPO_ENTIDAD = ISNULL((SELECT TOP 1 NOKOCARAC 
	FROM TABCARAC Tr WHERE Tr.KOTABLA = 'TIPOENTIDA' AND Tr.KOCARAC = #Tabla_Paso#.TIPOEN),'Sin Tipo Entidad'),
TAMANO_EMPRESA = ISNULL((SELECT TOP 1 NOKOCARAC 
	FROM TABCARAC Tr WHERE Tr.KOTABLA = 'TAMA�OEMPR' AND Tr.KOCARAC = #Tabla_Paso#.CLALIBPR),'Sin Tama�o Empresa'),

SUPER_FAMILIA = ISNULL((SELECT TOP 1 NOKOFM FROM TABFM Tf WHERE Tf.KOFM = #Tabla_Paso#.FMPR),'Sin Super Famila'),
FAMILIA = ISNULL((SELECT TOP 1 NOKOPF FROM TABPF Pf WHERE Pf.KOFM = #Tabla_Paso#.FMPR And Pf.KOPF = #Tabla_Paso#.PFPR ),'Sin Famila'),
SUB_FAMILIA = ISNULL((SELECT TOP 1 NOKOHF FROM TABHF Hf WHERE Hf.KOFM = #Tabla_Paso#.FMPR And Hf.KOPF = #Tabla_Paso#.PFPR And Hf.KOHF = #Tabla_Paso#.HFPR ),'Sin Sub-Famila'),                                                   
MARCA = ISNULL((SELECT TOP 1 NOKOMR FROM TABMR Tm WHERE Tm.KOMR = #Tabla_Paso#.MRPR),'Sin Marca'),
RUBRO_PR = ISNULL((SELECT TOP 1 NOKORU FROM TABRU Tr WHERE Tr.KORU = #Tabla_Paso#.RUPR),'Sin Rubro'),
CLAS_LIBRE = ISNULL((SELECT TOP 1 NOKOCARAC FROM TABCARAC Tr WHERE Tr.KOTABLA = 'CLALIBPR' AND Tr.KOCARAC = #Tabla_Paso#.CLALIBPR),'Sin Clasificaci�n'),
ZONA_PR = ISNULL((SELECT TOP 1 NOKOZO FROM TABZO Tr WHERE Tr.KOZO = #Tabla_Paso#.ZOPR),'Sin Zona'), 

SUCURSALLIDO = ISNULL((SELECT TOP 1 NOKOSU FROM TABSU Ts WHERE Ts.EMPRESA = #Tabla_Paso#.EMPRESA And Ts.KOSU = #Tabla_Paso#.SULIDO),'??')

WHERE IDMAEEDO IN (#Idmaeedo#)



