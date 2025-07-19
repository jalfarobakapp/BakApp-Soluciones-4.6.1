'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Informe_Prox_Recep_VS_Comp_No_Desp

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String
    Dim _Tabla_Paso_Prox_Recepciones As String ' INFORME PROXIMAS RECEPCIONES
    Dim _Tabla_Paso_Comp_No_Despachados As String ' INFORME COMPROMISOS NO DESPACHADOS

    Dim _SqlFiltro_Prox_Recepciones As String
    Dim _SqlFiltro_Comp_No_Despachados As String

    Dim _Tbl_Productos As DataTable
    Dim _Tbl_Recepciones, _Tbl_Despachos As DataTable

    Dim _Filtro_Tido_Recepcion As String
    Dim _Filtro_Tido_Despacho As String

    Dim _Grilla_Seleccionada As Object

    Dim _Unidad As Integer

    Public ReadOnly Property Pro_Tbl_Productos() As DataTable
        Get
            Return _Tbl_Productos
        End Get
    End Property

    Public Sub New(ByVal Tabla_Paso As String, _
                   ByVal Tabla_Paso_Prox_Recepciones As String, _
                   ByVal Filtro_Tido_Recepcion As String, _
                   ByVal Tabla_Paso_Comp_No_Despachados As String, _
                   ByVal Filtro_Tido_Despacho As String, _
                   ByVal Unidad As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tabla_Paso = Tabla_Paso
        _Tabla_Paso_Prox_Recepciones = Tabla_Paso_Prox_Recepciones
        _Tabla_Paso_Comp_No_Despachados = Tabla_Paso_Comp_No_Despachados

        _Filtro_Tido_Recepcion = Filtro_Tido_Recepcion
        _Filtro_Tido_Despacho = Filtro_Tido_Despacho

        _Unidad = Unidad

        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Recepcion, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)
        Sb_Formato_Generico_Grilla(Grilla_Despachos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Informe_Prox_Recep_VS_Comp_No_Desp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Recepcion.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Despachos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Recepcion.RowEnter, AddressOf Grilla_Recepcion_RowEnter
        AddHandler Grilla_Despachos.RowEnter, AddressOf Grilla_Despachos_RowEnter

        AddHandler Grilla_Productos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Productos.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Recepcion.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Recepcion.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Despachos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Despachos.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Rdb_Ver_Cantidad.CheckedChanged, AddressOf Rdb_CheckStateChanged
        AddHandler Rdb_Ver_Precios.CheckedChanged, AddressOf Rdb_CheckStateChanged

        Sb_Formato_Grilla()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Dim _Descripcion As String = Trim(Txt_Filtro_Productos.Text)
        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Descripcion), "KOPRCT_+NOKOPR LIKE '%")
        Dim _Condicion As String = Space(1) & "And KOPRCT_+NOKOPR Like '%" & _Cadena & "%'"
        '-DESPNOFAC
        Consulta_sql = "Update " & _Tabla_Paso & vbCrLf & _
                       "Set STK_FIS_BOD = Isnull((Select Sum(STFI" & _Unidad & ") From MAEST Where EMPRESA = '" & Mod_Empresa & "' AND KOPR = KOPRCT_),0)," & _
                       "STK_DESPNOFAC = Isnull((Select Sum(DESPNOFAC" & _Unidad & ") From MAEST Where EMPRESA = '" & Mod_Empresa & "' AND KOPR = KOPRCT_),0)," & _
                       "STK_RECENOFAC = Isnull((Select Sum(RECENOFAC" & _Unidad & ") From MAEST Where EMPRESA = '" & Mod_Empresa & "' AND KOPR = KOPRCT_),0)" & _
                       vbCrLf & _
                       vbCrLf & _
                       "Select * From " & _Tabla_Paso & " Where 1 > 0" & _Condicion & vbCrLf & _
                       "Select * From " & _Tabla_Paso_Prox_Recepciones & vbCrLf & _
                       "Where " & _Filtro_Tido_Recepcion & vbCrLf & _
                       "Select * From " & _Tabla_Paso_Comp_No_Despachados & vbCrLf & _
                       "Where " & _Filtro_Tido_Despacho


        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Tbl_Productos = _Ds.Tables(0)
        _Tbl_Recepciones = _Ds.Tables(1)
        _Tbl_Despachos = _Ds.Tables(2)

        _Ds.Relations.Add("Rel_Recepciones", _
                         _Ds.Tables("Table").Columns("KOPRCT_"), _
                         _Ds.Tables("Table1").Columns("KOPRCT"), False)

        _Ds.Relations.Add("Rel_Despachos", _
                         _Ds.Tables("Table").Columns("KOPRCT_"), _
                         _Ds.Tables("Table2").Columns("KOPRCT"), False)


        'Muestra segunda relacion
        Grilla_Productos.DataSource = _Ds
        Grilla_Productos.DataMember = "Table"

        Grilla_Recepcion.DataSource = _Ds
        Grilla_Recepcion.DataMember = "Table.Rel_Recepciones"

        Grilla_Despachos.DataSource = _Ds
        Grilla_Despachos.DataMember = "Table.Rel_Despachos"

    End Sub

    Sub Sb_Formato_Grilla()

        OcultarEncabezadoGrilla(Grilla_Productos, False)
        OcultarEncabezadoGrilla(Grilla_Recepcion, False)
        OcultarEncabezadoGrilla(Grilla_Despachos, False)

        With Grilla_Productos

            '.DataSource = _Tbl_Detalle

            'OcultarEncabezadoGrilla(Grilla_Productos)
            .Columns("KOPRCT_").Width = 90
            .Columns("KOPRCT_").HeaderText = "Código"
            .Columns("KOPRCT_").Visible = True
            .Columns("KOPRCT_").DisplayIndex = 0

            .Columns("NOKOPR").Width = 240
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = 1

            If Rdb_Ver_Cantidad.Checked Then

                .Columns("QTY_PEND_X_REC").Width = 80
                .Columns("QTY_PEND_X_REC").HeaderText = "Qty Pdte. X Recepcionar"
                .Columns("QTY_PEND_X_REC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("QTY_PEND_X_REC").DefaultCellStyle.Format = "###,##"
                .Columns("QTY_PEND_X_REC").Visible = True
                .Columns("QTY_PEND_X_REC").DisplayIndex = 2

                .Columns("QTY_PEND_X_DESP").Width = 80
                .Columns("QTY_PEND_X_DESP").HeaderText = "Qty Pdte. X Despachar"
                .Columns("QTY_PEND_X_DESP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("QTY_PEND_X_DESP").DefaultCellStyle.Format = "###,##"
                .Columns("QTY_PEND_X_DESP").Visible = True
                .Columns("QTY_PEND_X_DESP").DisplayIndex = 3

                .Columns("STK_FIS_BOD").Width = 60
                .Columns("STK_FIS_BOD").HeaderText = "Stock Fisico"
                .Columns("STK_FIS_BOD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("STK_FIS_BOD").DefaultCellStyle.Format = "###,##"
                .Columns("STK_FIS_BOD").Visible = True
                .Columns("STK_FIS_BOD").DisplayIndex = 4

                .Columns("STK_DESPNOFAC").Width = 70
                .Columns("STK_DESPNOFAC").HeaderText = "Stock Desp/s/Fac."
                .Columns("STK_DESPNOFAC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("STK_DESPNOFAC").DefaultCellStyle.Format = "###,##"
                .Columns("STK_DESPNOFAC").Visible = True
                .Columns("STK_DESPNOFAC").DisplayIndex = 5

                .Columns("STK_RECENOFAC").Width = 70
                .Columns("STK_RECENOFAC").HeaderText = "Stock Rece/s/Fac."
                .Columns("STK_RECENOFAC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("STK_RECENOFAC").DefaultCellStyle.Format = "###,##"
                .Columns("STK_RECENOFAC").Visible = True
                .Columns("STK_RECENOFAC").DisplayIndex = 6

                '--TOT_SALDOxPRECIOREAL_PEND_X_REC,TOT_SALDOxPM_TRANS_PEND_X_REC
                '--TOT_SALDOxPDESPIOREAL_PEND_X_DESP,TOT_SALDOxPM_TRANS_PEND_X_DESP

            ElseIf Rdb_Ver_Precios.Checked Then

                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").Width = 90
                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").HeaderText = "Costo X Recep."
                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").Visible = True
                .Columns("TOT_SALDOxPRECIOREAL_PEND_X_REC").DisplayIndex = 2

                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").Width = 90
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").HeaderText = "PM X Recep"
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").Visible = True
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_REC").DisplayIndex = 3

                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").Width = 90
                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").HeaderText = "Precio X Desp."
                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").Visible = True
                .Columns("TOT_SALDOxPDESPIOREAL_PEND_X_DESP").DisplayIndex = 4

                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").Width = 90
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").HeaderText = "PM X Desp."
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").Visible = True
                .Columns("TOT_SALDOxPM_TRANS_PEND_X_DESP").DisplayIndex = 5

            End If

        End With



        With Grilla_Recepcion

            .Columns("BOSULIDO").Width = 30
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = 0

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "Td"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 1

            .Columns("NUDO").Width = 80
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 2

            .Columns("NOKOEN").Width = 280 + 70
            .Columns("NOKOEN").HeaderText = "Proveedor"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = 3

            If Rdb_Ver_Cantidad.Checked Then

                .Columns("CAPRCO" & _Unidad).Width = 70
                .Columns("CAPRCO" & _Unidad).HeaderText = "Cant."
                .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("CAPRCO" & _Unidad).Visible = True
                .Columns("CAPRCO" & _Unidad).DisplayIndex = 4

                .Columns("CAPREX" & _Unidad).Width = 70
                .Columns("CAPREX" & _Unidad).HeaderText = "Recep."
                .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("CAPREX" & _Unidad).Visible = True
                .Columns("CAPREX" & _Unidad).DisplayIndex = 5

                .Columns("SALDO_Ud" & _Unidad).Width = 70
                .Columns("SALDO_Ud" & _Unidad).HeaderText = "Pend."
                .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("SALDO_Ud" & _Unidad).Visible = True
                .Columns("SALDO_Ud" & _Unidad).DisplayIndex = 6

            ElseIf Rdb_Ver_Precios.Checked Then

                .Columns("TOT_SALDOxPRECIOREAL").Width = 105
                .Columns("TOT_SALDOxPRECIOREAL").HeaderText = "Total Cant. X Costo"
                .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPRECIOREAL").Visible = True
                .Columns("TOT_SALDOxPRECIOREAL").DisplayIndex = 4

                .Columns("TOT_SALDOxPM_TRANS").Width = 105
                .Columns("TOT_SALDOxPM_TRANS").HeaderText = "Total Cant. X PM"
                .Columns("TOT_SALDOxPM_TRANS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPM_TRANS").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPM_TRANS").Visible = True
                .Columns("TOT_SALDOxPM_TRANS").DisplayIndex = 5

            End If


            '.Columns("STFI" & _Unidad).Width = 70
            '.Columns("STFI" & _Unidad).HeaderText = "Stock"
            '.Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            '.Columns("STFI" & _Unidad).Visible = True
            '.Columns("STFI" & _Unidad).DisplayIndex = 7


        End With

        With Grilla_Despachos

            .Columns("BOSULIDO").Width = 30
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            .Columns("BOSULIDO").DisplayIndex = 0

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "Td"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 1

            .Columns("NUDO").Width = 80
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 2

            .Columns("NOKOEN").Width = 280 + 70
            .Columns("NOKOEN").HeaderText = "Cliente"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = 3

            If Rdb_Ver_Cantidad.Checked Then

                .Columns("CAPRCO" & _Unidad).Width = 70
                .Columns("CAPRCO" & _Unidad).HeaderText = "Cant."
                .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("CAPRCO" & _Unidad).Visible = True
                .Columns("CAPRCO" & _Unidad).DisplayIndex = 4

                .Columns("CAPREX" & _Unidad).Width = 70
                .Columns("CAPREX" & _Unidad).HeaderText = "Recep."
                .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("CAPREX" & _Unidad).Visible = True
                .Columns("CAPREX" & _Unidad).DisplayIndex = 5

                .Columns("SALDO_Ud" & _Unidad).Width = 70
                .Columns("SALDO_Ud" & _Unidad).HeaderText = "Pend."
                .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Format = "###,##"
                .Columns("SALDO_Ud" & _Unidad).Visible = True
                .Columns("SALDO_Ud" & _Unidad).DisplayIndex = 6

            ElseIf Rdb_Ver_Precios.Checked Then

                .Columns("TOT_SALDOxPRECIOREAL").Width = 105
                .Columns("TOT_SALDOxPRECIOREAL").HeaderText = "Total Cant. X Precio"
                .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPRECIOREAL").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPRECIOREAL").Visible = True
                .Columns("TOT_SALDOxPRECIOREAL").DisplayIndex = 4

                .Columns("TOT_SALDOxPM_TRANS").Width = 105
                .Columns("TOT_SALDOxPM_TRANS").HeaderText = "Total Cant. X PM"
                .Columns("TOT_SALDOxPM_TRANS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("TOT_SALDOxPM_TRANS").DefaultCellStyle.Format = "$ ###,##"
                .Columns("TOT_SALDOxPM_TRANS").Visible = True
                .Columns("TOT_SALDOxPM_TRANS").DisplayIndex = 5

            End If
            '.Columns("STFI" & _Unidad).Width = 70
            '.Columns("STFI" & _Unidad).HeaderText = "Stock"
            '.Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            '.Columns("STFI" & _Unidad).Visible = True
            '.Columns("STFI" & _Unidad).DisplayIndex = 7

        End With

    End Sub

    Private Sub Frm_Informe_Prox_Recep_VS_Comp_No_Desp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grillas()
        End If
    End Sub

    Private Sub Grilla_Recepcion_RowEnter()

        For Each _Fila As DataGridViewRow In Grilla_Recepcion.Rows

            _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
            _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.Red

        Next

    End Sub

    Private Sub Grilla_Despachos_RowEnter()

        For Each _Fila As DataGridViewRow In Grilla_Despachos.Rows

            _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
            _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.Red

        Next

    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim _Nombre_Grilla = CType(sender, Control).Name

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If _Nombre_Grilla = "Grilla_Productos" Then
                        Btn_Estadisticas_Producto.Visible = True
                        Btn_Ver_Documento.Visible = False
                    Else
                        Btn_Estadisticas_Producto.Visible = False
                        Btn_Ver_Documento.Visible = True
                        _Grilla_Seleccionada = sender
                    End If

                    ShowContextMenu(Menu_Contextual)

                End If
            End With
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Nombre_Grilla = CType(sender, Control).Name

        If _Nombre_Grilla = "Grilla_Productos" Then
            Btn_Estadisticas_Producto.Visible = True
            Btn_Ver_Documento.Visible = False
        Else
            Btn_Estadisticas_Producto.Visible = False
            Btn_Ver_Documento.Visible = True
        End If

        _Grilla_Seleccionada = sender

        ShowContextMenu(Menu_Contextual)

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)

        Dim _Kopr As String = _Fila.Cells("KOPRCT_").Value
        'Dim _Tido As String = _Fila.Cells("TIDO").Value
        'Dim _Endo As String = _Fila.Cells("ENDO").Value


        'Dim _Tipotransa As String = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")

        'If _Tipotransa = "C" Then
        'Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
        'ElseIf _Tipotransa = "V" Then
        'Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        'Else
        Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr)
        'End If

    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click

        Dim Grilla As DataGridView = CType(_Grilla_Seleccionada, DataGridView)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
        Dim _Idmaeddo = _Fila.Cells("IDMAEDDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Idrst = _Idmaeddo
        Fm.Marcar_Stock_VS_Cantidad = True
        Fm.Marcar_Grilla_Pendientes = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Excel_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel_Productos.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Productos, Me, "Recepiones_VS_Despacho")
    End Sub

    Private Sub Excel_Recepciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Excel_Recepciones.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Recepciones, Me, "Prox_Recepciones")
    End Sub

    Private Sub Excel_Despachos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Excel_Despachos.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Despachos, Me, "Comp_No_Despachados")
    End Sub

    Private Sub Txt_Filtro_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Filtro_Productos.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grillas()
        End If
    End Sub

    Private Sub Txt_Filtro_Productos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Filtro_Productos.TextChanged
        If String.IsNullOrEmpty(Txt_Filtro_Productos.Text) Then Sb_Actualizar_Grillas()
    End Sub

    Private Sub Rdb_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked Then
            Sb_Formato_Grilla()
        End If
    End Sub

End Class