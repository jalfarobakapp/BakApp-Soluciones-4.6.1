Public Class Frm_St_Operaciones

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Operaciones As DataTable
    Dim _Row_Operacion As DataRow

    Public Property ModoSeleccion As Boolean

    Public Property Row_Operacion As DataRow
        Get
            Return _Row_Operacion
        End Get
        Set(value As DataRow)
            _Row_Operacion = value
        End Set
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_St_Operaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_MouseDown

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Txt_Buscador

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "Operacion+Descripcion Like '%")

        'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
        '               "Where Empresa = '" & Mod_Empresa & "' And Sucursal = '" & Mod_Sucursal & "' And Operacion+Descripcion Like '%" & _Cadena & "%'"

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones" & vbCrLf &
                       "Where Empresa = '" & Mod_Empresa & "' And Operacion+Descripcion Like '%" & _Cadena & "%'"
        _Tbl_Operaciones = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Operaciones

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Operacion").Visible = True
            .Columns("Operacion").HeaderText = "Código"
            .Columns("Operacion").Width = 80
            .Columns("Operacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Descripcion").Visible = True
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("Descripcion").Width = 390
            .Columns("Descripcion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantMayor1").Visible = True
            .Columns("CantMayor1").HeaderText = "M1"
            .Columns("CantMayor1").ToolTipText = "La Cantidad puede ser mayor que 1"
            .Columns("CantMayor1").Width = 30
            .Columns("CantMayor1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Externa").Visible = True
            .Columns("Externa").HeaderText = "Ext."
            .Columns("Externa").ToolTipText = "Operación externa"
            .Columns("Externa").Width = 40
            .Columns("Externa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("TienePrecio").Visible = True
            '.Columns("TienePrecio").HeaderText = "T.Precio"
            '.Columns("TienePrecio").ToolTipText = "Indica si la operación tiene precio de venta"
            '.Columns("TienePrecio").Width = 50
            '.Columns("TienePrecio").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            '.Columns("Activo").Visible = True
            '.Columns("Activo").HeaderText = "Activa"
            '.Columns("Activo").Width = 50
            '.Columns("Activo").DisplayIndex = 2
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        Txt_Buscador.Focus()

    End Sub

    Private Sub Btn_Crear_Operacion_Click(sender As Object, e As EventArgs) Handles Btn_Crear_Operacion.Click

        If Not Fx_Tiene_Permiso(Me, "Stec0022") Then
            Return
        End If

        Dim _Grabar As Boolean

        Dim Fm As New Frm_St_OperacionesCrear("")
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value

        If ModoSeleccion Then

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_St_OT_Operaciones Where Operacion = '" & _Operacion & "'"

            Consulta_sql = "Select Ope.*,ISNULL(Pre.Costo,0) As Costo,ISNULL(Pre.Precio,0) As Precio" & vbCrLf &
                           "From " & _Global_BaseBk & "Zw_St_OT_Operaciones Ope" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_St_OT_Operaciones_Precios Pre On Pre.Id_Ope = Ope.Id And " &
                           "Pre.Empresa = '" & Mod_Empresa & "' And Pre.Sucursal = '" & Mod_Sucursal & "'" & vbCrLf &
                           "Where Ope.Operacion = '" & _Operacion & "'"
            _Row_Operacion = _Sql.Fx_Get_DataRow(Consulta_sql)
            Me.Close()

        Else

            Call Btn_Mnu_Editar_Operacion_Click(Nothing, Nothing)

        End If

    End Sub

    Private Sub Sb_Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_Editar_Operacion_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Editar_Operacion.Click

        If Not Fx_Tiene_Permiso(Me, "Stec0023") Then
            Return
        End If

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value
        Dim _Operacion As String = _Fila.Cells("Operacion").Value
        Dim _Grabar, _Eliminar As Boolean

        Dim Fm As New Frm_St_OperacionesCrear(_Operacion)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Eliminar = Fm.Eliminar
        Fm.Dispose()

        If _Grabar Or _Eliminar Then
            Sb_Actualizar_Grilla()
            If _Grabar Then BuscarDatoEnGrilla(_Operacion, "Operacion", Grilla)
        End If

    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Space Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub
End Class
