Imports DevComponents.DotNetBar

Public Class Frm_ConfPuntosVta

    'Dim _Zw_PtsVta_Configuracion As New Zw_PtsVta_Configuracion
    Dim _Cl_Puntos As Cl_Puntos
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_ConfPuntosVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Cl_Puntos = New Cl_Puntos()
        _Cl_Puntos.Sb_Llenar_Zw_PtsVta_Configuracion(ModEmpresa)

        With _Cl_Puntos.Zw_PtsVta_Configuracion

            Input_GCadaPesos.Value = .GCadaPesos
            Input_GEquivPuntos.Value = .GEquivPuntos
            Input_RCadaPuntos.Value = .RCadaPuntos
            Input_REquivPesos.Value = .REquivPesos
            Input_MinPtosCanjear.Value = .MinPtosCanjear
            Input_ValMinPedCajear.Value = .ValMinPedCajear

        End With

        Me.ActiveControl = Input_GCadaPesos

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        With _Cl_Puntos.Zw_PtsVta_Configuracion

            .GCadaPesos = Input_GCadaPesos.Value
            .GEquivPuntos = Input_GEquivPuntos.Value
            .RCadaPuntos = Input_RCadaPuntos.Value
            .REquivPesos = Input_REquivPesos.Value
            .MinPtosCanjear = Input_MinPtosCanjear.Value
            .ValMinPedCajear = Input_ValMinPedCajear.Value

        End With

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Puntos.Fx_Grabar_Configuracion

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        MessageBoxEx.Show(Me, _Mensaje.Mensaje & vbCrLf &
                          "No sera necesario grabar en el siguiente formulario.", _Mensaje.Detalle,
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

End Class
