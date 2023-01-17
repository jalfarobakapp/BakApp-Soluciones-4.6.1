Imports DevComponents.DotNetBar

Public Class Frm_InfoEnt_Deudas_Doc_Comerciales

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _RowEntidad As DataRow
    Dim _DsInfCredito As DataSet 'New DS_InfCredito

    Dim _TblSinDocumentar As DataTable

    Dim _TblCheques,
        _TblPagos,
        _TblLetras,
        _TblPagares,
        _TblTotales,
        _TblDeuda,
        _TblUtilizado_NVV As DataTable

    Dim _Crsd_Utilizado As Double
    Dim _Crch_Utilizado As Double
    Dim _CrPgo_Utilizado As Double
    Dim _Crlt_Utilizado As Double
    Dim _Crpa_Utilizado As Double
    Dim _Crto_Utilizado As Double
    Dim _CrNvv_Utilizado As Double

    Dim _Crsd_Disponible,
        _Crch_Disponible,
        _CrPgo_Disponible,
        _Crlt_Disponible,
        _Crpa_Disponible,
        _Crto_Disponible As Double

    Dim _Dias_Vencimiento As Integer '
    Dim _FechaEmision As Date '
    Dim _Fecha_1er_Vencimiento As Date '
    Dim _FechaUltVencimiento As Date '
    Dim _Cuotas As Integer '
    Dim _Dias_1er_Vencimiento As Integer '

    Dim _Grabar_Vencimientos As Boolean '

    Dim _Credito_Utilizado As Double '

    Dim _Tiene_Deudas As Boolean


    Dim _Fun_Auto_Deuda_Ven As String
    Dim _Fun_Auto_Cupo_Exe As String

    Dim _Autorizar_Venta_Con_Deuda_Vencida As Boolean
    Dim _Autorizar_Venta_Con_Cupo_Exedido As Boolean

    Dim _CodFuncionario_permiso As String

    Dim _Rojo, _Azul, _Verde As Color

    Public Property RevFincred As Boolean
    Enum Enum_Accion
        Visualizar
        Permiso_Deuda_Vencida
        Permiso_Cupo_Exedido
    End Enum

    Dim _Accion As Enum_Accion

    Public Property Pro_Dias_Vencimiento() As Integer
        Get
            Return _Dias_Vencimiento
        End Get
        Set(value As Integer)
            _Dias_Vencimiento = value
        End Set
    End Property
    Public Property Pro_FechaEmision() As Date
        Get
            Return _FechaEmision
        End Get
        Set(value As Date)
            _FechaEmision = value
        End Set
    End Property
    Public Property Pro_Fecha_1er_Vencimiento() As Date
        Get
            Return _Fecha_1er_Vencimiento
        End Get
        Set(value As Date)
            _Fecha_1er_Vencimiento = value
        End Set
    End Property
    Public Property Pro_FechaUltVencimiento() As Date
        Get
            Return _FechaUltVencimiento
        End Get
        Set(value As Date)
            _FechaUltVencimiento = value
        End Set
    End Property
    Public Property Pro_Cuotas() As Integer
        Get
            Return _Cuotas
        End Get
        Set(value As Integer)
            _Cuotas = value
        End Set
    End Property
    Public Property Pro_Dias_1er_Vencimiento() As Integer
        Get
            Return _Dias_1er_Vencimiento
        End Get
        Set(value As Integer)
            _Dias_1er_Vencimiento = value
        End Set
    End Property
    Public Property Pro_Grabar_Vencimientos() As Boolean
        Get
            Return _Grabar_Vencimientos
        End Get
        Set(value As Boolean)
            _Grabar_Vencimientos = value
        End Set
    End Property
    Public Property Pro_Credito_Utilizado() As Double
        Get
            Return _Credito_Utilizado
        End Get
        Set(value As Double)
            _Credito_Utilizado = value
        End Set
    End Property
    Public Property Pro_Tiene_Deudas() As Boolean
        Get
            Return _Tiene_Deudas
        End Get
        Set(value As Boolean)
            _Tiene_Deudas = value
        End Set
    End Property
    Public Property Pro_CodFuncionario_permiso() As String
        Get
            Return _CodFuncionario_permiso
        End Get
        Set(value As String)
            _CodFuncionario_permiso = value
        End Set
    End Property
    Public Property Pro_Crsd_Disponible() As Double
        Get
            Return _Crsd_Disponible
        End Get
        Set(value As Double)
            _Crsd_Disponible = value
        End Set
    End Property
    Public Property Pro_Crch_Disponible() As Double
        Get
            Return _Crch_Disponible
        End Get
        Set(value As Double)
            _Crch_Disponible = value
        End Set
    End Property
    Public Property Pro_Crlt_Disponible() As Double
        Get
            Return _Crlt_Disponible
        End Get
        Set(value As Double)
            _Crlt_Disponible = value
        End Set
    End Property
    Public Property Pro_Crpa_Disponible() As Double
        Get
            Return _Crpa_Disponible
        End Get
        Set(value As Double)
            _Crpa_Disponible = value
        End Set
    End Property
    Public Property Pro_Crto_Disponible() As Double
        Get
            Return _Crto_Disponible
        End Get
        Set(value As Double)
            _Crto_Disponible = value
        End Set
    End Property
    Public Property Pro_Fun_Auto_Cupo_Exe() As String
        Get
            Return _Fun_Auto_Cupo_Exe
        End Get
        Set(value As String)
            _Fun_Auto_Cupo_Exe = value
        End Set
    End Property
    Public Property Pro_Fun_Auto_Deuda_Ven() As String
        Get
            Return _Fun_Auto_Deuda_Ven
        End Get
        Set(value As String)
            _Fun_Auto_Deuda_Ven = value
        End Set
    End Property
    Public Property Pro_Autorizar_Venta_Con_Deuda_Vencida() As Boolean
        Get
            If _Tiene_Deudas Then
                _Autorizar_Venta_Con_Deuda_Vencida = Fx_Tiene_Permiso(Me, "Bkp00019", _Fun_Auto_Deuda_Ven, False)
            Else
                _Autorizar_Venta_Con_Deuda_Vencida = True
            End If

            Return _Autorizar_Venta_Con_Deuda_Vencida
        End Get
        Set(value As Boolean)
            _Autorizar_Venta_Con_Deuda_Vencida = value
        End Set
    End Property
    Public Property Pro_Autorizar_Venta_Con_Cupo_Exedido() As Boolean
        Get
            If _Crto_Disponible < 0 Then ' _Crsd_Disponible < 0 Then
                _Autorizar_Venta_Con_Cupo_Exedido = Fx_Tiene_Permiso(Me, "Bkp00033", _Fun_Auto_Cupo_Exe, False)
            Else
                _Autorizar_Venta_Con_Cupo_Exedido = True
            End If

            Return _Autorizar_Venta_Con_Cupo_Exedido
        End Get
        Set(value As Boolean)
            _Autorizar_Venta_Con_Cupo_Exedido = value
        End Set
    End Property

    Public Sub New(RowEntidad As DataRow,
                   EnCurso_Total As Double,
                   EnCurso_Cheque As Double,
                   EnCurso_Letra As Double,
                   EnCurso_Pagare As Double,
                   Sumar_NVV As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Deuda, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Credito, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        If Sumar_NVV Then
            Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked = _Global_Row_Configuracion_General.Item("Utilizar_NVV_En_Credito_X_Cliente")
        End If

        AddHandler Grilla_Credito.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Deuda.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        _RowEntidad = RowEntidad

        _DsInfCredito = New DataSet
        Dim _Tbl As New DataTable("Tbl_SituCredito")

        'creamos las mismas columnas que hay en el dataset

        _Tbl.Columns.Add("TipoCredito", System.Type.[GetType]("System.String"))
        _Tbl.Columns.Add("Autorizado", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Utilizado", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Utilizado_NVV", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("EnCurso", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Disponible", System.Type.[GetType]("System.Double"))
        ',,,,,,

        _DsInfCredito.Tables.Add(_Tbl)

        Sb_Revisar_Situacion_Credito_Entidad(EnCurso_Total, EnCurso_Cheque, EnCurso_Letra, EnCurso_Pagare)
        Sb_Revisar_Deuda_Doc_Entidad()

        SuperTabControl1.SelectedTabIndex = 0

        If String.IsNullOrEmpty(_Fun_Auto_Deuda_Ven) Then _Fun_Auto_Deuda_Ven = FUNCIONARIO
        If String.IsNullOrEmpty(_Fun_Auto_Cupo_Exe) Then _Fun_Auto_Cupo_Exe = FUNCIONARIO

        _Autorizar_Venta_Con_Deuda_Vencida = Fx_Tiene_Permiso(Me, "Bkp00019", _Fun_Auto_Deuda_Ven, False)
        _Autorizar_Venta_Con_Cupo_Exedido = Fx_Tiene_Permiso(Me, "Bkp00033", _Fun_Auto_Cupo_Exe, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_CambCodPago.ForeColor = Color.White
            Txt_Cuotas.FocusHighlightEnabled = False
            Txt_Dias_1er_Vencimiento.FocusHighlightEnabled = False
            Dtp_FechaUltVencimiento.FocusHighlightEnabled = False
            Dtp_Fecha_1er_Vencimiento.FocusHighlightEnabled = False
        End If

    End Sub

    Public Sub New(RowEntidad As DataRow,
                   EnCurso_Total As Double,
                   EnCurso_Cheque As Double,
                   EnCurso_Letra As Double,
                   EnCurso_Pagare As Double)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla_Deuda, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Credito, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        AddHandler Grilla_Credito.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Deuda.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        _RowEntidad = RowEntidad

        _DsInfCredito = New DataSet
        Dim _Tbl As New DataTable("Tbl_SituCredito")

        'creamos las mismas columnas que hay en el dataset

        _Tbl.Columns.Add("TipoCredito", System.Type.[GetType]("System.String"))
        _Tbl.Columns.Add("Autorizado", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Utilizado", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Utilizado_NVV", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("EnCurso", System.Type.[GetType]("System.Double"))
        _Tbl.Columns.Add("Disponible", System.Type.[GetType]("System.Double"))
        ',,,,,,

        _DsInfCredito.Tables.Add(_Tbl)

        Sb_Revisar_Situacion_Credito_Entidad(EnCurso_Total, EnCurso_Cheque, EnCurso_Letra, EnCurso_Pagare)
        Sb_Color_Botones_Barra(Bar2)

        SuperTabControl1.SelectedTabIndex = 0

        If String.IsNullOrEmpty(_Fun_Auto_Deuda_Ven) Then _Fun_Auto_Deuda_Ven = FUNCIONARIO
        If String.IsNullOrEmpty(_Fun_Auto_Cupo_Exe) Then _Fun_Auto_Cupo_Exe = FUNCIONARIO

        _Autorizar_Venta_Con_Deuda_Vencida = Fx_Tiene_Permiso(Me, "Bkp00019", _Fun_Auto_Deuda_Ven, False)
        _Autorizar_Venta_Con_Cupo_Exedido = Fx_Tiene_Permiso(Me, "Bkp00033", _Fun_Auto_Cupo_Exe, False)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_CambCodPago.ForeColor = Color.White
            Txt_Cuotas.FocusHighlightEnabled = False
            Txt_Dias_1er_Vencimiento.FocusHighlightEnabled = False
            Dtp_FechaUltVencimiento.FocusHighlightEnabled = False
            Dtp_Fecha_1er_Vencimiento.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_InfoEnt_Deudas_Doc_Comerciales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If Global_Thema = Enum_Themas.Oscuro Then

            _Rojo = Color.FromArgb(220, 78, 66)
            _Azul = Color.FromArgb(37, 136, 213)
            _Verde = Color.FromArgb(30, 215, 96)

        Else

            _Rojo = Color.Red
            _Azul = Color.Blue
            _Verde = Color.Green

        End If

        _Autorizar_Venta_Con_Deuda_Vencida = Fx_Tiene_Permiso(Me, "Bkp00019", _Fun_Auto_Deuda_Ven, False)
        _Autorizar_Venta_Con_Cupo_Exedido = Fx_Tiene_Permiso(Me, "Bkp00033", _Fun_Auto_Cupo_Exe, False)

        Me.Text = "Entidad: " & Trim(_RowEntidad.Item("NOKOEN"))
        Sb_Actualiar_Grilla_Deuda()
        Sb_Actualiar_Grilla_Credito()

        Txt_Cuotas.Text = _Cuotas
        Txt_Dias_1er_Vencimiento.Text = _Dias_1er_Vencimiento

        _Fecha_1er_Vencimiento = DateAdd(DateInterval.Day, _Dias_1er_Vencimiento, Now)
        Dtp_Fecha_1er_Vencimiento.Value = _Fecha_1er_Vencimiento

        Sb_Procesar_Cond_Pago(True)


        AddHandler Txt_Cuotas.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Cuotas.Validated, AddressOf Txt_Validated

        AddHandler Txt_Dias_1er_Vencimiento.KeyPress, AddressOf Txt_KeyPress
        AddHandler Txt_Dias_1er_Vencimiento.Validated, AddressOf Txt_Validated

        AddHandler Dtp_Fecha_1er_Vencimiento.Validated, AddressOf Dtp_Fecha_1er_Vencimiento_Validated
        AddHandler Grilla_Credito.CellDoubleClick, AddressOf Sb_Grilla_Credito_CellDoubleClick

        Sb_Formato_Generico_Grilla(Grilla_Deuda, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Credito, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)


        Warning_Box_Deuda.Visible = True
        Warning_Box_Cupo_Exedido.Visible = True

        If _Tiene_Deudas Then
            If _Autorizar_Venta_Con_Deuda_Vencida Then
                Warning_Box_Deuda.Image = Imagenes_16x16.Images.Item("warning.png")
                Warning_Box_Deuda.Text = "<b>  Cliente con morosidad</b><i> Venta autorizada por " & _Fun_Auto_Deuda_Ven & " </i>"
            Else
                Warning_Box_Deuda.Image = Imagenes_16x16.Images.Item("delete_button_error.png")
                Warning_Box_Deuda.Text = "<b>  Cliente con morosidad</b> Debe solicitar permiso para realizar la venta <i></i>"
            End If
        Else

            Warning_Box_Deuda.Text = "<b>  Cliente sin morosidad</b><i></i>"
            Warning_Box_Deuda.Image = Imagenes_16x16.Images.Item("ok.png")

        End If

        Dim _Dimoper As Integer = _RowEntidad.Item("DIMOPER")

        Warning_Box_Deuda.Text = Warning_Box_Deuda.Text & " (Días de morosidad permitida " & _Dimoper & ")"

        If _Crto_Disponible < 0 Then
            If _Autorizar_Venta_Con_Cupo_Exedido Then
                Warning_Box_Cupo_Exedido.Image = Imagenes_16x16.Images.Item("warning.png")
                Warning_Box_Cupo_Exedido.Text = "<b>  Cliente con cupo excedido</b><i> Venta autorizada por " & _Fun_Auto_Cupo_Exe & " </i>"
            Else

                Dim _Icono As Image = Imagenes_16x16.Images.Item("delete_button_error.png")
                Dim _Existe_Tbl_Entidades_Bakapp As Boolean = _Sql.Fx_Existe_Tabla(_Global_BaseBk & "Zw_Entidades")
                Dim _Leyenda As String

                If _Existe_Tbl_Entidades_Bakapp Then

                    Dim _Libera_NVV As Boolean
                    Dim _Koen As String = _RowEntidad.Item("KOEN")
                    Dim _Suen As String = _RowEntidad.Item("SUEN")

                    Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Entidades" & vbCrLf &
                                       "Where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                    Dim _Row_Entidades As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    If IsNothing(_Row_Entidades) Then

                        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades (CodEntidad,CodSucEntidad,Libera_NVV) Values ('" & _Koen & "','" & _Suen & "',0)" & vbCrLf &
                                           "Select * From " & _Global_BaseBk & "Zw_Entidades where CodEntidad = '" & _Koen & "' And CodSucEntidad = '" & _Suen & "'"
                        _Row_Entidades = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    End If

                    _Libera_NVV = _Row_Entidades.Item("Libera_NVV")
                    If _Libera_NVV Then
                        Dim _SumCrto As Double = _RowEntidad.Item("CRSD") + _RowEntidad.Item("CRCH") + _RowEntidad.Item("CRLT") + _RowEntidad.Item("CRPA") + _RowEntidad.Item("CRTO")
                        If CBool(_SumCrto) Then
                            _Libera_NVV = False
                        End If
                    End If

                    If _Libera_NVV Then
                        _Icono = Imagenes_16x16.Images.Item("warning.png")
                        _Leyenda = "(Autorizado solo para generar NVV)"
                    End If

                End If

                Warning_Box_Cupo_Exedido.Image = _Icono
                Warning_Box_Cupo_Exedido.Text = "<b>  Cliente con cupo excedido</b> Debe solicitar permiso para realizar la venta " & _Leyenda & "<i></i>"

            End If
        Else
            Warning_Box_Cupo_Exedido.Image = Imagenes_16x16.Images.Item("ok.png")
            Warning_Box_Cupo_Exedido.Text = "<b>  Cliente con cupo</b><i></i>"
        End If

        'If _RowEntidad.Item("CRTO") = 0 And _RowEntidad.Item("DIPRVE") = 0 Then

        '    If Btn_CambCodPago.Visible Then
        '        Btn_CambCodPago.Visible = Not _Global_Row_Configuracion_Estacion.Item("Fincred_Usar")
        '        Btn_FincredPays.Visible = _Global_Row_Configuracion_Estacion.Item("Fincred_Usar")
        '    End If

        '    If RevFincred Then
        '        Warning_Box_Cupo_Exedido.Image = Imagenes_16x16.Images.Item("warning.png")
        '        Warning_Box_Cupo_Exedido.Text = "<b>  Cliente con cupo excedido</b><i> Venta sera revisada por FINCRED PAYS </i>"
        '    End If

        'End If

    End Sub


    Sub Sb_Actualiar_Grilla_Deuda()

        With Grilla_Deuda

            .DataSource = _TblDeuda

            OcultarEncabezadoGrilla(Grilla_Deuda, True)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 1

            .Columns("FEVE").HeaderText = "Vencimiento"
            .Columns("FEVE").Width = 90
            .Columns("FEVE").Visible = True
            .Columns("FEVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FEVE").DisplayIndex = 2

            .Columns("DIAS_ATRASO").HeaderText = "Días atraso"
            .Columns("DIAS_ATRASO").Width = 80
            .Columns("DIAS_ATRASO").Visible = True
            .Columns("DIAS_ATRASO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DIAS_ATRASO").DisplayIndex = 3

            .Columns("VAVE").HeaderText = "Valor cuota"
            .Columns("VAVE").Width = 80
            .Columns("VAVE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAVE").Visible = True
            .Columns("VAVE").DisplayIndex = 4

            .Columns("VAABVE").HeaderText = "Valor Abonado"
            .Columns("VAABVE").Width = 80
            .Columns("VAABVE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAABVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VAABVE").Visible = True
            .Columns("VAABVE").DisplayIndex = 5

            .Columns("SALDO").HeaderText = "Valor Saldo"
            .Columns("SALDO").Width = 80
            .Columns("SALDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO").Visible = True
            .Columns("SALDO").DisplayIndex = 6

        End With

        For Each _Fila As DataGridViewRow In Grilla_Deuda.Rows

            Dim _Nudonodefi As Boolean = _Fila.Cells("NUDONODEFI").Value '.Style.ForeColor = Color.DarkGreen
            Dim _Dias_Atraso As Integer = _Fila.Cells("DIAS_ATRASO").Value
            Dim _Dimoper As Integer = _RowEntidad.Item("DIMOPER")

            If _Nudonodefi Then
                _Fila.DefaultCellStyle.BackColor = Color.Yellow
            End If

            If _Dimoper > _Dias_Atraso Then
                _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _Verde
                _Fila.Visible = False
            Else
                _Fila.Cells("DIAS_ATRASO").Style.ForeColor = _Rojo
            End If

        Next

    End Sub

    Sub Sb_Actualiar_Grilla_Credito()

        Dim _Menos = 0

        If Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked Then
            _Menos = -20
        End If

        With Grilla_Credito

            OcultarEncabezadoGrilla(Grilla_Credito, True)

            .Columns("TipoCredito").HeaderText = "Tipo crédito"
            .Columns("TipoCredito").Width = 130
            .Columns("TipoCredito").Visible = True

            .Columns("Autorizado").HeaderText = "Autorizado"
            .Columns("Autorizado").Width = 100 + _Menos
            .Columns("Autorizado").Visible = True
            .Columns("Autorizado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Autorizado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Utilizado").HeaderText = "Utilizado"
            .Columns("Utilizado").Width = 100 + _Menos
            .Columns("Utilizado").Visible = True
            .Columns("Utilizado").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Utilizado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Utilizado_NVV").HeaderText = "Util. NVV"
            .Columns("Utilizado_NVV").Width = 100 + _Menos
            .Columns("Utilizado_NVV").Visible = Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked
            .Columns("Utilizado_NVV").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Utilizado_NVV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("EnCurso").HeaderText = "En curso"
            .Columns("EnCurso").Width = 100 + _Menos
            .Columns("EnCurso").Visible = True
            .Columns("EnCurso").DefaultCellStyle.Format = "$ ###,##"
            .Columns("EnCurso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("Disponible").HeaderText = "Disponible"
            .Columns("Disponible").Width = 100 + _Menos
            .Columns("Disponible").Visible = True
            .Columns("Disponible").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Disponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For Each _Fila As DataGridViewRow In .Rows

                Dim _TipoCredito As String = _Fila.Cells("TipoCredito").Value
                Dim _Disponible As Double = _Fila.Cells("Disponible").Value

                If _Disponible < 0 Then

                    If Global_Thema = 2 Then ' Dark
                        _Fila.Cells("Disponible").Style.ForeColor = Color.FromArgb(220, 78, 65)
                    Else
                        _Fila.Cells("Disponible").Style.ForeColor = Color.Red
                    End If

                Else
                    If _TipoCredito = "Max. crédito" Then
                        _Fila.Cells("Disponible").Style.ForeColor = Color.DarkGreen
                    End If
                End If

            Next

        End With

    End Sub

    Public Function Fx_Revisar_Deuda_Doc_Entidad(_Formulario As Form,
                                                  _CodEntidad As String,
                                                  _SucEntidad As String,
                                                  Optional _Mostrar_Mendaje As Boolean = False) As DataTable

        Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

        Consulta_Sql = My.Resources.Sql_Entidad.SqlQuery_deuda_doc_comerciales
        Consulta_Sql = Replace(Consulta_Sql, "#CodEntidad#", _CodEntidad)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha#", _Fecha)

        Dim _TblDeuda As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_TblDeuda.Rows.Count) Then

            Dim _Deudas As Integer
            For Each _Fila As DataRow In _TblDeuda.Rows
                Dim _Nudonodefi As Boolean = _Fila.Item("NUDONODEFI")
                If Not _Nudonodefi Then _Deudas += 1
            Next

            _Tiene_Deudas = CBool(_Deudas)

            If _Tiene_Deudas Then

                If _Mostrar_Mendaje Then
                    MessageBoxEx.Show(_Formulario, "La entidad tiene documentos con deuda vencida", "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        End If

        Return _TblDeuda

    End Function

    Sub Sb_Revisar_Deuda_Doc_Entidad()

        Dim _Fecha_Tope As Date = FechaDelServidor()
        Dim _Fecha As String = Format(FechaDelServidor, "yyyyMMdd")

        Dim _CodEntidad As String = _RowEntidad.Item("KOEN")
        Dim _Dimoper = _RowEntidad.Item("DIMOPER")

        Consulta_Sql = My.Resources.Sql_Entidad.SqlQuery_deuda_doc_comerciales
        Consulta_Sql = Replace(Consulta_Sql, "#CodEntidad#", _CodEntidad)
        Consulta_Sql = Replace(Consulta_Sql, "#Fecha#", _Fecha)

        _TblDeuda = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_TblDeuda.Rows.Count) Then

            Dim _Deudas As Integer

            For Each _Fila As DataRow In _TblDeuda.Rows

                Dim _Nudonodefi As Boolean = _Fila.Item("NUDONODEFI")
                Dim _Dias_Atraso As Integer = _Fila.Item("DIAS_ATRASO")

                If Not _Nudonodefi Then
                    Dim _DiasDeAtraso = _Dias_Atraso - _Dimoper
                    If _DiasDeAtraso >= 0 Then
                        _Deudas += 1
                    End If
                End If

            Next

            _Tiene_Deudas = CBool(_Deudas)

        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Deuda.CellDoubleClick

        Me.Enabled = False

        Dim _Idmaeedo = Grilla_Deuda.Rows(Grilla_Deuda.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Frm_InfoEnt_Deudas_Doc_Comerciales_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_FincredPays_Click(sender As Object, e As EventArgs) Handles Btn_FincredPays.Click

        Dim _Foen As String = _Sql.Fx_Trae_Dato("MAEEN", "FOEN", "KOEN = '" & _RowEntidad.Item("KOEN") & "' And SUEN = '" & _RowEntidad.Item("SUEN") & "'")

        If String.IsNullOrEmpty(_Foen) Then
            MessageBoxEx.Show(Me, "Falta el teléfono en la ficha del cliente" & vbCrLf &
                              "No se puede realizar esta gestión sin un numero de teléfono de contacto.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Grupo_CondPago.Enabled = True
        Btn_FincredPays.Enabled = False
        Txt_Cuotas.Focus()

    End Sub

    Public Function Fx_Revisar_Situacion_Credito(_Formulario As Form,
                                                 _EnCurso As Double,
                                                 _Mostrar_Infor As Boolean,
                                                 Optional _Revisar_Deuda As Boolean = True,
                                                 Optional _EnCurso_Cheque As Double = 0,
                                                 Optional _EnCurso_Letra As Double = 0,
                                                 Optional _EnCurso_Pagare As Double = 0) As Boolean

        Sb_Revisar_Situacion_Credito_Entidad(_EnCurso, _EnCurso_Cheque, _EnCurso_Letra, _EnCurso_Pagare)

        If _Revisar_Deuda Then
            If _Crto_Disponible >= 0 Then
                Return True
            Else

                If _Mostrar_Infor Then
                    MessageBoxEx.Show(_Formulario, "Entidad supera línea de crédito", "Crédito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


                Return False
            End If
        Else
            Return True
        End If

    End Function

    Sub Sb_Revisar_Situacion_Credito_Entidad(_EnCurso_Total As Double,
                                             _EnCurso_Cheque As Double,
                                             _EnCurso_Letra As Double,
                                             _EnCurso_Pagare As Double)
        _DsInfCredito.Clear()

        Dim _CodEntidad As String = _RowEntidad.Item("KOEN")
        Dim _SucEntidad As String = _RowEntidad.Item("SUEN")

        Dim _CRSD As Double = _RowEntidad.Item("CRSD")
        Dim _CRCH As Double = _RowEntidad.Item("CRCH")
        Dim _CRLT As Double = _RowEntidad.Item("CRLT")
        Dim _CRPA As Double = _RowEntidad.Item("CRPA")
        Dim _CRTO As Double = _RowEntidad.Item("CRTO")


        Consulta_Sql = My.Resources.Sql_Entidad.SqlQuery_InfoCreditoEntidad
        Consulta_Sql = Replace(Consulta_Sql, "#CodEntidad#", _CodEntidad)
        Consulta_Sql = Replace(Consulta_Sql, "#Base_Bakapp#", _Global_BaseBk)
        Consulta_Sql = Replace(Consulta_Sql, "#Empresa#", ModEmpresa)

        Dim _DsCredito As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _DsCredito.Tables(0).TableName = "SinDocumentar"
        _DsCredito.Tables(1).TableName = "Pagos"
        _DsCredito.Tables(2).TableName = "Cheques"
        _DsCredito.Tables(3).TableName = "Letras"
        _DsCredito.Tables(4).TableName = "Pagares"
        _DsCredito.Tables(5).TableName = "Utilizado_NVV"
        _DsCredito.Tables(6).TableName = "Totales"

        _TblSinDocumentar = _DsCredito.Tables("SinDocumentar")

        '_TblPagos = _DsCredito.Tables("Pagos")
        _TblCheques = _DsCredito.Tables("Cheques")
        _TblLetras = _DsCredito.Tables("Letras")
        _TblPagares = _DsCredito.Tables("Pagares")
        _TblUtilizado_NVV = _DsCredito.Tables("Utilizado_NVV")
        _TblTotales = _DsCredito.Tables("Totales")

        _Crsd_Utilizado = _TblTotales.Rows(0).Item("SIN_DOCUMENTAR")
        '_CrPgo_Utilizado = _TblTotales.Rows(0).Item("PAGOS")
        _Crch_Utilizado = _TblTotales.Rows(0).Item("CHEQUES")
        _Crlt_Utilizado = _TblTotales.Rows(0).Item("LETRAS")
        _Crpa_Utilizado = _TblTotales.Rows(0).Item("PAGARES")

        If Chk_Utilizar_NVV_En_Credito_X_Cliente.Checked Then
            _CrNvv_Utilizado = _TblTotales.Rows(0).Item("NVV")
        End If

        _Crsd_Disponible = _CRSD - (_Crsd_Utilizado + _CrNvv_Utilizado) - _EnCurso_Total
        _Crch_Disponible = _CRCH - (_Crch_Utilizado + _EnCurso_Cheque)

        _Crlt_Disponible = _CRLT - (_Crlt_Utilizado + _EnCurso_Letra)
        _Crpa_Disponible = _CRPA - (_Crpa_Utilizado + _EnCurso_Pagare)

        _Crto_Utilizado = _Crsd_Utilizado + _CrNvv_Utilizado + _Crch_Utilizado + _Crlt_Utilizado + _Crpa_Utilizado

        Dim _CRSF As Double

        Sb_Revisar_Saldo_Favor(_TblPagos, _CRSF, _CrPgo_Utilizado, _CrPgo_Disponible, _CodEntidad)

        _Crto_Disponible = _CRTO - (_Crto_Utilizado + _EnCurso_Total + _EnCurso_Cheque + _EnCurso_Letra + _EnCurso_Pagare)
        _Crto_Disponible = _CRTO + _CrPgo_Disponible - (_Crto_Utilizado + _EnCurso_Total + _EnCurso_Cheque + _EnCurso_Letra + _EnCurso_Pagare)

        Fx_Nueva_Linea_Credito("Sin documentar Cta. Cte.", _CRSD, _Crsd_Utilizado, _CrNvv_Utilizado, _EnCurso_Total, _Crsd_Disponible)
        Fx_Nueva_Linea_Credito("En cheques", _CRCH, _Crch_Utilizado, 0, _EnCurso_Cheque, _Crch_Disponible)
        Fx_Nueva_Linea_Credito("En letras", _CRLT, _Crlt_Utilizado, 0, _EnCurso_Letra, _Crlt_Disponible)
        Fx_Nueva_Linea_Credito("En pagare", _CRPA, _Crpa_Utilizado, 0, _EnCurso_Pagare, _Crpa_Disponible)

        Fx_Nueva_Linea_Credito("Saldo Favor (anticipos)", _CRSF, _CrPgo_Utilizado, 0, 0, _CrPgo_Disponible) ' Nueva linea

        Fx_Nueva_Linea_Credito("Máximo crédito", _CRTO, _Crto_Utilizado - _CrNvv_Utilizado, _CrNvv_Utilizado, _EnCurso_Total, _Crto_Disponible)

        Grilla_Credito.DataSource = _DsInfCredito.Tables("Tbl_SituCredito")

    End Sub

    Sub Sb_Revisar_Saldo_Favor(ByRef _TblPagos As DataTable,
                               ByRef _CRSF As Double,
                               ByRef _CrPgo_Utilizado As Double,
                               ByRef _CrPgo_Disponible As Double,
                               _CodEntidad As String)

        Consulta_Sql = "SELECT
DPCE.TIDP AS TIDP,
DPCE.NUDP AS NUDP,
DPCE.NUCUDP AS NUCUDP,
DPCE.FEVEDP AS FEVEDP,
DPCE.ENDP AS ENTIDAD,
convert(char(10),DPCE.FEEMDP,103) AS EMISION,
convert(char(10),DPCE.FEVEDP,103) AS VENCIM,
DPCE.REFANTI AS GLOSA,DPCE.VADP,DPCE.VAASDP,
Isnull((Select Top 1 NOKOENDP From TABENDP Where KOENDP = EMDP),'????') AS BANCO,
DPCE.ESPGDP,
'VALOR' =CASE DPCE.TIMODP WHEN 'E' THEN 0 ELSE DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP END,
'VALORD'=CASE DPCE.TIMODP WHEN 'E' THEN DPCE.VADP-DPCE.VAASDP-DPCE.VAVUDP ELSE 0 END,
'NOMBRE'=( SELECT TOP 1 EN.NOKOEN FROM MAEEN EN WITH ( NOLOCK ) WHERE EN.KOEN=DPCE.ENDP ) 
Into #Paso
FROM MAEDPCE DPCE WITH ( NOLOCK ) 

WHERE DPCE.TIDP IN ( 'EFV','CHV','TJV','LTV','PAV','ncv','fcv','fdv','DEP','CRV','ATB' )
--AND DPCE.FEEMDP  >= '2010-09-01'
AND DPCE.EMPRESA='" & ModEmpresa & "'  AND DPCE.ESASDP='P' 
 AND ROUND(DPCE.VADP,2)-ROUND(DPCE.VAASDP,2)-ROUND(DPCE.VAVUDP,2)<>0.0 
 AND DPCE.ENDP='" & _CodEntidad & "'

 Select * From #Paso

 Select Isnull(SUM(VADP),0) As 'CRSF',Isnull(SUM(VAASDP),0) As 'Utilizado',Isnull(Sum(VALOR),0) As 'Disponible'
 From #Paso

 Drop Table #Paso"

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

        _TblPagos = _Ds.Tables(0)

        _CRSF = _Ds.Tables(1).Rows(0).Item("CRSF")
        _CrPgo_Utilizado = _Ds.Tables(1).Rows(0).Item("Utilizado")
        _CrPgo_Disponible = _Ds.Tables(1).Rows(0).Item("Disponible")

    End Sub

    Function Fx_Nueva_Linea_Credito(_TipoCredito As String,
                                    _Autorizado As Double,
                                    _Utilizado As Double,
                                    _Utilizado_NVV As Double,
                                    _EnCurso As Double,
                                    _Disponible As Double)

        Dim NewFila As DataRow
        NewFila = _DsInfCredito.Tables("Tbl_SituCredito").NewRow
        With NewFila

            .Item("TipoCredito") = _TipoCredito
            .Item("Autorizado") = _Autorizado
            .Item("Utilizado") = _Utilizado
            .Item("Utilizado_NVV") = _Utilizado_NVV
            .Item("EnCurso") = _EnCurso
            .Item("Disponible") = _Disponible

            _DsInfCredito.Tables("Tbl_SituCredito").Rows.Add(NewFila)
        End With

    End Function

    Private Sub Sb_Grilla_Credito_CellDoubleClick(sender As System.Object,
                                               e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla_Credito.Rows(Grilla_Credito.CurrentRow.Index)
        Dim _Cabeza = Grilla_Credito.Columns(Grilla_Credito.CurrentCell.ColumnIndex).Name

        Dim _TipoCredito = _Fila.Cells("TipoCredito").Value

        Dim Fm As New Frm_InfoEnt_Situacion_Documentos
        Dim _Revisar As Boolean

        Select Case _TipoCredito

            Case "Sin documentar Cta. Cte."

                If _Cabeza = "Utilizado_NVV" Then

                    Fm.Text = "Notas de venta"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Venta
                    Fm.Tabla = _TblUtilizado_NVV
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                ElseIf _Cabeza = "Utilizado" Then

                    Fm.Text = "Documentos de venta"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Venta
                    Fm.Tabla = _TblSinDocumentar
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                End If

            Case "En cheques"

                If _Cabeza = "Utilizado" Then

                    Fm.Text = "Cheques"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Pago
                    Fm.Tabla = _TblCheques
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                End If

            Case "En Letras"

                If _Cabeza = "Utilizado" Then

                    Fm.Text = "Letras"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Pago
                    Fm.Tabla = _TblLetras
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                End If

            Case "En Pagare"

                If _Cabeza = "Utilizado" Then

                    Fm.Text = "Pagare"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Pago
                    Fm.Tabla = _TblPagares
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                End If

            Case "Saldo Favor (anticipos)"

                If _Cabeza = "Utilizado" Then

                    Fm.Text = "Saldo Favor (anticipos)"
                    Fm.TipoDocumentos = Frm_InfoEnt_Situacion_Documentos._TipoDoc.Doc_Pago
                    Fm.Tabla = _TblPagos
                    _Revisar = CBool(Fm.Tabla.Rows.Count)

                End If

            Case Else

                _Revisar = False

        End Select

        If _Revisar Then

            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            Beep()
            ToastNotification.Show(Me, "NO EXISTE INFORMACION",
                              My.Resources.cross,
                               1 * 1000, eToastGlowColor.Red,
                               eToastPosition.MiddleCenter)

        End If

    End Sub

    Private Sub Btn_AceptarVencimientos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AceptarVencimientos.Click

        If _Global_Row_Configuracion_Estacion.Item("Fincred_Usar") Then
            If _Dias_1er_Vencimiento > 0 Then
                Warning_Box_Cupo_Exedido.Image = Imagenes_16x16.Images.Item("warning.png")
                Warning_Box_Cupo_Exedido.Text = "<b>  Cliente con cupo excedido</b><i> Venta sera revisada por FINCRED PAYS </i>"
                MessageBoxEx.Show(Me, "Este documento sera evaluado por FINCRED" & vbCrLf &
                                  "La validación se hara al momento de grabar el documento definitivamente", "FINCRED",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                RevFincred = True
            End If
        End If

        _Grabar_Vencimientos = True
        Me.Close()
    End Sub

    Private Sub Txt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosSinPuntosNiComas(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If

    End Sub

    Private Sub Dtp_Fecha_1er_Vencimiento_Validated(sender As System.Object, e As System.EventArgs)
        Sb_Procesar_Cond_Pago(False)
    End Sub

    Private Sub Txt_Validated(sender As System.Object, e As System.EventArgs)
        If String.IsNullOrEmpty(CType(sender, TextBox).Text) Then
            CType(sender, TextBox).Text = 0
        End If
        _Dias_1er_Vencimiento = Val(Txt_Dias_1er_Vencimiento.Text)
        _Cuotas = Val(Txt_Cuotas.Text)
        Sb_Procesar_Cond_Pago(True)
    End Sub

    Sub Sb_Procesar_Cond_Pago(_Cambia_F1Venc As Boolean)

        _Dias_Vencimiento = _Dias_1er_Vencimiento

        If _Cuotas = 0 Then
            Txt_Cuotas.Text = 1
            _Cuotas = 1
        End If

        Dim Cuotas_(_Cuotas - 1) As Date

        Dim _FechasVenci As Date = Now
        Dim _dias As Integer

        If _Dias_1er_Vencimiento > 0 And _Cuotas > 1 Then
            _dias = _Dias_1er_Vencimiento
            For i = 1 To _Cuotas
                _FechasVenci = DateAdd(DateInterval.Day, _dias, _FechasVenci)
                Cuotas_(i - 1) = _FechasVenci
                _dias = _Dias_Vencimiento
            Next
            _FechaUltVencimiento = _FechasVenci
        Else

            _Fecha_1er_Vencimiento = DateAdd(DateInterval.Day, _Dias_1er_Vencimiento, Now)
            Dtp_Fecha_1er_Vencimiento.Value = _Fecha_1er_Vencimiento

            Cuotas_(0) = _Fecha_1er_Vencimiento


            _FechaUltVencimiento = _Fecha_1er_Vencimiento 'Now
            _Cuotas = 1
        End If

        _Dias_1er_Vencimiento = DateDiff(DateInterval.Day, FechaDelServidor, _Fecha_1er_Vencimiento)
        If _Cambia_F1Venc Then _Fecha_1er_Vencimiento = Cuotas_(0)

        Dtp_Fecha_1er_Vencimiento.Value = _Fecha_1er_Vencimiento
        Dtp_FechaUltVencimiento.Value = _FechaUltVencimiento

    End Sub
    Private Sub Btn_CambCodPago_Click(sender As System.Object, e As System.EventArgs) Handles Btn_CambCodPago.Click

        If Fx_Tiene_Permiso(Me, "Bkp00034") Then
            Grupo_CondPago.Enabled = True
            Txt_Cuotas.Focus()
        End If

    End Sub
    Private Sub Warning_Box_Deuda_Cupo_Exedido_OptionsClick(sender As System.Object, e As System.EventArgs) Handles Warning_Box_Deuda.OptionsClick
        SuperTabControl1.SelectedTabIndex = 1
    End Sub
    Private Sub Tiempo_Alerta_Tick(sender As System.Object, e As System.EventArgs)

        If Warning_Box_Deuda.Visible Then
            Warning_Box_Deuda.Visible = False
        Else
            Warning_Box_Deuda.Visible = True
        End If

        If Warning_Box_Cupo_Exedido.Visible Then
            Warning_Box_Cupo_Exedido.Visible = False
        Else
            Warning_Box_Cupo_Exedido.Visible = True
        End If

    End Sub

End Class
