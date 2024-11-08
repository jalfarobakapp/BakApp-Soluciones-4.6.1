Imports System.Data.SqlClient
Imports BkSpecialPrograms
Imports BkSpecialPrograms.LsValiciones

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

                Dim _Nombre As String = _PEDIDO.FIRST_NAME.ToString.Trim

                If Not String.IsNullOrEmpty(_PEDIDO.LAST_NAME.ToString.Trim) Then
                    _Nombre += " " & _PEDIDO.LAST_NAME.ToString.Trim
                End If

                'If Not String.IsNullOrEmpty(_PEDIDO.NICK_NAME.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.NICK_NAME.ToString.Trim
                If Not String.IsNullOrEmpty(_Nombre) Then _Observaciones += ", " & _Nombre
                'If Not String.IsNullOrEmpty(_FirstName.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.FIRST_NAME.ToString.Trim
                'If Not String.IsNullOrEmpty(_LastName.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.LAST_NAME.ToString.Trim
                If Not String.IsNullOrEmpty(_PEDIDO.DIRECCION.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.DIRECCION.ToString.Trim
                If Not String.IsNullOrEmpty(_PEDIDO.COMUNA.ToString.Trim) Then _Observaciones += ", " & _PEDIDO.COMUNA.ToString.Trim

                _Observaciones = Fx_ReemplazarCaracteresRaros2(_Observaciones)

                .Observaciones = Mid(_Observaciones, 1, 250)
                .Ocdo = _PEDIDO.ID_PAGO
                .TipoOri = "MLIBRE"
            End With

            For Each _PEDIDOS_DETALLE As PEDIDOS_DETALLE In _Ls_PEDIDOS_DETALLE

                Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & _PEDIDOS_DETALLE.KOPR & "'"
                Dim _Row_Producto As DataRow = _SqlRandom.Fx_Get_DataRow(Consulta_sql, False)

                If IsNothing(_Row_Producto) Then
                    _Mensaje.EsCorrecto = False
                    _Mensaje.Detalle = "Producto no encontrado"
                    _Mensaje.Mensaje = "Producto no encontrado: " & _PEDIDOS_DETALLE.KOPR.ToString.Trim
                    _Mensaje.Id = 0
                    Return _Mensaje
                End If

                Dim _Zw_Demonio_NVVAutoDet As New Zw_Demonio_NVVAutoDet

                With _Zw_Demonio_NVVAutoDet
                    .Id_Enc = 0
                    .Idmaeddo_Ori = _PEDIDOS_DETALLE.ID
                    .Codigo = _PEDIDOS_DETALLE.KOPR
                    .Cantidad = _PEDIDOS_DETALLE.CANTIDAD
                    .Untrans = 1
                    .Descripcion = _Row_Producto.Item("NOKOPR")
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
                    .Precio = _PEDIDOS_DETALLE.NETO_UNITARIO
                End With

                _Ls_Zw_Demonio_NVVAuto_Detalle.Add(_Zw_Demonio_NVVAutoDet)

            Next

            Consulta_sql = String.Empty

            SQL_ServerClass.Sb_Abrir_Conexion(Cn2)


            myTrans = Cn2.BeginTransaction()

            With _Zw_Demonio_NVVAuto

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_NVVAuto (IdmaeedoOCC_Ori,NudoOCC_Ori,Endo_Ori,Suendo_Ori,FechaGrab,GenerarNVV,Observaciones,TipoOri,Ocdo) Values " &
                               "(" & .IdmaeedoOCC_Ori & ",'" & .NudoOCC_Ori & "','" & .Endo_Ori & "','" & .Suendo_Ori & "','" & Format(.FechaGrab, "yyyyMMdd HH:mm:ss") & "'," & Convert.ToInt32(.GenerarNVV) & ",'" & .Observaciones & "','" & .TipoOri & "','" & .Ocdo & "')"

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
                                   "Untrans,Descripcion,Empresa,Sucursal,Bodega,CantidadDefinitiva,Precio) Values " &
                                   "(" & .Id_Enc & "," & .Idmaeddo_Ori & ",'" & .Codigo & "'," & .Cantidad & "," & .Untrans &
                                   ",'" & .Descripcion & "','" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "'," &
                                   .CantidadDefinitiva & "," & .Precio & ")"

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
                .NICK_NAME =  NuloPorNro(_Row.Item("NICK_NAME"), "")
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

            Consulta_sql = "SELECT ID,ID_MELI, KOPR, REFERENCIA_MELI, CANTIDAD, NETO_UNITARIO, SUB_TOTAL" & vbCrLf &
                           "FROM PEDIDOS_DETALLE" & vbCrLf &
                           "Where ID_MELI = " & _ID_MELI
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

End Class
