Public Class Class_MantFacturasElect

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Desde As DateTime
    Dim _Fecha_Hasta As DateTime
    Dim _Tbl_Documentos As DataTable
    Dim _Tbl_Sucursales As DataTable
    Dim _Tbl_Responsables As DataTable
    Dim _Tbl_Entidades As DataTable

    Dim _Documentos_Todos As Boolean
    Dim _Sucursales_Todas As Boolean
    Dim _Responsables_Todos As Boolean
    Dim _Entidades_Todas As Boolean

    Dim _Aceptar As Boolean

#Region "PROPIEDADES"

    Public Property Fecha_Desde As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(value As Date)
            _Fecha_Desde = value
        End Set
    End Property

    Public Property Fecha_Hasta As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(value As Date)
            _Fecha_Hasta = value
        End Set
    End Property

    Public Property Tbl_Documentos As DataTable
        Get
            Return _Tbl_Documentos
        End Get
        Set(value As DataTable)
            _Tbl_Documentos = value
        End Set
    End Property

    Public Property Tbl_Sucursales As DataTable
        Get
            Return _Tbl_Sucursales
        End Get
        Set(value As DataTable)
            _Tbl_Sucursales = value
        End Set
    End Property

    Public Property Tbl_Responsables As DataTable
        Get
            Return _Tbl_Responsables
        End Get
        Set(value As DataTable)
            _Tbl_Responsables = value
        End Set
    End Property

    Public Property Tbl_Entidades As DataTable
        Get
            Return _Tbl_Entidades
        End Get
        Set(value As DataTable)
            _Tbl_Entidades = value
        End Set
    End Property

    Public Property Documentos_Todos As Boolean
        Get
            Return _Documentos_Todos
        End Get
        Set(value As Boolean)
            _Documentos_Todos = value
        End Set
    End Property

    Public Property Sucursales_Todas As Boolean
        Get
            Return _Sucursales_Todas
        End Get
        Set(value As Boolean)
            _Sucursales_Todas = value
        End Set
    End Property

    Public Property Responsables_Todos As Boolean
        Get
            Return _Responsables_Todos
        End Get
        Set(value As Boolean)
            _Responsables_Todos = value
        End Set
    End Property

    Public Property Entidades_Todas As Boolean
        Get
            Return _Entidades_Todas
        End Get
        Set(value As Boolean)
            _Entidades_Todas = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

#End Region

    Public Sub New()

        _Documentos_Todos = True
        _Sucursales_Todas = True
        _Responsables_Todos = True
        _Entidades_Todas = True

    End Sub

    'Sub Sb_Reenviar_Documento(ByRef _Id_Dte As Integer,
    '                          ByRef _Idmaeedo As Integer,
    '                          ByRef _Trackid As String,
    '                          ByRef _AceptadoSII As Boolean,
    '                          ByRef _ReparoSII As Boolean,
    '                          ByRef _Respuesta As String)

    '    Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)

    '    Dim _Tiene_Trackid As Boolean = Not String.IsNullOrEmpty(_Trackid)

    '    If String.IsNullOrEmpty(_Trackid) Then

    '        If _Class_DTE.Fx_Enviar_DTE_Al_SII(_Id_Dte, _Trackid) Then

    '            If IsNumeric(_Trackid) Then

    '                Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Trackid = '" & _Trackid & "' Where Id_Dte = " & _Id_Dte
    '                _Sql.Ej_consulta_IDU(Consulta_sql)

    '            End If

    '        End If

    '    End If

    '    If IsNumeric(_Trackid) Then

    '        If Not _AceptadoSII And Not _ReparoSII Then

    '            If _Class_DTE.Fx_Consultar_Trackid(_Trackid, _Respuesta) Then

    '                Dim _Estado = String.Empty
    '                Dim _Glosa = String.Empty

    '                Dim _Aceptados As Integer
    '                Dim _Informados As Integer
    '                Dim _Rechazados As Integer
    '                Dim _Reparos As Integer

    '                _Class_DTE.Sb_Revisar_Respuesta_Trackid(_Respuesta, _Estado, _Glosa, _Aceptados, _Informados, _Rechazados, _Reparos,
    '                                                        _VolverProcesar:=False)

    '                _Tiene_Trackid = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_DTE_Trackid", "Id_Dte = " & _Id_Dte & " And Trackid = '" & _Trackid & "'"))

    '                Dim _Id_Trackid As Integer

    '                If _Tiene_Trackid Then

    '                    _Id_Trackid = _Sql.Fx_Trae_Dato("Zw_DTE_Trackid", "Id", "Id_Dte = " & _Id_Dte & " And Trackid = '" & _Trackid & "'")

    '                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Trackid Set" & vbCrLf &
    '                                   "Informado = " & _Informados &
    '                                   ",Aceptado = " & _Aceptados &
    '                                   ",Rechazado = " & _Rechazados &
    '                                   ",Reparo = " & _Reparos &
    '                                   ",Estado = '" & _Estado & "'" &
    '                                   ",Glosa = '" & _Glosa & "'" &
    '                                   ",Respuesta = '" & _Respuesta & "'" & vbCrLf &
    '                                   "Where Id = " & _Id_Trackid
    '                    _Sql.Ej_consulta_IDU(Consulta_sql)
    '                Else
    '                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_Trackid (Id_Dte,Idmaeedo,Trackid,Informado,Aceptado,Rechazado,Reparo,Estado,Glosa,Respuesta) Values " &
    '                               "(" & _Id_Dte & "," & _Idmaeedo & ",'" & _Trackid & "'," & _Informados & "," & _Aceptados & "," & _Rechazados & "," & _Reparos & ",'" & _Estado & "','" & _Glosa & "','" & _Respuesta & "')"
    '                    _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Trackid)
    '                End If

    '                _AceptadoSII = _Aceptados
    '                _ReparoSII = _Reparos

    '                If CBool(_Aceptados) Or CBool(_Reparos) Then

    '                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_DTE_Documentos Set Procesado = 1, Procesar = 0 Where Id_Dte = " & _Id_Dte
    '                    _Sql.Ej_consulta_IDU(Consulta_sql)

    '                    'Dim _Koen = _Class_DTE.Maeedo.Rows(0).Item("ENDO")
    '                    'Dim _Suen = _Class_DTE.Maeedo.Rows(0).Item("SUENDO")

    '                    'Dim _Para = _Class_DTE.Maeen.Rows(0).Item("EMAIL").ToString.Trim
    '                    'Dim _EnvioCorreo As String = _Class_DTE.Fx_Enviar_Notificacion_Correo_Al_Diablito(_Idmaeedo, _Para, "", _Id_Trackid)

    '                    'If Not String.IsNullOrEmpty(_EnvioCorreo) Then
    '                    '    Fx_Add_Log_Gestion(FUNCIONARIO, Modalidad, "Zw_DTE_Trackid", _Id_Dte, "Email_DTE_Error", _EnvioCorreo, "", "", _Koen, _Suen, False, "")
    '                    'End If

    '                End If

    '            End If

    '        End If

    '    End If

    'End Sub

End Class
