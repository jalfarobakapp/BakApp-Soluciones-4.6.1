Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Documento_X_Productos

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

        Sb_Formato_Generico_Grilla(Grilla_Documentos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Formato_Generico_Grilla(Grilla_Detalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, False, False)

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Informe_Prox_Recep_Y_Comp_No_Desp_Documento_X_Productos_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If _Informe_Padre = Enum_Informe_Padre.Informe_Compromisos_No_Despachados Then
            Me.Text = "INFORME DE COMPROMISOS NO DESPACHADOS NIVEL DOCUMENTOS"
        ElseIf _Informe_Padre = Enum_Informe_Padre.Informe_Proximas_Recpciones Then
            Me.Text = "INFORME DE PROXIMAS RECEPCIONES NIVEL DOCUMENTOS"
        End If


        AddHandler Grilla_Documentos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint
        AddHandler Grilla_Detalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        AddHandler Grilla_Detalle.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Detalle.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Documentos.MouseDown, AddressOf Grilla_MouseDown
        AddHandler Grilla_Documentos.CellDoubleClick, AddressOf Grilla_CellDoubleClick

        AddHandler Grilla_Detalle.RowEnter, AddressOf Grilla_Detalle_RowEnter

        Grilla_Detalle_RowEnter()

        Sb_Formato_Grillas()

        If CBool(Grilla_Documentos.RowCount) Then

            Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(0)
            Dim _Tido = _Fila.Cells("TIDO").Value

            If _Tido = "NVV" Then
                Btn_Facturacion_Masiva.Visible = True
            End If

        End If

    End Sub

    Sub Sb_Actualizar_Grillas()

        Consulta_sql = My.Resources.Recursos_Proximas_Recepciones.SQLQuery_Sub_Inf_Recep_Desp_Detalle_x_Documentos
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
        _Ds.Relations.Add("Rel_Detalle_Documentos",
                          _Ds.Tables("Table").Columns("IDMAEEDO"),
                          _Ds.Tables("Table1").Columns("IDMAEEDO"), False)

        _Tbl_Productos = _Ds.Tables(0)
        _Tbl_Detalle = _Ds.Tables(1)

        Grilla_Documentos.DataSource = _Ds
        Grilla_Documentos.DataMember = "Table"

        'Muestra segunda relacion
        Grilla_Detalle.DataSource = _Ds
        Grilla_Detalle.DataMember = "Table.Rel_Detalle_Documentos"

        OcultarEncabezadoGrilla(Grilla_Documentos, False)
        OcultarEncabezadoGrilla(Grilla_Detalle, False)

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

        With Grilla_Documentos

            OcultarEncabezadoGrilla(Grilla_Documentos, False)

            .Columns("TIDO").Width = 30
            .Columns("TIDO").HeaderText = "TD"
            .Columns("TIDO").Visible = True
            .Columns("TIDO").DisplayIndex = 0

            .Columns("NUDO").Width = 80
            .Columns("NUDO").HeaderText = "Número"
            .Columns("NUDO").Visible = True
            .Columns("NUDO").DisplayIndex = 1

            .Columns("FEEMDO").Width = 80
            .Columns("FEEMDO").HeaderText = "F.Emisión"
            .Columns("FEEMDO").Visible = True
            .Columns("FEEMDO").DisplayIndex = 2

            .Columns("FEERLI").Width = 80
            .Columns("FEERLI").HeaderText = _Campo_Fecha_Rece_Desp '"Fecha recepción"
            .Columns("FEERLI").Visible = True
            .Columns("FEERLI").DisplayIndex = 3

            .Columns("ENDO").Width = 80
            .Columns("ENDO").HeaderText = _Campo_Entidad_Rece_Desp '"Entidad"
            .Columns("ENDO").Visible = True
            .Columns("ENDO").DisplayIndex = 4

            .Columns("NOKOEN").Width = 200
            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Visible = True
            .Columns("NOKOEN").DisplayIndex = 5

            .Columns("SUCURSAL").Width = 150
            .Columns("SUCURSAL").HeaderText = "Sucursal"
            .Columns("SUCURSAL").Visible = True
            .Columns("SUCURSAL").DisplayIndex = 6

        End With

        With Grilla_Detalle

            OcultarEncabezadoGrilla(Grilla_Detalle, False)

            .Columns("BOSULIDO").Width = 35
            .Columns("BOSULIDO").HeaderText = "Bod"
            .Columns("BOSULIDO").Visible = True

            .Columns("KOPRCT").Width = 95
            .Columns("KOPRCT").HeaderText = "Código"
            .Columns("KOPRCT").Visible = True

            .Columns("NOKOPR").Width = 195
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True

            .Columns("CAPRCO" & _Unidad).Width = 70
            .Columns("CAPRCO" & _Unidad).HeaderText = "Cant."
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPRCO" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPRCO" & _Unidad).Visible = True

            .Columns("CAPREX" & _Unidad).Width = 70
            .Columns("CAPREX" & _Unidad).HeaderText = Mid(_Campo_Recep_Desp, 1, 5) & "."
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CAPREX" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("CAPREX" & _Unidad).Visible = True

            .Columns("SALDO_Ud" & _Unidad).Width = 70
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


            .Columns("STFI" & _Unidad).Width = 70
            .Columns("STFI" & _Unidad).HeaderText = "Stock"
            .Columns("STFI" & _Unidad).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("STFI" & _Unidad).DefaultCellStyle.Format = "###,##"
            .Columns("STFI" & _Unidad).Visible = True

        End With

    End Sub

    Private Sub Btn_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Excel.Click
        ExportarTabla_JetExcel_Tabla(_Tbl_Detalle, Me, "Productos_Detalle")
    End Sub

    Private Sub Grilla_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)

        Dim _Nombre_Grilla = CType(sender, Control).Name

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)

                    If _Nombre_Grilla = "Grilla_Documentos" Then
                        Btn_Estadisticas_Producto.Visible = False
                        Btn_Ver_Documento.Visible = True
                    ElseIf _Nombre_Grilla = "Grilla_Detalle" Then
                        Btn_Estadisticas_Producto.Visible = True
                        Btn_Ver_Documento.Visible = True
                    End If

                    ShowContextMenu(Menu_Contextual)

                End If
            End With
        End If

    End Sub

    Private Sub Grilla_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim _Nombre_Grilla = CType(sender, Control).Name
        Dim _Fila As DataGridViewRow = sender.Rows(sender.CurrentRow.Index)
        Dim _Tido = _Fila.Cells("TIDO").Value

        If _Nombre_Grilla = "Grilla_Documentos" Then
            Btn_Estadisticas_Producto.Visible = False
            Btn_Ver_Documento.Visible = True
            Btn_Facturar.Visible = (_Tido = "NVV")
        ElseIf _Nombre_Grilla = "Grilla_Detalle" Then
            Btn_Estadisticas_Producto.Visible = True
            Btn_Ver_Documento.Visible = True
            Btn_Facturar.Visible = False
        End If

        ShowContextMenu(Menu_Contextual)

    End Sub

    Private Sub Btn_Estadisticas_Producto_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Estadisticas_Producto.Click

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

    Private Sub Btn_Ver_Documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Documento.Click

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)
        Dim _New_Feer As Date
        Dim _Old_Feer As Date = FormatDateTime(_Fila.Cells("FEER").Value, DateFormat.ShortDate)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Marcar_Grilla_Pendientes = True
        Fm.ShowDialog(Me)
        _New_Feer = FormatDateTime(Fm.Pro_Row_Maeedo.Item("FEER"), DateFormat.ShortDate)
        Fm.Dispose()

        If _New_Feer <> _Old_Feer Then

            Consulta_sql = "UPDATE " & _Nombre_Tabla_Paso & vbCrLf &
                           "Set FEER = '" & Format(_New_Feer, "yyyyMMdd") & "', FEERLI = '" & Format(_New_Feer, "yyyyMMdd") & "'" & vbCrLf &
                           "Where IDMAEEDO = " & _Idmaeedo

            _Sql.Ej_consulta_IDU(Consulta_sql)

            _Fila.Cells("FEER").Value = _New_Feer

            For Each _Row As DataGridViewRow In Grilla_Detalle.Rows
                _Row.Cells("FEERLI").Value = _New_Feer
            Next
            ' BIG BALA
        End If

    End Sub

    Private Sub Btn_Facturar_Click(sender As Object, e As EventArgs) Handles Btn_Facturar.Click

        Dim _Fila As DataGridViewRow = Grilla_Documentos.Rows(Grilla_Documentos.CurrentRow.Index)

        Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value

        Sb_Crear_Documento_Desde_Otro_Automaticamente(Me, "FCV", _Idmaeedo)

        If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo) Then
            _Fila.DefaultCellStyle.BackColor = Color.LightGray
        End If

    End Sub

    Private Sub Btn_Facturacion_Masiva_Click(sender As Object, e As EventArgs) Handles Btn_Facturacion_Masiva.Click

        Dim _Lista_Idmaeedo As New List(Of String)

        For Each _Fila As DataGridViewRow In Grilla_Documentos.Rows
            Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
            If Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo) Then
                _Lista_Idmaeedo.Add(_Idmaeedo)
            End If
        Next

        If Not CBool(_Lista_Idmaeedo.Count) Then

            MessageBoxEx.Show(Me, "No existen documentos que facturar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return

        End If

        Dim _Filtro_Doc As String '= Generar_Filtro_IN(_Tbl_Productos, "", "IDMAEEDO", False, False, "")

        _Filtro_Doc = Generar_Filtro_IN_Arreglo(_Lista_Idmaeedo, True)
        _Filtro_Doc = "Where IDMAEEDO In " & _Filtro_Doc

        Me.Cursor = Cursors.WaitCursor

        Dim _Cl_Facturacion As New Clas_Facturacion_Masiva
        _Cl_Facturacion.Fx_Cargar_Tabla_Facturacion(_Filtro_Doc)
        _Cl_Facturacion.Fx_Cargar_Ds_Facturacion(_Filtro_Doc)

        Dim Fm As New Frm_Facturacion_Masiva
        Fm.Cl_Facturacion = _Cl_Facturacion

        Me.Cursor = Cursors.Default

        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Cursor = Cursors.WaitCursor

        For Each _Fila As DataGridViewRow In Grilla_Documentos.Rows
            Dim _Idmaeedo = _Fila.Cells("IDMAEEDO").Value
            If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo) Then
                _Fila.DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next

        Me.Cursor = Cursors.Default

    End Sub

    'Function Fx_Se_Puede_Facturar(_Idmaeedo As Integer) As Boolean

    '    Consulta_sql = "SELECT *
    '                    FROM MAEDDO  WITH ( NOLOCK ) 
    '                    WHERE IDMAEEDO =  " & _Idmaeedo & " AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''"

    '    Dim _Tbl_Saldo_Facturar As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

    '    Return CBool(_Tbl_Saldo_Facturar.Rows.Count)

    'End Function

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
