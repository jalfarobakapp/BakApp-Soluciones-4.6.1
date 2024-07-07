Imports DevComponents.DotNetBar

Public Class Frm_CrearContador

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _IdContador As Integer

    Public Grabar As Boolean
    Public Eliminado As Boolean

    Public Property Cl_Contador As New Cl_Contador

    Public Sub New(_IdContador As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Cl_Contador.Fx_Llenar_Zw_Inv_Contador(_IdContador)
        Me._IdContador = _IdContador

    End Sub

    Private Sub Frm_Operadores_Crear_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Chk_Activo.Checked = True
        Txt_Nombre.CharacterCasing = CharacterCasing.Upper
        Txt_Email.CharacterCasing = CharacterCasing.Lower

        If CBool(_IdContador) Then

            With Cl_Contador.Zw_Inv_Contador

                Txt_Rut.Text = .Rut
                Txt_Nombre.Text = .Nombre
                Txt_Telefono.Text = .Telefono
                Txt_Email.Text = .Email
                Chk_Activo.Checked = .Activo

            End With
            Me.ActiveControl = Txt_Nombre
        Else
            Me.ActiveControl = Txt_Rut
        End If

        Btn_Eliminar.Visible = CBool(_IdContador)

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Txt_Rut.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Rut", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Rut.Focus()
            Return
        End If

        If Not VerificaDigito(Txt_Rut.Text.Trim) Then
            MessageBoxEx.Show(Me, "Rut no válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Rut.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Nombre.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Nombre.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Telefono.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Telefono.Focus()
            Return
        End If

        If String.IsNullOrEmpty(Txt_Email.Text.Trim) Then
            MessageBoxEx.Show(Me, "Falta el Email", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Email.Focus()
            Return
        End If

        If Not Fx_Validar_Email(Txt_Email.Text.Trim) Then
            MessageBoxEx.Show(Me, "Email no válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Email.Focus()
            Return
        End If

        With Cl_Contador.Zw_Inv_Contador

            .Rut = Txt_Rut.Text.Trim
            .Nombre = Txt_Nombre.Text.Trim
            .Telefono = Txt_Telefono.Text.Trim
            .Email = Txt_Email.Text.Trim
            .Activo = Chk_Activo.Checked

        End With

        Dim _mensaje As New LsValiciones.Mensajes

        If CBool(_IdContador) Then
            _mensaje = Cl_Contador.Fx_Actualizar_Contador(Cl_Contador.Zw_Inv_Contador)
        Else
            _mensaje = Cl_Contador.Fx_Crear_Contador(Cl_Contador.Zw_Inv_Contador)
        End If

        MessageBoxEx.Show(Me, _mensaje.Mensaje, _mensaje.Detalle, MessageBoxButtons.OK, _mensaje.Icono)

        If Not _mensaje.EsCorrecto Then
            Return
        End If

        Grabar = True
        Me.Close()

    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

        If MessageBoxEx.Show(Me, "¿Esta seguro de querer eliminar este contador?", "Eliminar contador",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje = Cl_Contador.Fx_Eliminar_Contador(Cl_Contador.Zw_Inv_Contador)

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If Not _Mensaje.EsCorrecto Then
            Return
        End If

        Eliminado = True
        Me.Close()

    End Sub


End Class
