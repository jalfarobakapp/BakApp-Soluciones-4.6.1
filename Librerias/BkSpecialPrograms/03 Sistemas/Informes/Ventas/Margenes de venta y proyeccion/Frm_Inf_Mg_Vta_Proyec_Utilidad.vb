Imports Funciones_BakApp
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Mg_Vta_Proyec_Utilidad

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Fecha_Desde As Date
    Dim _Fecha_Hasta As Date

    Dim _DH_Transcurridos As Integer
    Dim _DH_Total As Integer

    Public Property Pro_Fecha_Desde() As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Desde = value
        End Set
    End Property

    Public Property Pro_Fecha_Hasta() As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(ByVal value As DateTime)
            _Fecha_Hasta = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Inf_Mg_Vta_Proyec_Utilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _Fecha_Fin_Mes As Date = ultimodiadelmes(_Fecha_Hasta)

        _DH_Transcurridos = Fx_Dias_Habiles(_Fecha_Desde, _Fecha_Hasta)
        _DH_Total = Fx_Dias_Habiles(_Fecha_Desde, _Fecha_Fin_Mes)

        Lbl_Dias_Habiles.Tag = _DH_Transcurridos
        Lbl_Dias_Habiles_Total.Tag = _DH_Total

        Lbl_Proyeccion_Lineal.Tag = (Lbl_Total_Neto.Tag / Lbl_Dias_Habiles.Tag) * Lbl_Dias_Habiles_Total.Tag
        Lbl_Proyeccion_Lineal.Text = FormatCurrency(Lbl_Proyeccion_Lineal.Tag, 0)

        Lbl_Dias_Habiles.Text = Lbl_Dias_Habiles.Tag
        Lbl_Dias_Habiles_Total.Text = Lbl_Dias_Habiles_Total.Tag

        Lbl_PPMg.Text = FormatPercent(Lbl_PPMg.Tag, 2)

        Lbl_Total_Neto.Text = FormatCurrency(Lbl_Total_Neto.Tag, 0)
        Lbl_Utilidad.Text = FormatCurrency(0, 0)

        AddHandler Txt_Costo.KeyPress, AddressOf Txt_KeyPress_Enter
        AddHandler Txt_Costo.KeyPress, AddressOf Txt_KeyPress_Solo_Numeros

    End Sub


    Private Sub Btn_Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Calcular.Click

        'Txt_Costo.Tag = Val(Txt_Costo.Text)
        Lbl_Utilidad.Tag = (Lbl_Proyeccion_Lineal.Tag * Lbl_PPMg.Tag) - Txt_Costo.Tag
        Lbl_Utilidad.Text = FormatCurrency(Lbl_Utilidad.Tag, 0)

    End Sub


    Private Sub Txt_Costo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Costo.Validated

        Txt_Costo.Tag = Val(Txt_Costo.Text)
        Txt_Costo.Text = FormatCurrency(Txt_Costo.Tag, 0)

    End Sub

    Private Sub Txt_KeyPress_Solo_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub Txt_KeyPress_Enter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Txt_Costo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Costo.Enter

        If CBool(Txt_Costo.Tag) Then
            Txt_Costo.Text = Txt_Costo.Tag
        Else
            Txt_Costo.Text = String.Empty
        End If

    End Sub
End Class