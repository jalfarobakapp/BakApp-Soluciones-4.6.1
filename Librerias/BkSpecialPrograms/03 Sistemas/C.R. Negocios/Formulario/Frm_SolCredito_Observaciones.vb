Imports DevComponents.DotNetBar


Public Class Frm_SolCredito_Observaciones

    Dim _Grabar As Boolean
    Dim _Cierre_Observaciones As String
    Dim _Graba_Jefe As Boolean

    Public Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Property Pro_Cierre_Observaciones As String
        Get
            Return _Cierre_Observaciones
        End Get
        Set(value As String)
            _Cierre_Observaciones = value
        End Set
    End Property

    Public Property Pro_Graba_Jefe As Boolean
        Get
            Return _Graba_Jefe
        End Get
        Set(value As Boolean)
            _Graba_Jefe = value
        End Set
    End Property

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Grabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Grabar.Click

        If _Graba_Jefe Then
            If Not Fx_Tiene_Permiso(Me, "Scn00017") Then
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Txt_Observaciones.Text)) Then
            MessageBoxEx.Show(Me, "Debe ingresar alguna observación", "Falta observación", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Observaciones.Focus()
            Return
        End If

        _Grabar = True
        Me.Close()
    End Sub

    Private Sub Frm_SolCredito_Observaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub Btn_Observaciones_Cierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Observaciones_Cierre.Click
        MessageBoxEx.Show(Me, _Cierre_Observaciones, "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class