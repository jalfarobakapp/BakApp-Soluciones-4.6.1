

CREATE TABLE #Paso_Vista(
    [Id]                 [int] IDENTITY(1,1) NOT NULL,
    [CODIGO]             [varchar](20) Default  (''),
	[DESCRIPCION]        [varchar](50) Default  (''),
	[DESCRIPCION_VISTA]  [varchar](100) Default (''),
	[EXCEL]              [varchar](50) Default  ('')
) ON [PRIMARY]

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('Empresa','RAZON','EMPRESA','Inf_Empresa') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('Codmeson','Nommeson','MESONES','Inf_Meson') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('Operacion','Nombreop','OPERACION','Inf_Operacion') 

--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ENDO+SUENDO','RAZON','CLIENTES','Inf_Clientes')
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('SULIDO','SUCURSALLIDO','SUCURSAL','Inf_Sucursales') 
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('BOSULIDO','BODEGA','BODEGA','Inf_Bodegas') 

--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CIEN','CIUDAD','(CLIENTES) CIUDAD','Inf_Ciudad')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CIEN+CMEN','COMUNA','(CLIENTES) COMUNAS','Inf_Comunas')       
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('TAMAEN','TAMANO_EMPRESA','(CLIENTES) TAMAÑO EMPRESA','Inf_TamaEn')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('TIPOEN','TIPO_ENTIDAD','(CLIENTES) TIPO ENTIDAD','Inf_TipoEntidad')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ACTIEN','ACTIVIDAD_ECONOMICA','(CLIENTES) ACTIVIDAD ECONOMICA','Inf_ActiEn') 
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('RUEN','RUBRO_EN','(CLIENTES) RUBROS','Inf_Rubro_Enr')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ZOEN','ZONA_EN','(CLIENTES) ZONA','Inf_Zona_En')                         

Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('Codigo','DescripcionPr','PRODUCTOS','Inf_Productos') 
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('FMPR','NOKOFM','PRODUCTOS -> SUPER FAMILIAS','Inf_Super_Familias')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('PFPR','NOKOPF','PRODUCTOS -> FAMILIAS','Inf_Familias')                         
Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('HFPR','NOKOHF','PRODUCTOS -> SUB-FAMILIAS','Inf_SubFamilias')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('MRPR','MARCA','PRODUCTOS -> MARCAS','Inf_Marcas')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('RUPR','RUBRO_PR','PRODUCTOS -> RUBROS','Inf_Rubro_Pr')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CLALIBPR','CLAS_LIBRE','PRODUCTOS -> CLASIFICACION LIBRE','Inf_ClasLibre') 
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('CLAS_BAKAPP','CLASIFICACION_BAKAPP','Clasificación especial BakApp','Inf_Clas_Especial_Bk',15)                                                 
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('ZOPR','ZONA_PR','PRODUCTOS -> ZONAS','Inf_Zona_Pr')                         

--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFULIDO','VENDEDOR','VENDEDORES','Inf_Vendedores')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFUDO','FUNCIONARIO','RESPONSABLE DE DOCUMENTOS','Inf_Responzable')   
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('KOFUEN','VENDEDOR_ASIGNADO','VENDEDOR ASIGNADO AL CLIENTE','Inf_Vendedor_Asignado')                        

--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL) Values ('0','ARBOL_CLASIF','CLASIFICACIONES (BAKAPP)','Class_BakApp')                         
--Insert Into #Paso_Vista (CODIGO,DESCRIPCION,DESCRIPCION_VISTA,EXCEL,ARBOL_BAKAPP,Es_Seleccionable,Nodo_Padre) 
--Values ('-1','Sin_Asociacion','Sin Asociación','Detalle_Inf',1,1,0)

--#Inserta_Campos_Arbol_BakApp#

-- Tabla con todos los Registros  
-- Table
Select * From #Paso_Vista

-- Table 3
Select CODIGO As Padre,DESCRIPCION_VISTA As Hijo 
From #Paso_Vista


Drop Table #Paso_Vista