'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Barra_Progreso

    Dim _Cancelar As Boolean

    Public Property Pro_Cancelar() As Boolean
        Get
            Return _Cancelar
        End Get
        Set(ByVal value As Boolean)
            Btn_Cancelar.Enabled = value
        End Set
    End Property
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Btn_Cancelar.Enabled = False
    End Sub

    Private Sub Frm_Barra_Progreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Btn_Minimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Minimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class