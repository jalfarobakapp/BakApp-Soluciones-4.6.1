Imports System.Globalization
Imports DevComponents.DotNetBar

Public Class Frm_Recalculo_PPPxProd

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Producto As DataRow
    Dim _FechaTope As DateTime
    Dim _Recalculado As Boolean
    Dim _NewPPP As Double

    Dim Cl_Pm As New Cl_PPPPr

    Dim _Dv As New DataView

    Private _ProductosTodos As Boolean
    Private _Tbl_Productos As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim _Fecha = "31/12/2021"
        Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        _FechaTope = _Global_Row_Configp.Item("FECHINIPPP")

        'Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        '_Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim
        Dtp_FechaTope.Value = _FechaTope
        Btn_Cancelar.Enabled = False

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Vertical, True, True, False)

    End Sub

    Private Sub Frm_Recalculo_PPPxProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Tiempo.Start()

        'Dim _Fecha = "31/12/2021"
        'Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        '_FechaTope = _Global_Row_Configp.Item("FECHINIPPP")

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

    End Sub

    Public Sub Sb_Actualizar_Grilla()

        Dim _FechaTope = Dtp_FechaTope.Value.ToString("yyyyMMdd")
        Dim _Condicion As String = String.Empty

        If IsNothing(_Tbl_Productos) And False = _ProductosTodos Then
            _Condicion = "And 1<0"
        Else
            If Not IsNothing(_Tbl_Productos) Then
                Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Productos, "Chk", "Codigo", False, True, "'")
                If Not String.IsNullOrEmpty(_Filtro) Then
                    _Condicion = "And MAEPR.KOPR In " & _Filtro
                End If
            End If
            If _ProductosTodos Then
                _Condicion = "And 1>0"
            End If
        End If

        Consulta_sql = "Select Cast(1 As Bit) As Chk,Cast('' As Varchar(10)) As Estado,MAEPREM.PMIN,MAEPREM.PM" &
                       ",MAEPREM.FEPM,Cast('" & _FechaTope & "' As Datetime) As 'FechaTope',Cast(0 As Float) As NewPM,MAEPR.KOPR,MAEPR.NOKOPR," &
                       "MAEPR.UD01PR,MAEPR.UD02PR,Cast(0 As Float) As Sum_Stock,Cast(0 As Float) As Stexistini " & vbCrLf &
                       "From MAEPR With ( Nolock )" & vbCrLf &
                       "Inner Join MAEPREM ON MAEPREM.KOPR=MAEPR.KOPR And MAEPREM.EMPRESA='" & ModEmpresa & "'" & vbCrLf &
                       "Where MAEPR.TIPR = 'FPN'" & vbCrLf &
                       _Condicion

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

        _Dv.Table = _Ds.Tables("Table")

        With Grilla

            .DataSource = _Dv

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("Chk").HeaderText = "Sel"
            .Columns("Chk").Width = 25
            .Columns("Chk").Visible = True
            .Columns("Chk").ReadOnly = False
            .Columns("Chk").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Estado").HeaderText = "Estado"
            .Columns("Estado").Width = 80
            .Columns("Estado").Visible = True
            .Columns("Estado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("KOPR").HeaderText = "Código"
            .Columns("KOPR").Width = 100
            .Columns("KOPR").Visible = True
            .Columns("KOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FEPM").HeaderText = "F.Ult.PPP"
            .Columns("FEPM").Width = 70
            .Columns("FEPM").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FEPM").Visible = True
            .Columns("FEPM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PM").Width = 80
            .Columns("PM").HeaderText = "PPP Actual"
            .Columns("PM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PM").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("PM").Visible = True
            .Columns("PM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NewPM").Width = 80
            .Columns("NewPM").HeaderText = "Nuevo PPP"
            .Columns("NewPM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NewPM").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("NewPM").Visible = True
            .Columns("NewPM").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Stexistini").Width = 80
            .Columns("Stexistini").HeaderText = "Stock Ini."
            .Columns("Stexistini").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Stexistini").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Stexistini").Visible = True
            .Columns("Stexistini").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Sum_Stock").Width = 80
            .Columns("Sum_Stock").HeaderText = "Stock Fin"
            .Columns("Sum_Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Sum_Stock").DefaultCellStyle.Format = "###,##0.##"
            .Columns("Sum_Stock").Visible = True
            .Columns("Sum_Stock").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("FechaTope").HeaderText = "FIR PPP"
            .Columns("FechaTope").Width = 70
            .Columns("FechaTope").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaTope").Visible = True
            .Columns("FechaTope").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 300
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Sub Sb_Recalcupar_PPP()

        'Dim _Fecha = "31/12/2021"
        'Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        Dim _Codigo = _Row_Producto.Item("KOPR").ToString.Trim

        Dim _Mensaje As LsValiciones.Mensajes

        _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR(_Codigo, _FechaTope)

        If _Mensaje.EsCorrecto Then
            _Recalculado = True
            _NewPPP = Cl_Pm.Pm
            ExportarTabla_JetExcel_Tabla(Cl_Pm.TblDetalleDocs, Me, "Historia PPP " & _Codigo)
            Me.Close()
        End If

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs) Handles Tiempo.Tick
        Tiempo.Stop()
        If MessageBoxEx.Show(Me, "¿confirma el racalculo?", "Recalcular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Btn_Cancelar.Enabled = True
            Sb_Recalcupar_PPP()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Cl_Pm.Cancelar = True
        MessageBoxEx.Show(Me, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Me.Close()
    End Sub

    Private Sub Btn_TraerProductos_Click(sender As Object, e As EventArgs) Handles Btn_TraerProductos.Click

        Dim _Sql_Filtro_Condicion_Extra = "And TIPR = 'FPN'"

        Dim _Filtrar As New Clas_Filtros_Random(Me)

        If _Filtrar.Fx_Filtrar(_Tbl_Productos,
                               Clas_Filtros_Random.Enum_Tabla_Fl._Productos, _Sql_Filtro_Condicion_Extra,
                               False, False) Then

            _Tbl_Productos = _Filtrar.Pro_Tbl_Filtro
            If _Filtrar.Pro_Filtro_Todas Then
                _ProductosTodos = True
                _Tbl_Productos = Nothing
            End If

            Sb_Actualizar_Grilla()

        End If

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        If Grilla.Rows.Count = 0 Then
            MessageBoxEx.Show(Me, "No existen productos para recalcular", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim productosSeleccionados As New List(Of DataGridViewRow)

        For Each fila As DataGridViewRow In Grilla.Rows
            If Not fila.IsNewRow AndAlso Convert.ToBoolean(fila.Cells("Chk").Value) Then
                productosSeleccionados.Add(fila)
            End If
        Next

        If productosSeleccionados.Count = 0 Then
            MessageBoxEx.Show(Me, "Debe seleccionar al menos un producto para recalcular.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Dim _LsMensajes As New List(Of LsValiciones.Mensajes)

        ' Configurar la barra de progreso
        Progreso_XProducto.Minimum = 0
        Progreso_XProducto.Maximum = productosSeleccionados.Count
        Progreso_XProducto.Value = 0
        Progreso_XProducto.Visible = True

        Dim _UltTabla As DataTable

        For i As Integer = 0 To productosSeleccionados.Count - 1
            Dim fila As DataGridViewRow = productosSeleccionados(i)

            ' Establecer el foco en la fila actual
            Grilla.ClearSelection()
            fila.Selected = True
            Grilla.CurrentCell = fila.Cells("Chk")

            Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
            Dim _Descripcion As String = fila.Cells("NOKOPR").Value.ToString()

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR2(_Codigo, _Descripcion, _FechaTope, Progreso_XDetalle)

            _LsMensajes.Add(_Mensaje)

            fila.Cells("Estado").Value = If(_Mensaje.EsCorrecto, "Procesado", "Error")
            fila.Cells("NewPM").Value = If(_Mensaje.EsCorrecto, Cl_Pm.Pm, 0.0)
            fila.Cells("Stexistini").Value = Cl_Pm.Stexistini
            fila.Cells("Sum_Stock").Value = Cl_Pm.Saldo_Stock

            _UltTabla = _Mensaje.Tag

            ' Actualizar barra de progreso y mostrar estado
            Progreso_XProducto.Value = i + 1
            Dim porcentaje As Integer = CInt(((i + 1) / productosSeleccionados.Count) * 100)
            Progreso_XProducto.Text = "Procesando producto " & FormatNumber(i + 1, 0) & " de " & FormatNumber(productosSeleccionados.Count, 0) & "  (" & porcentaje & "%)"
            Application.DoEvents()

        Next

        Progreso_XProducto.Visible = False

        If productosSeleccionados.Count = 1 AndAlso Not IsNothing(_UltTabla) Then
            Dim fila As DataGridViewRow = productosSeleccionados(0)
            Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
            ExportarTabla_JetExcel_Tabla(_UltTabla, Me, _Codigo & " Revisar PPP producto detalle")
        End If

        '' Ejemplo de procesamiento de los productos seleccionados
        'For Each fila As DataGridViewRow In productosSeleccionados

        '    ' Establecer el foco en la fila actual
        '    Grilla.ClearSelection()
        '    fila.Selected = True
        '    Grilla.CurrentCell = fila.Cells("Chk")
        '    'Grilla.FirstDisplayedScrollingRowIndex = fila.Index

        '    Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
        '    Dim _Descripcion As String = fila.Cells("NOKOPR").Value.ToString()

        '    Dim _Mensaje As LsValiciones.Mensajes

        '    _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR2(_Codigo, _Descripcion, _FechaTope, Progreso_XDetalle)

        '    _LsMensajes.Add(_Mensaje)

        '    fila.Cells("Estado").Value = If(_Mensaje.EsCorrecto, "Procesado", "Error")
        '    fila.Cells("NewPM").Value = If(_Mensaje.EsCorrecto, Cl_Pm.Pm, 0.0)
        '    fila.Cells("Stexistini").Value = Cl_Pm.Stexistini
        '    fila.Cells("Sum_Stock").Value = Cl_Pm.Sum_Stock

        '    'Stexistini Sum_Stock

        'Next

        MessageBoxEx.Show(Me, "Procesamiento finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Dim Fmv As New Frm_Validaciones
        'Fmv.ListaMensajes = _LsMensajes
        'Fmv.ShowDialog(Me)
        'Fmv.Dispose()

        ExportarTabla_JetExcel_Tabla(_Dv.Table, Me, "Resultados Recalculo PPP")

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub
End Class
