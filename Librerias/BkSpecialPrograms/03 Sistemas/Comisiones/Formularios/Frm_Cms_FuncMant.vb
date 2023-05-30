Public Class Frm_Cms_FuncMant

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _Id As Integer
    Dim _Row_Funcionario As DataRow
    Dim _Tbl_MisComisiones As DataTable

    Public Property Grabar As Boolean

    Public Property Row_Funcionario As DataRow
        Get
            Return _Row_Funcionario
        End Get
        Set(value As DataRow)
            _Row_Funcionario = value
        End Set
    End Property

    Public Sub New(_Id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id = _Id

    End Sub

    Private Sub Frm_Cms_FuncMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not CBool(_Id) Then
            Me.Height = 212
            Btn_Eliminar.Visible = False
            Btn_AgregarComision.Visible = False
        End If

        Txt_Funcionario.Text = _Row_Funcionario.Item("KOFU").ToString.Trim & " - " & _Row_Funcionario.Item("NOKOFU").ToString.Trim
        Txt_AFP.Text = _Row_Funcionario.Item("AFP")
        Txt_Salud.Text = _Row_Funcionario.Item("Salud")
        Chk_Habilitado.Checked = _Row_Funcionario.Item("Habilitado")

    End Sub


    Sub Sb_Actualizar_Grilla()

        Consulta_Sql = "Select *,Case" & vbCrLf &
                       "When MisVentas = 1 Then 'Mis ventas'" & vbCrLf &
                       "When VentasXEmpresa = 1 Then 'Ventas por empresa'" & vbCrLf &
                       "When VentasXSucursal = 1 Then 'Ventas por sucursales...'+XSucursales" & vbCrLf &
                       "When VentasXVendedores = 1 Then 'Ventas por vendedores: '+XVendedores" & vbCrLf &
                       "End As Resumen, From " & _Global_BaseBk & "Zw_Comisiones_Mis" & vbCrLf &
                       "Where CodFuncionario = '" & _Row_Funcionario.Item("KOFU") & "'"
        _Tbl_MisComisiones = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Tbl_MisComisiones

            .Columns("Descripcion").Width = 150
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").ReadOnly = False
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PorcComision").Width = 50
            .Columns("PorcComision").HeaderText = "% CM"
            .Columns("PorcComision").ToolTipText = "Porcenta de comisión"
            .Columns("PorcComision").Visible = True
            .Columns("PorcComision").ReadOnly = False
            .Columns("PorcComision").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Resumen").Width = 200
            .Columns("Resumen").HeaderText = "Resumen"
            .Columns("Resumen").Visible = True
            .Columns("Resumen").ReadOnly = False
            .Columns("Resumen").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Comisiones_Fun Set" &
                       " AFP = " & Txt_AFP.Text &
                       ",Salud = " & Txt_Salud.Text &
                       ",Habilidado = 0" & vbCrLf &
                       "Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Grabar = True
            Me.Close()
        End If

    End Sub

    Private Sub Btn_AgregarComision_Click(sender As Object, e As EventArgs) Handles Btn_AgregarComision.Click

        Dim Fm As New Frm_Cms_AgregarTipos(0, _Row_Funcionario.Item("KOFU"))
        Fm.ShowDialog(Me)
        If Fm.Grabar Then
            Sb_Actualizar_Grilla()
        End If
        Fm.Dispose()

    End Sub

    Private Sub Txt_AFP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_AFP.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

    Private Sub Txt_Salud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Salud.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii, False))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        End If
    End Sub

End Class
