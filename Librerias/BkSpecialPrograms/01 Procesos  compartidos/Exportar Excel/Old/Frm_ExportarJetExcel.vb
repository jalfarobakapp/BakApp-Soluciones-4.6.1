Imports Docs.Excel
Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_ExportarJetExcel

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Cancelar As Boolean = False
    Dim _Direc As String = ""

    Dim _TablaExcel As DataTable

    Public Property Pro_TablaExcel As DataTable
        Get
            Return _TablaExcel
        End Get
        Set(value As DataTable)
            _TablaExcel = value
        End Set
    End Property

    Sub ExpExcelJet(ByVal Tabla As DataTable,
             ByVal Bar As Object,
             ByVal Bar2 As Object,
             Optional ByVal NombreArchivo As String = "BkExcel",
             Optional ByVal Hoja As String = "hoja1",
             Optional ByVal _Directorio As String = "",
             Optional ByVal Extencion As String = "xlsx")
        Try


            If _Directorio = "" Then _Directorio = "..\..\..\"
            _Cancelar = False
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

                If _Cancelar = True Then
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

                    Dim _Valor

                    If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                        Dim _Valor_ As Double = De_Txt_a_Num_01(Contenido, 2) 'Gl_Fx_De_Num_a_Tx_01(Contenido, False, 2)
                        Wbook.Worksheets(0).Cells(fila, columna).Value = _Valor_ 'FormatNumber(_Valor_, 2) 'Gl_Fx_De_Num_a_Tx_01(Contenido, 3)
                    ElseIf TipoDeDato = "DateTime" Then
                        Dim _Fecha As Date = NuloPorNro(dr(dc.ColumnName), "01/01/1900")
                        Wbook.Worksheets(0).Cells(fila, columna).Value = FormatDateTime(_Fecha, DateFormat.ShortDate) 'dr(dc.ColumnName)
                    ElseIf TipoDeDato = "Boolean" Then
                        _Valor = CInt(dr(dc.ColumnName)) * -1
                        Wbook.Worksheets(0).Rows(fila).Cells(columna).Value = _Valor
                    Else

                        _Valor = CStr(dr(dc.ColumnName).ToString)

                        ' Limpieza de valores ASCII
                        For _i = 0 To 31
                            _Valor = Replace(_Valor, Chr(_i), " ")
                        Next
                        _Valor = Replace(_Valor, Chr(127), " ")

                        Wbook.Worksheets(0).Rows(fila).Cells(columna).Value = _Valor
                    End If

                    If _Cancelar = True Then
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
                If _Cancelar = True Then
                    Bar.Value = 0 : Bar2.Value = 0
                    Procesando(True, False)
                    Exit Sub
                End If
            Next

            'AddHandler Wbook.Progress, Nothing
            If _Cancelar = True Then
                Bar.Value = 0 : Bar2.Value = 0
                Procesando(True, False)
                Exit Sub
            End If
            Procesando(False, False)
            'Write .xlsx file.

            Dim ArchivoGuardado As String = _Directorio & NombreArchivo & "." & Extencion

            ' ArchivoGuardado = "..\..\..\DataTableImport.xlsx"


            Wbook.WriteXLSX(ArchivoGuardado)
            'Wbook.WriteXLS(ArchivoGuardado)

            'Wbook.WriteXLS("..\..\..\" & NombreArchivo & ".xls")
            'Open specified file in MS Excel.
            MsgBox("El documento fue guardado con exito en la carpeta:" & vbCrLf &
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

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Procesando(False, True)
        'CircularProgress2.IsRunning = True
        'tb = _SQL.Fx_Get_Tablas(Consulta_sql)

        ExpExcelJet(_TablaExcel, CircularProgress1, CircularProgress2, TxtNombreArchivo.Text, "", _Direc)
        'CircularProgress2.IsRunning = False
        _Cancelar = False
        Procesando(True, _Cancelar)
    End Sub

    Private Sub Frm_ExportarJetExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = TxtNombreArchivo
        TxtNombreArchivo.SelectAll()
        BtnCancelar.Enabled = False
    End Sub

    Private Sub Btn_DireccionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDireccionFile.Click
        SvfDirectorio.FileName = TxtNombreArchivo.Text & ".xlsx"
        If SvfDirectorio.ShowDialog = DialogResult.OK Then
            TxtNombreArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(SvfDirectorio.FileName)
            _Direc = Replace(SvfDirectorio.FileName, TxtNombreArchivo.Text & ".xlsx", "")
        End If
        'If Svf_Directorio.S
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Procesando(False, True)
        Consulta_sql = "SELECT * FROM MAEPR"
        CircularProgress2.IsRunning = True
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        ExpExcelJet(_Tbl, CircularProgress1, CircularProgress2, "", TxtNombreArchivo.Text)
        CircularProgress2.IsRunning = False
        _Cancelar = False
        Procesando(True, _Cancelar)
    End Sub

    Sub Procesando(ByVal OP As Boolean, ByVal Tk As Boolean)
        TxtNombreArchivo.Enabled = OP
        BtnDireccionFile.Enabled = OP
        ToolStripButton1.Enabled = OP
        ToolStripButton2.Enabled = OP
        BtnCancelar.Enabled = Tk
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        _Cancelar = True
        Procesando(True, False)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub Frm_ExportarJetExcel_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        _Cancelar = True
    End Sub

    Private Sub BtnVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerDetalle.Click
        If _TablaExcel.Rows.Count > 0 Then
            Dim Fm As New Frm_CargarTablasDePaso
            Fm._Tabla_de_Paso = _TablaExcel
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Ver detalle", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        End If
    End Sub
End Class