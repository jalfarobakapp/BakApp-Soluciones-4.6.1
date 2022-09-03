

SELECT  Id_Ot, Nro_Ot, 
        Empresa, Sucursal, Bodega, 
        CodEntidad, SucEntidad, Rut,
        Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN = CodEntidad And SUEN = SucEntidad),'') As Cliente, 
        Case Chk_Serv_Domicilio When 1 Then 'Domicilio' Else 'Taller' End As 'Lugar',
        Fecha_Ingreso, 
        CONVERT(VARCHAR, Fecha_Ingreso, 103) Fecha,  
        CONVERT(VARCHAR, Fecha_Ingreso, 108) Hora,
        Fecha_Compromiso, 
        Fecha_Entrega, 
        Fecha_Cierre,
        CodEstado, 
        (Select top 1 NombreTabla From #Db_BakApp#Zw_TablaDeCaracterizaciones 
					Where Tabla = 'ESTADOS_ST' And CodigoTabla = CodEstado) As 'Estado', 
        CodMaquina,
        (Select Top 1 NombreTabla 
        From BAKAPP_VH.dbo.Zw_TablaDeCaracterizaciones Where Tabla = 'MAQUINA_ST' And CodigoTabla = CodMaquina) As 'Maquina', 
        CodMarca, 
        (Select Top 1 NombreTabla 
        From BAKAPP_VH.dbo.Zw_TablaDeCaracterizaciones Where Tabla = 'MARCAS' And CodigoTabla = CodMarca) As 'Marca',
        CodModelo, 
        (Select Top 1 NombreTabla 
        From BAKAPP_VH.dbo.Zw_TablaDeCaracterizaciones Where Tabla = 'MODELOS_ST' And CodigoTabla = CodModelo) As 'Modelo',
        CodCategoria, 
        (Select Top 1 NombreTabla 
        From BAKAPP_VH.dbo.Zw_TablaDeCaracterizaciones Where Tabla = 'CATEGOR_ST' And CodigoTabla = CodCategoria) As 'Categoria',
        NroSerie, NroOcc_Cliente, 
        Chk_Serv_Domicilio, 
        Chk_Serv_Reparacion_Stock, 
        Chk_Serv_Mantenimiento_Correctivo, 
        Chk_Serv_Presupuesto_Pre_Aprobado, 
        Chk_Serv_Recoleccion, 
        Chk_Serv_Mantenimiento_Preventivo, 
        Chk_Serv_Garantia, 
        CodTecnico_Asignado,
        (Select top 1 NomFuncionario 
			From #Db_BakApp#Zw_St_Conf_Tecnicos_Taller 
			Where CodFuncionario = CodTecnico_Asignado) as Tecnico_Asignado,
        CodTecnico_Repara, 
        (Select top 1 NomFuncionario 
			From #Db_BakApp#Zw_St_Conf_Tecnicos_Taller 
			Where CodFuncionario = CodTecnico_Repara) as Tecnico_Repara,
		IsNull((Select top 1 NombreTabla From #Db_BakApp#Zw_TablaDeCaracterizaciones 
					Where Tabla = 'ES_ENTREGA_ST' And CodigoTabla =  Cod_Estado_Entrega),'') As 'Estado_Entrega',	
        Chk_Equipo_Reparado, 
        Idmaeedo_COV, 
        Nudo_COV, 
        Neto, 
        Iva, 
        Total,
        Cast(0 as Bit) As Chk_Flujo_Trabajo
FROM   #Db_BakApp#Zw_St_OT_Encabezado