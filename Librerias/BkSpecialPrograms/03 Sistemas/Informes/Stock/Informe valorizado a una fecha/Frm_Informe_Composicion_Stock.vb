'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Informe_Composicion_Stock

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tabla_Paso As String
    Dim _SqlFiltro As String

    Dim _Ds_Informes As DataSet
    Dim _Row_Totales As DataRow
    Dim _Tbl_Informe As DataTable

    Dim _Fl_Sucursales = String.Empty
    Dim _Fl_Bodegas = String.Empty
    Dim _Fl_Obsolencias = String.Empty
    Dim _Fl_Familias = String.Empty


    Dim _Kosu As String

    Private _dv As New DataView
    Dim _Informe As Enum_Informe

    Enum Enum_Informe
        Sucursal
        Bodega
        Super_Familia
        Obsolencia
    End Enum

    Dim _Nombre_Excel As String
    Dim _Correr_a_la_derecha As Boolean

    Dim _Top, _Left As Integer

    Public Property Pro_Fl_Sucursales() As String
        Get
            Return _Fl_Sucursales
        End Get
        Set(ByVal value As String)
            _Fl_Sucursales = value
        End Set
    End Property

    Public Property Pro_Fl_Bodegas() As String
        Get
            Return _Fl_Bodegas
        End Get
        Set(ByVal value As String)
            _Fl_Bodegas = value
        End Set
    End Property

    Public Property Pro_Fl_Obsolencia() As String
        Get
            Return _Fl_Obsolencias
        End Get
        Set(ByVal value As String)
            _Fl_Obsolencias = value
        End Set
    End Property

    Public Property Pro_Fl_Familias() As String
        Get
            Return _Fl_Familias
        End Get
        Set(ByVal value As String)
            _Fl_Familias = value
        End Set
    End Property

    Public Property Pro_Top() As Integer
        Get
            Return Me.Top
        End Get
        Set(ByVal value As Integer)
            _Top = value
        End Set
    End Property

    Public Property Pro_Left() As Integer
        Get
            Return Me.Left
        End Get
        Set(ByVal value As Integer)
            _Left = value
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

    Public Property Pro_Dv() As DataView
        Get
            Return _dv
        End Get
        Set(ByVal value As DataView)
            _dv = value
        End Set
    End Property


    Public Sub New(ByVal Informe As Enum_Informe, _
                   ByVal Nombre_Tabla_Paso As String, _
                   Optional ByVal Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Tabla_Paso = Nombre_Tabla_Paso
        '_SqlFiltro = SqlFiltro
        _Informe = Informe
        _Correr_a_la_derecha = Correr_a_la_derecha

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Actualizar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Informe_Composicion_Stock_X_Familia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _SqlFiltro = _Fl_Sucursales & vbCrLf & _
                     _Fl_Bodegas & vbCrLf & _
                     _Fl_Familias & vbCrLf & _
                     _Fl_Obsolencias

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 15
            Me.Left = _Left + 15
        End If

        Btn_Informe_X_Bodega.Visible = String.IsNullOrEmpty(_Fl_Bodegas)
        Btn_Informe_X_Familia.Visible = String.IsNullOrEmpty(_Fl_Familias)
        Btn_Informe_X_Obsolencia.Visible = String.IsNullOrEmpty(_Fl_Obsolencias)

        Select Case _Informe
            Case Enum_Informe.Sucursal

                Sb_Actualizar_Grilla_Sucursal()
                AddHandler Btn_Actualizar.Click, AddressOf Sb_Actualizar_Grilla_Sucursal
                _Nombre_Excel = "Inf_X_Sucursal"

            Case Enum_Informe.Bodega

                Sb_Actualizar_Grilla_Bodega()
                AddHandler Btn_Actualizar.Click, AddressOf Sb_Actualizar_Grilla_Bodega
                Btn_Informe_X_Bodega.Visible = False
                _Nombre_Excel = "Inf_X_Bodega"

                AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

            Case Enum_Informe.Super_Familia

                Sb_Actualizar_Grilla_Super_Familia()
                AddHandler Btn_Actualizar.Click, AddressOf Sb_Actualizar_Grilla_Super_Familia
                Btn_Informe_X_Familia.Visible = False
                _Nombre_Excel = "Inf_X_Familia"

                AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

            Case Enum_Informe.Obsolencia

                Sb_Actualizar_Grilla_Obsolencia()
                AddHandler Btn_Actualizar.Click, AddressOf Sb_Actualizar_Grilla_Obsolencia

                Btn_Informe_X_Obsolencia.Visible = False

                _Nombre_Excel = "Inf_X_Obsolencia"

                AddHandler Me.KeyDown, AddressOf Sb_Frm_KeyDown

        End Select

        AddHandler Rdb_Saldo_Con_saldo_Positivo.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Saldo_Con_y_sin_saldo.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged
        AddHandler Rdb_Saldo_Distinto_de_cero.CheckedChanged, AddressOf Sb_Rdb_CheckedChanged

        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown

    End Sub

    Sub Sb_Actualizar_Grilla_Sucursal()

        Dim _Condicion As String = Fx_Saldo_Producto()

        Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_X_Sucursal
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#FILTRO#", _SqlFiltro & vbCrLf & _Condicion)

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        'Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 10), Color.AliceBlue, True)
        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOSU").Width = 40
            .Columns("KOSU").HeaderText = "Cód."
            .Columns("KOSU").Visible = True

            .Columns("SUCURSAL").Width = 230
            .Columns("SUCURSAL").HeaderText = "Sucursal"
            .Columns("SUCURSAL").Visible = True

            .Columns("STFI").Width = 110
            .Columns("STFI").HeaderText = "Stock"
            .Columns("STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI").DefaultCellStyle.Format = "###,##"
            .Columns("STFI").Visible = True

            .Columns("PORC_STFI").Width = 70
            .Columns("PORC_STFI").HeaderText = "%"
            .Columns("PORC_STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_STFI").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_STFI").Visible = True

            .Columns("VALSTOCK").Width = 120
            .Columns("VALSTOCK").HeaderText = "Valor Stock $"
            .Columns("VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALSTOCK").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALSTOCK").Visible = True

            .Columns("PORC_VALSTOCK").Width = 70
            .Columns("PORC_VALSTOCK").HeaderText = "%"
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_VALSTOCK").Visible = True

        End With

        'Dim _Stfi, _Valstock As Double

        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '_Stfi += _Fila.Cells("STFI").Value
        '_Valstock += _Fila.Cells("VALSTOCK").Value

        'Next

        'Lbl_Total_Cantidad.Text = FormatNumber(_Stfi, 0)
        'Lbl_total_Valorizado.Text = FormatCurrency(_Valstock, 0)

    End Sub

    Sub Sb_Actualizar_Grilla_Bodega()

        Dim _Condicion As String = Fx_Saldo_Producto()

        Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_X_Bodega
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#FILTRO#", _SqlFiltro & vbCrLf & _Condicion)

        _Tbl_Informe = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("KOBO").Width = 40
            .Columns("KOBO").HeaderText = "Cód."
            .Columns("KOBO").Visible = True

            .Columns("BODEGA").Width = 230
            .Columns("BODEGA").HeaderText = "Bodega"
            .Columns("BODEGA").Visible = True

            .Columns("STFI").Width = 110
            .Columns("STFI").HeaderText = "Stock"
            .Columns("STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI").DefaultCellStyle.Format = "###,##"
            .Columns("STFI").Visible = True

            .Columns("PORC_STFI").Width = 70
            .Columns("PORC_STFI").HeaderText = "%"
            .Columns("PORC_STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_STFI").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_STFI").Visible = True

            .Columns("VALSTOCK").Width = 120
            .Columns("VALSTOCK").HeaderText = "Valor Stock $"
            .Columns("VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALSTOCK").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALSTOCK").Visible = True

            .Columns("PORC_VALSTOCK").Width = 70
            .Columns("PORC_VALSTOCK").HeaderText = "%"
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_VALSTOCK").Visible = True

        End With

        'Dim _Stfi, _Valstock As Double

        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '_Stfi += _Fila.Cells("STFI").Value
        '_Valstock += _Fila.Cells("VALSTOCK").Value

        'Next

        'Lbl_Total_Cantidad.Text = FormatNumber(_Stfi, 0)
        'Lbl_total_Valorizado.Text = FormatCurrency(_Valstock, 0)

    End Sub

    Sub Sb_Actualizar_Grilla_Super_Familia()

        Dim _Condicion As String = Fx_Saldo_Producto()

        Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_X_Familia
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#FILTRO#", _SqlFiltro & vbCrLf & _Condicion)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        If String.IsNullOrEmpty(_Fl_Sucursales) Then
            _Tbl_Informe = _Ds.Tables(0)
        Else
            _Tbl_Informe = _Ds.Tables(1)
        End If

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("FMPR").Width = 40
            .Columns("FMPR").HeaderText = "Cód."
            .Columns("FMPR").Visible = True

            .Columns("SUPER_FAMILIA").Width = 200
            .Columns("SUPER_FAMILIA").HeaderText = "Super Familia"
            .Columns("SUPER_FAMILIA").Visible = True

            .Columns("STFI").Width = 100
            .Columns("STFI").HeaderText = "Stock"
            .Columns("STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI").DefaultCellStyle.Format = "###,##"
            .Columns("STFI").Visible = True

            .Columns("PORC_STFI").Width = 60
            .Columns("PORC_STFI").HeaderText = "%"
            .Columns("PORC_STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_STFI").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_STFI").Visible = True

            .Columns("VALSTOCK").Width = 120
            .Columns("VALSTOCK").HeaderText = "Valor Stock $"
            .Columns("VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALSTOCK").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALSTOCK").Visible = True

            .Columns("PORC_VALSTOCK").Width = 60
            .Columns("PORC_VALSTOCK").HeaderText = "%"
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_VALSTOCK").Visible = True

        End With

        'If Not String.IsNullOrEmpty(Trim(_Kosu) & Trim(_Kosu)) Then
        '_dv.RowFilter = String.Format("KOSU Like '%{0}%'", _Kosu)
        'End If

    End Sub

    Sub Sb_Actualizar_Grilla_Obsolencia()

        Dim _Condicion As String = Fx_Saldo_Producto()

        Consulta_sql = My.Resources.Recursos_Stockval.SQLQuery_Informe_Obsolencia
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Tabla_Paso)
        Consulta_sql = Replace(Consulta_sql, "#FILTRO#", _SqlFiltro & vbCrLf & _Condicion)

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        If String.IsNullOrEmpty(_SqlFiltro) Then
            _Tbl_Informe = _Ds.Tables(0)
        Else
            _Tbl_Informe = _Ds.Tables(1)
        End If

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, True)

            .Columns("COD_OBSOLENCIA").Width = 40
            .Columns("COD_OBSOLENCIA").HeaderText = "Cód."
            .Columns("COD_OBSOLENCIA").Visible = True

            .Columns("OBSOLENCIA").Width = 230
            .Columns("OBSOLENCIA").HeaderText = "Ventas periodos"
            .Columns("OBSOLENCIA").Visible = True

            .Columns("STFI").Width = 110
            .Columns("STFI").HeaderText = "Stock"
            .Columns("STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI").DefaultCellStyle.Format = "###,##"
            .Columns("STFI").Visible = True

            .Columns("PORC_STFI").Width = 70
            .Columns("PORC_STFI").HeaderText = "%"
            .Columns("PORC_STFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_STFI").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_STFI").Visible = True

            .Columns("VALSTOCK").Width = 120
            .Columns("VALSTOCK").HeaderText = "Valor Stock $"
            .Columns("VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("VALSTOCK").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VALSTOCK").Visible = True

            .Columns("PORC_VALSTOCK").Width = 70
            .Columns("PORC_VALSTOCK").HeaderText = "%"
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PORC_VALSTOCK").DefaultCellStyle.Format = "% ###,##.##"
            .Columns("PORC_VALSTOCK").Visible = True

        End With

        'Dim _Stfi, _Valstock As Double

        'For Each _Fila As DataGridViewRow In Grilla.Rows

        '_Stfi += _Fila.Cells("STFI").Value
        '_Valstock += _Fila.Cells("VALSTOCK").Value

        'Next

        'Lbl_Total_Cantidad.Text = FormatNumber(_Stfi, 0)
        'Lbl_total_Valorizado.Text = FormatCurrency(_Valstock, 0)

    End Sub


    Private Sub Btn_Informe_X_Bodega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Bodega.Click
        ' Dim _Fl = Fx_Traer_Filtro_Bodegas()
        Sb_Revisar_Sub_Informe(Enum_Informe.Bodega) ', _Fl_Sucursales, _Fl, _Fl_Familias, _Fl_Obsolencias)
    End Sub

    Private Sub Btn_Informe_X_Familia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Familia.Click
        'Dim _Fl = Fx_Traer_Filtro_Familias()
        Sb_Revisar_Sub_Informe(Enum_Informe.Super_Familia) ', _Fl_Sucursales, _Fl_Bodegas, _Fl, _Fl_Obsolencias)
    End Sub

    Private Sub Btn_Informe_X_Obsolencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Obsolencia.Click
        'Dim _Fl = Fx_Traer_Filtro_Obsolencias()
        Sb_Revisar_Sub_Informe(Enum_Informe.Obsolencia) ', _Fl_Sucursales, _Fl_Bodegas, _Fl_Familias, _Fl)
    End Sub

    Private Sub Btn_Informe_X_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_X_Productos.Click

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Familias = _Fl_Familias
        Dim Fl_Obsolencias = _Fl_Obsolencias

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Familias = Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Obsolencia
                Fl_Obsolencias = Fx_Traer_Filtro_Obsolencias()
        End Select


        Dim _SqlFiltro = Fl_Sucursales & vbCrLf & _
                         Fl_Bodegas & vbCrLf & _
                         Fl_Familias & vbCrLf & _
                         Fl_Obsolencias

        Dim Fm As New Frm_Informe_Composicion_Stock_X_Productos(_SqlFiltro, _Tabla_Paso)

        Fm.Pro_Rdb_Saldo_Con_saldo_Positivo = Rdb_Saldo_Con_saldo_Positivo.Checked
        Fm.Pro_Rdb_Saldo_Con_y_sin_saldo = Rdb_Saldo_Con_y_sin_saldo.Checked
        Fm.Pro_Rdb_Saldo_Distinto_de_cero = Rdb_Saldo_Distinto_de_cero.Checked

        Fm.Text = "Detalle de productos"

        Fm.ShowDialog(Me)
        Fm.Dispose()


    End Sub



    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, _Nombre_Excel)
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ShowContextMenu(Menu_Contextual_Informe)
    End Sub

    Private Sub Sb_Frm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Function Fx_Saldo_Producto() As String

        Dim _Condicion As String

        If Rdb_Saldo_Con_y_sin_saldo.Checked Then
            _Condicion = String.Empty
        ElseIf Rdb_Saldo_Con_saldo_Positivo.Checked Then
            _Condicion = "And STFI > 0"
        ElseIf Rdb_Saldo_Distinto_de_cero.Checked Then
            _Condicion = "And STFI <> 0"
        End If

        Return _Condicion

    End Function

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Informe)
                End If
            End With
        End If
    End Sub

    Private Sub Sb_Rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked Then
            Select Case _Informe
                Case Enum_Informe.Sucursal
                    Sb_Actualizar_Grilla_Sucursal()
                Case Enum_Informe.Bodega
                    Sb_Actualizar_Grilla_Bodega()
                Case Enum_Informe.Super_Familia
                    Sb_Actualizar_Grilla_Super_Familia()
            End Select
        End If
    End Sub

    Function Fx_Trear_SqlFiltro_Texto_Fm() As String()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_vnta_entre, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Sucursal, _Filtro_Extra As String


        Try
            _Kosu = _Fila.Cells("KOSU").Value
            _Sucursal = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", _
                                         "EMPRESA = '" & ModEmpresa & "' AND KOSU = '" & _Kosu & "'", , , "Todas")

            If _Kosu = "ZZZ" Then
                _Kosu = Generar_Filtro_IN(_Tbl_Informe, "", "KOSU", False, False, "'")
            Else
                _Kosu = "('" & _Kosu & "')"
            End If

            _Filtro_Sucursal = "And KOSU IN " & _Kosu

        Catch ex As Exception
            _Kosu = String.Empty
            _Sucursal = "Todas"
        End Try

        _Texto_Fm = "Suc: " & Trim(_Sucursal)

        Dim _SqlFiltro As String

        Select Case _Informe
            Case Enum_Informe.Sucursal
                '_SqlFiltro = _Kosu
            Case Enum_Informe.Bodega

                _Kobo = _Fila.Cells("KOBO").Value
                Dim _Bodega = Trim(_Fila.Cells("BODEGA").Value)

                If _Kobo = "ZZZ" Then
                    _Kobo = Generar_Filtro_IN(_Tbl_Informe, "", "KOBO", False, False, "'")
                    _Texto_Fm += ",Bodega : Todas"
                Else
                    _Kobo = "('" & _Kobo & "')"
                    _Texto_Fm += ",Bodega : " & _Bodega
                End If

                '_SqlFiltro = _Kosu & " And KOBO IN " & _Kobo
                _Filtro_Extra = "And KOBO IN " & _Kobo


            Case Enum_Informe.Super_Familia

                _Fmpr = Trim(_Fila.Cells("FMPR").Value)
                Dim _Super_Familia = Trim(_Fila.Cells("SUPER_FAMILIA").Value)

                If _Fmpr = "ZZZ" Then
                    _Fmpr = Generar_Filtro_IN(_Tbl_Informe, "", "FMPR", False, False, "'")
                    _Texto_Fm += ",Super Familia: Todas"
                Else
                    _Fmpr = "('" & _Fmpr & "')"
                    _Texto_Fm += ",Super Familia: " & _Super_Familia
                End If

                '_SqlFiltro = _Kosu & "And FMPR IN " & _Fmpr
                _Filtro_Extra = "And FMPR IN " & _Fmpr

            Case Enum_Informe.Obsolencia 'COD_VNTA_ENTRE,VNTA_ENTRE,

                _Cod_vnta_entre = Trim(_Fila.Cells("COD_VNTA_ENTRE").Value)

                If _Cod_vnta_entre = "ZZZ" Then
                    _Cod_vnta_entre = Generar_Filtro_IN(_Tbl_Informe, "", "COD_VNTA_ENTRE", False, False, "'")
                Else
                    _Cod_vnta_entre = "('" & _Cod_vnta_entre & "')"
                End If

                _SqlFiltro = _Kosu & " And COD_VNTA_ENTRE IN " & _Cod_vnta_entre
                _Filtro_Extra = "And COD_VNTA_ENTRE IN " & _Cod_vnta_entre

        End Select


        Dim _Arreglo(2) As String

        _Arreglo(0) = NuloPorNro(_Filtro_Sucursal, "") '_SqlFiltro
        _Arreglo(1) = NuloPorNro(_Filtro_Extra, "")
        _Arreglo(2) = NuloPorNro(_Texto_Fm, "")

        Fx_Trear_SqlFiltro_Texto_Fm = _Arreglo

    End Function


    Function Fx_Traer_Filtro_Sucursales() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_Obsolencia, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Sucursales As String

        Try
            _Kosu = _Fila.Cells("KOSU").Value
            _Sucursal = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU", _
                                         "EMPRESA = '" & ModEmpresa & "' AND KOSU = '" & _Kosu & "'", , , "Todas")

            If _Kosu = "ZZZ" Then
                _Kosu = String.Empty 'Generar_Filtro_IN(_Tbl_Informe, "", "KOSU", False, False, "'")
                _Filtro_Sucursales = _Kosu
            Else
                _Kosu = "('" & _Kosu & "')"
                _Filtro_Sucursales = "And KOSU IN " & _Kosu
            End If

        Catch ex As Exception
            _Filtro_Sucursales = String.Empty
        End Try

        Return _Filtro_Sucursales

    End Function

    Function Fx_Traer_Filtro_Bodegas() As String

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_Obsolencia, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Bodegas As String

        Try
            _Kobo = _Fila.Cells("KOBO").Value
            Dim _Bodega = Trim(_Fila.Cells("BODEGA").Value)

            If _Kobo = "ZZZ" Then
                _Kobo = Generar_Filtro_IN(_Tbl_Informe, "", "KOBO", False, False, "'")
                _Texto_Fm += ",Bodega : Todas"
            Else
                _Kobo = "('" & _Kobo & "')"
                _Texto_Fm += ",Bodega : " & _Bodega
            End If

            _Filtro_Bodegas = "And KOBO IN " & _Kobo

        Catch ex As Exception
            _Filtro_Bodegas = ""
        End Try

        Return _Filtro_Bodegas

    End Function

    Function Fx_Traer_Filtro_Familias()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_vnta_entre, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Familias As String

        Try

            _Fmpr = Trim(_Fila.Cells("FMPR").Value)
            Dim _Super_Familia = Trim(_Fila.Cells("SUPER_FAMILIA").Value)

            If _Fmpr = "ZZZ" Then
                _Fmpr = Generar_Filtro_IN(_Tbl_Informe, "", "FMPR", False, False, "'")
                _Texto_Fm += ",Super Familia: Todas"
            Else
                _Fmpr = "('" & _Fmpr & "')"
                _Texto_Fm += ",Super Familia: " & _Super_Familia
            End If

            _Filtro_Familias = "And FMPR IN " & _Fmpr

        Catch ex As Exception
            _Filtro_Familias = String.Empty
        End Try

        Return _Filtro_Familias

    End Function

    Function Fx_Traer_Filtro_Obsolencias()

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Kosu, _Kobo, _Fmpr, _Cod_vnta_entre, _Sucursal, _Texto_Fm As String
        Dim _Filtro_Obsolencias As String

        Try

            _Cod_vnta_entre = Trim(_Fila.Cells("COD_OBSOLENCIA").Value)

            If _Cod_vnta_entre = "ZZZ" Then
                _Cod_vnta_entre = Generar_Filtro_IN(_Tbl_Informe, "", "COD_OBSOLENCIA", False, False, "'")
            Else
                _Cod_vnta_entre = "('" & _Cod_vnta_entre & "')"
            End If

            _Filtro_Obsolencias = "And COD_OBSOLENCIA IN " & _Cod_vnta_entre

        Catch ex As Exception
            _Filtro_Obsolencias = String.Empty
        End Try

        Return _Filtro_Obsolencias

    End Function

    Sub Sb_Revisar_Sub_Informe(ByVal _Sub_Informe As Enum_Informe)

        'Dim _Arreglo() As String = Fx_Traer_SqlFiltro_Texto_Fm()
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cod = _Fila.Cells(0).Value
        Dim _Des = UCase(_Informe.ToString)
        _Des = UCase(_Fila.Cells(_Des).Value)

        Dim _Texto_Fm As String

        If _Cod = "ZZZ" Then
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": TODAS"
        Else
            _Texto_Fm = "DESDE " & UCase(_Informe.ToString) & ": " & Trim(_Des)
        End If

        Dim Fl_Sucursales = _Fl_Sucursales
        Dim Fl_Bodegas = _Fl_Bodegas
        Dim Fl_Familias = _Fl_Familias
        Dim Fl_Obsolencias = _Fl_Obsolencias

        Select Case _Informe
            Case Enum_Informe.Sucursal
                Fl_Sucursales = Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fl_Bodegas = Fx_Traer_Filtro_Bodegas()
            Case Enum_Informe.Super_Familia
                Fl_Familias = Fx_Traer_Filtro_Familias()
            Case Enum_Informe.Obsolencia
                Fl_Obsolencias = Fx_Traer_Filtro_Obsolencias()
        End Select

        Dim Fm As New Frm_Informe_Composicion_Stock(_Sub_Informe, _Tabla_Paso, True)
        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left

        Select Case _Sub_Informe
            'Case Enum_Informe.Sucursal
            '    Fl_Sucursales = Fx_Traer_Filtro_Sucursales()
            Case Enum_Informe.Bodega
                Fm.Btn_Informe_X_Bodega.Visible = False
            Case Enum_Informe.Super_Familia
                Fm.Btn_Informe_X_Familia.Visible = False
            Case Enum_Informe.Obsolencia
                Fm.Btn_Informe_X_Obsolencia.Visible = False
        End Select

        Fm.Pro_Fl_Sucursales = Fl_Sucursales
        Fm.Pro_Fl_Bodegas = Fl_Bodegas
        Fm.Pro_Fl_Familias = Fl_Familias
        Fm.Pro_Fl_Obsolencia = Fl_Obsolencias

        Fm.Pro_Rdb_Saldo_Con_saldo_Positivo = Rdb_Saldo_Con_saldo_Positivo.Checked
        Fm.Pro_Rdb_Saldo_Con_y_sin_saldo = Rdb_Saldo_Con_y_sin_saldo.Checked
        Fm.Pro_Rdb_Saldo_Distinto_de_cero = Rdb_Saldo_Distinto_de_cero.Checked

        Fm.Text = "Stock valorizado, " & _Texto_Fm
        Fm.ShowDialog(Me)
        Fm.Dispose()


    End Sub



End Class