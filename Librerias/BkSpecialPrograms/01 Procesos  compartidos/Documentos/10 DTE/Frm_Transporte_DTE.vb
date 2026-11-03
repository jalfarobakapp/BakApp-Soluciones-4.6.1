Imports DevComponents.DotNetBar

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

        Dtp_FchSalida.IsEmpty = True
        Dtp_HraSalida.IsEmpty = True
        Dtp_FchLlegada.IsEmpty = True

        With Zw_Transporte_Dte

            Txt_Patente.Text = If(.Patente, String.Empty)
            Txt_PatenteCarro.Text = If(.PatenteCarro, String.Empty)
            Txt_RUTTrans.Text = If(.RUTTrans, String.Empty)
            Txt_Chofer.Text = If(.Chofer, String.Empty)
            Txt_RUTChofer.Text = If(.RUTChofer, String.Empty)
            Txt_DirDest.Text = If(.DirDest, String.Empty)
            Txt_CmnaDest.Text = If(.CmnaDest, String.Empty)
            Txt_CiudadDest.Text = If(.CiudadDest, String.Empty)

            Try
                Dtp_FchSalida.Value = If(.FchSalida, String.Empty)
                Dtp_HraSalida.Value = If(.HraSalida, String.Empty)
                Dtp_FchLlegada.Value = If(.FchLlegada, String.Empty)
            Catch ex As Exception
                Dtp_FchSalida.IsEmpty = True
                Dtp_HraSalida.IsEmpty = True
                Dtp_FchLlegada.IsEmpty = True
            End Try

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

        If Txt_Patente.Text.ToString.Trim.Length < 5 Then
            MessageBoxEx.Show(Me, "La patente debe tener al menos 5 caracteres para motocicletas y 6 caracteres para autos y camiones.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Patente.Focus()
            Return
        End If

        If Not String.IsNullOrEmpty(Txt_PatenteCarro.Text.ToString.Trim) AndAlso Txt_PatenteCarro.Text.ToString.Trim.Length < 6 Then
            MessageBoxEx.Show(Me, "La patente de carro debe tener al menos 6 caracteres.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_PatenteCarro.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_RUTTrans.Text.Trim) Then
            MessageBoxEx.Show(Me, "El Rut del Transportista no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

        Dim _Mensaje As LsValiciones.Mensajes

        Dim tieneFechaSalida As Boolean = Not Dtp_FchSalida.IsEmpty
        Dim tieneHoraSalida As Boolean = Not Dtp_HraSalida.IsEmpty
        Dim tieneFechaLlegada As Boolean = Not Dtp_FchLlegada.IsEmpty
        Dim cantidadDatosTransporte As Integer =
                                                If(tieneFechaSalida, 1, 0) +
                                                If(tieneHoraSalida, 1, 0) +
                                                If(tieneFechaLlegada, 1, 0)

        If cantidadDatosTransporte > 0 AndAlso cantidadDatosTransporte < 3 Then
            MessageBoxEx.Show(Me,
                      "Si informa fecha de salida, hora de salida o fecha de llegada, debe completar los tres datos.",
                      "Validación",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Stop)

            If Not tieneFechaSalida Then
                Dtp_FchSalida.Focus()
            ElseIf Not tieneHoraSalida Then
                Dtp_HraSalida.Focus()
            Else
                Dtp_FchLlegada.Focus()
            End If

            Return
        End If

        If cantidadDatosTransporte = 3 Then
            If Dtp_FchSalida.Value.Date < Date.Today Then
                MessageBoxEx.Show(Me,
                          "La fecha de salida no puede ser anterior a hoy.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
                Dtp_FchSalida.Focus()
                Return
            End If

            If Dtp_FchLlegada.Value.Date < Dtp_FchSalida.Value.Date Then
                MessageBoxEx.Show(Me,
                          "La fecha de llegada no puede ser anterior a la fecha de salida.",
                          "Validación",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Stop)
                Dtp_FchLlegada.Focus()
                Return
            End If
        End If

        If cantidadDatosTransporte = 0 Then
            _Mensaje = Fx_Confirmar_LecturaSINO(
        "¿Desea continuar sin informar los datos de salida y llegada?",
        "Fecha de salida, hora de salida y fecha de llegada están vacías.",
        eTaskDialogIcon.Help,,,, False)

            If _Mensaje.Resultado <> "Yes" Then
                Return
            End If
        End If

        Dim _Msg1 = "¿CONFIRMA LOS DATOS?"
        Dim _Msg2 = vbCrLf & $"Patente: {Txt_Patente.Text}" & IIf(Txt_PatenteCarro.Text.Trim <> String.Empty, $" Patente Carro: {Txt_PatenteCarro.Text}", String.Empty) & vbCrLf &
                    $"Rut Transporte: {Txt_RUTTrans.Text}" & vbCrLf &
                    $"Patente Carro: {Txt_PatenteCarro.Text}" & vbCrLf &
                    $"Rut Chofer: {Txt_RUTChofer.Text}" & vbCrLf &
                    $"Nombre Chofer: {Txt_Chofer.Text}"

        _Mensaje = New LsValiciones.Mensajes

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
            .PatenteCarro = Txt_PatenteCarro.Text
            .RUTTrans = Txt_RUTTrans.Text
            .Chofer = Txt_Chofer.Text
            .RUTChofer = Txt_RUTChofer.Text
            .DirDest = Txt_DirDest.Text
            .CmnaDest = Txt_CmnaDest.Text
            .CiudadDest = Txt_CiudadDest.Text
            .FchSalida = If(Dtp_FchSalida.IsEmpty, Nothing, Dtp_FchSalida.Value)
            .HraSalida = If(Dtp_HraSalida.IsEmpty, Nothing, Dtp_HraSalida.Value)
            .FchLlegada = If(Dtp_FchLlegada.IsEmpty, Nothing, Dtp_FchLlegada.Value)

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
        Dim patenteCarroActual As String = If(Txt_PatenteCarro.Text, String.Empty).Trim()
        Dim rutTransActual As String = If(Txt_RUTTrans.Text, String.Empty).Trim()
        Dim rutChoferActual As String = If(Txt_RUTChofer.Text, String.Empty).Trim()
        Dim choferActual As String = If(Txt_Chofer.Text, String.Empty).Trim()
        Dim dirDestActual As String = If(Txt_DirDest.Text, String.Empty).Trim()
        Dim cmnaDestActual As String = If(Txt_CmnaDest.Text, String.Empty).Trim()
        Dim ciudadDestActual As String = If(Txt_CiudadDest.Text, String.Empty).Trim()
        Dim fchSalidaActual As String = If(Dtp_FchSalida.IsEmpty, String.Empty, Dtp_FchSalida.Value.ToString("yyyy-MM-dd"))
        Dim hraSalidaActual As String = If(Dtp_HraSalida.IsEmpty, String.Empty, Dtp_HraSalida.Value.ToString("HH:mm:ss"))
        Dim fchLlegadaActual As String = If(Dtp_FchLlegada.IsEmpty, String.Empty, Dtp_FchLlegada.Value.ToString("yyyy-MM-dd"))

        Dim patenteUlt As String = If(UltimoTransporte.Patente, String.Empty).Trim()
        Dim patenteCarroUlt As String = If(UltimoTransporte.PatenteCarro, String.Empty).Trim()
        Dim rutTransUlt As String = If(UltimoTransporte.RUTTrans, String.Empty).Trim()
        Dim rutChoferUlt As String = If(UltimoTransporte.RUTChofer, String.Empty).Trim()
        Dim choferUlt As String = If(UltimoTransporte.Chofer, String.Empty).Trim()
        Dim dirDestUlt As String = If(UltimoTransporte.DirDest, String.Empty).Trim()
        Dim cmnaDestUlt As String = If(UltimoTransporte.CmnaDest, String.Empty).Trim()
        Dim ciudadDestUlt As String = If(UltimoTransporte.CiudadDest, String.Empty).Trim()
        Dim fchSalidaUlt As String = If(UltimoTransporte.FchSalida.HasValue, UltimoTransporte.FchSalida.Value.ToString("yyyy-MM-dd"), String.Empty)
        Dim hraSalidaUlt As String = If(UltimoTransporte.HraSalida.HasValue, UltimoTransporte.HraSalida.Value.ToString("HH:mm:ss"), String.Empty)
        Dim fchLlegadaUlt As String = If(UltimoTransporte.FchLlegada.HasValue, UltimoTransporte.FchLlegada.Value.ToString("yyyy-MM-dd"), String.Empty)

        Dim iguales As Boolean = String.Equals(patenteActual, patenteUlt, StringComparison.OrdinalIgnoreCase) AndAlso
                                 String.Equals(patenteCarroActual, patenteCarroUlt, StringComparison.OrdinalIgnoreCase) AndAlso
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

    Private Sub Dtp_FchSalida_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_FchSalida.ButtonClearClick
        Dtp_FchSalida.IsEmpty = True
    End Sub

    Private Sub Dtp_HraSalida_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_HraSalida.ButtonClearClick
        Dtp_HraSalida.IsEmpty = True
    End Sub

    Private Sub Dtp_FchLlegada_ButtonClearClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Dtp_FchLlegada.ButtonClearClick
        Dtp_FchLlegada.IsEmpty = True
    End Sub
End Class
