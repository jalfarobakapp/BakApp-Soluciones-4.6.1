Imports DevComponents.DotNetBar
Imports HefRcof

Public Class Frm_Dte_ConsumoFolios

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Path As String = AppPath() & "\Data\Dte"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Dte_ConsumoFolios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub Btn_Enviar_Consumo_Folios_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Consumo_Folios.Click

    '    Dim _Feemdo As String = Format(Dtp_Fecha.Value, "yyyyMMdd")

    '    Dim _Year As String = Dtp_Fecha.Value.Year
    '    Dim _Month As String = numero_(Dtp_Fecha.Value.Month, 2)
    '    Dim _Day As String = numero_(Dtp_Fecha.Value.Day, 2)

    '    Consulta_sql = "Select Min(NUDO) As Inicial,Max(NUDO) As Final,Count(*) As FoliosEmitidos,Sum(VANEDO) As MntNeto,Sum(VAIVDO) As MntIva,Sum(VABRDO) As MntTotal" & vbCrLf &
    '                   "From MAEEDO Where TIDO = 'BLV' And FEEMDO = '" & _Feemdo & "' And NUDONODEFI = 0"
    '    Dim _Row_Boletas As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

    '    'If IsNothing(_Row_Boletas) Then
    '    '    MessageBoxEx.Show(Me, "No hay datos que mostrar", "Boletas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    '    Return
    '    'End If

    '    'If Not CBool(_Row_Boletas.Item("FoliosEmitidos")) Then
    '    '    MessageBoxEx.Show(Me, "No hay datos que mostrar", "Boletas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '    '    Return
    '    'End If

    '    Dim _Inicial = CInt(NuloPorNro(_Row_Boletas.Item("Inicial"), 0))
    '    Dim _Final = CInt(NuloPorNro(_Row_Boletas.Item("Final"), 0))

    '    Dim _MntNeto = De_Num_a_Tx_01(NuloPorNro(_Row_Boletas.Item("MntNeto"), 0), True)
    '    Dim _MntIva = De_Num_a_Tx_01(NuloPorNro(_Row_Boletas.Item("MntIva"), 0), True)
    '    Dim _MntTotal = De_Num_a_Tx_01(NuloPorNro(_Row_Boletas.Item("MntTotal"), 0), True)
    '    Dim _FoliosEmitidos = De_Num_a_Tx_01(NuloPorNro(_Row_Boletas.Item("FoliosEmitidos"), 0), True)

    '    Dim _RutEmisor As String
    '    Dim _RutEnvia As String
    '    Dim _RutReceptor As String
    '    Dim _FchResol As String
    '    Dim _NroResol As String
    '    Dim _TpoDTE As String = "39"
    '    Dim _Cn As String

    '    Consulta_sql = "Select Id,Empresa,Campo,Valor,FechaMod,TipoCampo,TipoConfiguracion" & vbCrLf &
    '                   "From " & _Global_BaseBk & "Zw_DTE_Configuracion" & vbCrLf &
    '                   "Where Empresa = '" & Mod_Empresa & "' And TipoConfiguracion = 'ConfEmpresa'"
    '    Dim _Tbl_ConfEmpresa As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '    If Not CBool(_Tbl_ConfEmpresa.Rows.Count) Then
    '        '_Errores.Add("Faltan los datos de configuración DTE para la empresa")
    '        'Return 0
    '    End If

    '    For Each _Fila As DataRow In _Tbl_ConfEmpresa.Rows

    '        Dim _Campo As String = _Fila.Item("Campo").ToString.Trim

    '        If _Campo = "RutEmisor" Then _RutEmisor = _Fila.Item("Valor")
    '        If _Campo = "RutEnvia" Then _RutEnvia = _Fila.Item("Valor")
    '        If _Campo = "RutReceptor" Then _RutReceptor = _Fila.Item("Valor")
    '        If _Campo = "FchResol" Then _FchResol = _Fila.Item("Valor")
    '        If _Campo = "NroResol" Then _NroResol = _Fila.Item("Valor")
    '        If _Campo = "Cn" Then _Cn = _Fila.Item("Valor")

    '    Next

    '    Dim _cf As New HefConsumoFolios

    '    _cf.Certificado = _Cn '"JUAN PABLO SIERRALTA OREZZOLI"
    '    _cf.Schema = _Path & "Schemas\Rcof.xsd"

    '    _cf.DocumentoConsumoFolios.Caratula.RutEmisor = _RutEmisor '"79514800-0"
    '    _cf.DocumentoConsumoFolios.Caratula.RutEnvia = _RutEnvia ' "12628844-1"
    '    _cf.DocumentoConsumoFolios.Caratula.FchResol = _FchResol '"2012-06-19"
    '    _cf.DocumentoConsumoFolios.Caratula.NroResol = _NroResol '"72"
    '    _cf.DocumentoConsumoFolios.Caratula.FchInicio = _Year & "-" & _Month & "-" & _Day
    '    _cf.DocumentoConsumoFolios.Caratula.FchFinal = _Year & "-" & _Month & "-" & _Day
    '    _cf.DocumentoConsumoFolios.Caratula.Correlativo = "0"
    '    _cf.DocumentoConsumoFolios.Caratula.SecEnvio = "1"

    '    Dim _Resumen As New HefResumen

    '    _Resumen.TipoDocumento = _TpoDTE
    '    _Resumen.MntNeto = _MntNeto
    '    _Resumen.MntExento = 0
    '    _Resumen.MntIva = _MntIva
    '    _Resumen.MntTotal = _MntTotal
    '    _Resumen.FoliosEmitidos = _FoliosEmitidos
    '    _Resumen.FoliosAnulados = 0
    '    _Resumen.FoliosUtilizados = _FoliosEmitidos

    '    Dim RUtil1 As New HefRangoUtilizados

    '    RUtil1.Inicial = _Inicial
    '    RUtil1.Final = _Final
    '    _Resumen.RangoUtilizados.Add(RUtil1)

    '    _cf.DocumentoConsumoFolios.Resumenes.Add(_Resumen)

    '    If _cf.Publicar() Then

    '        Dim _Trackid = _cf.Trackid

    '        Dim _vFchInicio = Format(Dtp_Fecha.Value, "yyyyMMdd")
    '        Dim _vFchFinal = Format(Dtp_Fecha.Value, "yyyyMMdd")
    '        Dim _vFolioInicial = _Inicial
    '        Dim _vFolioFinal = _Final
    '        Dim _vFoliosEmitidos = _FoliosEmitidos
    '        Dim _vFoliosUtilizados = _FoliosEmitidos

    '        Dim _ArcXml = _cf.ArcXml.InnerXml.ToString '.ArcXml.ToString

    '        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_DTE_ConsFolios (Trackid,FchInicio,FchFinal,FolioInicial,FolioFinal,FoliosEmitidos,FoliosUtilizados,Xml) Values " &
    '                       "('" & _Trackid & "','" & _vFchInicio & "','" & _vFchFinal & "'," & _vFolioInicial &
    '                        "," & _vFolioFinal & "," & _vFoliosEmitidos & "," & _vFoliosUtilizados & ",'" & _ArcXml & "')"
    '        _Sql.Ej_consulta_IDU(Consulta_sql)

    '        MessageBoxEx.Show(Me, "Consumo de folios enviado correctamente",
    '                          "Consumo de folios de boletas", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '    End If

    'End Sub

End Class
