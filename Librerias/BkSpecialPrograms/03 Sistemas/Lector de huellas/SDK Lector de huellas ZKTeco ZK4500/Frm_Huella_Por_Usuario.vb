Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls

Public Class Frm_Huella_Por_Usuario

    Dim Consulta_Sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _RowFuncionario As DataRow

    Public Property Pro_RowFuncionario As DataRow
        Get
            Return _RowFuncionario
        End Get
        Set(value As DataRow)
            _RowFuncionario = value
        End Set
    End Property

    Public Sub New(CodFuncionario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_Sql = "Select * From TABFU Where KOFU = '" & CodFuncionario & "'"
        _RowFuncionario = _Sql.Fx_Get_DataRow(Consulta_Sql)

    End Sub

    Private Sub Frm_Huella_Por_Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Funcionario.Tag = _RowFuncionario.Item("KOFU")
        Lbl_Funcionario.Text = _RowFuncionario.Item("KOFU") & " - " & _RowFuncionario.Item("NOKOFU")

        Dim _Existe_Huella_1 As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Huellas",
                                                                         "CodFuncionario = '" & Lbl_Funcionario.Tag & "' And Nro_Huella = 1"))
        Dim _Existe_Huella_2 As Boolean = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Usuarios_Huellas",
                                                                         "CodFuncionario = '" & Lbl_Funcionario.Tag & "' And Nro_Huella = 2"))

        Sb_Warning(Warning_H1, _Existe_Huella_1)
        Sb_Warning(Warning_H2, _Existe_Huella_2)

    End Sub

    Sub Sb_Warning(_Warning As WarningBox,
                   _Tiene_Huella As Boolean)

        Dim _Funcionarios = String.Empty
        Dim _Titulo1 = String.Empty
        Dim _Titulo2 = String.Empty
        Dim _Titulo3 = String.Empty
        Dim _Imagen As Image

        Dim _Hay_Funcionarios = False

        RemoveHandler _Warning.OptionsClick, AddressOf Warning_OptionsClick_Registrar
        RemoveHandler _Warning.OptionsClick, AddressOf Warning_OptionsClick_Eliminar

        If _Tiene_Huella Then

            _Imagen = Imagenes_16x16.Images.Item("ok.png")
            _Titulo1 = "Existe Huella"
            _Titulo2 = "Huella N°" & _Warning.Tag
            _Titulo3 = "OK"
            _Funcionarios = String.Empty
            _Warning.OptionsButtonVisible = True
            _Warning.OptionsText = "Eliminar huella"


            AddHandler _Warning.OptionsClick, AddressOf Warning_OptionsClick_Eliminar

        Else

            _Imagen = Imagenes_16x16.Images.Item("warning.png")
            _Titulo1 = "No Existe Huella"
            _Titulo2 = "Huella N°" & _Warning.Tag
            _Titulo3 = "espacio disponible"
            _Funcionarios = String.Empty
            _Warning.OptionsButtonVisible = True
            _Warning.OptionsText = "Cargar huella"


            AddHandler _Warning.OptionsClick, AddressOf Warning_OptionsClick_Registrar

        End If

        _Warning.Image = _Imagen 'Imagenes_16x16.Images.Item("ok.png")
        _Warning.Text = "<b>" & Space(3) & _Titulo1 & "</b>" & Space(3) & _Titulo2 & Space(1) & "<i>" & _Titulo3 & "</i>"
        _Warning.Enabled = True

    End Sub

    Private Sub Warning_OptionsClick_Registrar(sender As Object, e As EventArgs) 'Handles Warning_H1.OptionsClick
        Sb_Warning(sender, Fx_Registrar_Huella(CType(sender, WarningBox).Tag))
    End Sub

    Private Sub Warning_OptionsClick_Eliminar(sender As Object, e As EventArgs) 'Handles Warning_H1.OptionsClick
        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Huellas 
                        Where CodFuncionario = '" & Lbl_Funcionario.Tag & "' And Nro_Huella = " & CType(sender, WarningBox).Tag
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Warning(sender, False)
        End If
    End Sub

    Function Fx_Registrar_Huella(_Nro_Huella As Integer) As Boolean

        Dim _Huella As String

        Dim Fm As New Frm_Huella_Identificar(Me, _Huella, False, False, Frm_Huella_Identificar.Enum_Accion.Registrar)
        Fm.Btn_Grabar_Sin_Lector.Visible = False
        If Fm.Pro_Conectado Then Fm.ShowDialog(Me)
        Dim _Registrado As Boolean = Fm.Pro_Registrado
        If _Registrado Then _Huella = Fm.Pro_Huella
        Fm.Dispose()

        If _Registrado Then

            Dim Fm_V As New Frm_Huella_Identificar(Me, "", False, False, Frm_Huella_Identificar.Enum_Accion.Buscar_Huella)
            Fm_V.Sb_Conectar_Sensor()
            Dim _Row = Fm_V.Fx_Existe_Huella_Row(_Huella)
            Fm_V.Dispose()

            If Not IsNothing(_Row) Then

                MessageBox.Show(Me, "Esta huella ya esta registrada para el usuario:" & vbCrLf &
                                Trim(_Row.Item("KOFU")) & " - " & _Row.Item("NOKOFU") & vbCrLf &
                                "No puede registrar 2 veces la misma huella en el sistema", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Registrado = False
            Else

                Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Usuarios_Huellas 
                                Where CodFuncionario = '" & Lbl_Funcionario.Tag & "' And Nro_Huella = " & _Nro_Huella & vbCrLf & vbCrLf &
                                "Insert Into " & _Global_BaseBk & "Zw_Usuarios_Huellas (CodFuncionario,Huella,Nro_Huella,Zk4500) 
                                Values ('" & Lbl_Funcionario.Tag & "','" & _Huella & "'," & _Nro_Huella & ",1)"
                _Registrado = _Sql.Ej_consulta_IDU(Consulta_Sql)

                If _Registrado Then MessageBox.Show(Me, "Huella registrada correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

        Return _Registrado

    End Function

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

End Class
