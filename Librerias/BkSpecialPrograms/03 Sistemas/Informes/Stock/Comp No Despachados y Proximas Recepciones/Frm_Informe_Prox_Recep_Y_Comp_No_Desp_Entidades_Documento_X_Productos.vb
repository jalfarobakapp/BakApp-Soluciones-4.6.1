Imports DevComponents.DotNetBar

Public Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Entidades_Documento_X_Productos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tabla_Paso As String
    Dim _SqlFiltro As String
    Dim _Unidad As Integer

    Dim _Tbl_Informe, _Tbl_Detalle As DataTable

    Enum Enum_Informe_Padre
        Informe_Proximas_Recpciones
        Informe_Compromisos_No_Despachados
    End Enum

    Dim _Informe_Padre As Enum_Informe_Padre

    Public ReadOnly Property Pro_Tbl_Informe() As DataTable
        Get
            Return _Tbl_Informe
        End Get
    End Property

    Public Sub New(Informe_Padre As Enum_Informe_Padre,
                   Nombre_Tabla_Paso As String,
                   SqlFiltro As String,
                   Unidad As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Informe_Padre = Informe_Padre
        _Nombre_Tabla_Paso = Nombre_Tabla_Paso
        _SqlFiltro = SqlFiltro
        _Unidad = Unidad

        Sb_Formato_Generico_Grilla(Grilla_Entidades, 18, New Font("Tahoma", 9), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

    End Sub

    Private Sub Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Entidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
            Me.Text = "INFORME DE COMPROMISOS NO DESPACHADOS NIVEL ENTIDAD"
        ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
            Me.Text = "INFORME DE PROXIMAS RECEPCIONES NIVEL ENTIDAD"
        End If

        AddHandler Grilla_Entidades.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Documentos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Detalle.RowEnter, AddressOf Grilla_Detalle_RowEnter

        Grilla_Detalle_RowEnter()

        Sb_Formato_Grillas()

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = My.Resources.Recursos_Proximas_Recepciones.SQLQuery_Sub_Inf_Recep_Desp_Detalle_x_Entiades
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
        _Ds.Relations.Add("Rel_Entidad_Documentos",
                          _Ds.Tables("Table").Columns("IDMAEEN"),
                          _Ds.Tables("Table1").Columns("IDMAEEN"), False)

        _Ds.Relations.Add("Rel_Documentos_Detalle",
                    _Ds.Tables("Table1").Columns("IDMAEEDO"),
                    _Ds.Tables("Table2").Columns("IDMAEEDO"), False)

        _Tbl_Detalle = _Ds.Tables(2)

        Grilla_Entidades.DataSource = _Ds
        Grilla_Entidades.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_Documentos.DataSource = _Ds
        Grilla_Documentos.DataMember = "Table.Rel_Entidad_Documentos"

        'Muestra tercera relacion
        Grilla_Detalle.DataSource = _Ds
        Grilla_Detalle.DataMember = "Table.Rel_Entidad_Documentos.Rel_Documentos_Detalle" '  Table.Table1.Rel_Documentos_Detalle"

        OcultarEncabezadoGrilla(Grilla_Entidades, True)
        OcultarEncabezadoGrilla(Grilla_Documentos, True)
        OcultarEncabezadoGrilla(Grilla_Detalle, True)

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

        With Grilla_Entidades

            OcultarEncabezadoGrilla(Grilla_Entidades, False)

            .Columns("ENDO").Width = 100
            .Columns("ENDO").HeaderText = _Campo_Entidad_Rece_Desp '"Entidad"
            .Columns("ENDO").Visible = True

            .Columns("SUENDO").Width = 80
            .Columns("SUENDO").HeaderText = "Suc."
            .Columns("SUENDO").Visible = True

            .Columns("NOKOEN").Width = 520
            .Columns("NOKOEN").HeaderText = "Razón Social " & _Campo_Entidad_Rece_Desp
            .Columns("NOKOEN").Visible = True

        End With



        With Grilla_Documentos

            OcultarEncabezadoGrilla(Grilla_Documentos, False)

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True

            .Columns("NUDO").Width = 100
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True

            .Columns("FEEMDO").Width = 100
            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Visible = True

            .Columns("FEERLI").Width = 100
            .Columns("FEERLI").HeaderText = _Campo_Fecha_Rece_Desp '"Fecha Despacho"
            .Columns("FEERLI").Visible = True

            .Columns("SUCURSAL").Width = 370
            .Columns("SUCURSAL").HeaderText = "Sucursal"
            .Columns("SUCURSAL").Visible = True


        End With

        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, False)

            .Columns("BOSULIDO").Width = 40
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True

            .Columns("KOPRCT").Width = 100
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True

            .Columns("NOKOPR").Width = 195
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True

            .Columns("UD0" & _Unidad & "PR").Width = 30
            .Columns("UD0" & _Unidad & "PR").HeaderText = "UD" & _Unidad
            .Columns("UD0" & _Unidad & "PR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UD0" & _Unidad & "PR").Visible = True

            'CAPRCO1,CAPREX1,STFI1,SALDO_Ud1,PPPRNE,PM_TRANS,PM_ACTUAL,TOT_SALDOxPRECIO,TOT_SALDOxPM_TRANS,
            'TOT_SALDOxPM_ACTUAL()

            .Columns("CAPRCO" & _Unidad).Width = 60
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cant."
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO" & _Unidad).Visible = True

            .Columns("CAPREX" & _Unidad).Width = 60
            .Columns("CAPREX" & _Unidad).HeaderText = Mid(_Campo_Recep_Desp, 1, 5) & "."
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPREX" & _Unidad).Visible = True

            .Columns("SALDO_Ud" & _Unidad).Width = 60
            .Columns("SALDO_Ud" & _Unidad).HeaderText = "Pend."
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("SALDO_Ud" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("SALDO_Ud" & _Unidad).Visible = True

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

            .Columns("STFI" & _Unidad).Width = 60
            .Columns("STFI" & _Unidad).HeaderText = "Stock"
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("STFI" & _Unidad).Visible = True

        End With

    End Sub

    Private Sub Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Detalle_X_Entidades_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Detalle, Me, "Productos_Detalle")
    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

        Dim Fm As New Frm_BkpPostBusquedaEspecial_Mt

        Dim _Fila As DataGridViewRow = Grilla_Detalle.Rows(Grilla_Detalle.CurrentRow.Index)

        Dim _Kopr As String = _Fila.Cells("KOPRCT").Value
        Dim _Tido As String = _Fila.Cells("TIDO").Value
        Dim _Endo As String = _Fila.Cells("ENDO").Value


        Dim _Tipotransa As String = _Sql.Fx_Trae_Dato("TABTIDO", "TIPOTRANSA", "TIDO = '" & _Tido & "'")

        If _Tipotransa = "C" Then
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Compra)
        ElseIf _Tipotransa = "V" Then
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr, _Endo, Frm_BkpPostBusquedaEspecial_Mt.Tipo_Doc.Venta)
        Else
            Fm.Sb_Ver_Informacion_Adicional_producto(Me, _Kopr)
        End If

    End Sub

    Private Sub Btn_Ver_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_documento.Click

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Marcar_Grilla_Pendientes = True
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Detalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Productos)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Documentos_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grilla_Documentos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_Documento)
                End If
            End With
        End If
    End Sub

    Private Sub Grilla_Documentos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Documentos.CellDoubleClick
        ShowContextMenu(Menu_Contextual_Documento)
    End Sub

    Private Sub Grilla_Detalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Detalle.CellDoubleClick
        ShowContextMenu(Menu_Contextual_Productos)
    End Sub

    Private Sub Grilla_Detalle_RowEnter()

        For Each _Fila As DataGridViewRow In Grilla_Detalle.Rows

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
