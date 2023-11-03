

CREATE TABLE #Paso_Vista(
    [Id]                 [int] IDENTITY(1,1) NOT NULL,
    [CODIGO]             [varchar](20) Default  (''),
	[DESCRIPCION]        [varchar](50) Default  (''),
	[DESCRIPCION_VISTA]  [varchar](100) Default (''),
	[EXCEL]              [varchar](50) Default  (''),
	[ARBOL_BAKAPP]       [Bit] Default(0),
	[Es_Seleccionable]   [Bit] Default(0),
	[Nodo_Padre]         [Int] Default(0)
) ON [PRIMARY]

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('EMPRESA','EMPRESA','EMPRESA','Inf_Empresa') 

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ENDO+SUENDO','RAZON','CLIENTES','Inf_Clientes')
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('SUDO','SUCURSAL','SUCURSAL EMISORA DOC. (Encabezado)','Inf_SucursalDoc') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('SULIDO','SUCURSALLIDO','SUCURSAL LINEA DOC. (Detalle)','Inf_Sucursales') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('BOSULIDO','BODEGA','BODEGA','Inf_Bodegas') 

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CIEN','CIUDAD','(CLIENTES) CIUDAD','Inf_Ciudad')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CIEN+CMEN','COMUNA','(CLIENTES) COMUNAS','Inf_Comunas')       
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('TAMAEN','TAMANO_EMPRESA','(CLIENTES) TAMAÑO EMPRESA','Inf_TamaEn')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('TIPOEN','TIPO_ENTIDAD','(CLIENTES) TIPO ENTIDAD','Inf_TipoEntidad')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ACTIEN','ACTIVIDAD_ECONOMICA','(CLIENTES) ACTIVIDAD ECONOMICA','Inf_ActiEn') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('RUEN','RUBRO_EN','(CLIENTES) RUBROS','Inf_Rubro_Enr')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ZOEN','ZONA_EN','(CLIENTES) ZONA','Inf_Zona_En')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('LVEN','NOLVEN','(CLIENTES) LISTAS DE PRECIOS ASOC. -> ZONAS','Inf_ListaEn')                         

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOLTPR','NOKOLTPR','LISTAS DE PRECIOS ASOC. DETALLE DOC.','Inf_ListaPr')                         

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOPRCT','NOKOPR','PRODUCTOS','Inf_Productos') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('FMPR','SUPER_FAMILIA','PRODUCTOS -> SUPER FAMILIAS','Inf_Super_Familias')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('PFPR','FAMILIA','PRODUCTOS -> FAMILIAS','Inf_Familias')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('HFPR','SUB_FAMILIA','PRODUCTOS -> SUB-FAMILIAS','Inf_SubFamilias')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('MRPR','MARCA','PRODUCTOS -> MARCAS','Inf_Marcas')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('RUPR','RUBRO_PR','PRODUCTOS -> RUBROS','Inf_Rubro_Pr')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CLALIBPR','CLAS_LIBRE','PRODUCTOS -> CLASIFICACION LIBRE','Inf_ClasLibre') 
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CLAS_BAKAPP','CLASIFICACION_BAKAPP','Clasificación especial BakApp','Inf_Clas_Especial_Bk',15)                                                 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ZOPR','ZONA_PR','PRODUCTOS -> ZONAS','Inf_Zona_Pr')                         


Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFULIDO','VENDEDOR','VENDEDORES','Inf_Vendedores')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFUDO','FUNCIONARIO','RESPONZABLE DE DOCUMENTOS','Inf_Responzable')   
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFUEN','VENDEDOR_ASIGNADO','VENDEDOR ASIGNADO AL CLIENTE','Inf_Vendedor_Asignado')                        

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('0','ARBOL_CLASIF','CLASIFICACIONES (BAKAPP)','Class_BakApp')                         

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('Mes+Ano','Mes_Ano','MES/AÑO','Inf_MesAno')                         


--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL,ARBOL_BAKAPP,Es_Seleccionable,Nodo_Padre) 
--Values ('-1','Sin_Asociacion','Sin Asociación','Detalle_Inf',1,1,0)

--#Inserta_Campos_Arbol_BakApp#

-- Tabla con todos los Registros  
-- Table
Select * From #Paso_Vista

-- Tabla Sin Entidades ni Productos Para Informe de ventas normal  
-- Table1
Select * From #Paso_Vista 
Where CODIGO Not In ('ENDO+SUENDO','KOPRCT')
Order By Id

-- Table 2
Select CODIGO As Padre,DESCRIPCION_VISTA As Hijo 
From #Paso_Vista
Where ARBOL_BAKAPP = 0 And CODIGO Not In ('ENDO+SUENDO','KOPRCT') And CODIGO <> '-1'

-- Table 3
Select CODIGO As Padre,DESCRIPCION_VISTA As Hijo 
From #Paso_Vista
--Where ARBOL_BAKAPP = 0 And CODIGO Not In ('ENDO+SUENDO','KOPRCT') And CODIGO <> '-1'

Drop Table #Paso_Vista