Imports System.Globalization
Imports System.IO
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
    Private _ProcesoCanceladoPorUsuario As Boolean

    Private _EsEjecucionAutomatica As Boolean = False
    Private _RutaLogAutomatico As String '= IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogsPPP")
    Private _NombreArchivoLog As String = String.Format("LogPPP_{0:yyyyMMdd_HHmmss}.txt", Now)
    Public Property EjecutarProcesoTodosLosProductos As Boolean


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _RutaLogAutomatico = AppPath() & "\Data\" & RutEmpresa & "\Tmp\LogsPPP"
        If Not Directory.Exists(_RutaLogAutomatico) Then
            System.IO.Directory.CreateDirectory(_RutaLogAutomatico)
        End If

        ' Eliminar archivos log con más de una semana de antigüedad
        Try
            Dim archivosLog = Directory.GetFiles(_RutaLogAutomatico, "LogPPP_*.txt")
            For Each archivo In archivosLog
                Dim fechaModificacion As DateTime = File.GetLastWriteTime(archivo).Date
                If fechaModificacion < DateTime.Now.Date.AddDays(-7) Then
                    File.Delete(archivo)
                End If
            Next
        Catch ex As Exception
            ' Si falla la eliminación, no hacer nada
        End Try

        Dim _Fecha = "31/12/2021"
        Dim _FechaTope As DateTime = DateTime.ParseExact(_Fecha, "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None)

        _FechaTope = _Global_Row_Configp.Item("FECHINIPPP")

        'Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
        '_Row_Producto = _Sql.Fx_Get_DataRow(Consulta_sql)

        'Txt_Producto.Text = _Row_Producto.Item("KOPR").ToString.Trim & " - " & _Row_Producto.Item("NOKOPR").ToString.Trim
        Dtp_FechaTope.Value = _FechaTope
        Btn_Cancelar.Visible = False

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.White, ScrollBars.Both, True, True, False)

    End Sub

    Private Sub Frm_Recalculo_PPPxProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If EjecutarProcesoTodosLosProductos Then
            _ProductosTodos = True
            _EsEjecucionAutomatica = True
        End If

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_Actualizar_Grilla()

        If EjecutarProcesoTodosLosProductos Then
            Dim t As New Timer()
            t.Interval = 2000 ' 2 segundos
            AddHandler t.Tick, Sub(s, ev)
                                   t.Stop()
                                   t.Dispose()
                                   If Btn_Procesar.Enabled Then
                                       Call Btn_Procesar_Click(Nothing, Nothing)
                                   End If
                               End Sub
            t.Start()
        End If

    End Sub

    Private Sub GuardarLogAutomatico(ByVal lineas As List(Of String))
        Try
            If Not IO.Directory.Exists(_RutaLogAutomatico) Then
                IO.Directory.CreateDirectory(_RutaLogAutomatico)
            End If
            Dim rutaArchivo As String = IO.Path.Combine(_RutaLogAutomatico, _NombreArchivoLog)
            IO.File.WriteAllLines(rutaArchivo, lineas, System.Text.Encoding.UTF8)
        Catch ex As Exception
            ' Si falla el log, no hacer nada más
        End Try
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
                       "MAEPR.UD01PR,MAEPR.UD02PR,Cast(0 As Float) As Sum_Stock,Cast(0 As Float) As Stexistini,MAEPREM.PM As Pm2,MAEPREM.FEPM As Fepm2  " & vbCrLf &
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

            .Columns("Fepm2").HeaderText = "F.Ult.PPP2"
            .Columns("Fepm2").Width = 70
            .Columns("Fepm2").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("Fepm2").Visible = True
            .Columns("Fepm2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Pm2").Width = 80
            .Columns("Pm2").HeaderText = "PPP2"
            .Columns("Pm2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Pm2").DefaultCellStyle.Format = "$ ###,##0.##"
            .Columns("Pm2").Visible = True
            .Columns("Pm2").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub Tiempo_Tick(sender As Object, e As EventArgs)
        'Tiempo.Stop()
        'If MessageBoxEx.Show(Me, "¿confirma el racalculo?", "Recalcular", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    Btn_Cancelar.Enabled = True
        '    Sb_Recalcupar_PPP()
        'Else
        '    Me.Close()
        'End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        If MessageBoxEx.Show(Me, "¿Desea cancelar el proceso de recalculo?", "Cancelar proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cl_Pm.Cancelar = True
            _ProcesoCanceladoPorUsuario = True
            MessageBoxEx.Show(Me, "Acción cancelada por el usuario", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

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
            If _EsEjecucionAutomatica Then
                GuardarLogAutomatico(New List(Of String) From {"No existen productos para recalcular."})
                Me.Close()
                Return
            Else
                MessageBoxEx.Show(Me, "No existen productos para recalcular", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        Dim productosSeleccionados As New List(Of DataGridViewRow)

        For Each fila As DataGridViewRow In Grilla.Rows
            If Not fila.IsNewRow AndAlso Convert.ToBoolean(fila.Cells("Chk").Value) Then
                productosSeleccionados.Add(fila)
            End If
        Next

        If productosSeleccionados.Count = 0 Then
            If _EsEjecucionAutomatica Then
                GuardarLogAutomatico(New List(Of String) From {"Debe seleccionar al menos un producto para recalcular."})
                Me.Close()
                Return
            Else
                MessageBoxEx.Show(Me, "Debe seleccionar al menos un producto para recalcular.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
        End If

        Dim _LsMensajes As New List(Of LsValiciones.Mensajes)
        Dim _LogLineas As New List(Of String)

        Progreso_XProducto.Minimum = 0
        Progreso_XProducto.Maximum = productosSeleccionados.Count
        Progreso_XProducto.Value = 0
        Progreso_XProducto.Visible = True

        Dim _UltTabla As DataTable

        Dim sw As New Stopwatch()
        sw.Start()

        Btn_Procesar.Enabled = False
        Btn_TraerProductos.Enabled = False
        Btn_Cancelar.Visible = True

        MetroStatusBar1.Refresh()
        Me.Refresh()

        Cl_Pm.Cancelar = False
        _ProcesoCanceladoPorUsuario = False

        For i As Integer = 0 To productosSeleccionados.Count - 1

            If _ProcesoCanceladoPorUsuario OrElse Cl_Pm.Cancelar Then
                Exit For
            End If

            Dim fila As DataGridViewRow = productosSeleccionados(i)

            Grilla.ClearSelection()
            fila.Selected = True
            Grilla.CurrentCell = fila.Cells("Chk")

            Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
            Dim _Descripcion As String = fila.Cells("NOKOPR").Value.ToString()

            Dim _Mensaje As LsValiciones.Mensajes

            Cl_Pm.Pm_Maeprem = fila.Cells("PM2").Value
            Cl_Pm.Fepm_Maeprem = fila.Cells("FEPM2").Value

            _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR2(_Codigo, _Descripcion, _FechaTope, Progreso_XDetalle)

            _LsMensajes.Add(_Mensaje)

            fila.Cells("Estado").Value = If(_Mensaje.EsCorrecto, "Procesado", "Error")
            fila.Cells("NewPM").Value = If(_Mensaje.EsCorrecto, Cl_Pm.Pm, 0.0)
            fila.Cells("Stexistini").Value = Cl_Pm.Stexistini
            fila.Cells("Sum_Stock").Value = Cl_Pm.Saldo_Stock
            fila.Cells("Pm").Value = Cl_Pm.Pm
            fila.Cells("Fepm").Value = Cl_Pm.Fepm

            _UltTabla = _Mensaje.Tag

            Progreso_XProducto.Value = i + 1
            Dim porcentaje As Integer = CInt(((i + 1) / productosSeleccionados.Count) * 100)
            If i + 1 < productosSeleccionados.Count AndAlso porcentaje = 100 Then
                porcentaje = 99
            End If
            Progreso_XProducto.Text = "Procesando producto " & FormatNumber(i + 1, 0) & " de " & FormatNumber(productosSeleccionados.Count, 0) & "  (" & porcentaje & "%)"

            Dim tiempoTranscurrido As TimeSpan = sw.Elapsed
            Dim tiempoPorProducto As Double = 0
            Dim tiempoRestante As TimeSpan = TimeSpan.Zero

            If i + 1 > 0 Then
                tiempoPorProducto = tiempoTranscurrido.TotalSeconds / (i + 1)
                Dim productosRestantes As Integer = productosSeleccionados.Count - (i + 1)
                Dim segundosRestantes As Double = tiempoPorProducto * productosRestantes
                tiempoRestante = TimeSpan.FromSeconds(segundosRestantes)
            End If

            Lbl_StatusBar.Text = String.Format("Tiempo transcurrido: {0:hh\:mm\:ss} | Estimado restante: {1:hh\:mm\:ss}", tiempoTranscurrido, tiempoRestante)

            ' Agregar al log si es ejecución automática
            If _EsEjecucionAutomatica Then
                If Not _Mensaje.EsCorrecto Then
                    _LogLineas.Add(String.Format("ERROR: {0} - {1} | {2}", _Codigo, _Descripcion, _Mensaje.Mensaje))
                Else
                    _LogLineas.Add(String.Format("OK: {0} - {1}", _Codigo, _Descripcion))
                End If
            End If

            Application.DoEvents()

        Next

        Progreso_XProducto.Text = "100%"

        Dim mensajeFinal As String
        If _ProcesoCanceladoPorUsuario OrElse Cl_Pm.Cancelar Then
            mensajeFinal = String.Format("El proceso fue cancelado por el usuario. Total de productos procesados: {0}, Tiempo total: {1:hh\:mm\:ss}", Progreso_XProducto.Value, sw.Elapsed)
        Else
            mensajeFinal = String.Format("Proceso finalizado. Total de productos: {0}, Tiempo total: {1:hh\:mm\:ss}", productosSeleccionados.Count, sw.Elapsed)
        End If

        Lbl_StatusBar.Text = mensajeFinal

        If _EsEjecucionAutomatica Then
            _LogLineas.Add("")
            _LogLineas.Add(mensajeFinal)
            GuardarLogAutomatico(_LogLineas)
            Me.Close()
            Return
        Else
            MessageBoxEx.Show(Me, mensajeFinal, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If Progreso_XProducto.Value > 0 Then
            Dim tablaProcesados As DataTable = _Dv.Table.Clone()
            For Each fila As DataGridViewRow In Grilla.Rows
                If Not fila.IsNewRow AndAlso Not String.IsNullOrEmpty(fila.Cells("Estado").Value?.ToString()) Then
                    If fila.Cells("Estado").Value.ToString() = "Procesado" OrElse fila.Cells("Estado").Value.ToString() = "Error" Then
                        Dim dr As DataRow = tablaProcesados.NewRow()
                        For Each col As DataGridViewColumn In Grilla.Columns
                            dr(col.Name) = fila.Cells(col.Name).Value
                        Next
                        tablaProcesados.Rows.Add(dr)
                    End If
                End If
            Next
            ExportarTabla_JetExcel_Tabla(tablaProcesados, Me, "Resultados Recalculo PPP")
        End If

        Btn_Procesar.Enabled = True
        Btn_TraerProductos.Enabled = True
        Btn_Cancelar.Visible = False

        Lbl_StatusBar.Text = "Bakapp Soluciones"
        Me.Refresh()

        'If Grilla.Rows.Count = 0 Then
        '    MessageBoxEx.Show(Me, "No existen productos para recalcular", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'Dim productosSeleccionados As New List(Of DataGridViewRow)

        'For Each fila As DataGridViewRow In Grilla.Rows
        '    If Not fila.IsNewRow AndAlso Convert.ToBoolean(fila.Cells("Chk").Value) Then
        '        productosSeleccionados.Add(fila)
        '    End If
        'Next

        'If productosSeleccionados.Count = 0 Then
        '    MessageBoxEx.Show(Me, "Debe seleccionar al menos un producto para recalcular.", "Validación",
        '                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Return
        'End If

        'Dim _LsMensajes As New List(Of LsValiciones.Mensajes)

        '' Configurar la barra de progreso
        'Progreso_XProducto.Minimum = 0
        'Progreso_XProducto.Maximum = productosSeleccionados.Count
        'Progreso_XProducto.Value = 0
        'Progreso_XProducto.Visible = True

        'Dim _UltTabla As DataTable

        '' Variables para medir el tiempo
        'Dim sw As New Stopwatch()
        'sw.Start()

        'Btn_Procesar.Enabled = False
        'Btn_TraerProductos.Enabled = False
        'Btn_Cancelar.Visible = True

        'MetroStatusBar1.Refresh()
        'Me.Refresh()

        'For i As Integer = 0 To productosSeleccionados.Count - 1

        '    If _ProcesoCanceladoPorUsuario OrElse Cl_Pm.Cancelar Then
        '        Exit For
        '    End If

        '    Dim fila As DataGridViewRow = productosSeleccionados(i)

        '    ' Establecer el foco en la fila actual
        '    Grilla.ClearSelection()
        '    fila.Selected = True
        '    Grilla.CurrentCell = fila.Cells("Chk")

        '    Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
        '    Dim _Descripcion As String = fila.Cells("NOKOPR").Value.ToString()

        '    Dim _Mensaje As LsValiciones.Mensajes

        '    _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR2(_Codigo, _Descripcion, _FechaTope, Progreso_XDetalle)

        '    _LsMensajes.Add(_Mensaje)

        '    fila.Cells("Estado").Value = If(_Mensaje.EsCorrecto, "Procesado", "Error")
        '    fila.Cells("NewPM").Value = If(_Mensaje.EsCorrecto, Cl_Pm.Pm, 0.0)
        '    fila.Cells("Stexistini").Value = Cl_Pm.Stexistini
        '    fila.Cells("Sum_Stock").Value = Cl_Pm.Saldo_Stock
        '    fila.Cells("Pm2").Value = Cl_Pm.Pm
        '    fila.Cells("Fepm2").Value = Cl_Pm.Fepm

        '    _UltTabla = _Mensaje.Tag

        '    ' Actualizar barra de progreso y mostrar estado
        '    Progreso_XProducto.Value = i + 1
        '    Dim porcentaje As Integer = CInt(((i + 1) / productosSeleccionados.Count) * 100)

        '    ' Si aún no es la última iteración y el porcentaje es 100, mostrar 99%
        '    If i + 1 < productosSeleccionados.Count AndAlso porcentaje = 100 Then
        '        porcentaje = 99
        '    End If
        '    ' Actualizar el texto de la barra de progreso
        '    Progreso_XProducto.Text = "Procesando producto " & FormatNumber(i + 1, 0) & " de " & FormatNumber(productosSeleccionados.Count, 0) & "  (" & porcentaje & "%)"

        '    ' Calcular tiempo transcurrido y estimado
        '    Dim tiempoTranscurrido As TimeSpan = sw.Elapsed
        '    Dim tiempoPorProducto As Double = 0
        '    Dim tiempoRestante As TimeSpan = TimeSpan.Zero

        '    If i + 1 > 0 Then
        '        tiempoPorProducto = tiempoTranscurrido.TotalSeconds / (i + 1)
        '        Dim productosRestantes As Integer = productosSeleccionados.Count - (i + 1)
        '        Dim segundosRestantes As Double = tiempoPorProducto * productosRestantes
        '        tiempoRestante = TimeSpan.FromSeconds(segundosRestantes)
        '    End If

        '    Lbl_StatusBar.Text = String.Format("Tiempo transcurrido: {0:hh\:mm\:ss} | Estimado restante: {1:hh\:mm\:ss}", tiempoTranscurrido, tiempoRestante)

        '    Application.DoEvents()

        'Next

        'Progreso_XProducto.Text = "100%"

        'If productosSeleccionados.Count = 1 AndAlso Not IsNothing(_UltTabla) Then
        '    Dim fila As DataGridViewRow = productosSeleccionados(0)
        '    Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()
        '    ExportarTabla_JetExcel_Tabla(_UltTabla, Me, _Codigo & " Revisar PPP producto detalle")
        'End If

        'Dim mensajeFinal As String
        'If _ProcesoCanceladoPorUsuario OrElse Cl_Pm.Cancelar Then
        '    mensajeFinal = String.Format("El proceso fue cancelado por el usuario. Total de productos procesados: {0}, Tiempo total: {1:mm\:ss}", Progreso_XProducto.Value, sw.Elapsed)
        'Else
        '    mensajeFinal = String.Format("Proceso finalizado. Total de productos: {0}, Tiempo total: {1:mm\:ss}", productosSeleccionados.Count, sw.Elapsed)
        'End If

        'Lbl_StatusBar.Text = mensajeFinal

        'MessageBoxEx.Show(Me, mensajeFinal, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '' Exportar los registros procesados
        'If Progreso_XProducto.Value > 0 Then
        '    Dim tablaProcesados As DataTable = _Dv.Table.Clone()
        '    For Each fila As DataGridViewRow In Grilla.Rows
        '        If Not fila.IsNewRow AndAlso Not String.IsNullOrEmpty(fila.Cells("Estado").Value?.ToString()) Then
        '            If fila.Cells("Estado").Value.ToString() = "Procesado" OrElse fila.Cells("Estado").Value.ToString() = "Error" Then
        '                Dim dr As DataRow = tablaProcesados.NewRow()
        '                For Each col As DataGridViewColumn In Grilla.Columns
        '                    dr(col.Name) = fila.Cells(col.Name).Value
        '                Next
        '                tablaProcesados.Rows.Add(dr)
        '            End If
        '        End If
        '    Next
        '    ExportarTabla_JetExcel_Tabla(tablaProcesados, Me, "Resultados Recalculo PPP")
        'End If

        ''Lbl_StatusBar.Text = String.Format("Proceso finalizado. Total de productos:{1}, Tiempo total: {0:mm\:ss}", sw.Elapsed, productosSeleccionados.Count)

        ''MessageBoxEx.Show(Me, Lbl_StatusBar.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '''Dim Fmv As New Frm_Validaciones
        '''Fmv.ListaMensajes = _LsMensajes
        '''Fmv.ShowDialog(Me)
        '''Fmv.Dispose()
        ''Progreso_XProducto.Text = String.Empty

        ''ExportarTabla_JetExcel_Tabla(_Dv.Table, Me, "Resultados Recalculo PPP")

        'Btn_Procesar.Enabled = True
        'Btn_TraerProductos.Enabled = True
        'Btn_Cancelar.Visible = False

        'Lbl_StatusBar.Text = "Bakapp Soluciones"
        'Me.Refresh()

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        ' Confirmar antes de limpiar
        If MessageBoxEx.Show(Me, "¿Está seguro que desea limpiar la selección y los datos mostrados?", "Confirmar limpieza",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        ' Limpiar variables relacionadas con los productos
        _Tbl_Productos = Nothing
        _ProductosTodos = False
        _ProcesoCanceladoPorUsuario = False

        ' Limpiar la fuente de datos de la grilla
        If Not IsNothing(Grilla.DataSource) Then
            Grilla.DataSource = Nothing
        End If
        _Dv.Table = Nothing

        ' Limpiar barra de progreso y estado
        Progreso_XProducto.Value = 0
        Progreso_XProducto.Text = String.Empty
        Progreso_XProducto.Visible = False
        Lbl_StatusBar.Text = "Bakapp Soluciones"

        Sb_Actualizar_Grilla()

        ' Refrescar controles
        Me.Refresh()
    End Sub
End Class
