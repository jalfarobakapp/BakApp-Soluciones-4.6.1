Imports DevComponents.DotNetBar

Public Class Frm_CrearContenedor

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Grabar As Boolean
    Public Property Eliminar As Boolean
    Public Property Zw_Contenedor As New Zw_Contenedor

    Dim _Cl_Contenedor As New Cl_Contenedor

    Public Sub New(_IdCont As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Zw_Contenedor = _Cl_Contenedor.Fx_Llenar_Contenedor(_IdCont)

    End Sub

    Private Sub Frm_CrearContenedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Zw_Contenedor
            'Txt_Id.Text = .Id
            'Txt_Empresa.Text = .Empresa
            Txt_Contenedor.Text = .Contenedor
            Txt_NombreContenedor.Text = .NombreContenedor
            'Txt_Tido_Rela.Text = .Tido_Rela
            'Txt_Nudo_Rela.Text = .Nudo_Rela
            'Txt_Idmaeedo_Rela.Text = .Idmaeedo_Rela

            Txt_Contenedor.Enabled = Not CBool(.Id)

        End With

        Me.ActiveControl = Txt_Contenedor

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrWhiteSpace(Txt_Contenedor.Text) Then
            MessageBoxEx.Show(Me, "Falta el código del contenedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Contenedor.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Txt_NombreContenedor.Text) Then
            MessageBoxEx.Show(Me, "Falta el nombre del contenedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_NombreContenedor.Focus()
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes

        With Zw_Contenedor
            .Contenedor = Txt_Contenedor.Text
            .NombreContenedor = Txt_NombreContenedor.Text
        End With


        If Zw_Contenedor.Id = 0 Then
            _Mensaje = _Cl_Contenedor.Fx_Crear_Contenedor(Zw_Contenedor)
        Else
            _Mensaje = _Cl_Contenedor.Fx_Editar_Contenedor(Zw_Contenedor)
        End If

        MessageBoxEx.Show(_Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Está seguro de eliminar el contenedor?", "Eliminar Contenedor",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As LsValiciones.Mensajes = _Cl_Contenedor.Fx_Eliminar_Contenedor(Zw_Contenedor)

        MessageBoxEx.Show(_Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Eliminar = True
        Me.Close()

    End Sub

End Class
