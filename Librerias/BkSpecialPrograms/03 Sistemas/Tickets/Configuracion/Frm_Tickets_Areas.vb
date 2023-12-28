Imports DevComponents.DotNetBar

Public Class Frm_Tickets_Areas

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Areas As DataTable
    Dim _Tbl_Tipos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Areas, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Tipos, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Tickets_Areas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Areas.MouseDown, AddressOf Sb_Grilla_Areas_MouseDown
        AddHandler Grilla_Tipos.MouseDown, AddressOf Sb_Grilla_Tipos_MouseDown

        AddHandler Grilla_Areas.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Tipos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "Area+Tipo Like '%")

        Consulta_sql = "Select Distinct Ar.* From " & _Global_BaseBk & "Zw_Stk_Areas Ar" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On Tp.Id_Area = Ar.Id" & vbCrLf &
                       "Where Area+Tipo Like '%" & _Cadena & "%'"
        _Tbl_Areas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Areas

            .DataSource = _Tbl_Areas

            OcultarEncabezadoGrilla(Grilla_Areas, True)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area / Departamento"
            .Columns("Area").Width = 600
            .Columns("Area").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            ''.Columns("Dias").Visible = True
            ''.Columns("Dias").HeaderText = "Días expira."
            ''.Columns("Dias").ToolTipText = "Días que faltan para que termine la oferta"
            ''.Columns("Dias").Width = 70
            ''.Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ''.Columns("Dias").DefaultCellStyle.Format = "###,##0.##"
            ''.Columns("Dias").DisplayIndex = _DisplayIndex
            ''_DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_CrearArea_Click(sender As Object, e As EventArgs) Handles Btn_CrearArea.Click

        Dim _Aceptar As Boolean
        Dim _Area As String

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del Area o Departamento", "Crear Area/Departamento", _Area, False, _Tipo_Mayus_Minus.Mayusculas, 50, True)

        If Not _Aceptar Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Areas", "Area = '" & _Area & "'")

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Al nombre del Area ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_CrearArea_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Areas (Area) Values ('" & _Area & "')"
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Me.Sb_Actualizar_Grilla()
            BuscarDatoEnGrilla(_Area, "Area", Grilla_Areas)
        End If

    End Sub

    Private Sub Btn_Mnu_EditarArea_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarArea.Click

        Dim _Fila As DataGridViewRow = Grilla_Areas.CurrentRow

        Dim _Id_Area As Integer = _Fila.Cells("Id").Value
        Dim _Area As String = _Fila.Cells("Area").Value
        Dim _Area_Old As String = _Fila.Cells("Area").Value

        Dim _Aceptar As Boolean

        _Aceptar = InputBox_Bk(Me, "Ingrese el nombre del Area o Departamento", "Editar nombre de Area/Departamento", _Area, False,
                               _Tipo_Mayus_Minus.Mayusculas, 50, True)

        If Not _Aceptar Then
            Return
        End If

        If _Area.Trim = _Area_Old.Trim Then
            Return
        End If

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Areas", "Area = '" & _Area & "' And Id <> " & _Id_Area)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Al nombre del Area ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Call Btn_Mnu_EditarArea_Click(Nothing, Nothing)
            Return
        End If

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Areas Set Area = '" & _Area.Trim & "' Where Id = " & _Id_Area
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            _Fila.Cells("Area").Value = _Area
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Grilla_Areas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Areas.CellDoubleClick
        'Call Btn_Mnu_EditarArea_Click(Nothing, Nothing)
        ShowContextMenu(Menu_Contextual_01)
    End Sub

    Private Sub Sb_Grilla_Areas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Sb_Grilla_Tipos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_02)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_AsociarTipos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_AsociarTipos.Click

        Dim _FilaArea As DataGridViewRow = Grilla_Areas.CurrentRow

        Dim _Id_Area As Integer = _FilaArea.Cells("Id").Value

        Dim _Grabar As Boolean
        Dim _Row_Tipo As DataRow

        Dim Fm As New Frm_Tickets_TiposCrear(_Id_Area, 0)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Tipo = Fm.Row_Tipo
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla_Tipos(_Id_Area)
        End If

        'Dim Fm As New Frm_Tickets_Tipos(_Id_Area)
        'Fm.ShowDialog(Me)
        'Fm.Dispose()

        'Call Grilla_Areas_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Grilla_Areas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Areas.CellEnter

        Dim _FilaArea As DataGridViewRow = Grilla_Areas.CurrentRow
        Dim _Id_Area As Integer = _FilaArea.Cells("Id").Value

        Sb_Actualizar_Grilla_Tipos(_Id_Area)

    End Sub
    Sub Sb_Actualizar_Grilla_Tipos(_Id_Area As Integer)

        Consulta_sql = "Select Tp.*,Isnull(Tf.NOKOFU,'') As 'Agente',Isnull(Gr.Grupo,'') As Grupo," & vbCrLf &
                       "Case AsignadoGrupo When 1 then 'Grupo: ' +Isnull(Gr.Grupo,'') Else " & vbCrLf &
                       "Case AsignadoAgente When 1 Then 'Agente: ' + Isnull(Tf.NOKOFU,'') Else '' End End As 'AsignadoA'," & vbCrLf &
                       "Case ExigeProducto When 1 Then " & vbCrLf &
                       "Case RevInventario When 1 Then 'Revisión de inventario' " & vbCrLf &
                       "Else Case AjusInventario When 1 Then 'Ajuste de inventario' " & vbCrLf &
                       "Else Case SobreStock When 1 Then 'Sobre Stock' Else '' End End End Else '' End	As 'Esp_producto'" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Tp.CodAgente" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Tp.Id_Grupo = Gr.Id" & vbCrLf &
                       "Where Tp.Id_Area = " & _Id_Area
        _Tbl_Tipos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos, True)

            Dim _DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 220
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("ExigeProducto").Visible = True
            .Columns("ExigeProducto").HeaderText = "Ex.Prod."
            .Columns("ExigeProducto").ToolTipText = "Si esta tickeado, el Ticket exgira la incorporación de un producto para la gestión"
            .Columns("ExigeProducto").Width = 50
            .Columns("ExigeProducto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Esp_producto").Visible = True
            .Columns("Esp_producto").HeaderText = "Especial Productos"
            .Columns("Esp_producto").ToolTipText = "Acción especial por gestión especialmente para productos"
            .Columns("Esp_producto").Width = 130
            .Columns("Esp_producto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("AsignadoA").Visible = True
            .Columns("AsignadoA").HeaderText = "Asignado a:"
            .Columns("AsignadoA").Width = 200
            .Columns("AsignadoA").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Mnu_QuitarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarTipo.Click

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Id_Tipo = " & _Id)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar este tipo de ticket, ya que tiene ticket asociados",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma eliminar este Tipo de requerimiento?", "Quitar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Tipos.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Btn_Mnu_EditarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EditarTipo.Click

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow

        Dim _Id_Area As Integer = _Fila.Cells("Id_Area").Value
        Dim _Id_Tipo As Integer = _Fila.Cells("Id").Value
        Dim _Tipo As String = _Fila.Cells("Tipo").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Estado = 'ABIE' And Id_Tipo = " & _Id_Tipo)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "Existen Tickets que están abierto y usan este tipo de requerimiento." & vbCrLf &
                              "Se mostrara el siguiente formulario, sin embargo el sistema volverá a validar que no hayan Tickets abiertos para que pueda editar",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Dim _Grabar As Boolean
        Dim _Row_Tipo As DataRow

        Dim Fm As New Frm_Tickets_TiposCrear(_Id_Area, _Id_Tipo)
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Row_Tipo = Fm.Row_Tipo
        Fm.Dispose()

        If _Grabar Then
            Sb_Actualizar_Grilla_Tipos(_Id_Area)
        End If

    End Sub

    Private Sub Grilla_Tipos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Tipos.CellDoubleClick
        ShowContextMenu(Menu_Contextual_02)
    End Sub

    Private Sub Btn_Mnu_EliminarArea_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_EliminarArea.Click

        Dim _Fila As DataGridViewRow = Grilla_Areas.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Stk_Tickets", "Id_Area = " & _Id)

        If CBool(_Reg) Then
            MessageBoxEx.Show(Me, "No se puede eliminar esta area de ticket, ya que tiene ticket asociados",
                              "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "¿Confirma eliminar el area?", "Quitar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Areas Where Id = " & _Id & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Areas.Rows.Remove(_Fila)
        End If

    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown

        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        If String.IsNullOrWhiteSpace(Txt_Buscador.Text) Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Actualizar_Grilla()
    End Sub
End Class
