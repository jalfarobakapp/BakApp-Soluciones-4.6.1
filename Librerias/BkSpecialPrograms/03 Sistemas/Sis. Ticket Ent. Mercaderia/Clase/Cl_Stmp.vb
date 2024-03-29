Imports BkSpecialPrograms.Stmp_BD
Imports BkSpecialPrograms.Tickets_Db
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Cl_Stmp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Stem_Enc As New Stmp_BD.Stmp_Enc
    Public Property Stem_Det As New List(Of Stmp_BD.Stmp_Det)

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

        With Stem_Enc

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

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function

    Function Fx_Llenar_Detalle(_Id_Enc As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stmp_Det Where Id_Enc = " & _Id_Enc
        Dim _Tbl_Det As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not CBool(_Tbl_Det.Rows.Count) Then

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = "No se encontraron registros en la tabla Zw_Stmp_Det con el Id_Enc " & _Id_Enc

            Return _Mensaje_Stem

        End If

        For Each _Fila As DataRow In _Tbl_Det.Rows

            Dim _Stem_Det As New Stmp_BD.Stmp_Det

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

            End With

            Stem_Det.Add(_Stem_Det)

        Next


        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registros cargados correctamente"

        Return _Mensaje_Stem

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

            With _Stem_Enc

                .Numero = Fx_NvoNro_Stmp()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stmp_Enc (Empresa,Sucursal,Numero,CodFuncionario_Crea,Idmaeedo,Tido," &
                               "Nudo,Endo,Suendo,FechaCreacion,Estado,Secueven,Facturar,FechaParaFacturar) Values " &
                       "('" & .Empresa & "','" & .Sucursal & "','" & .Numero & "','" & .CodFuncionario_Crea & "'," & .Idmaeedo &
                       ",'" & .Tido & "','" & .Nudo & "','" & .Endo & "','" & .Suendo & "','" & Format(.FechaCreacion, "yyyyMMdd hh:mm") & "'" &
                       ",'" & .Estado & "','" & .Secueven & "'," & Convert.ToInt32(.Facturar) & ",'" & Format(.FechaParaFacturar, "yyyyMMdd") & "')"

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

            For Each _Fila As Stmp_BD.Stmp_Det In _Stem_Det

                With _Fila

                    .Id_Enc = _Stem_Enc.Id

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
            _Mensaje_Stem.Detalle = "Se crea Ticket Nro " & _Stem_Enc.Numero & " - (" & _Stem_Enc.Tido & "-" & _Stem_Enc.Nudo & ")"
            _Mensaje_Stem.Mensaje = "Documento grabado correctamente"

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Stem_Enc.Id = 0

            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

    End Function

    Function Fx_NvoNro_Stmp() As String

        Dim _NvoNro_Stem As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stmp_Enc")

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
            Dim _Tbl_Det As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

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

            With _Stem_Enc

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " & vbCrLf &
                               "Estado = '" & .Estado & "', FechaPickeado = Getdate()" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            For Each _Fila As Stmp_BD.Stmp_Det In _Stem_Det

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

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Stem.EsCorrecto = True
            _Mensaje_Stem.Mensaje = "Documento grabado correctamente"

        Catch ex As Exception

            _Mensaje_Stem.EsCorrecto = False
            _Mensaje_Stem.Mensaje = ex.Message
            _Stem_Enc.Id = 0

            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje_Stem

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

    ''' <summary>
    ''' Encabezado de documento Stmp (Sistema de ticket de mercaderia por Picking)
    ''' </summary>
    Public Class Stmp_Enc

        Public Property Id As Integer
        Public Property Empresa As String
        Public Property Sucursal As String
        Public Property Numero As String
        Public Property CodFuncionario_Crea As String
        Public Property Idmaeedo As Integer
        Public Property Tido As String
        Public Property Nudo As String
        Public Property Endo As String
        Public Property Suendo As String
        Public Property FechaCreacion As DateTime
        Public Property Estado As String
        Public Property FechaPickeado As DateTime
        Public Property FechaCierre As DateTime
        Public Property Accion As String
        Public Property Secueven As String
        Public Property TipoPago As String
        Public Property Facturar As Boolean
        Public Property FechaParaFacturar As DateTime
        Public Property TipoGen As String

    End Class

    'Partial Public Class Stmp_Enc

    '    Public Property HabilitadaFac As Boolean
    '    Public Property FunAutorizaFac As Boolean

    'End Class

    ''' <summary>
    ''' Detalle de documento Stmp (Sistema de ticket de mercaderia por Picking)
    ''' </summary>
    Public Class Stmp_Det

        Public Property Id As Integer
        Public Property Id_Enc As Integer
        Public Property Idmaeedo As Integer
        Public Property Idmaeddo As Integer
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Nulido As String
        Public Property Udtrpr As Integer
        Public Property Rludpr As Double
        Public Property RtuVariable As Boolean
        Public Property Rlud_Real As Double
        Public Property Udpr As String
        Public Property Cantidad As Double
        Public Property Caprco1_Ori As Double
        Public Property Caprco1_Real As Double
        Public Property Ud01pr As String
        Public Property Caprco2_Ori As Double
        Public Property Caprco2_Real As Double
        Public Property Ud02pr As String
        Public Property Pickeado As Boolean
        Public Property CodFuncionario_Pickea As String
        Public Property EnProceso As Boolean

    End Class

    'Public Class Mensaje_Stmp

    '    Public Property EsCorrecto As Boolean
    '    Public Property Mensaje As String

    'End Class

End Namespace
