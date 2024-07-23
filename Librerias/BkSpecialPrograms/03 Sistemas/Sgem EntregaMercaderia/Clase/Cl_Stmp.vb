Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Cl_Stmp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Stmp_Enc As New Zw_Stmp_Enc
    Public Property Zw_Stmp_Det As New List(Of Zw_Stmp_Det)
    Public Property Zw_Stmp_DetPick As New List(Of Zw_Stmp_DetPick)

    Public Sub New()

    End Sub

    Function Fx_Llenar_Encabezado(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Id = " & _Id_Enc
        Dim _Row_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Enc) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_Stmp_Enc con el Id " & _Id_Enc

            Return _Mensaje_Stem

        End If

        With Zw_Stmp_Enc

            .Id = _Row_Enc.Item("Id")
            .Empresa = _Row_Enc.Item("Empresa")
            .Sucursal = _Row_Enc.Item("Sucursal")
            .Numero = _Row_Enc.Item("Numero")
            .CodFuncionario_Crea = _Row_Enc.Item("CodFuncionario_Crea")
            .Idmaeedo = _Row_Enc.Item("Idmaeedo")
            .Tido = _Row_Enc.Item("Tido")
            .Nudo = _Row_Enc.Item("Nudo")
            .Endo = _Row_Enc.Item("Endo")
            .Suendo = _Row_Enc.Item("Suendo")
            .FechaCreacion = _Row_Enc.Item("FechaCreacion")
            .Estado = _Row_Enc.Item("Estado")
            .FechaPickeado = NuloPorNro(_Row_Enc.Item("FechaCierre"), Nothing)
            .FechaCierre = NuloPorNro(_Row_Enc.Item("FechaCierre"), Nothing)
            .Accion = _Row_Enc.Item("Accion")
            .Secueven = _Row_Enc.Item("Secueven")
            .TipoPago = _Row_Enc.Item("TipoPago")
            .CodFuncionario_Entrega = _Row_Enc.Item("CodFuncionario_Entrega")

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function
    Function Fx_Llenar_Detalle(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Det Where Id_Enc = " & _Id_Enc
        Dim _Tbl_Det As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_Det.Rows.Count) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontraron registros en la tabla Zw_Stmp_Det con el Id_Enc " & _Id_Enc

            Return _Mensaje_Stem

        End If

        For Each _Fila As DataRow In _Tbl_Det.Rows

            Dim _Stem_Det As New Zw_Stmp_Det

            With _Stem_Det

                .Id = _Fila.Item("Id")
                .Id_Enc = _Fila.Item("Id_Enc")
                .Idmaeedo = _Fila.Item("Idmaeedo")
                .Idmaeddo = _Fila.Item("Idmaeddo")
                .Codigo = _Fila.Item("Codigo")
                .Descripcion = _Fila.Item("Descripcion")
                .Nulido = _Fila.Item("Nulido")
                .Udtrpr = _Fila.Item("Udtrpr")
                .Udpr = _Fila.Item("Udtrpr")
                .Rludpr = _Fila.Item("Rludpr")
                .RtuVariable = _Fila.Item("RtuVariable")
                .Rlud_Real = _Fila.Item("Rlud_Real")
                .Cantidad = _Fila.Item("Cantidad")
                .Caprco1_Ori = _Fila.Item("Caprco1_Ori")
                .Caprco1_Real = _Fila.Item("Caprco1_Real")
                .Ud01pr = _Fila.Item("Ud01pr")
                .Caprco2_Ori = _Fila.Item("Caprco2_Ori")
                .Caprco2_Real = _Fila.Item("Caprco2_Real")
                .Ud02pr = _Fila.Item("Ud02pr")
                .Pickeado = _Fila.Item("Pickeado")
                .CodFuncionario_Pickea = _Fila.Item("CodFuncionario_Pickea")
                .EnProceso = _Fila.Item("EnProceso")

                .UdMedida = _Fila.Item("Ud0" & .Udtrpr & "pr")

            End With

            Zw_Stmp_Det.Add(_Stem_Det)

        Next


        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

        Return _Mensaje_Stem

    End Function
    Function Fx_Llenar_Detalle_Pickeo(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_DetPick Where Id_Enc = " & _Id_Enc
        Dim _Tbl_DetPick As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        If Not CBool(_Tbl_DetPick.Rows.Count) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontraron registros en la tabla Zw_Stmp_Det con el Id_Enc " & _Id_Enc

            Return _Mensaje_Stem

        End If

        For Each _Fila As DataRow In _Tbl_DetPick.Rows

            Dim _Stem_DetPick As New Zw_Stmp_DetPick

            With _Stem_DetPick

                .Id = _Fila.Item("Id")
                .Id_Enc = _Fila.Item("Id_Enc")
                .Sku = _Fila.Item("Sku")
                .Sku_desc = _Fila.Item("Sku_desc")
                .Tag = _Fila.Item("Tag")
                .Udtrpr = _Fila.Item("Udtrpr")
                .Qty = _Fila.Item("Qty")
                .Loc = _Fila.Item("Loc")

            End With

            Zw_Stmp_DetPick.Add(_Stem_DetPick)

        Next

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

        Return _Mensaje_Stem

    End Function
    Function Fx_Llenar_Permiso(_Id_Enc As Integer, _CodPermiso As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc_Permisos Where Id_Enc = " & _Id_Enc & " And CodPermiso = '" & _CodPermiso & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then

            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla Zw_Stmp_Enc_Permisos con el Id_Enc " & _Id_Enc & " And CodPermiso = '" & _CodPermiso & "'"

            Return _Mensaje

        End If

        Dim Zw_Stmp_Enc_Permisos As New Zw_Stmp_Enc_Permisos

        With Zw_Stmp_Enc_Permisos

            .Id = _Row.Item("Id")
            .Id_Enc = _Row.Item("Id_Enc")
            .CodPermiso = _Row.Item("CodPermiso")
            .NroRemota = _Row.Item("NroRemota").ToString.Trim
            .CodFuncionario_Solicita = _Row.Item("CodFuncionario_Solicita")
            .CodFuncionario_Autoriza = _Row.Item("CodFuncionario_Autoriza")
            .FechaHora = _Row.Item("FechaHora")

        End With

        _Mensaje.EsCorrecto = True
        _Mensaje.Mensaje = "Registro encontrado."
        _Mensaje.Tag = Zw_Stmp_Enc_Permisos

        Return _Mensaje

    End Function
    Function Fx_Grabar_Nuevo_Tickets() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stmp_Enc

                .Numero = Fx_NvoNro_Stmp()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stmp_Enc (Empresa,Sucursal,Numero,CodFuncionario_Crea,Idmaeedo,Tido," &
                               "Nudo,Endo,Suendo,FechaCreacion,Estado,Secueven,Facturar,DocEmitir,Fecha_Facturar) Values " &
                       "('" & .Empresa & "','" & .Sucursal & "','" & .Numero & "','" & .CodFuncionario_Crea & "'," & .Idmaeedo &
                       ",'" & .Tido & "','" & .Nudo & "','" & .Endo & "','" & .Suendo & "','" & Format(.FechaCreacion, "yyyyMMdd HH:mm") & "'" &
                       ",'" & .Estado & "','" & .Secueven & "'," & Convert.ToInt32(.Facturar) & ",'" & .DocEmitir & "','" & Format(.Fecha_Facturar, "yyyyMMdd") & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                'Imports System.Data
                'Imports System.Data.SqlClient

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            For Each _Fila As Zw_Stmp_Det In Zw_Stmp_Det

                With _Fila

                    .Id_Enc = _Zw_Stmp_Enc.Id

                    If Not String.IsNullOrEmpty(.Codigo) Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stmp_Det (Id_Enc,Idmaeedo,Idmaeddo,Codigo,Descripcion,Nulido,Udtrpr,RtuVariable,Rludpr" &
                                       ",Caprco1_Ori,Caprco1_Real,Udpr,Ud01pr,Caprco2_Ori,Caprco2_Real,Ud02pr,Pickeado,EnProceso) Values " &
                                       "(" & .Id_Enc & "," & .Idmaeedo & "," & .Idmaeddo & ",'" & .Codigo & "','" & .Descripcion & "'" &
                                       ",'" & .Nulido & "'," & .Udtrpr & "," & De_Num_a_Tx_01(.RtuVariable, False, 5) & "," & De_Num_a_Tx_01(.Rludpr, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco1_Ori, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco1_Real, False, 5) &
                                       ",'" & .Udpr & "'" &
                                       ",'" & .Ud01pr & "'" &
                                       "," & De_Num_a_Tx_01(.Caprco2_Ori, False, 5) &
                                       "," & De_Num_a_Tx_01(.Caprco2_Real, False, 5) &
                                       ",'" & .Ud02pr & "'" &
                                       ",0," & Convert.ToInt32(.EnProceso) & ")"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Documento grabado correctamente"
            _Mensaje_Stem.Mensaje = "Se crea Ticket Nro " & _Zw_Stmp_Enc.Numero & " - (" & _Zw_Stmp_Enc.Tido & "-" & _Zw_Stmp_Enc.Nudo & ")"

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Detalle = "Error al grabar"
            _Mensaje_Stem.Mensaje = ex.Message
            _Zw_Stmp_Enc.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_NvoNro_Stmp() As String

        Dim _NvoNro_Stem As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stmp_Enc")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "#T00000000"
        End If

        _NvoNro_Stem = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _NvoNro_Stem

    End Function

    Function Fx_Revisar_NVV(_Tido As String, _Nudo As String) As LsValiciones.Mensajes

        Dim _Id_Enc As Integer
        Dim _Idmaeedo As Integer
        Dim _Row_Enc As DataRow

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            _Mensaje_Stem.EsCorrecto = False

            Consulta_sql = "Select SEnc.*,ESDO From " & _Global_BaseBk & "Zw_Stmp_Enc SEnc " & vbCrLf &
                           "Inner Join MAEEDO On IDMAEEDO = Idmaeedo" & vbCrLf &
                           "Where Tido = '" & _Tido & "' And Nudo = '" & _Nudo & "'"
            _Row_Enc = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Enc) Then
                Throw New System.Exception("No se encontro el documento " & _Tido & "-" & _Nudo & " en el Sistema")
            End If

            If _Row_Enc.Item("ESDO") = "N" Then
                Throw New System.Exception("Documento NULO en el Sistema")
            End If

            If _Row_Enc.Item("Estado") <> "PREPA" Then
                Throw New System.Exception("Acción disponible solo para documentos en estado (PREPA) Preparación.")
            End If

            _Id_Enc = _Row_Enc.Item("Id")
            _Idmaeedo = _Row_Enc.Item("Idmaeedo")

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Det Where Idmaeedo = " & _Idmaeedo
            Dim _Tbl_Det As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If Not CBool(_Tbl_Det.Rows.Count) Then
                Throw New System.Exception("No se encontro el detalle del documento en la tabla Zw_Stmp_Det")
            End If

            myTrans = Cn2.BeginTransaction()

            Dim _Ct_Pickados = 0
            Dim _Ct_EnProceso = 0

            For Each _Fila As DataRow In _Tbl_Det.Rows

                Dim _Id_Det As Integer = _Fila.Item("Id")
                Dim _Pickeado As Boolean = _Fila.Item("Pickeado")
                Dim _EnProceso As Boolean = _Fila.Item("EnProceso")

                If _Pickeado Then

                    _Ct_Pickados += 1
                    _EnProceso = False

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Det Set " & vbCrLf &
                                   "EnProceso = 0" & vbCrLf &
                                   "Where Id = " & _Id_Det

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

                If _EnProceso Then
                    _Ct_EnProceso += 1
                End If

            Next

            If _Tbl_Det.Rows.Count = _Ct_Pickados Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Completado = 1,Estado = 'COMPL'" & vbCrLf &
                               "Where Id = " & _Id_Enc

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                _Mensaje_Stem.EsCorrecto = True
                _Mensaje_Stem.Mensaje = "Documento completado"

            Else

                Throw New System.Exception("Faltan " & _Ct_EnProceso & " producto(s) por procesar." & vbCrLf &
                                           "Producto procesados: " & _Ct_Pickados)

            End If

            _Mensaje_Stem.EsCorrecto = True

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Confirmar_Picking() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stmp_Enc

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Estado = '" & .Estado & "',Accion = '" & .Accion & "'" &
                               ",Fecha_Facturar = '" & Format(.Fecha_Facturar, "yyyyMMdd") & "'" &
                               ",DocEmitir = '" & .DocEmitir & "'" &
                               ",TipoPago = '" & .TipoPago & "'" &
                               ",FechaPickeado = Getdate()" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            For Each _Fila As Zw_Stmp_Det In Zw_Stmp_Det

                With _Fila

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Det Set " & vbCrLf &
                                   "Cantidad = " & De_Num_a_Tx_01(.Cantidad, False, 5) & vbCrLf &
                                   ",Caprco1_Real = " & De_Num_a_Tx_01(.Caprco1_Real, False, 5) & vbCrLf &
                                   ",Caprco2_Real = " & De_Num_a_Tx_01(.Caprco2_Real, False, 5) & vbCrLf &
                                   ",Pickeado = " & Convert.ToInt32(.Pickeado) & vbCrLf &
                                   ",EnProceso = " & Convert.ToInt32(.EnProceso) & vbCrLf &
                                   ",CodFuncionario_Pickea = '" & .CodFuncionario_Pickea & "'" & vbCrLf &
                                   "Where Id = " & .Id

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            For Each _Fila As Zw_Stmp_DetPick In Zw_Stmp_DetPick

                With _Fila

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stmp_DetPick (Id_Enc,Idmaeedo,Idmaeddo,Tido,Nudo,Sku,Sku_desc,Tag,Udtrpr,Qty,Loc,Cont) Values " &
                                   "(" & .Id_Enc & "," & .Idmaeedo & "," & .Idmaeddo & ",'" & .Tido & "','" & .Nudo & "','" & .Sku & "','" & .Sku_desc &
                                   "','" & .Tag & "'," & .Udtrpr & "," & De_Num_a_Tx_01(.Qty, False, 5) & ",'" & .Loc & "','" & .Cont & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End With

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Documento grabado correctamente"
            _Mensaje_Stem.Mensaje = "Documento grabado correctamente"

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Zw_Stmp_Enc.Id = 0

            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Crear_Ticket(_Idmaeedo As Integer,
                             _Tido As String,
                             _Nudo As String,
                             _Facturar As Boolean,
                             _FechaParaFacturar As DateTime,
                             _TipoPago As String,
                             _Picker As Boolean,
                             _Empresa As String,
                             _Sucursal As String,
                             _CodFuncionario_Crea As String) As LsValiciones.Mensajes

        Dim _FechaServidor As DateTime = FechaDelServidor()

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Enc Where Idmaeedo = " & _Idmaeedo & " And Tido = '" & _Tido & "' And Nudo = '" & _Nudo & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row) Then
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "El documento ya esta ingresado en el sistema de Ticket Picking (Ticket Nro: " & _Row.Item("Numero") & ")"
            _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            Return _Mensaje
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Docu_Ent",
                                                       "Empresa = '" & _Empresa & "'" &
                                                       " And Idmaeedo = " & _Idmaeedo &
                                                       " And Tido = '" & _Tido & "'" &
                                                       " And Nudo = '" & _Nudo & "'")

        If _Reg = 0 Then

            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
            Dim _TipoEstacion As String = _Global_Row_EstacionBk.Item("TipoEstacion")

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Docu_Ent (Idmaeedo,NombreEquipo,TipoEstacion,Empresa,Modalidad,Tido,Nudo," &
                           "FechaHoraGrab,HabilitadaFac,FunAutorizaFac,Pickear)" & vbCrLf &
                           "Select IDMAEEDO,'" & _NombreEquipo & "','" & _TipoEstacion & "',EMPRESA,'?',TIDO,NUDO,LAHORA,0,'',1" & vbCrLf &
                           "From MAEEDO Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                           "Insert Into " & _Global_BaseBk & "Zw_Docu_Det (Idmaeddo,Idmaeedo,Tido,Nudo,Codigo,Descripcion,RtuVariable)" & vbCrLf &
                           "Select IDMAEDDO,IDMAEEDO,TIDO,NUDO,KOPRCT,NOKOPR,0" & vbCrLf &
                           "From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

        End If

        If _Picker Then
            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Pickear = 1 Where Idmaeedo = " & _Idmaeedo & " And Tido = '" & _Tido & "' And Nudo = '" & _Nudo & "'"
            _Sql.Ej_consulta_IDU(Consulta_sql)
        End If

        Consulta_sql = "Select Edo.IDMAEEDO,Edo.EMPRESA,Edo.TIDO,Edo.NUDO,Edo.ENDO,Edo.SUENDO,Edo.SUDO,Doc.Pickear,HabilitadaFac,FunAutorizaFac,Estaenwms" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Docu_Ent Doc On Edo.IDMAEEDO = Doc.Idmaeedo And Edo.TIDO = Doc.Tido And Edo.NUDO = Doc.Nudo" & vbCrLf &
                       "Where IDMAEEDO = " & _Idmaeedo
        Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row_Documento) Then
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "No se encontro el registro en la tabla MAEEDO, Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO")
            _Mensaje.Detalle = "IDMAEEDO " & _Idmaeedo
            Return _Mensaje
        End If

        If Not _Row_Documento.Item("Pickear") Then
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Este documento no esta marcado para ser Pickeado en la tabla Zw_Docu_Ent"
            _Mensaje.Detalle = "Documento: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Return _Mensaje
        End If

        If Not _Row_Documento.Item("Estaenwms") Then
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Este documento no esta ingresado en el WMS" & vbCrLf &
                                    "Vuelva a intentarlo en 10 segundos y si no se encuentra informe de esta situación al personal de logística"
            _Mensaje.Detalle = "Documento: " & _Row_Documento.Item("TIDO") & "-" & _Row_Documento.Item("NUDO")
            Return _Mensaje
        End If

        Dim _Row_Entidad As DataRow = Fx_Traer_Datos_Entidad(_Row_Documento.Item("ENDO"), _Row_Documento.Item("SUENDO"))
        Dim _Cl_Stem As New Cl_Stmp

        With _Cl_Stem.Zw_Stmp_Enc

            .Empresa = _Empresa
            .Sucursal = _Sucursal
            .Idmaeedo = _Row_Documento.Item("IDMAEEDO")
            .Tido = _Row_Documento.Item("TIDO")
            .Nudo = _Row_Documento.Item("NUDO")
            .Endo = _Row_Documento.Item("ENDO")
            .Suendo = _Row_Documento.Item("SUENDO")
            .CodFuncionario_Crea = _CodFuncionario_Crea
            .FechaCreacion = _FechaServidor
            .Estado = "INGRE" ' Ex PREPA
            .Facturar = _Facturar
            .Fecha_Facturar = _FechaParaFacturar
            .TipoPago = _TipoPago

            Try
                .Secueven = _Row_Entidad.Item("SECUEVEN")
            Catch ex As Exception
                .Secueven = String.Empty

                If _Facturar Then
                    .Secueven = "NFG"
                End If

            End Try

            If .Secueven.Contains("NG") Then .DocEmitir = "GDV"
            If .Secueven.Contains("NB") Then .DocEmitir = "BLV"
            If .Secueven.Contains("NF") Then .DocEmitir = "FCV"

        End With

        Consulta_sql = "Select Ddo.*,Isnull(RtuVariable,0) As RtuVariable From MAEDDO Ddo" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Docu_Det ZDet On Ddo.IDMAEDDO = ZDet.Idmaeddo" & vbCrLf &
                       "Where IDMAEEDO = " & _Row_Documento.Item("IDMAEEDO")
        Dim _Tbl_Detalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        For Each _Fila As DataRow In _Tbl_Detalle.Rows

            Dim _Zw_Stmp_Det As New Zw_Stmp_Det

            With _Zw_Stmp_Det

                .Idmaeedo = _Fila.Item("IDMAEEDO")
                .Idmaeddo = _Fila.Item("IDMAEDDO")
                .Codigo = _Fila.Item("KOPRCT")
                .Descripcion = _Fila.Item("NOKOPR")
                .Nulido = _Fila.Item("NULIDO")
                .Udtrpr = _Fila.Item("UDTRPR")
                .Rludpr = _Fila.Item("RLUDPR")
                .Caprco1_Ori = _Fila.Item("CAPRCO1")
                .Caprco1_Real = 0
                .Udpr = _Fila.Item("UD0" & .Udtrpr & "PR")
                .Ud01pr = _Fila.Item("UD01PR")
                .Caprco2_Ori = _Fila.Item("CAPRCO2")
                .Caprco2_Real = 0
                .Ud02pr = _Fila.Item("UD02PR")
                .Pickeado = False
                .EnProceso = True
                .RtuVariable = _Fila.Item("RtuVariable")

            End With

            _Cl_Stem.Zw_Stmp_Det.Add(_Zw_Stmp_Det)

        Next

        _Mensaje = _Cl_Stem.Fx_Grabar_Nuevo_Tickets

        Return _Mensaje

    End Function
    Function Fx_Revisar_WMSVillar(_Idmaeedo As Integer,
                                  _Tido As String,
                                  _Nudo As String,
                                  _CadenaConexionWms As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Sql_WMS As New Class_SQL(_CadenaConexionWms)

            Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Revisar_Nota_de_venta_activa_en_WMS_Villar
            Consulta_sql = Replace(Consulta_sql, "#Nudo#", _Nudo)

            Dim _Ds As DataSet = _Sql_WMS.Fx_Get_DataSet(Consulta_sql, True, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "Error a extraer datos desde el WMS"
                _Mensaje.Mensaje = _Sql.Pro_Error
                Return _Mensaje
            End If

            _Ds.Tables(0).TableName = "ticket_verde"
            _Ds.Tables(1).TableName = "Detalle"
            _Ds.Tables(2).TableName = "Cabecera"
            _Ds.Tables(3).TableName = "Lineas"
            _Ds.Tables(4).TableName = "Comandos"

            Dim _ticket_verde As DataTable = _Ds.Tables("ticket_verde")
            Dim _Detalle As DataTable = _Ds.Tables("Detalle")
            Dim _Cabecera As DataTable = _Ds.Tables("Cabecera")
            Dim _Lineas As DataTable = _Ds.Tables("Lineas")
            Dim _Comandos As DataTable = _Ds.Tables("Comandos")

            If _ticket_verde.Rows(0).Item("ticket_verde") <> "Y" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

            Dim _ob_type As String = _Cabecera.Rows(0).Item("ob_type")
            Dim _shipment As String = _Cabecera.Rows(0).Item("shipment")
            Dim _wave As String = _Cabecera.Rows(0).Item("wave")
            Dim _whse_id As String = _Cabecera.Rows(0).Item("whse_id")
            Dim _ob_ord_stt As String = _Cabecera.Rows(0).Item("ob_ord_stt").ToString.Trim

            If _ob_ord_stt <> "RDY" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            '_Detalle.Columns.Add("Saldo_qty", GetType(Double))

            Dim _CanalEntrada As String = Mid(_ob_type, 1, 1)
            Dim _TipoPago As String = Mid(_ob_type, 2, 1)
            Dim _Entrega As String = Mid(_ob_type, 3, 1)
            Dim _DocEmitir As String = Mid(_ob_type, 4, 1)

            With Zw_Stmp_Enc

                Select Case _DocEmitir
                    Case "B"
                        .DocEmitir = "BLV"
                    Case "G"
                        .DocEmitir = "GDV"
                    Case "F"
                        .DocEmitir = "FCV"
                End Select

                Select Case _TipoPago
                    Case "C"
                        .TipoPago = "Contado"
                    Case "R"
                        .TipoPago = "Credito"
                End Select

                .Estado = "COMPL"
                .Accion = _ob_type

            End With

            Dim _QuerySql = String.Empty

            If _ticket_verde.Rows(0).Item("ticket_verde") = "Y" Then

                For Each _Fila As DataRow In _Detalle.Rows

                    Dim _Cont As String = _Fila.Item("CONT")
                    Dim _tag As String = _Fila.Item("tag")
                    Dim _loc As String = NuloPorNro(_Fila.Item("loc"), "")

                    Dim _sku As String = _Fila.Item("sku")
                    Dim _qty As Double = _Fila.Item("qty")
                    Dim _Saldo_qty As Double = _Fila.Item("Saldo_qty")

                    Dim _DetPick As New Zw_Stmp_DetPick

                    With _DetPick
                        .Id_Enc = Zw_Stmp_Enc.Id
                        .Idmaeedo = _Idmaeedo
                        .Tido = _Tido
                        .Nudo = _Nudo
                        .Sku = _Fila.Item("sku")
                        .Sku_desc = _Fila.Item("sku_desc")
                        .Tag = _Fila.Item("tag")
                        .Qty = _Fila.Item("qty")
                        .Udtrpr = 1
                        .Loc = _loc
                        .Cont = _Cont
                    End With

                    Zw_Stmp_DetPick.Add(_DetPick)

                Next

                For Each _Det As Zw_Stmp_Det In Zw_Stmp_Det

                    For Each _Fila As DataRow In _Detalle.Rows

                        Dim _Cont As String = _Fila.Item("CONT")
                        Dim _tag As String = _Fila.Item("tag")
                        Dim _loc As String = NuloPorNro(_Fila.Item("loc"), "")

                        Dim _sku As String = _Fila.Item("sku")
                        Dim _qty As Double = _Fila.Item("qty")
                        Dim _Saldo_qty As Double = _Fila.Item("Saldo_qty")

                        If _Det.Codigo.Trim = _sku.Trim And CBool(_Saldo_qty) Then

                            Dim _Cantidad As Double = _Saldo_qty

                            If _Det.Caprco1_Ori < _Cantidad Then
                                _Cantidad = _Det.Caprco1_Ori
                            End If

                            _Saldo_qty = _Saldo_qty - _Cantidad

                            _Det.Cantidad += _Cantidad
                            _Det.Caprco1_Real += _Cantidad
                            _Det.Caprco2_Real += _Cantidad

                            _Fila.Item("Saldo_qty") = _Saldo_qty

                            _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                         "('MAEDDO'," & _Det.Idmaeddo & ",'wms','" & _Fecha & "','wms','CONT','" & _Cont & "')" & vbCrLf &
                                         "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                         "('MAEDDO'," & _Det.Idmaeddo & ",'wms','" & _Fecha & "','wms','tag','" & _tag & "')" & vbCrLf &
                                         "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                         "('MAEDDO'," & _Det.Idmaeddo & ",'wms','" & _Fecha & "','wms','loc','" & _loc & "')" & vbCrLf &
                                         "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                         "('MAEDDO'," & _Det.Idmaeddo & ",'wms','" & _Fecha & "','wms','qty','" & _qty & "')" & vbCrLf

                            If _Det.Caprco1_Real = _Det.Caprco1_Ori Then
                                Exit For
                            End If

                        End If

                    Next

                    If _Det.Caprco1_Real > 0 Then
                        _Det.Pickeado = True
                    End If

                    _Det.EnProceso = False
                    _Det.CodFuncionario_Pickea = "wms"

                Next

                _Mensaje = Fx_Confirmar_Picking()

                If _Mensaje.EsCorrecto Then

                    _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','ob_type','" & _ob_type & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','shipment','" & _shipment & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','wave','" & _wave & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','whse_id','" & _whse_id & "')"

                    _Sql.Ej_consulta_IDU(_QuerySql, False)

                End If

            End If

        Catch ex As Exception

        End Try

        Return _Mensaje

    End Function
    Function Fx_Revisar_WMSVillar_Resp(_Idmaeedo As Integer,
                                  _Tido As String,
                                  _Nudo As String,
                                  _CadenaConexionWms As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Sql_WMS As New Class_SQL(_CadenaConexionWms)

            Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Revisar_Nota_de_venta_activa_en_WMS_Villar
            Consulta_sql = Replace(Consulta_sql, "#Nudo#", _Nudo)

            Dim _Ds As DataSet = _Sql_WMS.Fx_Get_DataSet(Consulta_sql)

            _Ds.Tables(0).TableName = "ticket_verde"
            _Ds.Tables(1).TableName = "Detalle"
            _Ds.Tables(2).TableName = "Cabecera"
            _Ds.Tables(3).TableName = "Lineas"
            _Ds.Tables(4).TableName = "Comandos"

            Dim _ticket_verde As DataTable = _Ds.Tables("ticket_verde")
            Dim _Detalle As DataTable = _Ds.Tables("Detalle")
            Dim _Cabecera As DataTable = _Ds.Tables("Cabecera")
            Dim _Lineas As DataTable = _Ds.Tables("Lineas")
            Dim _Comandos As DataTable = _Ds.Tables("Comandos")

            If _ticket_verde.Rows(0).Item("ticket_verde") <> "Y" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

            Dim _ob_type As String = _Cabecera.Rows(0).Item("ob_type")
            Dim _shipment As String = _Cabecera.Rows(0).Item("shipment")
            Dim _wave As String = _Cabecera.Rows(0).Item("wave")
            Dim _whse_id As String = _Cabecera.Rows(0).Item("whse_id")
            Dim _ob_ord_stt As String = _Cabecera.Rows(0).Item("ob_ord_stt").ToString.Trim

            If _ob_ord_stt <> "RDY" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            '_Detalle.Columns.Add("Saldo_qty", GetType(Double))

            Dim _CanalEntrada As String = Mid(_ob_type, 1, 1)
            Dim _TipoPago As String = Mid(_ob_type, 2, 1)
            Dim _Entrega As String = Mid(_ob_type, 3, 1)
            Dim _DocEmitir As String = Mid(_ob_type, 4, 1)

            With Zw_Stmp_Enc

                Select Case _DocEmitir
                    Case "B"
                        .DocEmitir = "BLV"
                    Case "G"
                        .DocEmitir = "GDV"
                    Case "F"
                        .DocEmitir = "FCV"
                End Select

                Select Case _TipoPago
                    Case "C"
                        .TipoPago = "Contado"
                    Case "R"
                        .TipoPago = "Credito"
                End Select

                .Estado = "COMPL"
                .Accion = _ob_type

            End With

            Dim _QuerySql = String.Empty

            If _ticket_verde.Rows(0).Item("ticket_verde") = "Y" Then

                For Each _Fila As DataRow In _Detalle.Rows

                    Dim _Cont As String = _Fila.Item("CONT")
                    Dim _tag As String = _Fila.Item("tag")
                    Dim _loc As String = NuloPorNro(_Fila.Item("loc"), "")

                    Dim _sku As String = _Fila.Item("sku")
                    Dim _qty As Double = _Fila.Item("qty")
                    Dim _Saldo_qty As Double = _Fila.Item("Saldo_qty")

                    Dim _DetPick As New Zw_Stmp_DetPick

                    With _DetPick
                        .Id_Enc = Zw_Stmp_Enc.Id
                        .Idmaeedo = _Idmaeedo
                        .Tido = _Tido
                        .Nudo = _Nudo
                        .Sku = _Fila.Item("sku")
                        .Sku_desc = _Fila.Item("sku_desc")
                        .Tag = _Fila.Item("tag")
                        .Qty = _Fila.Item("qty")
                        .Udtrpr = 1
                        .Loc = _loc
                        .Cont = _Cont
                    End With

                    Zw_Stmp_DetPick.Add(_DetPick)

                    For Each _Det As Zw_Stmp_Det In Zw_Stmp_Det

                        If _Det.Codigo.Trim = _sku.Trim And _Det.EnProceso Then

                            With _Det

                                Dim _Cantidad As Double = _Saldo_qty - .Caprco1_Real

                                .Cantidad += _Cantidad
                                .Caprco1_Real += _Cantidad
                                .Caprco2_Real += _Cantidad

                                _Saldo_qty = _Cantidad - _Saldo_qty

                                _Fila.Item("Saldo_qty") = _Saldo_qty

                                If _Fila.Item("Saldo_qty") = 0 Then

                                    .Pickeado = True
                                    .EnProceso = False

                                End If

                                If .Pickeado Then

                                    .CodFuncionario_Pickea = "wms"

                                    _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','CONT','" & _Cont & "')" & vbCrLf &
                                             "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','tag','" & _tag & "')" & vbCrLf &
                                             "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','loc','" & _loc & "')" & vbCrLf &
                                             "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','qty','" & _qty & "')" & vbCrLf

                                End If

                                If _Saldo_qty = 0 Then
                                    Exit For
                                End If

                            End With

                        End If

                    Next

                Next

                _Mensaje = Fx_Confirmar_Picking()

                If _Mensaje.EsCorrecto Then

                    _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','ob_type','" & _ob_type & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','shipment','" & _shipment & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','wave','" & _wave & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','whse_id','" & _whse_id & "')"

                    _Sql.Ej_consulta_IDU(_QuerySql, False)

                End If

            End If

        Catch ex As Exception

        End Try

        Return _Mensaje

    End Function
    Function Fx_Revisar_WMSVillar2(_Idmaeedo As Integer,
                                  _Nudo As String,
                                  _CadenaConexionWms As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Sql_WMS As New Class_SQL(_CadenaConexionWms)

            Consulta_sql = My.Resources.Recursos_WmsVillar.SQLQuery_Revisar_Nota_de_venta_activa_en_WMS_Villar
            Consulta_sql = Replace(Consulta_sql, "#Nudo#", _Nudo)

            Dim _Ds As DataSet = _Sql_WMS.Fx_Get_DataSet(Consulta_sql)

            _Ds.Tables(0).TableName = "ticket_verde"
            _Ds.Tables(1).TableName = "Detalle"
            _Ds.Tables(2).TableName = "Cabecera"
            _Ds.Tables(3).TableName = "Lineas"
            _Ds.Tables(4).TableName = "Comandos"

            Dim _ticket_verde As DataTable = _Ds.Tables("ticket_verde")
            Dim _Detalle As DataTable = _Ds.Tables("Detalle")
            Dim _Cabecera As DataTable = _Ds.Tables("Cabecera")
            Dim _Lineas As DataTable = _Ds.Tables("Lineas")
            Dim _Comandos As DataTable = _Ds.Tables("Comandos")

            If _ticket_verde.Rows(0).Item("ticket_verde") <> "Y" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

            Dim _ob_type As String = _Cabecera.Rows(0).Item("ob_type")
            Dim _shipment As String = _Cabecera.Rows(0).Item("shipment")
            Dim _wave As String = _Cabecera.Rows(0).Item("wave")
            Dim _whse_id As String = _Cabecera.Rows(0).Item("whse_id")
            Dim _ob_ord_stt As String = _Cabecera.Rows(0).Item("ob_ord_stt").ToString.Trim

            If _ob_ord_stt <> "RDY" Then
                _Mensaje.EsCorrecto = False
                _Mensaje.Detalle = "El pedido aun no esta listo"
                Return _Mensaje
            End If

            Dim _CanalEntrada As String = Mid(_ob_type, 1, 1)
            Dim _TipoPago As String = Mid(_ob_type, 2, 1)
            Dim _Entrega As String = Mid(_ob_type, 3, 1)
            Dim _DocEmitir As String = Mid(_ob_type, 4, 1)

            With Zw_Stmp_Enc

                Select Case _DocEmitir
                    Case "B"
                        .DocEmitir = "BLV"
                    Case "G"
                        .DocEmitir = "GDV"
                    Case "F"
                        .DocEmitir = "FCV"
                End Select

                Select Case _TipoPago
                    Case "C"
                        .TipoPago = "Contado"
                    Case "R"
                        .TipoPago = "Credito"
                End Select

                .Estado = "COMPL"

            End With

            Dim _QuerySql = String.Empty

            If _ticket_verde.Rows(0).Item("ticket_verde") = "Y" Then

                For Each _Fila As DataRow In _Detalle.Rows

                    Dim _CONT As String = _Fila.Item("CONT")
                    Dim _tag As String = _Fila.Item("tag")
                    Dim _loc As String = NuloPorNro(_Fila.Item("loc"), "...")

                    Dim _sku As String = _Fila.Item("sku")
                    Dim _qty As Double = _Fila.Item("qty")

                    For Each _Det As Zw_Stmp_Det In Zw_Stmp_Det

                        If _Det.Codigo.Trim = _sku.Trim Then

                            With _Det

                                .Cantidad = _qty
                                .Caprco1_Real = _qty
                                .Caprco2_Real = _qty
                                .Pickeado = True
                                .EnProceso = False
                                .CodFuncionario_Pickea = "wms"

                                _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','CONT','" & _CONT & "')" & vbCrLf &
                                             "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','tag','" & _tag & "')" & vbCrLf &
                                             "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                             "('MAEDDO'," & .Idmaeddo & ",'wms','" & _Fecha & "','wms','loc','" & _loc & "')" & vbCrLf

                            End With

                            Exit For

                        End If

                    Next

                Next

                _Mensaje = Fx_Confirmar_Picking()
                'ob_type, shipment, wave, ,whse_id
                If _Mensaje.EsCorrecto Then

                    _QuerySql += "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','ob_type','" & _ob_type & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','shipment','" & _shipment & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','wave','" & _wave & "')" & vbCrLf &
                                 "Insert Into MEVENTO (ARCHIRVE,IDRVE,KOFU,FEVENTO,KOTABLA,KOCARAC,NOKOCARAC) Values " &
                                 "('MAEEDO'," & _Idmaeedo & ",'wms','" & _Fecha & "','wms','whse_id','" & _whse_id & "')"

                    _Sql.Ej_consulta_IDU(_QuerySql, False)

                End If

            End If

        Catch ex As Exception

        End Try

        Return _Mensaje

    End Function
    Function Fx_Entregar_Mercaderia() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stmp_Enc

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Estado = '" & .Estado & "'" &
                               ",FechaEntrega = Getdate()" &
                               ",CodFuncionario_Entrega = '" & .CodFuncionario_Entrega & "'" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Documento entrega correctamente"
            _Mensaje_Stem.Mensaje = "Documento cerrado y entrega correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop
            _Zw_Stmp_Enc.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function
    Function Fx_EnviarAPerparacionPlanificar() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stmp_Enc

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Estado = '" & .Estado & "'" &
                               ",Planificada = " & Convert.ToInt32(.Planificada) &
                               ",FechaPlanificacion = Getdate()" &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Planificar/Preparar"
            _Mensaje_Stem.Mensaje = "Documento en preparación"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop
            _Zw_Stmp_Enc.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function
    Function Fx_Cerrar_Ticket() As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stmp_Enc

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Estado = '" & .Estado & "'" &
                               ",FechaCierre = Getdate()" &
                               ",CodFuncionario_Cierra = '" & .CodFuncionario_Cierra & "'" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Detalle = "Documento entrega correctamente"
            _Mensaje_Stem.Mensaje = "Documento cerrado y entrega correctamente"
            _Mensaje_Stem.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Mensaje_Stem.Icono = MessageBoxIcon.Stop
            _Zw_Stmp_Enc.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_Grabar_Permiso(Zw_Stmp_Enc_Permisos As Zw_Stmp_Enc_Permisos) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Fx_Llenar_Permiso(Zw_Stmp_Enc_Permisos.Id_Enc, Zw_Stmp_Enc_Permisos.CodPermiso)

        If _Mensaje.EsCorrecto Then
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Permiso ya existe"
            _Mensaje.Mensaje = "Este permiso ya fue otorgado al registro actual"
            _Mensaje.Icono = MessageBoxIcon.Information
            Return _Mensaje
        End If

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_Stmp_Enc_Permisos

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stmp_Enc_Permisos (Id_Enc,CodPermiso,NroRemota,CodFuncionario_Solicita,CodFuncionario_Autoriza,FechaHora) Values " & vbCrLf &
                               "(" & .Id_Enc & ",'" & .CodPermiso & "','" & .NroRemota & "','" & .CodFuncionario_Solicita & "','" & .CodFuncionario_Autoriza & "',Getdate())"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Permiso grabado correctamente"
            _Mensaje.Mensaje = "Permiso grabado correctamente"

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar permiso"
            _Mensaje.Mensaje = ex.Message
            _Zw_Stmp_Enc.Id = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

End Class


Namespace Stmp_BD

    Public Enum EnumAcciones
        <Description("Defaul sin valor")>
        Defaul = 0

        <Description("Acepta Contenido del Documento")>
        ACD_AceptaContenidoDocumento = 1

        <Description("Reclamo al Contenido del Documento")>
        RCD_ReclamoContenidoDocumento = 2

        <Description("Otorga Recibo de Mercaderías o Servicios")>
        ERM_OtorgaReciboMercaderiasServicios = 3

        <Description("Reclamo por Falta Parcial de Mercaderías")>
        RFP_ReclamoFaltaParcialMercaderias = 4

        <Description("Reclamo por Falta Total de Mercaderías")>
        RFT_ReclamoFaltaTotalMercaderias = 5
    End Enum

End Namespace
