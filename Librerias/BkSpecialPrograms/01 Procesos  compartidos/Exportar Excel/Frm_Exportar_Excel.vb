Imports DevComponents.DotNetBar
Imports System.IO
Imports Docs.Excel

Public Class Frm_Exportar_Excel

    Dim _Tbl_Excel As DataTable
    Dim _Cancelar As Boolean
    Dim _Directorio_Destino As String
    Dim _Archivo As String
    Dim _Error As String

    Dim _Necesita_Permiso As Boolean
    Dim _CodPermiso As String

    Dim _No_Abrir_Archivo As Boolean
    Dim _HojaRevisada As Integer = 1

    Public Property Ds_Excel As DataSet
    Public Property CodPermiso As String
        Get
            Return _CodPermiso
        End Get
        Set(value As String)
            _CodPermiso = value
        End Set
    End Property
    Public Property Pro_Directorio_Destino() As String
        Get
            Return _Directorio_Destino
        End Get
        Set(value As String)
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
        Set(value As String)
            Txt_Nombre_Archivo.Text = value
        End Set
    End Property
    Public ReadOnly Property Pro_Archivo() As String
        Get
            Return _Archivo
        End Get
    End Property

    Dim _Extension As Enum_Extension

    Enum Enum_Extension
        xlsx
        xls
    End Enum

    Public Sub New(Tbl_Excel As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tbl_Excel = Tbl_Excel

        _Directorio_Destino = Application.StartupPath & "\Data\" & RutEmpresa & "\Tmp\Excel"

        If Not Directory.Exists(_Directorio_Destino) Then
            System.IO.Directory.CreateDirectory(_Directorio_Destino)
        End If

        Sb_Color_Botones_Barra(Bar1)

        _CodPermiso = String.Empty

    End Sub

    Private Sub Frm_Exportar_Excel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.ActiveControl = Txt_Nombre_Archivo
        Txt_Nombre_Archivo.SelectAll()

        Dim _Arr_Seperador(,) As String = {{",", "Coma (,)"},
                                    {";", "Punto y coma (;)"},
                                    {"  ", "Tabulación (Tab)"},
                                    {" ", "Espacio"},
                                    {"", "Sin separación"},
                                    {"Otro", "Otro ->"}
                                    }
        Sb_Llenar_Combos(_Arr_Seperador, Cmb_Separador)
        Cmb_Separador.SelectedValue = ","

        _Necesita_Permiso = Not String.IsNullOrEmpty(_CodPermiso)

        If _Necesita_Permiso Then
            If Not Fx_Tiene_Permiso(_CodPermiso, FUNCIONARIO) Then
                GroupPanel1.Text = "(Para poder exportar el informe necesitara del permiso " & _CodPermiso & ", solo puede ver el detalle)"
            End If
        End If

    End Sub

    Function Fx_Exportar_ExcelJet(NombreArchivo As String,
                                  Directorio As String,
                                  Optional Extencion As Enum_Extension = Enum_Extension.xlsx,
                                  Optional ByRef _Error As String = "") As String

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Try

            If String.IsNullOrEmpty(Directorio) Then
                Directorio = _Directorio_Destino
            End If

            _Extension = Extencion

            Sb_Procesando(True)

            _Configuracion_Regional_()

            _Cancelar = False

            'Create a new workbook.
            ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
            Dim Wbook = New ExcelWorkbook()

            'Add new worksheet to workbook.
            Wbook.Worksheets.Add("Hoja1")


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

                'If fila = 70165 Then
                '    Dim _Stop = True
                'End If
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
                        Dim _Valor_ As Double = De_Txt_a_Num_01(Contenido, 3) 'Gl_Fx_De_Num_a_Tx_01(Contenido, False, 2)
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

                        If IsNothing(_Valor) Then _Valor = String.Empty

                        Wbook.Worksheets(0).Rows(fila).Cells(columna).Value = _Valor.ToString.Trim
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

            For i = 0 To columna - 1
                Wbook.Worksheets(0).Columns(i).Autofit()
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


            If _Extension = Enum_Extension.xlsx Then
                Wbook.WriteXLSX(_Archivo)
            ElseIf _Extension = Enum_Extension.xls Then
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
            _Error = "Fila: " & fila & ", Columna: " & columna & vbCrLf & ex.Message
            Return ""
            'MsgBox(ex.Message)
        Finally
            Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            Sb_Procesando(False)
        End Try
    End Function

    Function Fx_Exportar_ExcelJetXHoja(NombreArchivo As String,
                                       Directorio As String,
                                       Ds_Hojas As DataSet,
                                       Extencion As Enum_Extension) As LsValiciones.Mensajes

        Dim _fila As Integer = 0
        Dim _columna As Integer = 0
        Dim _Nro_Hoja = 0

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If String.IsNullOrEmpty(Directorio) Then
                Directorio = _Directorio_Destino
            End If

            _Extension = Extencion

            Sb_Procesando(True)

            _Configuracion_Regional_()

            _Cancelar = False

            'Create a new workbook.
            ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
            Dim Wbook = New ExcelWorkbook()


            For Each _Hojas As DataTable In Ds_Hojas.Tables

                _fila = 0
                _columna = 0

                _Tbl_Excel = _Hojas

                'Add new worksheet to workbook.
                Wbook.Worksheets.Add("Hoja" & _Nro_Hoja + 1)


                ' xls, xlsx
                '/////////////////////////////////////////////////
                '// Armamos la linea con los títulos de columnas
                '/////////////////////////////////////////////////

                For Each dc In _Tbl_Excel.Columns
                    With Wbook.Worksheets(_Nro_Hoja).Rows(0).Cells(_columna)
                        .Style.Font.Bold = True
                        .Style.Font.Color = ColorPalette.Blue
                        .Value = dc.ColumnName
                        _columna += 1
                    End With

                    If _Cancelar = True Then
                        Circular_Progres_Porcentaje.Value = 0
                        Sb_Procesando(False)
                        Exit Function
                    End If
                Next
                _fila += 1

                'Bar = BarraProgreso

                Circular_Progres_Porcentaje.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
                Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count

                _columna = 1
                Circular_Progres_Porcentaje.Value = 0
                Circular_Progres_Contador.Value = 0

                Dim Contador = 0

                For Each dr In _Tbl_Excel.Rows

                    System.Windows.Forms.Application.DoEvents()
                    _columna = 0
                    For Each dc In _Tbl_Excel.Columns

                        Dim Contenido = dr(dc.ColumnName).ToString

                        Dim ty As Type = dc.DataType
                        Dim TipoDeDato As String = ty.Name.ToString

                        Dim _Valor

                        If dc.ColumnName = "Consolidado" Then
                            Dim _ssa = 0
                        End If

                        If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                            Dim _Valor_ As Double = De_Txt_a_Num_01(Contenido, 3) 'Gl_Fx_De_Num_a_Tx_01(Contenido, False, 2)
                            Wbook.Worksheets(_Nro_Hoja).Cells(_fila, _columna).Value = _Valor_ ' FormatNumber(_Valor_, 2) 'Gl_Fx_De_Num_a_Tx_01(Contenido, 3)
                        ElseIf TipoDeDato = "DateTime" Then
                            Dim _Fecha As Date = NuloPorNro(dr(dc.ColumnName), "01/01/1900")
                            Wbook.Worksheets(_Nro_Hoja).Cells(_fila, _columna).Value = FormatDateTime(_Fecha, DateFormat.ShortDate) 'dr(dc.ColumnName)
                        ElseIf TipoDeDato = "Boolean" Then
                            _Valor = CInt(NuloPorNro(dr(dc.ColumnName), False)) * -1
                            Wbook.Worksheets(_Nro_Hoja).Rows(_fila).Cells(_columna).Value = _Valor
                        Else

                            _Valor = CStr(dr(dc.ColumnName).ToString)

                            ' Limpieza de valores ASCII
                            For _i = 0 To 31
                                _Valor = Replace(_Valor, Chr(_i), " ")
                            Next
                            _Valor = Replace(_Valor, Chr(127), " ")

                            If IsNothing(_Valor) Then _Valor = String.Empty

                            Wbook.Worksheets(_Nro_Hoja).Rows(_fila).Cells(_columna).Value = _Valor.ToString.Trim
                        End If

                        If _Cancelar = True Then
                            Exit For
                        End If

                        _columna += 1

                    Next

                    _fila += 1

                    Contador += 1
                    Circular_Progres_Porcentaje.Value = ((Contador * 100) / _Tbl_Excel.Rows.Count)
                    Circular_Progres_Contador.Value += 1

                    If _Cancelar = True Then
                        Exit For
                    End If

                Next

                'Merged range.

                If _fila < 20000 Then

                    For i = 0 To _columna - 1
                        Try
                            Wbook.Worksheets(_Nro_Hoja).Columns(i).Autofit()
                        Catch ex As Exception

                        End Try
                    Next

                End If

                _Nro_Hoja += 1

            Next

            If _Cancelar Then
                _Mensaje.Cancelado = True
                Throw New Exception("Proceso cancelado por el usuario")
            End If

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

            If _Extension = Enum_Extension.xlsx Then
                Wbook.WriteXLSX(_Archivo)
            ElseIf _Extension = Enum_Extension.xls Then
                Wbook.WriteXLS(_Archivo)
            End If

            Txt_Nombre_Archivo.Text = NombreArchivo & "." & Extencion.ToString

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "El archivo fue guardado con exito en la carpeta:" & vbCrLf & _Archivo
            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Tag = _Archivo

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Hoja: Hoja" & _Nro_Hoja + 1 & ", Fila: " & _fila & ", Columna: " & _columna & vbCrLf & ex.Message
            _Mensaje.Detalle = "Exportar a Excel"
            _Mensaje.Tag = ""
            _Mensaje.Icono = MessageBoxIcon.Error
        Finally
            Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            Sb_Procesando(False)
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_CSV(_Nombre_Archivo As String,
                          _Directorio_Destino As String,
                          Optional ByRef _Error As String = "") As String

        Const DELIMITADOR As String = ";"

        _Cancelar = False

        Circular_Progres_Porcentaje.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count

        Dim _Fila = 0
        Dim _Columna = 1
        Dim Contador = 0

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

                    If _Fila = 21700 Then
                        Dim Aca = True
                    End If

                    _Columna = 0

                    For Each dc In _Tbl_Excel.Columns

                        Dim _Valor = _Row(dc.ColumnName).ToString

                        Dim ty As Type = dc.DataType
                        Dim TipoDeDato As String = ty.Name.ToString

                        If _Valor = "5547211" Or _Columna = 111 Then
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
                            ' Limpieza de valores ASCII
                            For _i = 0 To 31
                                _Valor = Replace(_Valor, Chr(_i), " ")
                            Next
                            _Valor = Replace(_Valor, Chr(127), " ")

                            If IsNothing(_Valor) Then
                                _Valor = String.Empty
                            End If

                            Try
                                _Valor = _Valor.ToString.Trim
                            Catch ex As Exception

                            End Try

                        ElseIf TipoDeDato = "DateTime" Then
                            Dim _Fecha As Date = NuloPorNro(_Row(dc.ColumnName), "01-01-1900")
                            _Valor = _Fecha 'dr(dc.ColumnName)
                            _Valor = Replace(_Valor, "/", "-")
                        End If


                        ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
                        _Linea = _Linea & _Valor & DELIMITADOR
                        _Columna += 1
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
            _Error = ex.Message & vbCrLf & "Fila: " & _Fila & ", Columna: " & _Columna
            Return ""
        Finally
            Circular_Progres_Contador.Value = 0 : Circular_Progres_Porcentaje.Value = 0
            Sb_Procesando(False)
        End Try

    End Function

    Function Fx_Crear_TXT(_Nombre_Archivo As String,
                          _Directorio_Destino As String,
                          _Separador As String,
                          Optional ByRef _Error As String = "") As String

        'Const DELIMITADOR As String = ";"

        _Cancelar = False

        Circular_Progres_Porcentaje.Maximum = 100 ' Bar.Value = ((Contador * 100) / Tabla.Rows.Count)
        Circular_Progres_Contador.Maximum = _Tbl_Excel.Rows.Count

        Dim columna = 1
        Dim Contador = 0
        Dim _Fila = 0

        Circular_Progres_Porcentaje.Value = 0
        Circular_Progres_Contador.Value = 0

        ' ruta del fichero de texto  
        Dim _Archivo_TXT As String = Path.GetTempFileName()

        Try

            Sb_Procesando(True)

            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas  
            Using _Archivo As StreamWriter = New StreamWriter(_Archivo_TXT)

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

                        If TipoDeDato = "Double" Or TipoDeDato = "Decimal" Or TipoDeDato = "Int32" Then
                            Dim _Valor_

                            Try
                                _Valor_ = De_Num_a_Tx_01(_Valor, False, 2)
                                _Valor = _Valor_
                            Catch ex As Exception
                                _Valor = 0
                            End Try

                        ElseIf TipoDeDato = "String" Then

                            _Valor = _Valor ' Replace(_Valor, ",", ".")

                            ' Limpieza de valores ASCII
                            For _i = 0 To 31
                                _Valor = Replace(_Valor, Chr(_i), " ")
                            Next
                            _Valor = Replace(_Valor, Chr(127), " ")

                            If IsNothing(_Valor) Then
                                _Valor = String.Empty
                            End If

                            Try
                                _Valor = _Valor.ToString.Trim
                            Catch ex As Exception

                            End Try

                        ElseIf TipoDeDato = "DateTime" Then

                            Dim _Fecha As Date = NuloPorNro(_Row(dc.ColumnName), "01-01-1900")

                            _Valor = _Fecha
                            _Valor = Replace(_Valor, "/", "-")

                        End If

                        ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
                        _Linea = _Linea & _Valor & _Separador
                        columna += 1

                    Next


                    'For col As Integer = 0 To .Columns.Count - 1
                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador  
                    '_Linea = _Linea & .Item(col, _Fila).Value.ToString & DELIMITADOR
                    'Next

                    ' Escribir una línea con el método WriteLine  
                    _Archivo.WriteLine(_Linea.ToString)

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

            _Nombre_Archivo += ".txt"

            Dim _pFileName = _Directorio_Destino & "\" & _Nombre_Archivo
            System.IO.File.Copy(_Archivo_TXT, _pFileName, True)
            File.Delete(_Archivo_TXT)

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

    Sub Sb_Procesando(_Procesando As Boolean)

        If _Procesando Then
            Btn_Exportar_a_Excel.Enabled = False
            Btn_Exportar_Csv.Enabled = False
            Btn_Exportar_Txt.Enabled = False
            Btn_Ver_Detalle.Enabled = False
            Me.ControlBox = Not _Procesando
            Btn_Carpeta_Informes.Enabled = False
            Btn_Cancelar.Visible = True
            Txt_Nombre_Archivo.Enabled = True
        Else
            Btn_Exportar_a_Excel.Enabled = True
            Btn_Exportar_Csv.Enabled = True
            Btn_Exportar_Txt.Enabled = True
            Btn_Ver_Detalle.Enabled = True
            Me.ControlBox = Not _Procesando
            Btn_Carpeta_Informes.Enabled = True
            Btn_Cancelar.Visible = False
            Txt_Nombre_Archivo.Enabled = False
        End If

        Me.Refresh()

    End Sub

    Private Sub Btn_Exportar_a_Excel_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_a_Excel.Click

        If _Necesita_Permiso Then
            If Not Fx_Tiene_Permiso(Me, _CodPermiso) Then
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Archivo.Text)) Then
            MessageBoxEx.Show(Me, "Debe ponerle un nombre al archivo Excel",
                              "Validación",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        If Rdb_xls.Checked Then
            _Extension = Enum_Extension.xls
        ElseIf Rdb_Xlsx.Checked Then
            _Extension = Enum_Extension.xlsx
        End If

        _Archivo = String.Empty

        If Not IsNothing(Ds_Excel) Then

            Dim _Mensaje As LsValiciones.Mensajes = Fx_Exportar_ExcelJetXHoja(Txt_Nombre_Archivo.Text, _Directorio_Destino, Ds_Excel, _Extension)

            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, Windows.Forms.MessageBoxButtons.OK, _Mensaje.Icono)

            If _Mensaje.EsCorrecto Then
                _Archivo = _Mensaje.Tag
            End If

        Else

            _Archivo = Fx_Exportar_ExcelJet(Txt_Nombre_Archivo.Text, _Directorio_Destino, _Extension)

        End If

        If Not String.IsNullOrEmpty(_Archivo) Then

            If MessageBoxEx.Show(Me, "¿Desea Abrir el archivo " & Txt_Nombre_Archivo.Text & "?", "Abrir documento Excel",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
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

    Private Sub Btn_Exportar_Csv_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Exportar_Csv.Click

        If Not IsNothing(Ds_Excel) Then

            _Tbl_Excel = Nothing

            If Ds_Excel.Tables.Count > 1 Then
                MessageBoxEx.Show(Me, "No se puede exportar a CSV, ya que se han generado " & Ds_Excel.Tables.Count & " hojas como resultado." & vbCrLf &
                                  "Solo se puede exportar cuando el resultado es 1 hoja" & vbCrLf & vbCrLf &
                                  "Solo podrá exportar a Excel",
                                  "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _Tbl_Excel = Ds_Excel.Tables(0)

        End If

        If _Necesita_Permiso Then
            If Not Fx_Tiene_Permiso(Me, _CodPermiso) Then
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Archivo.Text)) Then
            MessageBoxEx.Show(Me, "Debe ponerle un nombre al archivo CSV",
                              "Validación",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        _Archivo = Fx_Crear_CSV(Txt_Nombre_Archivo.Text, _Directorio_Destino)

        If Not String.IsNullOrEmpty(_Archivo) Then

            If MsgBox("¿Desea Abrir el archivo " & Txt_Nombre_Archivo.Text & "?",
                     MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Abrir docuemto CSV") = MsgBoxResult.Yes Then
                Try
                    System.Diagnostics.Process.Start(_Archivo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Me.Close()

        End If

    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub

    Private Sub Frm_Exportar_Excel_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Direccion_File_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Direccion_File.Click

        If _Necesita_Permiso Then
            If Not Fx_Tiene_Permiso(Me, _CodPermiso) Then
                Return
            End If
        End If

        Dim _Extencion As String

        If Rdb_xls.Checked Then
            _Extencion = "xls"
        ElseIf Rdb_Xlsx.Checked Then
            _Extencion = "xlsx"
        End If

        SvfDirectorio.FileName = Txt_Nombre_Archivo.Text & "." & _Extencion
        If SvfDirectorio.ShowDialog = DialogResult.OK Then
            Txt_Nombre_Archivo.Text = System.IO.Path.GetFileNameWithoutExtension(SvfDirectorio.FileName)
            _Directorio_Destino = Replace(SvfDirectorio.FileName, Txt_Nombre_Archivo.Text & "." & _Extencion, "")
        End If

    End Sub

    Private Sub Btn_Ver_Detalle_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Ver_Detalle.Click

        If Not IsNothing(Ds_Excel) Then
            _Tbl_Excel = Nothing
        End If

        If IsNothing(_Tbl_Excel) Then

            If IsNothing(Ds_Excel) Then
                MessageBoxEx.Show(Me, "No existen datos que mostrar", "Ver detalle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            If Ds_Excel.Tables.Count > 1 Then

                Dim _Msg As String = "Se han generado " & Ds_Excel.Tables.Count & " hojas como resultado. " & vbCrLf &
                       "Por favor, indícame el número de la hoja que deseas revisar (del 1 al " & Ds_Excel.Tables.Count & ")."
                Dim _Aceptar As Boolean = InputBox_Bk(Me, _Msg, "Ver detalle",
                                                      _HojaRevisada, False, _Tipo_Mayus_Minus.Normal, 2, True, _Tipo_Imagen.Texto,,
                                                      _Tipo_Caracter.Solo_Numeros_Enteros, False)

                If Not _Aceptar Then
                    Return
                End If

                If _HojaRevisada > Ds_Excel.Tables.Count Then
                    MessageBoxEx.Show(Me, "El número de hoja no es valido, debe ser del 1 al " & Ds_Excel.Tables.Count, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _HojaRevisada = 1
                    Call Btn_Ver_Detalle_Click(Nothing, Nothing)
                    Return
                End If

                _Tbl_Excel = Ds_Excel.Tables(_HojaRevisada - 1)

                If _Tbl_Excel.Rows.Count = 0 Then
                    MessageBoxEx.Show(Me, "No existen datos que mostrar en la hoja " & _HojaRevisada, "Ver detalle", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Call Btn_Ver_Detalle_Click(Nothing, Nothing)
                    Return
                End If

            Else
                _Tbl_Excel = Ds_Excel.Tables(0)
            End If

        End If

        If _Tbl_Excel.Rows.Count > 0 Then

            Me.Cursor = Cursors.WaitCursor

            Dim Fm As New Frm_CargarTablasDePaso
            Fm._Tabla_de_Paso = _Tbl_Excel
            Fm.ShowDialog(Me)

            Me.Cursor = Cursors.Default

            If Not IsNothing(Ds_Excel) Then

                If Ds_Excel.Tables.Count > 1 Then
                    If MessageBoxEx.Show(Me, "¿Desea ver otras hojas?", "Ver detalle",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Call Btn_Ver_Detalle_Click(Nothing, Nothing)
                    End If
                End If

            End If

        Else
            MessageBoxEx.Show("No existen datos que mostrar", "Ver detalle", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Btn_Carpeta_Informes_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Carpeta_Informes.Click
        Dim _Temporales = Application.StartupPath & "\Data\" & RutEmpresa & "\Tmp\Excel"
        Shell("explorer.exe " & _Temporales, AppWinStyle.NormalFocus)
    End Sub

    Private Sub Btn_Exportar_Txt_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Txt.Click

        If Not IsNothing(Ds_Excel) Then

            _Tbl_Excel = Nothing

            If Ds_Excel.Tables.Count > 1 Then
                MessageBoxEx.Show(Me, "No se puede exportar a TXT, ya que se han generado " & Ds_Excel.Tables.Count & " hojas como resultado." & vbCrLf &
                                  "Solo se puede exportar cuando el resultado es 1 hoja" & vbCrLf & vbCrLf &
                                  "Solo podrá exportar a Excel",
                                  "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            _Tbl_Excel = Ds_Excel.Tables(0)

        End If

        If _Necesita_Permiso Then
            If Not Fx_Tiene_Permiso(Me, _CodPermiso) Then
                Return
            End If
        End If

        If String.IsNullOrEmpty(Trim(Txt_Nombre_Archivo.Text)) Then
            MessageBoxEx.Show(Me, "Debe ponerle un nombre al archivo TXT",
                              "Validación",
                              Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            Return
        End If

        Dim _Separador As String = Cmb_Separador.SelectedValue

        If _Separador = "Otro" Then _Separador = Txt_Separador.Text.Trim

        _Archivo = Fx_Crear_TXT(Txt_Nombre_Archivo.Text, _Directorio_Destino, _Separador)

        If Not String.IsNullOrEmpty(_Archivo) Then

            If MsgBox("¿Desea Abrir el archivo " & Txt_Nombre_Archivo.Text & "?",
                     MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Abrir docuemto") = MsgBoxResult.Yes Then
                Try
                    System.Diagnostics.Process.Start(_Archivo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Me.Close()

        End If

    End Sub

    Private Sub Cmb_Separador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Separador.SelectedIndexChanged

        Txt_Separador.Visible = (Cmb_Separador.SelectedValue = "Otro")

    End Sub

End Class
