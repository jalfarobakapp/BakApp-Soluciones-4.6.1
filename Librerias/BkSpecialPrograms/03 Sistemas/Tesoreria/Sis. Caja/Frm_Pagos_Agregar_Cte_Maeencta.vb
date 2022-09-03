Imports DevComponents.DotNetBar

Public Class Frm_Pagos_Agregar_Cte_Maeencta

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Private _Emisor As String
    Private _Nombre_Emisor As String
    Private _Cuenta As String
    Private _Sucursal As String
    Private _Rut As String
    Private _Norut As String

    Private _Aceptar As Boolean

    Dim _Tidpen As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago

    Public Property Rut As String
        Get
            Return _Rut
        End Get
        Set
            _Rut = Value
        End Set
    End Property

    Public Property Norut As String
        Get
            Return _Norut
        End Get
        Set(value As String)
            _Norut = value
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

    Public Property Emisor As String
        Get
            Return _Emisor
        End Get
        Set(value As String)
            _Emisor = value
        End Set
    End Property

    Public Property Cuenta As String
        Get
            Return _Cuenta
        End Get
        Set(value As String)
            _Cuenta = value
        End Set
    End Property

    Public Property Tidpen As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago
        Get
            Return _Tidpen
        End Get
        Set(value As Frm_Pagos_Seleccionar_CH_TJ.Enum_Tipo_Pago)
            _Tidpen = value
        End Set
    End Property

    Public Property Nombre_Emisor As String
        Get
            Return _Nombre_Emisor
        End Get
        Set(value As String)
            _Nombre_Emisor = value
        End Set
    End Property

    Public Property Sucursal As String
        Get
            Return _Sucursal
        End Get
        Set(value As String)
            _Sucursal = value
        End Set
    End Property

    'Enum Enum_Tipo_Pago
    '    CH
    '    TJ
    '    DP
    '    PT
    'End Enum

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Aceptar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Pagos_Agregar_Cte_Maeencta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_EMDP_Documento.Tag = Emisor
        Txt_EMDP_Documento.Text = Nombre_Emisor
        Txt_CUDP_Nro_Cuenta.Text = Cuenta

        Txt_SUEMDP_Sucursal.Text = Sucursal

        Txt_Rut.Text = Rut
        Txt_Norut.Text = Norut

        If String.IsNullOrEmpty(Emisor) Then
            Call Btn_Buscar_Emisor_Click(Nothing, Nothing)
            If String.IsNullOrEmpty(Txt_EMDP_Documento.Tag) Then
                Me.Close()
            End If
            Me.ActiveControl = Txt_CUDP_Nro_Cuenta
        Else
            Me.ActiveControl = Txt_Rut
        End If

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If String.IsNullOrEmpty(Txt_EMDP_Documento.Text.Trim) Then

            Beep()
            ToastNotification.Show(Me, "FALTA EMISOR DE DOCUMENTO",
                                   My.Resources.cross,
                                   1 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Return

        End If

        If String.IsNullOrEmpty(Txt_CUDP_Nro_Cuenta.Text.Trim) Then

            Beep()
            ToastNotification.Show(Me, "FALTA NUMERO DE CUENTA",
                                   My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_CUDP_Nro_Cuenta.Focus()
            Return

        End If

        Aceptar = True
        Rut = Txt_Rut.Text
        Norut = Txt_Norut.Text
        Emisor = Txt_EMDP_Documento.Tag
        Nombre_Emisor = Txt_EMDP_Documento.Text
        Cuenta = Txt_CUDP_Nro_Cuenta.Text
        Sucursal = Txt_SUEMDP_Sucursal.Text

        Me.Close()

    End Sub

    Private Sub Btn_Buscar_Emisor_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Emisor.Click

        Dim Fm_Emisor As New Frm_Seleccionar_Emisor_Doc_Pago(_Tidpen)
        Fm_Emisor.ShowDialog(Me)
        Dim _Row_Emisor As DataRow = Fm_Emisor.Pro_Row_Tabendp
        Fm_Emisor.Dispose()

        If Not (_Row_Emisor Is Nothing) Then

            Txt_EMDP_Documento.Tag = _Row_Emisor.Item("KOENDP")
            Txt_EMDP_Documento.Text = _Row_Emisor.Item("NOKOENDP").ToString.Trim
            Txt_CUDP_Nro_Cuenta.Text = String.Empty

            Txt_SUEMDP_Sucursal.Text = _Row_Emisor.Item("SUENDP").ToString.Trim

            If String.IsNullOrEmpty(Txt_SUEMDP_Sucursal.Text) Then

                Txt_SUEMDP_Sucursal.Focus()
                Txt_SUEMDP_Sucursal.SelectAll()

            Else

                Txt_CUDP_Nro_Cuenta.Focus()

            End If

        End If

    End Sub

End Class
