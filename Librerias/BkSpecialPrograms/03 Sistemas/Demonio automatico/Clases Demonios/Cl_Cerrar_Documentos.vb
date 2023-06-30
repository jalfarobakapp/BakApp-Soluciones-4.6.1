Imports DevComponents.DotNetBar

Public Class Cl_Cerrar_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

#Region "PROPIEDADES"

    Public Property COVCerrar As Boolean
    Public Property OCICerrar As Boolean
    Public Property OCCCerrar As Boolean
    Public Property NVVCerrar As Boolean
    Public Property NVICerrar As Boolean
    Public Property DiasCOV As Integer
    Public Property DiasOCI As Integer
    Public Property DiasOCC As Integer
    Public Property DiasNVI As Integer
    Public Property DiasNVV As Integer
    Public Property Fecha_Revision As DateTime
    Public Property Procesando As Boolean
    Public Property Log_Registro As String
    Public Property Ejecutar As Boolean
#End Region

    Public Sub New()

    End Sub

    Sub Sb_Procedimientos_Cierre_Masivo_Documentos(_Formulario As Form, _Tido As String)

        Dim _Dias As Integer
        Dim _Ejecutar As Boolean

        Select Case _Tido
            Case "COV"
                _Dias = DiasCOV : _Ejecutar = COVCerrar
            Case "OCI"
                _Dias = DiasOCI : _Ejecutar = OCICerrar
            Case "OCC"
                _Dias = DiasOCC : _Ejecutar = OCCCerrar
            Case "NVI"
                _Dias = DiasNVI : _Ejecutar = NVICerrar
            Case "NVV"
                _Dias = DiasNVV : _Ejecutar = NVVCerrar
            Case Else
                Return
        End Select

        If Not _Ejecutar Then
            Return
        End If

        Dim _Fecha As Date = Fecha_Revision

        _Fecha = DateAdd(DateInterval.Day, -_Dias, _Fecha)

        Consulta_Sql = My.Resources.Recursos_Demonio.SQLQuery_Cierrer_Docmuento
        Consulta_Sql = Replace(Consulta_Sql, "#Filtro#",
                       "Edo.EMPRESA = '" & ModEmpresa & "' And Edo.TIDO = '" & _Tido & "' And Edo.ESDO = '' And Edo.FEEMDO <= '" & Format(_Fecha, "yyyyMMdd") & "'")
        Consulta_Sql = Replace(Consulta_Sql, "#Campo_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", "")
        Consulta_Sql = Replace(Consulta_Sql, "Isnull(Mae2.NOKOEN,'') As RAZON_FISICA,", "")
        Consulta_Sql = Replace(Consulta_Sql, "#Orden#", "")
        Consulta_Sql = Replace(Consulta_Sql, "#CantidadDoc#", "100")
        Consulta_Sql = Replace(Consulta_Sql, "Cast(0 As Bit) As Chk,", "Cast(1 As Bit) As Chk,")

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        If _Tbl.Rows.Count Then

            Dim Fm As New Frm_BuscarDocumento_Mt
            Fm.Ocultar_Envio_Correos_Masivamente = True
            Fm.Lbl_Ver.Text = False
            Fm.BtnAceptar.Visible = True
            Fm.Pro_Sql_Query = Consulta_Sql
            Fm.CmbCantFilas.Text = 100
            Fm.Pro_Pago_a_Documento = False
            Fm.Pro_Abrir_Seleccionado = False
            Fm.Seleccion_Multiple = True
            Fm.Abrir_Cerrar_Documentos_Compromiso = True
            Fm.Abrir_Documentos = False
            Fm.Cerrar_Documentos = True
            Fm.Cerrar_Documentos_Automaticamente = True
            Fm.Bar1.Enabled = False
            Fm.ShowDialog(_Formulario)
            Fm.Dispose()

        End If

    End Sub

End Class


