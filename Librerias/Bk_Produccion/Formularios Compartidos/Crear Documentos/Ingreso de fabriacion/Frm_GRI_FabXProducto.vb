Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_GRI_FabXProducto

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Pote As DataRow
    Dim _Row_Potl As DataRow

    Dim _FechaDelServidor As Date

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _FechaDelServidor = FechaDelServidor()

    End Sub

    Private Sub Frm_GRI_FabXProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Txt_Cantidad.KeyPress, AddressOf Sb_Txt_KeyPress_Solo_Numeros_Enteros
        AddHandler Txt_Cantidad.Validated, AddressOf Sb_Txt_Nros_Validated
        AddHandler Txt_Cantidad.Enter, AddressOf Sb_Txt_Nros_Enter

        ActiveControl = Txt_Numot
        Sb_Limpiar()

    End Sub

    Private Sub Txt_Numot_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Numot.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_BuscarOt(Txt_Numot.Text)
        End If
    End Sub

    Sub Sb_BuscarOt(ByRef _Numot As String)

        If Not String.IsNullOrEmpty(_Numot) Then

            Dim _Nudo As String = Fx_Rellena_ceros(_Numot, 10)
            Dim _Nro As String

            _Nro = Replace(_Nudo, "-", ",")

            Dim _Cadena = Split(_Nro, ",")

            If _Cadena.Length = 2 Then
                _Nudo = Fx_Rellena_ceros(_Cadena(1), 10)
            Else
                _Numot = _Nudo
            End If

            Consulta_sql = "Select * From POTE Where NUMOT = '" & _Numot & "'"
            _Row_Pote = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Pote) Then
                MessageBoxEx.Show(Me, "No existe la OT Nro: " & _Numot, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                _Numot = String.Empty
                Return
            End If

            Txt_Numot.ReadOnly = True

            Lbl_ReferenciaOT.Text = "REFERENCIA: " & _Row_Pote.Item("REFERENCIA")

            Sb_BuscarProductos(_Numot)

        End If

    End Sub

    Sub Sb_BuscarProductos(_Numot As String)

        Consulta_sql = "Select * From POTL" & vbCrLf &
               "Where NUMOT='" & _Numot & "' And EMPRESA = '" & ModEmpresa & "' And LILG <> 'IM' " &
               "And Exists (Select TABBOPR.* From TABBOPR " &
               "Where TABBOPR.KOPR = POTL.CODIGO And TABBOPR.KOSU = '" & ModSucursal & "' AND TABBOPR.KOBO = '" & ModBodega & "' ) "

        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim Fm As New Frm_GRI_ProductosOT
        Fm.Tbl_Productos = _Tbl_Productos
        Fm.ShowDialog(Me)
        _Row_Potl = Fm.FilaSeleccionada
        Fm.Dispose()

        If IsNothing(_Row_Potl) Then
            If String.IsNullOrEmpty(Txt_Codigo.Text) Then
                MessageBoxEx.Show(Me, "Debe seleccionar algun producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Txt_Cantidad.Focus()
            End If
            Return
        End If

        Txt_Cantidad.Text = String.Empty
        Txt_Cantidad.Tag = 0

        Grupo_Producto.Enabled = True
        Txt_Codigo.ButtonCustom.Enabled = True
        Txt_Codigo.Text = _Row_Potl.Item("CODIGO")
        Txt_Descripcion.Text = _Row_Potl.Item("GLOSA")

        Txt_Cantidad.Enabled = True
        Txt_Cantidad.Focus()

    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Sb_Limpiar()
    End Sub

    Sub Sb_Limpiar()
        Dtp_Fecha_Ingreso.Value = _FechaDelServidor
        Txt_Numot.Text = String.Empty
        Txt_Numot.ReadOnly = False
        Grupo_Producto.Enabled = False
        Txt_Codigo.Text = String.Empty
        Txt_Codigo.ButtonCustom.Enabled = False
        Txt_Descripcion.Text = String.Empty
        Lbl_ReferenciaOT.Text = "REFERENCIA:"
        Txt_Cantidad.Enabled = False
        Txt_Cantidad.Text = String.Empty
        Txt_Cantidad.Tag = 0
        Btn_Grabar.Enabled = False
        Txt_Numot.Focus()
        Me.Refresh()
    End Sub

    Private Sub Txt_Codigo_ButtonCustomClick(sender As Object, e As EventArgs) Handles Txt_Codigo.ButtonCustomClick
        Sb_BuscarProductos(Txt_Numot.Text)
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click
        MessageBoxEx.Show(Me, "Cantidad: " & Txt_Cantidad.Tag, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub Sb_Txt_Nros_Validated(sender As Object, e As EventArgs)
        Btn_Grabar.Enabled = True
        CType(sender, Controls.TextBoxX).Tag = Val(CType(sender, Controls.TextBoxX).Text)
        CType(sender, Controls.TextBoxX).Text = FormatNumber(CType(sender, Controls.TextBoxX).Tag, 0)
    End Sub
    Private Sub Sb_Txt_Nros_Enter(sender As Object, e As EventArgs)
        CType(sender, Controls.TextBoxX).Text = CType(sender, Controls.TextBoxX).Tag
        Btn_Grabar.Enabled = False
    End Sub

    Private Sub Txt_Cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then ' Comprueba si se presionó la tecla ENTER
            e.Handled = True ' Evita que el ENTER se refleje en el TextBox
            Me.SelectNextControl(ActiveControl, True, True, True, True) ' Salta al siguiente control
        End If
    End Sub
End Class
