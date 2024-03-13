Imports DevComponents.DotNetBar
Imports Funciones_BakApp

Public Class Frm_Permisos_Usuario_Porc_Dscto

    Dim _Aceptar As Boolean

    Public ReadOnly Property Pro_Aceptar() As Boolean
        Get
            Return _Aceptar
        End Get
    End Property

    Public Property Pro_Porcentaje() As Double
        Get
            Return Num_Porcentaje.Value
        End Get
        Set(ByVal value As Double)
            Num_Porcentaje.Value = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Permisos_Usuario_Porc_Dscto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        _Aceptar = True
        Me.Close()
    End Sub

    Private Sub Frm_Permisos_Usuario_Porc_Dscto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Enter Then
            _Aceptar = True
            Me.Close()
        ElseIf e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class