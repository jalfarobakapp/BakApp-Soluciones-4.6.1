Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Cl_Sincroniza

    Dim _SqlRandom As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim _SqlMeli As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Cadena_ConexionSQL_Server_Meli
    Public Property ConfiguracionLocal As Configuracion

    Public Sub New()

    End Sub

    Sub Sb_Revisar_Pedidos(Txt_Log As Object, _Fecha As Date, _Top As Integer)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        If _Top = 0 Then
            _Top = 1000
        End If

        Dim _Mensaje As LsValiciones.Mensajes = Fx_Llenar_Doc_MELI(_Top, _Fecha)

        If _Mensaje.EsCorrecto Then

            Dim _Ls_Doc_MELI As List(Of Doc_MELI) = _Mensaje.Tag

            For Each _Doc_MELI As Doc_MELI In _Ls_Doc_MELI

                Dim _ID As Integer = _Doc_MELI.ID
                Dim _ID_MELI As String = _Doc_MELI.ID_MELI
                Dim _PEDIDO As PEDIDOS = _Doc_MELI.PEDIDO
                Dim _OBSERVACIONES As String = _Doc_MELI.Mensaje

                If _Doc_MELI.EsCorrecto Then

                    Dim _PEDIDOS_DETALLE As List(Of PEDIDOS_DETALLE) = _Doc_MELI.PEDIDOS_DETALLE

                    Dim _Mensaje2 As LsValiciones.Mensajes = Fx_Grabar_Pedido(_PEDIDO, _PEDIDOS_DETALLE)

                    If _Mensaje2.EsCorrecto Then

                        _OBSERVACIONES = _Mensaje2.Mensaje

                        Sb_AddToLog("Sincronizando MELI", "Reisando documento: " & _Doc_MELI.PEDIDO.ID_MELI, Txt_Log)

                        Consulta_sql = "Update PEDIDOS Set REVBAKAPP = 1,FECHAREVBAKAPP = Getdate(),OBSERVACIONES = '" & _OBSERVACIONES & "' Where ID = " & _ID
                        _SqlMeli.Ej_consulta_IDU(Consulta_sql, False)

                    Else

                        _OBSERVACIONES = _Mensaje2.Mensaje

                        Consulta_sql = "Update PEDIDOS Set REVBAKAPP = 1,FECHAREVBAKAPP = Getdate(),OBSERVACIONES = '" & _OBSERVACIONES & "'" & vbCrLf &
                                       "Where ID = " & _ID
                        _SqlMeli.Ej_consulta_IDU(Consulta_sql, False)

                        Sb_AddToLog("Sincronizando MELI", "Error en documento ID: " & _ID & ", ID_MELI: " & _ID_MELI, Txt_Log)
                        Sb_AddToLog("Sincronizando MELI", _OBSERVACIONES, Txt_Log)

                    End If

                Else

                    Consulta_sql = "Update PEDIDOS Set REVBAKAPP = 1,FECHAREVBAKAPP = Getdate(),OBSERVACIONES = '" & _OBSERVACIONES & "'" & vbCrLf &
                                   "Where ID = " & _ID
                    _SqlMeli.Ej_consulta_IDU(Consulta_sql, False)

                    Sb_AddToLog("Sincronizando MELI", "Error en documento ID: " & _ID & ", ID_MELI: " & _ID_MELI, Txt_Log)
                    Sb_AddToLog("Sincronizando MELI", _OBSERVACIONES, Txt_Log)

                End If

            Next

        End If

    End Sub

    Private Function Fx_Grabar_Pedido(_PEDIDO As PEDIDOS, _Ls_PEDIDOS_DETALLE As List(Of PEDIDOS_DETALLE)) As Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _FechaGrab As Date = FechaDelServidor()

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Dim _Zw_Demonio_NVVAuto As New Zw_Demonio_NVVAuto
            Dim _Ls_Zw_Demonio_NVVAuto_Detalle As New List(Of Zw_Demonio_NVVAutoDet)

            Dim _Observaciones As String

            With _Zw_Demonio_NVVAuto

                .IdmaeedoOCC_Ori = _PEDIDO.ID
                .NudoOCC_Ori = _PEDIDO.ID_MELI
                .Endo_Ori = _PEDIDO.KOEN
                .Suendo_Ori = String.Empty
                .FechaGrab = _FechaGrab
                .GenerarNVV = True

                _Observaciones = "Pedido: " & _PEDIDO.ID_MELI

                _PEDIDO.NICK_NAME = Fx_ReemplazarCaracteresRaros2(_PEDIDO.NICK_NAME)
                _PEDIDO.FIRST_NAME = Fx_ReemplazarCaracteresRaros2(_PEDIDO.FIRST_NAME)
                _PEDIDO.LAST_NAME = Fx_ReemplazarCaracteresRaros2(_PEDIDO.LAST_NAME)
                _PEDIDO.DIRECCION = Fx_ReemplazarCaracteresRaros2(_PEDIDO.DIRECCION)
                _PEDIDO.COMUNA = Fx_ReemplazarCaracteresRaros2(_PEDIDO.COMUNA)

                Dim _Nombre As String = _PEDIDO.FIRST_NAME.ToString.Trim

                If Not String.IsNullOrEmpty(_PEDIDO.LAST_NAME.ToString.Trim) Then
                    _Nombre += " " & _PEDIDO.LAST_NAME.ToString.Trim
                End If

                If Not String.IsNullOrEmpty(_Nombre) Then _Observaciones += ", " & _Nombre
                If Not String.IsNullOrEmpty(_PEDIDO.DIRECCION.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.DIRECCION.ToString.Trim
                If Not String.IsNullOrEmpty(_PEDIDO.COMUNA.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.COMUNA.ToString.Trim

                _Observaciones = Fx_ReemplazarCaracteresRaros2(_Observaciones)

                .Observaciones = Mid(_Observaciones, 1, 250)
                .Ocdo = _PEDIDO.ID_PAGO
                .TipoOri = "MLIBRE"

                .Texto1 = _PEDIDO.ID_MELI
                .Texto2 = _PEDIDO.ID_PAGO
                .Texto3 = _PEDIDO.NICK_NAME
                .Texto4 = _PEDIDO.FIRST_NAME
                .Texto5 = _PEDIDO.LAST_NAME
                .Texto6 = _PEDIDO.DIRECCION
                .Texto7 = _PEDIDO.COMUNA
                .Texto8 = String.Empty
                .Texto9 = String.Empty
                .Texto10 = String.Empty
                .Facturar = ConfiguracionLocal.Facturar
                .DocEmitir = ConfiguracionLocal.DocEmitir
                .CodFuncionario_Factura = ConfiguracionLocal.Responsable
                .EnvFacAutoBk = 0

            End With

            For Each _PEDIDOS_DETALLE As PEDIDOS_DETALLE In _Ls_PEDIDOS_DETALLE

                Dim _Descripcion As String

                If _PEDIDOS_DETALLE.PRCT Then

                    Consulta_sql = "Select KOCT,NOKOCT From TABCT Where KOCT = '" & _PEDIDOS_DETALLE.KOPR & "' And TICT = '" & _PEDIDOS_DETALLE.TICT & "'"
                    Dim _Row_Concepto As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql, False)

                    If IsNothing(_Row_Concepto) Then
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Detalle = "Concepto no encontrado"
                        _Mensaje.Mensaje = "Concepto no encontrado: " & _PEDIDOS_DETALLE.KOPR.ToString.Trim
                        _Mensaje.Id = 0
                        Return _Mensaje
                    End If

                    _Descripcion = _Row_Concepto.Item("NOKOCT")

                Else

                    Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _PEDIDOS_DETALLE.KOPR & "'"
                    Dim _Row_Producto As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql, False)

                    If IsNothing(_Row_Producto) Then
                        _Mensaje.EsCorrecto = False
                        _Mensaje.Detalle = "Producto no encontrado"
                        _Mensaje.Mensaje = "Producto no encontrado: " & _PEDIDOS_DETALLE.KOPR.ToString.Trim
                        _Mensaje.Id = 0
                        Return _Mensaje
                    End If

                    _Descripcion = _Row_Producto.Item("NOKOPR")

                End If

                Dim _Zw_Demonio_NVVAutoDet As New Zw_Demonio_NVVAutoDet

                With _Zw_Demonio_NVVAutoDet
                    .Id_Enc = 0
                    .Idmaeddo_Ori = _PEDIDOS_DETALLE.ID
                    .Codigo = _PEDIDOS_DETALLE.KOPR
                    .Cantidad = _PEDIDOS_DETALLE.CANTIDAD
                    .Untrans = 1
                    .Descripcion = _Descripcion
                    .Empresa = ConfiguracionLocal.BodegaFacturacion.Empresa
                    .Sucursal = ConfiguracionLocal.BodegaFacturacion.Kosu
                    .Bodega = ConfiguracionLocal.BodegaFacturacion.Kobo
                    '.Stfi1 = _Row.Item("Stfi1")
                    '.Stfi2 = _Row.Item("Stfi2")
                    .CantidadDefinitiva = _PEDIDOS_DETALLE.CANTIDAD
                    '.Stocnv1 = _Row.Item("Stocnv1")
                    '.Stocnv2 = _Row.Item("Stocnv2")
                    '.StComp1 = _Row.Item("StComp1")
                    '.StComp2 = _Row.Item("StComp2")
                    '.Stdv1 = _Row.Item("Stdv1")
                    '.Stdv2 = _Row.Item("Stdv2")
                    .Precio = Math.Round(_PEDIDOS_DETALLE.NETO_UNITARIO * 1.19, 0)
                    .Prct = _PEDIDOS_DETALLE.PRCT
                    .Tict = _PEDIDOS_DETALLE.TICT
                End With

                _Ls_Zw_Demonio_NVVAuto_Detalle.Add(_Zw_Demonio_NVVAutoDet)

            Next

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)


            myTrans = Cn2.BeginTransaction()

            With _Zw_Demonio_NVVAuto

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_NVVAuto (IdmaeedoOCC_Ori,NudoOCC_Ori,Endo_Ori,Suendo_Ori," &
                               "FechaGrab,GenerarNVV,Observaciones,TipoOri,Ocdo," &
                               "Texto1,Texto2,Texto3,Texto4,Texto5,Texto6,Texto7,Texto8,Texto9,Texto10," &
                               "Facturar,DocEmitir,CodFuncionario_Factura,EnvFacAutoBk) Values " &
                               "(" & .IdmaeedoOCC_Ori & ",'" & .NudoOCC_Ori & "','" & .Endo_Ori & "','" & .Suendo_Ori &
                               "','" & Format(.FechaGrab, "yyyyMMdd HH:mm:ss") & "'," & Convert.ToInt32(.GenerarNVV) &
                               ",'" & .Observaciones & "','" & .TipoOri & "','" & .Ocdo &
                               "','" & .Texto1 & "','" & .Texto2 & "','" & .Texto3 & "','" & .Texto4 & "','" & .Texto5 & "','" & .Texto6 &
                               "','" & .Texto7 & "','" & .Texto8 & "','" & .Texto9 & "','" & .Texto10 &
                               "'," & Convert.ToInt32(.Facturar) & ",'" & .DocEmitir &
                               "','" & .CodFuncionario_Factura & "'," & Convert.ToInt32(.EnvFacAutoBk) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id_Enc = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            For Each _Fila As Zw_Demonio_NVVAutoDet In _Ls_Zw_Demonio_NVVAuto_Detalle

                With _Fila

                    .Id_Enc = _Zw_Demonio_NVVAuto.Id_Enc

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet (Id_Enc,Idmaeddo_Ori,Codigo,Cantidad," &
                                   "Untrans,Descripcion,Empresa,Sucursal,Bodega,CantidadDefinitiva,Precio,Kofulido,Prct,Tict) Values " &
                                   "(" & .Id_Enc & "," & .Idmaeddo_Ori & ",'" & .Codigo & "'," & .Cantidad & "," & .Untrans &
                                   ",'" & .Descripcion & "','" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "'," &
                                   .CantidadDefinitiva & "," & .Precio & ",'" & ConfiguracionLocal.Vendedor & "'," &
                                   Convert.ToInt32(.Prct) & ",'" & .Tict & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Se inserta documento desde MELI correctamente en Bakapp"
            _Mensaje.Mensaje = "OK."


        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function
    Function Fx_Llenar_Doc_MELI(_Top As Integer, _Fecha As Date) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select Top " & _Top & " * From PEDIDOS" & vbCrLf &
                           "Where REVBAKAPP = 0 And CONVERT(varchar, FECHA, 112) = '" & Format(_Fecha, "yyyyMMdd") & "'"

            Dim _Tbl As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_Tbl.Rows.Count) Then
                _Mensaje.Detalle = "Sin registros"
                Throw New System.Exception("No se encontraron registros")
            End If

            Dim _Ls_Doc_MELI As New List(Of Doc_MELI)

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _ID_MELI As String = _Fila.Item("ID_MELI")

                Dim _Msj_Enc As LsValiciones.Mensajes = Fx_Llenar_PEDIDO(_ID_MELI)
                Dim _Msj_Det As LsValiciones.Mensajes = Fx_Llenar_PEDIDOS_DETALLE(_ID_MELI)

                Dim _Doc_MELI As New Doc_MELI

                _Doc_MELI.EsCorrecto = _Msj_Enc.EsCorrecto And _Msj_Det.EsCorrecto
                _Doc_MELI.ID_MELI = _ID_MELI
                _Doc_MELI.PEDIDO = _Msj_Enc.Tag
                _Doc_MELI.PEDIDOS_DETALLE = _Msj_Det.Tag

                If Not IsNothing(_Doc_MELI.PEDIDO) Then
                    _Doc_MELI.ID = _Doc_MELI.PEDIDO.ID
                End If

                If Not _Msj_Enc.EsCorrecto Then
                    _Mensaje.Detalle = _Msj_Enc.Mensaje
                End If

                If Not _Msj_Det.EsCorrecto Then
                    _Mensaje.Detalle = _Msj_Det.Mensaje
                End If

                _Doc_MELI.Mensaje = _Mensaje.Detalle

                _Ls_Doc_MELI.Add(_Doc_MELI)

                'Consulta_sql = "Update PEDIDOS Set REVBAKAPP = 1 Where ID_MELI = " & _Doc_MELI.PEDIDO.ID_MELI
                '_SqlRandom.Ej_consulta_IDU(Consulta_sql, False)

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = 0
            _Mensaje.Mensaje = "Registros encontrados"
            _Mensaje.Tag = _Ls_Doc_MELI

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function
    Function Fx_Llenar_PEDIDO(_ID_MELI As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From PEDIDOS" & vbCrLf &
                           "Where ID_MELI = " & _ID_MELI
            Dim _Row As DataRow = _SqlMeli.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.Detalle = "Sin registros"
                Throw New System.Exception("No se encontraron registros en PEDIDOS, ID_MELI = " & _ID_MELI)
            End If

            Dim _PEDIDOS As New PEDIDOS

            With _PEDIDOS

                .ID = _Row.Item("ID")
                .ID_MELI = _Row.Item("ID_MELI")
                .IDMAEEDO = _Row.Item("IDMAEEDO")
                .ID_PAGO = _Row.Item("ID_PAGO")
                .ESTADO = _Row.Item("ESTADO")
                .FECHA = _Row.Item("FECHA")
                .IMPRESO = _Row.Item("IMPRESO")
                .PAGADO = _Row.Item("PAGADO")
                .IDMAEEDO_F = NuloPorNro(_Row.Item("IDMAEEDO_F"), 0)
                .KOEN = _Row.Item("KOEN")
                .SUEN = _Row.Item("SUEN")
                .REVBAKAPP = _Row.Item("REVBAKAPP")
                .OBSERVACIONES = _Row.Item("OBSERVACIONES")
                .FECHAREVBAKAPP = NuloPorNro(_Row.Item("FECHAREVBAKAPP"), Nothing)
                .NICK_NAME = NuloPorNro(_Row.Item("NICK_NAME"), "")
                .FIRST_NAME = NuloPorNro(_Row.Item("FIRST_NAME"), "")
                .LAST_NAME = NuloPorNro(_Row.Item("LAST_NAME"), "")
                .DIRECCION = NuloPorNro(_Row.Item("DIRECCION"), "")
                .COMUNA = NuloPorNro(_Row.Item("COMUNA"), "")

            End With

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = _PEDIDOS.ID
            _Mensaje.Mensaje = "Registros encontrados"
            _Mensaje.Tag = _PEDIDOS

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function
    Function Fx_Llenar_PEDIDOS_DETALLE(_ID_MELI As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select * From PEDIDOS_DETALLE" & vbCrLf &
                           "Where ID_MELI = " & _ID_MELI & vbCrLf &
                           "And ES_KIT = 0"
            Dim _Tbl As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_Tbl.Rows.Count) Then
                _Mensaje.Detalle = "Sin registros"
                Throw New System.Exception("No se encontraron registros en PEDIDOS_DETALLE, ID_MELI = " & _ID_MELI)
            End If

            Dim _Ls_PEDIDOS_DETALLE As New List(Of PEDIDOS_DETALLE)

            For Each _Row As DataRow In _Tbl.Rows

                Dim _DETALLE_MELI As New PEDIDOS_DETALLE

                With _DETALLE_MELI
                    .ID = _Row.Item("ID")
                    .ID_MELI = _Row.Item("ID_MELI")
                    .KOPR = _Row.Item("KOPR")
                    .REFERENCIA_MELI = _Row.Item("REFERENCIA_MELI")
                    .CANTIDAD = _Row.Item("CANTIDAD")
                    .NETO_UNITARIO = _Row.Item("NETO_UNITARIO")
                    .SUB_TOTAL = _Row.Item("SUB_TOTAL")
                    .ES_KIT = _Row.Item("ES_KIT")
                    .ID_PADREKIT = _Row.Item("ID_PADREKIT")
                    .PRCT = _Row.Item("PRCT")
                    .TICT = _Row.Item("TICT")
                End With

                _Ls_PEDIDOS_DETALLE.Add(_DETALLE_MELI)

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = 1
            _Mensaje.Mensaje = "Registros encontrados"
            _Mensaje.Tag = _Ls_PEDIDOS_DETALLE

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Sub Sb_Adjuntar_Etiquetas(Txt_Log As Object, _Fecha As Date, _Top As Integer)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        If _Top = 0 Then
            _Top = 1000
        End If

        Consulta_sql = "Select NudoOCC_Ori As Id_Meli,Idmaeedo_NVV As Idmaeedo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_NVVAuto" & vbCrLf &
                       "Where NudoOCC_Ori+'.pdf' Not in (Select Nombre_Archivo From " & _Global_BaseBk & "Zw_Docu_Archivos) " &
                       "And CONVERT(varchar, Feemdo_NVV, 112) = '" & Format(_Fecha, "yyyyMMdd") & "'"

        Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl.Rows.Count) Then
            Sb_AddToLog("Adjuntar etiquetas", "Sin registros", Txt_Log)
            Return
        End If

        For Each _Row As DataRow In _Tbl.Rows

            Dim _Idmaeedo As Integer = _Row.Item("Idmaeedo")
            Dim _Id_Meli As String = _Row.Item("Id_Meli")
            Dim _Ruta_Etiqueta As String = ConfiguracionLocal.RutaEtiquetas
            Dim _Nombre_Etiqueta As String = _Id_Meli & ".pdf"

            Dim _Mensaje As LsValiciones.Mensajes = Fx_AdjuntarEtiqueta(_Idmaeedo, _Ruta_Etiqueta, _Nombre_Etiqueta)

            If _Mensaje.EsCorrecto Then
                Sb_AddToLog("Adjuntar etiquetas", "Etiqueta adjuntada correctamente, ID MELI: " & _Id_Meli, Txt_Log)
            Else
                Sb_AddToLog("Adjuntar etiquetas", "Error al adjuntar etiqueta, ID MELI: " & _Id_Meli, Txt_Log)
                Sb_AddToLog("Adjuntar etiquetas", _Mensaje.Mensaje, Txt_Log)
            End If

        Next

    End Sub
    Function Fx_AdjuntarEtiqueta(_Idmaeedo As Integer, _Ruta_Etiqueta As String, _Nombre_Etiqueta As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Adjuntar etiqueta"

        Dim _Ruta As String = _Ruta_Etiqueta & "\" & _Nombre_Etiqueta

        Try
            ' Verificar si el archivo existe en la ruta especificada
            If Not System.IO.File.Exists(_Ruta) Then
                _Mensaje.Cancelado = True
                Throw New System.Exception("El archivo no existe en la ruta especificada, " & _Ruta)
            End If

            Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)

            If Not Fm.Fx_Grabar_Observacion_Adjunta(_Ruta, _Nombre_Etiqueta, False, ConfiguracionLocal.Vendedor) Then
                Throw New System.Exception("Error al adjuntar etiqueta")
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Etiqueta adjuntada correctamente, ID MELI: " & _Nombre_Etiqueta

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Sub Sb_Revisar_Kit(Txt_Log As Object, _Fecha As Date, _Top As Integer)

        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Consulta_sql = "SELECT d.ID,d.ID_MELI,KOPR,REFERENCIA_MELI,CANTIDAD,NETO_UNITARIO,SUB_TOTAL" & vbCrLf &
                       "FROM PEDIDOS_DETALLE d" & vbCrLf &
                       "Inner Join PEDIDOS p On d.ID_MELI = p.ID_MELI" & vbCrLf &
                       "Where KOPR Like 'KT-%' And d.ES_KIT = 0 And CONVERT(varchar, FECHA, 112) = '" & Format(_Fecha, "yyyyMMdd") & "'"

        Dim _Tbl As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _ID As Integer = _Fila.Item("ID")
            Dim _ID_MELI As String = _Fila.Item("ID_MELI")
            Dim _KOPR As String = _Fila.Item("KOPR")
            Dim _REFERENCIA_MELI As String = _Fila.Item("REFERENCIA_MELI")
            Dim _CANTIDAD As Integer = _Fila.Item("CANTIDAD")
            Dim _NETO_UNITARIO As Double = _Fila.Item("NETO_UNITARIO")
            Dim _SUB_TOTAL As Double = _Fila.Item("SUB_TOTAL")

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Llenar_PEDIDOS_DETALLE_KIT(_ID_MELI, _SUB_TOTAL, _CANTIDAD)

            If _Mensaje.EsCorrecto Then

                Dim _Ls_PEDIDOS_DETALLE As List(Of PEDIDOS_DETALLE) = _Mensaje.Tag
                Dim _Mensaje2 As LsValiciones.Mensajes = Fx_Grabar_Pedido_Kit(_ID, _ID_MELI, _Ls_PEDIDOS_DETALLE)

                If _Mensaje2.EsCorrecto Then
                    Sb_AddToLog("Sincronizando MELI", "Creación de pedido por KIT: " & _KOPR, Txt_Log)
                Else
                    Sb_AddToLog("Sincronizando MELI", "Problema al crear KIT: " & _KOPR, Txt_Log)
                    Sb_AddToLog("Sincronizando MELI", _Mensaje2.Mensaje, Txt_Log)
                End If

            End If

        Next

    End Sub

    Private Function Fx_Grabar_Pedido_Kit(_Id_Detalle As Integer,
                                          _Id_meli As String,
                                          _Ls_NewPedido_Detalle As List(Of PEDIDOS_DETALLE)) As Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _FechaGrab As Date = FechaDelServidor()

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Try

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)
            myTrans = Cn2.BeginTransaction()


            For Each _Fila As PEDIDOS_DETALLE In _Ls_NewPedido_Detalle

                With _Fila

                    Consulta_sql = "Update PEDIDOS Set REVBAKAPP = 0,FECHAREVBAKAPP = Null, OBSERVACIONES = '' Where ID_MELI = " & _Id_meli

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Consulta_sql = "Update PEDIDOS_DETALLE Set ES_KIT = 1 Where ID = " & _Id_Detalle

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Consulta_sql = "Insert Into PEDIDOS_DETALLE (ID_MELI,KOPR,REFERENCIA_MELI," &
                                   "CANTIDAD,NETO_UNITARIO,SUB_TOTAL,ES_KIT,ID_PADREKIT,PRCT,TICT) Values " & vbCrLf &
                                   "('" & .ID_MELI & "','" & .KOPR & "','" & .REFERENCIA_MELI & "'," &
                                   De_Num_a_Tx_01(.CANTIDAD, False, 5) & "," &
                                   De_Num_a_Tx_01(.NETO_UNITARIO, False, 5) & "," &
                                   De_Num_a_Tx_01(.SUB_TOTAL, False, 5) & ",0," & _Id_Detalle & "," & Convert.ToInt32(.PRCT) & ",'" & .TICT & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next


            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Se inserta documento desde MELI correctamente en Bakapp"
            _Mensaje.Mensaje = "OK."


        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Private Function Fx_Llenar_PEDIDOS_DETALLE_KIT(_ID_MELI As String, _Sub_Total As Double, _CantidadKit As Integer) As Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Ls_PEDIDOS_DETALLE As New List(Of PEDIDOS_DETALLE)

            Dim _Mjs As LsValiciones.Mensajes = Fx_Llenar_PEDIDOS_DETALLE(_ID_MELI)

            If _Mjs.EsCorrecto Then
                _Ls_PEDIDOS_DETALLE = _Mjs.Tag
                _Mensaje.EsCorrecto = True
                _Mensaje.Id = 1
                _Mensaje.Mensaje = "Registros encontrados"
                '_Ls_PEDIDOS_DETALLE = _Mensaje.Tag
            Else
                _Mensaje.Id = 0
                Throw New System.Exception("No se encontraron registros en PEDIDOS_DETALLE, ID_MELI = " & _ID_MELI)
            End If

            'If Not CBool(_Tbl.Rows.Count) Then
            '    _Mensaje.Detalle = "Sin registros"
            '    Throw New System.Exception("No se encontraron registros en PEDIDOS_DETALLE, ID_MELI = " & _ID_MELI)
            'End If

            Dim _Ls_Pedidos As New List(Of PEDIDOS_DETALLE)

            For Each _Fila As PEDIDOS_DETALLE In _Ls_PEDIDOS_DETALLE

                Dim _Sku As String = _Fila.KOPR
                Dim _Id_padrekit As Integer = _Fila.ID

                Dim _Mensaje2 As LsValiciones.Mensajes = Fx_CrearDetalleKit(_ID_MELI, _Fila, _Sub_Total, _CantidadKit)

                _Ls_Pedidos.AddRange(_Mensaje2.Tag)

            Next

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = 1
            _Mensaje.Mensaje = "Registros encontrados"
            _Mensaje.Tag = _Ls_Pedidos

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Id = 0
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_CrearDetalleKit(_Id_meli As String,
                                _Fila_Pedidos_detalle As PEDIDOS_DETALLE,
                                _Sub_Total As Double,
                                _CantidadKit As Integer) As LsValiciones.Mensajes

        Dim _Sku As String = _Fila_Pedidos_detalle.KOPR
        Dim _Id_padrekit As Integer = _Fila_Pedidos_detalle.ID

        Dim _Mensaje As New Mensajes
        Dim _Ls_PEDIDOS_DETALLE As New List(Of PEDIDOS_DETALLE)

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Try

            Consulta_sql = "SELECT ID,ID_EMPRESA,CODIGO_KIT,GLOSA,PRECIO,ESTADO,INTEGRADO_MELI,ID_MELI" & vbCrLf &
                           "FROM [@KT_KITS]" & vbCrLf &
                           "WHERE (CODIGO_KIT = '" & _Sku & "')"
            Dim _Row As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Throw New System.Exception("No se encontraron registros en [@KT_KITS], SKU = '" & _Sku & "'")
            End If

            Dim _Id_kit As Integer = _Row.Item("ID")

            Consulta_sql = "SELECT ID,ID_KIT,SKU,CANTIDAD,ROUND(t.PP01UD*1.19,0) As PP01UD" & vbCrLf &
                           "FROM [@KT_KIT_DETALLE] k" & vbCrLf &
                           "Inner Join TABPRE t On k.SKU = t.KOPR And KOLT = '01P'" & vbCrLf &
                           "WHERE (ID_KIT = " & _Id_kit & ")"
            Dim _Tbl As DataTable = _SqlRandom.Fx_Get_DataTable(Consulta_sql)

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Id As Integer = _Fila.Item("ID")
                Dim _Kopr As String = _Fila.Item("SKU")
                Dim _Cantidad As Integer = _Fila.Item("CANTIDAD") * _CantidadKit
                Dim _Precio As Double = _Fila.Item("PP01UD")

                Dim _PEDIDOS_DETALLE As New PEDIDOS_DETALLE

                With _PEDIDOS_DETALLE
                    .ID = _Id
                    .ID_MELI = _Id_meli
                    .KOPR = _Kopr
                    .CANTIDAD = _Cantidad
                    .NETO_UNITARIO = _Precio
                    .REFERENCIA_MELI = ""
                    .SUB_TOTAL = _Cantidad * _Precio
                    .ES_KIT = True
                    .ID_PADREKIT = _Id_padrekit
                    .PRCT = False
                    .TICT = String.Empty
                End With

                _Ls_PEDIDOS_DETALLE.Add(_PEDIDOS_DETALLE)

            Next

            Dim _Sub_Total_Calculado As Double = _Ls_PEDIDOS_DETALLE.Sum(Function(x) x.SUB_TOTAL)
            Dim _Diferencia As Double = _Sub_Total_Calculado - _Sub_Total

            ' Calcular el descuento necesario
            Dim _Descuento As Double = Math.Round(_Diferencia / _Sub_Total_Calculado, 5)

            Dim _Suma_Total_Neto_Calculado As Double = 0
            Dim _Suma_Total_Bruto_Calculado As Double = 0

            For Each _Fl As PEDIDOS_DETALLE In _Ls_PEDIDOS_DETALLE

                Dim _Precio As Double = _Fl.NETO_UNITARIO
                Dim _Precio_Bruto As Double

                Dim _PrecioCd As Double = Math.Round(_Precio * _Descuento, 0)

                _Precio = _Precio - _PrecioCd
                _Precio_Bruto = Math.Round(_Precio * 1.19, 0)

                Dim _Total As Double = _Precio * _Fl.CANTIDAD
                Dim _Total_Bruto As Double = _Precio_Bruto * _Fl.CANTIDAD

                _Suma_Total_Neto_Calculado += _Total
                _Suma_Total_Bruto_Calculado += _Total_Bruto

                _Fl.NETO_UNITARIO = _Precio
                _Fl.SUB_TOTAL = _Precio * _Fl.CANTIDAD

            Next

            _Diferencia = _Sub_Total - _Suma_Total_Neto_Calculado

            Dim _TotalBruto_Meli As Double = Math.Round(_Sub_Total * 1.19, 0)
            Dim _TotalBruto_Calculado As Double = _Suma_Total_Bruto_Calculado

            _Diferencia = _TotalBruto_Meli - _TotalBruto_Calculado

            If CBool(_Diferencia) Then

                'Dim _Dif As Double = Math.Round(_Diferencia / _CantidadKit, 0)

                Dim _Kopr As String
                Dim _Cantidad As Integer = 1
                Dim _Precio As Double = _Diferencia
                Dim _Tict As String

                If _Diferencia > 0 Then
                    _Kopr = ConfiguracionLocal.Concepto_R
                    _Tict = "R"
                Else
                    _Kopr = ConfiguracionLocal.Concepto_D
                    _Tict = "D"
                    _Diferencia = _Diferencia * -1
                End If

                _Precio = _Diferencia

                Dim _PEDIDOS_DETALLE As New PEDIDOS_DETALLE

                With _PEDIDOS_DETALLE
                    .ID = 0
                    .ID_MELI = _Id_meli
                    .KOPR = _Kopr
                    .CANTIDAD = _Cantidad
                    .NETO_UNITARIO = _Precio
                    .REFERENCIA_MELI = ""
                    .SUB_TOTAL = _Precio
                    .ES_KIT = True
                    .ID_PADREKIT = _Id_padrekit
                    .PRCT = True
                    .TICT = _Tict
                End With

                _Ls_PEDIDOS_DETALLE.Add(_PEDIDOS_DETALLE)

                '_Ls_PEDIDOS_DETALLE.Item(0).NETO_UNITARIO += _Dif
                '_Ls_PEDIDOS_DETALLE.Item(0).SUB_TOTAL = _Ls_PEDIDOS_DETALLE.Item(0).NETO_UNITARIO * _Ls_PEDIDOS_DETALLE.Item(0).CANTIDAD

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Kits encontrados y armados"
            _Mensaje.Tag = _Ls_PEDIDOS_DETALLE

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Sub Sb_ActualizarIDMAEEDO_NVV_DesdeBakappHaciaMLIBRE()

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Consulta_sql = "SELECT * From PEDIDOS Where IDMAEEDO = 0 And REVBAKAPP = 1"
        Dim _Tbl_Pedidos As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

        If _Tbl_Pedidos.Rows.Count = 0 Then
            Return
        End If

        For Each _Fila As DataRow In _Tbl_Pedidos.Rows

            Dim _ID As Integer = _Fila.Item("ID")
            Dim _ID_MELI As String = _Fila.Item("ID_MELI")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Where NudoOCC_Ori = '" & _ID_MELI & "' And Idmaeedo_NVV <> 0"
            Dim _Row As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Continue For
            End If

            Dim _IDMAEEDO As Integer = _Row.Item("Idmaeedo_NVV")

            Consulta_sql = "Update PEDIDOS Set IDMAEEDO = " & _IDMAEEDO & ",ESTADO = 1 Where ID_MELI = " & _ID_MELI
            _SqlMeli.Ej_consulta_IDU(Consulta_sql)

        Next

    End Sub

    Sub Sb_ActualizarIDMAEEDO_FCV_DesdeBakappHaciaMLIBRE()

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Consulta_sql = "SELECT * From PEDIDOS Where IDMAEEDO <> 0 And ESTADO = 1"
        Dim _Tbl_Pedidos As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

        If _Tbl_Pedidos.Rows.Count = 0 Then
            Return
        End If

        For Each _Fila As DataRow In _Tbl_Pedidos.Rows

            Dim _ID As Integer = _Fila.Item("ID")
            Dim _ID_MELI As String = _Fila.Item("ID_MELI")
            Dim _IDMAEEDO_NVV As String = _Fila.Item("IDMAEEDO")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_FacAuto Where Idmaeedo_NVV = '" & _IDMAEEDO_NVV & "' And Facturado = 1"
            Dim _Row As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Continue For
            End If

            Dim _IDMAEEDO_F As Integer = _Row.Item("Idmaeedo_FCV")

            Consulta_sql = "Update PEDIDOS Set IDMAEEDO_F = " & _IDMAEEDO_F & ",ESTADO = 2 Where ID_MELI = " & _ID_MELI
            _SqlMeli.Ej_consulta_IDU(Consulta_sql)

        Next

    End Sub

    Sub Sb_SincronizarPagos()

        If Not ConfiguracionLocal.Pago.PagarAuto Then
            Return
        End If

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)
        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Consulta_sql = "Select Distinct ID_MELI From PEDIDOS_PAGOS Where IDMAEDPCD = 0"
        Dim _Tbl As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _ID_MELI As String = _Fila.Item("ID_MELI")
            Dim _Ls_PEDIDOS_PAGOS As List(Of PEDIDOS_PAGOS) = Fx_Llena_PEDIDOS_PAGOS(_ID_MELI)

            For Each _Fl As PEDIDOS_PAGOS In _Ls_PEDIDOS_PAGOS

                Dim _ID As Integer = _Fl.ID
                Dim _IDMAEEDO_F As Integer = _Fl.IDMAEEDO_F
                Dim _ID_PAGO As String = _Fl.ID_PAGO
                Dim _MONTO As Double = _Fl.MONTO
                Dim _TIPO_PAGO As String = _Fl.TIPO_PAGO
                Dim _FECHA_PAGO As Date = _Fl.FECHA_PAGO
                Dim _IDMAEDPCD As Integer = _Fl.IDMAEDPCD
                Dim _IDMAEDPCE As Integer = _Fl.IDMAEDPCE
                Dim _LOG_INFO As String = _Fl.LOG_INFO

                Dim _Cudp As String = If(_ID_PAGO.Length >= 16, _ID_PAGO.Substring(_ID_PAGO.Length - 16), _ID_MELI)
                Dim _Nucudp As String = If(_ID_MELI.Length >= 8, _ID_MELI.Substring(_ID_MELI.Length - 8), _ID_MELI)
                Dim _Refanti As String = _ID_MELI

                Dim _Mensaje As LsValiciones.Mensajes = Fx_PagarDocumento(_IDMAEEDO_F, _Cudp, _Nucudp, _Refanti)

                If _Mensaje.EsCorrecto Then

                    Dim _Maedpcd As MAEDPCD = _Mensaje.Tag

                    Consulta_sql = "Update PEDIDOS_PAGOS Set IDMAEDPCE = " & _Maedpcd.IDMAEDPCE & ",IDMAEDPCD = " & _Maedpcd.IDMAEDPCD & " Where ID = " & _ID
                    _SqlMeli.Ej_consulta_IDU(Consulta_sql)

                Else

                    Consulta_sql = "Update PEDIDOS_PAGOS Set LOG_INFO = '" & _Mensaje.Mensaje & "' Where ID = " & _ID
                    _SqlMeli.Ej_consulta_IDU(Consulta_sql)

                End If

            Next

        Next

    End Sub

    Function Fx_Llena_PEDIDOS_PAGOS(_Id_Meli As String) As List(Of PEDIDOS_PAGOS)

        Dim _Ls_PEDIDOS_PAGOS As New List(Of PEDIDOS_PAGOS)

        _SqlMeli = New Class_SQL(Cadena_ConexionSQL_Server_Meli)

        Consulta_sql = "Select * From PEDIDOS_PAGOS Where ID_MELI = '" & _Id_Meli & "'"
        Dim _Tbl As DataTable = _SqlMeli.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Pedidos_Pagos As New PEDIDOS_PAGOS With {
                .ID = _Fila.Item("ID"),
                .ID_MELI = _Fila.Item("ID_MELI"),
                .IDMAEEDO_F = _Fila.Item("IDMAEEDO_F"),
                .ID_PAGO = _Fila.Item("ID_PAGO"),
                .MONTO = _Fila.Item("MONTO"),
                .TIPO_PAGO = _Fila.Item("TIPO_PAGO"),
                .FECHA_PAGO = _Fila.Item("FECHA_PAGO"),
                .IDMAEDPCD = _Fila.Item("IDMAEDPCD"),
                .IDMAEDPCE = _Fila.Item("IDMAEDPCE"),
                .LOG_INFO = _Fila.Item("LOG_INFO")
            }

            _Ls_PEDIDOS_PAGOS.Add(_Pedidos_Pagos)

        Next

        Return _Ls_PEDIDOS_PAGOS

    End Function

    Function Fx_PagarDocumento(_Idmaeedo As Integer, _Cudp As String, _Nucudp As String, _Refanti As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _SqlRandom = New Class_SQL(Cadena_ConexionSQL_Server)

        Try

            Dim _Cl_Pagar As New Clas_Pagar
            Dim _Maedpce As MAEDPCE

            Dim _Row_Maeedo As DataRow = _SqlRandom.Fx_Get_DataRow("Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo)

            Consulta_sql = "Select TOP 1 * From MAEMO Where KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' Order by IDMAEMO DESC"
            Dim _Row_MaemoUSD = _SqlRandom.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_MaemoUSD) Then
                Throw New System.Exception("No se encontraron registros en MAEMO, KOMO = 'US$', FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "'")
            End If

            _Maedpce = New MAEDPCE With {
            .TIDP = ConfiguracionLocal.Pago.TipoPago,
            .EMPRESA = ConfiguracionLocal.Pago.Empresa,
            .ENDP = _Row_Maeedo.Item("ENDO"),
            .EMDP = ConfiguracionLocal.Pago.Banco,
            .SUEMDP = "",
            .CUDP = _Cudp,
            .NUCUDP = _Nucudp,
            .FEEMDP = FechaDelServidor(),
            .FEVEDP = FechaDelServidor(),
            .MODP = "$",
            .TIMODP = "N",
            .TAMODP = _Row_MaemoUSD.Item("VAMO"),
            .VADP = _Row_Maeedo.Item("VABRDO"),
            .VAASDP = _Row_Maeedo.Item("VABRDO"),
            .VAVUDP = 0,
            .ESASDP = "A",
            .ESPGDP = "P",
            .SUREDP = ConfiguracionLocal.Pago.Sucursal,
            .CJREDP = ConfiguracionLocal.Pago.Caja,
            .KOFUDP = ConfiguracionLocal.Pago.Funcionario,
            .REFANTI = _Refanti,
            .KOTU = 1,
            .VAABDP = 0,
            .CUOTAS = 1,
            .ARCHIRSD = "",
            .IDRSD = 0,
            .KOTNDP = ConfiguracionLocal.Pago.RutEmpresa,
            .SUTNDP = ConfiguracionLocal.Pago.Sucursal
            }

            Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()
            Dim _Ls_Maedpce As New List(Of MAEDPCE)

            _Ls_Maedpce.Add(_Maedpce)

            _Mensaje = _Cl_Pagar.Fx_Pagar_Documento(_Idmaeedo, _Ls_Maedpce, _Fecha_Asignacion_Pago)

            If Not _Mensaje.EsCorrecto Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Documento pagado correctamente"

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

End Class
