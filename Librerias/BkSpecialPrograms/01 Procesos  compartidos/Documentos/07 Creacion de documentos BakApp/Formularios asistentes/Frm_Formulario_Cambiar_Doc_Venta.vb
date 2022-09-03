
'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Formulario_Cambiar_Doc_Venta

    Enum Enum_Documento
        BLV
        FCV
        COV
        NVV
        Ninguno
    End Enum

    Dim _Post_Venta As Boolean

    Dim _Tido_Seleccionado As Enum_Documento
    Dim _Tido_Origen As Enum_Documento

    Public ReadOnly Property Pro_Tido_Seleccionado() As Enum_Documento
        Get
            Return _Tido_Seleccionado
        End Get
    End Property

    Public Sub New(ByVal Tido_Origen As String, Post_Venta As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '_Tido_Origen = Tido_Origen

        _Post_Venta = Post_Venta

        Select Case Tido_Origen

            Case "BLV"
                BtnBoleta.Checked = True '.Enabled = False
            Case "COV"
                BtnCotizacion.Checked = True '.Enabled = False
            Case "FCV"
                BtnFactura.Checked = True '.Enabled = False
            Case "NVV"
                BtnNotaDeVenta.Checked = True '.Enabled = False
        End Select

    End Sub

    Private Sub Frm_Formulario_Cambiar_Doc_Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Tido_Seleccionado = Enum_Documento.Ninguno
    End Sub

    Private Sub BtnBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBoleta.Click
        If Fx_Tiene_Permiso(Me, "Bkp00002") Then
            _Tido_Seleccionado = Enum_Documento.BLV
            Me.Close()
        End If
    End Sub

    Private Sub BtnCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCotizacion.Click
        If Fx_Tiene_Permiso(Me, "Bkp00004") Then
            _Tido_Seleccionado = Enum_Documento.COV
            Me.Close()
        End If
    End Sub

    Private Sub BtnFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFactura.Click

        Dim _Permiso As String

        If _Post_Venta Then
            _Permiso = "Bkp00003"
        Else
            _Permiso = "Bkp00054"
        End If

        If Fx_Tiene_Permiso(Me, _Permiso) Then
            _Tido_Seleccionado = Enum_Documento.FCV
            Me.Close()
        End If
    End Sub

    Private Sub BtnNotaDeVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNotaDeVenta.Click
        If Fx_Tiene_Permiso(Me, "Bkp00020") Then
            _Tido_Seleccionado = Enum_Documento.NVV
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Frm_Formulario_Cambiar_Doc_Venta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            _Tido_Seleccionado = Enum_Documento.Ninguno
            Me.Close()
        End If
    End Sub
End Class
