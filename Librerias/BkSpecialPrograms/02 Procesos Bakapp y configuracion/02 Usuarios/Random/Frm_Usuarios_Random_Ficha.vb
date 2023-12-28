Imports DevComponents.DotNetBar


Public Class Frm_Usuarios_Random_Ficha

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Kofu As String

    Dim _Pais As String
    Dim _Ciudad As String
    Dim _Comuna As String

    Dim _Grabar As Boolean
    Dim _Accion As Enum_Accion

    Enum Enum_Accion
        Crear
        Editar
    End Enum

    Public Property Grabar As Boolean
        Get
            Return _Grabar
        End Get
        Set(value As Boolean)
            _Grabar = value
        End Set
    End Property

    Public Sub New(_Accion As Enum_Accion, _Kofu As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Accion = _Accion
        Me._Kofu = _Kofu

    End Sub

    Private Sub Btn_Grabar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Grabar.Click

        If String.IsNullOrEmpty(Trim(Txt_Nombre.Text)) Then
            MessageBoxEx.Show(Me, "Nombre no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        'If String.IsNullOrEmpty(Trim(Txt_Direccion.Text)) Then
        '    MessageBoxEx.Show(Me, "Email no puede estar vacio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        If _Accion = Enum_Accion.Editar Then
            EditarFuncionario()
        ElseIf _Accion = Enum_Accion.Crear Then
            CrearFuncionario()
            MsgBox("Funcionario Creado Exitosamente")
        End If

    End Sub

    Private Sub Frm_Usuarios_Ficha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If _Accion = Enum_Accion.Editar Then

            Txt_Codigo.Enabled = False
            Btn_Eliminar.Visible = True
            Txt_Codigo.Text = _Kofu
            LlenarInfoFuncionario(_Kofu)

        ElseIf _Accion = Enum_Accion.Crear Then

            Btn_Eliminar.Visible = False

        End If

    End Sub


    Private Sub CrearFuncionario()

        Dim _Rut As String = Txt_Rut.Text
        Dim _Codigo As String = Txt_Codigo.Text
        Dim _Nombre As String = Txt_Nombre.Text
        Dim _Direccion As String = Txt_Direccion.Text
        Dim _Ciudad As String = Me._Ciudad
        Dim _Comuna As String = Me._Comuna
        Dim _Telefono As String = Txt_Telefono.Text
        Dim _Email As String = Txt_Email.Text
        Dim _EmailSup As String = Txt_EmailSup.Text
        Dim _Modalidad As String = Cmb_Mod.Text
        Dim _CodigoExt As String = Txt_Cod_Ext.Text
        Dim _Password As String = TraeClaveRD(Txt_Password.Text)

        Dim Reg As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABFU", "KOFU = '" & _Codigo & "'"))

        If Reg Then
            MessageBoxEx.Show(Me, "El código del usuario ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_sql = "Insert Into TABFU (KOFU,NOKOFU,RTFU,DIFU,CIFU,CMFU,PLANO,MODALIDAD,INACTIVO,PARAFIRMA,EMAIL,EMAILSUP,CODEXTERN,FOFU,PWFU)" & vbCrLf &
                        "Values ('" & _Codigo & "','" & _Nombre & "','" & _Rut & "','" & _Direccion & "','" & _Ciudad & "','" & _Comuna & "'," &
                        "'SINFOTOF','" & _Modalidad & "',0,'F','" & _Email & "','" & _EmailSup & "','" & _CodigoExt & "','" & _Telefono & "','" & _Password & "')"

        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub EditarFuncionario()

        Dim Rut As String = Txt_Rut.Text
        Dim Codigo As String = Txt_Codigo.Text
        Dim Nombre As String = Txt_Nombre.Text
        Dim Direccion As String = Txt_Direccion.Text
        Dim Ciudad As String = _Ciudad
        Dim Comuna As String = _Comuna
        Dim Telefono As String = Txt_Telefono.Text
        Dim Email As String = Txt_Email.Text
        Dim EmailSup As String = Txt_EmailSup.Text
        Dim Modalidad As String = Cmb_Mod.Text
        Dim CodigoExt As String = Txt_Cod_Ext.Text
        Dim PassWord As String = TraeClaveRD(Txt_Password.Text)

        If Not Fx_Validar_Email(Email) Then
            MessageBoxEx.Show(Me, "Email incorrecto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Txt_Email.Focus()
            Return
        End If

        Dim Consulta As String = "Update TABFU Set " & vbCrLf &
                                 "NOKOFU='" & Nombre & "'" &
                                 ",RTFU='" & Rut & "'" &
                                 ",DIFU='" & Direccion & "'" &
                                 ",CIFU='" & Ciudad & "'" &
                                 ",CMFU='" & Comuna & "'" &
                                 ",PLANO='SINFOTOF'" &
                                 ",MODALIDAD='" & Modalidad & "'" &
                                 ",INACTIVO=0" &
                                 ",PARAFIRMA='F'" &
                                 ",EMAIL='" & Email & "'" &
                                 ",EMAILSUP='" & EmailSup & "'" &
                                 ",CODEXTERN='" & CodigoExt & "'" &
                                 ",FOFU='" & Telefono & "'" &
                                 ",PWFU='" & PassWord & "'" & vbCrLf &
                                 "Where KOFU='" & Codigo & "'"
        If _Sql.Ej_consulta_IDU(Consulta) Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub LlenarInfoFuncionario(Codigo As String)

        Consulta_sql = "Select NOKOFU,RTFU,DIFU,CIFU,CMFU,MODALIDAD,EMAIL,EMAILSUP,CODEXTERN,FOFU,PWFU " & vbCrLf &
                                 "From TABFU Where KOFU='" & Codigo & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Txt_Nombre.Text = _Row.Item("NOKOFU")
        Txt_Rut.Text = _Row.Item("RTFU")
        Txt_Direccion.Text = _Row.Item("DIFU")
        _Ciudad = _Row.Item("CIFU")
        _Comuna = _Row.Item("CMFU")
        Cmb_Mod.Text = _Row.Item("MODALIDAD")
        Txt_Email.Text = _Row.Item("EMAIL")
        Txt_EmailSup.Text = _Row.Item("EMAILSUP")
        Txt_Cod_Ext.Text = _Row.Item("CODEXTERN")
        Txt_Telefono.Text = _Row.Item("FOFU")
        Txt_Password.Text = DecryptClaveRD(_Row.Item("PWFU"))

    End Sub
    Private Sub Btn_Eliminar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Eliminar.Click

        Dim Codigo As String = Txt_Codigo.Text
        Consulta_sql = "UPDATE TABFU SET INACTIVO=1 WHERE KOFU='" & Codigo & "'"
        _Sql.Fx_Ejecutar_Consulta(Consulta_sql)
        MsgBox("Funcionario Eliminado")

    End Sub

    Private Sub Frm_Usuarios_Bk_Ficha_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Buscar_Comuna_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Comuna.Click

        Dim Fm As New Frm_PaCiCm_Lista
        Fm.ShowDialog(Me)

        If Not IsNothing(Fm.Row_Localidad) Then

            _Pais = Fm.Row_Localidad.Item("KOPA")
            _Ciudad = Fm.Row_Localidad.Item("KOCI")
            _Comuna = Fm.Row_Localidad.Item("KOCM")

            Dim _NPais = Fm.Row_Localidad.Item("NOKOPA")
            Dim _NCiudad = Fm.Row_Localidad.Item("NOKOCI")
            Dim _NComuna = Fm.Row_Localidad.Item("NOKOCM")

            Txt_Comuna.Text = _NComuna.Trim & ", " & _NCiudad.Trim & " - " & _NPais

        End If

        Fm.Dispose()

    End Sub


End Class
