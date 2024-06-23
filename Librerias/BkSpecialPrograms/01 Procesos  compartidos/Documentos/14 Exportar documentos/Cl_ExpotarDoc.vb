Imports System.Data.SqlClient

Namespace Bk_ExpotarDoc
    Public Class Cl_ExpotarDoc

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Public Sub New()

        End Sub

        Function Fx_Importar_Documento(_Idmaeedo_Desde As Integer,
                                       _Id_Conexion As Integer,
                                       _Cambiar_NroDocumento As Boolean,
                                       _Modalidad As String) As Bk_ExpotarDoc.Respuesta

            Dim _Respuestas As New Bk_ExpotarDoc.Respuesta

            _Respuestas.EsCorrecto = False
            _Respuestas.Mensajes = New List(Of String)
            _Respuestas.Idmaeedo = 0

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
            Dim _Row_DnExt As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Servidor = _Row_DnExt.Item("Servidor")
            Dim _Puerto = _Row_DnExt.Item("Puerto")
            Dim _Usuario = _Row_DnExt.Item("Usuario")
            Dim _Clave = _Row_DnExt.Item("Clave")
            Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")
            Dim _Empresa = _Row_DnExt.Item("Empresa")

            Dim _ServidorPuerto As String = _Servidor

            If Not String.IsNullOrEmpty(_Puerto) Then
                _ServidorPuerto = _Servidor & "," & _Puerto
            End If

            Dim _Cadena_ConexionSQL_Server_Destino = "data " &
                                            "source = " & _ServidorPuerto & "; " &
                                            "initial catalog = " & _BaseDeDatos & "; " &
                                            "user id = " & _Usuario & "; " &
                                            "password = " & _Clave

            Dim _NewIdmaeedo As Integer = 0

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select MAEEN.* From MAEEN 
                                   Inner Join MAEEDO On ENDO = KOEN And SUENDO = SUEN 
                                        Where IDMAEEDO = " & _Idmaeedo_Desde

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

            _Ds.Tables(0).TableName = "Maeedo"
            _Ds.Tables(1).TableName = "Maeddo"
            _Ds.Tables(2).TableName = "Maeimli"
            _Ds.Tables(3).TableName = "Maedtli"
            _Ds.Tables(4).TableName = "Maeedoob"
            _Ds.Tables(5).TableName = "Maeven"

            Dim _Tido As String
            Dim _Nudo As String
            Dim _ProxNumero As String

            If _Cambiar_NroDocumento Then
                _ProxNumero = _Sql.Fx_Trae_Dato("CONFIEST", "OCC", "EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & Modalidad & "'")
            End If

            ' _Cadena_ConexionSQL_Server_Destino = "data source = 190.171.153.139,1451; initial catalog = SUPERMERCADO_SPA; user id = SUPERMERCADO_SPA; password = SUPERMERCADO_SPA"

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(_Cadena_ConexionSQL_Server_Destino)

            For Each _Fl As DataRow In _Ds.Tables(1).Rows

                Dim _Suc = _Fl.Item("SULIDO")
                Dim _Bod = _Fl.Item("BOSULIDO")
                Dim _Koprct = _Fl.Item("KOPRCT")

                Consulta_Sql = "Insert Into MAEST (EMPRESA,KOSU,KOBO,KOPR) Values ('" & _Empresa & "','" & _Suc & "','" & _Bod & "','" & _Koprct & "')"
                SQL_ServerClass.Ej_consulta_IDU(Consulta_Sql, False)

            Next

            Try

                Dim _Fila_Encabezado As DataRow = _Ds.Tables("Maeedo").Rows(0)

                _Tido = _Fila_Encabezado.Item("TIDO")
                _Nudo = _Fila_Encabezado.Item("NUDO")

                SQL_ServerClass.Sb_Abrir_Conexion(cn2)

                Consulta_Sql = "Select * From CONFIGP Where EMPRESA = '" & _Empresa & "'"
                _Respuestas.RowEmpresa = SQL_ServerClass.Fx_Get_DataRow(Consulta_Sql)

                Dim _Reg As Boolean = CBool(SQL_ServerClass.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"))

                If _Reg Then
                    Throw New System.Exception("El documento " & _Tido & "-" & _Nudo & " ya existe en la base de datos.")
                End If

                myTrans = cn2.BeginTransaction()

                Dim _Subtido = _Fila_Encabezado.Item("SUBTIDO")

                Consulta_Sql = Fx_Crear_Registro(0, _Fila_Encabezado, _Ds, "Maeedo", "EMPRESA", "IDMAEEDO", "IDMAEEDO")

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _NewIdmaeedo = dfd1("Identity")
                End While
                dfd1.Close()

                Consulta_Sql = String.Empty

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeddo").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maeddo", "IDMAEEDO", "IDMAEDDO", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    'Dim _Empresa = _Fila_Detalle.Item("EMPRESA")
                    Dim _Sulido = _Fila_Detalle.Item("SULIDO")
                    Dim _Bosulido = _Fila_Detalle.Item("BOSULIDO")
                    Dim _Koprct = _Fila_Detalle.Item("KOPRCT")
                    'Dim _Tido = _Fila_Detalle.Item("TIDO")
                    Dim _Tidopa = _Fila_Detalle.Item("TIDOPA")

                    Dim _Prct = Convert.ToInt32(_Fila_Detalle.Item("PRCT"))
                    Dim _Tipr = _Fila_Detalle.Item("TIPR")
                    Dim _Lincondesp = Convert.ToInt32(_Fila_Detalle.Item("LINCONDESP"))
                    Dim _Caprco1 = De_Num_a_Tx_01(_Fila_Detalle.Item("CAPRCO1"), False, 5)
                    Dim _Caprco2 = De_Num_a_Tx_01(_Fila_Detalle.Item("CAPRCO2"), False, 5)

                    If Not _Prct And _Tipr <> "SSN" Then

                        Dim _Campos_StockAd_Tido = Fx_Campo_Mov_Stock_Adicional_Suma(_Tido, _Subtido, _Lincondesp, _Tidopa)

                        ' ACA SE AUMENTAN LOS STOCK CORRESPONDINTE AL DOCUMENTO DE SALIDA O DE INGRESO

                        If CBool(_Campos_StockAd_Tido.Count) Then

                            Dim _Campo_StockUd1 = _Campos_StockAd_Tido(0)
                            Dim _Campo_StockUd2 = _Campos_StockAd_Tido(1)

                            Consulta_Sql = "UPDATE MAEST SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                         _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                       "WHERE EMPRESA='" & _Empresa &
                                                       "' AND KOSU='" & _Sulido &
                                                       "' AND KOBO='" & _Bosulido &
                                                       "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPREM SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                           "WHERE EMPRESA='" & _Empresa &
                                                           "' AND KOPR='" & _Koprct & "'" & vbCrLf &
                                           "UPDATE MAEPR SET " & _Campo_StockUd1 & " = " & _Campo_StockUd1 & " +" & _Caprco1 & "," &
                                                           _Campo_StockUd2 & " = " & _Campo_StockUd2 & " + " & _Caprco2 & vbCrLf &
                                                           "WHERE KOPR='" & _Koprct & "'"

                            Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End If


                Next

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeimli").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maeimli", "IDMAEEDO", "IDMAEIMLI", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maedtli").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maedtli", "IDMAEEDO", "IDMAEDTLI", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeedoob").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maeedoob", "IDMAEEDO", "", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeven").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maeven", "IDMAEVEN", "IDMAEVEN", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeven").Rows

                    Consulta_Sql = Fx_Crear_Registro(_NewIdmaeedo, _Fila_Detalle, _Ds, "Maeven", "IDMAEVEN", "IDMAEVEN", "IDMAEEDO")
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                Consulta_Sql = "Update MAEEDO Set EMPRESA = '" & _Empresa & "' Where IDMAEEDO = " & _NewIdmaeedo & vbCrLf &
                               "Update MAEDDO Set EMPRESA = '" & _Empresa & "' Where IDMAEEDO = " & _NewIdmaeedo
                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                _Respuestas.EsCorrecto = True
                _Respuestas.Idmaeedo = _NewIdmaeedo
                _Respuestas.Mensajes.Add("Se graba " & _Tido & "-" & _Nudo)

                '_Cambiar_NroDocumento = False

                'Consulta_Sql = "Update MAEEDO Set NUDO = 'OCC0000001' Where IDMAEEDO = " & _NewIdmaeedo
                'Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

                'Consulta_Sql = "Update MAEDDO Set NUDO = 'OCC0000001' Where IDMAEEDO = " & _NewIdmaeedo
                'Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

                If _Cambiar_NroDocumento Then

                    If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                        Consulta_Sql = "UPDATE CONFIEST SET " &
                                       "GDV = '" & _ProxNumero & "'," & vbCrLf &
                                       "GTI = '" & _ProxNumero & "'," & vbCrLf &
                                       "GDP = '" & _ProxNumero & "'," & vbCrLf &
                                       "GDD = '" & _ProxNumero & "'" & vbCrLf &
                                       "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    Else
                        Consulta_Sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                        "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                    End If

                    If Not String.IsNullOrEmpty(Consulta_Sql) Then

                        Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        _Respuestas.Mensajes.Add("Se Cambia la numeración de " & _Tido & ": " & _ProxNumero & " en la modalidad: " & _Modalidad)

                    End If

                End If

                'If False Then
                'Throw New System.Exception("An exception has occurred.")
                'End If

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Catch ex As Exception

                _Respuestas.EsCorrecto = False
                _Respuestas.Idmaeedo = 0
                _Respuestas.Mensajes.Clear()
                _Respuestas.Mensajes.Add(ex.Message)

                If Not IsNothing(myTrans) Then
                    _Respuestas.Mensajes.Add(ex.StackTrace)
                    myTrans.Rollback()
                End If

                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            End Try

            Return _Respuestas

        End Function

        Function Fx_Trae_Valor(_Fila As DataRow, _Columna As DataColumn) As Object

            Dim _Valor As Object
            Dim _NomColumna As String = _Columna.ColumnName

            If _NomColumna = "SEMILLA" Then
                Dim _Aca = 0
            End If

            If _NomColumna <> "IDMAEEDO" Then
                If _Columna.DataType.Name = "String" Then
                    _Valor = "'" & _Fila.Item(_NomColumna) & "'"
                ElseIf _Columna.DataType.Name = "DateTime" Then

                    Dim _Fecha As Date

                    Try
                        _Fecha = _Fila.Item(_NomColumna)
                        _Valor = "'" & Format(_Fecha, "yyyyMMdd") & "'"
                    Catch ex As Exception
                        _Valor = "Null"
                    End Try

                ElseIf _Columna.DataType.Name = "Double" Or
                        _Columna.DataType.Name = "Int32" Or
                        _Columna.DataType.Name = "Decimal" Then
                    If ((_Fila.Item(_NomColumna) Is DBNull.Value) OrElse (_Fila.Item(_NomColumna) Is Nothing)) Then
                        _Valor = "Null"
                    Else
                        _Valor = De_Num_a_Tx_01(_Fila.Item(_NomColumna), False, 5)
                    End If
                ElseIf _Columna.DataType.Name = "Boolean" Then
                    _Valor = Convert.ToInt32(_Fila.Item(_NomColumna))
                Else

                End If
            End If

            Return _Valor

        End Function

        Function Fx_Crear_Registro(_NewIdmaeedo As Integer,
                                   _Fila As DataRow,
                                   _Ds As DataSet,
                                   _NomTabla As String,
                                   _NomColum1 As String,
                                   _NomColumNoIncluye As String,
                                   _NomColumIdPadre As String) As String

            Dim Consulta_Sql As String

            Consulta_Sql += "Insert Into " & _NomTabla.ToUpper & " ("

            For Each _Columna As DataColumn In _Ds.Tables(_NomTabla).Columns
                If _Columna.ColumnName <> _NomColumNoIncluye Then
                    If _Columna.ColumnName = _NomColum1 Then
                        Consulta_Sql += _Columna.ColumnName
                    Else
                        Consulta_Sql += "," & _Columna.ColumnName
                    End If
                End If
            Next

            Consulta_Sql += ") Values ("

            For Each _Columna As DataColumn In _Ds.Tables(_NomTabla).Columns

                Dim _Valor = Me.Fx_Trae_Valor(_Fila, _Columna)

                Dim _NomColumna As String = _Columna.ColumnName

                If _NomColumna <> _NomColumNoIncluye Then
                    If _NomColumna = _NomColum1 Then
                        If _NomColum1 = _NomColumIdPadre Then
                            _Valor = _NewIdmaeedo
                        End If
                        Consulta_Sql += "" & _Valor
                    Else
                        Consulta_Sql += "," & _Valor
                    End If
                End If

            Next

            Consulta_Sql += ")" & vbCrLf

            Return Consulta_Sql

        End Function

        Function Fx_Campo_Mov_Stock_Adicional_Suma(_Tido As String,
                                                   _Subtido As String,
                                                   _Lincondesp As Boolean,
                                                   _Tidopa As String) As List(Of String)

            Dim _TidoSubtido As String = _Tido.Trim() & _Subtido.Trim
            Dim _Campos As New List(Of String)

            Select Case _Tido

                Case "FCV", "FDB", "FDV", "FDX", "FEV", "FVL", "FVT", "FVX", "BLV"

                    If Not _Lincondesp And Not (_Tidopa = "GDV" Or _Tidopa = "GDP") Then
                        _Campos.Add("STDV1")
                        _Campos.Add("STDV2")
                    End If

                Case "GDV"

                    If String.IsNullOrEmpty(_Tidopa) Or _Tidopa = "NVV" Or _Tidopa = "COV" Then
                        _Campos.Add("DESPNOFAC1")
                        _Campos.Add("DESPNOFAC2")
                    End If

                Case "GDP"

                    If _Subtido = "PRE" Then
                        _Campos.Add("PRESALCLI1")
                        _Campos.Add("PRESALCLI2")
                    End If

                    If _Subtido = "CON" Then
                        _Campos.Add("CONSALCLI1")
                        _Campos.Add("CONSALCLI2")
                    End If

                Case "OCI", "OCC"

                    _Campos.Add("STOCNV1C")
                    _Campos.Add("STOCNV2C")

                Case "NVI", "NVV"

                    _Campos.Add("STOCNV1")
                    _Campos.Add("STOCNV2")

                Case "GRC"

                    If _Tidopa <> "FCC" Then
                        _Campos.Add("RECENOFAC1")
                        _Campos.Add("RECENOFAC2")
                    End If

                Case "FCC"

                    If Not _Lincondesp And _Tidopa <> "GRC" Then
                        _Campos.Add("STDV1C")
                        _Campos.Add("STDV1C")
                    End If

                Case "GTI"

                    _Campos.Add("STTR1")
                    _Campos.Add("STTR2")

                Case "GDD"

                    If _Subtido = String.Empty Then
                        _Campos.Add("DEVSINNCC1")
                        _Campos.Add("DEVSINNCC2")
                    End If

                    If _Subtido = "PRE" Then
                        _Campos.Add("PRESDEPRO1")
                        _Campos.Add("PRESDEPRO2")
                    End If

                    If _Subtido = "CON" Then
                        _Campos.Add("CONSDEPRO1")
                        _Campos.Add("CONSDEPRO2")
                    End If

                Case "GRD"

                    If _Tidopa <> "NCV" Then
                        _Campos.Add("DEVSINNCV1")
                        _Campos.Add("DEVSINNCV2")
                    End If

            End Select

            Return _Campos

        End Function

        Private Function Fx_Cambiar_Numeracion_Modalidad(_Tido As String,
                                                         _Nudo As String,
                                                         _Empresa As String,
                                                         _Modalidad As String) As String

            ' _Modalidad = "  "

            Dim _Consulta_sql = "Select Top 1 " & _Tido & " From CONFIEST Where MODALIDAD = '" & _Modalidad & "' And EMPRESA = '" & _Empresa & "'"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(_Consulta_sql)

            Dim _Nudo_Modalidad As String

            _Consulta_sql = String.Empty

            If CBool(_Tbl.Rows.Count) Then

                _Nudo_Modalidad = _Tbl.Rows(0).Item(_Tido).ToString.Trim

                If String.IsNullOrEmpty(_Nudo_Modalidad) Then
                    _Consulta_sql = Fx_Cambiar_Numeracion_Modalidad(_Tido, _Nudo, _Empresa, "  ")
                ElseIf _Nudo_Modalidad = "0000000000" Then
                    _Consulta_sql = String.Empty
                Else

                    Dim Continua As Boolean = True

                    If Not String.IsNullOrEmpty(Trim(_Nudo_Modalidad)) Then

                        Dim _ProxNumero = Fx_Proximo_NroDocumento(_Nudo, 10)

                        If _Tido = "GDV" Or _Tido = "GTI" Or _Tido = "GDP" Or _Tido = "GDD" Then

                            _Consulta_sql = "UPDATE CONFIEST SET " &
                                            "GDV = '" & _ProxNumero & "'," & vbCrLf &
                                            "GTI = '" & _ProxNumero & "'," & vbCrLf &
                                            "GDP = '" & _ProxNumero & "'," & vbCrLf &
                                            "GDD = '" & _ProxNumero & "'" & vbCrLf &
                                            "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                        Else
                            _Consulta_sql = "UPDATE CONFIEST SET " & _Tido & " = '" & _ProxNumero & "'" & vbCrLf &
                                        "WHERE EMPRESA = '" & _Empresa & "' AND  MODALIDAD = '" & _Modalidad & "'"
                        End If

                    End If

                End If

            End If

            Return _Consulta_sql

        End Function


        Function Fx_CrearNVVDesdeOCC(_Idmaeedo_Desde As Integer,
                                     _Endo_Ori As String,
                                     _Suendo_Ori As String,
                                     _Id_Conexion As Integer) As Bk_ExpotarDoc.Respuesta

            Dim _Respuestas As New Bk_ExpotarDoc.Respuesta

            _Respuestas.EsCorrecto = False
            _Respuestas.Mensajes = New List(Of String)
            _Respuestas.Idmaeedo = 0

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_DbExt_Conexion Where Id = " & _Id_Conexion
            Dim _Row_DnExt As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Servidor = _Row_DnExt.Item("Servidor")
            Dim _Puerto = _Row_DnExt.Item("Puerto")
            Dim _Usuario = _Row_DnExt.Item("Usuario")
            Dim _Clave = _Row_DnExt.Item("Clave")
            Dim _BaseDeDatos = _Row_DnExt.Item("BaseDeDatos")
            Dim _Empresa = _Row_DnExt.Item("Empresa")

            Dim _ServidorPuerto As String = _Servidor

            If Not String.IsNullOrEmpty(_Puerto) Then
                _ServidorPuerto = _Servidor & "," & _Puerto
            End If

            Dim _Cadena_ConexionSQL_Server_Destino = "data " &
                                            "source = " & _ServidorPuerto & "; " &
                                            "initial catalog = " & _BaseDeDatos & "; " &
                                            "user id = " & _Usuario & "; " &
                                            "password = " & _Clave

            Dim _Id_Enc As Integer = 0

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEDDO Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select * From MAEVEN Where IDMAEEDO = " & _Idmaeedo_Desde & "
                            Select MAEEN.* From MAEEN 
                                   Inner Join MAEEDO On ENDO = KOEN And SUENDO = SUEN 
                                        Where IDMAEEDO = " & _Idmaeedo_Desde

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

            _Ds.Tables(0).TableName = "Maeedo"
            _Ds.Tables(1).TableName = "Maeddo"
            _Ds.Tables(2).TableName = "Maeimli"
            _Ds.Tables(3).TableName = "Maedtli"
            _Ds.Tables(4).TableName = "Maeedoob"
            _Ds.Tables(5).TableName = "Maeven"

            Dim _Idmaeedo_Ori As Integer
            Dim _Tido As String
            Dim _Nudo As String

            ' _Cadena_ConexionSQL_Server_Destino = "data source = 190.171.153.139,1451; initial catalog = SUPERMERCADO_SPA; user id = SUPERMERCADO_SPA; password = SUPERMERCADO_SPA"

            Dim myTrans As SqlClient.SqlTransaction
            Dim Comando As SqlClient.SqlCommand

            Dim cn2 As New SqlConnection
            Dim SQL_ServerClass As New Class_SQL(_Cadena_ConexionSQL_Server_Destino)

            Consulta_Sql = "Select Top 1 *,NOKOCARAC+'.dbo.' As Global_BaseBk From TABCARAC Where KOTABLA = 'BAKAPP' And KOCARAC = 'BASE'"
            Dim _Row_Tabcarac As DataRow = SQL_ServerClass.Fx_Get_DataRow(Consulta_Sql)

            Dim _Global_BaseBk_Destino As String = _Row_Tabcarac.Item("Global_BaseBk")

            Try

                Dim _Fila_Encabezado As DataRow = _Ds.Tables("Maeedo").Rows(0)

                _Idmaeedo_Ori = _Fila_Encabezado.Item("IDMAEEDO")
                _Tido = _Fila_Encabezado.Item("TIDO")
                _Nudo = _Fila_Encabezado.Item("NUDO")

                SQL_ServerClass.Sb_Abrir_Conexion(cn2)

                Consulta_Sql = "Select * From CONFIGP Where EMPRESA = '" & _Empresa & "'"
                _Respuestas.RowEmpresa = SQL_ServerClass.Fx_Get_DataRow(Consulta_Sql)

                'Dim _Reg As Boolean = CBool(SQL_ServerClass.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _Tido & "' And NUDO = '" & _Nudo & "'"))

                'If _Reg Then
                '    Throw New System.Exception("El documento " & _Tido & "-" & _Nudo & " ya existe en la base de datos.")
                'End If

                myTrans = cn2.BeginTransaction()

                Dim _Subtido = _Fila_Encabezado.Item("SUBTIDO")

                Consulta_Sql = "Insert Into " & _Global_BaseBk_Destino & "Zw_Demonio_NVVAuto (IdmaeedoOCC_Ori,Endo_Ori,Suendo_Ori,NudoOCC_Ori,FechaGrab,GenerarNVV) Values " &
                               "(" & _Idmaeedo_Ori & ",'" & _Endo_Ori & "','" & _Suendo_Ori & "','" & _Nudo & "',Getdate(),1)"

                Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Id_Enc = dfd1("Identity")
                End While
                dfd1.Close()

                Consulta_Sql = String.Empty

                For Each _Fila_Detalle As DataRow In _Ds.Tables("Maeddo").Rows

                    Dim _Idmaeddo_Ori As Integer = _Fila_Detalle.Item("IDMAEDDO")
                    Dim _Codigo As String = _Fila_Detalle.Item("KOPRCT")
                    Dim _Descripcion As String = _Fila_Detalle.Item("NOKOPR")
                    Dim _Untrans As Integer = _Fila_Detalle.Item("UDTRPR")
                    Dim _Cantidad As Double = _Fila_Detalle.Item("CAPRCO" & _Untrans)

                    Consulta_Sql = "Insert Into " & _Global_BaseBk_Destino & "Zw_Demonio_NVVAutoDet (Id_Enc,Idmaeddo_Ori,Codigo,Cantidad,Untrans,Descripcion) Values " &
                                   "(" & _Id_Enc & "," & _Idmaeddo_Ori & ",'" & _Codigo & "','" & De_Num_a_Tx_01(_Cantidad, False, 5) & "'," & _Untrans & ",'" & _Descripcion & "')"
                    Comando = New SqlClient.SqlCommand(Consulta_Sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

                _Respuestas.EsCorrecto = True
                _Respuestas.Idmaeedo = _Id_Enc

                'If False Then
                'Throw New System.Exception("An exception has occurred.")
                'End If

                myTrans.Commit()
                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            Catch ex As Exception

                _Respuestas.EsCorrecto = False
                _Respuestas.Idmaeedo = 0
                _Respuestas.Mensajes.Clear()
                _Respuestas.Mensajes.Add(ex.Message)

                If Not IsNothing(myTrans) Then
                    _Respuestas.Mensajes.Add(ex.StackTrace)
                    myTrans.Rollback()
                End If

                SQL_ServerClass.Sb_Cerrar_Conexion(cn2)

            End Try

            Return _Respuestas

        End Function

    End Class

    Public Class Respuesta
        Public Property EsCorrecto As Boolean
        Public Property Mensajes As List(Of String)
        Public Property Idmaeedo As Integer
        Public Property RowEmpresa As DataRow

    End Class

End Namespace


