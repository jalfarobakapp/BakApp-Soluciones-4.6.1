Imports HEFESTO.Acuse.Recibo.Factura
'Imports HEFESTO.Acuse.Recibo.Factura.Certificacion
'Imports HEFESTO.Acuse.Recibo.Factura.Produccion
Imports HEFESTO
Imports BakApp_DTEMonitor.Eventos_Dte
Imports System.IO

Public Class Cl_AcuseReciboFactura

    'Dim _RutEmisor As String
    'Dim _RutEnvia As String
    'Dim _RutReceptor As String
    'Dim _FchResol As String
    'Dim _NroResol As String
    'Dim _Cn As String

    'Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    'Dim Consulta_sql As String

    Public Sub New()

        'Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
        '               "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
        '               "Where Empresa = '" & ModEmpresa & "' And TipoConfiguracion = 'ConfEmpresa'"
        'Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        'If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
        '    Throw New System.Exception("Faltan los datos de configuración DTE para la empresa")
        'End If

        'For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

        '    Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

        '    If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
        '    If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
        '    If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
        '    If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
        '    If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
        '    If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

        'Next

    End Sub

    Function Fx_RevisarHistorialDocumento(_Cn As String,
                                          _RutEmisor As String,
                                          _TipoDte As String,
                                          _FolioDte As String,
                                          _Intentos As Integer,
                                          Optional _Mensaje As String = "") As Ls_HistorialDocumentoDte


        Dim _Ls_HistorialDocumentoDte As New Ls_HistorialDocumentoDte

        _Ls_HistorialDocumentoDte.Historial = New List(Of HistorialDocumentoDte)

        If _Intentos > 3 Then
            _Ls_HistorialDocumentoDte.EsCorrecto = False
            _Ls_HistorialDocumentoDte.Mensaje = _Mensaje
            Return _Ls_HistorialDocumentoDte
        End If

        'Dim _Acuse As Respuesta = Certificacion.HefAcuseReciboFactura.ConsultarVersion(_Cn)
        Dim _Acuse As Respuesta = Produccion.HefAcuseReciboFactura.ConsultarVersion(_Cn)

        _Acuse = Produccion.HefAcuseReciboFactura.ConsultaHistorialDocumentoDTE(_Cn, _RutEmisor, _TipoDte, _FolioDte)

        If Not _Acuse.EsCorrecto Then

            _Intentos += 1

            _Ls_HistorialDocumentoDte.EsCorrecto = False
            _Ls_HistorialDocumentoDte.Mensaje = _Acuse.Detalle

            _Ls_HistorialDocumentoDte = Fx_RevisarHistorialDocumento(_Cn, _RutEmisor, _TipoDte, _FolioDte, _Intentos, _Mensaje)

            Return _Ls_HistorialDocumentoDte

        End If

        Dim _XmlData As String = _Acuse.Resultado.ToString
        Dim _Reader As New StringReader(_XmlData)

        Dim dataSet As New DataSet()
        dataSet.ReadXml(_Reader)

        Dim _Tbl_listaEventosDoc As DataTable
        Dim _TieneEventos As Boolean = dataSet.Tables.Contains("listaEventosDoc")

        If _TieneEventos Then

            _Tbl_listaEventosDoc = dataSet.Tables(3)

            For Each row As DataRow In _Tbl_listaEventosDoc.Rows

                Dim _HistorialDocumentoDte As New HistorialDocumentoDte

                _HistorialDocumentoDte.CodEvento = row.Item("codEvento")
                _HistorialDocumentoDte.DescEvento = row.Item("descEvento")
                _HistorialDocumentoDte.RutResponsable = row.Item("rutResponsable")
                _HistorialDocumentoDte.DvResponsable = row.Item("dvResponsable")
                _HistorialDocumentoDte.FechaEvento = row.Item("fechaEvento")

                _Ls_HistorialDocumentoDte.Historial.Add(_HistorialDocumentoDte)

            Next

            _Ls_HistorialDocumentoDte.EsCorrecto = True

        Else

            _Acuse = Produccion.HefAcuseReciboFactura.ConsultaEstadoDocumentoCedible(_Cn, _RutEmisor, _TipoDte, _FolioDte)

            _XmlData = _Acuse.Resultado.ToString
            _Reader = New StringReader(_XmlData)

            dataSet = New DataSet()
            dataSet.ReadXml(_Reader)

            _TieneEventos = dataSet.Tables.Contains("listaEventosDoc")

            _Ls_HistorialDocumentoDte.EsCorrecto = False

        End If

        _Ls_HistorialDocumentoDte.Mensaje = dataSet.Tables(2).Rows(0).Item("descResp")
        Return _Ls_HistorialDocumentoDte

    End Function

End Class

Namespace Eventos_Dte

    Public Class Ls_HistorialDocumentoDte
        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String
        Public Property Historial As List(Of HistorialDocumentoDte)

    End Class
    Public Class HistorialDocumentoDte

        Public Property CodEvento As String
        Public Property DescEvento As String
        Public Property RutResponsable As String
        Public Property DvResponsable As String
        Public Property FechaEvento As DateTime

    End Class

End Namespace

