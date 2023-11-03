Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Public Class Frm_Tickets_Respuesta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_TicketAc As Integer
    Dim _Funcionario As String
    Public Property Grabar As Boolean

    Public Sub New(_Id_TicketAc As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._Id_TicketAc = _Id_TicketAc

    End Sub

    Private Sub Frm_Tickets_Respuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Descripcion.Text) Then
            MessageBoxEx.Show(Me, "La descripción no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Descripcion.Focus()
            Return
        End If

        Grabar = True
        Me.Close()
    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Adjuntar_Archivos("Zw_Stk_Tickets_Archivos", "Id_TicketAc", _Id_TicketAc)
        'Fm.Text = "Archivos adjuntos documento en construcción: " & _Tido.Trim & " Nro: " & _Nudo
        Fm.Pedir_Permiso = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

    End Sub
End Class
