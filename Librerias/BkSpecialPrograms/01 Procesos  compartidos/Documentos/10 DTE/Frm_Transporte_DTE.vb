Imports System.Reflection
Imports DevComponents.DotNetBar
Imports Microsoft.Office.Interop.Outlook

Public Class Frm_Transporte_DTE

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Transporte_Dte As New Zw_Transporte_Dte
    Public Property UltimoTransporte As Zw_Transporte_Dte

    Public Property Grabar As Boolean


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

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

        Txt_DirDest.ReadOnly = True
        Txt_CmnaDest.ReadOnly = True
        Txt_CiudadDest.ReadOnly = True

        Txt_DirDest.Enabled = False
        Txt_CmnaDest.Enabled = False
        Txt_CiudadDest.Enabled = False

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

        If Txt_Patente.Text.ToString.Trim.Length < 5 Then
            MessageBoxEx.Show(Me, "La patente debe tener al menos 5 caracteres para motocicletas y 6 caracteres para autos y camiones.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

        Dim _Msg1 = "¿CONFIRMA LOS DATOS?"
        Dim _Msg2 = vbCrLf & $"Patente: {Txt_Patente.Text}" & vbCrLf &
                    $"Rut Transporte: {Txt_RUTTrans.Text}" & vbCrLf &
                    $"Rut Chofer: {Txt_RUTChofer.Text}" & vbCrLf &
                    $"Nombre Chofer: {Txt_Chofer.Text}"

        Dim _Mensaje As LsValiciones.Mensajes

        ' Si los datos actuales son iguales a UltimoTransporte, no pedir confirmación.
        Dim skipConfirmation As Boolean = ValoresIgualesAUltimo()

        If Not skipConfirmation Then
            _Mensaje = Fx_Confirmar_LecturaSINO(_Msg1, _Msg2, eTaskDialogIcon.Help,,,, False)

            If _Mensaje.Resultado <> "Yes" Then
                Return
            End If
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
        'MessageBoxEx.Show(Me, "Datos guardados correctamente.", "Información",
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Si se desea cerrar el formulario:
        Me.DialogResult = DialogResult.OK
        Grabar = True
        Me.Close()

    End Sub

    Private Function ValoresIgualesAUltimo() As Boolean
        If UltimoTransporte Is Nothing Then
            Return False
        End If

        Dim patenteActual As String = If(Txt_Patente.Text, String.Empty).Trim()
        Dim rutTransActual As String = If(Txt_RUTTrans.Text, String.Empty).Trim()
        Dim rutChoferActual As String = If(Txt_RUTChofer.Text, String.Empty).Trim()
        Dim choferActual As String = If(Txt_Chofer.Text, String.Empty).Trim()
        Dim dirDestActual As String = If(Txt_DirDest.Text, String.Empty).Trim()
        Dim cmnaDestActual As String = If(Txt_CmnaDest.Text, String.Empty).Trim()
        Dim ciudadDestActual As String = If(Txt_CiudadDest.Text, String.Empty).Trim()

        Dim patenteUlt As String = If(UltimoTransporte.Patente, String.Empty).Trim()
        Dim rutTransUlt As String = If(UltimoTransporte.RUTTrans, String.Empty).Trim()
        Dim rutChoferUlt As String = If(UltimoTransporte.RUTChofer, String.Empty).Trim()
        Dim choferUlt As String = If(UltimoTransporte.Chofer, String.Empty).Trim()
        Dim dirDestUlt As String = If(UltimoTransporte.DirDest, String.Empty).Trim()
        Dim cmnaDestUlt As String = If(UltimoTransporte.CmnaDest, String.Empty).Trim()
        Dim ciudadDestUlt As String = If(UltimoTransporte.CiudadDest, String.Empty).Trim()

        Dim iguales As Boolean = String.Equals(patenteActual, patenteUlt, StringComparison.OrdinalIgnoreCase) AndAlso
                                 String.Equals(rutTransActual, rutTransUlt, StringComparison.OrdinalIgnoreCase) AndAlso
                                 String.Equals(rutChoferActual, rutChoferUlt, StringComparison.OrdinalIgnoreCase) AndAlso
                                 String.Equals(choferActual, choferUlt, StringComparison.OrdinalIgnoreCase)

        Return iguales
    End Function


    Private Sub Btn_UltTransporte_Click(sender As Object, e As EventArgs) Handles Btn_UltTransporte.Click

        If IsNothing(UltimoTransporte) Then
            MessageBoxEx.Show(Me, "No hay un último transporte registrado.", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        With UltimoTransporte

            Txt_Patente.Text = If(.Patente, String.Empty)
            Txt_RUTTrans.Text = If(.RUTTrans, String.Empty)
            Txt_Chofer.Text = If(.Chofer, String.Empty)
            Txt_RUTChofer.Text = If(.RUTChofer, String.Empty)

        End With

        Txt_Chofer.Focus()

    End Sub
End Class
