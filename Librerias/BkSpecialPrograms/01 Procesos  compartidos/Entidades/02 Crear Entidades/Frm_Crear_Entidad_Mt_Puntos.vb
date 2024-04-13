Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_Puntos

    Public Property Aceptar As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_Puntos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_EmailPuntos

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If Not Fx_Validar_Email(Txt_EmailPuntos.Text.Trim) Then
            MessageBoxEx.Show(Me, "Correo invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_EmailPuntos.Focus()
            Return
        End If

        Aceptar = True
        Me.Close()

    End Sub
End Class
