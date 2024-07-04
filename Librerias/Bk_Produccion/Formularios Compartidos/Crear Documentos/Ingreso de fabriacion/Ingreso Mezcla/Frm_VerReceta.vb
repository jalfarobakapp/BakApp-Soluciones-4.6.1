Imports BkSpecialPrograms
Public Class Frm_VerReceta

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Row_Receta As DataRow
    Dim _Tbl_Receta As DataTable
    Dim _Codnomen As String

    Public Property NoMostrarMarcaFactorMezcla As Boolean
    Public Property MostrarSoloMarcaFactorMezcla As Boolean

    Public Sub New(_Codnomen As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Codnomen = _Codnomen

        _Row_Receta = _Sql.Fx_Get_DataRow("Select * From PNPE Where CODIGO = '" & _Codnomen & "'")

        Sb_Formato_Generico_Grilla(Grilla, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, False)
        Sb_Color_Botones_Barra(Bar1)

    End Sub
    Private Sub Frm_VerReceta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Receta: " & _Row_Receta.Item("CODIGO") & " - " & _Row_Receta.Item("DESCRIPTOR")

        AddHandler Grilla.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Sb_ActualizaGrilla()

    End Sub

    Sub Sb_ActualizaGrilla()

        Dim _Condicion As String = String.Empty

        If NoMostrarMarcaFactorMezcla Then
            _Condicion = "And PNPD.ELEMENTO Not In " &
                         "(Select KOPR From MAEPR Where MRPR In " &
                         "(Select CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'TARJA_MEZCLASMRFACTOR'))" & vbCrLf
        End If

        If MostrarSoloMarcaFactorMezcla Then
            _Condicion = "And PNPD.ELEMENTO In " &
                         "(Select KOPR From MAEPR Where MRPR In " &
                         "(Select CodigoTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones Where Tabla = 'TARJA_MEZCLASMRFACTOR'))" & vbCrLf
        End If

        Consulta_sql = "Select PNPD.ELEMENTO,NOKOPR,PNPD.UDAD,CANTIDAD From PNPD" & vbCrLf &
                       "Inner Join MAEPR On KOPR = ELEMENTO" & vbCrLf &
                       "Where CODIGO = '" & _Codnomen & "'" & vbCrLf &
                       _Condicion &
                       "Order By NREG"
        _Tbl_Receta = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla

            .DataSource = _Tbl_Receta

            OcultarEncabezadoGrilla(Grilla)

            Dim _DisplayIndex = 0

            .Columns("ELEMENTO").Width = 100
            .Columns("ELEMENTO").HeaderText = "Código"
            .Columns("ELEMENTO").Visible = True
            .Columns("ELEMENTO").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("NOKOPR").Width = 380
            .Columns("NOKOPR").HeaderText = "Descripción"
            .Columns("NOKOPR").Visible = True
            .Columns("NOKOPR").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("UDAD").Width = 40
            .Columns("UDAD").HeaderText = "UN"
            .Columns("UDAD").Visible = True
            .Columns("UDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").Width = 100
            .Columns("CANTIDAD").HeaderText = "Cantidad"
            .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("CANTIDAD").DefaultCellStyle.Format = "N2"
            .Columns("CANTIDAD").Visible = True
            .Columns("CANTIDAD").DisplayIndex = _DisplayIndex
            _DisplayIndex += 1

            .Columns("CANTIDAD").DefaultCellStyle.Format = "N2"

        End With

        Dim _SumaCantiades As Double = 0

        For Each row As DataRow In _Tbl_Receta.Rows
            Dim cantidad As Double = CDbl(row("CANTIDAD"))
            _SumaCantiades += cantidad
        Next

        Lbl_TotalCantidades.Text = _SumaCantiades.ToString("N2")

    End Sub

    Private Sub Btn_Exportar_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Excel.Click

        Dim vista As DataView '= CType(Grilla.DataSource, DataView)
        Dim dataTable As DataTable ' = Grilla.DataSource

        If TypeOf Grilla.DataSource Is DataTable Then
            dataTable = CType(Grilla.DataSource, DataTable)
            vista = dataTable.DefaultView
        End If

        Dim dataTablePaso As New DataTable()

        ' Agregar las columnas al DataTable de paso
        For Each columna As DataColumn In vista.Table.Columns

            Dim _NombreColumna As String = columna.ColumnName

            If Grilla.Columns(_NombreColumna).Visible Then
                dataTablePaso.Columns.Add(columna.ColumnName, columna.DataType)
            End If

        Next

        ' Recorrer cada fila de la vista y agregar una nueva fila al DataTable de paso
        For Each fila As DataRowView In vista
            Dim nuevaFila As DataRow = dataTablePaso.NewRow()

            ' Utilizar los valores de las celdas visibles para llenar las columnas del DataTable de paso
            For Each columna As DataColumn In vista.Table.Columns

                ' Asumiendo que dataTablePaso es tu DataTable y nuevaFila es tu DataRow
                Dim nombreColumna As String = columna.ColumnName '"Id" ' El nombre de la columna que quieres verificar

                ' Verifica si la columna existe en el DataTable
                If dataTablePaso.Columns.Contains(nombreColumna) Then
                    ' Si la columna existe, procede con tu lógica para asignar el valor
                    nuevaFila(nombreColumna) = fila(columna.ColumnName) ' Asegúrate de reemplazar 'valor' con el valor real que deseas asignar
                End If
            Next

            dataTablePaso.Rows.Add(nuevaFila)
        Next

        ' Utilizar el DataTable de paso según tus necesidades
        ' Por ejemplo, exportarlo a un archivo de Excel
        ExportarTabla_JetExcel_Tabla(dataTablePaso, Me, "Receta")
        ' ...

    End Sub
End Class
