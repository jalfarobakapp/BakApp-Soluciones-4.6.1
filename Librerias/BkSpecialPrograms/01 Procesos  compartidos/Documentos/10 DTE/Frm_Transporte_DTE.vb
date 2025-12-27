Imports System.Reflection
Imports DevComponents.DotNetBar
Imports Microsoft.Office.Interop.Outlook

Public Class Frm_Transporte_DTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Transporte_Dte As New Zw_Transporte_Dte

    Public Property Grabar As Boolean


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Frm_Transporte_DTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Zw_Transporte_Dte

            Txt_Patente.Text = If(.Patente, String.Empty)
            Txt_RUTTrans.Text = If(.RUTTrans, String.Empty)
            Txt_Chofer.Text = If(.Chofer, String.Empty)
            Txt_RUTChofer.Text = If(.RUTChofer, String.Empty)
            Txt_DirDest.Text = If(.DirDest, String.Empty)
            Txt_CmnaDest.Text = If(.CmnaDest, String.Empty)
            Txt_CiudadDest.Text = If(.CiudadDest, String.Empty)

        End With

        Me.ActiveControl = Txt_Patente

    End Sub

    Private Function FindControlRecursive(parent As Control, name As String) As Control
        If parent Is Nothing OrElse String.IsNullOrEmpty(name) Then
            Return Nothing
        End If

        ' Comparación case-insensitive
        If String.Equals(parent.Name, name, StringComparison.OrdinalIgnoreCase) Then
            Return parent
        End If

        For Each ctrl As Control In parent.Controls
            If String.Equals(ctrl.Name, name, StringComparison.OrdinalIgnoreCase) Then
                Return ctrl
            End If

            If ctrl.HasChildren Then
                Dim found As Control = FindControlRecursive(ctrl, name)
                If found IsNot Nothing Then
                    Return found
                End If
            End If
        Next

        Return Nothing
    End Function

    Private Function IsRutControlName(name As String) As Boolean
        If String.IsNullOrEmpty(name) Then
            Return False
        End If

        Return name.ToLowerInvariant().Contains("rut")
    End Function


    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If Zw_Transporte_Dte Is Nothing Then
            Zw_Transporte_Dte = New Zw_Transporte_Dte()
        End If

        If String.IsNullOrEmpty(Txt_Patente.Text.Trim) Then
            MessageBoxEx.Show(Me, "La patente no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Patente.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_RUTTrans.Text.Trim) Then
            MessageBoxEx.Show(Me, "El Rut del Transportista no puede estar vacía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RUTTrans.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_RUTChofer.Text.Trim) Then
            MessageBoxEx.Show(Me, "El Rut del Chofer no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RUTChofer.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Chofer.Text.Trim) Then
            MessageBoxEx.Show(Me, "El nombre del Chofer no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Chofer.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_DirDest.Text.Trim) Then
            MessageBoxEx.Show(Me, "La Dirección de destino no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_DirDest.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_CiudadDest.Text.Trim) Then
            MessageBoxEx.Show(Me, "La Ciudad de destino no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CiudadDest.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_CmnaDest.Text.Trim) Then
            MessageBoxEx.Show(Me, "La Comuna de destino no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_CmnaDest.Focus()
            Return
        End If

        If Not VerificaDigito(Txt_RUTTrans.Text) Then
            MessageBoxEx.Show(Me, "Rut del Transportirta invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RUTTrans.Focus()
            Return
        End If

        If Not VerificaDigito(Txt_RUTChofer.Text) Then
            MessageBoxEx.Show(Me, "Rut del Chofer invalido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_RUTChofer.Focus()
            Return
        End If

        With Zw_Transporte_Dte

            .Patente = Txt_Patente.Text
            .RUTTrans = Txt_RUTTrans.Text
            .Chofer = Txt_Chofer.Text
            .RUTChofer = Txt_RUTChofer.Text
            .DirDest = Txt_DirDest.Text
            .CmnaDest = Txt_CmnaDest.Text
            .CiudadDest = Txt_CiudadDest.Text

        End With

        ' Si todo está bien, confirmar y cerrar formulario (o ajustar según necesidad)
        MessageBoxEx.Show(Me, "Datos guardados correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Si se desea cerrar el formulario:
        Me.DialogResult = DialogResult.OK
        Grabar = True
        Me.Close()

    End Sub
End Class
