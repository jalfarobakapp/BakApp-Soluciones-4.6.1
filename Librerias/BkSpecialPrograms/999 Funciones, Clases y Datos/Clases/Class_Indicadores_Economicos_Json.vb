Imports System.Net
Imports System.Web.Script.Serialization
Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Class_Indicadores_Economicos_Json

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _ApiUrl As String = "https://www.mindicador.cl/api"
    Dim _JsonString As String = "{}"
    Dim _Indicadores As Object
    Dim _Http As New WebClient()
    Dim _Js As New JavaScriptSerializer()

    Dim _Sitio_Activo As Boolean


    Dim _Error As String

    Enum Enum_Indicador
        ivp                'Indice de valor promedio (IVP) 
        euro               'Euro
        dolar_intercambio  'Dólar acuerdo 
        dolar              'Dólar observado
        libra_cobre        'Libra de Cobre
        utm                'Unidad Tributaria Mensual (UTM)
        tpm                'Tasa Política Monetaria (TPM)
        uf                 'Tasa Política Monetaria (TPM)
        tasa_desempleo     'Tasa de desempleo
        ipc                'Indice de Precios al Consumidor (IPC) 
        imacec             'Imacec
        bitcoin            'Bitcoin
    End Enum

    Public Property Pro_Indicadores() As Object
        Get
            Return _Indicadores
        End Get
        Set(ByVal value As Object)
            _Indicadores = value
        End Set
    End Property
    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Property Pro_Sitio_Activo As Boolean
        Get
            _Sitio_Activo = Fx_Revisar_Sitio_Activo(_ApiUrl)
            Return _Sitio_Activo
        End Get
        Set(value As Boolean)
            _Sitio_Activo = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Sub Sb_Revisar_Indicadores()

        _Http.Headers.Add(HttpRequestHeader.Accept, "application/json")
        _JsonString = _Http.DownloadString(_ApiUrl)
        _Indicadores = _Js.Deserialize(Of Object)(_JsonString)

        Dim _Uf = _Indicadores("uf")("valor")
        Dim _Dolar = _Indicadores("dolar")("valor")
        Dim _Euro = _Indicadores("euro")("valor")

    End Sub

    Function Fx_Datos_Indicadores_Actuales(ByVal _Indicador As String) As DataRow

        _Error = String.Empty

        Dim _Codigo_Indicador As String = _Indicador
        Dim _Url = _ApiUrl '& "/" & _Codigo_Indicador & "/" & Format(_Fecha_Indicador, "dd-MM-yyyy")

        _Http.Headers.Add(HttpRequestHeader.Accept, "application/json")
        _JsonString = _Http.DownloadString(_Url)
        _Indicadores = _Js.Deserialize(Of Object)(_JsonString)

        'https://mindicador.cl/api/uf/24-09-2018

        'Dim _Valor_Dolar = _Todos_Los_Indicadores(_Indicador)("valor")

        Dim _Row As DataRow = Fx_New_Row()

        Dim _Codigo = _Indicadores(_Indicador)("codigo")
        Dim _Nombre = _Indicadores(_Indicador)("nombre")
        Dim _Fecha = CDate(FormatDateTime(CDate(_Indicadores(_Indicador)("fecha")), DateFormat.ShortDate))
        Dim _Unidad_medida = _Indicadores(_Indicador)("unidad_medida")
        Dim _Valor = _Indicadores(_Indicador)("valor")

        _Row.Item("Codigo") = _Codigo
        _Row.Item("Nombre") = _Nombre
        _Row.Item("Fecha") = _Fecha
        _Row.Item("Unidad_medida") = _Unidad_medida
        _Row.Item("Valor") = _Valor

        Fx_Datos_Indicadores_Actuales = _Row

    End Function

    Function Fx_Datos_Indicador_A_Una_Fecha(ByVal _Indicador As String, ByVal _Fecha_Indicador As Date) As DataRow

        Dim _Codigo_Indicador As String = _Indicador
        Dim _Url = _ApiUrl & "/" & _Codigo_Indicador & "/" & Format(_Fecha_Indicador, "dd-MM-yyyy")
        Dim _Row As DataRow

        _Http.Headers.Add(HttpRequestHeader.Accept, "application/json")
        _JsonString = _Http.DownloadString(_Url)
        _Indicadores = _Js.Deserialize(Of Object)(_JsonString)

        _Row = Fx_New_Row()

        Dim _Codigo = _Indicadores("codigo")
        Dim _Nombre = _Indicadores("nombre")
        Dim _Unidad_medida = _Indicadores("unidad_medida")
        Dim _Valor = _Indicadores("serie")(0)("valor")

        _Row.Item("Codigo") = _Codigo
        _Row.Item("Nombre") = _Nombre
        _Row.Item("Fecha") = _Fecha_Indicador
        _Row.Item("Unidad_medida") = _Unidad_medida
        _Row.Item("Valor") = _Valor

        Fx_Datos_Indicador_A_Una_Fecha = _Row


    End Function

    Private Function Fx_New_Row() As DataRow

        Dim _Dt As New DataTable("Tabla1")
        Dim _Dr As DataRow
        Dim _Ds As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        _Dt.Columns.Add("Codigo", System.Type.[GetType]("System.String"), "")
        _Dt.Columns.Add("Nombre", System.Type.[GetType]("System.String"), "")
        _Dt.Columns.Add("Fecha", System.Type.[GetType]("System.DateTime"))
        _Dt.Columns.Add("Unidad_medida", System.Type.[GetType]("System.String"), "")
        _Dt.Columns.Add("Valor", System.Type.[GetType]("System.Double"))
        ',,,,,,

        _Dr = _Dt.NewRow()
        _Dr("Codigo") = "C"
        _Dr("Nombre") = "C"
        _Dr("Fecha") = Now
        _Dr("Unidad_medida") = "C"
        _Dr("Valor") = 0
        _Dt.Rows.Add(_Dr)
       
        _Ds.Tables.Add(_Dt)

        Return _Dr

    End Function

    Function Sb_Actualizar_Taza_De_Cambio_Hoy()

        Try

            Dim _Fecha As String

            Dim _Fecha_Taza As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            _Fecha = Format(_Fecha_Taza, "yyyyMMdd")

            Dim _CantMonedas As Integer = _Sql.Fx_Cuenta_Registros("TABMO", "TIMO = 'E' Or KOMO <> '$'")

            Consulta_sql = "Select KOMO,TIMO,NOKOMO,VAMO,FEMO,FACOMOAN,VAMOCOM" & vbCrLf & _
                           "From TABMO" & vbCrLf & _
                           "Where KOMO In (Select Distinct CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'INDICADORES')" & vbCrLf & _
                           "And FEMO <> '" & _Fecha & "'"

            Dim _TblMoneda As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Monedas = String.Empty

            Dim _SqlQuery = String.Empty

            For Each _Filas As DataRow In _TblMoneda.Rows

                Dim _Timo = _Filas.Item("TIMO")
                Dim _Komo = _Filas.Item("KOMO")
                Dim _Nokomo = Trim(_Filas.Item("NOKOMO"))
                Dim _Vamo = De_Num_a_Tx_01(_Filas.Item("VAMO"), False, 5)
                Dim _Vamocom = De_Num_a_Tx_01(_Filas.Item("VAMOCOM"), False, 5)

                Dim _Indicador As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones", _
                                                             "NombreTabla", _
                                                             "Tabla = 'INDICADORES' And CodigoTabla = '" & _Komo & "'")

                Dim _Row_Indicador As DataRow = Fx_Datos_Indicadores_Actuales(_Indicador)

                If Not (_Row_Indicador Is Nothing) Then
                    _Vamo = De_Num_a_Tx_01(_Row_Indicador.Item("Valor"), False, 5)

                    _SqlQuery += "-- " & _Nokomo & vbCrLf & _
                                 "UPDATE TABMO SET" & Space(1) & _
                                 "FEMO='" & _Fecha & "'," & _
                                 "TIMO='" & _Timo & "'," & _
                                 "VAMO=" & _Vamo & "," & _
                                 "VAMOCOM=" & _Vamocom & Space(1) & _
                                 "WHERE KOMO='" & _Komo & "'" & vbCrLf & _
                                 "INSERT INTO MAEMO (KOMO,NOKOMO,FEMO,TIMO,VAMO,VAMOCOM) VALUES" & Space(1) & _
                                 "('" & _Komo & "','" & _Nokomo & "','" & _Fecha & "','" & _Timo & "'," & _Vamo & "," & _Vamocom & ")" & vbCrLf & _
                                 "UPDATE PNOMDIM SET VALOR=" & _Vamo & " WHERE CODIGO='VALOR_" & _Komo & "'" & vbCrLf & vbCrLf
                End If


            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Function Sb_Actualizar_Taza_De_Cambio_a_una_Fecha(ByVal _Fecha_Taza As Date)

        Try

            Dim _Fecha As String

            'Dim _Fecha_Taza As Date = FormatDateTime(FechaDelServidor(), DateFormat.ShortDate)

            _Fecha = Format(_Fecha_Taza, "yyyyMMdd")

            Dim _CantMonedas As Integer = _Sql.Fx_Cuenta_Registros("TABMO", "TIMO = 'E' Or KOMO <> '$'")

            Consulta_sql = "Select KOMO,TIMO,NOKOMO,VAMO,FEMO,FACOMOAN,VAMOCOM" & vbCrLf &
                           "From TABMO" & vbCrLf &
                           "Where KOMO In (Select Distinct CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'INDICADORES')" & vbCrLf &
                           "And FEMO <> '" & _Fecha & "'"

            Dim _TblMoneda As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            Dim _Monedas = String.Empty

            Dim _SqlQuery = String.Empty

            For Each _Filas As DataRow In _TblMoneda.Rows

                Dim _Timo = _Filas.Item("TIMO")
                Dim _Komo = _Filas.Item("KOMO")
                Dim _Nokomo = Trim(_Filas.Item("NOKOMO"))
                Dim _Vamo = De_Num_a_Tx_01(_Filas.Item("VAMO"), False, 5)
                Dim _Vamocom = De_Num_a_Tx_01(_Filas.Item("VAMOCOM"), False, 5)

                Dim _Indicador As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_TablaDeCaracterizaciones",
                                                             "NombreTabla",
                                                             "Tabla = 'INDICADORES' And CodigoTabla = '" & _Komo & "'")

                Dim _Row_Indicador As DataRow = Fx_Datos_Indicador_A_Una_Fecha(_Indicador, _Fecha_Taza)

                If Not (_Row_Indicador Is Nothing) Then
                    _Vamo = De_Num_a_Tx_01(_Row_Indicador.Item("Valor"), False, 5)

                    _SqlQuery += "-- " & _Nokomo & vbCrLf &
                                 "UPDATE TABMO SET" & Space(1) &
                                 "FEMO='" & _Fecha & "'," &
                                 "TIMO='" & _Timo & "'," &
                                 "VAMO=" & _Vamo & "," &
                                 "VAMOCOM=" & _Vamocom & Space(1) &
                                 "WHERE KOMO='" & _Komo & "'" & vbCrLf &
                                 "INSERT INTO MAEMO (KOMO,NOKOMO,FEMO,TIMO,VAMO,VAMOCOM) VALUES" & Space(1) &
                                 "('" & _Komo & "','" & _Nokomo & "','" & _Fecha & "','" & _Timo & "'," & _Vamo & "," & _Vamocom & ")" & vbCrLf &
                                 "UPDATE PNOMDIM SET VALOR=" & _Vamo & " WHERE CODIGO='VALOR_" & _Komo & "'" & vbCrLf & vbCrLf
                End If


            Next

            If Not String.IsNullOrEmpty(_SqlQuery) Then
                _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
            End If

        Catch ex As Exception
            _Error = ex.Message
        End Try

    End Function

    Private Function Fx_Revisar_Sitio_Activo(_Url As String) As Boolean

        Dim Peticion As System.Net.WebRequest
        Dim Respuesta As System.Net.HttpWebResponse
        Try
            Peticion = System.Net.WebRequest.Create(_Url)
            Peticion.Timeout = 5000
            Respuesta = Peticion.GetResponse()
            Return True
        Catch ex As System.Net.WebException
            If ex.Status = Net.WebExceptionStatus.NameResolutionFailure Then
                'MessageBox.Show("El Sitio no existe")
            End If
        End Try

    End Function

End Class
