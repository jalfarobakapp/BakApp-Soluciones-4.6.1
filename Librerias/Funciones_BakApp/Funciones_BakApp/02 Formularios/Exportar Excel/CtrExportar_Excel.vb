Imports Docs.Excel
Imports System.Windows.Forms
Imports DevComponents.DotNetBar


Public Class CtrExportar_Excel

    Public FmPrincipal As DevComponents.DotNetBar.Metro.MetroAppForm

    Dim Cancelar As Boolean = False
    Dim Direc As String = ""
    Public TablaExcel As DataTable


    Sub ExpExcelJet(ByVal Tabla As DataTable, _
             ByVal Bar As Object, _
             ByVal Bar2 As Object, _
             Optional ByVal NombreArchivo As String = "BkExcel", _
             Optional ByVal Hoja As String = "hoja1", _
             Optional ByVal Directorio As String = "", _
             Optional ByVal Extencion As String = "xlsx")

        If Directorio = "" Then Directorio = "..\..\..\"
        Cancelar = False
        'Create a new workbook.
        ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
        Dim Wbook = New ExcelWorkbook()

        'Add new worksheet to workbook.
        Wbook.Worksheets.Add("Hoja1")


        Dim fila As Integer = 0
        Dim columna As Integer = 0

        ' xls, xlsx
        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////

        For Each dc In Tabla.Columns
            With Wbook.Worksheets(0).Rows(0).Cells(columna)
                .Style.Font.Bold = True
                .Style.Font.Color = ColorPalette.Blue
                .Value = dc.ColumnName
                columna += 1
            End With

            If Cancelar = True Then
                Bar.Value = 0
                Procesando(True, False)
                Exit Sub
            End If
        Next
        fila += 1

        'Bar = BarraProgreso

        Bar.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Bar2.Maximum = Tabla.Rows.Count

        columna = 1
        Bar.Value = 0
        Bar2.Value = 0

        Dim Contador = 0
        'AddHandler Wbook.Progress, AddressOf workbook_SavingProgress

        For Each dr In Tabla.Rows
            System.Windows.Forms.Application.DoEvents()
            columna = 0
            For Each dc In Tabla.Columns

                Dim Contenido = dr(dc.ColumnName).ToString

                'Dim dtp As DataColumn = dc
                Dim ty As Type = dc.DataType
                Dim TipoDeDato As String = ty.Name.ToString

                If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                    Wbook.Worksheets(0).Cells(fila, columna).Value = De_Txt_a_Num_01(Contenido, 3)
                    Wbook.Worksheets(0).Cells(fila, columna).Style.StringFormat = "0.00"
                Else
                    Wbook.Worksheets(0).Rows(fila).Cells(columna).Value = dr(dc.ColumnName).ToString
                End If

                If Cancelar = True Then
                    Bar.Value = 0 : Bar2.Value = 0
                    Procesando(True, False)
                    Exit Sub
                End If

                'objHojaExcel.Range(nombreColumna(columna) & fila).Value = "'" & dr(dc.ColumnName).ToString
                columna += 1
            Next
            fila += 1

            '3000 = 100
            '23 = x
            Contador += 1
            Bar.Value = ((Contador * 100) / Tabla.Rows.Count) 'Mas
            Bar2.value += 1 ' Contador
            If Cancelar = True Then
                Bar.Value = 0 : Bar2.Value = 0
                Procesando(True, False)
                Exit Sub
            End If
        Next

        'AddHandler Wbook.Progress, Nothing
        If Cancelar = True Then
            Bar.Value = 0 : Bar2.Value = 0
            Procesando(True, False)
            Exit Sub
        End If
        Procesando(False, False)
        'Write .xlsx file.

        Dim ArchivoGuardado As String = Directorio & NombreArchivo & "." & Extencion

        ' ArchivoGuardado = "..\..\..\DataTableImport.xlsx"


        Wbook.WriteXLSX(ArchivoGuardado)
        'Wbook.WriteXLS(ArchivoGuardado)

        'Wbook.WriteXLS("..\..\..\" & NombreArchivo & ".xls")
        'Open specified file in MS Excel.
        MsgBox("El documento fue guardado con exito en la carpeta:" & vbCrLf & _
               ArchivoGuardado, MsgBoxStyle.Information, "Exportar a Excel")

        If MsgBox("¿Desea Abrir el archivo " & ArchivoGuardado & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Abrir docuemto Excel") = MsgBoxResult.Yes Then
            Try
                System.Diagnostics.Process.Start(ArchivoGuardado)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Bar.Value = 0
        Bar2.Value = 0
        Procesando(True, False)

    End Sub

    Sub Procesando(ByVal OP As Boolean, ByVal Tk As Boolean)
        TxtNombreArchivo.Enabled = OP
        BtnBuscarDireccion.Enabled = OP
        BtnExportarExcel.Enabled = OP
        BtnSalir.Enabled = OP
        BtnCancelar.Enabled = Tk
    End Sub

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        Procesando(False, True)
        'CircularProgress2.IsRunning = True
        'tb = get_Tablas(Consulta_sql, cn1)

        ExpExcelJet(TablaExcel, CircularProgress1, CircularProgress2, TxtNombreArchivo.Text, "", Direc)
        'CircularProgress2.IsRunning = False
        Cancelar = False
        Procesando(True, Cancelar)
        FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Top)
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Cancelar = True
        Procesando(True, False)
    End Sub

    Private Sub CtrExportar_Excel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtNombreArchivo.SelectAll()
        TxtNombreArchivo.Focus()
        BtnCancelar.Enabled = False
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        FmPrincipal.CloseModalPanel(Me, DevComponents.DotNetBar.Controls.eSlideSide.Left)
    End Sub

    Private Sub BtnVerTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerTabla.Click
        If TablaExcel.Rows.Count > 0 Then
            Dim Fm As New Frm_CargarTablasDePaso
            Fm._Tabla_de_Paso = TablaExcel
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Ver detalle", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnBuscarDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarDireccion.Click
        SvfDirectorio.FileName = TxtNombreArchivo.Text & ".xlsx"
        If SvfDirectorio.ShowDialog = DialogResult.OK Then
            TxtNombreArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(SvfDirectorio.FileName)
            Direc = Replace(SvfDirectorio.FileName, TxtNombreArchivo.Text & ".xlsx", "")
        End If
    End Sub
End Class
