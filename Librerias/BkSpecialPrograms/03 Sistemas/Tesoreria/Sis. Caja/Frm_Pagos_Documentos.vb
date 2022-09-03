Imports System.IO
Imports System.Threading
Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Maeedo As DataTable
    Dim _Tbl_Maedpce As DataTable

    Dim _Monto_Total As Double
    Dim _Monto_Asignado As Double
    Dim _Monto_Vuelto As Double
    Dim _Monto_Saldo As Double

    Dim _Modp = "$"
    Dim _Timodp = "N"
    Dim _Tamodp = 1

    Dim _DtsConfig As New DatosBakApp

    Dim _Ruta_Impresora As String = AppPath() & "\Data\" & RutEmpresa & "\BkPost"
    Dim _Nombre_Archivo_XML_Impresora As String = "Imp_Caja.xml"

    Dim _Impresora As String
    Dim _Desde_Documento As Boolean
    Dim _Aplica_Ley_20956 As Boolean
    Dim _Valor_Diferencia_Ley_20956 As Double
    Dim _Autorizado_Grabar As Boolean
    Dim _Es_TLV As Boolean

    Dim _Ocultar_Cta_Cte As Boolean
    Dim _Ds_Matriz_Documentos As Ds_Matriz_Documentos
    Dim _NombreEquipo = _Global_Row_EstacionBk.Item("NombreEquipo")
    Dim _Row_CashDro As DataRow
    Dim _Post_Integrado_Transbank_Activo As Boolean
    Dim _Id_CashDro As Integer

#Region "PROPIESDADES"

    Public Property Pro_Tbl_Maeedo() As DataTable
        Get
            Return _Tbl_Maeedo
        End Get
        Set(value As DataTable)

            If (value Is Nothing) Then
                Sb_Nuevo_Documento()
                value = _Tbl_Maeedo
            End If

            _Tbl_Maeedo = value
            Sb_Tabla_Maeedo()

        End Set
    End Property

    Public Property Pro_Tbl_Maedpce() As DataTable
        Get
            Return _Tbl_Maedpce
        End Get
        Set(value As DataTable)
            _Tbl_Maedpce = value
        End Set
    End Property

    Public Property Desde_Documento As Boolean
        Get
            Return _Desde_Documento
        End Get
        Set(value As Boolean)
            _Desde_Documento = value
        End Set
    End Property

    Public Property Aplica_Ley_20956 As Boolean
        Get
            Return _Aplica_Ley_20956
        End Get
        Set(value As Boolean)
            _Aplica_Ley_20956 = value
        End Set
    End Property

    Public Property Autorizado_Grabar As Boolean
        Get
            Return _Autorizado_Grabar
        End Get
        Set(value As Boolean)
            _Autorizado_Grabar = value
        End Set
    End Property

    Public Property Es_TLV As Boolean
        Get
            Return _Es_TLV
        End Get
        Set(value As Boolean)
            _Es_TLV = value
        End Set
    End Property

    Public Property Ds_Matriz_Documentos As Ds_Matriz_Documentos
        Get
            Return _Ds_Matriz_Documentos
        End Get
        Set(value As Ds_Matriz_Documentos)
            _Ds_Matriz_Documentos = value
        End Set
    End Property

    Public Property Id_CashDro As Integer
        Get
            Return _Id_CashDro
        End Get
        Set(value As Integer)
            _Id_CashDro = value
        End Set
    End Property

#End Region

    Public Sub New(Optional Impresora As String = "")

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Maeedo, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Maedpce, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Not Directory.Exists(_Ruta_Impresora) Then
            System.IO.Directory.CreateDirectory(_Ruta_Impresora)
        End If

        _Impresora = Impresora

        Sb_Nuevo_Documento()

        Sb_Color_Botones_Barra(Bar1)

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Estaciones_CashDro" & vbCrLf &
                       "Where NombreEquipo = '" & _NombreEquipo & "'"
        _Row_CashDro = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_Row_CashDro) Then
            _Post_Integrado_Transbank_Activo = (_Row_CashDro.Item("Usar_Post_Integrado") And _Row_CashDro.Item("Post_Integrado"))
        End If

        Lbl_Info_Transbank.Visible = _Post_Integrado_Transbank_Activo
        Btn_Transbank.Visible = _Post_Integrado_Transbank_Activo

    End Sub

    Private Sub Frm_Pagos_Documentos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim exists = File.Exists(_Ruta_Impresora & "\" & _Nombre_Archivo_XML_Impresora)

        Lbl_Ajuste_Por_Ley20956.Visible = _Aplica_Ley_20956

        If Not Desde_Documento Then

            If Not exists Then

                _Impresora = String.Empty

            Else

                Dim _DtsImp As New DatosBakApp
                _DtsImp.ReadXml(_Ruta_Impresora & "\" & _Nombre_Archivo_XML_Impresora)

                If CBool(_DtsImp.Tables("Conf_Impresora_Local").Rows.Count) Then

                    Dim _DtsImg As New DatosBakApp
                    _DtsImg.ReadXml(_Ruta_Impresora & "\" & _Nombre_Archivo_XML_Impresora)

                    Dim _RutaImagen As String

                    If _DtsImg.Tables("Ruta_Imagen").Rows.Count > 0 Then
                        _RutaImagen = _DtsImg.Tables("Ruta_Imagen").Rows(0).Item("Ruta").ToString
                    Else
                        _RutaImagen = String.Empty
                    End If

                    _Impresora = _DtsImp.Tables("Conf_Impresora_Local").Rows(0).Item("Impresora").ToString

                End If

            End If

            If Fx_Validar_Impresora(_Impresora) Then
                Me.Text = "PAGO A DOCUMENTOS - Impresora: " & _Impresora
            Else
                Me.Text = "PAGO A DOCUMENTOS - Impresora: ??? NO EXISTE IMPRESORA SELECCIONADA"
            End If

            Sb_Nuevo_Documento()

        Else

            Sb_Tabla_Maedpce()
            Sb_Sumar_Totales()

            Btn_Limpiar.Visible = False
            Btn_Buscar_Documentos.Visible = False
            Btn_Documentos_Hoy.Visible = False
            Btn_Configuracion_Post.Visible = False
            Me.MinimizeBox = False
            Me.Refresh()

            Me.ActiveControl = Grilla_Maedpce
            Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(0).Cells("TIDP")

            Grilla_Maeedo.ReadOnly = True

        End If

        Dim _Koen As String = _Tbl_Maeedo.Rows(0).Item("ENDO")
        Dim _Suendo As String = _Tbl_Maeedo.Rows(0).Item("SUENDO")

        Dim _Vnta_EntidadXdefecto As String = _Global_Row_Configuracion_Estacion.Item("Vnta_EntidadXdefecto")
        Dim _Vnta_SucEntXdefecto As String = _Global_Row_Configuracion_Estacion.Item("Vnta_SucEntXdefecto")

        Dim _RowEntidad_X_Defecto = Fx_Traer_Datos_Entidad(_Vnta_EntidadXdefecto, _Vnta_SucEntXdefecto)

        AddHandler Grilla_Maedpce.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Maedpce.EditingControlShowing, AddressOf Grilla_EditingControlShowing

        Sb_Revisar_Si_Hay_Archivos_Adjuntos()

        Lbl_Version.Text = "Versión modulo: " & _Version_BkSpecialPrograms

    End Sub

    Sub Sb_Nuevo_Documento()

        If Not Desde_Documento Then

            _Ds_Matriz_Documentos = New Ds_Matriz_Documentos
            _Ds_Matriz_Documentos.Clear()

        End If

        Consulta_sql = "SELECT TOP 1 * FROM MAEMO WHERE KOMO = 'US$' AND FEMO = '" & Format(FechaDelServidor, "yyyyMMdd") & "' ORDER BY IDMAEMO DESC"
        Dim _RowMoneda_USdolar = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowMoneda_USdolar) Then
            _Tamodp = _RowMoneda_USdolar.Item("VAMO")
        Else
            _Tamodp = 1
        End If

        Consulta_sql = "SELECT top 1 EMPRESA,IDMAEEDO,TIDO,NUDO,ENDO,SUDO,TIMODO,MODO,NUVEDO," &
                       "FE01VEDO,VABRDO,VABRDO-VAABDO AS SALDO_ANTERIOR,VAABDO," &
                       "CAST(0 AS FLOAT) AS PAGO_ACTUAL," &
                       "CAST(0 AS FLOAT) AS PAGO_CHEQUE," &
                       "CAST(0 AS FLOAT) AS SALDO_ACTUAL," &
                       "NUDONODEFI,VAPIDO,SUENDO,FEULVEDO,HORAGRAB," &
                       "CAST('' AS VARCHAR(50)) AS NOKOEN,'' AS ESPGDO,'' AS ESDO,TIDOELEC" & vbCrLf &
                       "FROM MAEEDO"

        _Tbl_Maeedo = _Sql.Fx_Get_Tablas(Consulta_sql)

        With _Tbl_Maeedo

            .Rows(0).Item("EMPRESA") = ModEmpresa
            .Rows(0).Item("IDMAEEDO") = 0
            .Rows(0).Item("TIDO") = String.Empty
            .Rows(0).Item("NUDO") = String.Empty
            .Rows(0).Item("ENDO") = String.Empty
            .Rows(0).Item("SUDO") = String.Empty
            .Rows(0).Item("TIMODO") = String.Empty
            .Rows(0).Item("MODO") = ModEmpresa
            .Rows(0).Item("NUVEDO") = ModEmpresa
            .Rows(0).Item("FE01VEDO") = Date.Now
            .Rows(0).Item("VABRDO") = 0
            .Rows(0).Item("SALDO_ANTERIOR") = 0
            .Rows(0).Item("VAABDO") = 0
            .Rows(0).Item("PAGO_ACTUAL") = 0
            .Rows(0).Item("PAGO_CHEQUE") = 0
            .Rows(0).Item("SALDO_ACTUAL") = 0
            .Rows(0).Item("NUDONODEFI") = False
            .Rows(0).Item("SUENDO") = String.Empty
            .Rows(0).Item("FEULVEDO") = Date.Now
            .Rows(0).Item("HORAGRAB") = 0
            .Rows(0).Item("NOKOEN") = String.Empty
            .Rows(0).Item("TIDOELEC") = 0

        End With

        Sb_Tabla_Maeedo()

        Fx_Buscar_Documento("XXX", False)

        Me.ActiveControl = Grilla_Maeedo
        Grilla_Maeedo.CurrentCell = Grilla_Maeedo.Rows(0).Cells("NUDO")

        If _Global_Row_Configuracion_Estacion.Item("FacElect_Usar_AmbienteCertificacion") Then
            Dim _BackColor_Tido As Color = Color.FromArgb(235, 81, 13)
            MStb_Barra.BackgroundStyle.BackColor = _BackColor_Tido
            Lbl_Info_Transbank.Text = "(*** Ambiente Certificación SII ***) - Transbank activo (Post-Integrado)"
        End If

    End Sub

    Sub Sb_Sumar_Totales()

        _Monto_Total = 0
        _Monto_Asignado = 0
        _Monto_Saldo = 0
        _Monto_Vuelto = 0
        _Valor_Diferencia_Ley_20956 = 0

        Lbl_Ajuste_Por_Ley20956.Visible = False

        Dim _Pago_Cheque = 0

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Tidp = _Fila.Item("TIDP")

            If _Tidp = "CHV" Then
                _Pago_Cheque += NuloPorNro(_Fila.Item("VADP"), 0)
            End If

            _Monto_Asignado += NuloPorNro(_Fila.Item("VADP"), 0)

        Next

        Dim _Fila_Md As DataRow = _Tbl_Maeedo.Rows(0)

        _Monto_Total = _Fila_Md.Item("SALDO_ANTERIOR")

        If _Aplica_Ley_20956 Then

            Dim _Ult_Fila As DataRow = _Tbl_Maedpce.Rows(_Tbl_Maedpce.Rows.Count - 1)
            Dim _Valor_EFV As Double = _Ult_Fila.Item("VADP")
            Dim _Diferencia As Double = (_Monto_Total - (_Monto_Asignado - _Valor_EFV)) - _Valor_EFV

            If _Ult_Fila.Item("TIDP") = "EFV" Then

                If _Diferencia < -10 Then

                    _Diferencia = _Diferencia * -1
                    _Diferencia = Math.Ceiling(_Diferencia)

                    Dim _Ult_Unidad As Double = Mid(_Diferencia, _Diferencia.ToString.Length, 1)

                    _Diferencia = (_Diferencia + (10 - _Ult_Unidad)) - _Diferencia

                End If

                If _Diferencia < 10 And _Diferencia > -10 Then

                    If _Diferencia > 0 Then

                        _Monto_Total -= _Diferencia

                        Dim _New_Fila As DataRow = Fx_Nueva_Linea_De_Pago(_Tbl_Maedpce)
                        _New_Fila.Item("VADP") = _Diferencia
                        _New_Fila.Item("VAABDP") = _Diferencia
                        _New_Fila.Item("VAASDP") = _Diferencia

                    Else
                        _Ult_Fila.Item("LEY20956") = _Diferencia
                        _Monto_Total += _Diferencia * -1
                    End If

                    ' Si es positivo se debe agregar una fila con la diferencia

                    _Valor_Diferencia_Ley_20956 = _Diferencia

                    Lbl_Ajuste_Por_Ley20956.Visible = True
                    Lbl_Ajuste_Por_Ley20956.Text = "Ajuste por ley 20956:" & Space(5) & _Diferencia

                End If

            End If

        End If

        _Fila_Md.Item("PAGO_ACTUAL") = _Monto_Asignado
        _Fila_Md.Item("PAGO_CHEQUE") = _Pago_Cheque

        _Monto_Saldo = _Monto_Total - _Monto_Asignado
        _Monto_Vuelto = _Monto_Asignado - _Monto_Total

        If _Monto_Vuelto < 0 Then _Monto_Vuelto = 0
        If _Monto_Saldo < 0 Then _Monto_Saldo = 0

        _Fila_Md.Item("SALDO_ACTUAL") = _Monto_Saldo

        Lbl_Total_a_pagar.Text = FormatCurrency(_Monto_Total, 0)
        Lbl_Asignado.Text = FormatCurrency(_Monto_Asignado, 0)
        Lbl_Saldo.Tag = _Monto_Saldo
        Lbl_Saldo.Text = FormatCurrency(_Monto_Saldo, 0)
        Lbl_Vuelto.Text = FormatCurrency(_Monto_Vuelto, 0)

        If _Monto_Saldo > 0 Then
            If Global_Thema = Enum_Themas.Oscuro Then
                Lbl_Saldo.ForeColor = Color.FromArgb(221, 80, 68)
            Else
                Lbl_Saldo.ForeColor = Color.Red
            End If
        Else
            If Global_Thema = 2 Then ' Dark
                Lbl_Saldo.ForeColor = Color.White
            Else
                Lbl_Saldo.ForeColor = Color.Black
            End If
        End If

        Me.Refresh()

    End Sub

    Sub Sb_Tabla_Maeedo()

        With Grilla_Maeedo

            .DataSource = _Tbl_Maeedo

            OcultarEncabezadoGrilla(Grilla_Maeedo, True)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0
            .Columns("TIDO").ReadOnly = True

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 1
            .Columns("NUDO").ReadOnly = True

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = 2
            .Columns("ENDO").ReadOnly = True

            .Columns("MODO").HeaderText = "M"
            .Columns("MODO").Width = 30
            .Columns("MODO").Visible = True
            .Columns("MODO").DisplayIndex = 3
            .Columns("MODO").ReadOnly = True
            .Columns("MODO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("VABRDO").HeaderText = "Valor Documento"
            .Columns("VABRDO").Width = 110
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("VABRDO").DisplayIndex = 4
            .Columns("VABRDO").ReadOnly = True

            '.Columns("VABRDO").HeaderText = "Número"
            '.Columns("VABRDO").Width = 80
            '.Columns("VABRDO").Visible = True

            .Columns("SALDO_ANTERIOR").HeaderText = "Saldo Anterior"
            .Columns("SALDO_ANTERIOR").Width = 90
            .Columns("SALDO_ANTERIOR").Visible = True
            .Columns("SALDO_ANTERIOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_ANTERIOR").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("SALDO_ANTERIOR").DisplayIndex = 5
            .Columns("SALDO_ANTERIOR").ReadOnly = True

            .Columns("PAGO_ACTUAL").HeaderText = "Pago Actual"
            .Columns("PAGO_ACTUAL").Width = 85
            .Columns("PAGO_ACTUAL").Visible = True
            .Columns("PAGO_ACTUAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PAGO_ACTUAL").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("PAGO_ACTUAL").DisplayIndex = 6
            .Columns("PAGO_ACTUAL").ReadOnly = True

            .Columns("SALDO_ACTUAL").HeaderText = "Saldo Actual"
            .Columns("SALDO_ACTUAL").Width = 85
            .Columns("SALDO_ACTUAL").Visible = True
            .Columns("SALDO_ACTUAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_ACTUAL").DefaultCellStyle.Format = "$ ###,##.##"
            .Columns("SALDO_ACTUAL").DisplayIndex = 7
            .Columns("SALDO_ACTUAL").ReadOnly = True

            .Columns("NUVEDO").HeaderText = "#N"
            .Columns("NUVEDO").Width = 30
            .Columns("NUVEDO").Visible = True
            .Columns("NUVEDO").DisplayIndex = 8
            .Columns("NUVEDO").ReadOnly = True
            .Columns("NUVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("FE01VEDO").HeaderText = "1er Venc."
            .Columns("FE01VEDO").Width = 75
            .Columns("FE01VEDO").Visible = True
            .Columns("FE01VEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FE01VEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FE01VEDO").DisplayIndex = 9
            .Columns("FE01VEDO").ReadOnly = True

            .Columns("FEULVEDO").HeaderText = "Ult. Venc."
            .Columns("FEULVEDO").Width = 75
            .Columns("FEULVEDO").Visible = True
            .Columns("FEULVEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEULVEDO").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEULVEDO").DisplayIndex = 10
            .Columns("FEULVEDO").ReadOnly = True

        End With

    End Sub

    Sub Sb_Tabla_Maedpce()

        Consulta_sql = "SELECT TOP 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS," &
                       "CAST(0 AS INT) AS IDMAEEDO,CAST(0 AS FLOAT) AS SALDO,Cast(0 As Float) As LEY20956" & vbCrLf &
                       "FROM MAEDPCE WITH ( NOLOCK ) " & vbCrLf &
                       "WHERE 1 = 0"

        _Tbl_Maedpce = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Maedpce

            .DataSource = _Tbl_Maedpce

            OcultarEncabezadoGrilla(Grilla_Maedpce, True)

            .Columns("TIDP").HeaderText = "TD"
            .Columns("TIDP").Width = 40
            .Columns("TIDP").Visible = True

            .Columns("FEEMDP").HeaderText = "F.Emisión"
            .Columns("FEEMDP").Width = 80
            .Columns("FEEMDP").Visible = True
            .Columns("FEEMDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEEMDP").DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns("FEVEDP").HeaderText = "F.venci."
            .Columns("FEVEDP").Width = 80
            .Columns("FEVEDP").Visible = True
            .Columns("FEVEDP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEVEDP").DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns("MODP").HeaderText = "Mon"
            .Columns("MODP").Width = 20
            .Columns("MODP").Visible = True

            .Columns("VADP").HeaderText = "Monto"
            .Columns("VADP").Width = 80
            .Columns("VADP").Visible = True
            .Columns("VADP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VADP").DefaultCellStyle.Format = "$ ###,##.##"

        End With

        Sb_Nueva_Linea_De_Pago()

    End Sub

    Private Sub Sb_Nueva_Linea_De_Pago()

        Dim NewFila As DataRow
        NewFila = _Tbl_Maedpce.NewRow

        With NewFila

            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = _Tbl_Maeedo.Rows(0).Item("ENDO")
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = FechaDelServidor()
            .Item("FEVEDP") = FechaDelServidor()

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAVUDP") = 0
            .Item("ESPGDP") = String.Empty
            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("ESASDP") = "A" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, SALDO A FAVOR DEL CLIENTE
            .Item("ESPGDP") = ""
            .Item("CUOTAS") = 0

            .Item("IDMAEEDO") = 0
            .Item("SALDO") = 0
            .Item("LEY20956") = 0

            _Tbl_Maedpce.Rows.Add(NewFila)

        End With

    End Sub

    Private Function Fx_Nueva_Linea_De_Pago(_Tbl As DataTable) As DataRow

        Dim NewFila As DataRow
        NewFila = _Tbl.NewRow

        With NewFila

            .Item("IDMAEDPCE") = 0
            .Item("EMPRESA") = ModEmpresa
            .Item("SUREDP") = ModSucursal
            .Item("CJREDP") = ModCaja

            .Item("TIDP") = String.Empty
            .Item("NUDP") = String.Empty

            .Item("ENDP") = _Tbl_Maeedo.Rows(0).Item("ENDO")
            .Item("EMDP") = String.Empty   ' CODIGO EMISOR DE DOCUMENTO, BANCO, TIPO TARJETA, ETC.
            .Item("SUEMDP") = String.Empty ' ??
            .Item("CUDP") = String.Empty   ' NRO CTA. CTE.
            .Item("NUCUDP") = String.Empty ' NRO DEL CHEQUE
            .Item("FEEMDP") = FechaDelServidor()
            .Item("FEVEDP") = FechaDelServidor()

            .Item("MODP") = _Modp
            .Item("TIMODP") = _Timodp
            .Item("TAMODP") = _Tamodp

            .Item("VADP") = 0
            .Item("VAABDP") = 0
            .Item("VAASDP") = 0
            .Item("VAVUDP") = 0
            .Item("ESPGDP") = String.Empty
            .Item("REFANTI") = String.Empty
            .Item("KOTU") = 1
            .Item("KOFUDP") = FUNCIONARIO
            .Item("KOTNDP") = RutEmpresa
            .Item("SUTNDP") = ModCaja

            .Item("NUTRANSMI") = ""
            .Item("DOCUENANTI") = ""

            .Item("ESASDP") = "A" ' ESTADO ASIGNACION DEL PAGO A = ASIGNADO A UN DOCUMENTO, P = NO ASIGNADO O PARCIALMENTE ASIGNADO, ES DECIR, 
            .Item("ESPGDP") = ""
            .Item("CUOTAS") = 0

        End With

        Return NewFila

    End Function

    Private Sub Grilla_Maedpce_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellEndEdit

        Dim _Cabeza = Grilla_Maedpce.Columns(e.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tidp As String = _Fila.Cells("TIDP").Value

        If _Cabeza = "VADP" Then

            Dim _Saldo As Double = _Fila.Cells("SALDO").Value
            Dim _Vadp As Double = _Fila.Cells("VADP").Value

            If _Tidp = "ncv" Then

                If _Vadp > _Saldo Then

                    MessageBoxEx.Show(Me, "Valor máximo de la nota de crédito es de " & FormatCurrency(_Saldo, 0),
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _Fila.Cells("VADP").Value = _Saldo

                End If

            End If

            Sb_Sumar_Totales()

        End If

        Dim _Feemdp As Date = FormatDateTime(_Fila.Cells("FEEMDP").Value, DateFormat.ShortDate)
        Dim _Fevedp As Date = FormatDateTime(_Fila.Cells("FEVEDP").Value, DateFormat.ShortDate)

        If _Feemdp > _Fevedp Then

            MessageBoxEx.Show(Me, "La fecha de vencimiento no puede ser menor a la fecha de emisión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Fila.Cells("FEVEDP").Value = _Feemdp

        End If

        Grilla_Maedpce.Columns("VADP").ReadOnly = True
        Grilla_Maedpce.Columns("FEVEDP").ReadOnly = True

        Bar1.Enabled = True

    End Sub

    Private Sub Grilla_Maedpce_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Maedpce.KeyDown

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Idmaedpce As Integer = _Fila.Cells("IDMAEDPCE").Value
        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)

        Dim _Tecla As Keys = e.KeyValue

        Select Case _Tecla

            Case Keys.Down

                If Not String.IsNullOrEmpty(_Tidp) Then

                    If CBool(_Vadp) Then

                        Dim _Filas As Integer = Grilla_Maedpce.Rows.Count - 1

                        Dim _X_Columna As Integer = Grilla_Maedpce.CurrentCellAddress.X
                        Dim _Y_Fila As Integer = Grilla_Maedpce.CurrentCellAddress.Y

                        If _Filas = _Y_Fila Then

                            If _Monto_Saldo > 0 Then
                                Sb_Nueva_Linea_De_Pago()
                                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(_Filas + 1).Cells("TIDP")
                            Else
                                Beep()
                                ToastNotification.Show(Me, "EL PAGO YA ESTA COMPLETO",
                                                       My.Resources.cross,
                                                       1 * 1000, eToastGlowColor.Red,
                                                       eToastPosition.MiddleCenter)
                            End If

                        End If

                    End If

                End If

            Case Keys.Delete

                Grilla_Maedpce.Rows.RemoveAt(Grilla_Maedpce.CurrentRow.Index)
                Grilla_Maedpce.Refresh()

                If Grilla_Maedpce.Rows.Count = 0 Then
                    Sb_Tabla_Maedpce()
                Else
                    Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.Rows.Count - 1).Cells("TIDP")
                End If

                Sb_Sumar_Totales()

            Case Keys.Enter

                If _Cabeza = "VADP" Then

                    If Not String.IsNullOrEmpty(_Tidp) Then

                        If _Tidp = "ncv" Then

                            Beep()
                            ToastNotification.Show(Me, "NO SE PUEDE CAMBIAR EL VALOR DE LA NOTA DE CREDITO",
                                                   My.Resources.cross,
                                                  1 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)

                            Return

                        End If

                        If CBool(_Idmaedpce) Then

                            Beep()
                            ToastNotification.Show(Me, "PAGO CON SALDO A FAVOR DESDE LA CTA. CTE. NO PUEDE SER MODIFICADO",
                                                   My.Resources.cross,
                                                  2 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)

                            Return

                        End If

                        Grilla_Maedpce.Columns("VADP").ReadOnly = False

                        Dim _Saldo As Double

                        If _Vadp = 0 Then

                            Dim _Aplicar_Redondeo As Boolean
                            Dim _Ley20956 As Double

                            If _Aplica_Ley_20956 Then

                                Dim _FilaPg As DataRow = _Tbl_Maedpce.Rows(_Tbl_Maedpce.Rows.Count - 1)

                                _Aplicar_Redondeo = (_FilaPg.Item("TIDP") = "EFV")

                                Dim _Ult_Unidad As Double = Mid(_Monto_Saldo, _Monto_Saldo.ToString.Length, 1)

                                If _Ult_Unidad <= 5 Then
                                    _Ley20956 = _Ult_Unidad
                                    _Vadp = _Monto_Saldo - _Ley20956
                                Else
                                    _Ley20956 = _Ult_Unidad - 10
                                    _Vadp = _Monto_Saldo + (_Ley20956 * -1)
                                End If

                            Else

                                _Vadp = _Monto_Saldo
                                _Saldo = _Fila.Cells("SALDO").Value

                            End If

                            If _Tidp = "ncv" Then
                                If _Vadp > _Saldo Then
                                    _Vadp = _Saldo
                                End If
                            End If

                            _Fila.Cells("VADP").Value = _Vadp

                        End If

                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Maedpce.BeginEdit(True)

                    Else

                        Beep()
                        ToastNotification.Show(Me, "DEBE INGRESAR EL TIPO DE PAGO",
                                                   My.Resources.cross,
                                                  1 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)

                    End If

                ElseIf _Cabeza = "TIDP" Then

                    If String.IsNullOrEmpty(_Tidp) Then

                        Dim _Tido = Grilla_Maeedo.Rows(0).Cells("TIDO").Value

                        If String.IsNullOrEmpty(_Tido) Then
                            Beep()
                            ToastNotification.Show(Me, "NO HAY DOCUMENTOS QUE PAGAR",
                                                   My.Resources.cross,
                                                  1 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)
                        Else

                            Sb_Ingresar_Linea_de_pago()

                        End If

                    End If

                ElseIf _Cabeza = "FEEMDP" Or _Cabeza = "FEVEDP" Then

                    If _Tidp <> "EFV" And Not CBool(_Idmaedpce) Then

                        Grilla_Maedpce.Columns(_Cabeza).ReadOnly = False
                        SendKeys.Send("{F2}")
                        e.Handled = True
                        Grilla_Maedpce.BeginEdit(True)

                    End If

                End If

        End Select

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Validar As TextBox = CType(e.Control, TextBox)

        If _Cabeza = "VADP" Then
            AddHandler _Validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        Else
            RemoveHandler _Validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla
        End If

    End Sub

    Private Sub Btn_Pago_Efectivo_Click(sender As System.Object, e As System.EventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        _Fila.Cells("TIDP").Value = "EFV"
        _Fila.Cells("ESPGDP").Value = "C"
        Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")

    End Sub

    Private Sub Grilla_Maeedo_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maeedo.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla_Maeedo.Rows(Grilla_Maeedo.CurrentRow.Index)

        Dim _Tido As String = _Fila.Cells("TIDO").Value
        Dim _Nudo As String = _Fila.Cells("NUDO").Value

        If String.IsNullOrEmpty(_Tido) Then

            If Fx_Buscar_Documento(_Nudo, True) Then

                Grilla_Maedpce.Focus()
                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(0).Cells("TIDP")

                Beep()
                Sb_Ingresar_Linea_de_pago()

            Else
                _Fila.Cells("NUDO").Value = String.Empty
            End If

        End If


    End Sub

    Function Fx_Buscar_Documento(_Nro_Documento As String,
                                 _Mostrar_Mensaje As Boolean) As Boolean

        Dim _Tido = Mid(_Nro_Documento, 1, 3)
        Dim _Nudo = Mid(_Nro_Documento, 4, 10)

        Consulta_sql = "SELECT top 1 EMPRESA,IDMAEEDO,TIDO,NUDO,ENDO,SUDO,TIMODO,MODO,NUVEDO," &
                       "FE01VEDO,VABRDO,VABRDO-VAABDO AS SALDO_ANTERIOR,VAABDO," &
                       "CAST(0 AS FLOAT) AS PAGO_ACTUAL," &
                       "CAST(0 AS FLOAT) AS PAGO_CHEQUE," &
                       "CAST(0 AS FLOAT) AS SALDO_ACTUAL," &
                       "NUDONODEFI,VAPIDO,SUENDO,FEULVEDO,HORAGRAB," &
                       "MAEEN.NOKOEN,ESPGDO,ESDO" & vbCrLf &
                       "FROM MAEEDO AS EDO WITH ( NOLOCK ) LEFT OUTER JOIN MAEEN ON ENDO=MAEEN.KOEN AND" & Space(1) &
                       "SUENDO=MAEEN.SUEN" & vbCrLf &
                       "WHERE EMPRESA = '" & ModEmpresa & "' And TIDO = '" & _Tido & "' AND NUDO = '" & _Nudo & "'" & vbCrLf &
                       "AND TIDO IN ('BLV','BSV','FCV','FDV','NCV')"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If Not (_Tbl Is Nothing) Then

            If CBool(_Tbl.Rows.Count) Then

                If _Tbl.Rows(0).Item("ESPGDO") <> "P" Then

                    If _Mostrar_Mensaje Then
                        MessageBoxEx.Show(Me, "DOCUMENTO PAGADO", "VALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    Return False

                End If

                _Tbl_Maeedo = _Tbl
                Sb_Tabla_Maeedo()

            Else

                If Not String.IsNullOrEmpty(_Nudo) Then

                    Beep()
                    ToastNotification.Show(Me, "DOCUMENTO NO EXISTE",
                                           My.Resources.cross,
                                           1 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)

                End If

            End If

            Sb_Tabla_Maedpce()
            Sb_Sumar_Totales()

            Sb_Revisar_Si_Hay_Archivos_Adjuntos()

            Return CBool(_Tbl.Rows.Count)

        End If

    End Function



    Private Sub Grilla_Maeedo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Grilla_Maeedo.KeyDown

        Dim _Cabeza = Grilla_Maeedo.Columns(Grilla_Maeedo.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maeedo.Rows(0)

        Dim _Tido As String = _Fila.Cells("TIDO").Value


        If _Cabeza = "NUDO" Then

            If e.KeyValue = Keys.Enter Then

                If String.IsNullOrEmpty(_Tido) Then

                    Grilla_Maeedo.Columns("NUDO").ReadOnly = False

                    SendKeys.Send("{F2}")
                    e.Handled = True
                    Grilla_Maedpce.BeginEdit(True)

                End If
            End If
        End If

    End Sub


    Private Sub Btn_Buscar_Documentos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Buscar_Documentos.Click

        Dim _Fm As New Frm_BusquedaDocumento_Filtro(False)

        With _Fm

            .Grupo_Funcionario.Enabled = False
            .Rdb_Funcionarios_Uno.Checked = True
            .Pro_Sql_Filtro_Otro_Filtro = "" '"AND ESPGDO='P' AND SUDO = '" & ModSucursal & "'"
            .Pro_TipoDoc_Seleccionado = Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado
            .Rdb_Tipo_Documento_Uno.Checked = True

            Dim _Condicion As String = "WHERE TIDO IN ('BLV','BSV','FCV','FDV','NCV')" & vbCrLf &
                                       "Union" & vbCrLf &
                                       "SELECT '' As Padre,'Cualquiera...' as Hijo"


            .Sb_LlenarCombo_FlDoc(Frm_BusquedaDocumento_Filtro._TipoDoc_Sel.Personalizado, "", _Condicion)
            .Rdb_Funcionarios_Uno.Checked = True
            .Grupo_Funcionario.Enabled = False
            .Rdb_Fecha_Emision_Desde_Hasta.Checked = True
            .Pro_Pago_a_Documento = True
            .Rdb_Funcionarios_Todos.Checked = True

            .ShowDialog(Me)

            If Not (.Pro_Row_Documento_Seleccionado Is Nothing) Then

                Dim _Tido = .Pro_Row_Documento_Seleccionado.Item("TIDO")
                Dim _Nudo = .Pro_Row_Documento_Seleccionado.Item("NUDO")
                Dim _Nro_Documento As String = _Tido & _Nudo

                If Fx_Buscar_Documento(_Nro_Documento, True) Then
                    Beep()
                    Grilla_Maedpce.Focus()
                    Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(0).Cells("TIDP")
                End If

            End If

            .Dispose()
        End With


    End Sub

    Sub Sb_Actualizar_Campos_Tbl_Maedpce()

        ' FALTA CALCULAR LAS ASIGNACIONES Y VUELTOS DE CADA FILA EN LA MAEDPCE

        Dim _Saldo_Anterior = Grilla_Maeedo.Rows(0).Cells("SALDO_ANTERIOR").Value
        Dim _Saldo_Actual As Double = _Saldo_Anterior
        Dim _Valor_Asignado As Double = 0

        Dim _Contador = 1

        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            _Fila.Item("VAVUDP") = 0
            _Fila.Item("VAASDP") = 0
            _Fila.Item("VAABDP") = 0

            Dim _Vadp As Double = _Fila.Item("VADP")
            Dim _Vaasdp As Double = 0
            Dim _Vaabdp As Double = 0
            Dim _Vavudp As Double = 0
            Dim _Tidp As String = _Fila.Item("TIDP")
            Dim _Ley20956 As Double = _Fila.Item("LEY20956")

            If _Saldo_Actual > 0 Then

                If _Tbl_Maedpce.Rows.Count = _Contador Then
                    _Vavudp = _Vadp - _Saldo_Actual
                    _Saldo_Actual = _Saldo_Actual - _Vadp
                    _Valor_Asignado = _Vadp + _Saldo_Actual
                Else
                    _Saldo_Actual = _Saldo_Actual - _Vadp
                    _Valor_Asignado = _Vadp
                End If

            Else

                _Vavudp = _Vadp
                _Saldo_Anterior = 0
                _Saldo_Actual = 0
                _Valor_Asignado = 0

            End If

            If _Vavudp < 0 Then
                _Valor_Asignado += _Vavudp
                _Vavudp = 0
            End If

            _Vavudp += _Ley20956

            'If _Vadp > _Saldo_Anterior Then
            '    _Vaasdp = _Valor_Asignado
            '    _Vavudp = 0
            'Else
            _Vaasdp = _Valor_Asignado '_Vadp
            'End If

            If _Tidp = "EFV" Or _Tidp = "EFC" Or _Tidp = "ncv" Then
                _Vaabdp = _Vadp
            End If

            If _Vavudp > 0 And _Desde_Documento Then

                Dim Rdb_Anticipo As New Command
                Rdb_Anticipo.Checked = True
                Rdb_Anticipo.Name = "Rdb_Anticipo"
                Rdb_Anticipo.Text = "Dejar como anticipo del cliente"

                Dim Rdb_Vuelto As New Command
                Rdb_Vuelto.Checked = False
                Rdb_Vuelto.Name = "Rdb_Vuelto"
                Rdb_Vuelto.Text = "Dar vuelto"

                Dim _Opciones() As Command = {Rdb_Anticipo, Rdb_Vuelto}

                Dim _Info As New TaskDialogInfo("Pago a documentos",
                                      eTaskDialogIcon.Users,
                                      "Saldo a favor por " & FormatCurrency(_Vavudp, 0),
                                      "¿Que hara con este saldo a favor?",
                                      eTaskDialogButton.Ok,
                                      eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

                Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

                If Rdb_Anticipo.Checked Then

                    Dim _Refanti = String.Empty

                    InputBox_Bk(Me, "Descripción anticipo", "Valor anticipo", _Refanti, True,, 80)

                    _Fila.Item("ESASDP") = "P"
                    _Fila.Item("REFANTI") = _Refanti.ToUpper

                End If

                If Rdb_Vuelto.Checked Then

                    _Fila.Item("VAVUDP") = _Vavudp

                End If

            Else

                If _Vavudp > 0 Then

                    If _Tidp = "EFV" Or _Tidp = "EFC" Then
                        _Fila.Item("VAVUDP") = _Vavudp
                    Else

                        Dim _Refanti = String.Empty

                        InputBox_Bk(Me, "Hay un saldo a favor del cliente por " & FormatCurrency(_Vavudp, 0) & vbCrLf &
                                "Este saldo a favor quedara como anticipo en la cuenta corriente del cliente." & vbCrLf &
                                "Ingrese la descripción del anticipo", "Valor anticipo", _Refanti, False, _Tipo_Mayus_Minus.Mayusculas)

                        _Fila.Item("ESASDP") = "P"
                        _Fila.Item("REFANTI") = _Refanti.ToUpper

                    End If

                End If

            End If

            _Fila.Item("VAASDP") = _Vaasdp
            _Fila.Item("VAABDP") = _Vaabdp

            _Contador += 1

        Next

    End Sub

    Sub Sb_Pagar_Vale_Transitorio(_Idmaeedo As Integer,
                                  _Pagar As Boolean)

        Dim _Iddt As Integer

        Dim _Tido = _Tbl_Maeedo.Rows(0).Item("TIDO")
        Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido, , Modalidad) ' _Class_DTE.Pro_Nro_Documento

        Dim _Tidoelec As Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

        Dim _Nudonodefi = _Tbl_Maeedo.Rows(0).Item("NUDONODEFI")

        If CBool(_Tidoelec) And CBool(_Nudonodefi) Then

            If Not Fx_Revisar_Expiracion_Folio_SII(Me, _Tido, _Nro_Documento) Then

                MessageBoxEx.Show(Me, "El documento no fue grabado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Nuevo_Documento()
                Return

            End If

        End If

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _Tido & "' And NUDO = '" & _Nro_Documento & "' And IDMAEEDO <> " & _Idmaeedo)

        If CBool(_Reg) Then
            _Nro_Documento = Traer_Numero_Documento(_Tido, , Modalidad)
        End If

        Consulta_sql = "Update MAEEDO Set NUDO='" & _Nro_Documento & "',NUDONODEFI=0,TIDOELEC=" & _Tidoelec & " Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                       "Update MAEDDO Set NUDO='" & _Nro_Documento & "' Where IDMAEEDO=" & _Idmaeedo

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

            Fx_Cambiar_Numeracion_Modalidad(_Tido, Modalidad)

            Dim _Nudo_Old = _Tbl_Maeedo.Rows(0).Item("NUDO")

            Try

                If CBool(_Tidoelec) Then

                    Sb_Firmar_Documento_Electronico(Me, _Idmaeedo, _Tido)

                    'Dim _Class_DTE As New Class_Genera_DTE_RdBk(_Idmaeedo)
                    'Dim _Firma_Bakapp As Boolean
                    'Dim _Firma_RunMonitor As Boolean

                    'Try
                    '    If _Global_Row_Configuracion_General.Item("FacElec_Bakapp_Hefesto") Then
                    '        _Firma_Bakapp = True
                    '    Else
                    '        _Firma_RunMonitor = True
                    '    End If
                    'Catch ex As Exception
                    '    _Firma_RunMonitor = True
                    'End Try

                    'If _Firma_RunMonitor Then
                    '    _Iddt = _Class_DTE.Fx_Dte_Genera_Documento(Me, False)
                    '    If CBool(_Iddt) Then
                    '        _Class_DTE.Fx_Dte_Firma(Me, _Iddt, False)
                    '    End If
                    'End If

                    'If _Firma_Bakapp Then

                    '    Dim _Id_Dte As Integer
                    '    Dim _Icono As Image = My.Resources.Recursos_DTE.script_edit
                    '    Me.Cursor = Cursors.WaitCursor

                    '    Try
                    '        Lbl_Version.Text = "Versión: " & _Global_Version_BakApp & "... Firmando documento electrónico DTE"
                    '        Me.Refresh()

                    '        If CBool(_Class_DTE.Fx_FirmarXHefesto()) Then
                    '            ToastNotification.Show(Me, "FIRMADO...", _Icono, 3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    '        End If

                    '    Catch ex As Exception
                    '    Finally
                    '        Me.Enabled = True
                    '        Application.DoEvents()
                    '        Me.Cursor = Cursors.Default
                    '    End Try

                    'End If

                End If

            Catch ex As Exception

                Consulta_sql = "Update MAEEDO Set NUDO='" & _Nudo_Old & "',NUDONODEFI=1,TIDOELEC=" & _Tidoelec & " Where IDMAEEDO=" & _Idmaeedo & vbCrLf &
                               "Update MAEDDO Set NUDO='" & _Nudo_Old & "' Where IDMAEEDO=" & _Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_sql)
                _Nro_Documento = String.Empty

                MessageBoxEx.Show(Me, ex.Message, "Error al crear DTE", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Try
            'FIRMA ELECTRONICA 


        End If

        ' *****  ERROR EN CAJA CUANDO IMPRIME Y NO ENCUENTRA EL FORMATO POR LA MODALIDAD DE BAKAPP

        If Not String.IsNullOrEmpty(_Nro_Documento) Then

            ' *********************************************************************
            Dim _Error_PDF As String

            _Error_PDF = Fx_Guargar_PDF_Automaticamente_Por_Doc_Modalidad(_Idmaeedo)

            If Not String.IsNullOrEmpty(_Error_PDF) Then
                MessageBoxEx.Show(Me, _Error_PDF, "Error al querer grabar PDF automático", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Sb_Imprimir_Doc(_Idmaeedo, _Tido)

            If Not IsNothing(_Row_CashDro) Then
                If _Post_Integrado_Transbank_Activo Then 'Chk_Usar_Post_Integrado.Checked And Chk_Post_Integrado.Checked Then
                    _Impresora = _Row_CashDro.Item("Impresora_Predeterminada")
                    Sb_Imprimir_Voucher_Tarjeta_Bakapp(Me, _Idmaeedo, _Impresora)
                End If
            End If

            If _Pagar Then

                Dim _Clas_Pagar As New Clas_Pagar

                Dim _FechaDelServidor = FechaDelServidor()

                If _Sql.Fx_Exite_Campo("MAEDPCE", "LEY20956") Then
                    _Clas_Pagar.Fx_Crear_Pago_MAEDPCE2(Me, _Idmaeedo, _Tbl_Maedpce, _FechaDelServidor)
                Else
                    _Clas_Pagar.Fx_Crear_Pago_MAEDPCE(Me, _Idmaeedo, _Tbl_Maedpce, _FechaDelServidor)
                End If

                'Sb_Pagar_NCV(_Idmaeedo)
                _Clas_Pagar.Fx_Pagar_NCV(Me, _Tbl_Maedpce, _Idmaeedo)

            End If

            ' ACTIVACION DE ORDENES DE DESPACHO *---------------------------------------------------------

            Consulta_sql = "Select IDRST From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            Dim _TblDetalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
            Dim _Filtro_Idmaeddo_Dori = Generar_Filtro_IN(_TblDetalle, "", "IDRST", True, False, "")

            Consulta_sql = "Select Distinct Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc_Det 
                            Where Idmaeedo In (Select IDMAEEDO From MAEDDO Where IDMAEDDO In " & _Filtro_Idmaeddo_Dori & ") Or Idmaeedo = " & _Idmaeedo
            Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

            For Each _Fl As DataRow In _Tbl.Rows

                Dim _Id_Despacho = _Fl.Item("Id_Despacho")
                Dim _Cl_Despacho As New Clas_Despacho_Fx
                _Cl_Despacho.Sb_Actualizar_Despachos(_Id_Despacho)
                _Cl_Despacho.Fx_Enviar_Despacho_Chilexpress(_Id_Despacho)

            Next

            'Revision Chilexpress

            'If CBool(_Tbl.Rows.Count) Then

            '    Dim _Filtro_Id_Despacho = Generar_Filtro_IN(_Tbl, "", "Id_Despacho", False, False, "'")
            '    Dim _Id_Despacho = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Despachos", "Id_Despacho_Padre", "Id_Despacho In " & _Filtro_Id_Despacho, True)

            '    If CBool(_Id_Despacho) Then
            '    End If

            'End If

            ' IMPRIMIR EN DIABLITO

            Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
            _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Modalidad, _Idmaeedo)

            '***********************************************************************************************


            ' Incorporación de Permisos

            Consulta_sql = String.Empty

            For Each _Row As DataRow In Ds_Matriz_Documentos.Tables("Permisos_Doc").Rows

                Dim _CodPermiso = _Row.Item("CodPermiso")
                Dim _Necesita_Permiso = _Row.Item("Necesita_Permiso")
                Dim _Solicitado_Por_Cadena = _Row.Item("Solicitado_Por_Cadena")

                If _Necesita_Permiso Then

                    Dim _Autorizado = _Row.Item("Autorizado")
                    Dim _CodFuncionario_Autoriza = _Row.Item("CodFuncionario_Autoriza")
                    Dim _NroRemota = NuloPorNro(_Row.Item("NroRemota"), "")
                    Dim _Permiso_Presencial = _Row.Item("Permiso_Presencial")
                    Dim _Fecha_Otorga As DateTime? = Nothing

                    If _Solicitado_Por_Cadena Then

                        If Not String.IsNullOrEmpty(_NroRemota) Then

                            _Fecha_Otorga = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Remotas", "Fecha_Otorga", "NroRemota = '" & _NroRemota & "'")

                        End If

                    End If

                    If _Permiso_Presencial Then

                        Dim _Koen As String = _Tbl_Maeedo.Rows(0).Item("ENDO")
                        Dim _Suendo As String = _Tbl_Maeedo.Rows(0).Item("SUENDO")

                        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suendo)

                        _NroRemota = Fx_Solicitar_Remota(FUNCIONARIO, _CodPermiso, "", 0,
                                             _RowEntidad.Item("KOEN"),
                                             _RowEntidad.Item("NOKOEN"), False, _RowEntidad.Item("SUEN"), _Permiso_Presencial,
                                             _Idmaeedo, _CodFuncionario_Autoriza, "", _Fecha_Otorga, _NroRemota)

                    End If

                    If Not String.IsNullOrEmpty(_NroRemota) Then

                        Consulta_sql += "Update " & _Global_BaseBk & "Zw_Remotas Set Idmaeedo = " & _Idmaeedo & Environment.NewLine &
                                        "Where NroRemota = '" & _NroRemota & "'" & Environment.NewLine

                    End If

                End If

            Next

            If Not String.IsNullOrEmpty(Consulta_sql) Then
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If


            MessageBoxEx.Show(Me, _Tido & " - " & _Nro_Documento & vbCrLf & vbCrLf &
                              "Grabada correctamente", "Grabar documento", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Sb_Nuevo_Documento()

        End If

    End Sub

    Sub Sb_Imprimir_Doc(_Idmaeedo As Integer, _Tido As String)

        Dim _Imp = _Impresora

        If String.IsNullOrEmpty(_Imp) Then
            Dim Fm As New Frm_Seleccionar_Impresoras("")
            Fm.ShowDialog(Me)
            If (String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada)) Then
                Return
            Else
                _Imp = Fm.Pro_Impresora_Seleccionada
            End If
            Fm.Dispose()
        End If

        Consulta_sql = "Select Top 1 Modalidad, TipoDoc, NombreFormato" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And TipoDoc = '" & _Tido & "' And Modalidad = '" & Modalidad & "'"

        Dim _RowNombreFormato As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
        Dim _NombreFormato = _RowNombreFormato.Item("NombreFormato")

        Dim _Imprime As String = Fx_Enviar_A_Imprimir_Documento(Me, _NombreFormato, _Idmaeedo,
                                                                False, False, _Imp, False, 0, False, "")

        If Not String.IsNullOrEmpty(Trim(_Imprime)) Then
            MessageBox.Show(Me, _Imprime, "Problemas al Imprimir",
                       MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Pagar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Pagar.Click

        If Desde_Documento Then
            Sb_Grabar_Pago_A_Documento_Desde_Documento()
        Else
            Sb_Grabar_Pago_A_Documento(False)
        End If

    End Sub

    Sub Sb_Grabar_Pago_A_Documento(_Pago_Cta_Cte As Boolean,
                                   Optional _Pago_desde_CashDro As Boolean = False,
                                   Optional ByRef _Idmaedpce As Integer = 0)

        Dim _Idmaeedo As Integer = _Tbl_Maeedo.Rows(0).Item("IDMAEEDO")
        Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")

        Dim _Permiso_Pagar As Boolean

        If CBool(_Idmaeedo) Or Desde_Documento Then

            Dim _Nudonodefi As Boolean = _Tbl_Maeedo.Rows(0).Item("NUDONODEFI")

            Sb_Actualizar_Campos_Tbl_Maedpce()

            Dim _Tb As DataTable = _Tbl_Maedpce
            Dim _Tb_P As DataTable = _Tbl_Maeedo

            Dim _Vabrdo As Double = _Tbl_Maeedo.Rows(0).Item("VABRDO")
            Dim _Saldo_Actual As Double = _Tbl_Maeedo.Rows(0).Item("SALDO_ACTUAL")

            Dim _Koen As String = _Tbl_Maeedo.Rows(0).Item("ENDO")
            Dim _Suendo As String = _Tbl_Maeedo.Rows(0).Item("SUENDO")

            Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suendo)
            Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()

            'DEBO PONER UN GATILLO PARA QUE SE PUEDA SALTAR ESTA PARTE

            If Not _Pago_desde_CashDro Then

                If _Vabrdo = _Saldo_Actual Then

                    If _Pago_Cta_Cte Then

                        If Not Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad) Then
                            Return
                        End If

                        _Permiso_Pagar = True

                    Else

                        Sb_Tabla_Maedpce()

                        If _Nudonodefi Then

                            If Not Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad) Then
                                Return
                            End If

                            _Permiso_Pagar = True

                        Else

                            Beep()
                            ToastNotification.Show(Me, "FALTA DETALLE DEL PAGO",
                                                   My.Resources.cross,
                                                   1 * 1000, eToastGlowColor.Red,
                                                   eToastPosition.MiddleCenter)

                        End If

                    End If

                Else

                    If Not Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad) Then
                        Return
                    End If

                    _Permiso_Pagar = True

                End If

                If _Permiso_Pagar And _Pago_Cta_Cte Then

                    _Autorizado_Grabar = True
                    Me.Close()

                End If

            Else

                _Fecha_Asignacion_Pago = _Tbl_Maedpce.Rows(0).Item("FEEMDP")
                _Permiso_Pagar = True

            End If

            Dim _Pagar As Boolean

            If _Pago_Cta_Cte Then
                _Pagar = False
            Else
                _Pagar = True
            End If

            If _Permiso_Pagar Then

                If _Nudonodefi Then

                    _Nudonodefi = _Sql.Fx_Trae_Dato("MAEEDO", "NUDONODEFI", "IDMAEEDO = " & _Idmaeedo)

                    If _Nudonodefi Then

                        Sb_Pagar_Vale_Transitorio(_Idmaeedo, _Pagar)

                    Else

                        MessageBoxEx.Show(Me, "Este documento ya no es un vale transitorio." & vbCrLf &
                                         "No se grabara ningún pago", "Transacción desecha", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Sb_Nuevo_Documento()

                    End If

                Else

                    If _Pagar Then

                        Dim _Clas_Pagar As New Clas_Pagar

                        If _Sql.Fx_Exite_Campo("MAEDPCE", "LEY20956") Then
                            _Idmaedpce = _Clas_Pagar.Fx_Crear_Pago_MAEDPCE2(Me, _Idmaeedo, _Tbl_Maedpce, _Fecha_Asignacion_Pago)
                        Else
                            _Idmaedpce = _Clas_Pagar.Fx_Crear_Pago_MAEDPCE(Me, _Idmaeedo, _Tbl_Maedpce, _Fecha_Asignacion_Pago)
                        End If

                        If CBool(_Idmaedpce) Then

                            _Clas_Pagar.Fx_Pagar_NCV(Me, _Tbl_Maedpce, _Idmaeedo)
                            Sb_Nuevo_Documento()

                        End If

                    End If

                End If

            End If

        Else

            Beep()
            ToastNotification.Show(Me, "FALTA DOCUMENTO A PAGAR",
                                   My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)

        End If

    End Sub

    Function Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad As DataRow) As Boolean

        Dim _CodPermiso As String
        Dim _Solicitar_Permiso As Boolean
        Dim _Rows_Usuario_Autoriza As DataRow
        Dim _Permiso_Presencial As Boolean
        Dim _Tiene_Permiso As Boolean

        Dim _Permiso_Pagar = Fx_Revisar_Credito_Cliente2(_RowEntidad, _CodPermiso, _Solicitar_Permiso, _Tiene_Permiso)

        If _Tiene_Permiso Then
            Return True
        End If

        If Not _Permiso_Pagar And _Solicitar_Permiso Then

            Dim _Objeto As Object

            If _Desde_Documento Then
                _Objeto = _Ds_Matriz_Documentos
            End If

            If Fx_Tiene_Permiso(Me, _CodPermiso,,,,, _RowEntidad.Item("KOEN"), _RowEntidad.Item("SUEN"),,,
                                _Rows_Usuario_Autoriza,,, _Permiso_Presencial, _Objeto) Then
                Fx_Insertar_Permiso_en_Tabla_Permisos(_Ds_Matriz_Documentos.Tables("Permisos_Doc"), _CodPermiso, _Rows_Usuario_Autoriza, _Permiso_Presencial)
                _Permiso_Pagar = True
            End If

        End If

        Return _Permiso_Pagar

    End Function

    Sub Sb_Grabar_Pago_A_Documento_Desde_Documento()

        Dim _Idmaeedo As Integer = _Tbl_Maeedo.Rows(0).Item("IDMAEEDO")
        Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")

        Dim _Permiso_Pagar As Boolean

        Dim _Nudonodefi As Boolean = _Tbl_Maeedo.Rows(0).Item("NUDONODEFI")

        Sb_Actualizar_Campos_Tbl_Maedpce()

        Dim _Tb As DataTable = _Tbl_Maedpce
        Dim _Tb_P As DataTable = _Tbl_Maeedo

        Dim _Vabrdo As Double = _Tbl_Maeedo.Rows(0).Item("VABRDO")
        Dim _Saldo_Actual As Double = _Tbl_Maeedo.Rows(0).Item("SALDO_ACTUAL")

        Dim _Koen As String = _Tbl_Maeedo.Rows(0).Item("ENDO")
        Dim _Suendo As String = _Tbl_Maeedo.Rows(0).Item("SUENDO")

        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suendo)
        Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()

        'DEBO PONER UN GATILLO PARA QUE SE PUEDA SALTAR ESTA PARTE

        'If Not Fx_Revisar_Pago_Obligatorio_X_Conceptos_X_Documento() Then
        '    Return
        'End If

        If _Vabrdo = _Saldo_Actual Then

            Sb_Tabla_Maedpce()

            If _Ocultar_Cta_Cte Then

                If _Tido = "BLV" Then

                    If Not Fx_Tiene_Permiso(Me, "Doc00041",,,,,,,,,,,,, _Ds_Matriz_Documentos) Then

                        Return

                    Else

                        _Permiso_Pagar = True

                    End If

                End If

            Else

                'If MessageBoxEx.Show(Me, "No hay pagos que realizar" & vbCrLf &
                '                             "¿Desea utilizar la Cta. Cte. del cliente?", "",
                '                             MessageBoxButtons.YesNo,
                '                             MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then

                '    _Permiso_Pagar = Fx_Revisar_Credito_Cliente(_RowEntidad)

                'End If
                If Not Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad) Then
                    Return
                End If

                _Permiso_Pagar = True

            End If

        Else

            'If CBool(_Saldo_Actual) Then

            '    Dim _Pagar_Con_Saldo = MessageBoxEx.Show(Me,
            '                                             "El documento no esta siendo pagado en su totalidad" & vbCrLf & vbCrLf &
            '                                             "quedara un saldo de " & FormatCurrency(_Saldo_Actual, 0) & vbCrLf & vbCrLf &
            '                                             "¿Desea continuar?",
            '                                             "Documento con saldo",
            '                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            '    If _Pagar_Con_Saldo <> Windows.Forms.DialogResult.Yes Then
            '        Return
            '    End If

            'End If

            '_Permiso_Pagar = Fx_Revisar_Credito_Cliente(_RowEntidad)

            If Not Fx_Permitir_Grabar_Sin_Pagar(_RowEntidad) Then
                Return
            End If

            _Permiso_Pagar = True

        End If

        If _Permiso_Pagar Then

            If Lbl_Ajuste_Por_Ley20956.Visible Then

                _Tbl_Maeedo.Rows(0).Item("VAABDO") = _Tbl_Maeedo.Rows(0).Item("VABRDO")

                If _Valor_Diferencia_Ley_20956 > 0 Then

                    Dim _New_Fila As DataRow = Fx_Nueva_Linea_De_Pago(_Tbl_Maedpce)
                    _New_Fila.Item("TIDP") = "EFV"
                    _New_Fila.Item("ESPGDP") = "C"
                    _New_Fila.Item("VADP") = _Valor_Diferencia_Ley_20956
                    _New_Fila.Item("VAABDP") = _Valor_Diferencia_Ley_20956
                    _New_Fila.Item("VAASDP") = _Valor_Diferencia_Ley_20956
                    _New_Fila.Item("LEY20956") = _Valor_Diferencia_Ley_20956
                    _Tbl_Maedpce.Rows.Add(_New_Fila)

                End If

            Else

                If Pro_Tbl_Maedpce.Rows.Count = 1 Then

                    If _Tbl_Maeedo.Rows(0).Item("TIDO") = "BLV" Then

                        _Es_TLV = True

                        For Each _Filas As DataRow In _Tbl_Maedpce.Rows

                            If _Filas.Item("TIDP") <> "TJV" Then

                                _Es_TLV = False
                                Exit For

                            End If

                        Next

                    End If

                End If

                _Tbl_Maeedo.Rows(0).Item("VAABDO") = _Tbl_Maeedo.Rows(0).Item("PAGO_ACTUAL")

            End If

            _Autorizado_Grabar = True

            Me.Close()

        End If

    End Sub

    Sub Sb_Pagar_NCV(_Idmaeedo As Integer)

        Dim _Clas_Pagar As New Clas_Pagar

        Consulta_sql = "Select Top 1 IDMAEDPCE,EMPRESA,SUREDP,CJREDP,TIDP,NUDP,ENDP,EMDP,SUEMDP,CUDP,NUCUDP,FEEMDP,FEVEDP,MODP," & vbCrLf &
                       "TIMODP,TAMODP,VADP,VAABDP,VAASDP,VAVUDP,ESPGDP,REFANTI,KOTU,NUTRANSMI,DOCUENANTI,KOFUDP,KOTNDP,SUTNDP,ESASDP,ESPGDP,CUOTAS" & vbCrLf &
                       "From MAEDPCE With ( Nolock ) " & vbCrLf &
                       "Where 1 = 0"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Tbl.Rows.Add(Fx_Nueva_Linea_De_Pago(_Tbl))


        For Each _Fila As DataRow In _Tbl_Maedpce.Rows

            Dim _Tidp = _Fila.Item("TIDP")

            If _Tidp = "ncv" Then

                Consulta_sql = "Select TIDO,NUDO,ENDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo
                Dim _Row_NewMaeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Tido_Pago = _Row_NewMaeedo.Item("TIDO")
                Dim _Nudo_Pago = _Row_NewMaeedo.Item("NUDO")
                Dim _Endo_Pago = _Row_NewMaeedo.Item("ENDO")

                Dim _Tido_Nudo = Split(_Fila.Item("REFANTI"), "-")
                Dim _Tido_NCV = _Tido_Nudo(0)
                Dim _Nudo_NCV = _Tido_Nudo(1)
                Dim _Endo_NCV = _Tido_Nudo(2)

                Dim _Idmaeedo_NCV As Integer = _Fila.Item("IDMAEEDO")

                _Tbl.Rows(0).Item("ESPGDP") = "C"

                Dim _Koen = Trim(_Endo_Pago)
                Dim _Rut = RutEmpresa

                _Tbl.Rows(0).Item("TIDP") = LCase(_Tido_Pago)
                _Tbl.Rows(0).Item("ENDP") = _Koen
                _Tbl.Rows(0).Item("EMDP") = _Rut

                _Tbl.Rows(0).Item("REFANTI") = _Tido_Pago & "-" & _Nudo_Pago & "-" & _Koen

                _Tbl.Rows(0).Item("VADP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAABDP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAASDP") = _Fila.Item("VADP")
                _Tbl.Rows(0).Item("VAABDP") = _Fila.Item("VADP")

                Dim _Idmaedpce As Integer = _Clas_Pagar.Fx_Crear_Pago_MAEDPCE(Me, _Idmaeedo_NCV, _Tbl, FechaDelServidor)

            End If

        Next

    End Sub

    Private Sub Btn_Limpiar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Limpiar.Click
        Sb_Nuevo_Documento()
    End Sub

    Private Sub Btn_Impresora_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Impresora.Click

        If Fx_Tiene_Permiso(Me, "Doc00058") Then

            Dim Archivo As String = _Ruta_Impresora & "\" & _Nombre_Archivo_XML_Impresora
            Dim exists = System.IO.File.Exists(Archivo)
            If exists Then
                Kill(Archivo)
            End If

            Dim Fm As New Frm_Seleccionar_Impresoras(_Impresora)
            Fm.ShowDialog(Me)

            If String.IsNullOrEmpty(Fm.Pro_Impresora_Seleccionada) Then
                Return
            Else

                _DtsConfig.Clear()

                Dim NewFila As DataRow
                NewFila = _DtsConfig.Tables("Conf_Impresora_Local").NewRow
                With NewFila
                    .Item("Modulo") = "Bkpost"
                    .Item("Impresora") = Fm.Pro_Impresora_Seleccionada
                    _DtsConfig.Tables("Conf_Impresora_Local").Rows.Add(NewFila)
                End With

                _DtsConfig.WriteXml(_Ruta_Impresora & "\" & _Nombre_Archivo_XML_Impresora)
                '

                MessageBoxEx.Show(Me, "Impresora seleccionada: " & Fm.Pro_Impresora_Seleccionada, "Impresora",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                _Impresora = Fm.Pro_Impresora_Seleccionada
                Me.Text = "PAGO A DOCUMENTOS - Impresora: " & _Impresora

            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Documentos_Hoy_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Documentos_Hoy.Click

        Dim _Filtro_Documentos = "And Edo.TIDO In ('BSV','BLV','FCV','FDV','NCV')"
        Dim _Filtro_Fechas = "And Edo.FEEMDO BETWEEN '" & Format(FechaDelServidor, "yyyyMMdd") &
                              "' AND '" & Format(FechaDelServidor, "yyyyMMdd") & "'"

        Dim _Left_Join_MAEEN_ENDOFI_SUENDOFI As String
        Dim _Campo_SUENDOFI As String

        If _Sql.Fx_Exite_Campo("MAEEDO", "SUENDOFI") Then
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN And Edo.SUENDOFI = Mae2.SUEN"
            _Campo_SUENDOFI = "Isnull(SUENDOFI,'') As SUENDOFI,"
        Else
            _Left_Join_MAEEN_ENDOFI_SUENDOFI = "Left Join MAEEN Mae2 On Edo.ENDOFI = Mae2.KOEN "
            _Campo_SUENDOFI = String.Empty
        End If

        Consulta_sql = My.Resources._24_Recursos.SQLQuery_Buscar_Docmuento
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#CantidadDoc#", 1000)
        Consulta_sql = Replace(Consulta_sql, "#TipoDocumento#", _Filtro_Documentos)
        Consulta_sql = Replace(Consulta_sql, "#NroDocumento#", "")
        Consulta_sql = Replace(Consulta_sql, "#Entidad#", "")
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", _Filtro_Fechas)
        Consulta_sql = Replace(Consulta_sql, "#Estado#", "")
        Consulta_sql = Replace(Consulta_sql, "#Funcionario#", "")
        Consulta_sql = Replace(Consulta_sql, "#SucursalDocumento#", "And Edo.SUDO = '" & ModSucursal & "'")
        Consulta_sql = Replace(Consulta_sql, "#Producto#", "")
        Consulta_sql = Replace(Consulta_sql, "#Orden#", "Order by IDMAEEDO Desc")

        Consulta_sql = Replace(Consulta_sql, "#Left_Join_MAEEN_ENDOFI_SUENDOFI#", _Left_Join_MAEEN_ENDOFI_SUENDOFI)
        Consulta_sql = Replace(Consulta_sql, "#Campo_SUENDOFI#", _Campo_SUENDOFI)

        Consulta_sql = Replace(Consulta_sql, "#Otro_Filtro#", "And Edo.ESPGDO = 'P'")
        Consulta_sql = Replace(Consulta_sql, "#ValesTransitorios#", "")

        Dim _Tbl_Paso As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_Tbl_Paso.Rows.Count) Then

            Consulta_sql = Replace(Consulta_sql, "", "Top #CantidadDoc#")

            Dim Fm As New Frm_BuscarDocumento_Mt
            Fm.BtnAceptar.Visible = False
            Fm.Pro_Sql_Query = Consulta_sql
            Fm.CmbCantFilas.Text = 1000
            Fm.Pro_Pago_a_Documento = True
            Fm.Pro_Abrir_Seleccionado = False
            Fm.CmbCantFilas.Enabled = False
            Fm.ShowDialog(Me)

            Dim _IdMaeedo_Doc = Fm.Pro_IdMaeedo_Doc

            Fm.Dispose()

            If Convert.ToBoolean(_IdMaeedo_Doc) Then

                Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
                Dim _RowDocumento As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Tido = _RowDocumento.Item("TIDO")
                Dim _Nudo = _RowDocumento.Item("NUDO")
                Dim _Nro_Documento As String = _Tido & _Nudo

                If Fx_Buscar_Documento(_Nro_Documento, True) Then

                    Beep()
                    Grilla_Maedpce.Focus()
                    Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(0).Cells("TIDP")
                    Sb_Ingresar_Linea_de_pago()

                End If

            End If

            Fm.Dispose()

        Else
            Beep()
            ToastNotification.Show(Me, "NO EXISTEN DATOS QUE MOSTRAR", My.Resources.cross, 3 * 1000,
                                   eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If


    End Sub

    Private Sub Frm_Pagos_Documentos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Dim _Tecla As Keys = e.KeyValue

        Select Case _Tecla
            Case Keys.F3
                If Bar1.Enabled Then Call Btn_Pagar_Click(Nothing, Nothing)
            Case Keys.F4
                Sb_Nuevo_Documento()
            Case Keys.F5
                Call Btn_Documentos_Hoy_Click(Nothing, Nothing)
            Case Keys.Escape
                If _Desde_Documento Then
                    Me.Close()
                End If
        End Select

    End Sub

    Private Sub Btn_Pago_Cta_Cte_Click(sender As System.Object, e As System.EventArgs)
        Sb_Grabar_Pago_A_Documento(True)
    End Sub

    Enum Enum_Revisa_Cto
        Cheque
        Sin_Documentar
    End Enum

    Function Fx_Revisar_Credito_Cliente(_RowEntidad As DataRow) As Boolean

        Dim _Koen = _RowEntidad.Item("KOEN")
        Dim _Suen = _RowEntidad.Item("SUEN")

        Dim _NOTRAEDEUD As Boolean = _RowEntidad.Item("NOTRAEDEUD")

        If _NOTRAEDEUD Then
            Return True
        End If

        Dim _TotalBruto As Double = _Tbl_Maeedo.Rows(0).Item("VABRDO")
        Dim _Pago_Actual As Double = _Tbl_Maeedo.Rows(0).Item("PAGO_ACTUAL")
        Dim _Saldo_Actual As Double = _Tbl_Maeedo.Rows(0).Item("SALDO_ACTUAL")

        Dim _EnCurso_Cheque As Double = _Tbl_Maeedo.Rows(0).Item("PAGO_CHEQUE")
        Dim _EnCurso_Letra As Double
        Dim _EnCurso_Pagare As Double
        Dim _Encurso_Total As Double = _TotalBruto

        Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad,
                                                           _Encurso_Total,
                                                           _EnCurso_Cheque,
                                                           _EnCurso_Letra,
                                                           _EnCurso_Pagare,
                                                           False)

        Dim _Credito_Cheque,
            _Credito_Cta_Cte As Double

        _Credito_Cheque = Fm_D.Pro_Crch_Disponible
        _Credito_Cta_Cte = Fm_D.Pro_Crsd_Disponible

        Dim _Permiso_Cheque As Boolean
        Dim _Permiso_Cta_Cte As Boolean

        If _Credito_Cheque < 0 Then

            _Permiso_Cheque = Fx_Tiene_Permiso(Me, "Ope00002", , False,,,,,,,,,,, _Ds_Matriz_Documentos)

            If Not _Permiso_Cheque Then

                If _Desde_Documento Then

                    Dim _Tbl_Detalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")
                    Dim _Cuenta_Tidopa_Guia = 0

                    For Each _Fila As DataRow In _Tbl_Detalle.Rows

                        Dim _Tidopa As String = _Fila.Item("Tidopa")

                        If _Tidopa.Contains("G") Then
                            _Cuenta_Tidopa_Guia += 1
                        End If

                    Next

                    If _Cuenta_Tidopa_Guia = _Tbl_Detalle.Rows.Count Then

                        MessageBoxEx.Show(Me, "Supera el límite de crédito en Cheque" & vbCrLf &
                                        "Sobregiro: " & FormatCurrency(_Credito_Cheque, 0) & vbCrLf & vbCrLf &
                                        "El documento viene completamente desde guías por lo tanto la factura se emitirá de todas formas",
                                        "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        Return True
                    End If

                End If

                If MessageBoxEx.Show(Me, "Supera el límite de crédito en Cheque" & vbCrLf &
                                    "Sobregiro: " & FormatCurrency(_Credito_Cheque * -1, 0) & vbCrLf & vbCrLf &
                                    "¿Desea solicitar permiso para realizar esta acción?",
                                    "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    _Permiso_Cheque = Fx_Tiene_Permiso(Me, "Ope00002",,,,,,,,,,,,, _Ds_Matriz_Documentos)

                End If

            End If

        Else
            _Permiso_Cheque = True
        End If

        If Not _Permiso_Cheque Then
            Return False
        End If

        If Not CBool(_Saldo_Actual) Then
            Return True
        End If

        If _Credito_Cta_Cte < 0 Then

            _Permiso_Cta_Cte = Fx_Tiene_Permiso(Me, "Ope00003", , False,,,,,,,,,,, _Ds_Matriz_Documentos)

            If Not _Permiso_Cta_Cte Then

                If _Desde_Documento Then

                    Dim _Tbl_Detalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")
                    Dim _Cuenta_Tidopa_Guia = 0

                    For Each _Fila As DataRow In _Tbl_Detalle.Rows

                        Dim _Tidopa As String = _Fila.Item("Tidopa")

                        If _Tidopa.Contains("G") Then
                            _Cuenta_Tidopa_Guia += 1
                        End If

                    Next

                    If _Cuenta_Tidopa_Guia = _Tbl_Detalle.Rows.Count Then

                        MessageBoxEx.Show(Me, "Supera el límite de crédito Sin Documentar" & vbCrLf &
                                        "Sobregiro: " & FormatCurrency(_Credito_Cta_Cte, 0) & vbCrLf & vbCrLf &
                                        "El documento viene completamente desde guías por lo tanto la factura se emitirá de todas formas",
                                        "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        Return True
                    End If

                End If

                _Credito_Cta_Cte = (_Credito_Cta_Cte * -1) - _Pago_Actual

                If MessageBoxEx.Show(Me, "Supera el límite de crédito Sin Documentar" & vbCrLf &
                                        "Sobregiro: " & FormatCurrency(_Credito_Cta_Cte, 0) & vbCrLf & vbCrLf &
                                        "¿Desea solicitar permiso para realizar esta acción?",
                                        "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                    _Permiso_Cta_Cte = Fx_Tiene_Permiso(Me, "Ope00003",,,,, _Koen, _Suen,,,,,,, _Ds_Matriz_Documentos)

                End If

            End If

        Else
            _Permiso_Cta_Cte = True
        End If

        Return _Permiso_Cta_Cte

    End Function

    Function Fx_Revisar_Credito_Cliente2(_RowEntidad As DataRow,
                                         ByRef _CodPermiso_Necesita As String,
                                         ByRef _Solicitar_Permiso As Boolean,
                                         ByRef _Tiene_Permiso As Boolean) As Boolean

        Dim _Koen = _RowEntidad.Item("KOEN")
        Dim _Suen = _RowEntidad.Item("SUEN")

        Dim _NOTRAEDEUD As Boolean = _RowEntidad.Item("NOTRAEDEUD")

        Dim _TotalBruto As Double = _Tbl_Maeedo.Rows(0).Item("VABRDO")
        Dim _Pago_Actual As Double = _Tbl_Maeedo.Rows(0).Item("PAGO_ACTUAL")
        Dim _Saldo_Actual As Double = _Tbl_Maeedo.Rows(0).Item("SALDO_ACTUAL")

        Dim _EnCurso_Cheque As Double = _Tbl_Maeedo.Rows(0).Item("PAGO_CHEQUE")
        Dim _EnCurso_Letra As Double
        Dim _EnCurso_Pagare As Double
        Dim _Encurso_Total As Double = _TotalBruto

        Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad,
                                                           _Encurso_Total,
                                                           _EnCurso_Cheque,
                                                           _EnCurso_Letra,
                                                           _EnCurso_Pagare)

        Dim _Credito_Cheque,
            _Credito_Cta_Cte As Double

        _Credito_Cheque = Fm_D.Pro_Crch_Disponible
        _Credito_Cta_Cte = Fm_D.Pro_Crsd_Disponible

        If _Credito_Cheque < 0 Then

            If Fx_Tiene_Permiso(Me, "Ope00002",, False) Then

                If MessageBoxEx.Show(Me, "Supera el límite de crédito en Cheque" & vbCrLf &
                            "Sobregiro: " & FormatCurrency(_Credito_Cheque * -1, 0) & vbCrLf & vbCrLf &
                            "¿Desea continuar con la venta?",
                            "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    _Tiene_Permiso = True
                    Return True

                End If

                _Solicitar_Permiso = False
                Return False

            End If

            If MessageBoxEx.Show(Me, "Supera el límite de crédito en Cheque" & vbCrLf &
                            "Sobregiro: " & FormatCurrency(_Credito_Cheque * -1, 0) & vbCrLf & vbCrLf &
                            "¿Desea solicitar permiso para realizar esta acción?",
                            "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                _Solicitar_Permiso = True
                _CodPermiso_Necesita = "Ope00002"

            End If

            Return False

        End If

        If Not CBool(_Saldo_Actual) Then
            Return True
        End If

        If _Credito_Cta_Cte < 0 Then

            _Credito_Cta_Cte = (_Credito_Cta_Cte * -1) - _Pago_Actual

            If Fx_Tiene_Permiso(Me, "Ope00003",, False) Then

                If MessageBoxEx.Show(Me, "Supera el límite de crédito Sin Documentar" & vbCrLf &
                            "Sobregiro: " & FormatCurrency(_Credito_Cta_Cte, 0) & vbCrLf & vbCrLf &
                            "¿Desea continuar con la venta?",
                            "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    _Tiene_Permiso = True
                    Return True

                End If

                _Solicitar_Permiso = False
                Return False

            End If


            If MessageBoxEx.Show(Me, "Supera el límite de crédito Sin Documentar" & vbCrLf &
                                        "Sobregiro: " & FormatCurrency(_Credito_Cta_Cte, 0) & vbCrLf & vbCrLf &
                                        "¿Desea solicitar permiso para realizar esta acción?",
                                        "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Yes Then

                _Solicitar_Permiso = True
                _CodPermiso_Necesita = "Ope00003"

            End If

            Return False

        End If

        If _NOTRAEDEUD Then

            If Fx_Tiene_Permiso(Me, "Ope00004",, False) Then

                If CBool(_Pago_Actual) Then

                    If MessageBoxEx.Show(Me, "El documento no esta siendo pagado en su totalidad" & vbCrLf & vbCrLf &
                                             "quedara un saldo de " & FormatCurrency(_Saldo_Actual, 0) & vbCrLf & vbCrLf &
                                             "¿Desea continuar?",
                                             "Documento con saldo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        _Tiene_Permiso = True
                        Return True

                    End If

                Else

                    If MessageBoxEx.Show(Me, "No hay pagos que realizar" & vbCrLf &
                     "¿Desea utilizar la Cta. Cte. del cliente?", "",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        _Tiene_Permiso = True
                        Return True
                    End If

                End If

                _Solicitar_Permiso = False
                Return False

            End If

            _Solicitar_Permiso = True
            _CodPermiso_Necesita = "Ope00004"
            Return False

        End If

        Return True

    End Function

    Private Sub BtnConfTipoEstacion_Click(sender As System.Object, e As System.EventArgs) Handles BtnConfTipoEstacion.Click

        Dim _Autorizado As Boolean

        Dim Fm_Pass As New Frm_Clave_Administrador
        Fm_Pass.ShowDialog(Me)
        _Autorizado = Fm_Pass.Pro_Autorizado
        Fm_Pass.Dispose()

        If _Autorizado Then
            Dim Fm As New Frm_RegistrarEquipo_Listado(True, Frm_RegistrarEquipo_Listado.Enum_Tipo_Estacion.Normal)
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If

    End Sub

    Private Sub Grilla_Maedpce_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Grilla_Maedpce.CellBeginEdit
        Bar1.Enabled = False
    End Sub

    Private Sub Grilla_Maedpce_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Maedpce.CellDoubleClick

        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim _Tidp As String = _Fila.Cells("TIDP").Value
        Dim _Vadp As Double = NuloPorNro(_Fila.Cells("VADP").Value, 0)

        Select Case _Cabeza

            Case "TIDP"

                If String.IsNullOrEmpty(_Tidp) Then

                    Dim _Tido = Grilla_Maeedo.Rows(0).Cells("TIDO").Value

                    If String.IsNullOrEmpty(_Tido) Then
                        Beep()
                        ToastNotification.Show(Me, "NO HAY DOCUMENTOS QUE PAGAR",
                                               My.Resources.cross,
                                              1 * 1000, eToastGlowColor.Red,
                                               eToastPosition.MiddleCenter)
                    Else

                        Sb_Ingresar_Linea_de_pago()

                    End If

                End If

            Case "FEVEDP"

                If _Tidp <> "EFV" Then

                    Grilla_Maedpce.Columns("FEVEDP").ReadOnly = False
                    SendKeys.Send("{F2}")
                    Grilla_Maedpce.BeginEdit(True)

                End If

        End Select

    End Sub


    Sub Sb_Ingresar_Linea_de_pago()

        Try

            Me.Enabled = False

            Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
            Dim _Tidp As String
            Dim _Tipo_Pago As Integer
            Dim _Tidp_Seleccionado As Boolean
            Dim _Row_Tidp As DataRow

            Dim _Filtro_Extra_Sql As String

            Dim _Tido = _Tbl_Maeedo.Rows(0).Item("TIDO")
            Dim _Nudonodefi = _Tbl_Maeedo.Rows(0).Item("NUDONODEFI")

            Dim _Nro_Documento As String = Traer_Numero_Documento(_Tido, , Modalidad) ' _Class_DTE.Pro_Nro_Documento

            Dim _Tidoelec As Integer = CInt(Fx_Es_Electronico(_Tido)) * -1

            If CBool(_Tidoelec) And CBool(_Nudonodefi) Then

                If Not Fx_Revisar_Expiracion_Folio_SII(Me, _Tido, _Nro_Documento) Then
                    Sb_Nuevo_Documento()
                    Return
                End If

            End If


            If _Tido <> "NCV" Then

                If _Ocultar_Cta_Cte Then
                    _Filtro_Extra_Sql = "And CodigoTabla In ('EFV','CHV','TJV','DEP','ATB','CRV')"
                Else
                    _Filtro_Extra_Sql = "And CodigoTabla In ('EFV','CHV','TJV','CTA','ncv','DEP','ATB','CRV')"
                End If

                _Tipo_Pago = 0

            Else

                _Filtro_Extra_Sql = "And CodigoTabla = 'EFC'"
                _Tipo_Pago = 1

            End If

            If Desde_Documento Then
                If _Ds_Matriz_Documentos.Tables("Encabezado_Doc").Rows(0).Item("Post_Venta") Then
                    _Filtro_Extra_Sql = "And CodigoTabla In ('TJV')"
                End If
            End If

            Dim Fm As New Frm_Pagos_Seleccion_Tipo_Pago(_Tipo_Pago)
            Fm.Pro_Filtro_Extra_Sql = _Filtro_Extra_Sql
            Fm.ShowDialog(Me)
            _Tidp_Seleccionado = Fm.Pro_Precio_Tidp_Seleccionado
            _Row_Tidp = Fm.Pro_Row_Tidp
            Fm.Dispose()

            If _Tidp_Seleccionado Then

                _Tidp = _Row_Tidp.Item("TIDP")

                If Desde_Documento Then
                    If Not Fx_Revisar_Pago_Obligatorio_X_Conceptos_X_Linea(_Tidp) Then
                        Return
                    End If
                End If

                If Not String.IsNullOrEmpty(_Tidp) Then

                    Select Case _Tidp
                        Case "EFV", "EFC"
                            Sb_Pago_Efectivo(_Tidp)
                        Case "CHV", "TJV", "DEP", "ATB", "CRV"
                            Sb_Pago_Cheque_o_Tarjeta(_Tidp)
                        Case "CTA"
                            sb_Pago_Con_Cta_Cte()
                        Case "ncv"
                            Sb_Pago_Nota_De_Credito()
                        Case Else
                            MessageBoxEx.Show(Me, "Condición de pago no habilitada", "Validación",
                                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End Select

                End If

            End If

        Catch ex As Exception
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub sb_Pago_Con_Cta_Cte()

        Dim Chk_Pagar_Saldo_Favor As New Command
        Chk_Pagar_Saldo_Favor.Checked = True
        Chk_Pagar_Saldo_Favor.Name = "Chk_Pagar_Saldo_Favor"
        Chk_Pagar_Saldo_Favor.Text = "Utilizar saldos a favor del cliente: Depositos, Transferecnias, etc."

        Dim Chk_Pagar_Linea_Credito As New Command
        Chk_Pagar_Linea_Credito.Checked = False
        Chk_Pagar_Linea_Credito.Name = "Chk_Pagar_Linea_Credito"
        Chk_Pagar_Linea_Credito.Text = "Utilizar línea de crédito del cliente (Grabar sin pagar)"


        Dim _Opciones() As Command = {Chk_Pagar_Saldo_Favor, Chk_Pagar_Linea_Credito}


        Dim _Info As New TaskDialogInfo("Pago con Cte. Cte.",
                          eTaskDialogIcon.Users,
                          "Pago con cuenta corriente del cliente",
                          "Confirme su opción",
                          eTaskDialogButton.Ok, eTaskDialogBackgroundColor.Red, _Opciones, Nothing, Nothing, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Ok Then

            If Chk_Pagar_Saldo_Favor.Checked Then

                Dim _Row_Maedpcde_CtaCte As DataRow

                Dim Fm_Pg As New Frm_Teneduria_CtaCteEnt(_Tbl_Maeedo.Rows(0).Item("ENDO"), "", _Tbl_Maedpce)

                If CBool(Fm_Pg.Tbl_Maedpcde_CtaCte.Rows.Count) Then

                    Fm_Pg.ShowDialog(Me)
                    _Row_Maedpcde_CtaCte = Fm_Pg.Row_Maedpcde_CtaCte

                Else

                    MessageBoxEx.Show(Me, "El cliente no tiene saldos a favor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If

                Fm_Pg.Dispose()

                If Not IsNothing(_Row_Maedpcde_CtaCte) Then

                    Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

                    _Fila.Cells("IDMAEDPCE").Value = _Row_Maedpcde_CtaCte.Item("IDMAEDPCE")
                    _Fila.Cells("EMDP").Value = _Row_Maedpcde_CtaCte.Item("EMDP")
                    _Fila.Cells("SUEMDP").Value = _Row_Maedpcde_CtaCte.Item("SUEMDP")
                    _Fila.Cells("CUDP").Value = _Row_Maedpcde_CtaCte.Item("CUDP")
                    _Fila.Cells("NUCUDP").Value = _Row_Maedpcde_CtaCte.Item("NUCUDP")
                    _Fila.Cells("CUOTAS").Value = _Row_Maedpcde_CtaCte.Item("CUOTAS")

                    Dim _Vadp As Double
                    Dim _Saldo As Double = _Row_Maedpcde_CtaCte.Item("SALDO")

                    If Lbl_Saldo.Tag >= _Saldo Then
                        _Vadp = _Saldo
                    Else
                        _Vadp = Lbl_Saldo.Tag
                    End If

                    _Fila.Cells("VADP").Value = _Vadp

                    _Fila.Cells("FEEMDP").Value = _Row_Maedpcde_CtaCte.Item("FEEMDP")
                    _Fila.Cells("FEVEDP").Value = _Row_Maedpcde_CtaCte.Item("FEVEDP")
                    _Fila.Cells("TIDP").Value = _Row_Maedpcde_CtaCte.Item("TIDP")

                    Sb_Sumar_Totales()

                End If

            End If

            If Chk_Pagar_Linea_Credito.Checked Then

                Sb_Grabar_Pago_A_Documento(True)

            End If

        End If

    End Sub

    Sub Sb_Pago_Efectivo(_Tidp As String)

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        _Fila.Cells("TIDP").Value = _Tidp
        _Fila.Cells("ESPGDP").Value = "C"
        Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")

    End Sub

    Sub Sb_Pago_Cheque_o_Tarjeta(_Tidp As String)

        Dim _Idmaeedo As Integer = _Tbl_Maeedo.Rows(0).Item("IDMAEEDO")

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Tipo_Pago As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago  ' Enum_Tipo_Pago_Ch_Tj
        Dim _Row_Tabendp As DataRow

        Dim _Mostrar_Cuentas_Del_Cliente_Proveedor As Boolean
        Dim _Mostrar_Cuentas_De_La_Empresa As Boolean

        Dim _Koen As String = _Tbl_Maeedo.Rows(0).Item("ENDO")

        If _Tidp = "CHV" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CH
            _Mostrar_Cuentas_Del_Cliente_Proveedor = True

        ElseIf _Tidp = "TJV" Then

            If Not IsNothing(_Row_CashDro) Then

                If _Post_Integrado_Transbank_Activo Then

                    Dim _Id As Integer

                    If Fx_Pago_Tarjeta_Post_Integrado(_Id) Then

                        _Id_CashDro = _Id

                        If Desde_Documento Then
                            Sb_Grabar_Pago_A_Documento_Desde_Documento()
                        Else
                            Sb_Grabar_Pago_A_Documento(False)

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set Tido = TIDO,Nudo = NUDO,Idmaedpce = IDMAEDPCE,Idmaeedo = Idmaeedo_H
                                            From MAEEDO 
                                            Inner Join MAEDPCD On ARCHIRST = 'MAEEDO' And IDRST = IDMAEEDO
                                            Where posid = '" & _NombreEquipo & "' And IDMAEEDO = " & _Idmaeedo & " And Idmaeedo_H = " & _Idmaeedo
                            _Sql.Ej_consulta_IDU(Consulta_sql)

                        End If

                    End If
                    Return

                End If

            End If

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.TJ

            Dim Fm_Emisor As New Frm_Seleccionar_Emisor_Doc_Pago(_Tipo_Pago)
            Fm_Emisor.ShowDialog(Me)
            _Row_Tabendp = Fm_Emisor.Pro_Row_Tabendp
            Fm_Emisor.Dispose()

            If IsNothing(_Row_Tabendp) Then
                Return
            End If

        ElseIf _Tidp = "DEP" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.DP
            _Mostrar_Cuentas_De_La_Empresa = True

        ElseIf _Tidp = "ATB" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.PT
            _Mostrar_Cuentas_De_La_Empresa = True

        ElseIf _Tidp = "CRV" Then

            _Tipo_Pago = Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago.CR
            _Mostrar_Cuentas_De_La_Empresa = False

        End If

        Dim Fm As New Frm_Pagos_Seleccionar_CH_TJ(_Tipo_Pago, _Row_Tabendp, Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_De_Pago.Cliente, Lbl_Saldo.Tag)
        Fm.Mostrar_Cuentas_De_La_Empresa = _Mostrar_Cuentas_De_La_Empresa
        Fm.Mostrar_Cuentas_Del_Cliente_Proveedor = _Mostrar_Cuentas_Del_Cliente_Proveedor
        Fm.Koen = _Koen
        Fm.ShowDialog(Me)

        If Fm.Pro_Aceptar Then

            _Fila.Cells("EMDP").Value = Fm.Pro_Emdp
            _Fila.Cells("SUEMDP").Value = Fm.Pro_Suemdp
            _Fila.Cells("CUDP").Value = Fm.Pro_Cudp
            _Fila.Cells("NUCUDP").Value = Fm.Pro_Nucudp
            _Fila.Cells("CUOTAS").Value = Fm.Pro_Cuotas
            _Fila.Cells("VADP").Value = Fm.Pro_Monto

            _Fila.Cells("TIDP").Value = Fm.Pro_Tipd
            _Fila.Cells("ESPGDP").Value = "P"

            If _Tidp = "CRV" Then
                _Fila.Cells("ESPGDP").Value = "C"
                _Fila.Cells("SUEMDP").Value = ""
            End If

            Sb_Sumar_Totales()

            If _Tidp = "CHV" Then
                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("FEVEDP")
            Else
                Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")
            End If

        End If

    End Sub

    Sub Sb_Pago_Nota_De_Credito()

        Try

            Dim _Endo As String = _Tbl_Maeedo.Rows(0).Item("ENDO")
            Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

            Dim Fm As New Frm_Pagos_Trae_NCV(_Endo, False)
            If Fm.Pro_Tiene_NCV_Pendientes Then
                Fm.ShowDialog(Me)

                If Not (Fm.Pro_RowMaeedo Is Nothing) Then

                    Dim _Idmaeedo_Nc As Integer = Fm.Pro_RowMaeedo.Item("IDMAEEDO")
                    Dim _Tido = Fm.Pro_RowMaeedo.Item("TIDO")
                    Dim _Nudo = Fm.Pro_RowMaeedo.Item("NUDO")

                    For Each _Row As DataRow In _Tbl_Maedpce.Rows

                        Dim _Idmaeedo_Mc = _Row.Item("IDMAEEDO")

                        If _Idmaeedo_Mc = _Idmaeedo_Nc Then
                            Throw New System.Exception("El documento ya está asociado a los pagos" & vbCrLf & vbCrLf &
                                                       "No puede asignar la nota de crédito Nro: " & _Nudo & " más de una vez")
                        End If

                    Next

                    _Fila.Cells("TIDP").Value = "ncv"
                    _Fila.Cells("ESPGDP").Value = "C"

                    Dim _Koen = Fm.Pro_RowMaeen.Item("KOEN")
                    Dim _Rut = RutEmpresa

                    _Fila.Cells("ENDP").Value = _Koen
                    _Fila.Cells("EMDP").Value = _Rut

                    _Fila.Cells("REFANTI").Value = _Tido & "-" & _Nudo & "-" & _Koen
                    _Fila.Cells("IDMAEEDO").Value = Fm.Pro_RowMaeedo.Item("IDMAEEDO")
                    _Fila.Cells("SALDO").Value = Fm.Pro_RowMaeedo.Item("SALDO")

                    Sb_Sumar_Totales()

                    Dim _Saldo As Double = Fm.Pro_RowMaeedo.Item("SALDO")
                    Dim _Vadp As Double

                    If _Saldo > _Monto_Saldo Then
                        _Vadp = _Monto_Saldo
                    Else
                        _Vadp = _Saldo
                    End If

                    _Fila.Cells("SALDO").Value = _Monto_Saldo
                    _Fila.Cells("VADP").Value = _Vadp

                    Sb_Sumar_Totales()

                End If
            Else
                Throw New System.Exception("No existen notas de crédito a favor")
            End If

            Fm.Dispose()

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Function Fx_Validad_Cupo_Excedido(ByRef _Tiene_Cupo_Excedido As Boolean) As Boolean

        Dim _Koen = _Tbl_Maeedo.Rows(0).Item("ENDO")
        Dim _Suen = _Tbl_Maeedo.Rows(0).Item("SUENDO")

        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        Dim _NOTRAEDEUD As Boolean = _RowEntidad.Item("NOTRAEDEUD")

        If _NOTRAEDEUD Then
            Return True
        End If

        ' Dim _Fun_Auto_Cupo_Exe = NuloPorNro(_TblEncabezado.Rows(0).Item("Fun_Auto_Cupo_Exe"), "")

        Dim _EnCurso_Total = Lbl_Saldo.Tag
        Dim _Crsd_Disponible As Double

        Dim Fm_D As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, _EnCurso_Total, 0, 0, 0, True)
        Fm_D.Pro_Fun_Auto_Cupo_Exe = FUNCIONARIO
        Dim _Autorizar_Venta_Con_Cupo_Exedido As Boolean = Fm_D.Pro_Autorizar_Venta_Con_Cupo_Exedido
        _Crsd_Disponible = Fm_D.Pro_Crsd_Disponible
        Fm_D.Dispose()

        If _Crsd_Disponible < 0 Then

            _Tiene_Cupo_Excedido = True

            If _Autorizar_Venta_Con_Cupo_Exedido Then

                Fx_Validad_Cupo_Excedido = _Autorizar_Venta_Con_Cupo_Exedido

            Else

                If Fx_Tiene_Permiso(Me, "Bkp00033", FUNCIONARIO,,,,,,,,,,,, _Ds_Matriz_Documentos) Then
                    Fx_Validad_Cupo_Excedido = True
                End If

            End If

        End If

    End Function

    Private Sub Grilla_Maedpce_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Grilla_Maedpce.DataError

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)
        Dim _Cabeza = Grilla_Maedpce.Columns(Grilla_Maedpce.CurrentCell.ColumnIndex).Name

        Select Case _Cabeza

            Case "FEEMDP", "FEVEDP"

                _Fila.Cells(_Cabeza).Value = Date.Now

        End Select

        MessageBoxEx.Show(Me, e.Exception.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        If Fx_Tiene_Permiso(Me, "Doc00032") Then

            If Not Desde_Documento Then

                Dim _Idmaeedo As String = _Tbl_Maeedo.Rows(0).Item("IDMAEEDO")
                Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")
                Dim _Nudo As String = _Tbl_Maeedo.Rows(0).Item("NUDO")

                If Not CBool(_Idmaeedo) Then
                    Beep()
                    ToastNotification.Show(Me, "FALTA DOCUMENTO A PAGAR", My.Resources.cross, 1 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                    Return
                End If

                Dim _Otra_Condicion = String.Empty

                Consulta_sql = "Select Distinct IDMAEEDO From MAEDDO Where IDMAEDDO In (Select IDRST From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ")"
                Dim _TblDetalle As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim _Filtros_Idmaeedo = Generar_Filtro_IN(_TblDetalle, "", "IDMAEEDO", False, False, "")

                If _Filtros_Idmaeedo <> "()" Then
                    _Otra_Condicion = "Or Idmaeedo In " & _Filtros_Idmaeedo
                End If

                Dim Fm As New Frm_Adjuntar_Archivos("Zw_Docu_Archivos", "Idmaeedo", _Idmaeedo)
                Fm.Otra_Condicion = _Otra_Condicion
                Fm.Text = "Archivos adjuntos documento: " & _Tido.Trim & " Nro: " & _Nudo
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Else

                Dim _TblDetalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

                Dim _Campo As String
                Dim _Id As String

                _Campo = "NombreEquipo"
                _Id = _NombreEquipo

                Dim _Filtros_Idmaeedo = Generar_Filtro_IN(_TblDetalle, "", "Idmaeedo_Dori", False, False, "")

                If _Filtros_Idmaeedo <> "()" Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Casi_DocArc (Nombre_Archivo,Archivo,Fecha,CodFuncionario,NombreEquipo,Idmaeedo) 
                                Select Nombre_Archivo,Archivo,Fecha,CodFuncionario,'" & _NombreEquipo & "',Idmaeedo 
                                From " & _Global_BaseBk & "Zw_Docu_Archivos Where Idmaeedo In " & _Filtros_Idmaeedo
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

                Dim Fm As New Frm_Adjuntar_Archivos("Zw_Casi_DocArc", _Campo, _Id) '"Id_DocEnc", _Id_DocEnc_Arc)
                Fm.Text = "Archivos adjuntos documento en construcción"
                Fm.ShowDialog(Me)
                Fm.Dispose()

                If _Filtros_Idmaeedo <> "()" Then

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Casi_DocArc Where Idmaeedo In " & _Filtros_Idmaeedo
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                End If

            End If

        End If

        Sb_Revisar_Si_Hay_Archivos_Adjuntos()

    End Sub

    Sub Sb_Revisar_Si_Hay_Archivos_Adjuntos()

        Dim _Archivos As Integer
        Dim _TblDetalle As DataTable

        If Not Desde_Documento Then

            Dim _Idmaeedo As String = _Tbl_Maeedo.Rows(0).Item("IDMAEEDO")
            Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")
            Dim _Nudo As String = _Tbl_Maeedo.Rows(0).Item("NUDO")

            If CBool(_Idmaeedo) Then

                Consulta_sql = "Select Distinct IDMAEEDO From MAEDDO Where IDMAEDDO In (Select IDRST From MAEDDO Where IDMAEEDO = " & _Idmaeedo & ") Or IDMAEEDO = " & _Idmaeedo
                _TblDetalle = _Sql.Fx_Get_Tablas(Consulta_sql)

                _Archivos = Fx_Revisar_Si_Hay_Archivos_Adjuntos(_NombreEquipo, _TblDetalle, "IDMAEEDO")

            End If

        Else

            _TblDetalle = _Ds_Matriz_Documentos.Tables("Detalle_Doc")
            _Archivos = Fx_Revisar_Si_Hay_Archivos_Adjuntos(_NombreEquipo, _TblDetalle, "Idmaeedo_Dori")

        End If

        'If _Archivos > 0 Then
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
        '    If _Archivos > 9 Then
        '        Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
        '        Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
        '    Else
        '        Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-" & _Archivos & ".png")
        '        Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-" & _Archivos & ".png")
        '    End If
        'Else
        '    Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
        '    Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item(4)
        '    Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item(15)
        'End If


        If _Archivos > 0 Then
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento (" & _Archivos & " archivo(s))"
            If _Archivos > 9 Then
                'Btn_Archivos_Adjuntos.Image = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
                'Btn_Archivos_Adjuntos.ImageAlt = Imagenes_32x32.Images.Item("attach-number-9-plus.png")
                Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9_plus
                Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9_plus___copia
            Else
                Select Case _Archivos
                    Case 0
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
                    Case 1
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_1
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_1___copia
                    Case 2
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_2
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_2___copia
                    Case 3
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_3
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_3___copia
                    Case 4
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_4
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_4___copia
                    Case 5
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_5
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_5___copia
                    Case 6
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_6
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_6___copia
                    Case 7
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_7
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_7___copia
                    Case 8
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_8
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_8___copia
                    Case 9
                        Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.attach_number_9
                        Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.attach_number_9___copia
                End Select
            End If
        Else
            Btn_Archivos_Adjuntos.Tooltip = "Archivos adjuntos al documento"
            Btn_Archivos_Adjuntos.Image = My.Resources.Recursos_Documento.document_attach
            Btn_Archivos_Adjuntos.ImageAlt = My.Resources.Recursos_Documento.document_attach___copia
        End If

    End Sub

    Function Fx_Revisar_Pago_Obligatorio_X_Conceptos_X_Documento() As Boolean

        Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")

        If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Docu_ObligPg") Then
            Return True
        End If

        Consulta_sql = "Select *,Cast(0 As Bit) As Paga_Tidp_Obl,Cast(0 As Bit) As Tiene_Concepto_Obl 
                        From " & _Global_BaseBk & "Zw_Docu_ObligPg Where Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "'"

        Dim _Tbl_Docu_ObligPg As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _TblDetalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")


        If CBool(_Tbl_Docu_ObligPg.Rows.Count) Then

            For Each _Fila_Obl As DataRow In _Tbl_Docu_ObligPg.Rows

                Dim _Tidp_Obl As String = _Fila_Obl.Item("Tidp")
                Dim _Concepto_Obl As String = _Fila_Obl.Item("Concepto")
                Dim _No_Obliga_Dscto As Boolean = _Fila_Obl.Item("No_Obliga_Dscto")

                For Each _Fila_P As DataRow In _Tbl_Maedpce.Rows

                    Dim _Tidp_P As String = _Fila_P.Item("TIDP")

                    If _Tidp_P = _Tidp_Obl Then

                        _Fila_Obl.Item("Paga_Tidp_Obl") = True

                        For Each _Fila_D As DataRow In _TblDetalle.Rows

                            Dim _Codigo As String = _Fila_D.Item("Codigo")
                            Dim _Prct As Boolean = _Fila_D.Item("Prct")
                            Dim _Tict As String = _Fila_D.Item("Tict")

                            If _Prct Then

                                If _Concepto_Obl = _Codigo Then
                                    _Fila_Obl.Item("Tiene_Concepto_Obl") = True
                                    If _No_Obliga_Dscto Then Exit For
                                End If

                            End If

                        Next

                    End If

                Next

            Next

            Dim _DescuentoValor As Double

            For Each _Fila_D As DataRow In _TblDetalle.Rows
                If _Fila_D.Item("Tict") = "" Or _Fila_D.Item("Tict") = "D" Then
                    _DescuentoValor += _Fila_D.Item("DescuentoValor")
                End If
            Next

            Dim _Msg As String
            Dim _Count_Obl = 0

            For Each _Fila_Obl As DataRow In _Tbl_Docu_ObligPg.Rows

                Dim _Paga_Tidp_Obl As Boolean = _Fila_Obl.Item("Paga_Tidp_Obl")
                Dim _Tiene_Concepto_Obl As Boolean = _Fila_Obl.Item("Tiene_Concepto_Obl")

                Dim _Obliga_Con_Dscto As Boolean = _Fila_Obl.Item("Obliga_Con_Dscto")
                Dim _Obliga_Sin_Dscto As Boolean = _Fila_Obl.Item("Obliga_Sin_Dscto")
                Dim _No_Obliga_Dscto As Boolean = _Fila_Obl.Item("No_Obliga_Dscto")

                If CBool(_DescuentoValor) Then

                    If _Paga_Tidp_Obl And Not _Tiene_Concepto_Obl Then
                        If Not _Obliga_Con_Dscto Then
                            _Count_Obl += 1
                            _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto faltante: " & _Fila_Obl.Item("Concepto").ToString.Trim & vbCrLf
                        End If
                    End If

                    If _Paga_Tidp_Obl And _Tiene_Concepto_Obl And _Obliga_Sin_Dscto Then
                        _Count_Obl += 1
                        _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto : " & _Fila_Obl.Item("Concepto").ToString.Trim & " Obliga a NO tener descuentos en documento" & vbCrLf
                    End If

                Else

                    If _Paga_Tidp_Obl And Not _Tiene_Concepto_Obl Then
                        If Not _Obliga_Sin_Dscto Then
                            _Count_Obl += 1
                            _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto faltante: " & _Fila_Obl.Item("Concepto").ToString.Trim & vbCrLf
                        End If
                    End If

                    If _Paga_Tidp_Obl And _Tiene_Concepto_Obl And _Obliga_Con_Dscto Then
                        _Count_Obl += 1
                        _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto : " & _Fila_Obl.Item("Concepto").ToString.Trim & " Obliga a tener descuentos en documento" & vbCrLf
                    End If

                End If

            Next

            If CBool(_Count_Obl) Then

                MessageBoxEx.Show(Me, "Falta(n) concepto(s) o validaciones en detalle según tipo de pago obligatorio para: " & _Tido & vbCrLf & vbCrLf & _Msg,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                If Not Fx_Tiene_Permiso(Me, "Doc00053") Then
                    Return False
                End If

            End If

        End If

        Return True

    End Function

    Function Fx_Revisar_Pago_Obligatorio_X_Conceptos_X_Linea(_Tidp_P As String) As Boolean

        Dim _Tido As String = _Tbl_Maeedo.Rows(0).Item("TIDO")

        If Not _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Docu_ObligPg") Then
            Return True
        End If

        Consulta_sql = "Select *,Cast(0 As Bit) As Paga_Tidp_Obl,Cast(0 As Bit) As Tiene_Concepto_Obl 
                        From " & _Global_BaseBk & "Zw_Docu_ObligPg Where Modalidad = '" & Modalidad & "' And Tido = '" & _Tido & "'"

        Dim _Tbl_Docu_ObligPg As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _TblDetalle As DataTable = _Ds_Matriz_Documentos.Tables("Detalle_Doc")

        If CBool(_Tbl_Docu_ObligPg.Rows.Count) Then

            For Each _Fila_Obl As DataRow In _Tbl_Docu_ObligPg.Rows

                Dim _Tidp_Obl As String = _Fila_Obl.Item("Tidp")
                Dim _Concepto_Obl As String = _Fila_Obl.Item("Concepto")

                If _Tidp_P = _Tidp_Obl Then

                    _Fila_Obl.Item("Paga_Tidp_Obl") = True

                    For Each _Fila_D As DataRow In _TblDetalle.Rows

                        Dim _Codigo As String = _Fila_D.Item("Codigo")
                        Dim _Prct As Boolean = _Fila_D.Item("Prct")
                        Dim _Tict As String = _Fila_D.Item("Tict")

                        If _Prct Then

                            If _Concepto_Obl = _Codigo Then
                                _Fila_Obl.Item("Tiene_Concepto_Obl") = True
                                Exit For
                            End If

                        End If

                    Next

                End If

            Next

            Dim _DescuentoValor As Double

            For Each _Fila_D As DataRow In _TblDetalle.Rows
                If _Fila_D.Item("Tict") = "" Or _Fila_D.Item("Tict") = "D" Then
                    _DescuentoValor += _Fila_D.Item("DescuentoValor")
                End If
            Next

            Dim _Msg As String
            Dim _Count_Obl = 0

            For Each _Fila_Obl As DataRow In _Tbl_Docu_ObligPg.Rows

                Dim _Paga_Tidp_Obl As Boolean = _Fila_Obl.Item("Paga_Tidp_Obl")
                Dim _Tiene_Concepto_Obl As Boolean = _Fila_Obl.Item("Tiene_Concepto_Obl")

                Dim _Cond_Obliga As String = _Fila_Obl.Item("Cond_Obliga")

                If _Paga_Tidp_Obl And Not _Tiene_Concepto_Obl Then

                    If _Cond_Obliga <> "SINDSCTO" And _Cond_Obliga <> "CONDSCTO" Then
                        _Count_Obl += 1
                        _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto faltante: " & _Fila_Obl.Item("Concepto").ToString.Trim & vbCrLf
                    Else
                        If CBool(_DescuentoValor) Then
                            If _Cond_Obliga = "CONDSCTO" Then
                                _Count_Obl += 1
                                _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto : " & _Fila_Obl.Item("Concepto").ToString.Trim & " Debe incluir este concepto, ya que el documento tiene descuentos" & vbCrLf
                            End If
                        Else
                            If _Cond_Obliga = "SINDSCTO" Then
                                _Count_Obl += 1
                                _Msg += "Tipo de pago: " & _Fila_Obl.Item("Tidp") & ", concepto : " & _Fila_Obl.Item("Concepto").ToString.Trim & " Debe incluir este concepto, ya que el documento No tiene descuentos" & vbCrLf
                            End If
                        End If
                    End If

                End If

            Next

            If CBool(_Count_Obl) Then

                If Fx_Tiene_Permiso(Me, "Doc00053",, False) Then
                    If MessageBoxEx.Show(Me, "Validación de CONCEPTOS en detalle según tipo de pago obligatorio para: " & _Tido & vbCrLf & vbCrLf & _Msg & vbCrLf &
                                         "¿Dese incluir de todas forma el tipo de pago?",
                                       "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                        Return False
                    End If
                Else
                    MessageBoxEx.Show(Me, "Validación de CONCEPTOS en detalle según tipo de pago obligatorio para: " & _Tido & vbCrLf & vbCrLf & _Msg,
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Not Fx_Tiene_Permiso(Me, "Doc00053") Then
                        Return False
                    End If
                End If

            End If

        End If

        Return True

    End Function

    Private Sub Btn_Config_Impresora_Diablito_Click(sender As Object, e As EventArgs) Handles Btn_Config_Impresora_Diablito.Click

        Dim Fm As New Frm_Imp_Diablito_X_Est(FUNCIONARIO, True)
        Fm.Tido = "BLV"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Function Fx_Pago_Tarjeta_Post_Integrado(ByRef _Id As Integer) As Boolean

        Dim _Row_Documento As DataRow = _Tbl_Maeedo.Rows(0)

        Dim _Idmaeedo As Integer = _Row_Documento.Item("IDMAEEDO")
        Dim _Monto As Double = _Row_Documento.Item("SALDO_ACTUAL")
        Dim _Log_Error As String

        Dim _Numero As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_CashDro_Operaciones", "COALESCE(MAX(Numero),'0000000000')")
        _Numero = Fx_Proximo_NroDocumento(_Numero, 10)

        Dim _posid As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim _posuser As String = FUNCIONARIO

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Operaciones (Numero,OperationId,FechaHora_Inicio,posid,posuser,Monto,Modalidad,Empresa,Sucursal,Bodega,Caja,Idmaeedo_H) Values " & vbCrLf &
                       "('" & _Numero & "','',GetDate(),'" & _posid & "','" & _posuser & "'," & De_Num_a_Tx_01(_Monto, False, 5) & ",'" & Modalidad & "','" & ModEmpresa & "','" & ModSucursal & "','" & ModBodega & "','" & ModCaja & "'," & _Idmaeedo & ")"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id)

        Dim _Pagado As Boolean
        Dim _Respuesta As String = String.Empty
        Dim _Status As String = String.Empty

        Dim _1R_Pagado As Boolean
        Dim _1R_Respuesta As String = String.Empty
        Dim _1R_Status As String = String.Empty

        Dim _Puerto_Serial_Bloqueado As Boolean

        Dim _Cerrado_por_usuario_o_tiempo As Boolean
        Dim _Commando_Transbank As String
        Dim _Id_Log_Transbank = 0

        Dim _Comando
        Dim _Codigo_de_comercio
        Dim _Terminal_ID
        Dim _Numero_Ticket_Boleta
        Dim _Cod_Autorizacion
        Dim _Nro_Tarjeta
        Dim _Nro_Operacion
        Dim _Tipo_de_Tarjeta
        Dim _Cuotas
        Dim _Marca As String
        Dim _Idmaeedo_Str As String = Strings.Right(_Idmaeedo, 6) ' _Idmaeedo.ToString.PadRight()

        Dim _Fila As DataGridViewRow = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index)

        Dim Fm_Espera As New Frm_Form_Esperar

        Dim _Fase_Prueba_Tarjeta = _Row_CashDro.Item("Fase_Prueba_Tarjeta")

        If _Fase_Prueba_Tarjeta Then

            Dim _Accion = MessageBoxEx.Show(Me, "Yes = Pagar" & vbCrLf &
                                 "No = Cancelar" & vbCrLf &
                                 "Cancelar = Cancelado por el usuario en Transbank o tiempo",
                                 "Pruebas Transbank", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If _Accion = DialogResult.Yes Then

                Dim _Random As New Random()
                Dim _Fecha = FechaDelServidor()

                _Cod_Autorizacion = _Random.Next(10000, 99999)
                _Nro_Tarjeta = Rellenar(_Random.Next(1000, 9999), 20, "*", False)
                _Nro_Operacion = _Random.Next(10000, 99999)

                Dim _Tj = _Random.Next(-10, 10)
                Dim _Tarjeta As String

                If _Tj <= 0 Then
                    _Tarjeta = "CR"
                ElseIf _Tj > 0 Then
                    _Tarjeta = "DB"
                End If

                _Pagado = True
                _Respuesta = "0260|00|555444333222|E1100455" &
                             "|" & _Idmaeedo &
                             "|" & _Cod_Autorizacion &
                             "|" & numero_(_Monto, 10) &
                             "|" & _Nro_Tarjeta &
                             "|" & _Nro_Operacion &
                             "|" & _Tarjeta &
                             "|||MC|" & Format(_Fecha, "ddMMyyyy") & "|" & FormatDateTime(_Fecha, DateFormat.ShortTime) & "|0"

                '_Respuesta = "0210|00|597042762248|C1903756|979292|008144|43970|0||7457|000261|DB|  -  -00|********306|DB|02112021|124755|0|0||@"

                _Status = "APROBADO"
                _1R_Pagado = True
                _1R_Respuesta = _Respuesta
                _1R_Status = _Status
                _Cerrado_por_usuario_o_tiempo = False
                _Commando_Transbank = "Prueba manual Bakapp"

            ElseIf _Accion = DialogResult.No Then

                Return False

            ElseIf _Accion = DialogResult.Cancel Then

                _Cerrado_por_usuario_o_tiempo = True

            End If

        Else

            Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, _Idmaeedo_Str, _Monto,
                                   Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Transaccion_Venta, True)
            Fm.Btn_Cancelar.Visible = False
            Fm.ShowDialog(Me)
            _Puerto_Serial_Bloqueado = Fm.Pro_Puerto_Bloqueado

            If _Puerto_Serial_Bloqueado Then

                ToastNotification.Show(Me, "PROBLEMAS DE COMUNICACION CON PUERTO SERIAL", My.Resources.cross,
                                           8 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                ' 3 Segundos de demora
                Thread.Sleep(3000)
                Return False

            End If

            _Pagado = Fm.Pro_Pagado
            _Respuesta = Fm.Pro_Respuesta_Decodificada
            _Status = Fm.Pro_Status
            _1R_Pagado = _Pagado
            _1R_Respuesta = _Respuesta
            _1R_Status = _Status
            _Cerrado_por_usuario_o_tiempo = Fm.Pro_Cierra_Usuario
            _Commando_Transbank = Fm.Pro_Comando_Transaccion
            Fm.Dispose()

        End If

        Dim _Log_Datos_Ultima_Venta_Transbank As String
        Dim _Datos_Respuesta = Split(_Respuesta, "|")
        Dim _Cod_Respuesta

        Try
            _Cod_Respuesta = _Datos_Respuesta(1)
        Catch ex As Exception
            _Cod_Respuesta = "??"
        End Try


        Dim _Respuesta_Status = UCase(Fx_Tabla1_Respuestas(_Cod_Respuesta))

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia,Comando_Transbank,Respuesta_Transbank,Respuesta_Inicial) Values" & Space(1) &
                       "(Getdate(),'" & _Respuesta & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ",'" & _Commando_Transbank & "','" & _1R_Respuesta & "',1)"
        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)


        If _Cod_Respuesta <> "??" And _Cod_Respuesta <> "00" Then

            Beep()
            ToastNotification.Show(Me, _Respuesta_Status,
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            _Pagado = False
            Return False

        End If

        Dim _Datos_Tarjeta = _Datos_Respuesta
        Dim _Datos_Desde_Ul_Venta_Por_Transbank As Boolean

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set " &
                       "Log_Datos_Ultima_Venta_Transbank = Log_Datos_Ultima_Venta_Transbank+' [" & _Datos_Tarjeta.Length & "]'" & vbCrLf &
                       "Where Id = " & _Id_Log_Transbank
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Dim _Buscar_Datos_Ult_Venta_Transbank As Boolean

        If _Datos_Tarjeta.Length >= 10 Then
            _Buscar_Datos_Ult_Venta_Transbank = False
        Else
            _Buscar_Datos_Ult_Venta_Transbank = True
        End If

        'If _Buscar_Datos_Ult_Venta_Transbank Then

        '    Sb_Datos_Ult_Venta_Por_Transbank(_Log_Datos_Ultima_Venta_Transbank, _Row_Documento.Item("TIDO"))
        '    _Datos_Tarjeta = Split(_Log_Datos_Ultima_Venta_Transbank, "|")
        '    _Datos_Desde_Ul_Venta_Por_Transbank = True

        'End If

        Dim _Largo As Integer = CType(_Datos_Tarjeta, System.Array).Length

        Try

            Dim _Codigo_Respuesta = _Datos_Tarjeta(1)
            Dim _Numero_Ticket_Boleta_IDMAEEDO = _Datos_Tarjeta(4)
            Dim _Ultimo_Status = Fx_Tabla1_Respuestas(_Codigo_Respuesta)

            If CInt(_Numero_Ticket_Boleta_IDMAEEDO) = CInt(_Idmaeedo_Str) Or _Numero_Ticket_Boleta_IDMAEEDO = "000000" Then

                _Respuesta = _Log_Datos_Ultima_Venta_Transbank
                _Status = UCase(_Ultimo_Status)

                If _Datos_Tarjeta(1) = "00" Then

                    _Pagado = True

                    Try

                        _Comando = _Datos_Tarjeta(0)
                        _Codigo_de_comercio = _Datos_Tarjeta(2)
                        _Terminal_ID = _Datos_Tarjeta(3)
                        _Numero_Ticket_Boleta = _Datos_Tarjeta(4)
                        _Cod_Autorizacion = _Datos_Tarjeta(5)
                        _Cuotas = _Datos_Tarjeta(7)
                        _Nro_Tarjeta = Rellenar(_Datos_Tarjeta(9), 20, "*", False)
                        _Nro_Operacion = _Datos_Tarjeta(10)
                        _Tipo_de_Tarjeta = _Datos_Tarjeta(11)

                        Try
                            _Marca = _Datos_Tarjeta(14)
                        Catch ex As Exception
                            _Marca = String.Empty
                        End Try

                        Dim _Voucher As String
                        Dim _Crear_Voucher_Bakapp = False

                        'If _Datos_Desde_Ul_Venta_Por_Transbank Then

                        '    Try
                        '        _Voucher = _Datos_Tarjeta(15)
                        '        _Voucher = Replace(_Voucher, "*** DUPLICADO ***", Space(17))
                        '    Catch ex As Exception
                        '        _Crear_Voucher_Bakapp = True
                        '    End Try

                        'Else

                        _Crear_Voucher_Bakapp = True

                        'End If

                        If _Crear_Voucher_Bakapp Then

                            Dim _Fecha = FormatDateTime(FechaDelServidor, DateFormat.ShortDate)
                            Dim _Hora = FormatDateTime(FechaDelServidor, DateFormat.ShortTime)

                            _Voucher = Fx_Crear_Voucher_Transbank(_Tipo_de_Tarjeta, _Fecha, _Hora, _Nro_Tarjeta, _Monto,
                                                                  _Numero_Ticket_Boleta, _Nro_Operacion, _Cod_Autorizacion, _Marca)

                        End If

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Log" & Space(1) &
                                       "(Fecha_Hora,Log_Datos_Ultima_Venta_Transbank,Monto_Venta_Referencia,Idmaeedo_Referencia) Values" & Space(1) &
                                       "(Getdate(),'" & _Log_Datos_Ultima_Venta_Transbank & "'," & De_Num_a_Tx_01(_Monto, False, 5) & "," & _Idmaeedo & ")"
                        _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Id_Log_Transbank)

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Transbank_Log Set 
                                        Voucher = '" & _Voucher & "',
                                        Comando_Transbank = '" & _Commando_Transbank & "', 
                                        Respuesta_Transbank = '" & _1R_Respuesta & "' Where Id = " & _Id_Log_Transbank
                        _Sql.Ej_consulta_IDU(Consulta_sql)

                        _Respuesta = "Nro. Tarjeta: " & _Nro_Tarjeta & "," &
                                     "Nro. Operación: " & _Nro_Operacion & "," &
                                     "Cód.Autorización: " & _Cod_Autorizacion & "," &
                                     "Terminal Id: " & _Terminal_ID & "," &
                                     "Cód.Comercio: " & _Codigo_de_comercio & " Id_Log_Transbank = " & _Id_Log_Transbank

                    Catch ex As Exception

                        _Log_Error = "Revisar [Zw_CashDro_Transbank_Log], Id_Log_Transbank = " & _Id_Log_Transbank
                        _Respuesta = String.Empty

                    End Try

                ElseIf _Codigo_Respuesta = "01" Then

                    Beep()
                    ToastNotification.Show(Me, "RECHAZADO",
                                   My.Resources.cross,
                                   3 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
                    _Pagado = False

                Else

                    _Pagado = False

                End If

            End If

        Catch ex As Exception
            _Log_Error = ex.Message & " Error al recibir la respuesta desde la Máquina Transbank"
            _Respuesta = String.Empty
            _Id_Log_Transbank = 0
        End Try

        If Not _Pagado And _1R_Pagado Then
            _Pagado = _1R_Pagado
            _Status = _1R_Status
            _Respuesta = _1R_Respuesta
        End If

        'If _Pagado Then
        '    Sb_Transformar_Vale_Transitorio_En_Documento(_Row_Documento, _Id, "TJV")
        'End If

        _Respuesta = Replace(_Respuesta, "'", "")

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_CashDro_Operaciones Set" & Space(1) &
                       "Pagado_Transbank = " & CInt(_Pagado) * -1 & "," &
                       "Log_Error = '" & _Log_Error & "'," &
                       "Status_Tarjeta = '" & _Status & "'," &
                       "Respuesta_Tarjeta = '" & _Respuesta & "'," &
                       "FechaHora_Fin = Getdate()," &
                       "Id_Log_Transbank = " & _Id_Log_Transbank & vbCrLf &
                       "Where Id = " & _Id
        _Sql.Ej_consulta_IDU(Consulta_sql)

        If Not _Pagado Then

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_CashDro_Operaciones" & vbCrLf &
                           "Where Idmaeedo = " & _Idmaeedo & " And Pagado_Nota_de_credito = 1"
            _Sql.Ej_consulta_IDU(Consulta_sql)

        End If

        Fm_Espera.Dispose()

        If _Pagado Then

            'Dim _Comando
            'Dim _Codigo_de_comercio
            'Dim _Terminal_ID
            'Dim _Numero_Ticket_Boleta
            'Dim _Cod_Autorizacion
            'Dim _Nro_Tarjeta
            'Dim _Nro_Operacion
            'Dim _Tipo_de_Tarjeta
            'Dim _Marca As String

            '_Fila.Cells("EMDP").Value = Fm.Pro_Emdp
            '_Fila.Cells("SUEMDP").Value = Fm.Pro_Suemdp
            '_Fila.Cells("CUDP").Value = Fm.Pro_Cudp
            '_Fila.Cells("NUCUDP").Value = Fm.Pro_Nucudp

            If IsNothing(_Cuotas) Then _Cuotas = 0
            If _Cuotas > 3 Then _Cuotas = 1


            _Fila.Cells("CUOTAS").Value = _Cuotas
            '_Fila.Cells("VADP").Value = Fm.Pro_Monto

            _Fila.Cells("TIDP").Value = "TJV"
            _Fila.Cells("ESPGDP").Value = "P"

            _Fila.Cells("VADP").Value = _Monto

            Dim _Emdp As String

            If _Tipo_de_Tarjeta = "CR" Then
                _Emdp = _Row_CashDro.Item("TJV_Emdp_Credito")
            ElseIf _Tipo_de_Tarjeta = "DB" Then
                _Emdp = _Row_CashDro.Item("TJV_Emdp_Debito")
            End If

            _Fila.Cells("EMDP").Value = _Emdp
            _Fila.Cells("CUDP").Value = _Cod_Autorizacion
            _Fila.Cells("NUCUDP").Value = _Nro_Operacion

            _Fila.Cells("REFANTI").Value = _Nro_Tarjeta

            Dim _Cod_Tarjeta = String.Empty

            _Fila.Cells("NUTRANSMI").Value = _Cod_Tarjeta
            _Fila.Cells("DOCUENANTI").Value = _Terminal_ID

            Sb_Sumar_Totales()

            Grilla_Maedpce.CurrentCell = Grilla_Maedpce.Rows(Grilla_Maedpce.CurrentRow.Index).Cells("VADP")

        End If

        Return _Pagado

    End Function

    Private Function Fx_Tabla1_Respuestas(_Respuesta As String) As String

        Select Case _Respuesta
            Case "00"
                Return "Aprobado"
            Case "01"
                Return "Rechazado"
            Case "02"
                Return "Autorizador no Responde"
            Case "03"
                Return "Fallo Conexión"
            Case "04"
                Return "Transacción ya fue Anulada"
            Case "05"
                Return "No existe transacción para Anular"
            Case "06"
                Return "Tarjeta no Soportada"
            Case "07"
                Return "Transacción Cancelada"
            Case "08"
                Return "No puede Anular Transacción Debito"
            Case "09"
                Return "Error Lectura de Tarjeta"
            Case "10"
                Return "Monto menor al mínimo permitido"
            Case "11"
                Return "No existe venta"
            Case "12"
                Return "Transacción no soportada"
            Case "13"
                Return "Debe ejecutar cierre"
            Case "14"
                Return "Error Encriptando PAN (BCYCLE)"
            Case "15"
                Return "Error Operando con Debito (BCYCLE)"
            Case "80"
                Return "Confirme el Monto"
            Case "81"
                Return "Ingrese Clave (PIN)"
            Case "82"
                Return "Procesando Transaccion"
            Case "90"
                Return "Inicialización Exitosa"
            Case "91"
                Return "Inicialización Fallida"
            Case "92"
                Return "Lector no conectado"

        End Select

    End Function

    Private Sub Btn_Mnu_Cerrar_Terminal_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Cerrar_Terminal.Click

        Dim _Validar As Boolean

        Dim Fmp As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0002", True, False)
        Fmp.Pro_Cerrar_Automaticamente = True
        Fmp.No_Necesita_Permiso_Supervisor = True
        Fmp.ShowDialog(Me)
        _Validar = Fmp.Pro_Permiso_Aceptado
        Fmp.Dispose()

        If Not _Validar Then
            Return
        End If

        Dim Fm As New Frm_Cashdro_Pago_Tarjeta(_Row_CashDro, "0", 0, Frm_Cashdro_Pago_Tarjeta.Enum_Accion.Cerrar_Terminal, False)
        Fm.ShowDialog(Me)

        Dim _Pagado As Boolean = Fm.Pro_Pagado
        Dim _Respuesta_Transbank As String = Fm.Pro_Respuesta_Decodificada
        Dim _Status As String = Fm.Pro_Status
        Dim _Error As Boolean = Fm.Pro_Erro_Conexion
        Dim _Puerto_Serial_Bloqueado As Boolean = Fm.Pro_Puerto_Bloqueado

        If _Puerto_Serial_Bloqueado Then
            MessageBoxEx.Show(Me, "Problema de conexión con puerto Serial (COM)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            _Error = True
        End If

        Fm.Dispose()

        If Not _Error Then

            Dim _Fecha_Cierre As Date = FechaDelServidor()

            If Not String.IsNullOrEmpty(_Respuesta_Transbank) Then

                Dim _IdCierre As Integer
                Dim _Respuesta_Arreglo = Split(_Respuesta_Transbank, "|")
                Dim _Voucher As String = _Respuesta_Arreglo(4)

                _Respuesta_Transbank = Replace(_Respuesta_Transbank, "'", "")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre (NombreEquipo,Fecha_Hora_Cierre,Respuesta_Transbank,Detalle) Values" & Space(1) &
                               "('" & _NombreEquipo & "',Getdate(),'" & _Respuesta_Transbank & "','" & _Voucher & "')"

                If _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _IdCierre) Then

                    Dim _Impresora_Predeterminada = _Row_CashDro.Item("Impresora_Predeterminada")

                    MessageBoxEx.Show(Me, "Cierre generado correctamente", "Cierre Transbank",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim _Este_Nombre_Equipo = _Global_Row_EstacionBk.Item("NombreEquipo")

                    If _NombreEquipo <> _Este_Nombre_Equipo Then
                        _Impresora_Predeterminada = String.Empty
                    End If

                    Consulta_sql = "Declare @Fecha as date = '" & Format(_Fecha_Cierre, "yyyyMMdd") & "'" & vbCrLf &
                                   "Select Top 1 *" & vbCrLf &
                                   "From " & _Global_BaseBk & "Zw_CashDro_Transbank_Cierre" & vbCrLf &
                                   "Where NombreEquipo = '" & _NombreEquipo & "' And Fecha_Hora_Cierre >= @Fecha And Fecha_Hora_Cierre < DATEADD(dd,1,@Fecha)" & vbCrLf &
                                   "Order By Fecha_Hora_Cierre Desc"
                    Dim _Row_Cierre As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                    If Not IsNothing(_Row_Cierre) Then

                        Dim _Cl_Voucher As New Clas_Imprimir_Voucher
                        _Cl_Voucher.Pro_Impresora = _Impresora_Predeterminada
                        _Cl_Voucher.Fx_Imprimir_Voucher_Cierre(Me, _IdCierre)
                        _Impresora_Predeterminada = _Cl_Voucher.Pro_Impresora

                        Dim _Imp_Cierre As New Clas_Imprimir_Cierre(_NombreEquipo, _Fecha_Cierre)

                        If _Imp_Cierre.Pro_Tbl_Detalle_Terminal.Rows.Count Then
                            _Imp_Cierre.Fx_Imprimir_Archivo(Me, "Detalle Terminal " & FormatDateTime(_Fecha_Cierre, DateFormat.ShortDate),
                                                            _Impresora_Predeterminada, Clas_Imprimir_Cierre._Enum_Tipo_Impresion.Detalle_Terminal)
                        End If

                    End If

                End If

            End If
        Else
            MessageBoxEx.Show(Me, "No es posible tener conexión con la maquina Transbank", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Mnu_Imprimir_Cierres_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Imprimir_Cierres.Click

        Dim _Validar As Boolean

        Dim Fmp As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0002", True, False)
        Fmp.No_Necesita_Permiso_Supervisor = True
        Fmp.Pro_Cerrar_Automaticamente = True
        Fmp.ShowDialog(Me)
        _Validar = Fmp.Pro_Permiso_Aceptado
        Fmp.Dispose()

        If Not _Validar Then
            Return
        End If

        Dim Fm As New Frm_Imprimir_Cierres_Transbank(_NombreEquipo, Frm_Imprimir_Cierres_Transbank._Enum_Tipo_Cierre.Transbank)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Mnu_Configurar_Terminal_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Configurar_Terminal.Click

        Dim _Validar As Boolean

        Dim Fmp As New Frm_ValidarPermiso(Frm_ValidarPermiso.Tipo_Accion.Validar_Permiso, "Cdro0002", True, False)
        Fmp.No_Necesita_Permiso_Supervisor = True
        Fmp.Pro_Cerrar_Automaticamente = True
        Fmp.ShowDialog(Me)
        _Validar = Fmp.Pro_Permiso_Aceptado
        Fmp.Dispose()

        If _Validar Then

            Dim Fm As New Frm_Equipos_CashDro_Equipo(_NombreEquipo)
            Fm.ShowDialog(Me)
            If Fm.Pro_Grabar Then
                Me.Close()
            End If

            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Transbank_Click(sender As Object, e As EventArgs) Handles Btn_Transbank.Click
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Btn_PDF_BLV_Click(sender As Object, e As EventArgs) Handles Btn_PDF_BLV.Click
        Sb_Configuracion_Salida_PDF(Me, "BLV")
    End Sub

    Private Sub Btn_PDF_FCV_Click(sender As Object, e As EventArgs) Handles Btn_PDF_FCV.Click
        Sb_Configuracion_Salida_PDF(Me, "FCV")
    End Sub
End Class
