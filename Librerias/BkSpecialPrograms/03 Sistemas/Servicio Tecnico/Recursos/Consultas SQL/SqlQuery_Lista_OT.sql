

SELECT  Id_Ot,Sub_Ot,Id_Ot_Padre,Nro_Ot,Pertenece, 
        Empresa, Sucursal, Bodega, 
        CodEntidad, SucEntidad, Rut,
        Isnull((Select Top 1 NOKOEN From MAEEN Where KOEN = CodEntidad And SUEN = SucEntidad),'') As Cliente, 
        Case Chk_Serv_Domicilio When 1 Then 'Domicilio' Else 'Taller' End As 'Lugar',
        Fecha_Ingreso, 
        DATEDIFF(D,Fecha_Ingreso,Getdate()) AS Dias,
        Fecha_Ingreso As Fecha,
        Fecha_Ingreso As Hora,
        --CONVERT(VARCHAR, Fecha_Ingreso, 103) Fecha,  
        --CONVERT(VARCHAR, Fecha_Ingreso, 108) Hora,
        Fecha_Compromiso, 
        Fecha_Entrega, 
        Fecha_Cierre,
        CodEstado, 
		Case When Codigo <> '' 
				Then Rtrim(Ltrim(Codigo))+' - '+Descripcion 
				Else Rtrim(Ltrim(TMaqui.NombreTabla)) +' '+Rtrim(Ltrim(TMarca.NombreTabla))+' '+Rtrim(Ltrim(TModel.NombreTabla)) End As 'Producto',
        TEstado.NombreTabla As 'Estado', 
        CodMaquina,
        TMaqui.NombreTabla As 'Maquina', 
        CodMarca, 
        TMarca.NombreTabla As 'Marca',
        CodModelo, 
		TModel.NombreTabla As 'Modelo',
        CodCategoria, 
        TCateg.NombreTabla As 'Categoria',
        NroSerie, 
        NroOcc_Cliente, 
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
			Where CodFuncionario = CodTecnico_Asignado) As 'Tecnico_Asignado',
        CodTecnico_Repara, 
        (Select top 1 NomFuncionario 
			From #Db_BakApp#Zw_St_Conf_Tecnicos_Taller 
			Where CodFuncionario = CodTecnico_Repara) As 'Tecnico_Repara',

		IsNull(TEntrega.NombreTabla,'') As 'Estado_Entrega',
        Chk_Equipo_Reparado, 
        Idmaeedo_COV, 
        Nudo_COV, 
        Neto, 
        Iva, 
        Total,
        Cast(0 as Bit) As Chk_Flujo_Trabajo

FROM   #Db_BakApp#Zw_St_OT_Encabezado
	Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TEstado On TEstado.Tabla = 'ESTADOS_ST' And TEstado.CodigoTabla = CodEstado
		Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TMaqui On TMaqui.Tabla = 'MAQUINA_ST' And TMaqui.CodigoTabla = CodMaquina
			Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TMarca On TMarca.Tabla = 'MARCAS' And TMarca.CodigoTabla = CodMarca
				Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TModel On TModel.Tabla = 'MODELOS_ST' And TModel.CodigoTabla = CodModelo
					Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TCateg On TCateg.Tabla = 'CATEGOR_ST' And TCateg.CodigoTabla = CodCategoria
						Left Join #Db_BakApp#Zw_TablaDeCaracterizaciones TEntrega On TEntrega.Tabla = 'ES_ENTREGA_ST' And TEntrega.CodigoTabla = Cod_Estado_Entrega

Where 1 > 0
#Condicion#
