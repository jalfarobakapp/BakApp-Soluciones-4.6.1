'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Informe_Composicion_Stock_X_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String
    Dim _SqlFiltro As String

    Dim _Ds_Informes As DataSet
    Dim _Row_Totales As DataRow
    Dim _Tbl_Informe_X_Sucursal As DataTable
    Dim _Tbl_Informe_X_Familias As DataTable
    Dim _Tbl_Informe_X_Productos As DataTable

    Private _dv As New DataView

    Public Property Pro_Ds_Informes() As DataSet
        Get
            Return _Ds_Informes
        End Get
        Set(ByVal value As DataSet)

            _Ds_Informes = value

            _Row_Totales = _Ds_Informes.Tables(0).Rows(0)
            _Tbl_Informe_X_Sucursal = _Ds_Informes.Tables(1)
            _Tbl_Informe_X_Familias = _Ds_Informes.Tables(2)
            _Tbl_Informe_X_Productos = _Ds_Informes.Tables(3)

        End Set
    End Property

    Public Property Pro_Tbl_Informe_X_Sucursal() As DataTable
        Get
            Return _Tbl_Informe_X_Sucursal
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Informe_X_Sucursal = value
        End Set
    End Property

    Public Property Pro_Tbl_Informe_X_Familias() As DataTable
        Get
            Return _Tbl_Informe_X_Familias
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Informe_X_Familias = value
        End Set
    End Property

    Public Property Pro_Tbl_Informe_X_Productos() As DataTable
        Get
            Return _Tbl_Informe_X_Productos
        End Get
        Set(ByVal value As DataTable)
            _Tbl_Informe_X_Productos = value
        End Set
    End Property

    Public Property Pro_Dv() As DataView
        Get
            Return _dv
        End Get
        Set(ByVal value As DataView)
            _dv = value
        End Set
    End Property

    Public Property Pro_Rdb_Saldo_Con_saldo_Positivo() As Boolean
        Get
            Return Rdb_Saldo_Con_saldo_Positivo.Checked
        End Get
        Set(ByVal value As Boolean)
            Rdb_Saldo_Con_saldo_Positivo.Checked = value
        End Set
    End Property

    Public Property Pro_Rdb_Saldo_Con_y_sin_saldo() As Boolean
        Get
            Return Rdb_Saldo_Con_y_sin_saldo.Checked
        End Get
        Set(ByVal value As Boolean)
            Rdb_Saldo_Con_y_sin_saldo.Checked = value
        End Set
    End Property

    Public Property Pro_Rdb_Saldo_Distinto_de_cero() As Boolean
        Get
            Return Rdb_Saldo_Distinto_de_cero.Checked
        End Get
        Set(ByVal value As Boolean)
            Rdb_Saldo_Distinto_de_cero.Checked = value
        End Set
    End Property


    Public Sub New(ByVal SqlFiltro As String, _
                   ByVal Nombre_Tabla_Paso As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _SqlFiltro = SqlFiltro
        _Tabla_Paso = Nombre_Tabla_Paso
        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)


        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Actualizar.ForeColor = Color.White
        End If

    End Sub


    Private Sub Frm_Informe_Composicion_Stock_X_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sb_Actualizar_Grilla()

        AddHandler Btn_Actualizar.Click, AddressOf Sb_Actualizar_Grilla
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

        AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

        AddHandler Rdb_Saldo_Con_saldo_Positivo.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Saldo_Con_y_sin_saldo.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Saldo_Distinto_de_cero.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

    End Sub

    Sub Sb_Actualizar_Grilla()

        Try

            Me.Enabled = True
            Me.Cursor = Cursors.WaitCursor

            Dim _Condicion As String

            If Rdb_Saldo_Con_y_sin_saldo.Checked Then
                _Condicion = String.Empty
            ElseIf Rdb_Saldo_Con_saldo_Positivo.Checked Then
                _Condicion = "And STFI > 0"
            ElseIf Rdb_Saldo_Distinto_de_cero.Checked Then
                _Condicion = "And STFI <> 0"
            End If

            Dim _Descripcion As String = Trim(Txt_Filtro_Productos.Text)
            Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(_Descripcion), "KOPR+NOKOPR LIKE '%")
            _Condicion += vbCrLf & "And KOPR+NOKOPR Like '%" & _Cadena & "%'"

            Consulta_sql = "Select KOPR,NOKOPR,KOBO,BODEGA," & _
                           "UNIDAD,STFI,PRMEDIO,VALSTOCK," & _
                           "FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO,CLALIBPR,CLAS_LIBRE" & vbCrLf & _
                           "From " & _Tabla_Paso & vbCrLf & _
                           "Where 1 > 0 " & _SqlFiltro & vbCrLf & _
                           _Condicion & vbCrLf & _
                           "Order by KOPR,KOBO"

            _Tbl_Informe_X_Productos = _Sql.Fx_Get_Tablas(Consulta_sql)

            With Grilla

                .DataSource = _Tbl_Informe_X_Productos

                'If Not String.IsNullOrEmpty(Trim(_Kosu) & Trim(_Kofm)) Then
                '_dv.RowFilter = String.Format("KOSU+FMPR Like '%{0}%'", _Kosu & _Kofm)
                'End If

                OcultarEncabezadoGrilla(Grilla) ', True)

                .Columns("KOPR").Width = 85
                .Columns("KOPR").HeaderText = "Código"
                .Columns("KOPR").Visible = True

                .Columns("NOKOPR").Width = 200
                .Columns("NOKOPR").HeaderText = "Descripción"
                .Columns("NOKOPR").Visible = True

                .Columns("KOBO").Width = 30
                .Columns("KOBO").HeaderText = "Cód"
                .Columns("KOBO").Visible = True

                .Columns("BODEGA").Width = 130
                .Columns("BODEGA").HeaderText = "Bodega"
                .Columns("BODEGA").Visible = True

                .Columns("UNIDAD").Width = 30
                .Columns("UNIDAD").HeaderText = "UD"
                .Columns("UNIDAD").Visible = True

                .Columns("STFI").Width = 50
                .Columns("STFI").HeaderText = "Stock"
                .Columns("STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("STFI").DefaultCellStyle.Format = "###,##"
                .Columns("STFI").Visible = True

                .Columns("PRMEDIO").Width = 80
                .Columns("PRMEDIO").HeaderText = "$ Precio Medio"
                .Columns("PRMEDIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("PRMEDIO").DefaultCellStyle.Format = "$ ###,##"
                .Columns("PRMEDIO").Visible = True

                .Columns("VALSTOCK").Width = 80
                .Columns("VALSTOCK").HeaderText = "Valor Stock $"
                .Columns("VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("VALSTOCK").DefaultCellStyle.Format = "$ ###,##"
                .Columns("VALSTOCK").Visible = True

            End With

            Consulta_sql = "Select SUM(STFI) AS STFI,SUM(VALSTOCK) AS VALSTOCK" & vbCrLf & _
                           "From " & _Tabla_Paso & vbCrLf & _
                           "Where 1 > 0 " & _SqlFiltro & vbCrLf & _
                           _Condicion

            Dim _Row_Totales As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Stfi, _Valstock As Double

            If Not _Row_Totales Is Nothing Then
                _Stfi = _Row_Totales.Item("STFI")
                _Valstock = _Row_Totales.Item("VALSTOCK")
            End If

            Lbl_Total_Stock.Text = FormatNumber(_Stfi, 0)
            Lbl_Total_Valirzado.Text = FormatCurrency(_Valstock, 0)

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_Ver_Informacion_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Informacion_Producto.Click

        If Fx_Tiene_Permiso(Me, "Prod009") Then

            Dim _Codigo As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("KOPR").Value

            Dim Fm As New Frm_EstadisticaProducto(_Codigo)
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

    End Sub

    Private Sub Btn_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar.Click

        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image, _
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)


        End With

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Producto)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe_X_Productos, Me, "Inf_X_Productos")
    End Sub

    Private Sub Sb_Frm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Sb_Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Txt_Filtro_Productos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Filtro_Productos.TextChanged
        If String.IsNullOrEmpty(Txt_Filtro_Productos.Text) Then Sb_Actualizar_Grilla()
    End Sub

    Private Sub Txt_Filtro_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Filtro_Productos.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla()
        End If
    End Sub
End Class