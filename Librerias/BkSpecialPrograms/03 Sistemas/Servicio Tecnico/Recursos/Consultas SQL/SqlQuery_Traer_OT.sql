


Declare @Id_Ot Int = #Id_Ot# 


-- ENCABEZADO TABLA (0)

SELECT  Id_Ot, Nro_Ot, Empresa, Sucursal, Bodega, CodEntidad, SucEntidad, Rten ,Rut, 
        Cast('' As Varchar(50)) As	Cliente,
        Fecha_Ingreso, 
        Fecha_Compromiso, 
        Fecha_Entrega, 
        Fecha_Cierre,
        CodEstado, 
        (Select top 1 NombreTabla From #Db_BakApp#Zw_TablaDeCaracterizaciones 
					Where Tabla = 'ESTADOS_ST' And CodigoTabla = CodEstado) As 'Estado', 
        CodMaquina,
        CodMarca,
        CodModelo,
        CodCategoria, 
        NroSerie, 
        NroOcc_Cliente, 
        Chk_Serv_Domicilio, 
        Pais, 
        Ciudad, 
        Comuna, 
        Direccion,
        Nombre_Contacto,
        Telefono_Contacto,
        Email_Contacto,
        Chk_Serv_Reparacion_Stock, 
        Chk_Serv_Mantenimiento_Correctivo, 
        Chk_Serv_Presupuesto_Pre_Aprobado, 
        Chk_Serv_Recoleccion, 
        Chk_Serv_Mantenimiento_Preventivo, 
        Chk_Serv_Garantia,
        Chk_Serv_Demostracion_Maquina,
        CodTecnico_Asignado,
        (Select top 1 NomFuncionario 
			From #Db_BakApp#Zw_St_Conf_Tecnicos_Taller 
			Where CodFuncionario = CodTecnico_Asignado) as Tecnico_Asignado,
        CodTecnico_Repara,
        (Select top 1 NomFuncionario 
			From #Db_BakApp#Zw_St_Conf_Tecnicos_Taller 
			Where CodFuncionario = CodTecnico_Repara) as Tecnico_Repara,
        Horas_Mano_de_Obra_Asignado, 
        Horas_Mano_de_Obra_Repara,
        Chk_Equipo_Reparado, Idmaeedo_COV, Nudo_COV, Neto, Iva, Total,
        Cod_Estado_Entrega,
        IsNull((Select top 1 NombreTabla From #Db_BakApp#Zw_TablaDeCaracterizaciones 
					Where Tabla = 'ES_ENTREGA_ST' And CodigoTabla =  Cod_Estado_Entrega),'') As Estado_Entrega, 
        Chk_Equipo_Abandonado_Por_El_Cliente,
        Chk_No_Existe_COV_Ni_NVV,
		Codigo,
		Descripcion,
		Idmaeedo_GRP_PRE,
		Idmaeedo_GDP_PRE
FROM    #Db_BakApp#Zw_St_OT_Encabezado
Where Id_Ot = @Id_Ot

-- DETALLE PRODUCTOS TABLA (1)
SELECT  Id_Ot, Cast(0 as Bit) As Nuevo_Item,Semilla, Utilizado, Codigo, Descripcion, Cantidad, Ud, Un, CantUd1, CantUd2, Precio, Neto_Linea, Iva_Linea, Total_Linea
FROM    #Db_BakApp#Zw_St_OT_DetProd
Where Id_Ot = @Id_Ot And Desde_COV = 0
Order by Semilla

-- CHECK-IN TABLA (2)
SELECT  Id_Ot,Cast(0 as Bit) As Nuevo_Item,Semilla,Codigo,Check_In,Nota
FROM    #Db_BakApp#Zw_St_OT_CheckIn
Where Id_Ot = @Id_Ot
Order by Semilla

-- NOTAS TABLA (3)
SELECT  Id_Ot, Defecto_segun_cliente, Reparacion_a_realizar, Defecto_encontrado, Reparacion_Realizada, Chk_no_se_pudo_reparar, 
        Motivo_no_reparo, 
        Nota_Etapa_01, 
        Nota_Etapa_02, 
        Nota_Etapa_03, 
        Nota_Etapa_04, 
        Nota_Etapa_05, 
        Nota_Etapa_06, 
        Nota_Etapa_07, 
        Nota_Etapa_08

FROM    #Db_BakApp#Zw_St_OT_Notas
Where Id_Ot = @Id_Ot

-- ESTADOS TABLA (4)
SELECT  Id_Ot,Cast(0 as Bit) As Nuevo_Item,Semilla,CodEstado,Fecha_Fijacion,CodFuncionario,NomFuncionario
FROM    #Db_BakApp#Zw_St_OT_Estados
Where Id_Ot = @Id_Ot
Order by Semilla

-- ACCESORIOS TABLA (5)

SELECT  Id_Ot, Cast(0 as Bit) As Nuevo_Item,Semilla,Codigo,Articulo,Cantidad,NroSerie,Nota
FROM    #Db_BakApp#Zw_St_OT_Accesorios
Where Id_Ot = @Id_Ot
Order by Semilla


-- COTIZACIONES TABLA (6)

SELECT Id_Ot,Idmaeedo,Tido,Nudo,Estado,
		Case Estado 
			When 'E' Then 'En Evaluación...' 
			When 'A' Then 'ACEPTADO' 
			When 'R' Then 'RECHAZADO' 
		End As Estado_D,Fecha_Asociacion,
		CONVERT(VARCHAR, Fecha_Asociacion, 103) Fecha,
		Fecha_Doc,Seleccionado
FROM   #Db_BakApp#Zw_St_OT_Doc_Asociados
Where Id_Ot = @Id_Ot and Tido In ('COV','NVV')


-- DETALLE PRODUCTOS COTIZACION APROBADA (7)

SELECT  Id_Ot, Cast(0 as Bit) As Chk_Validado,Semilla, Utilizado, Codigo, Descripcion, Cantidad, Cantidad_Utilizada,Ud, 
        Un, CantUd1, CantUd2, Precio, Neto_Linea, Iva_Linea, Total_Linea,Desde_COV, Idmaeedo_Cov,Idmaeddo_Cov
FROM    #Db_BakApp#Zw_St_OT_DetProd
Where Id_Ot = @Id_Ot And Desde_COV = 1
Order by Semilla


-- FACTURAS TABLA (8)

SELECT Id_Ot,Idmaeedo,Tido,Nudo,
       Isnull((Select Top 1 NOKOEN From MAEEN 
			Where KOEN+SUEN = (Select ENDO+SUENDO From MAEEDO Where IDMAEEDO = Zw_Fv.Idmaeedo)),'') As Cliente,
       --Cast('' as Varchar(50)) As Cliente,
       Fecha_Asociacion,
	   CONVERT(VARCHAR, Fecha_Asociacion, 103) Fecha,
	   Fecha_Doc,
	   Isnull((Select TOP 1 VABRDO From MAEEDO Where IDMAEEDO = Zw_Fv.Idmaeedo),0) As Total
FROM   #Db_BakApp#Zw_St_OT_Doc_Asociados Zw_Fv
Where Id_Ot = @Id_Ot And Tido In ('FCV','GDV','GDI','GDP','GDD') And Garantia = 0

-- FACTURA GARANTIA TABLA (9)

SELECT Id_Ot,Idmaeedo,Tido,Nudo,
       Cast('' as Varchar(50)) As Cliente,
       Fecha_Asociacion,
	   CONVERT(VARCHAR, Fecha_Asociacion, 103) Fecha,
	   Fecha_Doc,
	   Cast(0 as Float) as Total,
	   Documento_Externo
FROM   #Db_BakApp#Zw_St_OT_Doc_Asociados Zw_Fv
Where Id_Ot = @Id_Ot And Garantia = 1
