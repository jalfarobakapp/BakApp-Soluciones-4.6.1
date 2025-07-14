Imports DevComponents.DotNetBar

Public Class Frm_01_UbicXpro

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _RowProducto As DataRow, _RowBodega As DataRow
    Dim _RowSector As DataRow

    Dim _Codigo, _Descripcion As String

    Dim _Producto_Op As New Frm_BkpPostBusquedaEspecial_Mt

    Public Property Pro_RowBodega() As DataRow
        Get
            Return _RowBodega
        End Get
        Set(ByVal value As DataRow)
            _RowBodega = value
        End Set
    End Property

    Public Sub New(ByVal Codigo As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Codigo = Codigo

        'If Global_Thema = 2 Then

        '    BtnAgregarUbicXProdBuscar.ForeColor = Color.White
        '    BtnAgregarUbicXProdDirecto.ForeColor = Color.White
        '    Btn_Mnu_Pr_Estadistica_Producto2.ForeColor = Color.White
        '    TxtDescripcion.FocusHighlightEnabled = False

        'End If

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_01_UbicXpro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If (_RowBodega Is Nothing) Then

            Consulta_sql = "Select top 1 * From TABBO" & vbCrLf &
                           "Where EMPRESA = '" & Mod_Empresa & "' And KOSU = '" & Mod_Sucursal & "' and KOBO = '" & Mod_Bodega & "'"

            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            _RowBodega = _Tbl.Rows(0)

        End If

        _Empresa = _RowBodega.Item("EMPRESA")
        _Sucursal = _RowBodega.Item("KOSU")
        _Bodega = _RowBodega.Item("KOBO")

        Consulta_sql = "Select top 1 *  From MAEPR Where KOPR = '" & _Codigo & "'"
        _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Descripcion = _RowProducto.Item("NOKOPR")

        TxtDescripcion.Text = "Código: " & Trim(_Codigo) & ", Descripción: " & _Descripcion
        Sb_ActGrilla_Ubicaciones()

        AddHandler Grilla.CellDoubleClick, AddressOf Sb_Ver_Ubicaciones
        AddHandler BtnAgregarUbicXProdDirecto.Click, AddressOf Sb_Asignar_Ubicacion_Directa

        AddHandler Grilla.KeyDown, AddressOf Grilla_KeyDown
        AddHandler Grilla.CellEndEdit, AddressOf Grilla_CellEndEdit
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

    End Sub

    Sub Sb_ActGrilla_Ubicaciones()

        Consulta_sql = "Select Ubic.Semilla,Ubic.Empresa,Ubic.Sucursal,Ubic.Bodega,Ubic.Id_Mapa,Ubic.Codigo_Sector,Ubic.Codigo_Ubic,Ubic.Codigo,Ubic.Primaria," & vbCrLf &
                       "Ubic.Stock_Minimo_Ubic,Ubic.Stock_Maximo_Ubic," & vbCrLf &
                       "Case Ubic.Primaria When 1 Then 'Principal' else 'secundaria' End As 'Tipo'," & vbCrLf &
                       "Map.Nombre_Mapa+' '+Ubic.Codigo_Sector+' -> '+Ubic.Codigo_Ubic As 'Ubicacion'," & vbCrLf &
                       "Isnull(Sum(Stock_Ud1),0) As Stock_Ubic_Ud1," & vbCrLf &
                       "Isnull(Sum(Stock_Ud2),0) As Stock_Ubic_Ud2" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Prod_Ubicacion Ubic" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc Map On Map.Id_Mapa = Ubic.Id_Mapa" & vbCrLf &
                       "Left join " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Stock_X_Producto Stpr On" & vbCrLf &
                       "Stpr.Empresa = Ubic.Empresa And Stpr.Sucursal = Ubic.Sucursal And Stpr.Bodega = Ubic.Bodega And " &
                       "Stpr.Codigo_Ubic = Ubic.Codigo_Ubic And Stpr.Codigo = Ubic.Codigo" & vbCrLf &
                       "Where Ubic.Codigo = '" & _Codigo & "'" & vbCrLf &
                       "Group By Map.Nombre_Mapa,Ubic.Semilla,Ubic.Empresa,Ubic.Sucursal,Ubic.Bodega,Ubic.Id_Mapa,Ubic.Codigo_Sector," &
                       "Ubic.Codigo_Ubic,Ubic.Codigo,Ubic.Primaria,Ubic.Stock_Minimo_Ubic,Ubic.Stock_Maximo_Ubic" & vbCrLf &
                       "Order by Primaria Desc"

        With Grilla

            .DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

            OcultarEncabezadoGrilla(Grilla, True)

            Dim _DisplayIndex = 0

            .Columns("Empresa").Width = 30
            .Columns("Empresa").HeaderText = "Emp."
            .Columns("Empresa").Visible = True
            .Columns("Empresa").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sucursal").Width = 30
            .Columns("Sucursal").HeaderText = "Suc."
            .Columns("Sucursal").Visible = True
            .Columns("Sucursal").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Bodega").Width = 30
            .Columns("Bodega").HeaderText = "Bod."
            .Columns("Bodega").Visible = True
            .Columns("Bodega").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Sector").Width = 300
            '.Columns("Sector").HeaderText = "Sector"
            '.Columns("Sector").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Sector").Visible = True

            .Columns("Ubicacion").Width = 390
            .Columns("Ubicacion").HeaderText = "Ubicación"
            .Columns("Ubicacion").Visible = True
            .Columns("Ubicacion").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Tipo").Width = 80
            .Columns("Tipo").HeaderText = "Tipo Ubic."
            .Columns("Tipo").Visible = True
            .Columns("tipo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            '.Columns("Fila").Width = 60
            '.Columns("Fila").HeaderText = "Fila"
            '.Columns("Fila").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Fila").Visible = True

            '.Columns("Primaria").Width = 100
            '.Columns("Primaria").HeaderText = "Ubicación por Defecto"
            '.Columns("Primaria").Visible = True
            '.Columns("Primaria").DisplayIndex = 3

            .Columns("Stock_Minimo_Ubic").Width = 90
            .Columns("Stock_Minimo_Ubic").HeaderText = "Cantidad Mínima"
            .Columns("Stock_Minimo_Ubic").Visible = True
            .Columns("Stock_Minimo_Ubic").DefaultCellStyle.Format = "##,###"
            .Columns("Stock_Minimo_Ubic").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Minimo_Ubic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stock_Maximo_Ubic").Width = 90
            .Columns("Stock_Maximo_Ubic").HeaderText = "Cantidad Máxima"
            .Columns("Stock_Maximo_Ubic").Visible = True
            .Columns("Stock_Maximo_Ubic").DefaultCellStyle.Format = "##,###"
            .Columns("Stock_Maximo_Ubic").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stock_Maximo_Ubic").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1


        End With


    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnAgregarUbicXProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarUbicXProdBuscar.Click
        Sb_Agregar_Ubicacion_Buscando_En_Mapa()
    End Sub

    Sub Sb_Agregar_Ubicacion_Buscando_En_Mapa()

        If Fx_Tiene_Permiso(Me, "Ubic0004") Then

            Dim Fm As New Frm_Diseno_Doc_y_Ubic
            Fm.Pro_RowBodega = _RowBodega
            Fm.Pro_RowProducto = _RowProducto
            Fm.Pro_Configuracion_Diseno = Frm_Diseno_Doc_y_Ubic._TipoDiseno.Mapa_Bodega_Asignar_Ubicaciones
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Sb_ActGrilla_Ubicaciones()
        End If

    End Sub

    Sub Eliminar_Fila()

        If Fx_Tiene_Permiso(Me, "Ubic0006") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Semilla = _Fila.Cells("Semilla").Value
            Dim _Id_Mapa = _Fila.Cells("Id_Mapa").Value
            Dim _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value
            Dim _Primaria = _Fila.Cells("Primaria").Value
            Dim _Empresa = _Fila.Cells("Empresa").Value
            Dim _Sucursal = _Fila.Cells("Sucursal").Value
            Dim _Bodega = _Fila.Cells("Bodega").Value
            Dim _Codigo_Ubic = _Fila.Cells("Codigo_Ubic").Value
            Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

            If Grilla.Rows.Count > 1 And _Primaria Then

                MessageBoxEx.Show(Me, "¡Esta es la ubicación por defecto del producto" & vbCrLf &
                                  "no se puede eliminar antes que las demás!", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return

            End If

            Dim dlg As System.Windows.Forms.DialogResult =
                         MessageBoxEx.Show(Me, "¿Esta seguro de eliminar la(s) fila(s) seleccionada(s)?",
                                          "Eliminar fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dlg = System.Windows.Forms.DialogResult.Yes Then

                Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Ubicacion_IngSal", "Semilla = " & _Semilla)

                Consulta_sql = String.Empty

                If CBool(_Reg) Then
                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal Set " & vbCrLf &
                               "Empresa = '" & _Empresa & "'" &
                               ",Sucursal = '" & _Sucursal & "'" &
                               ",Bodega = '" & _Bodega & "'" &
                               ",Id_Mapa = " & _Id_Mapa &
                               ",Codigo_Sector = '" & _Codigo_Sector & "'" &
                               ",Codigo_Ubic = '" & _Codigo_Ubic & "'" &
                               ",Codigo = '" & _Codigo & "'" &
                               ",CodFuncionario_Sal = '" & FUNCIONARIO & "'" &
                               ",NombreEquipo = '" & _NombreEquipo & "'" &
                               ",Salida = 1" &
                               ",FechaSalida = GetDate()" & vbCrLf &
                               "Where Semilla = " & _Semilla & vbCrLf
                Else
                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Ubicacion_IngSal (Semilla,Empresa,Sucursal,Bodega,Id_Mapa,Codigo_Sector,Codigo_Ubic,Codigo," &
                                   "CodFuncionario_Sal,NombreEquipo,Salida,FechaSalida) Values " & vbCrLf &
                                   "(" & _Semilla & ",'" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "'," & _Id_Mapa & ",'" & _Codigo_Sector & "','" & _Codigo_Ubic & "'" &
                                   ",'" & _Codigo & "','" & FUNCIONARIO & "','" & _NombreEquipo & "',1,Getdate())" & vbCrLf
                End If

                Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Prod_Ubicacion Where Semilla = " & _Semilla

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                    MessageBoxEx.Show(Me, _Sql.Pro_Error, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If

                If _Primaria Then

                    If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

                        Consulta_sql = "Update TABBOPR Set DATOSUBIC = ''" & vbCrLf &
                                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'"
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    End If

                End If

                Grilla.Rows.RemoveAt(_Fila.Index)

            End If

        End If

    End Sub

    Private Sub Frm_01_UbicXpro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F2 Then
            Sb_Asignar_Ubicacion_Directa()
        ElseIf e.KeyValue = Keys.F3 Then
            Sb_Agregar_Ubicacion_Buscando_En_Mapa()
        ElseIf e.KeyValue = Keys.F4 Then
            _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If
    End Sub


#Region "VER UBICACIONES DE UN SECTOR"

    Sub Sb_Ver_Ubicaciones()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Mapa = _Fila.Cells("Id_Mapa").Value
        Dim _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value
        Dim _Primaria = _Fila.Cells("Primaria").Value
        Dim _Empresa = _Fila.Cells("Empresa").Value
        Dim _Sucursal = _Fila.Cells("Sucursal").Value
        Dim _Bodega = _Fila.Cells("Bodega").Value

        Dim Fm As New Frm_Ubicaciones(_RowBodega, _Id_Mapa, _Codigo_Sector)
        Fm.Pro_RowProducto = _RowProducto
        Fm.ShowDialog(Me)
        Sb_ActGrilla_Ubicaciones()
        Fm.Dispose()


    End Sub

    Function Fx_Raiz_Clasificacion(ByVal _Codigo_Nodo As String)

        Dim _Full As String = String.Empty
        Dim _CodPadre As String

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _Codigo_Nodo
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")

        Do While (_CodPadre <> 0)

            Consulta_sql = "Select * From " & _Global_BaseBk & " Zw_TblArbol_Asociaciones Where Codigo_Nodo = " & _CodPadre
            _Tbl = _Sql.Fx_Get_DataTable(Consulta_sql)

            _CodPadre = _Tbl.Rows(0).Item("Identificacdor_NodoPadre")
            _Full = "\" & _Tbl.Rows(0).Item("Descripcion") & _Full

        Loop

        Return _Full

    End Function

#End Region

#Region "ASIGNAR UBICACION AL PRODUCTO"
    Sub Sb_Asignar_Ubicacion_Directa()

        Dim _Codigo_Ubic As String

        Dim _Aceptar As Boolean = InputBox_Bk(Me, "ingrese código de la ubicación" & vbCrLf &
                                                 "distingue mayúsculas de minúsculas",
                                                  "ASIGNAR UBICACION AL PRODUCTO", _Codigo_Ubic,
                                                  False, _Tipo_Mayus_Minus.Normal, 20, True, _Tipo_Imagen.Barra, False)


        If _Aceptar Then

            _Codigo_Ubic = UCase(_Codigo_Ubic)

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Bodega" & vbCrLf &
                           "Where Codigo_Ubic = '" & _Codigo_Ubic & "' And Es_SubSector = 0"
            Dim _TblUbicaciones As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            If CBool(_TblUbicaciones.Rows.Count) Then

                Dim _Empresa
                Dim _Sucursal
                Dim _Bodegad
                Dim _Id_Mapa
                Dim _Codigo_Sector

                If _TblUbicaciones.Rows.Count = 1 Then

                    Dim _Fila As DataRow = _TblUbicaciones.Rows(0)

                    _Empresa = _Fila.Item("Empresa")
                    _Sucursal = _Fila.Item("Sucursal")
                    _Bodega = _Fila.Item("Bodega")
                    _Id_Mapa = _Fila.Item("Id_Mapa")
                    _Codigo_Sector = _Fila.Item("Codigo_Sector")

                Else

                    Dim Fm As New Frm_AsociarUbicXprod
                    Fm._TblUbicaciones = _TblUbicaciones
                    Fm.ShowDialog(Me)

                    If Fm._Ubicacion_Asociada Then

                        Dim _Fila = Fm.Grilla.Rows(Fm.Grilla.CurrentRow.Index)

                        _Empresa = _Fila.Cells("Empresa").Value
                        _Sucursal = _Fila.Cells("Sucursal").Value
                        _Bodega = _Fila.Cells("Bodega").Value
                        _Id_Mapa = _Fila.Cells("Id_Mapa").Value
                        _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value

                    End If

                End If

                Dim Fm_c As New Frm_05_UbicXpro_UbicacionConProductos(_RowBodega, _Id_Mapa, _Codigo_Sector, _Codigo_Ubic)

                If Fm_c.Fx_Agregar_producto_ubicacion(Me, _Codigo) Then
                    Sb_ActGrilla_Ubicaciones()
                End If
            Else
                MessageBoxEx.Show(Me, "Código no existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Sb_Asignar_Ubicacion_Directa()
            End If

        End If


    End Sub
#End Region

    Private Sub Grilla_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Tecla As Keys = e.KeyValue


        Select Case _Tecla
            Case Keys.Enter

                e.SuppressKeyPress = False
                e.Handled = True

                If _Cabeza = "Stock_Minimo_Ubic" Or _Cabeza = "Stock_Maximo_Ubic" Then
                    'If Fx_Tiene_Permiso(Me, "") Then
                    Grilla.Columns(_Cabeza).ReadOnly = False
                    Grilla.BeginEdit(True)
                    'End If
                End If

            Case Keys.Delete
                e.Handled = True
                Eliminar_Fila()
        End Select


    End Sub

    Private Sub Grilla_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        'Dim _Codigo = _Fila.Cells("Codigo").Value

        Dim _Cabeza = Grilla.Columns(Grilla.CurrentCell.ColumnIndex).Name

        Dim _Codigo_Ubic = _Fila.Cells("Codigo_Ubic").Value
        Dim _Stock_Minimo_Ubic = NuloPorNro(_Fila.Cells("Stock_Minimo_Ubic").Value, 0)
        Dim _Stock_Maximo_Ubic = NuloPorNro(_Fila.Cells("Stock_Maximo_Ubic").Value, 0)

        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set " &
                       "Stock_Minimo_Ubic = " & De_Num_a_Tx_01(_Stock_Minimo_Ubic, False, 5) & "," &
                       "Stock_Maximo_Ubic = " & De_Num_a_Tx_01(_Stock_Maximo_Ubic, False, 5) & vbCrLf &
                       "Where Codigo = '" & _Codigo & "' And Codigo_Ubic = '" & _Codigo_Ubic & "'"

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)



    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    'Dim _Grilla As Object = CType(sender, DataGridView) 'CType(sender, DevComponents.DotNetBar.Controls.DataGridViewX)

                    Dim _Fila As DataGridViewRow = CType(sender, DataGridView).Rows(CType(sender, DataGridView).CurrentRow.Index)
                    Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

                    ShowContextMenu(Menu_Contextual_Ubicacion)

                End If

            End With

        End If

    End Sub

    Private Sub Btn_Mnu_Ubicacion_X_Defecto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ubicacion_X_Defecto.Click

        If Fx_Tiene_Permiso(Me, "Ubic0005") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Semilla = _Fila.Cells("Semilla").Value

            Dim _Msg As String

            If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then
                _Msg = "Esto cambiara la ubicación en el campo ubicación (DATOSUBIC) de la bodega en RANDOM" & vbCrLf & vbCrLf
            End If

            If MessageBoxEx.Show(Me, _Msg & "¿Esta seguro de cambiar la ubicación por defecto?", "Cambiar bodega por defecto", vbYesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Primaria = 0" & vbCrLf &
                               "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' And Codigo = '" & _Codigo & "'" & vbCrLf & vbCrLf &
                               "Update " & _Global_BaseBk & "Zw_Prod_Ubicacion Set Primaria = 1" & vbCrLf &
                               "Where Semilla = " & _Semilla

                If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                    Dim _Codigo_Ubic As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Prod_Ubicacion", "Codigo_Ubic", "Semilla = " & _Semilla)

                    If _Global_Row_Configuracion_General.Item("Utilizar_Ubicaciones_WCM") Then

                        Consulta_sql = "Update TABBOPR Set DATOSUBIC = '" & _Codigo_Ubic & "'" & vbCrLf &
                                       "Where EMPRESA = '" & _Empresa & "' AND KOSU = '" & _Sucursal & "' AND KOBO = '" & _Bodega & "' AND KOPR = '" & _Codigo & "'"
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    End If

                    MessageBoxEx.Show(Me, "La ubicación por defecto es: " & _Codigo_Ubic,
                                  "Cambio de ubicación por defecto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                Sb_ActGrilla_Ubicaciones()

            End If

        End If

    End Sub

    Private Sub Btn_Mnu_Pr_Estadistica_Producto_Click(sender As Object, e As EventArgs) Handles Btn_Mnu_Pr_Estadistica_Producto.Click
        _Producto_Op.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
    End Sub

    Private Sub Btn_Mnu_Ver_Sector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ver_Sector.Click
        Sb_Ver_Ubicaciones()
    End Sub

    Private Sub Btn_Mnu_Ver_Sector_En_Mapa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ver_Sector_En_Mapa.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Mapa = _Fila.Cells("Id_Mapa").Value
        Dim _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value
        Dim _Primaria = _Fila.Cells("Primaria").Value

        Consulta_sql = "SELECT * " & vbCrLf &
                       "FROM " & _Global_BaseBk & "Zw_WMS_Ubicaciones_Mapa_Enc" & vbCrLf &
                       "Where Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "' 
                        And Id_Mapa = " & _Id_Mapa

        Dim _RowMapa As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If Not IsNothing(_RowMapa) Then

            Dim Fm As New Frm_Formulario_Diseno_Mapa_Documentos(_RowMapa,
                                                                Frm_Formulario_Diseno_Mapa_Documentos._TipoDiseno.Mapa_Ver_Mapa)
            Fm.Pro_Codigo_Sector_Activo = _Codigo_Sector
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub
    Private Sub Btn_Mnu_Eliminar_Ubicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Eliminar_Ubicacion.Click
        Eliminar_Fila()
    End Sub
    Private Sub Btn_Imprimir_Ubicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir_Ubicacion.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Id_Mapa = _Fila.Cells("Id_Mapa").Value
        Dim _Codigo_Sector = _Fila.Cells("Codigo_Sector").Value
        Dim _Primaria = _Fila.Cells("Primaria").Value
        Dim _Codigo_Ubic = _Fila.Cells("Codigo_Ubic").Value

        Consulta_sql = "Select Cast(1 as Bit) As Chk,'" & _Codigo & "' As Codigo,'" & _Descripcion & "' As Descripcion"
        Dim _TblProductos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim Fm As New Frm_ImpBarras_PorProducto
        Fm.Codigo_Ubic = _Codigo_Ubic
        'Fm.Pro_Chk_Imprimir_Todas_Las_Ubicaciones = True
        Fm.Pro_Tbl_Filtro_Productos = _TblProductos
        Fm.Pro_Cantidad_Uno = True
        Fm.BtnBuscarProducto.Visible = False
        Fm.BtnLimpiar.Visible = False
        Fm.Grupo_Ubicaciones.Enabled = False
        Fm.Grupo_Lista_Precios.Enabled = True
        Fm.Btn_imprimir_Archivo.Visible = False
        Fm.Text = Fm.Text & " - Ubicación(" & _Codigo_Ubic & ")"
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

End Class
