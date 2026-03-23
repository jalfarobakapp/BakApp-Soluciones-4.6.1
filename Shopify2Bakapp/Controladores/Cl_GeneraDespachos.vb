Imports System.Data.SqlClient
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

Public Class Cl_GeneraDespachos

    Dim _SqlRandom As Class_SQL
    Dim Consulta_sql As String

    Public Property ConfiguracionLocal As Configuracion

    'Public Sub New()
    '    ' Ahora solo necesitamos conectarnos a la base de datos de Random/Bakapp
    '    _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
    'End Sub

    ''' <summary>
    ''' Busca NVVs de Shopify/B2B y las inyecta a las tablas de despacho de Bakapp.
    ''' </summary>
    'Sub Sb_Procesar_Despachos_ECommerce(Txt_Log As Object, _Top As Integer)

    '    If _Top = 0 Then _Top = 100

    '    ' -----------------------------------------------------------------------------------------
    '    ' 1. BUSCAR NOTAS DE VENTA (NVV) DEL E-COMMERCE QUE NO TENGAN DESPACHO ASIGNADO
    '    ' ¡IMPORTANTE!: Ajusta el filtro "KOFUDO = 'SHP'" por el vendedor o identificador 
    '    ' que use tu E-commerce (Shopify/B2B) al crear la NVV en Random.
    '    ' -----------------------------------------------------------------------------------------
    '    Consulta_sql = "SELECT TOP " & _Top & " IDMAEEDO, TIDO, NUDO, ENDO, SUENDO, FEEMDO, OBSERVACIONES " & vbCrLf &
    '                   "FROM MAEEDO " & vbCrLf &
    '                   "WHERE TIDO = 'NVV' AND EMPRESA = '" & ConfiguracionLocal.BodegaFacturacion.Empresa & "' " & vbCrLf &
    '                   "AND KOFUDO = 'SHP' " & vbCrLf & ' <-- CAMBIAR POR TU VENDEDOR DE SHOPIFY
    '                   "AND IDMAEEDO NOT IN (SELECT Idmaeedo_Doc FROM " & _Global_BaseBk & "Zw_Despachos_Doc)" ' Valida que no exista ya en despacho

    '    Dim _Tbl_Pendientes As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

    '    If Not CBool(_Tbl_Pendientes.Rows.Count) Then
    '        ' No hay nada nuevo que despachar
    '        Return
    '    End If

    '    Sb_AddToLog("Demonio Despachos", "Se encontraron " & _Tbl_Pendientes.Rows.Count & " NVVs pendientes.", Txt_Log)

    '    For Each _Fila_NVV As DataRow In _Tbl_Pendientes.Rows

    '        Dim _Idmaeedo As Integer = _Fila_NVV.Item("IDMAEEDO")
    '        Dim _Nudo As String = _Fila_NVV.Item("NUDO")

    '        ' Lógica para determinar si es Retiro o Domicilio (Ej: leyendo un tag en observaciones)
    '        Dim _Observaciones As String = _Fila_NVV.Item("OBSERVACIONES").ToString().ToUpper()
    '        Dim _TipoDespacho As String = "DOMICILIO" ' Por defecto

    '        If _Observaciones.Contains("RETIRO") Then
    '            _TipoDespacho = "RETIRO"
    '        End If

    '        ' Llamamos a la función que inserta los datos en las tablas de despacho
    '        Dim _Mensaje As Mensajes = Fx_Crear_Orden_Despacho(_Fila_NVV, _TipoDespacho)

    '        If _Mensaje.EsCorrecto Then
    '            Sb_AddToLog("Demonio Despachos", "Despacho creado OK para NVV: " & _Nudo, Txt_Log)
    '        Else
    '            Sb_AddToLog("Demonio Despachos", "Error en NVV " & _Nudo & ": " & _Mensaje.Mensaje, Txt_Log)
    '        End If

    '    Next

    'End Sub

    ''' <summary>
    ''' Graba transaccionalmente en el encabezado y detalle de Despachos Bakapp.
    ''' </summary>
    'Private Function Fx_Crear_Orden_Despacho(_Fila_NVV As DataRow, _TipoDespacho As String) As Mensajes

    '    Dim _Mensaje As New Mensajes
    '    Dim myTrans As SqlClient.SqlTransaction
    '    Dim Comando As SqlClient.SqlCommand
    '    Dim Cn2 As New SqlConnection

    '    Try
    '        ' Extraemos datos del documento Random
    '        Dim _Idmaeedo As Integer = _Fila_NVV.Item("IDMAEEDO")
    '        Dim _Tido As String = _Fila_NVV.Item("TIDO")
    '        Dim _Nudo As String = _Fila_NVV.Item("NUDO")
    '        Dim _Endo As String = _Fila_NVV.Item("ENDO")
    '        Dim _Suendo As String = _Fila_NVV.Item("SUENDO")

    '        ' Buscar dirección de despacho del cliente en MAEEN
    '        Consulta_sql = "SELECT NOKOEN, DIEN, COEN, CIEN FROM MAEEN WHERE KOEN = '" & _Endo & "' AND SUEN = '" & _Suendo & "'"
    '        Dim _Row_Cliente As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql)

    '        Dim _NombreCliente As String = If(IsNothing(_Row_Cliente), "", _Row_Cliente.Item("NOKOEN").ToString())
    '        Dim _Direccion As String = If(IsNothing(_Row_Cliente), "", _Row_Cliente.Item("DIEN").ToString())
    '        Dim _Comuna As String = If(IsNothing(_Row_Cliente), "", _Row_Cliente.Item("COEN").ToString())

    '        _SqlRandom.Sb_Abrir_Conexion(Cn2)
    '        myTrans = Cn2.BeginTransaction()

    '        ' -----------------------------------------------------------------------------------------
    '        ' 2. INSERTAR EN EL ENCABEZADO DE DESPACHO (Zw_Despachos)
    '        ' ¡IMPORTANTE!: Ajusta los nombres de las columnas a la tabla de despachos de tu Bakapp.
    '        ' -----------------------------------------------------------------------------------------
    '        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos " &
    '                       "(Empresa, Fecha_Emision, Estado, Tipo_Despacho, Entidad, SucEntidad, Nombre_Entidad, Direccion, Comuna) " &
    '                       "Values " &
    '                       "('" & ConfiguracionLocal.BodegaFacturacion.Empresa & "', GetDate(), 'PICKING', " &
    '                       "'" & _TipoDespacho & "', '" & _Endo & "', '" & _Suendo & "', " &
    '                       "'" & _NombreCliente & "', '" & _Direccion & "', '" & _Comuna & "')"

    '        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
    '        Comando.Transaction = myTrans
    '        Comando.ExecuteNonQuery()

    '        ' Obtener el ID del despacho recién insertado
    '        Comando = New SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
    '        Comando.Transaction = myTrans
    '        Dim _Id_Despacho As Integer
    '        Using dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
    '            While dfd1.Read()
    '                _Id_Despacho = dfd1("Identity")
    '            End While
    '        End Using

    '        ' -----------------------------------------------------------------------------------------
    '        ' 3. INSERTAR EN EL DETALLE DE DOCUMENTOS DEL DESPACHO (Zw_Despachos_Doc)
    '        ' Aquí "amarramos" el despacho recién creado a la NVV de Random.
    '        ' -----------------------------------------------------------------------------------------
    '        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Despachos_Doc " &
    '                       "(Id_Despacho, Idmaeedo_Doc, Tido, Nudo) " &
    '                       "Values " &
    '                       "(" & _Id_Despacho & ", " & _Idmaeedo & ", '" & _Tido & "', '" & _Nudo & "')"

    '        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
    '        Comando.Transaction = myTrans
    '        Comando.ExecuteNonQuery()

    '        ' CONFIRMAMOS LA TRANSACCION
    '        myTrans.Commit()
    '        _SqlRandom.Sb_Cerrar_Conexion(Cn2)

    '        _Mensaje.EsCorrecto = True
    '        _Mensaje.Detalle = "Despacho insertado correctamente"
    '        _Mensaje.Mensaje = "OK."

    '    Catch ex As Exception
    '        _Mensaje.EsCorrecto = False
    '        _Mensaje.Detalle = "Error al grabar orden de despacho"
    '        _Mensaje.Mensaje = ex.Message

    '        If Not IsNothing(myTrans) Then myTrans.Rollback()
    '        _SqlRandom.Sb_Cerrar_Conexion(Cn2)
    '    End Try

    '    Return _Mensaje

    'End Function

End Class
