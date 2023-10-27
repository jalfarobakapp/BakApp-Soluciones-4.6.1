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

        'Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        'Dim _Condicion As String = String.Empty

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "CODIGO+DESCRIPTOR Like '%")

        'If Not String.IsNullOrWhiteSpace(Txt_BuscaXProducto.Text) Then
        '_Condicion = "And CODIGO In (Select CODIGO From MAEDRES Where ELEMENTO = '" & Txt_BuscaXProducto.Text & "')"
        'End If

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Areas"
        _Tbl_Areas = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Areas

            .DataSource = _Tbl_Areas

            OcultarEncabezadoGrilla(Grilla_Areas)

            Dim _DisplayIndex = 0

            .Columns("Area").Visible = True
            .Columns("Area").HeaderText = "Area / Departamento"
            .Columns("Area").Width = 440
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
        Call Btn_Mnu_AsociarTipos_Click(Nothing, Nothing)
        'Call Btn_Mnu_EditarArea_Click(Nothing, Nothing)
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

        Dim Fm As New Frm_Tickets_Tipos(_Id_Area)
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Call Grilla_Areas_CellEnter(Nothing, Nothing)

    End Sub

    Private Sub Grilla_Areas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla_Areas.CellEnter

        Dim _FilaArea As DataGridViewRow = Grilla_Areas.CurrentRow
        Dim _Id_Area As Integer = _FilaArea.Cells("Id").Value

        Consulta_sql = "Select At.*,Tp.Tipo From " & _Global_BaseBk & "Zw_Stk_AreaVsTipo At" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Tipos Tp On At.Id_Tipo = Tp.Id" & vbCrLf &
                       "Where Id_Area = " & _Id_Area

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id_Area = " & _Id_Area

        _Tbl_Tipos = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla_Tipos

            .DataSource = _Tbl_Tipos

            OcultarEncabezadoGrilla(Grilla_Tipos)

            Dim _DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").HeaderText = "Tipo"
            .Columns("Tipo").Width = 440
            .Columns("Tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Btn_Mnu_QuitarTipo_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_QuitarTipo.Click

        'If Not Fx_Tiene_Permiso(Me, "Ofer0006") Then
        '    Return
        'End If

        Dim _Fila As DataGridViewRow = Grilla_Tipos.CurrentRow
        Dim _Id As Integer = _Fila.Cells("Id").Value

        If MessageBoxEx.Show(Me, "¿Confirma quitar este Tipo de requerimiento?", "Quitar tipo de requerimiento",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_AreaVsTipo Where Id = " & _Id
        If _Sql.Ej_consulta_IDU(Consulta_sql) Then
            Grilla_Tipos.Rows.Remove(_Fila)
        End If

    End Sub
End Class
