'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_InvMargenesDet_

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Detalle As DataTable

    Dim _Codigo As String
    Dim _Descripcion As String

    Public Sub New(_Codigo As String, _Descripcion As String, _Tbl_Detalle As DataTable)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(GrillaDetalle, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)

        Me._Codigo = _Codigo
        Me._Descripcion = _Descripcion
        Me._Tbl_Detalle = _Tbl_Detalle

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_InvMargenesDet_Mt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler GrillaDetalle.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        GrillaDetalle.DataSource = _Tbl_Detalle

        TxtProducto.Text = _Codigo
        TxtDescripcion.Text = _Descripcion

        FormatoGrilla()

    End Sub

    Private Sub FormatoGrilla()

        With GrillaDetalle

            OcultarEncabezadoGrilla(GrillaDetalle)

            Dim _DisplayIndex = 0

            .Columns("Tido").Width = 30
            .Columns("Tido").HeaderText = "TD"
            .Columns("Tido").Visible = True
            .Columns("Tido").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Nudo").Width = 70
            .Columns("Nudo").HeaderText = "Número"
            .Columns("Nudo").Visible = True
            .Columns("Nudo").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Feemli").Width = 70
            .Columns("Feemli").HeaderText = "Fecha"
            .Columns("Feemli").Visible = True
            .Columns("Feemli").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CantidadUd1").Width = 50
            .Columns("CantidadUd1").HeaderText = "Cant. Ud1"
            .Columns("CantidadUd1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CantidadUd1").DefaultCellStyle.Format = "###,##"
            .Columns("CantidadUd1").Visible = True
            .Columns("CantidadUd1").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("PNetoUnit").Width = 65
            .Columns("PNetoUnit").HeaderText = "Precio Unitario"
            .Columns("PNetoUnit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PNetoUnit").DefaultCellStyle.Format = "$ ###,##"
            .Columns("PNetoUnit").Visible = True
            .Columns("PNetoUnit").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CostoUnitIm").Width = 65
            .Columns("CostoUnitIm").HeaderText = "Costo Unitario"
            .Columns("CostoUnitIm").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CostoUnitIm").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CostoUnitIm").Visible = True
            .Columns("CostoUnitIm").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalCosto").Width = 80
            .Columns("TotalCosto").HeaderText = "Total Costo"
            .Columns("TotalCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalCosto").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalCosto").Visible = True
            .Columns("TotalCosto").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("TotalPrecio").Width = 80
            .Columns("TotalPrecio").HeaderText = "Total Precio"
            .Columns("TotalPrecio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrecio").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TotalPrecio").Visible = True
            .Columns("TotalPrecio").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Total_Mrg").Width = 80
            .Columns("Total_Mrg").HeaderText = "Total Margen"
            .Columns("Total_Mrg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total_Mrg").DefaultCellStyle.Format = "$ ###,##"
            .Columns("Total_Mrg").Visible = True
            .Columns("Total_Mrg").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Porc_Markup").Width = 80
            .Columns("Porc_Markup").HeaderText = "Margen %"
            .Columns("Porc_Markup").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Porc_Markup").DefaultCellStyle.Format = "% ##0.##"
            .Columns("Porc_Markup").Visible = True
            .Columns("Porc_Markup").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Funcionario").Width = 40
            .Columns("Funcionario").HeaderText = "Func"
            .Columns("Funcionario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Funcionario").Visible = True
            .Columns("Funcionario").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("Precio_Cambiado").Width = 30
            .Columns("Precio_Cambiado").HeaderText = "P/C"
            .Columns("Precio_Cambiado").ToolTipText = "Precio cambiado"
            .Columns("Precio_Cambiado").Visible = True
            .Columns("Precio_Cambiado").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

        End With

    End Sub

    Private Sub GrillaDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrillaDetalle.CellDoubleClick

        Me.Enabled = False

        Dim _Tido, _Nudo, _Koprct As String
        Dim _Idmaeedo As Integer

        Dim _Fila As DataGridViewRow = GrillaDetalle.Rows(GrillaDetalle.CurrentRow.Index)

        _Koprct = _Fila.Cells("Koprct").Value
        _Tido = _Fila.Cells("Tido").Value
        _Nudo = _Fila.Cells("Nudo").Value

        _Idmaeedo = _Sql.Fx_Trae_Dato("MAEDDO", "IDMAEEDO", "TIDO = '" & _Tido & "' AND NUDO = '" & _Nudo & "'")

        Dim Fm As New Frm_Ver_Documento(_Idmaeedo, Frm_Ver_Documento.Enum_Tipo_Apertura.Desde_Random_SQL)
        Fm.Codigo_Marcar = _Koprct
        Fm.ShowDialog(Me)
        Fm.Dispose()

        Me.Enabled = True

    End Sub

    Private Sub Btn_Excel_Detalle_Click(sender As Object, e As EventArgs) Handles Btn_Excel_Detalle.Click

        ExportarTabla_JetExcel_Tabla(_Tbl_Detalle, Me, "Detalle_Doc_Mrgn")

    End Sub

End Class
