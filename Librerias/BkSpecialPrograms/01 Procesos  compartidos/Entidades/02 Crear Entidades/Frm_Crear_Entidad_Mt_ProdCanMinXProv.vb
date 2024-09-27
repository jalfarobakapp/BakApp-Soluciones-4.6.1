Imports DevComponents.DotNetBar

Public Class Frm_Crear_Entidad_Mt_ProdCanMinXProv

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Dim _CodEntidad As String
    Dim _CodSucEntidad As String

    Dim _Tbl_Producto As DataTable
    Dim _Dv As New DataView

    'Dim m_comboBox As ComboBox

    Public Sub New(_CodEntidad As String, _CodSucEntidad As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._CodEntidad = _CodEntidad
        Me._CodSucEntidad = _CodSucEntidad

        Sb_Formato_Generico_Grilla(Grilla, 22, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Crear_Entidad_Mt_ProdCanMinXProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        Me.ActiveControl = Txt_Buscador

        AddHandler Rdb_VerProd_Todos.CheckedChanged, AddressOf Rdb_VerProd_CheckedChanged
        AddHandler Rdb_VerProd_ConMultiplos.CheckedChanged, AddressOf Rdb_VerProd_CheckedChanged
        AddHandler Rdb_VerProd_SinMultiplos.CheckedChanged, AddressOf Rdb_VerProd_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        If Rdb_VerProd_Todos.Checked Then _Condicion = String.Empty
        If Rdb_VerProd_ConMultiplos.Checked Then _Condicion = "And MultiploCompra <> 0"
        If Rdb_VerProd_SinMultiplos.Checked Then _Condicion = "And MultiploCompra = 0"

        'Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "KOPR+NOKOPR Like '%")

        Consulta_Sql = "Select Cast(0 As Bit) As Editado,PrMc.*," & vbCrLf &
                       "PrMc.UdCompra As UdCompra_Ori,PrMc.MultiploCompra As MultiploCompra_Ori," &
                       "Case UdCompra When 2 Then UD02PR Else UD01PR End As UnCm,UD01PR,UD02PR,1 As Ud1,2 As Ud2,NOKOPR" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra PrMc" & vbCrLf &
                       "Inner Join MAEPR On KOPR = PrMc.Codigo" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "'" & vbCrLf & _Condicion
        '"And KOPR+NOKOPR Like '%" & _Cadena & "%'" & vbCrLf & _Condicion

        Dim _Ds As New DataSet

        _Dv.Table = _Sql.Fx_Get_DataSet(Consulta_Sql, _Ds, "Tbl").Tables("Tbl")

        _Tbl_Producto = _Dv.Table '_Sql.Fx_Get_Tablas(Consulta_Sql)

        With Grilla

            .DataSource = _Dv '_Tbl_Producto

            '' Elimina la columna de ComboBox del DataGridView
            'Dim comboColumn As New DataGridViewComboBoxColumn()
            'comboColumn.Name = "UdCompra2"
            'comboColumn.HeaderText = "UdCompra2"
            'Grilla.Columns.Add(comboColumn)

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            '.Columns("Editado").HeaderText = "Ed."
            '.Columns("Editado").Width = 30
            '.Columns("Editado").Visible = True
            '.Columns("Editado").DisplayIndex = _DisplayIndex
            '_DisplayIndex += 1

            .Columns("Codigo").HeaderText = "Código"
            .Columns("Codigo").Width = 110
            .Columns("Codigo").Visible = True
            .Columns("Codigo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 320
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UdCompra").HeaderText = "Ud"
            .Columns("UdCompra").Width = 40
            .Columns("UdCompra").Visible = True
            '.Columns("UdCompra").ReadOnly = False
            .Columns("UdCompra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UnCm").HeaderText = "UM"
            .Columns("UnCm").Width = 30
            .Columns("UnCm").Visible = True
            .Columns("UnCm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("MultiploCompra").Visible = True
            .Columns("MultiploCompra").HeaderText = "Multiplo"
            .Columns("MultiploCompra").ToolTipText = "Cantidad mínima y multiplo por la que se le debe comprar al proveedor"
            .Columns("MultiploCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("MultiploCompra").DefaultCellStyle.Format = "###,###.##"
            .Columns("MultiploCompra").Width = 60
            .Columns("MultiploCompra").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

        'Dim i As Integer = 0

        'For Each fila As DataGridViewRow In Grilla.Rows

        '    If Not fila.IsNewRow AndAlso Not fila.Cells("Ud1").Value Is Nothing AndAlso Not fila.Cells("Ud2").Value Is Nothing Then

        '        Dim celdaComboBox As DataGridViewComboBoxCell = CType(Grilla.Rows(i).Cells("UdCompra2"), DataGridViewComboBoxCell)

        '        Dim valorColumna0 As String = fila.Cells("Ud1").Value.ToString
        '        Dim valorColumna1 As String = fila.Cells("Ud2").Value.ToString

        '        celdaComboBox.Items.AddRange({valorColumna0, valorColumna1})

        '        ' Reemplaza "NombreDeTuColumna" con el índice real de la columna
        '        Dim comboCell As DataGridViewComboBoxCell = CType(fila.Cells("UdCompra2"), DataGridViewComboBoxCell)
        '        celdaComboBox.Value = fila.Cells("UdCompra").Value.ToString
        '        i += 1

        '    Else

        '        ' Sal del bucle si encuentras una fila vacía o nueva
        '        Exit For

        '    End If

        'Next

        Sb_Filtrar_Busqueda()

    End Sub

    Private Sub Txt_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Buscador.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Filtrar_Busqueda()
            'Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        Dim _Tbl_PrEdit As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "Editado = 1", "Codigo")

        _Tbl_PrEdit = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "UdCompra <> UdCompra_Ori Or MultiploCompra <> MultiploCompra_Ori", "Codigo")

        If Not CBool(_Tbl_PrEdit.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay registros que actualizar", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Consulta_Sql = String.Empty

        For Each _Fila As DataRow In _Tbl_PrEdit.Rows

            Dim _Id As Integer = _Fila.Item("Id")
            Dim _UdCompra As Integer = _Fila.Item("UdCompra")
            Dim _MultiploCompra As Double = _Fila.Item("MultiploCompra")

            Consulta_Sql += "Update " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra Set UdCompra = " & _UdCompra &
                            ",MultiploCompra = " & De_Num_a_Tx_01(_MultiploCompra, False, 5) & vbCrLf &
                            "Where Id = " & _Id & vbCrLf

        Next

        If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema al grabar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else

            If Not Rdb_VerProd_Todos.Checked Then Rdb_VerProd_Todos.Checked = True
            Sb_Actualizar_Grilla()

            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Btn_AgregarProductos_Click(sender As Object, e As EventArgs) Handles Btn_AgregarProductos.Click

        If String.IsNullOrEmpty(_CodEntidad) Then
            Call Btn_Mnu_SeleccionarProductos_Click(Nothing, Nothing)
        Else
            ShowContextMenu(Menu_Contextual_02)
        End If

    End Sub

    Private Sub Btn_ExportarExcel_Click(sender As Object, e As EventArgs) Handles Btn_ExportarExcel.Click

        Dim _Texto_Busqueda As String = Txt_Buscador.Text.Trim
        Dim _Condicion As String = String.Empty

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Texto_Busqueda), "KOPR+NOKOPR Like '%")

        Consulta_Sql = "Select KOPR As Codigo,NOKOPR As Descripcion,PrMc.UdCompra,PrMc.MultiploCompra" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra PrMc" & vbCrLf &
                       "Inner Join MAEPR On KOPR = PrMc.Codigo" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        ExportarTabla_JetExcel_Tabla(_Tbl, Me, "Productos")

    End Sub

    Private Sub Txt_Buscador_ButtonCustom2Click(sender As Object, e As EventArgs) Handles Txt_Buscador.ButtonCustom2Click
        Txt_Buscador.Text = String.Empty
        Sb_Filtrar_Busqueda()
        'Sb_Actualizar_Grilla()
    End Sub
    Private Sub Sb_Grilla_Tipos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub Btn_Mnu_SeleccionarProductos_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_SeleccionarProductos.Click

        If Not Fx_RevisarSiHayDatosEditados() Then
            Return
        End If

        'If Not Fx_Tiene_Permiso(Me, "CfEnt030") Then Return

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR In ('FPN','FIN') And KOPR Not In " &
                                          "(Select Codigo From " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra " &
                                          "Where CodEntidad = '" & _CodEntidad & "')"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        Dim _Tbl As DataTable

        If _Filtrar.Fx_Filtrar(_Tbl,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False, False, False,, False) Then

            _Tbl = _Filtrar.Pro_Tbl_Filtro

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Codigo As String = _Fila.Item("Codigo")

                Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra (CodEntidad,Codigo,UdCompra) Values " &
                               "('" & _CodEntidad & "','" & _Codigo & "',1)"
                _Sql.Ej_consulta_IDU(Consulta_Sql)

            Next

            Sb_Actualizar_Grilla()

            MessageBoxEx.Show(Me, "Se han insertado correctamente " & FormatNumber(_Tbl.Rows.Count, 0) & " producto(s)" & vbCrLf &
                              "No es necesario grabar para confirmar esta acción", "Insertar productos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub Btn_TraerProductosFCCGRCOCC_Click(sender As Object, e As EventArgs) Handles Btn_TraerProductosFCCGRCOCC.Click

        If Not Fx_RevisarSiHayDatosEditados() Then
            Return
        End If

        Dim _Filtro As String

        Consulta_Sql = "Select Distinct KOPRCT" & vbCrLf &
                       "From MAEDDO Where TIDO In ('OCC','GRC','FCC') And ENDO = '" & _CodEntidad & "'" & vbCrLf &
                       "And KOPRCT Not In (Select Codigo From " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra Where CodEntidad = '" & _CodEntidad & "')"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If Not CBool(_Tbl.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen datos que mostrar", "Buscar productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "Se encontraron " & FormatNumber(_Tbl.Rows.Count, 0) & vbCrLf & vbCrLf &
                             "¿Confirma la incorporación de estos?", "Importar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        _Filtro = Generar_Filtro_IN(_Tbl, "", "KOPRCT", False, False, "'")

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra (CodEntidad,Codigo,UdCompra)" & vbCrLf &
                       "Select '" & _CodEntidad & "',KOPR,1" & vbCrLf &
                       "From MAEPR Where KOPR In " & _Filtro

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Se han insertado correctamente " & FormatNumber(_Tbl.Rows.Count, 0) & " producto(s)" & vbCrLf &
                              "No es necesario grabar para confirmar esta acción", "Insertar productos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_TraerProductosTabcodal_Click(sender As Object, e As EventArgs) Handles Btn_TraerProductosTabcodal.Click

        If Not Fx_RevisarSiHayDatosEditados() Then
            Return
        End If

        Dim _Filtro As String

        Consulta_Sql = "Select Distinct KOPR" & vbCrLf &
                       "From TABCODAL Where KOEN = '" & _CodEntidad & "'" & vbCrLf &
                       "And KOPR Not In (Select Codigo From " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra Where CodEntidad = '" & _CodEntidad & "')"

        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql)

        If Not CBool(_Tbl.Rows.Count) Then
            MessageBoxEx.Show(Me, "No existen datos que mostrar", "Buscar productos", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If MessageBoxEx.Show(Me, "Se encontraron " & FormatNumber(_Tbl.Rows.Count, 0) & vbCrLf & vbCrLf &
                             "¿Confirma la incorporación de estos?", "Importar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        _Filtro = Generar_Filtro_IN(_Tbl, "", "KOPR", False, False, "'")

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra (CodEntidad,Codigo,UdCompra)" & vbCrLf &
                       "Select '" & _CodEntidad & "',KOPR,1" & vbCrLf &
                       "From MAEPR Where KOPR In " & _Filtro

        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
            Txt_Buscador.Text = String.Empty
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Se han insertado correctamente " & FormatNumber(_Tbl.Rows.Count, 0) & " producto(s)" & vbCrLf &
                              "No es necesario grabar para confirmar esta acción", "Insertar productos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Grilla_KeyDown(sender As Object, e As KeyEventArgs) Handles Grilla.KeyDown

        Dim _Seleccionada As Boolean
        Dim _UnCm As String
        Dim _UnTrans As Integer

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If e.KeyValue = Keys.Enter Then

            Select Case _Cabeza

                Case "UnCm", "UdCompra"

                    Dim Fm As New Frm_Cantidades_Selec_Ud(_Fila)
                    Fm.ShowDialog(Me)
                    _Seleccionada = Fm.Seleccionada
                    _UnTrans = Fm.UnTrans
                    _UnCm = Fm.UdTrans
                    Fm.Dispose()

                    If _Seleccionada Then
                        _Fila.Cells("UdCompra").Value = _UnTrans
                        _Fila.Cells("UnCm").Value = _UnCm

                        If _Fila.Cells("UdCompra").Value <> _Fila.Cells("UdCompra_Ori").Value Then
                            _Fila.Cells("Editado").Value = True
                        End If

                    End If

                Case "MultiploCompra"

                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)

                    e.SuppressKeyPress = False
                    e.Handled = True

            End Select

        End If

    End Sub

    Private Sub Grilla_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Grilla.EditingControlShowing

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        If _Cabeza = "MultiploCompra" Then

            ' referencia a la celda  
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress  
            AddHandler validar.KeyPress, AddressOf Validar_Keypress_Nros_Grilla

        End If

        'If _Cabeza = "UdCompra2" Then

        '    Try
        '        If e.Control.GetType Is GetType(DataGridViewComboBoxEditingControl) Then
        '            m_comboBox = DirectCast(e.Control, ComboBox)
        '            ' Instalamos el controlador para el evento SelectedValueChanged
        '            AddHandler m_comboBox.SelectedValueChanged, AddressOf ComboBoxOnSelectedValueChanged
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "vb.net",
        '         MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try

        'End If

    End Sub

    Private Sub Grilla_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.CellEndEdit

        Dim _Fila As DataGridViewRow = Grilla.CurrentRow
        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Grilla.Columns(_Cabeza).ReadOnly = True

        Select Case _Cabeza

            Case "UnCm", "UdCompra", "MultiploCompra"

                If _Cabeza = "UnCm" Or _Cabeza = "UdCompra" Then
                    '_Fila.Cells("UdCompra").Value = _Fila.Cells("UdCompra2").Value
                    Grilla.Columns(_Cabeza).ReadOnly = False
                End If

                'If _Fila.Cells(_Cabeza).Value <> _Fila.Cells(_Cabeza & "_Ori").Value Then
                '    _Fila.Cells("Editado").Value = True
                'End If

        End Select

    End Sub

    Private Sub ComboBoxOnSelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        'Referenciamos el control ComboBox que ha
        ' desencadenado el evento.
        Dim cb As ComboBox = DirectCast(sender, ComboBox)
        ' Obtenemos el valor de su propiedad ValueMember
        '
        Dim value As Object = cb.SelectedValue

        'RemoveHandler m_comboBox.SelectedValueChanged, AddressOf ComboBoxOnSelectedValueChanged
        'Grilla.EndEdit()
        'If value IsNot DBNull.Value Then
        '    MessageBox.Show(CStr(value))
        'End If
    End Sub

    'Private Sub Grilla_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Grilla.RowValidated
    '    Try
    '        If m_comboBox IsNot Nothing Then
    '            'Desinstalamos el controlador de eventos 
    '            RemoveHandler m_comboBox.SelectedValueChanged,
    '            AddressOf ComboBoxOnSelectedValueChanged
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "vb.net",
    '        MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub Btn_QuitarConValorCero_Click(sender As Object, e As EventArgs) Handles Btn_QuitarConValorCero.Click

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Entidades_ProdMinCompra", "CodEntidad = '" & _CodEntidad & "'")

        If Not CBool(_Tbl_Producto.Rows.Count) Then
            MessageBoxEx.Show(Me, "No hay registros que quitar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _Tbl_PrEdit As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "Editado = 1", "Codigo")

        _Tbl_PrEdit = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "UdCompra <> UdCompra_Ori Or MultiploCompra <> MultiploCompra_Ori", "Codigo")

        If CBool(_Tbl_PrEdit.Rows.Count) Then
            If MessageBoxEx.Show(Me, "hay registros actualizados, si sigue no se grabaran esos cambios." & vbCrLf & vbCrLf &
                                 "¿Desea seguir con la eliminación?", "Grabar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return
            End If
        End If

        If MessageBoxEx.Show(Me, "¿Confirma quitar los productos con cantidad cero?", "Quitar productos",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Consulta_Sql = "Delete " & _Global_BaseBk & "Zw_Entidades_ProdMinCompra" & vbCrLf &
                       "Where CodEntidad = '" & _CodEntidad & "' And MultiploCompra = 0"
        If _Sql.Ej_consulta_IDU(Consulta_Sql) Then
            Sb_Actualizar_Grilla()
            MessageBoxEx.Show(Me, "Registros eliminados correctamente", "Quitar productos",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub Txt_Buscador_TextChanged(sender As Object, e As EventArgs) Handles Txt_Buscador.TextChanged
        If String.IsNullOrEmpty(Txt_Buscador.Text) Then
            Sb_Filtrar_Busqueda()
            'Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Frm_Crear_Entidad_Mt_ProdCanMinXProv_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'Dim _Tbl_PrEdit As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "Editado = 1", "Codigo")

        '_Tbl_PrEdit = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "UdCompra <> UdCompra_Ori Or MultiploCompra <> MultiploCompra_Ori", "Codigo")

        'If CBool(_Tbl_PrEdit.Rows.Count) Then
        '    If MessageBoxEx.Show(Me, "hay registros actualizados, los cambios no se guardaran si cierra el formulario." & vbCrLf & vbCrLf &
        '                         "¿Confirma cerrar el formularion sin grabar?", "Salir sin grabar",
        '                         MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
        '        e.Cancel = True
        '    End If
        'End If

        If Not Fx_RevisarSiHayDatosEditados() Then
            e.Cancel = True
        End If

    End Sub

    Function Fx_RevisarSiHayDatosEditados() As Boolean

        Dim _Tbl_PrEdit As DataTable = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "Editado = 1", "Codigo")

        _Tbl_PrEdit = Fx_Crea_Tabla_Con_Filtro(_Tbl_Producto, "UdCompra <> UdCompra_Ori Or MultiploCompra <> MultiploCompra_Ori", "Codigo")

        If CBool(_Tbl_PrEdit.Rows.Count) Then
            If MessageBoxEx.Show(Me, "hay registros actualizados, los cambios no se guardaran." & vbCrLf & vbCrLf &
                                 "¿Confirma continuar sin grabar sin grabar?", "Salir sin grabar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Stop) <> DialogResult.Yes Then
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub Rdb_VerProd_CheckedChanged(sender As Object, e As EventArgs)
        If CType(sender, Controls.CheckBoxX).Checked Then
            Sb_Filtrar_Busqueda()
            'Sb_Actualizar_Grilla()
        End If
    End Sub

    Sub Sb_Filtrar_Busqueda()

        Dim _Condicion As String

        If Rdb_VerProd_Todos.Checked Then _Condicion = String.Empty
        If Rdb_VerProd_ConMultiplos.Checked Then _Condicion = "And MultiploCompra <> 0"
        If Rdb_VerProd_SinMultiplos.Checked Then _Condicion = "And MultiploCompra = 0"

        _Dv.RowFilter = String.Format("Codigo+NOKOPR Like '%{0}%' " & _Condicion, Txt_Buscador.Text)

    End Sub

End Class
