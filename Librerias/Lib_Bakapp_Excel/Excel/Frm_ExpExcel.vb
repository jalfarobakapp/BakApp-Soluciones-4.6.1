Imports DevComponents.DotNetBar
Imports System.IO
Imports Docs.Excel
Imports Funciones_BakApp
Imports System.Windows.Forms

Public Class Frm_Exportar_Excel

    Dim _Tbl_Excel As DataTable
    Dim _Cancelar As Boolean
    Dim _Directorio_Destino As String
    Dim _Archivo As String
    Dim _Error As String

    Dim _No_Abrir_Archivo As Boolean

    Public Property Pro_Directorio_Destino() As String
        Get
            Return _Directorio_Destino
        End Get
        Set(ByVal value As String)
            _Directorio_Destino = value
        End Set
    End Property
    Public ReadOnly Property Pro_Error()
        Get
            Return _Error
        End Get
    End Property
    Public Property Pro_Nombre_Archivo() As String
        Get
            If String.IsNullOrEmpty(_Archivo) Then
                Txt_Nombre_Archivo.Text = String.Empty
            End If
            Return Txt_Nombre_Archivo.Text
        End Get
        Set(ByVal value As String)
            Txt_Nombre_Archivo.Text = value
        End Set
    End Property
    Public ReadOnly Property Pro_Archivo() As String
        Get
            Return _Archivo
        End Get
    End Property

    Dim _Extencion As Enum_Extencion

    Enum Enum_Extencion
        xlsx
        xls
    End Enum

    Public Sub New(ByVal Tbl_Excel As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tbl_Excel = Tbl_Excel

        _Directorio_Destino = Application.StartupPath & "\Data\" & RutEmpresa & "\Tmp\Excel"

        If Not Directory.Exists(_Directorio_Destino) Then
            System.IO.Directory.CreateDirectory(_Directorio_Destino)
        End If

    End Sub

    Private Sub Frm_Exportar_Excel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = Txt_Nombre_Archivo
        Txt_Nombre_Archivo.SelectAll()
    End Sub

    Function Fx_Exportar_ExcelJet(ByVal NombreArchivo As String, _
                                  ByVal Directorio As String, _
                                  Optional ByVal Extencion As Enum_Extencion = Enum_Extencion.xlsx, _
                                  Optional ByRef _Error As String = "") As String

        Try

            If String.IsNullOrEmpty(Directorio) Then
                Directorio = _Directorio_Destino
            End If

            _Extencion = Extencion

            Sb_Procesando(True)

            _Configuracion_Regional_()

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



            For Each dc In _Tbl_Excel.Columns
                With Wbook.Worksheets(0).Rows(0).Cells(columna)
                    .Style.Font.Bold = True
                    .Style.Font.Color = ColorPalette.Blue
                    .Value = dc.ColumnName
                    columna += 1
                End With

                If _Cancelar = True Then
                    Circular_Progres_Porcentaje.Value = 0
                    Sb_Procesando(False)
                    Exit Function
                End If
            Next
            fila += 1

            'Bar = BarraProgreso

            Circular_Progres_Porcentaje.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
            Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count

            columna = 1
            Circular_Progres_Porcentaje.Value = 0
            Circular_Progres_Contador.Value = 0

            Dim Contador = 0
            'AddHandler Wbook.Progress, AddressOf workbook_SavingProgress

            For Each dr In _Tbl_Excel.Rows
                System.Windows.Forms.Application.DoEvents()
                columna = 0
                For Each dc In _Tbl_Excel.Columns

                    Dim Contenido = dr(dc.ColumnName).ToString

                    'Dim dtp As DataColumn = dc
                    Dim ty As Type = dc.DataType
                    Dim TipoDeDato As String = ty.Name.ToString

                    Dim _Valor

                    If dc.ColumnName = "Consolidado" Then
                        Dim _ssa = 0
                    End If

                    If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                        Dim _Valor_ As Double = De_Txt_a_Num_01(Val(Contenido), 2) 'Gl_Fx_De_Num_a_Tx_01(Contenido, False, 2)
                        Wbook.Worksheets(0).Cells(fila, columna).Value = _Valor_ ' FormatNumber(_Valor_, 2) 'Gl_Fx_De_Num_a_Tx_01(Contenido, 3)
                    ElseIf TipoDeDato = "DateTime" Then
                        Dim _Fecha As Date = NuloPorNro(dr(dc.ColumnName), "01/01/1900")
                        Wbook.Worksheets(0).Cells(fila, columna).Value = FormatDateTime(_Fecha, DateFormat.ShortDate) 'dr(dc.ColumnName)
                    ElseIf TipoDeDato = "Boolean" Then
                        _Valor = CInt(NuloPorNro(dr(dc.ColumnName), False)) * -1
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
                        'Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
                        'Sb_Procesando(False)
                        Exit Function
                    End If

                    'objHojaExcel.Range(nombreColumna(columna) & fila).Value = "'" & dr(dc.ColumnName).ToString
                    columna += 1
                Next
                fila += 1

                '3000 = 100
                '23 = x
                Contador += 1
                Circular_Progres_Porcentaje.Value = ((Contador * 100) / _Tbl_Excel.Rows.Count) 'Mas
                Circular_Progres_Contador.Value += 1 ' Contador

                If _Cancelar = True Then
                    'Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
                    'Sb_Procesando(False)
                    Exit Function
                End If

            Next

            'If _Cancelar = True Then
            'Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            'Sb_Procesando(False)
            'Exit Function
            'End If

            ' ArchivoGuardado = "..\..\..\DataTableImport.xlsx"


            Dim _Contador = 1
            Dim _Archivo As String
            _Archivo = Directorio & "\" & NombreArchivo & "." & Extencion.ToString

            Do While File.Exists(_Archivo)

                If Fx_IsFileOpen(_Archivo) Then
                    _Archivo = Directorio & "\" & NombreArchivo & "_(" & _Contador & ")" & "." & Extencion.ToString
                    _Contador += 1
                Else
                    Exit Do
                End If

            Loop


            If _Extencion = Enum_Extencion.xlsx Then
                Wbook.WriteXLSX(_Archivo)
            ElseIf _Extencion = Enum_Extencion.xls Then
                Wbook.WriteXLS(_Archivo)
            End If


            'Wbook.WriteXLS(ArchivoGuardado)

            'Wbook.WriteXLS("..\..\..\" & NombreArchivo & ".xls")
            'Open specified file in MS Excel.
            'MsgBox("El documento fue guardado con exito en la carpeta:" & vbCrLf & _
            '       ArchivoGuardado, MsgBoxStyle.Information, "Exportar a Excel")
            _Error = ""
            Txt_Nombre_Archivo.Text = NombreArchivo & "." & Extencion.ToString
            Return _Archivo


        Catch ex As Exception
            _Error = ex.Message
            Return ""
            'MsgBox(ex.Message)
        Finally
            Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            Sb_Procesando(False)
        End Try
    End Function

    Function Fx_Crear_CSV(ByVal _Nombre_Archivo As String, _
                          ByVal _Directorio_Destino As String, _
                          Optional ByRef _Error As String = "") As String

        Const DELIMITADOR As String = ";"

        _Cancelar = False

        Circular_Progres_Porcentaje.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count

        Dim columna = 1
        Dim Contador = 0
        Dim _Fila = 0

        Circular_Progres_Porcentaje.Value = 0
        Circular_Progres_Contador.Value = 0

        ' ruta del fichero de texto  
        Dim _Archivo_CSV As String = Path.GetTempFileName() '_Directorio_Destino & "\" & _Nombre_Archivo & ".csv"

        Try

            Sb_Procesando(True)

            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas  
            Using _Archivo As StreamWriter = New StreamWriter(_Archivo_CSV)

                ' variable para almacenar la línea actual del dataview  
                Dim _Linea As String = String.Empty

                ' Recorrer las filas del dataGridView  
                For Each _Row As DataRow In _Tbl_Excel.Rows
                    ' vaciar la línea  
                    _Linea = String.Empty
                    System.Windows.Forms.Application.DoEvents()
                    ' Recorrer la cantidad de columnas que contiene el dataGridView  

                    For Each dc In _Tbl_Excel.Columns

                        Dim _Valor = _Row(dc.ColumnName).ToString

                        Dim ty As Type = dc.DataType
                        Dim TipoDeDato As String = ty.Name.ToString

                        If _Valor = "5547211" Or columna = 111 Then
                            Dim alto = 0
                        End If

                        If dc.ColumnName = "Cantidad" Then
                            Dim _ssa = 0
                        End If

                        If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                            Dim _Valor_
                            Try
                                _Valor_ = De_Num_a_Tx_01(_Valor, False, 2)
                                _Valor = _Valor_
                            Catch ex As Exception
                                _Valor = 0
                            End Try
                        ElseIf TipoDeDato = "String" Then
                            'Dim _Coma As String = Chr(34) & "," & Chr(34)
                            _Valor = Replace(_Valor, ",", ".")
                        ElseIf TipoDeDato = "DateTime" Then
                            Dim _Fecha As Date = NuloPorNro(_Row(dc.ColumnName), "01-01-1900")
                            _Valor = _Fecha 'dr(dc.ColumnName)
                            _Valor = Replace(_Valor, "/", "-")
                        End If


                        ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
                        _Linea = _Linea & _Valor & DELIMITADOR
                        columna += 1
                    Next


                    'For col As Integer = 0 To .Columns.Count - 1
                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
                    '_Linea = _Linea & .Item(col, _Fila).Value.ToString & DELIMITADOR
                    'Next

                    ' Escribir una línea con el método WriteLine  
                    With _Archivo
                        ' eliminar el último caracter ";" de la cadena  
                        _Linea = _Linea.Remove(_Linea.Length - 1).ToString
                        ' escribir la fila  
                        .WriteLine(_Linea.ToString)
                    End With

                    Contador += 1
                    Circular_Progres_Porcentaje.Value = ((Contador * 100) / _Tbl_Excel.Rows.Count) 'Mas
                    Circular_Progres_Contador.Value += 1 ' Contador

                    If _Cancelar = True Then
                        'Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
                        'Sb_Procesando(False)
                        Return ""
                    End If
                    _Fila += 1
                Next

            End Using

            ' Abrir con Process.Start el archivo de texto  
            'Process.Start(_Archivo_CSV)

            _Nombre_Archivo += ".csv"

            Dim _pFileName = _Directorio_Destino & "\" & _Nombre_Archivo  'Replace(_Archivo_CSV, "tmp", "csv") 'Path.GetTempFileName.Replace("tmp", "xls")
            System.IO.File.Copy(_Archivo_CSV, _pFileName, True)
            File.Delete(_Archivo_CSV)

            Txt_Nombre_Archivo.Text = _Nombre_Archivo

            Return _pFileName
            'error  
        Catch ex As Exception
            _Error = ex.Message & vbCrLf & "Fila: " & _Fila
            Return ""
        Finally
            Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            Sb_Procesando(False)
        End Try

    End Function


    Sub Sb_Procesando(ByVal _Procesando As Boolean)

        If _Procesando Then
            Btn_Exportar_a_Excel.Enabled = False
            Btn_Exportar_Csv.Enabled = False
            Btn_Ver_Detalle.Enabled = False
            Btn_Salir.Enabled = False
            Btn_Carpeta_Informes.Enabled = False
            Btn_Cancelar.Visible = True
            Txt_Nombre_Archivo.Enabled = True
        Else
            Btn_Exportar_a_Excel.Enabled = True
            Btn_Exportar_Csv.Enabled = True
            Btn_Ver_Detalle.Enabled = True
            Btn_Salir.Enabled = True
            Btn_Carpeta_Informes.Enabled = True
            Btn_Cancelar.Visible = False
            Txt_Nombre_Archivo.Enabled = False
        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Exportar_a_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_a_Excel.Click

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Archivo.Text)) Then
            MessageBoxEx.Show(Me, "Debe ponerle un nombre al archivo Excel", _
                              "Validación", _
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        'Fx_IsFileOpen

        If Rdb_xls.Checked Then
            _Archivo = Fx_Exportar_ExcelJet(Txt_Nombre_Archivo.Text, _Directorio_Destino, Enum_Extencion.xls)
        ElseIf Rdb_Xlsx.Checked Then
            _Archivo = Fx_Exportar_ExcelJet(Txt_Nombre_Archivo.Text, _Directorio_Destino, Enum_Extencion.xlsx)
        End If

        If Not String.IsNullOrEmpty(_Archivo) Then

            'MessageBoxEx.Show(Me, "El documento fue guardado con exito en la carpeta:" & vbCrLf & _
            '       _Archivo, "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If MsgBox("¿Desea Abrir el archivo " & Txt_Nombre_Archivo.Text & "?", _
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Abrir docuemto Excel") = MsgBoxResult.Yes Then
                Try
                    System.Diagnostics.Process.Start(_Archivo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Me.Close()
        Else
            MessageBoxEx.Show(Me, "Error al exportar datos a excel." & vbCrLf & _Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Btn_Exportar_Csv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Csv.Click

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Archivo.Text)) Then
            MessageBoxEx.Show(Me, "Debe ponerle un nombre al archivo Excel", _
                              "Validación", _
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        'If String.IsNullOrEmpty(_Directorio_Destino) Then
        '_Directorio_Destino = Gl_Fx_Seleccionar_Directorio(Global_Directorio_Carpeta_Empresa_Activa_Tmp)
        'End If

        _Archivo = Fx_Crear_CSV(Txt_Nombre_Archivo.Text, _Directorio_Destino)

        If Not String.IsNullOrEmpty(_Archivo) Then

            If MsgBox("¿Desea Abrir el archivo " & Txt_Nombre_Archivo.Text & "?", _
                     MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Abrir docuemto Excel") = MsgBoxResult.Yes Then
                Try
                    System.Diagnostics.Process.Start(_Archivo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Me.Close()

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Frm_Exportar_Excel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub



    Private Sub Btn_Direccion_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Direccion_File.Click
        SvfDirectorio.FileName = Txt_Nombre_Archivo.Text & ".xlsx"
        If SvfDirectorio.ShowDialog = DialogResult.OK Then
            Txt_Nombre_Archivo.Text = System.IO.Path.GetFileNameWithoutExtension(SvfDirectorio.FileName)
            _Directorio_Destino = Replace(SvfDirectorio.FileName, Txt_Nombre_Archivo.Text & ".xlsx", "")
        End If
    End Sub

    Private Sub Btn_Ver_Detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Detalle.Click
        If _Tbl_Excel.Rows.Count > 0 Then
            Dim Fm As New Frm_CargarTablasDePaso
            Fm._Tabla_de_Paso = _Tbl_Excel
            Fm.ShowDialog(Me)
        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Ver detalle", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Btn_Carpeta_Informes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Carpeta_Informes.Click
        Shell("explorer.exe " & _Directorio_Destino, AppWinStyle.NormalFocus)
    End Sub
End Class