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

        Consulta_sql = "Select Cast(0 As Bit) As Chk,Cast('' As Varchar(10)) As Estado,MAEPREM.PMIN,MAEPREM.PM" &
                       ",MAEPREM.FEPM,Cast('" & _FechaTope & "' As Datetime) As 'FechaTope',Cast(0 As Float) As New_PM,MAEPR.KOPR,MAEPR.NOKOPR," &
                       "MAEPR.UD01PR,MAEPR.UD02PR,MAEPR.KOPRRA,MAEPR.KOPRTE,MAEPR.FMPR,MAEPR.PFPR,MAEPR.HFPR,MAEPR.MRPR,RUPR" & vbCrLf &
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
            .Columns("Estado").Width = 50
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

            .Columns("FechaTope").HeaderText = "FIR PPP"
            .Columns("FechaTope").Width = 70
            .Columns("FechaTope").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("FechaTope").Visible = True
            .Columns("FechaTope").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Width = 250
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

        ' Ejemplo de procesamiento de los productos seleccionados
        For Each fila As DataGridViewRow In productosSeleccionados

            Dim _Codigo As String = fila.Cells("KOPR").Value.ToString()

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = Cl_Pm.Fx_RecalcularPPPxPR2(_Codigo, _FechaTope, ProgressBarX1)

            _LsMensajes.Add(_Mensaje)

            fila.Cells("Estado").Value = If(_Mensaje.EsCorrecto, "Procesado", "Error")

        Next

        MessageBoxEx.Show(Me, "Procesamiento finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim Fmv As New Frm_Validaciones
        Fmv.ListaMensajes = _LsMensajes
        Fmv.ShowDialog(Me)
        Fmv.Dispose()

    End Sub

    Private Sub Grilla_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grilla.CellMouseUp
        Grilla.EndEdit()
    End Sub
End Class
