Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Generales_Saldo_NoAsig

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Pago As DataRow

    Dim _Endo As String
    Dim _Vadp As Double
    Dim _Saldo As Double
    Dim _Vavudp As Double
    Dim _Anticipo As Double
    Dim _Refanti As String
    Dim _Idrsd As Integer
    Dim _Archirsd As String
    Dim _Filtro_Doc As String

    Dim _Grabar As Boolean

    Public Property Vadp As Double
        Get
            Return _Vadp
        End Get
        Set(value As Double)
            _Vadp = value
        End Set
    End Property

    Public Property Saldo As Double
        Get
            Return _Saldo
        End Get
        Set(value As Double)
            _Saldo = value
        End Set
    End Property

    Public Property Vavudp As Double
        Get
            Return _Vavudp
        End Get
        Set(value As Double)
            _Vavudp = value
        End Set
    End Property

    Public Property Anticipo As Double
        Get
            Return _Anticipo
        End Get
        Set(value As Double)
            _Anticipo = value
        End Set
    End Property

    Public Property Refanti As String
        Get
            _Refanti = Txt_Refanti.Text.Trim
            Return _Refanti
        End Get
        Set(value As String)
            _Refanti = value
        End Set
    End Property

    Public Property Idrsd As Integer
        Get
            Return _Idrsd
        End Get
        Set(value As Integer)
            _Idrsd = value
        End Set
    End Property

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Archirsd As String
        Get
            Return _Archirsd
        End Get
        Set(value As String)
            _Archirsd = value
        End Set
    End Property

    Public Sub New(_Endo As String, _Row_Pago As DataRow, _Filtro_Doc As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Endo = _Endo
        Me._Row_Pago = _Row_Pago
        Me._Filtro_Doc = _Filtro_Doc

        Lbl_Tidp.Text = _Row_Pago.Item("TIDP")
        Lbl_Nucudp.Text = _Row_Pago.Item("NUCUDP")
        Lbl_Vadp.Tag = _Row_Pago.Item("VADP")
        Lbl_Saldo.Tag = _Row_Pago.Item("SALDO")
        Txt_Vavudp.Tag = _Row_Pago.Item("VAVUDP")
        Lbl_Anticipo.Tag = 0
        _Archirsd = _Row_Pago.Item("ARCHIRSD")
        Txt_Refanti.Text = _Row_Pago.Item("REFANTI")

        _Idrsd = _Row_Pago.Item("IDRSD")

        Btn_Ver_Documento.Enabled = CBool(_Idrsd)

        Lbl_Doc_Anticipo.Text = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrsd)

    End Sub

    Private Sub Frm_Pagos_Generales_Saldo_NoAsig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Calcular_Valores()
        Me.ActiveControl = Txt_Vavudp

    End Sub

    Private Sub Txt_Vavudp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Vavudp.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            Txt_Vavudp.Tag = Val(Txt_Vavudp.Text)

            If Txt_Vavudp.Tag > Lbl_Saldo.Tag Then
                Txt_Vavudp.Tag = 0
            End If

            Sb_Calcular_Valores()

        End If

    End Sub

    Sub Sb_Calcular_Valores()

        _Vadp = Lbl_Vadp.Tag
        _Saldo = Lbl_Saldo.Tag
        _Anticipo = Lbl_Anticipo.Tag
        _Vavudp = Txt_Vavudp.Tag

        _Anticipo = _Saldo - _Vavudp

        Lbl_Anticipo.Tag = _Anticipo
        Lbl_Anticipo.Text = FormatNumber(_Anticipo, 0)

        Lbl_Vadp.Text = FormatNumber(_Vadp, 0)
        Lbl_Saldo.Text = FormatNumber(_Saldo, 0)
        Txt_Vavudp.Text = FormatNumber(_Vavudp, 0)

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        _Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Doc_Asociado_Incorporar_Click(sender As Object, e As EventArgs) Handles Btn_Doc_Asociado_Incorporar.Click

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        Dim _Tbl As DataTable

        _Filtrar.Tabla = "MAEEDO"
        _Filtrar.Campo = "IDMAEEDO"
        _Filtrar.Descripcion = "TIDO+'-'+NUDO+'    '+Rtrim(LTrim(MODO))+'      '+PARSENAME(CONVERT(VARCHAR,CAST(VABRDO AS MONEY),1),2)"

        Dim _Condicion = "And EMPRESA='" & ModEmpresa & "'  AND ENDO='" & _Endo & "'  AND TIDO IN ('NVV','RES','PRO') AND ESDO Not In ('C','N') AND   
                          NOT EXISTS (SELECT * FROM MAEDPCE WHERE MAEDPCE.ARCHIRSD = 'MAEEDO' AND MAEDPCE.IDRSD = MAEEDO.IDMAEEDO)"

        _Filtrar.Ver_Codigo = False

        Dim _Reg = _Sql.Fx_Cuenta_Registros("MAEEDO", "1 > 0 " & _Condicion)

        If _Reg = 0 Then

            MessageBoxEx.Show(Me, "No hay documentos que mostrar", "Buscar documentos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return

        End If

        If _Filtrar.Fx_Filtrar(_Tbl,
                           Clas_Filtros_Random.Enum_Tabla_Fl._Otra, _Condicion,
                           False, False, True) Then

            _Tbl = _Filtrar.Pro_Tbl_Filtro

            _Archirsd = "MAEEDO"
            _Idrsd = _Tbl.Rows(0).Item("Codigo")
            Lbl_Doc_Anticipo.Text = _Sql.Fx_Trae_Dato("MAEEDO", "TIDO+'-'+NUDO", "IDMAEEDO = " & _Idrsd)
            Btn_Ver_Documento.Enabled = True

        End If

    End Sub

    Private Sub Btn_Ver_Documento_Click(sender As Object, e As EventArgs) Handles Btn_Ver_Documento.Click

        Me.Enabled = False

        Try
            If CBool(_Idrsd) Then

                Dim _Idmaeedo = _Idrsd

                Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
                Fm.Btn_Ver_Orden_de_despacho.Visible = False
                Fm.ShowDialog(Me)
                Fm.Dispose()

            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Enabled = True
        End Try

    End Sub

End Class
