Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls


Public Class Frm_Formulario_Cantidad_Stock_X_Bodega

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Producto As DataRow
    Dim _Row_Bodega As DataRow
    Dim _Aceptar As Boolean
    Dim _Cantidad As Double
    Dim _Stock_Insuficiente As Boolean
    Dim _Es_Venta As Boolean
    Dim _Sucursal As String
    Dim _Tido As String

    Dim _Mostrar_Stock_Fisico As Boolean = Not Fx_Tiene_Permiso("NO00004", FUNCIONARIO)
    Dim _Mostrar_Stock_Comprometido As Boolean = Not Fx_Tiene_Permiso("NO00005", FUNCIONARIO)
    Dim _Mostrar_Stock_Devengado As Boolean = Not Fx_Tiene_Permiso("NO00006", FUNCIONARIO)
    Dim _Mostrar_Stock_Pedido As Boolean = Not Fx_Tiene_Permiso("NO00007", FUNCIONARIO)
    Dim _Mostrar_Stock_Disponible As Boolean = Not Fx_Tiene_Permiso("NO00008", FUNCIONARIO)
    Public Property Row_Bodega As DataRow
        Get
            Return _Row_Bodega
        End Get
        Set(value As DataRow)
            _Row_Bodega = value
        End Set
    End Property

    Public Property Aceptar As Boolean
        Get
            Return _Aceptar
        End Get
        Set(value As Boolean)
            _Aceptar = value
        End Set
    End Property

    Public Property Stock_Insuficiente As Boolean
        Get
            Return _Stock_Insuficiente
        End Get
        Set(value As Boolean)
            _Stock_Insuficiente = value
        End Set
    End Property

    Public Property Es_Venta As Boolean
        Get
            Return _Es_Venta
        End Get
        Set(value As Boolean)
            _Es_Venta = value
        End Set
    End Property

    Public Sub New(Codigo As String, Cantidad As Double, Sucursal As String, Es_Venta As Boolean, Tido As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Es_Venta = Es_Venta
        _Sucursal = Sucursal
        _Tido = Tido

        Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & Codigo & "'"
        _Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)
        _Cantidad = Cantidad

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        Chk_Ver_Todas_Las_Bodegas.Visible = Not _Es_Venta

        If Not _Mostrar_Stock_Disponible Then Me.Width -= 85
        If Not _Mostrar_Stock_Comprometido Then Me.Width -= 65
        If Not _Mostrar_Stock_Devengado Then Me.Width -= 65
        If Not _Mostrar_Stock_Fisico Then Me.Width -= 65
        If Not _Mostrar_Stock_Pedido Then Me.Width -= 65

    End Sub

    Private Sub Frm_Formulario_Cantidad_Stock_X_Bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Producto: " & _Row_Producto.Item("KOPR").ToString.Trim & ", " & _Row_Producto.Item("NOKOPR").ToString.Trim
        Dim _Decimales = 0

        If _Row_Producto.Item("RLUD") = 1 Then
            Rdb_Unidad_2.Enabled = False
        Else
            _Decimales = 2
        End If

        Lbl_Cantidad.Text = "CANTIDAD EN DOC.: " & FormatNumber(_Cantidad, _Decimales)

        Sb_Actualizar_Grilla()

        AddHandler Rdb_Unidad_1.CheckedChanged, AddressOf Rdb_CheckedChanged
        AddHandler Rdb_Unidad_2.CheckedChanged, AddressOf Rdb_CheckedChanged

        AddHandler Chk_Ver_Todas_Las_Bodegas.CheckedChanged, AddressOf Sb_Actualizar_Grilla

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim _Filtro_Productos As String

        Dim _Codigo = _Row_Producto.Item("KOPR")

        _Filtro_Productos = "('" & _Codigo & "')"

        Dim _Ud As Integer

        If Rdb_Unidad_1.Checked Then
            _Ud = 1
        Else
            _Ud = 2
        End If

        If _Es_Venta Then

            Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* 
                            From TABBO
                            Where (EMPRESA+KOSU+KOBO
                            In (Select SUBSTRING(CodPermiso, 3, 10)
                            From " & _Global_BaseBk & "ZW_PermisosVsUsuarios
                            Where CodUsuario = '" & FUNCIONARIO & "' And CodPermiso In (Select CodPermiso From " & _Global_BaseBk & "ZW_Permisos Where CodFamilia = 'Bodega'))
                            Or (EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "' And KOBO = '" & ModBodega & "')) And 
                            (EMPRESA+KOSU+KOBO In (Select EMPRESA+KOSU+KOBO From TABBOPR Where KOPR = '" & _Codigo & "'))"

        Else

            If Chk_Ver_Todas_Las_Bodegas.Checked Then

                Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* 
                            From TABBO
                            Where EMPRESA = '" & ModEmpresa & "' And EMPRESA+KOSU+KOBO In (Select EMPRESA+KOSU+KOBO From TABBOPR Where KOPR = '" & _Codigo & "')"

            Else

                Consulta_sql = "Select Distinct EMPRESA+KOSU+KOBO As Cod,* 
                                From TABBO
                                Where EMPRESA = '" & ModEmpresa & "' And KOSU = '" & _Sucursal & "' 
                                And EMPRESA+KOSU+KOBO In (Select EMPRESA+KOSU+KOBO From TABBOPR Where KOPR = '" & _Codigo & "')"

            End If

        End If



        Dim _Tbl_Bodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Bodegas, "", "Cod", False, False, "'")

        _Filtro = "And Empresa+Sucursal+Bodega In " & _Filtro
        Dim _Orden_Bod = "ORDEN_BOD_" & ModEmpresa.Trim & ModSucursal.Trim

        Consulta_sql = My.Resources.Recursos_Cant_Stock_Bodega.Stock_productos_por_emp_suc_bod
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Codigos#", _Filtro_Productos)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Ud)
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _Filtro)
        Consulta_sql = Replace(Consulta_sql, "#Tabla#", _Orden_Bod)
        Consulta_sql = Replace(Consulta_sql, "#Global_BaseBk#", _Global_BaseBk)

        Dim _DisplayIndex = 0

        With Grilla

            .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("SUC_BOD").Visible = True
            .Columns("SUC_BOD").HeaderText = "Suc-Bod"
            .Columns("SUC_BOD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SUC_BOD").Width = 80
            .Columns("SUC_BOD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOBO").Visible = True
            .Columns("NOKOBO").HeaderText = "Bodega"
            .Columns("NOKOBO").Width = 200
            .Columns("NOKOBO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_DISPONIBLE").Visible = _Mostrar_Stock_Disponible
            .Columns("ST_DISPONIBLE").HeaderText = "Disponible"
            .Columns("ST_DISPONIBLE").Width = 85
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DISPONIBLE").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_DISPONIBLE").ToolTipText = "Stock disponible teóricamente Ud" & _Ud & " (Stock físico-comprometido)"
            .Columns("ST_DISPONIBLE").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_COMPROMETIDO").Visible = _Mostrar_Stock_Comprometido
            .Columns("ST_COMPROMETIDO").HeaderText = "Compr.RD"
            .Columns("ST_COMPROMETIDO").Width = 65
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_COMPROMETIDO").ToolTipText = "Stock comprometido Ud" & _Ud & " (NVV)"
            .Columns("ST_COMPROMETIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_COMPROMETIDO_BK").Visible = _Mostrar_Stock_Comprometido
            .Columns("ST_COMPROMETIDO_BK").HeaderText = "Comp.BK"
            .Columns("ST_COMPROMETIDO_BK").Width = 65
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_COMPROMETIDO_BK").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_COMPROMETIDO_BK").ToolTipText = "Stock comprometido Ud" & _Ud & " (NVV - Pendientes de permisos remotos)"
            .Columns("ST_COMPROMETIDO_BK").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_DEVENGADO").Visible = _Mostrar_Stock_Devengado
            .Columns("ST_DEVENGADO").HeaderText = "Ven.N/Entr."
            .Columns("ST_DEVENGADO").Width = 65
            .Columns("ST_DEVENGADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_DEVENGADO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_DEVENGADO").ToolTipText = "Ventas no despachadas (Devengados)"
            .Columns("ST_DEVENGADO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_FISICO").Visible = _Mostrar_Stock_Fisico
            .Columns("ST_FISICO").HeaderText = "Físico"
            .Columns("ST_FISICO").Width = 65
            .Columns("ST_FISICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_FISICO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_FISICO").ToolTipText = "Stock Ud" & _Ud
            .Columns("ST_FISICO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ST_PEDIDO").Visible = _Mostrar_Stock_Pedido
            .Columns("ST_PEDIDO").HeaderText = "Pedido"
            .Columns("ST_PEDIDO").Width = 65
            .Columns("ST_PEDIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("ST_PEDIDO").DefaultCellStyle.Format = "##,###0.##"
            .Columns("ST_PEDIDO").ToolTipText = "Stock Pedido OCC"
            .Columns("ST_PEDIDO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        For Each _Fila As DataGridViewRow In Grilla.Rows

            Dim _Suc_Bod = Trim(_Fila.Cells("SUC_BOD").Value)
            Dim _St_Fisico = _Fila.Cells("ST_FISICO").Value
            Dim _St_Disponible = _Fila.Cells("ST_DISPONIBLE").Value

            Dim _Sucursal = _Fila.Cells("Sucursal").Value
            Dim _Bodega = _Fila.Cells("Bodega").Value

            If Not String.IsNullOrEmpty(_Tido) Then
                _St_Disponible = Fx_Stock_Disponible(_Tido, ModEmpresa, _Sucursal, _Bodega, _Codigo, _Ud, "STFI" & _Ud)
                If _St_Disponible < 0 Then _St_Disponible = 0
                _Fila.Cells("ST_DISPONIBLE").Value = _St_Disponible
            End If

            If String.IsNullOrEmpty(_Suc_Bod) Then

                _Fila.Visible = _Es_Venta

                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                    _Fila.DefaultCellStyle.ForeColor = Color.Gold
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.Gold
                End If

            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.DefaultCellStyle.BackColor = Color.Black
                Else
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If
            End If

            If _St_Fisico < 0 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("ST_FISICO").Style.ForeColor = Color.FromArgb(221, 80, 68)
                Else
                    _Fila.Cells("ST_FISICO").Style.ForeColor = Color.Red
                End If
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("ST_FISICO").Style.ForeColor = Color.LightGreen
                Else
                    _Fila.Cells("ST_FISICO").Style.ForeColor = Color.Blue
                End If
            End If

            If _St_Disponible <= 0 Then
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("ST_DISPONIBLE").Style.ForeColor = Color.FromArgb(221, 80, 68)
                Else
                    _Fila.Cells("ST_DISPONIBLE").Style.ForeColor = Color.Red
                End If
            Else
                If Global_Thema = Enum_Themas.Oscuro Then
                    _Fila.Cells("ST_DISPONIBLE").Style.ForeColor = Color.LightGreen
                Else
                    _Fila.Cells("ST_DISPONIBLE").Style.ForeColor = Color.Blue
                End If
            End If

        Next

        Grilla.CurrentCell = Grilla.Rows(0).Cells("ST_DISPONIBLE")

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Empresa = _Fila.Cells("Empresa").Value
        Dim _Sucursal = _Fila.Cells("Sucursal").Value
        Dim _Bodega = _Fila.Cells("Bodega").Value
        Dim _Nokobo = _Fila.Cells("NOKOBO").Value
        Dim _St_Disponible As Double = _Fila.Cells("ST_DISPONIBLE").Value

        If Not String.IsNullOrEmpty(Trim(_Sucursal) + Trim(_Bodega)) Then

            If _St_Disponible < _Cantidad And _Es_Venta Then

                If MessageBoxEx.Show(Me, "Stock insuficiente en bodega: " & _Nokobo & vbCr & vbCrLf &
                                  "Stock disponible: " & FormatNumber(_St_Disponible, 0) & vbCrLf & vbCrLf &
                                  "¿Desea asignar de todas formas esta bodega?",
                                  "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                                  MessageBoxDefaultButton.Button1, True) = DialogResult.Yes Then

                    _Stock_Insuficiente = True
                    _Aceptar = True

                End If

            Else

                Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega
                _Aceptar = Fx_Tiene_Permiso(Me, _Permiso, , True)

            End If

        Else
            Beep()
        End If

        If _Aceptar Then
            Consulta_sql = "Select * From TABBO Where EMPRESA = '" & _Empresa & "' And KOSU = '" & _Sucursal & "' And KOBO = '" & _Bodega & "'"
            _Row_Bodega = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()
        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Try
            Dim _Codigo = Trim(Grilla.Rows(Grilla.CurrentRow.Index).Cells("Codigo").Value)

            If e.KeyValue = Keys.Enter Then
                SendKeys.Send("{F2}")
                e.Handled = True
                Call Grilla_CellDoubleClick(Nothing, Nothing)
            End If
        Catch ex As Exception
            Beep()
        End Try

    End Sub

    Private Sub Frm_Formulario_Cantidad_Stock_X_Bodega_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub Rdb_CheckedChanged(sender As Object, e As EventArgs)

        If CType(sender, CheckBoxX).Checked Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

End Class
