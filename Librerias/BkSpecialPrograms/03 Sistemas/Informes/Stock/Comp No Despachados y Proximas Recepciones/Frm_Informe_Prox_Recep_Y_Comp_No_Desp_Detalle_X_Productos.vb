Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _SqlFiltro As String
    Dim _Unidad As Integer

    Dim _Tbl_Productos, _Tbl_Detalle As DataTable

    Enum Enum_Informe_Padre
        Informe_Proximas_Recpciones
        Informe_Compromisos_No_Despachados
    End Enum

    Dim _Informe_Padre As Enum_Informe_Padre


    Public Sub New(ByVal Informe_Padre As Enum_Informe_Padre,
                   ByVal Nombre_Tabla_Paso As String,
                   ByVal SqlFiltro As String,
                   ByVal Unidad As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Informe_Padre = Informe_Padre
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _SqlFiltro = SqlFiltro
        _Unidad = Unidad

        Sb_Formato_Generico_Grilla(Grilla_Productos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Documentos, 15, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
            Me.Text = "INFORME DE COMPROMISOS NO DESPACHADOS NIVEL PRODUCTOS"
        ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
            Me.Text = "INFORME DE PROXIMAS RECEPCIONES NIVEL PRODUCTOS"
        End If

        AddHandler Grilla_Productos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Documentos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Documentos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Documentos.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Productos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Productos.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Documentos.RowEnter, AddressOf Grilla_Detalle_RowEnter

        Sb_Formato_Grillas()

        For Each _Fila As DataGridViewRow In Grilla_Productos.Rows

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
                _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.FromArgb(221, 80, 68)
            Else
                _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
                _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.Red
            End If

        Next

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = My.Resources.Recursos_Proximas_Recepciones.SQLQuery_Sub_Inf_Recep_Desp_Detalle_x_Producto
        Consulta_sql = Replace(Consulta_sql, "#Filtro#", _SqlFiltro)
        Consulta_sql = Replace(Consulta_sql, "#Ud#", _Unidad)
        Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Nombre_Tabla_Paso)

        Dim _Reg = _Sql.Fx_Cuenta_Registros("INFORMATION_SCHEMA.COLUMNS",
                                            "COLUMN_NAME LIKE 'SUENDOFI' AND TABLE_NAME = 'MAEEDO'")
        If Not CBool(_Reg) Then
            Consulta_sql = Replace(Consulta_sql, "SUENDOFI,", "")
        End If

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        ' Agregar la relación ( campo en común : campo_Relacionado = idCliente )  
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        _Ds.Relations.Add("Rel_Detalle_Productos",
                          _Ds.Tables("Table").Columns("KOPRCT"),
                          _Ds.Tables("Table1").Columns("KOPRCT"), False)

        _Tbl_Productos = _Ds.Tables(0)
        _Tbl_Detalle = _Ds.Tables(1)

        Grilla_Productos.DataSource = _Ds
        Grilla_Productos.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_Documentos.DataSource = _Ds
        Grilla_Documentos.DataMember = "Table.Rel_Detalle_Productos"

        OcultarEncabezadoGrilla(Grilla_Productos, False)
        OcultarEncabezadoGrilla(Grilla_Documentos, False)

    End Sub

    Sub Sb_Formato_Grillas()

        Dim _Campo_Recep_Desp As String
        Dim _Campo_Fecha_Rece_Desp As String
        Dim _Campo_Entidad_Rece_Desp As String

        If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
            _Campo_Recep_Desp = "Despachado"
            _Campo_Fecha_Rece_Desp = "F.Despacho"
            _Campo_Entidad_Rece_Desp = "Cliente"
        ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
            _Campo_Recep_Desp = "Recepcionado"
            _Campo_Fecha_Rece_Desp = "F.Recepción"
            _Campo_Entidad_Rece_Desp = "Proveedor"
        End If

        With Grilla_Productos

            OcultarEncabezadoGrilla(Grilla_Productos, False)

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True

            .Columns("NOKOPR").Width = 270
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True

            .Columns("CAPRCO" & _Unidad).Width = 80
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cantidad"
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO" & _Unidad).Visible = True

            .Columns("CAPREX" & _Unidad).Width = 90
            .Columns("CAPREX" & _Unidad).HeaderText = _Campo_Recep_Desp
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPREX" & _Unidad).Visible = True

            .Columns("SALDO_Ud" & _Unidad).Width = 80
            .Columns("SALDO_Ud" & _Unidad).HeaderText = "Pendiente"
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("SALDO_Ud" & _Unidad).Visible = True

            .Columns("STFI" & _Unidad).Width = 80
            .Columns("STFI" & _Unidad).HeaderText = "Stock"
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("STFI" & _Unidad).Visible = True

        End With

        With Grilla_Documentos

            OcultarEncabezadoGrilla(Grilla_Documentos, False)

            .Columns("SULIDO").Width = 35
            .Columns("SULIDO").HeaderText = "Suc"
            .Columns("SULIDO").Visible = True
            '.Columns("SULIDO").DisplayIndex = 0

            .Columns("BOSULIDO").Width = 40
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True
            '.Columns("BOSULIDO").DisplayIndex = 1

            .Columns("ENDO").Width = 65
            .Columns("ENDO").HeaderText = _Campo_Entidad_Rece_Desp '"Entidad"
            .Columns("ENDO").Visible = True
            '.Columns("ENDO").DisplayIndex = 2

            .Columns("NOKOEN").Width = 140
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Visible = True
            '.Columns("NOKOEN").DisplayIndex = 3

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            '.Columns("TIDO").DisplayIndex = 4

            .Columns("NUDO").Width = 70
            .Columns("NUDO").HeaderText = "Númerp"
            .Columns("NUDO").Visible = True
            '.Columns("NUDO").DisplayIndex = 5

            .Columns("UD0" & _Unidad & "PR").Width = 30
            .Columns("UD0" & _Unidad & "PR").HeaderText = "UM"
            .Columns("UD0" & _Unidad & "PR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UD0" & _Unidad & "PR").Visible = True
            '.Columns("UD0" & _Unidad & "PR").DisplayIndex = 6

            'CAPRCO1,CAPREX1,STFI1,SALDO_Ud1,PPPRNE,PM_TRANS,PM_ACTUAL,TOT_SALDOxPRECIO,TOT_SALDOxPM_TRANS,
            'TOT_SALDOxPM_ACTUAL()

            .Columns("CAPRCO" & _Unidad).Width = 50
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cant."
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO" & _Unidad).Visible = True
            '.Columns("CAPRCO" & _Unidad).DisplayIndex = 7

            .Columns("CAPREX" & _Unidad).Width = 50
            .Columns("CAPREX" & _Unidad).HeaderText = Mid(_Campo_Recep_Desp, 1, 5) & "."
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPREX" & _Unidad).Visible = True
            '.Columns("CAPREX" & _Unidad).DisplayIndex = 8

            .Columns("SALDO_Ud" & _Unidad).Width = 50
            .Columns("SALDO_Ud" & _Unidad).HeaderText = "Pend."
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("SALDO_Ud" & _Unidad).Visible = True
            '.Columns("SALDO_Ud" & _Unidad).DisplayIndex = 9

            .Columns("STFI" & _Unidad).Width = 50
            .Columns("STFI" & _Unidad).HeaderText = "Stock"
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("STFI" & _Unidad).Visible = True
            '.Columns("STFI" & _Unidad).DisplayIndex = 10

            .Columns("MODO").HeaderText = "TM."
            .Columns("MODO").Visible = True
            .Columns("MODO").Width = 30
            '.Columns("MODO").DisplayIndex = 11

            .Columns("PPPRNE").Width = 65
            .Columns("PPPRNE").HeaderText = "Precio"
            .Columns("PPPRNE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PPPRNE").DefaultCellStyle.Format = "###,##.##"
            .Columns("PPPRNE").Visible = True
            '.Columns("PPPRNE").DisplayIndex = 12
        End With

    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Detalle, Me, "Productos_Detalle")
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
                    ElseIf _Nombre_Grilla = "Grilla_Documentos" Then
                        Btn_Estadisticas_Producto.Visible = False
                        Btn_Ver_Documento.Visible = True
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
        ElseIf _Nombre_Grilla = "Grilla_Documentos" Then
            Btn_Estadisticas_Producto.Visible = False
            Btn_Ver_Documento.Visible = True
        End If

        ShowContextMenu(Menu_Contextual)

    End Sub


    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        Dim _Fila As DataGridViewRow = Grilla_Productos.Rows(Grilla_Productos.CurrentRow.Index)

        Dim _Kopr As String = _Fila.Cells("KOPRCT").Value
        Dim _Tido As String = String.Empty '_Fila.Cells("TIDO").Value
        Dim _Endo As String = String.Empty '_Fila.Cells("ENDO").Value


        Dim _Tipotransa As String = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")

        If _Tipotransa = "C" Then
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
        ElseIf _Tipotransa = "V" Then
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        Else
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr)
        End If

    End Sub

    Private Sub Btn_Ver_Documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Detalle_RowEnter()

        For Each _Fila As DataGridViewRow In Grilla_Documentos.Rows

            If Global_Thema = Enum_Themas.Oscuro Then
                _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
                _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.FromArgb(221, 80, 68)
            Else
                _Fila.Cells("CAPREX" & _Unidad).Style.ForeColor = Color.Green
                _Fila.Cells("SALDO_Ud" & _Unidad).Style.ForeColor = Color.Red
            End If

        Next

    End Sub

End Class
