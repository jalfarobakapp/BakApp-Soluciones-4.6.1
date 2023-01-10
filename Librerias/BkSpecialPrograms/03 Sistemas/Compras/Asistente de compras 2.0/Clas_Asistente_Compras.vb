Imports DevComponents.DotNetBar

Public Class Clas_Asistente_Compras

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Informe As String

    Dim _Tiempo_Reposicion As Integer

    Dim _Chk_Sabado As Boolean
    Dim _Chk_Domingo As Boolean

    Dim _Input_Tiempo_Reposicion As Integer
    Dim _Input_Tiempo_Proyeccion As Enum_Proyeccion

    Dim _Input_Porc_Crecimiento As Integer
    Dim _Input_Dias_a_Abastecer As Integer

    Dim _Proyeccion_Tiempo_Reposicion As Enum_Proyeccion
    Dim _Proyeccion_Metodo_Abastecer As Enum_Proyeccion

    Dim _Chk_Rotacion_Con_Ent_Excluidas As Boolean
    Dim _Chk_Trabajando_Con_Proyeccion As Boolean
    Dim _Chk_Restar_Stok_Bodega As Boolean
    Dim _Chk_Advertir_Rotacion As Boolean
    Dim _Input_Dias_Advertencia_Rotacion As Integer
    Dim _Rdb_Agrupar_x_Asociados As Boolean
    Dim _Rdb_Ud1_Compra As Boolean
    Dim _Rdb_Ud2_Compra As Boolean
    Dim _Filtro_Bodegas_Todas As String
    Dim _Tbl_Filtro_Bodegas As DataTable
    Dim _Proceso_Automatico_Ejecutado As Boolean
    Dim _Rdb_RotDias As Boolean
    Dim _Rdb_RotMeses As Boolean
    Dim _Rdb_Rot_Mediana As Boolean
    Dim _Rdb_Rot_Promedio As Boolean

    Public Property Chk_SumerStockExternoAlFisico As Boolean

    Enum Enum_Proyeccion
        Dias
        Semanas
        Meses
    End Enum

    Public Property Pro_Chk_Sabado() As Boolean
        Get
            Return _Chk_Sabado
        End Get
        Set(ByVal value As Boolean)
            _Chk_Sabado = value
        End Set
    End Property
    Public Property Pro_Chk_Domingo() As Boolean
        Get
            Return _Chk_Domingo
        End Get
        Set(ByVal value As Boolean)
            _Chk_Domingo = value
        End Set
    End Property
    Public Property Pro_Input_Tiempo_Reposicion() As Integer
        Get
            Return _Input_Tiempo_Reposicion
        End Get
        Set(ByVal value As Integer)
            _Input_Tiempo_Reposicion = value
        End Set
    End Property
    Public Property Pro_Input_Tiempo_Proyeccion() As Enum_Proyeccion
        Get
            Return _Input_Tiempo_Proyeccion
        End Get
        Set(ByVal value As Enum_Proyeccion)
            _Input_Tiempo_Proyeccion = value
        End Set
    End Property

    Public Property Pro_Proyeccion_Tiempo_Reposicion() As Enum_Proyeccion
        Get
            Return _Proyeccion_Tiempo_Reposicion
        End Get
        Set(ByVal value As Enum_Proyeccion)
            _Proyeccion_Tiempo_Reposicion = value
        End Set
    End Property
    Public Property Pro_Proyeccion_Metodo_Abastecer() As Enum_Proyeccion
        Get
            Return _Proyeccion_Metodo_Abastecer
        End Get
        Set(ByVal value As Enum_Proyeccion)
            _Proyeccion_Metodo_Abastecer = value
        End Set
    End Property

    Public Property Pro_Input_Porc_Crecimiento() As Integer
        Get
            Return _Input_Porc_Crecimiento
        End Get
        Set(ByVal value As Integer)
            _Input_Porc_Crecimiento = value
        End Set
    End Property
    Public Property Pro_Input_Dias_a_Abastecer() As Integer
        Get
            Return _Input_Dias_a_Abastecer
        End Get
        Set(ByVal value As Integer)
            _Input_Dias_a_Abastecer = value
        End Set
    End Property

    Public Property Pro_Chk_Rotacion_Con_Ent_Excluidas() As Boolean
        Get
            Return _Chk_Rotacion_Con_Ent_Excluidas
        End Get
        Set(ByVal value As Boolean)
            _Chk_Rotacion_Con_Ent_Excluidas = value
        End Set
    End Property
    Public Property Pro_Chk_Trabajando_Con_Proyeccion() As Boolean
        Get
            Return _Chk_Trabajando_Con_Proyeccion
        End Get
        Set(ByVal value As Boolean)
            _Chk_Trabajando_Con_Proyeccion = value
        End Set
    End Property
    Public Property Pro_Chk_Restar_Stok_Bodega() As Boolean
        Get
            Return _Chk_Restar_Stok_Bodega
        End Get
        Set(ByVal value As Boolean)
            _Chk_Restar_Stok_Bodega = value
        End Set
    End Property
    Public Property Pro_Chk_Advertir_Rotacion() As Boolean
        Get
            Return _Chk_Advertir_Rotacion
        End Get
        Set(ByVal value As Boolean)
            _Chk_Advertir_Rotacion = value
        End Set
    End Property
    Public Property Pro_Input_Dias_Advertencia_Rotacion() As Integer
        Get
            Return _Input_Dias_Advertencia_Rotacion
        End Get
        Set(ByVal value As Integer)
            _Input_Dias_Advertencia_Rotacion = value
        End Set
    End Property
    Public Property Pro_Rdb_Agrupar_x_Asociados() As Boolean
        Get
            Return _Rdb_Agrupar_x_Asociados
        End Get
        Set(ByVal value As Boolean)
            _Rdb_Agrupar_x_Asociados = value
        End Set
    End Property
    Public Property Pro_Rdb_Ud1_Compra() As Boolean
        Get
            Return _Rdb_Ud1_Compra
        End Get
        Set(ByVal value As Boolean)
            _Rdb_Ud1_Compra = value
        End Set
    End Property
    Public Property Pro_Rdb_Ud2_Compra() As Boolean
        Get
            Return _Rdb_Ud2_Compra
        End Get
        Set(ByVal value As Boolean)
            _Rdb_Ud2_Compra = value
        End Set
    End Property
    Public Property Pro_Filtro_Bodegas_Todas() As String
        Get
            Return _Filtro_Bodegas_Todas
        End Get
        Set(ByVal value As String)
            _Filtro_Bodegas_Todas = value
        End Set
    End Property
    Public Property Pro_Tbl_Filtro_Bodegas() As DataTable
        Get
            Return _Tbl_Filtro_Bodegas
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Filtro_Bodegas = value
        End Set
    End Property
    Public Property Pro_Proceso_Automatico_Ejecutado() As Boolean
        Get
            Return _Proceso_Automatico_Ejecutado
        End Get
        Set(ByVal value As Boolean)
            _Proceso_Automatico_Ejecutado = value
        End Set
    End Property
    Public ReadOnly Property Pro_Nombre_Tbl_Paso_Informe() As String
        Get
            Return _Nombre_Tbl_Paso_Informe
        End Get
    End Property

    Public Property Rdb_RotDias As Boolean
        Get
            Return _Rdb_RotDias
        End Get
        Set(value As Boolean)
            _Rdb_RotDias = value
        End Set
    End Property

    Public Property Rdb_RotMeses As Boolean
        Get
            Return _Rdb_RotMeses
        End Get
        Set(value As Boolean)
            _Rdb_RotMeses = value
        End Set
    End Property

    Public Property Rdb_Rot_Mediana As Boolean
        Get
            Return _Rdb_Rot_Mediana
        End Get
        Set(value As Boolean)
            _Rdb_Rot_Mediana = value
        End Set
    End Property

    Public Property Rdb_Rot_Promedio As Boolean
        Get
            Return _Rdb_Rot_Promedio
        End Get
        Set(value As Boolean)
            _Rdb_Rot_Promedio = value
        End Set
    End Property

    Public Sub New(ByVal Nombre_Tbl_Paso_Informe As String)
        _Nombre_Tbl_Paso_Informe = Nombre_Tbl_Paso_Informe
        _Rdb_RotMeses = True
    End Sub

    Sub Sb_Actualizar_Rotacion(_Codigo As String, _Actualizar_Dias_Stock_En_Bodega As Boolean)

        Try

            Dim _Ud

            If _Rdb_Ud1_Compra Then : _Ud = 1 : Else : _Ud = 2 : End If

            Dim _Campo_CalUd_Diario As String
            Dim _Campo_CalUd_Mensual As String
            Dim _RotCalculo As String
            Dim _TipoRotCalculo As String

            If _Rdb_Rot_Mediana Then
                _Campo_CalUd_Diario = "RotDiariaUd"
                _Campo_CalUd_Mensual = "RotMensualUd"
                _TipoRotCalculo = "Mediana"
            End If

            If _Rdb_Rot_Promedio Then
                _Campo_CalUd_Diario = "Promedio_Ud"
                _Campo_CalUd_Mensual = "Promedio_MensualUd"
                _TipoRotCalculo = "Promedio"
            End If

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then
                _TipoRotCalculo += " diario"
                _RotCalculo = _Campo_CalUd_Diario
            Else
                _TipoRotCalculo += " mensual"
                _RotCalculo = _Campo_CalUd_Mensual
            End If


            '_Campo_CalUd_Diario = "RotDiariaUd" & _Ud

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set TipoRotCalculo = '" & _TipoRotCalculo & "',RotCalculo = " & _Campo_CalUd_Diario & _Ud
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Dim _Fecha_Servidor As Date = FechaDelServidor()

            Dim _Filtro_Bodega As String

            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And Empresa+Sucursal+Bodega In " & _Filtro_Bodega
            End If


            Dim _UsarSabado = CInt(_Chk_Sabado) * -1
            Dim _UsarDomingo = CInt(_Chk_Domingo) * -1

            Dim _Dias_Abastecer As Integer ' = Input_Dias_a_Abastecer.Value
            Dim _Meses_Abastecer As Double ' = Input_Dias_a_Abastecer.Value

            Dim _Tiempo_Reposicion = _Input_Tiempo_Reposicion
            Dim _Tiempo_Reposicion_Mensual As Double

            Dim _Porc_Cre = 1 + (_Input_Porc_Crecimiento / 100) 'Input_Porc_Crecimiento.Value 
            Dim _Porc_Crecimiento As String = De_Num_a_Tx_01(_Porc_Cre)

            Dim _Dias_Prom_Mensual As Double
            Dim _DM_Proyec_Tr, _DM_Abastecer As Double

            Dim _Dias_Habiles = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                             Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Habiles)
            Dim _Dias_Sabado = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                                Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Sabado)
            Dim _Dias_Domingo = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                                Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Domingo)

            _Dias_Prom_Mensual = _Dias_Habiles

            If _Chk_Sabado Then _Dias_Prom_Mensual += _Dias_Sabado
            If _Chk_Domingo Then _Dias_Prom_Mensual += _Dias_Domingo

            _Dias_Prom_Mensual = Math.Round(_Dias_Prom_Mensual / 12, 0)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then '_Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Meses Then 'Cmb_Proyeccion_Tiempo_Reposicion.Text = "meses" Then
                _DM_Proyec_Tr = 1
            Else
                _DM_Proyec_Tr = 365 / 12
            End If

            If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then '_Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Meses Then
                _DM_Abastecer = 1
            Else
                _DM_Abastecer = Math.Round(365 / 12, 5)
            End If

            _Tiempo_Reposicion = _Input_Tiempo_Reposicion * _DM_Proyec_Tr 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue
            _Dias_Abastecer = _Input_Dias_a_Abastecer * _DM_Abastecer 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue ' + _Tiempo_Reposicion

            _Meses_Abastecer = _Input_Dias_a_Abastecer 'Math.Round(_Dias_Abastecer / _Dias_Prom_Mensual, 1) 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue '_Dias_Proyeccion
            _Tiempo_Reposicion_Mensual = _Input_Tiempo_Reposicion 'Math.Round(_Tiempo_Reposicion / _Dias_Prom_Mensual, 1) 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue

            Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, _Fecha_Servidor)

            _Dias_Abastecer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Habiles)

            Dim _Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Sabado)
            Dim _Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Domingo)
            Dim _RestarStock = CInt(_Chk_Restar_Stok_Bodega) * -1

            If _Chk_Sabado Then _Dias_Abastecer += _Sabados
            If _Chk_Domingo Then _Dias_Abastecer += _Domingos


            Dim _Dias_Proyeccion_Venta = _Dias_Abastecer

            If _Chk_Sabado Then _Dias_Proyeccion_Venta += _Sabados
            If _Chk_Domingo Then _Dias_Proyeccion_Venta += _Domingos

            _Dias_Proyeccion_Venta = _Dias_Prom_Mensual

            ' ACTUALIZA VELOCIDAD DE SALIDAD, DIAS DE STOCK EN BODEGA PARA LOS PRODUCTOS

            'If _Rdb_RotDias Then

            '    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
            '                   "RotMensualUd1 = Ceiling(RotDiariaUd1*" & _Dias_Proyeccion_Venta & ")," & vbCrLf &
            '                   "RotMensualUd2 = Ceiling(RotDiariaUd2*" & _Dias_Proyeccion_Venta & ")"
            '    _Sql.Ej_consulta_IDU(Consulta_sql)

            'End If

            'If _Rdb_RotMeses Then

            ' Debo poner un validador que permita preguntar si quiere redondear hacia arriba o no Sierralta lo usa, La Colchaguina No
            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotMensualUd1 = Ceiling(RotMensualUd1)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotDiariaUd1 = Round(RotMensualUd1/" & _Dias_Prom_Mensual & ",3)," & vbCrLf &
                           "RotDiariaUd2 = Round(RotMensualUd2/" & _Dias_Prom_Mensual & ",3)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotMensualUd1_Prod = Ceiling(RotMensualUd1_Prod)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotDiariaUd1_Prod = Round(RotMensualUd1_Prod/" & _Dias_Prom_Mensual & ",3)," & vbCrLf &
                           "RotDiariaUd2_Prod = Round(RotMensualUd2_Prod/" & _Dias_Prom_Mensual & ",3)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            '----------------------------------------------------------------------------------------


            Dim _Advertir_Rotacion As Boolean = _Chk_Advertir_Rotacion
            Dim _Dias_Advertir_Rotacion As Integer = _Input_Dias_Advertencia_Rotacion

            Dim _Fecha_Tope_Rotacion As Date = FormatDateTime(DateAdd(DateInterval.Day, -_Dias_Advertir_Rotacion, FechaDelServidor), DateFormat.ShortDate)
            Dim _Fecha_Rotacion As String = Format(_Fecha_Tope_Rotacion, "yyyMMdd")

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'If _Advertir_Rotacion Then
            ' Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 1" & vbCrLf & _
            '               "Where Fecha_Ultima_Ejecucion < '" & _Fecha_Rotacion & "'"
            '_Sql.Ej_consulta_IDU(Consulta_sql)
            'End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud1_Negativo = 0,Stock_Fisico_Ud2_Negativo = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud1 = 0,Stock_Fisico_Ud1_Negativo = 1 Where Stock_Fisico_Ud1 < 0
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud2 = 0,Stock_Fisico_Ud2_Negativo = 1 Where Stock_Fisico_Ud2 < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                               "StockUd" & _Ud & " = Stock_Fisico_Ud" & _Ud & "-(" & _Tiempo_Reposicion & " * RotCalculo)" & vbCrLf &
                               "Where Stock_Fisico_Ud" & _Ud & " > 0"
            Else
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                               "StockUd" & _Ud & " = Stock_Fisico_Ud" & _Ud & "-(" & _Tiempo_Reposicion_Mensual & " * RotCalculo)" & vbCrLf &
                               "Where Stock_Fisico_Ud" & _Ud & " > 0"
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " StockUd1 = 0 Where StockUd1 < 0
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " StockUd2 = 0 Where StockUd2 < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotCalculo > 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then Ceiling(Round(Stock_Fisico_Ud" & _Ud & " / RotCalculo,0)) Else 0 End" & vbCrLf &
                               "When RotCalculo <= 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then " & _Input_Dias_a_Abastecer & " Else 0 End" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"

            Else

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotCalculo > 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then Round(Stock_Fisico_Ud" & _Ud & " / RotCalculo,1) Else 0 End" & vbCrLf &
                               "When RotCalculo <= 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then " & _Input_Dias_a_Abastecer & " Else 0 End" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"

            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Tpo_Reposicion As String

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then
                _Tpo_Reposicion = _Tiempo_Reposicion & " * " & _Campo_CalUd_Diario
            Else
                _Tpo_Reposicion = _Tiempo_Reposicion_Mensual & " * " & _Campo_CalUd_Mensual
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Tiempo_Reposicion =" & _Tpo_Reposicion & _Ud
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = Ceiling(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = Round(" & _Tpo_Reposicion & "2,3)" & vbCrLf &
                               "Where 1 > 0"

            Else

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = Ceiling(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = Round(" & _Tpo_Reposicion & "2,3)" & vbCrLf &
                               "Where 1 > 0"
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd1_Rd = Stock_Fisico_Ud1 - Stock_CriticoUd1_Rd," & vbCrLf &
                           "Stock_ProyectadoUd2_Rd = Stock_Fisico_Ud2 - Stock_CriticoUd2_Rd"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd1_Rd = 0 Where Stock_ProyectadoUd1_Rd < 0" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd2_Rd = 0 Where Stock_ProyectadoUd2_Rd < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                           "Stock_CriticoUd" & _Ud & "_Rd = (Select Top 1 Stock_CriticoUd" & _Ud & "_Rd" & Space(1) &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z2 Where Z1.Codigo_Nodo_Madre = Z2.Codigo_Nodo_Madre)" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'Dim _Dias_Proyeccion_Venta = _Dias_Abastecer

            'If _Chk_Sabado Then _Dias_Proyeccion_Venta += _Sabados
            'If _Chk_Domingo Then _Dias_Proyeccion_Venta += _Domingos

            '_Dias_Proyeccion_Venta = _Dias_Prom_Mensual

            Dim _DCS = 3 ' Decimales, cantidad sugerida

            If _Ud = 1 Then _DCS = 0

            If _Chk_Restar_Stok_Bodega Then

                If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round(((RotCalculo*" & _Dias_Abastecer & ") * " & _Porc_Crecimiento & ") - StockUd" & _Ud & "," & _DCS & ")" & vbCrLf &
                                   "Where 1 > 0"
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round(((RotCalculo*" & _Meses_Abastecer & ") * " & _Porc_Crecimiento & ") - StockUd" & _Ud & "," & _DCS & ")" & vbCrLf &
                                   "Where 1 > 0"
                End If

            Else

                If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round((" & _Dias_Abastecer & " * RotCalculo) * " & _Porc_Crecimiento & "," & _DCS & ")" & vbCrLf &
                                   "Where 1 > 0"
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round((" & _Meses_Abastecer & " * (RotCalculo)) * " & _Porc_Crecimiento & "," & _DCS & ")" & vbCrLf &
                                   "Where 1 > 0"
                End If

            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Filtro_Productos = String.Empty

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd1_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd1_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd2_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd2_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd1 = 0 Where 1 > 0 " & _Filtro_Productos & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd2 = 0 Where 1 > 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set CantSugeridaTot = 0 Where 1 > 0 And CantSugeridaTot < 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set" & Space(1) &
                           "Con_Stock_CriticoUd1 = Case When (Stock_Fisico_Ud1 - Stock_CriticoUd1_Rd) <= 0 Then 1 Else 0 End," & vbCrLf &
                           "Con_Stock_CriticoUd2 = Case When (Stock_Fisico_Ud2 - Stock_CriticoUd2_Rd) <= 0 Then 1 Else 0 End" & vbCrLf &
                           "Where 1 > 0" & vbCrLf & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Filtro_Es_Agrupador As String

            If _Proceso_Automatico_Ejecutado Then
                _Filtro_Es_Agrupador = "And Es_Agrupador = 1"
            Else
                _Filtro_Es_Agrupador = String.Empty
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
                           "Where CantSugeridaTot > 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                           "Where CantSugeridaTot <= 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Sb_Actulizar_Refleo_Baja_Rotacion()

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Familia = 0" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                           "Sospecha_Familia = (Select Count(*) From " & _Nombre_Tbl_Paso_Informe & " Z2" & Space(1) &
                           "Where Z2.Codigo = Z1.Codigo And Z2.Es_Agrupador = 0 )" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1" & vbCrLf &
                           "Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud1 = -0.1 Where Stock_Fisico_Ud1_Negativo = 1
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud2 = -0.1 Where Stock_Fisico_Ud2_Negativo = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally

        End Try

    End Sub

    Sub Sb_Actualizar_Rotacion_Respaldo(_Codigo As String, _Actualizar_Dias_Stock_En_Bodega As Boolean)

        Try

            Dim _Fecha_Servidor As Date = FechaDelServidor()

            Dim _Filtro_Bodega As String

            If _Filtro_Bodegas_Todas Then
                _Filtro_Bodega = String.Empty
            Else
                _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
                _Filtro_Bodega = "And Empresa+Sucursal+Bodega In " & _Filtro_Bodega
            End If


            Dim _UsarSabado = CInt(_Chk_Sabado) * -1
            Dim _UsarDomingo = CInt(_Chk_Domingo) * -1

            Dim _Dias_Abastecer As Integer ' = Input_Dias_a_Abastecer.Value
            Dim _Meses_Abastecer As Double ' = Input_Dias_a_Abastecer.Value

            Dim _Tiempo_Reposicion = _Input_Tiempo_Reposicion
            Dim _Tiempo_Reposicion_Mensual As Double

            Dim _Porc_Cre = 1 + (_Input_Porc_Crecimiento / 100) 'Input_Porc_Crecimiento.Value 
            Dim _Porc_Crecimiento As String = De_Num_a_Tx_01(_Porc_Cre)

            Dim _Dias_Prom_Mensual As Double
            Dim _DM_Proyec_Tr, _DM_Abastecer As Double

            Dim _Dias_Habiles = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                             Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Habiles)
            Dim _Dias_Sabado = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                                Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Sabado)
            Dim _Dias_Domingo = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year),
                                                Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Domingo)

            _Dias_Prom_Mensual = _Dias_Habiles

            If _Chk_Sabado Then _Dias_Prom_Mensual += _Dias_Sabado
            If _Chk_Domingo Then _Dias_Prom_Mensual += _Dias_Domingo

            _Dias_Prom_Mensual = Math.Round(_Dias_Prom_Mensual / 12, 0)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then '_Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Meses Then 'Cmb_Proyeccion_Tiempo_Reposicion.Text = "meses" Then
                _DM_Proyec_Tr = 1
            Else
                _DM_Proyec_Tr = 365 / 12
            End If

            If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then '_Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Meses Then
                _DM_Abastecer = 1
            Else
                _DM_Abastecer = Math.Round(365 / 12, 5)
            End If

            _Tiempo_Reposicion = _Input_Tiempo_Reposicion * _DM_Proyec_Tr 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue
            _Dias_Abastecer = _Input_Dias_a_Abastecer * _DM_Abastecer 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue ' + _Tiempo_Reposicion

            _Meses_Abastecer = _Input_Dias_a_Abastecer 'Math.Round(_Dias_Abastecer / _Dias_Prom_Mensual, 1) 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue '_Dias_Proyeccion
            _Tiempo_Reposicion_Mensual = _Input_Tiempo_Reposicion 'Math.Round(_Tiempo_Reposicion / _Dias_Prom_Mensual, 1) 'Cmb_Proyeccion_Tiempo_Reposicion.SelectedValue

            Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, _Fecha_Servidor)

            _Dias_Abastecer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Habiles)

            Dim _Sabados As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Sabado)
            Dim _Domingos As Integer = Fx_Cuenta_Dias(_Fecha_Servidor, _Fecha_Fin, Opcion_Dias.Domingo)
            Dim _RestarStock = CInt(_Chk_Restar_Stok_Bodega) * -1

            Dim _Ud

            If _Rdb_Ud1_Compra Then : _Ud = 1 : Else : _Ud = 2 : End If

            If _Chk_Sabado Then _Dias_Abastecer += _Sabados
            If _Chk_Domingo Then _Dias_Abastecer += _Domingos


            Dim _Dias_Proyeccion_Venta = _Dias_Abastecer

            If _Chk_Sabado Then _Dias_Proyeccion_Venta += _Sabados
            If _Chk_Domingo Then _Dias_Proyeccion_Venta += _Domingos

            _Dias_Proyeccion_Venta = _Dias_Prom_Mensual

            ' ACTUALIZA VELOCIDAD DE SALIDAD, DIAS DE STOCK EN BODEGA PARA LOS PRODUCTOS

            If _Rdb_RotDias Then

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                               "RotMensualUd1 = Ceiling(RotDiariaUd1*" & _Dias_Proyeccion_Venta & ")," & vbCrLf &
                               "RotMensualUd2 = Ceiling(RotDiariaUd2*" & _Dias_Proyeccion_Venta & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            If _Rdb_RotMeses Then

                ' Debo poner un validador que permita preguntar si quiere redondear hacia arriba o no Sierralta lo usa, La Colchaguina No
                'Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                '               "RotMensualUd1 = Ceiling(RotMensualUd1)," & vbCrLf &
                '               "RotMensualUd2 = Ceiling(RotMensualUd2)"
                '_Sql.Ej_consulta_IDU(Consulta_sql)

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                               "RotDiariaUd1 = Round(RotMensualUd1/" & _Dias_Prom_Mensual & ",3)," & vbCrLf &
                               "RotDiariaUd2 = Round(RotMensualUd2/" & _Dias_Prom_Mensual & ",3)"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotMensualUd1_Prod = Ceiling(RotMensualUd1_Prod)," & vbCrLf &
                           "RotMensualUd2_Prod = Ceiling(RotMensualUd2_Prod)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set " & vbCrLf &
                           "RotDiariaUd1_Prod = Round(RotMensualUd1_Prod/" & _Dias_Prom_Mensual & ",3)," & vbCrLf &
                           "RotDiariaUd2_Prod = Round(RotMensualUd2_Prod/" & _Dias_Prom_Mensual & ",3)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            '----------------------------------------------------------------------------------------


            Dim _Advertir_Rotacion As Boolean = _Chk_Advertir_Rotacion '_RowParametros.Item("Chk_Advertir_Rotacion")
            Dim _Dias_Advertir_Rotacion As Integer = _Input_Dias_Advertencia_Rotacion '_RowParametros.Item("Input_Dias_Advertencia_Rotacion")

            Dim _Fecha_Tope_Rotacion As Date = FormatDateTime(DateAdd(DateInterval.Day, -_Dias_Advertir_Rotacion, FechaDelServidor), DateFormat.ShortDate)
            Dim _Fecha_Rotacion As String = Format(_Fecha_Tope_Rotacion, "yyyMMdd")

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'If _Advertir_Rotacion Then
            ' Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Advierte_Rotacion = 1" & vbCrLf & _
            '               "Where Fecha_Ultima_Ejecucion < '" & _Fecha_Rotacion & "'"
            '_Sql.Ej_consulta_IDU(Consulta_sql)
            'End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud1 = 0,Stock_Fisico_Ud1_Negativo = 1 Where Stock_Fisico_Ud1 < 0
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud2 = 0,Stock_Fisico_Ud2_Negativo = 1 Where Stock_Fisico_Ud2 < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then '_Proyeccion_Metodo_Abastecer = _Proyeccion_Tiempo_Reposicion.Dias Then '_Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then ' Cmb_Proyeccion_Metodo_Abastecer.SelectedValue = 1 Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                               "StockUd" & _Ud & " = Stock_Fisico_Ud" & _Ud & "-(" & _Tiempo_Reposicion & " * RotDiariaUd" & _Ud & ")" & vbCrLf &
                               "Where Stock_Fisico_Ud" & _Ud & " > 0"
            Else
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                               "StockUd" & _Ud & " = Stock_Fisico_Ud" & _Ud & "-(" & _Tiempo_Reposicion_Mensual & " * RotMensualUd" & _Ud & ")" & vbCrLf &
                               "Where Stock_Fisico_Ud" & _Ud & " > 0"
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " StockUd1 = 0 Where StockUd1 < 0
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " StockUd2 = 0 Where StockUd2 < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)


            If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then ' Cmb_Proyeccion_Metodo_Abastecer.SelectedValue = 1 Then

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotDiariaUd" & _Ud & " > 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then CEILING(ROUND(Stock_Fisico_Ud" & _Ud & " / RotDiariaUd" & _Ud & ",0)) else 0 end" & vbCrLf &
                               "When RotDiariaUd" & _Ud & " <= 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then " & _Input_Dias_a_Abastecer & " else 0 end" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"

            Else

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set TStock = Case" & vbCrLf &
                               "When RotMensualUd" & _Ud & " > 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then ROUND(Stock_Fisico_Ud" & _Ud & "/RotMensualUd" & _Ud & ",1) else 0 end" & vbCrLf &
                               "When RotMensualUd" & _Ud & " <= 0 Then Case When Stock_Fisico_Ud" & _Ud & " > 0 Then " & _Input_Dias_a_Abastecer & " else 0 end" & vbCrLf &
                               "End" & vbCrLf &
                               "Where(1 > 0)"

            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Dim _Tpo_Reposicion As String

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then
                _Tpo_Reposicion = _Tiempo_Reposicion & " * RotDiariaUd"
            Else
                _Tpo_Reposicion = _Tiempo_Reposicion_Mensual & " * RotMensualUd"
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Tiempo_Reposicion =" & _Tpo_Reposicion & _Ud
            _Sql.Ej_consulta_IDU(Consulta_sql)

            If _Proyeccion_Tiempo_Reposicion = Enum_Proyeccion.Dias Then
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = Ceiling(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = Ceiling(Round(" & _Tpo_Reposicion & "2,0))" & vbCrLf &
                               "Where 1 > 0"
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = Ceiling(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = Round(" & _Tpo_Reposicion & "2,3)" & vbCrLf &
                               "Where 1 > 0"

            Else
                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = CEILING(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = CEILING(Round(" & _Tpo_Reposicion & "2,0))" & vbCrLf &
                               "Where 1 > 0"

                Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                               "Set Stock_CriticoUd1_Rd = CEILING(Round(" & _Tpo_Reposicion & "1,0))," & vbCrLf &
                               "Stock_CriticoUd2_Rd = Round(" & _Tpo_Reposicion & "2,3)" & vbCrLf &
                               "Where 1 > 0"
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd1_Rd = Stock_Fisico_Ud1 - Stock_CriticoUd1_Rd," & vbCrLf &
                           "Stock_ProyectadoUd2_Rd = Stock_Fisico_Ud2 - Stock_CriticoUd2_Rd"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd1_Rd = 0 Where Stock_ProyectadoUd1_Rd < 0" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) &
                           "Stock_ProyectadoUd2_Rd = 0 Where Stock_ProyectadoUd2_Rd < 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                           "Stock_CriticoUd" & _Ud & "_Rd = (Select Top 1 Stock_CriticoUd" & _Ud & "_Rd" & Space(1) &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z2 Where Z1.Codigo_Nodo_Madre = Z2.Codigo_Nodo_Madre)" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            'Dim _Dias_Proyeccion_Venta = _Dias_Abastecer

            'If _Chk_Sabado Then _Dias_Proyeccion_Venta += _Sabados
            'If _Chk_Domingo Then _Dias_Proyeccion_Venta += _Domingos

            '_Dias_Proyeccion_Venta = _Dias_Prom_Mensual

            If _Chk_Restar_Stok_Bodega Then

                If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round(((RotDiariaUd" & _Ud & "*" & _Dias_Abastecer & ") * " & _Porc_Crecimiento & ") - StockUd" & _Ud & ",0)" & vbCrLf &
                                   "Where 1 > 0"
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round(((RotMensualUd" & _Ud & "*" & _Meses_Abastecer & ") * " & _Porc_Crecimiento & ") - StockUd" & _Ud & ",0)" & vbCrLf &
                                   "Where 1 > 0"
                End If

            Else

                If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round((" & _Dias_Abastecer & " * RotDiariaUd" & _Ud & ") * " & _Porc_Crecimiento & ",0)" & vbCrLf &
                                   "Where 1 > 0"
                Else
                    Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " set" & vbCrLf &
                                   "CantSugeridaTot = Round((" & _Meses_Abastecer & " * (RotMensualUd" & _Ud & ")) * " & _Porc_Crecimiento & ",0)" & vbCrLf &
                                   "Where 1 > 0"
                End If
            End If
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Filtro_Productos = String.Empty

            Consulta_sql = "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd1_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd1_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Stock_CriticoUd2_Rd = 1" & vbCrLf &
                           "Where 1 > 0 And Stock_CriticoUd2_Rd = 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd1 = 0 Where 1 > 0 " & _Filtro_Productos & vbCrLf &
                           "UPDATE " & _Nombre_Tbl_Paso_Informe & " set Con_Stock_CriticoUd2 = 0 Where 1 > 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set CantSugeridaTot = 0 Where 1 > 0 And CantSugeridaTot < 0 " & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)


            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                           "Set" & Space(1) &
                           "Con_Stock_CriticoUd1 = Case When (Stock_Fisico_Ud1 - Stock_CriticoUd1_Rd) <= 0 Then 1 Else 0 End," & vbCrLf &
                           "Con_Stock_CriticoUd2 = Case When (Stock_Fisico_Ud2 - Stock_CriticoUd2_Rd) <= 0 Then 1 Else 0 End" & vbCrLf &
                           "Where 1 > 0" & vbCrLf & _Filtro_Productos
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Dim _Filtro_Es_Agrupador As String

            If _Proceso_Automatico_Ejecutado Then
                _Filtro_Es_Agrupador = "And Es_Agrupador = 1"
            Else
                _Filtro_Es_Agrupador = String.Empty
            End If

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
                           "Where CantSugeridaTot > 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                           "Where CantSugeridaTot <= 0.45 And Comprar_Igual = 0" & vbCrLf &
                           _Filtro_Es_Agrupador
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Sb_Actulizar_Refleo_Baja_Rotacion()

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Familia = 0" & vbCrLf &
                           "Update " & _Nombre_Tbl_Paso_Informe & " Set" & vbCrLf &
                           "Sospecha_Familia = (Select COUNT(*) From " & _Nombre_Tbl_Paso_Informe & " Z2" & Space(1) &
                           "Where Z2.Codigo = Z1.Codigo And Z2.Es_Agrupador = 0 )" & vbCrLf &
                           "From " & _Nombre_Tbl_Paso_Informe & " Z1" & vbCrLf &
                           "Where Es_Agrupador = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud1 = -0.1 Where Stock_Fisico_Ud1_Negativo = 1
                            Update " & _Nombre_Tbl_Paso_Informe & " Set" & Space(1) & " Stock_Fisico_Ud2 = -0.1 Where Stock_Fisico_Ud2_Negativo = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message)
        Finally

        End Try

    End Sub

    Function Fx_Dias_Proyeccion() As Integer

        Dim _UsarSabado = CInt(_Chk_Sabado) * -1
        Dim _UsarDomingo = CInt(_Chk_Domingo) * -1
        Dim _Dias_Abastecer = _Input_Dias_a_Abastecer
        Dim _Tiempo_Reposicion = _Input_Tiempo_Reposicion
        Dim _Porc_Crecimiento = 1 + (_Input_Porc_Crecimiento / 100) 'Input_Porc_Crecimiento.Value 

        Dim _Fecha_Fin = DateAdd(DateInterval.Day, _Dias_Abastecer, FechaDelServidor)

        _Dias_Abastecer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Habiles)

        Dim _Sabados As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Sabado)
        Dim _Domingos As Integer = Fx_Cuenta_Dias(FechaDelServidor, _Fecha_Fin, Opcion_Dias.Domingo)

        Dim _Dias_Proyeccion '= Input_Dias_a_Abastecer.Value * Cmb_Proyeccion_Metodo_Abastecer.SelectedValue + _Tiempo_Reposicion

        Dim _Campos As Integer

        Select Case _Proyeccion_Metodo_Abastecer '= Enum_Proyeccion.Dias  '_Proyeccion_Metodo_Abastecer '_Cmb_Proyeccion_Metodo_Abastece
            Case Enum_Proyeccion.Dias
                _Dias_Proyeccion = 1 : _Campos = 60 '_Dias_Abastecer
            Case Enum_Proyeccion.Semanas
                _Dias_Proyeccion = 5 : _Campos = 20
            Case Enum_Proyeccion.Meses
                _Dias_Proyeccion = 22 : _Campos = 12
        End Select

        If _Chk_Sabado Then
            _Dias_Abastecer += _Sabados
            Select Case _Proyeccion_Metodo_Abastecer ' '= Enum_Proyeccion.Dias  '_Proyeccion_Metodo_Abastecer 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue
                Case Enum_Proyeccion.Semanas
                    _Dias_Proyeccion += 1
                Case Enum_Proyeccion.Meses
                    _Dias_Proyeccion += 2
            End Select
        End If

        If _Chk_Domingo Then
            _Dias_Abastecer += _Domingos
            Select Case _Proyeccion_Metodo_Abastecer '= Enum_Proyeccion.Dias  '_Proyeccion_Metodo_Abastecer 'Cmb_Proyeccion_Metodo_Abastecer.SelectedValue
                Case Enum_Proyeccion.Semanas
                    _Dias_Proyeccion += 1
                Case Enum_Proyeccion.Meses
                    _Dias_Proyeccion += 2
            End Select
        End If

        Return _Dias_Abastecer '_Dias_Proyeccion

    End Function

    Sub Sb_Actulizar_Refleo_Baja_Rotacion()

        Dim _Ud

        If _Rdb_Ud1_Compra Then : _Ud = 1 : Else : _Ud = 2 : End If

        Dim _Dias_Habiles = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year), _
                                             Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Habiles)
        Dim _Dias_Sabado = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year), _
                                            Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Sabado)
        Dim _Dias_Domingo = Fx_Cuenta_Dias(Convert.ToDateTime("01/01/" & FechaDelServidor.Year), _
                                            Convert.ToDateTime("31/12/" & FechaDelServidor.Year), Opcion_Dias.Domingo)


        Dim _Dias = _Dias_Habiles
        Dim _Filtro_Dias As String

        If _Chk_Sabado Then
            _Dias += _Dias_Sabado
            _Filtro_Dias += "+Dias_Existencia_Sabados"
        End If

        If _Chk_Domingo Then
            _Dias += _Dias_Domingo
            _Filtro_Dias += "+Dias_Existencia_Domingos"
        End If

        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 0,Sospecha_Baja_Rotacion = 0" &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 1" & vbCrLf &
                       "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
                       "And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year = 1 And Comprar_Igual = 0" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
                       "Where CantSugeridaTot > 0.45" & Space(1) &
                       "And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year < 5 And Refleo = 0" &
                       vbCrLf &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
                       "Where CantSugeridaTot < 0.45 And ((FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year between 2 And 5 OR RotMensualUd1 < 0.5)"
        _Sql.Ej_consulta_IDU(Consulta_sql)


        Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
                       "And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year < 1 And Comprar_Igual = 0" &
                       vbCrLf &
                       vbCrLf &
                       "--Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "--Where CantSugeridaTot > 0.5" & Space(1) &
                       "--And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year <= 5 And Refleo = 0 And Comprar_Igual = 0" &
                       vbCrLf &
                       "--Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
                       "--Where CantSugeridaTot <  0.45 And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year between 2 And 5 And Comprar_Igual = 0" &
                       vbCrLf &
                       "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
                       "Where Sospecha_Baja_Rotacion = 0 And CantSugeridaTot > 0 And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year > 5 And Comprar_Igual = 0"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _GDIodt As Boolean = False

        If _GDIodt Then

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 0,Sospecha_Baja_Rotacion = 0" &
               vbCrLf &
               "Update " & _Nombre_Tbl_Paso_Informe & " Set Refleo = 1" & vbCrLf &
               "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
               "And GDIodt_Ult_Year-GRIodt_Ult_Year = 1 And Comprar_Igual = 0" &
               vbCrLf &
               vbCrLf &
               "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
               "Where CantSugeridaTot > 0.45" & Space(1) &
               "And GDIodt_Ult_Year-GRIodt_Ult_Year < 5 And Refleo = 0" &
               vbCrLf &
               vbCrLf &
               "Update " & _Nombre_Tbl_Paso_Informe & " Set Sospecha_Baja_Rotacion = 1" & vbCrLf &
               "Where CantSugeridaTot < 0.45 And (GDIodt_Ult_Year-GRIodt_Ult_Year between 2 And 5 OR RotMensualUd1 < 0.5)"
            _Sql.Ej_consulta_IDU(Consulta_sql)

            Consulta_sql = "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
               "Where (Dias_Existencia_Habiles" & _Filtro_Dias & ") <=" & _Dias & Space(1) &
               "And GDIodt_Ult_Year-GRIodt_Ult_Year < 1 And Comprar_Igual = 0" &
               vbCrLf &
               vbCrLf &
               "--Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
               "--Where CantSugeridaTot > 0.5" & Space(1) &
               "--And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year <= 5 And Refleo = 0 And Comprar_Igual = 0" &
               vbCrLf &
               "--Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 0" & vbCrLf &
               "--Where CantSugeridaTot <  0.45 And (FCV_Ult_Year+BLV_Ult_Year)-NCV_Ult_Year between 2 And 5 And Comprar_Igual = 0" &
               vbCrLf &
               "Update " & _Nombre_Tbl_Paso_Informe & " Set Comprar = 1" & vbCrLf &
               "Where Sospecha_Baja_Rotacion = 0 And CantSugeridaTot > 0 And GDIodt_Ult_Year-GRIodt_Ult_Year > 5 And Comprar_Igual = 0"
            _Sql.Ej_consulta_IDU(Consulta_sql)


        End If


    End Sub

    Sub Sb_Actualizar_Stock()

        Dim _Filtro_Bodega As String

        If _Filtro_Bodegas_Todas Then
            _Filtro_Bodega = String.Empty
        Else
            _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
            _Filtro_Bodega = "And EMPRESA+KOSU+KOBO In " & _Filtro_Bodega
        End If

        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Inserta_stock_por_producto
        Consulta_sql = Replace(Consulta_sql, "#TablaPaso#", _Nombre_Tbl_Paso_Informe)
        Consulta_sql = Replace(Consulta_sql, "#CodFuncionario#", FUNCIONARIO)
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Bodega#", _Filtro_Bodega)
        Consulta_sql = Replace(Consulta_sql, "Zw_Prod_Asociacion", _Global_BaseBk & "Zw_Prod_Asociacion")

        If Chk_SumerStockExternoAlFisico Then

            Dim _StockBodExterna As String

            _Filtro_Bodega = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")

            _StockBodExterna = "Update #Paso Set StfiBodExt1 = Isnull((Select SUM(Ztk.StfiBodExt1)" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Stock Ztk" & vbCrLf &
                               "Where #Paso.KOPR = Ztk.Codigo And Empresa+Sucursal+Bodega In " & _Filtro_Bodega & "),0)" & vbCrLf &
                               "Update #Paso Set StfiBodExt2 = Isnull((Select SUM(Ztk.StfiBodExt2)" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Stock Ztk" & vbCrLf &
                               "Where #Paso.KOPR = Ztk.Codigo And Empresa+Sucursal+Bodega In " & _Filtro_Bodega & "),0)"

            _StockBodExterna = "Update #Paso Set STFI1 = STFI1 + Isnull((Select SUM(Ztk.StfiBodExt1)" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Stock Ztk" & vbCrLf &
                               "Where #Paso.KOPR = Ztk.Codigo And Empresa+Sucursal+Bodega In " & _Filtro_Bodega & "),0)" & vbCrLf &
                               "Update #Paso Set STFI2 = STFI2 + Isnull((Select SUM(Ztk.StfiBodExt2)" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Prod_Stock Ztk" & vbCrLf &
                               "Where #Paso.KOPR = Ztk.Codigo And Empresa+Sucursal+Bodega In " & _Filtro_Bodega & "),0)"

            Consulta_sql = Replace(Consulta_sql, "--InsertarStockFisicoDeBodegaExterna", _StockBodExterna)

        End If

        _Sql.Ej_consulta_IDU(Consulta_sql)

    End Sub

    Sub Sb_Info_Calculo_Rotacion(ByVal _Me As Form, ByVal _Codigo As String, ByVal _Descripcion As String, _Ud As Integer)

        Dim _Filtro_Bodegas As String = Generar_Filtro_IN(_Tbl_Filtro_Bodegas, "Chk", "Codigo", False, True, "'")
        Dim _Es_Asociador = CInt(_Rdb_Agrupar_x_Asociados) * -1


        Consulta_sql = "Select Top 1 * From " & _Nombre_Tbl_Paso_Informe & vbCrLf &
                       "Where Codigo = '" & _Codigo & "'" & Space(1) &
                       "--And Es_Agrupador = " & _Es_Asociador
        Dim _Row_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Codigo_Nodo_Madre = _Row_Producto.Item("Codigo_Nodo_Madre")
        Dim _Descripcion_Madre = _Row_Producto.Item("Descripcion_Madre")
        Dim _Unidad As String = _Row_Producto.Item("UD" & _Ud)
        Dim _Ud1 As String = _Row_Producto.Item("UD1")
        Dim _Ud2 As String = _Row_Producto.Item("UD2")

        Dim _Fecha_Inicio = _Row_Producto.Item("Fecha_Inicio")
        Dim _Fecha_Fin = _Row_Producto.Item("Fecha_Fin")

        Dim _Qty_Vendidos = _Row_Producto.Item("SumTotalQtyUd" & _Ud)
        Dim _Dias_Calculo '= _Row_Producto.Item("Dias_Calculo")
        Dim _RotDiariaUd1 = _Row_Producto.Item("RotDiariaUd" & _Ud)
        Dim _RotMensualUd1 = _Row_Producto.Item("RotMensualUd" & _Ud)

        Dim _PromDia_Ud = _Row_Producto.Item("Promedio_Ud" & _Ud)
        Dim _PromMes_Ud = _Row_Producto.Item("Promedio_MensualUd" & _Ud)
        Dim _Rtu = _Row_Producto.Item("Rtu")

        Dim _Dias_Existencia_Habiles = _Row_Producto.Item("Dias_Existencia_Habiles")
        Dim _Dias_Existencia_Sabados = _Row_Producto.Item("Dias_Existencia_Sabados")
        Dim _Dias_Existencia_Domingos = _Row_Producto.Item("Dias_Existencia_Domingos")

        Dim _Dias_Habiles = Fx_Cuenta_Dias(_Fecha_Inicio, _Fecha_Fin, Opcion_Dias.Habiles)
        Dim _Dias_Sabados = Fx_Cuenta_Dias(_Fecha_Inicio, _Fecha_Fin, Opcion_Dias.Sabado)
        Dim _Dias_Domingos = Fx_Cuenta_Dias(_Fecha_Inicio, _Fecha_Fin, Opcion_Dias.Domingo)
        Dim _Total_Dias = _Dias_Habiles + _Dias_Sabados + _Dias_Domingos



        Dim _Dias_Quiebre_Habiles = _Dias_Habiles - _Dias_Existencia_Habiles
        Dim _Dias_Quiebre_Sabados = _Dias_Sabados - _Dias_Existencia_Sabados
        Dim _Dias_Quiebre_Domingos = _Dias_Domingos - _Dias_Existencia_Domingos


        Dim _Msg_Rotacion As String

        If _Proyeccion_Metodo_Abastecer = Enum_Proyeccion.Dias Then
            _Msg_Rotacion = "Rotación diaria [" & _Unidad & "]: " & FormatNumber(_RotDiariaUd1, 2)
        Else
            _Msg_Rotacion = "Rotación mensual [" & _Unidad & "]: " & FormatNumber(_RotMensualUd1, 2)
        End If

        _Msg_Rotacion = "Rotación diaria [" & _Unidad & "]: " & FormatNumber(_RotDiariaUd1, 3) & vbCrLf &
                        "Rotación mensual [" & _Unidad & "]: " & FormatNumber(_RotMensualUd1, 3) & vbCrLf & vbCrLf &
                        "Vta. Promedio diaria [" & _Unidad & "]: " & FormatNumber(_PromDia_Ud, 3) & vbCrLf &
                        "Vta. Promedio mensual [" & _Unidad & "]: " & FormatNumber(_PromMes_Ud, 3)

        Dim _Mensaje As String = "Fecha estudio rotación, desde: " & FormatDateTime(_Fecha_Inicio, DateFormat.ShortDate) & ", hasta: " & FormatDateTime(_Fecha_Fin, DateFormat.ShortDate) & vbCrLf & vbCrLf &
                                 "Días de existencia hábiles: " & FormatNumber(_Dias_Existencia_Habiles, 0) & ", sábados: " & FormatNumber(_Dias_Existencia_Sabados, 0) & ", domingos: " & FormatNumber(_Dias_Existencia_Domingos, 0) & vbCrLf & vbCrLf &
                                 "Cantidad de ventas en el periodo: " & FormatNumber(_Qty_Vendidos, 0) & ", Días calculo: " & FormatNumber(_Dias_Calculo, 0) & vbCrLf &
                                 vbCrLf &
                                 _Msg_Rotacion & vbCrLf &
                                 vbCrLf &
                                 "Quiebres de stock días hábiles: " & FormatNumber(_Dias_Quiebre_Habiles, 0) &
                                 ", Sábado: " & FormatNumber(_Dias_Quiebre_Sabados, 0) &
                                 ", Domingo: " & FormatNumber(_Dias_Quiebre_Domingos, 0) & vbCrLf & vbCrLf


        _Mensaje = vbCrLf & "Fecha estudio rotación, desde: " & FormatDateTime(_Fecha_Inicio, DateFormat.ShortDate) & ", hasta: " & FormatDateTime(_Fecha_Fin, DateFormat.ShortDate) & vbCrLf & vbCrLf &
                   _Msg_Rotacion & vbCrLf & vbCrLf &
                   "Cód. agrupa: " & _Codigo_Nodo_Madre & vbCrLf & vbCrLf &
                   _Descripcion_Madre & vbCrLf & vbCrLf


        Dim _Info As New TaskDialogInfo("Información de rotación código: " & _Codigo,
                          eTaskDialogIcon.Information2,
                          _Descripcion,
                          _Mensaje,
                          eTaskDialogButton.Ok _
                          , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)

        TaskDialog.Show(_Info)


    End Sub

End Class
