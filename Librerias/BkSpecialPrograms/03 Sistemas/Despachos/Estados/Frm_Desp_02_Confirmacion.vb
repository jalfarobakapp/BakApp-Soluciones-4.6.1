Imports DevComponents.DotNetBar

Public Class Frm_Desp_02_Confirmacion

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Confirmado As Boolean
    Dim _Cl_Despacho As Clas_Despacho
    Public Property Confirmado As Boolean
        Get
            Return _Confirmado
        End Get
        Set(value As Boolean)
            _Confirmado = value
        End Set
    End Property

    Public Property Despachos As Clas_Despacho
        Get
            Return _Cl_Despacho
        End Get
        Set(value As Clas_Despacho)
            _Cl_Despacho = value
        End Set
    End Property
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Desp_02_Confirmacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txt_Observaciones
        _Cl_Despacho.Fx_Tomar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If String.IsNullOrEmpty(Txt_Observaciones.Text.Trim) Then
            MessageBoxEx.Show(Me, "Debe ingresar una observación para seguir con la gestión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Observaciones.Focus()
            Return
        End If

        _Confirmado = _Cl_Despacho.Fx_Accion_Confirmacion(Txt_Observaciones.Text)

        If _Confirmado Then
            Me.Close()
        Else
            MessageBoxEx.Show(Me, _Cl_Despacho.Error, "Problemas!!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub



    Private Sub Frm_Desp_02_Confirmacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Frm_Desp_02_Confirmacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _Cl_Despacho.Fx_Soltar_Orden_Despacho(_Cl_Despacho.Id_Despacho, FUNCIONARIO)
    End Sub
End Class
