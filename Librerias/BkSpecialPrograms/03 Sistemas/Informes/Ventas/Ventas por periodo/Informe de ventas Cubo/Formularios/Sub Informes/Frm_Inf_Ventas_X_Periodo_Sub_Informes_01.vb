Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Inf_Ventas_X_Periodo_Sub_Informes_01

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _Nombre_Excel As String
    Dim _Tbl_Informe As DataTable
    Dim _SqlFiltro As String
    Dim _SqlExcel As String
    Dim _SqlExcelVistaAltual As String

    Enum Enum_Tipo_Informe
        Inf_Clientes
        Inf_Documentos
        Inf_Detalle
    End Enum

    Dim _Tipo_Informe As Enum_Tipo_Informe

    Dim _Correr_a_la_derecha As Boolean
    Dim _Top, _Left As Integer

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

    Public Sub New(ByVal Nombre_Tabla_Paso As String, _
                   ByVal SqlFiltro As String, _
                   ByVal Tipo_Informe As Enum_Tipo_Informe, _
                   Optional ByVal Correr_a_la_derecha As Boolean = False)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _SqlFiltro = SqlFiltro
        _Tipo_Informe = Tipo_Informe
        _Correr_a_la_derecha = Correr_a_la_derecha

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Me.Width = 1000
        Me.Height = 600

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Inf_Ventas_X_Periodo_02_Detalle_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Correr_a_la_derecha Then
            Me.Top = _Top + 15
            Me.Left = _Left + 15
        End If

        Sb_Actualizar_Grilla()

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Sb_Grilla_ColumnHeaderMouseClick

    End Sub


    Sub Sb_Actualizar_Grilla()

        Lbl_Informes.Visible = True
        Btn_Mnu_Estadisticas_Producto.Visible = False
        Btn_Mnu_Ver_Documento.Visible = False
        Btn_Mnu_Informeacion_Credito_Cliente.Visible = False

        Btn_Informe_Clientes.Visible = False
        Btn_Informe_Documentos.Visible = False
        Btn_Informe_Productos.Visible = False

        Select Case _Tipo_Informe
            Case Enum_Tipo_Informe.Inf_Clientes
                Me.Text = "Informe de ventas por Clientes"
                'Lbl_Informes.Visible = True
                Btn_Informe_Documentos.Visible = True
                Btn_Informe_Productos.Visible = True
                Btn_Mnu_Informeacion_Credito_Cliente.Visible = True
                Sb_Actualizar_Grilla_Informe_X_Clientes()
                _Nombre_Excel = "Inf_Vta_Clientes"
            Case Enum_Tipo_Informe.Inf_Documentos
                Me.Text = "Informe de ventas por Documentos"
                'Lbl_Informes.Visible = True
                Btn_Informe_Productos.Visible = True
                Btn_Mnu_Ver_Documento.Visible = True
                Btn_Mnu_Informeacion_Credito_Cliente.Visible = True
                Sb_Actualizar_Grilla_Informe_X_Documentos_Entidades()
                _Nombre_Excel = "Inf_Vta_Documentos"
            Case Enum_Tipo_Informe.Inf_Detalle
                Me.Text = "Informe de ventas por Productos"
                Btn_Mnu_Ver_Documento.Visible = True
                Btn_Mnu_Estadisticas_Producto.Visible = True
                Sb_Actualizar_Grilla_Informe_X_Detalle()
                Btn_Informe_Clientes.Visible = True
                _Nombre_Excel = "Inf_Vta_Productos"
        End Select

        Sb_Marcar_Grillas()

        Me.Refresh()

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    'ShowContextMenu(Menu_Contextual_Informe)
                    ShowContextMenu(Menu_Contextual)
                End If
            End With
        End If
    End Sub

    Sub Sb_Actualizar_Grilla_Informe_X_Clientes()

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text), _
                                                "ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA LIKE '%")


        Consulta_sql = "Select RTEN,RUT,ENDO,SUENDO,RAZON,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL," & _
                       "SUM(VANELI) AS VANEDO,SUM(VAIVLI) AS VAIVDO, SUM(VABRLI) AS VABRDO" & vbCrLf & _
                       "From " & _Nombre_Tabla_Paso & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _
                       _SqlFiltro & vbCrLf & _
                       "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'" & vbCrLf & _
                       "Group By RTEN,RUT,ENDO,SUENDO,RAZON,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL"
        _SqlExcel = Consulta_sql

        _SqlExcelVistaAltual = "Select ENDO As Entidad,SUENDO As 'Suc.',RAZON As 'Razón Social',KOFULIDO As 'Cod.',VENDEDOR As 'Vendedor'," &
                               "SUM(VANELI) As 'Neto',SUM(VABRLI) As 'Bruto'" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               _SqlFiltro & vbCrLf &
                               "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'" & vbCrLf &
                               "Group By RTEN,RUT,ENDO,SUENDO,RAZON,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL"

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").Visible = True

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 290
            .Columns("RAZON").Visible = True

            .Columns("KOFULIDO").HeaderText = "Cod."
            .Columns("KOFULIDO").Width = 35
            .Columns("KOFULIDO").Visible = True

            .Columns("VENDEDOR").HeaderText = "Vendedor"
            .Columns("VENDEDOR").Width = 130
            .Columns("VENDEDOR").Visible = True

            .Columns("VANEDO").HeaderText = "Neto"
            .Columns("VANEDO").Width = 80
            .Columns("VANEDO").Visible = True
            .Columns("VANEDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VANEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VABRDO").HeaderText = "Bruto"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        Consulta_sql = "Select Isnull(SUM(CAPRCO1),0) AS CANTIDAD,Isnull(SUM(VANELI),0) AS VANELI,Isnull(SUM(VAIVLI),0) AS VAIVLI, Isnull(SUM(VABRLI),0) AS VABRLI" & vbCrLf & _
                      "From " & _Nombre_Tabla_Paso & vbCrLf & _
                      "Where 1 > 0" & vbCrLf & _
                      _SqlFiltro & vbCrLf & _
                      "And ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Total_Cantidad As Double
        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        If CBool(_Tbl.Rows.Count) Then
            _Total_Cantidad = _Tbl.Rows(0).Item("CANTIDAD")
            _Total_Neto = _Tbl.Rows(0).Item("VANELI")
            _Total_Bruto = _Tbl.Rows(0).Item("VABRLI")
        End If

        Lbl_Total_Cantidad.Text = FormatNumber(_Total_Cantidad, 0)
        Lbl_Total_Neto.Text = FormatCurrency(_Total_Neto, 0)
        Lbl_Total_Bruto.Text = FormatCurrency(_Total_Bruto, 0)

    End Sub

    Sub Sb_Actualizar_Grilla_Informe_X_Documentos_Entidades()

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text), _
                                                "TIDO+NUDO+ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA LIKE '%")

        Consulta_sql = "Select IDMAEEDO,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,FEEMDO,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL," &
                       "SUM(VANELI) AS VANEDO,SUM(VAIVLI) AS VAIVDO, SUM(VABRLI) AS VABRDO" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       _SqlFiltro & vbCrLf &
                       "And TIDO+NUDO+ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'" & vbCrLf &
                       "Group By IDMAEEDO,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,FEEMDO,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL"
        _SqlExcel = Consulta_sql


        _SqlExcelVistaAltual = "Select TIDO As 'TD',NUDO As 'Número',ENDO As 'Entidad',SUENDO As 'Suc.',RAZON As 'Razón Social',FEEMDO As 'Fecha'," &
                               "KOFULIDO As 'Cod.',VENDEDOR As 'Vendedor',SUM(VANELI) As 'Neto',SUM(VABRLI) As 'Bruto'" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               _SqlFiltro & vbCrLf &
                               "And TIDO+NUDO+ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'" & vbCrLf &
                               "Group By IDMAEEDO,TIDO,NUDO,RTEN,RUT,ENDO,SUENDO,RAZON,FEEMDO,KOFULIDO,VENDEDOR,RUEN,RUBRO_EN,ZOEN,ZONA_EN,DIEN,CIEN,CIUDAD,CMEN,COMUNA,SUDO,SUCURSAL"

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 70
            .Columns("NUDO").Visible = True

            .Columns("ENDO").HeaderText = "Entidad"
            .Columns("ENDO").Width = 75
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Width = 50
            .Columns("SUENDO").Visible = True

            .Columns("RAZON").HeaderText = "Razón Social"
            .Columns("RAZON").Width = 280
            .Columns("RAZON").Visible = True

            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Width = 70
            .Columns("FEEMDO").Visible = True

            .Columns("KOFULIDO").HeaderText = "Cod."
            .Columns("KOFULIDO").Width = 30
            .Columns("KOFULIDO").Visible = True

            .Columns("VENDEDOR").HeaderText = "Vendedor"
            .Columns("VENDEDOR").Width = 130
            .Columns("VENDEDOR").Visible = True

            .Columns("VANEDO").HeaderText = "Neto"
            .Columns("VANEDO").Width = 80
            .Columns("VANEDO").Visible = True
            .Columns("VANEDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VANEDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VABRDO").HeaderText = "Bruto"
            .Columns("VABRDO").Width = 80
            .Columns("VABRDO").Visible = True
            .Columns("VABRDO").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VABRDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        Consulta_sql = "Select Isnull(SUM(CAPRCO1),0) AS CANTIDAD,Isnull(SUM(VANELI),0) AS VANELI,Isnull(SUM(VAIVLI),0) AS VAIVLI, Isnull(SUM(VABRLI),0) AS VABRLI" & vbCrLf & _
                       "From " & _Nombre_Tabla_Paso & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _
                       _SqlFiltro & vbCrLf & _
                       "And TIDO+NUDO+ENDO+SUENDO+RAZON+VENDEDOR+RUBRO_EN+ZONA_EN+CIUDAD+COMUNA Like '%" & _Cadena & "%'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Total_Cantidad As Double
        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        If CBool(_Tbl.Rows.Count) Then
            _Total_Cantidad = _Tbl.Rows(0).Item("CANTIDAD")
            _Total_Neto = _Tbl.Rows(0).Item("VANELI")
            _Total_Bruto = _Tbl.Rows(0).Item("VABRLI")
        End If

        Lbl_Total_Cantidad.Text = FormatNumber(_Total_Cantidad, 0)
        Lbl_Total_Neto.Text = FormatCurrency(_Total_Neto, 0)
        Lbl_Total_Bruto.Text = FormatCurrency(_Total_Bruto, 0)

    End Sub

    Sub Sb_Actualizar_Grilla_Informe_X_Detalle()

        Dim _Cadena As String = CADENA_A_BUSCAR(RTrim$(Txt_Filtro_Abanzado.Text), _
        "KOPRCT+NOKOPR+TIDO+NUDO+VENDEDOR+SUPER_FAMILIA+FAMILIA+SUB_FAMILIA+MARCA+RUBRO_PR+CLAS_LIBRE+ZONA_PR LIKE '%")

        Consulta_sql = "Select IDMAEDDO,IDMAEEDO,KOPRCT,NOKOPR,TIDO,NUDO,SULIDO,BOSULIDO,FEEMDO,KOFULIDO,UD," &
                       "SUM(CAPRCO1) AS CANTIDAD,PPPRNE,SUM(VANELI) AS VANELI,SUM(VAIVLI) AS VAIVLI, SUM(VABRLI) AS VABRLI," &
                       "FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR" & vbCrLf &
                       "From " & _Nombre_Tabla_Paso & vbCrLf &
                       "Where 1 > 0" & vbCrLf &
                       "And KOPRCT+NOKOPR+TIDO+NUDO+VENDEDOR+SUPER_FAMILIA+FAMILIA+SUB_FAMILIA+MARCA+RUBRO_PR+CLAS_LIBRE+ZONA_PR Like '%" & _Cadena & "%'" & vbCrLf &
                       _SqlFiltro & vbCrLf &
                       "Group By IDMAEDDO,IDMAEEDO,KOPRCT,NOKOPR,TIDO,NUDO,SULIDO,BOSULIDO,FEEMDO,KOFULIDO,UD,PPPRNE,FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR"
        _SqlExcel = Consulta_sql

        _SqlExcelVistaAltual = "Select KOPRCT As 'Código',NOKOPR As 'Descripción',TIDO As 'Td',NUDO As 'Número',FEEMDO As 'Fecha',KOFULIDO As 'Cod.',UD," &
                               "SUM(CAPRCO1) As 'Cantidad',PPPRNE As 'Precio Neto',SUM(VANELI) As Neto,SUM(VABRLI) As Bruto" & vbCrLf &
                               "From " & _Nombre_Tabla_Paso & vbCrLf &
                               "Where 1 > 0" & vbCrLf &
                               "And KOPRCT+NOKOPR+TIDO+NUDO+VENDEDOR+SUPER_FAMILIA+FAMILIA+SUB_FAMILIA+MARCA+RUBRO_PR+CLAS_LIBRE+ZONA_PR Like '%" & _Cadena & "%'" & vbCrLf &
                               _SqlFiltro & vbCrLf &
                               "Group By IDMAEDDO,IDMAEEDO,KOPRCT,NOKOPR,TIDO,NUDO,SULIDO,BOSULIDO,FEEMDO,KOFULIDO,UD,PPPRNE,FMPR,SUPER_FAMILIA,PFPR,FAMILIA,HFPR,SUB_FAMILIA,MRPR,MARCA,RUPR,RUBRO_PR,CLALIBPR,CLAS_LIBRE,ZOPR,ZONA_PR"

        _Tbl_Informe = _Sql.Fx_Get_Tablas(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Informe

            OcultarEncabezadoGrilla(Grilla, False)

            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").Visible = True

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 250
            .Columns("NOKOPR").Visible = True

            .Columns("TIDO").HeaderText = "Td"
            .Columns("TIDO").Width = 30
            .Columns("TIDO").Visible = True

            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Width = 80
            .Columns("NUDO").Visible = True

            .Columns("FEEMDO").HeaderText = "Fecha"
            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").Visible = True

            .Columns("KOFULIDO").HeaderText = "Cod."
            .Columns("KOFULIDO").Width = 30
            .Columns("KOFULIDO").Visible = True

            '.Columns("VENDEDOR").HeaderText = "Vendedor"
            '.Columns("VENDEDOR").Width = 30
            '.Columns("VENDEDOR").Visible = True

            .Columns("UD").HeaderText = "UD"
            .Columns("UD").Width = 30
            .Columns("UD").Visible = True

            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").Width = 60
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("PPPRNE").HeaderText = "Precio Neto"
            .Columns("PPPRNE").Width = 70
            .Columns("PPPRNE").Visible = True
            .Columns("PPPRNE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VANELI").HeaderText = "Neto"
            .Columns("VANELI").Width = 80
            .Columns("VANELI").Visible = True
            .Columns("VANELI").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VANELI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VABRLI").HeaderText = "Bruto"
            .Columns("VABRLI").Width = 80
            .Columns("VABRLI").Visible = True
            .Columns("VABRLI").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VABRLI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        Consulta_sql = "Select Isnull(SUM(CAPRCO1),0) AS CANTIDAD,Isnull(SUM(VANELI),0) AS VANELI,Isnull(SUM(VAIVLI),0) AS VAIVLI, Isnull(SUM(VABRLI),0) AS VABRLI" & vbCrLf & _
                       "From " & _Nombre_Tabla_Paso & vbCrLf & _
                       "Where 1 > 0" & vbCrLf & _
                       _SqlFiltro & vbCrLf & _
                       "And KOPRCT+NOKOPR+TIDO+NUDO+VENDEDOR+SUPER_FAMILIA+FAMILIA+SUB_FAMILIA+MARCA+RUBRO_PR+CLAS_LIBRE+ZONA_PR Like '%" & _Cadena & "%'"

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Total_Cantidad As Double
        Dim _Total_Neto As Double
        Dim _Total_Bruto As Double

        If CBool(_Tbl.Rows.Count) Then
            _Total_Cantidad = _Tbl.Rows(0).Item("CANTIDAD")
            _Total_Neto = _Tbl.Rows(0).Item("VANELI")
            _Total_Bruto = _Tbl.Rows(0).Item("VABRLI")
        End If

        Lbl_Total_Cantidad.Text = FormatNumber(_Total_Cantidad, 0)
        Lbl_Total_Neto.Text = FormatCurrency(_Total_Neto, 0)
        Lbl_Total_Bruto.Text = FormatCurrency(_Total_Bruto, 0)

    End Sub

    Sub Sb_RowsPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < sender.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If sender.RowHeadersWidth < CInt(size.Width + 20) Then
                sender.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "vb.net", _
         MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click

        Dim _Permiso As String

        Select Case _Tipo_Informe
            Case Enum_Tipo_Informe.Inf_Clientes
                _Permiso = "Inf00035"
            Case Enum_Tipo_Informe.Inf_Documentos
                _Permiso = "Inf00036"
            Case Enum_Tipo_Informe.Inf_Detalle
                _Permiso = "Inf00037"
        End Select

        If Fx_Tiene_Permiso(Me, _Permiso) Then
            ShowContextMenu(Menu_contextual_Exportar_Excel)
        End If

    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Fx_Tiene_Permiso(Me, "CfEnt001") Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Koen = Trim(_Fila.Cells("KOEN").Value)
            Dim _Suen = Trim(_Fila.Cells("SUEN").Value)

            Dim Fm As New Frm_Crear_Entidad_Mt
            Fm.Fx_Llenar_Entidad(_Koen, _Suen)
            Fm.Pro_Crear_Entidad = False
            Fm.Pro_Editar_Entidad = True
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button, _
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

            Fm.Dispose()
        End If
    End Sub

    Private Sub Btn_Ver_Situacion_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value
        Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        Dim _RowEntidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
        Fm.Btn_CambCodPago.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Comportamiento_De_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value


        Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        If Not (_RowEntidad Is Nothing) Then

            Dim Fm As New Frm_Infor_Ent_Comportamiento_De_Pago
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
    End Sub

    Private Sub Btn_Informeacion_Credito_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Informeacion_Credito_Cliente.Click
        If Fx_Tiene_Permiso(Me, "Inf00018") Then

            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Koen As String = _Fila.Cells("ENDO").Value
            Dim _Suen As String = _Fila.Cells("SUENDO").Value
            Dim _Razon As String = _Fila.Cells("RAZON").Value

            Dim Fm As New Frm_Infor_Ent_Estado_Creditos_Vigentes
            Fm.Pro_TxtDescripcion = _Razon
            Fm.ShowDialog(Me)
            Fm.Dispose()
        End If
    End Sub

    Private Sub Txt_Filtro_Abanzado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Filtro_Abanzado.KeyDown
        If e.KeyValue = Keys.Enter Then
            Sb_Actualizar_Grilla
        End If
    End Sub

    Private Sub Btn_Informe_Documentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Documentos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("ENDO").Value
        Dim _Suen As String = _Fila.Cells("SUENDO").Value

        Dim _Filtro = _SqlFiltro + vbCrLf & _
                      "And ENDO+SUENDO = '" & _Koen & _Suen & "'"

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso, _
                                                               _Filtro, _
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Documentos, True)

        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Informe_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Productos.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Filtro

        Select Case _Tipo_Informe
            Case Enum_Tipo_Informe.Inf_Clientes

                Dim _Koen As String = _Fila.Cells("ENDO").Value
                Dim _Suen As String = _Fila.Cells("SUENDO").Value

                _Filtro = _SqlFiltro + vbCrLf & "And ENDO+SUENDO = '" & _Koen & _Suen & "'"

            Case Enum_Tipo_Informe.Inf_Documentos

                Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

                _Filtro = _SqlFiltro & vbCrLf & "And IDMAEEDO = " & _Idmaeedo

        End Select


        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso, _
                                                               _Filtro, _
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Detalle, True)

        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick
        ShowContextMenu(Menu_Contextual)
    End Sub

    Private Sub Sb_Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Sb_Marcar_Grillas()
    End Sub

    Sub Sb_Marcar_Grillas()

        Dim _Rojo, _Azul, _Verde As Color

        If Global_Thema = Enum_Themas.Oscuro Then

            _Rojo = Color.FromArgb(220, 78, 66)
            _Azul = Color.FromArgb(37, 136, 213)
            _Verde = Color.FromArgb(30, 215, 96)

        Else

            _Rojo = Color.Red
            _Azul = Color.Blue
            _Verde = Color.Green

        End If


        Select Case _Tipo_Informe
            
            Case Enum_Tipo_Informe.Inf_Documentos
                For Each _Fila As DataGridViewRow In Grilla.Rows

                    Dim _Tido As String = _Fila.Cells("TIDO").Value

                    Select Case _Tido
                        Case "NCV", "NCX", "NEV", "NCZ"
                            _Fila.Cells("VANEDO").Style.ForeColor = _Rojo
                            _Fila.Cells("VABRDO").Style.ForeColor = _Rojo
                    End Select

                Next

            Case Enum_Tipo_Informe.Inf_Detalle
                For Each _Fila As DataGridViewRow In Grilla.Rows

                    Dim _Tido As String = _Fila.Cells("TIDO").Value

                    Select Case _Tido
                        Case "NCV", "NCX", "NEV", "NCZ"
                            _Fila.Cells("VANELI").Style.ForeColor = _Rojo
                            _Fila.Cells("VABRLI").Style.ForeColor = _Rojo
                    End Select

                Next
        End Select

    End Sub

    Private Sub Btn_Mnu_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Estadisticas_Producto.Click

        Dim Fm_Producto As New Frm_BkpPostBusquedaEspecial_Mt

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Codigo As String = _Fila.Cells("KOPRCT").Value

        Dim _Endo As String
        Dim _Tido As String = _Fila.Cells("TIDO").Value
        Dim _Nudo As String = _Fila.Cells("TIDO").Value
        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        _Endo = _Sql.Fx_Trae_Dato("MAEEDO", "ENDO", "IDMAEEDO = " & _Idmaeedo)

        Dim _Tipotransa As String

        If _Sql.Fx_Exite_Campo("TABTIDO", "TIPOTRANSA") Then
            _Tipotransa = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")
            If _Tipotransa = "C" Then
                Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
            ElseIf _Tipotransa = "V" Then
                Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
            Else
                Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
            End If
        Else
            Fm_Producto.Sb_Ver_Informacion_Adicional_producto(Me, _Codigo)
        End If

    End Sub

    Private Sub Btn_Mnu_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ver_Documento.Click
        Dim _Idmaeedo = Grilla.Rows(Grilla.CurrentRow.Index).Cells("IDMAEEDO").Value
        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Informe_Clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Informe_Clientes.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koprct As String = _Fila.Cells("KOPRCT").Value

        Dim _Filtro = _SqlFiltro & vbCrLf & "And KOPRCT = '" & _Koprct & "'"

        Dim Fm As New Frm_Inf_Ventas_X_Periodo_Sub_Informes_01(_Nombre_Tabla_Paso, _
                                                               _Filtro, _
                                                               Frm_Inf_Ventas_X_Periodo_Sub_Informes_01.Enum_Tipo_Informe.Inf_Clientes, True)

        Fm.Pro_Top = Me.Top
        Fm.Pro_Left = Me.Left
        Fm.ShowDialog(Me)
        Fm.Dispose()
    End Sub

    Private Sub Btn_Nota_de_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nota_de_venta.Click

        If Fx_Tiene_Permiso(Me, "Bkp00040") Then

            Dim Fm_Post As New Frm_Formulario_Documento("NVV", csGlobales.Enum_Tipo_Documento.Venta, False)
            'Fm_Post.Btn_Minimizar.Visible = True
            Fm_Post.MinimizeBox = True
            Fm_Post.ShowDialog(Me)
            Fm_Post.Dispose()

        End If

    End Sub

    Private Sub Btn_Crear_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Crear_Venta.Click
        ShowContextMenu(Menu_Contextual_Ventas)
    End Sub

    Private Sub Btn_Exportar_Detalle_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Detalle.Click

        'Dim _Permiso As String

        'Select Case _Tipo_Informe
        '    Case Enum_Tipo_Informe.Inf_Clientes
        '        _Permiso = "Inf00035"
        '    Case Enum_Tipo_Informe.Inf_Documentos
        '        _Permiso = "Inf00036"
        '    Case Enum_Tipo_Informe.Inf_Detalle
        '        _Permiso = "Inf00037"
        'End Select

        'If Fx_Tiene_Permiso(Me, _Permiso) Then ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, _Nombre_Excel)

        ExportarTabla_JetExcel_Tabla(_Tbl_Informe, Me, _Nombre_Excel)

    End Sub

    Private Sub Btn_Exportar_Vista_Actual_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Vista_Actual.Click

        'Dim _Permiso As String

        'Select Case _Tipo_Informe
        '    Case Enum_Tipo_Informe.Inf_Clientes
        '        _Permiso = "Inf00035"
        '    Case Enum_Tipo_Informe.Inf_Documentos
        '        _Permiso = "Inf00036"
        '    Case Enum_Tipo_Informe.Inf_Detalle
        '        _Permiso = "Inf00037"
        'End Select

        'If Fx_Tiene_Permiso(Me, _Permiso) Then

        'End If

        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(_SqlExcelVistaAltual)
        ExportarTabla_JetExcel_Tabla(_Tbl, Me, _Nombre_Excel)

    End Sub

    Private Sub Btn_Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Copiar.Click
        With Grilla

            Dim _Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
            Dim _Texto_Cabeza = .Columns(.CurrentCell.ColumnIndex).HeaderText

            Dim Copiar = .Rows(.CurrentRow.Index).Cells(_Cabeza).Value
            Clipboard.SetText(Copiar)

            ToastNotification.Show(Me, _Texto_Cabeza & " esta en el portapapeles", Btn_Copiar.Image,
                                   2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

        End With
    End Sub
End Class
