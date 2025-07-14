Imports System.IO
Imports DevComponents.DotNetBar
Public Class Frm_Impor_Prod_Masivamente

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Nombre_Tbl_Paso_Precios As String
    Dim _Txt_Log As New TextBox
    Dim _Cancelar As Boolean
    Dim _Limpiar As Boolean

    Dim _Codsucursal As String
    Dim _CodBodega As String
    Dim _CodLista As String

    Dim _Nombre_Archivo_CExtencion As String
    Dim _Nombre_Archivo_SExtencion As String
    Dim _InitialDirectory As String

    Dim _Tbl_Productos_Levantar As DataTable
    Dim _Tipo_Doc As Enum_Tipo_Doc
    Enum Enum_Tipo_Doc
        Excel
        Txt
    End Enum

    Dim _NetoBruto As String

    Public Property Tbl_Productos_Levantar As DataTable
        Get
            Return _Tbl_Productos_Levantar
        End Get
        Set(value As DataTable)
            _Tbl_Productos_Levantar = value
        End Set
    End Property

    Public Property Nombre_Archivo_CExtencion As String
        Get
            Return _Nombre_Archivo_CExtencion
        End Get
        Set(value As String)
            _Nombre_Archivo_CExtencion = value
        End Set
    End Property

    Public Property Nombre_Archivo_SExtencion As String
        Get
            Return _Nombre_Archivo_SExtencion
        End Get
        Set(value As String)
            _Nombre_Archivo_SExtencion = value
        End Set
    End Property

    Public Property InitialDirectory As String
        Get
            Return _InitialDirectory
        End Get
        Set(value As String)
            _InitialDirectory = value
        End Set
    End Property

    Public Property NetoBruto As String
        Get
            Return _NetoBruto
        End Get
        Set(value As String)
            _NetoBruto = value
        End Set
    End Property

    Public Sub New(_Codsucursal As String, _CodBodega As String, _CodLista As String, _Tipo_Doc As Enum_Tipo_Doc)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me._Codsucursal = _Codsucursal
        Me._CodBodega = _CodBodega
        Me._CodLista = _CodLista
        Me._Tipo_Doc = _Tipo_Doc

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Consulta_sql = "Select KOPR As Codigo,NOKOPR As Descripcion,Cast(0 As Float) As Cantidad,Cast(1 As Int) As UdTrans,Cast(0 As Float) As Precio,Cast('' As Varchar(3)) As Bodega From MAEPR Where 1<0"
        _Tbl_Productos_Levantar = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Color_Botones_Barra(Bar1)

        Btn_Archivo_Ayuda_Excel.Visible = (_Tipo_Doc = Enum_Tipo_Doc.Excel)
        Btn_Buscar_Archivo_Excel.Visible = (_Tipo_Doc = Enum_Tipo_Doc.Excel)
        Chk_Primera_Fila_Es_encabezado.Checked = (_Tipo_Doc = Enum_Tipo_Doc.Excel)

        Btn_Buscar_Archivo_Txt.Visible = (_Tipo_Doc = Enum_Tipo_Doc.Txt)

        _NetoBruto = "N"

    End Sub

    Private Sub Frm_Impor_Prod_Masivamente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Rdb_Bodega_Documento.Text = "Incorporar bodega " & _CodBodega
        Rdb_Precio_Lista.Text = "Incorporar precio desde lista " & _CodLista & " (recomendado)"

    End Sub

    Sub Sb_Importar_Productos_Excel()

        'Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        Dim _OpenFileDialog As New OpenFileDialog

        With _OpenFileDialog
            .Filter = "Ficheros (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty
            .CheckPathExists = True

            If Not Directory.Exists(_InitialDirectory) Then
                .InitialDirectory = _InitialDirectory
            End If

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo_SExtencion = System.IO.Path.GetFileNameWithoutExtension(.SafeFileName)
                _Ubic_Archivo = System.IO.Path.GetDirectoryName(.FileName)

                _Nombre_Archivo_CExtencion = .SafeFileName
                _Ubic_Archivo = .FileName
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        _Tbl_Productos_Levantar.Clear()

        Txt_Nombre_Archivo.Text = _Ubic_Archivo

        Dim _ImpEx As New Class_Importar_Excel
        Dim _Extencion As String = Replace(System.IO.Path.GetExtension(_Nombre_Archivo_CExtencion), ".", "")
        Dim _Arreglo = _ImpEx.Importar_Excel_Array(_Ubic_Archivo, _Extencion, 0)
        Dim _Filas = _Arreglo.GetUpperBound(0)

        Dim _Arreglo_Cd(_Filas) As String

        Dim _Desde = 0

        If Chk_Primera_Fila_Es_encabezado.Checked Then
            _Desde = 1
        End If

        For i = _Desde To _Filas
            _Arreglo_Cd(i) = NuloPorNro(_Arreglo(i, 0), "")
        Next

        Dim _Filtro_Productos As String = Generar_Filtro_IN_Arreglo(_Arreglo_Cd, False)

        Dim _Problemas As Integer
        Dim _SinProbremas As Integer

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0

        For i = _Desde To _Filas

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()

            Dim _Codigo As String
            Dim _Descripcion As String
            Dim _Cantidad As Double
            Dim _UdTrans As Integer
            Dim _Precio As Double
            Dim _Bodega As String

            Try
                _Codigo = NuloPorNro(_Arreglo(i, 0), "")
                _Cantidad = NuloPorNro(_Arreglo(i, 1), 0)
                _UdTrans = NuloPorNro(_Arreglo(i, 2), 0)
                _Precio = NuloPorNro(_Arreglo(i, 3), 0)
                _Bodega = NuloPorNro(_Arreglo(i, 4), "")
            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    _Descripcion = _RowProducto.Item("NOKOPR")

                    _Error = Fx_Agregar_Producto(_RowProducto, _Cantidad, _UdTrans, _Precio, _Bodega)

                    If String.IsNullOrEmpty(_Error) Then
                        _SinProbremas += 1
                    Else
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & ", Código [" & _Codigo & "]",
                        _Txt_Log, False)
                        _Problemas += 1
                    End If

                Else

                    If String.IsNullOrEmpty(_Codigo) Then
                        _Descripcion = "#CODVACIO#"
                    Else
                        _Descripcion = "#NO EXISTE#"
                    End If

                    If _Descripcion = "#NO EXISTE#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: El producto no existe, Código [" & _Codigo & "]",
                                    _Txt_Log, False)
                        _Problemas += 1
                    ElseIf _Descripcion = "#CODVACIO#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: Código en blanco",
                                   _Txt_Log, False)
                        _Problemas += 1
                    End If

                End If

            Else

                Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Codigo & "]",
                 _Txt_Log, False)
                _Problemas += 1

            End If

            If CBool(_Problemas) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            If _Cancelar Then
                Exit For
            End If

            System.Windows.Forms.Application.DoEvents()

            _Contador += 1
            Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            Lbl_Procesando.Text = "Leyendo fila " & i & " de " & _Filas & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Producto: " & Trim(_Descripcion)

        Next

        Try

            If _Cancelar Then
                _Limpiar = True
                Return
            End If

            _Limpiar = False

            If CBool(_Problemas) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Problemas)))

                If _Problemas = 1 Then
                    _Leyend = "Existe " & _Problemas & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & _Problemas & " líneas con problemas en el archivo de lectura"
                End If

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_Archivo_TXT
                Fm.Pro_Nombre_Archivo = "Error_LevLista_X_Codigo.txt"
                Fm.Pro_Texto_Log = _Txt_Log.Text
                Fm.ShowDialog(Me)
                Fm.Dispose()

                _Tbl_Productos_Levantar.Clear()

                'CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Temp\", "Error_LevLista.txt", _Txt_Log.Text, False)
                'Process.Start("notepad.exe", AppPath() & "\Data\" & RutEmpresa & "\Temp\Error_LevLista.txt")

            End If

            If CBool(_Tbl_Productos_Levantar.Rows.Count) Then
                Me.Close()
            End If

        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty

        End Try

    End Sub

    Sub Sb_Importar_Productos_Txt()

        'Dim _Nombre_Archivo As String
        Dim _Ubic_Archivo As String

        Dim _OpenFileDialog As New OpenFileDialog

        With _OpenFileDialog
            .Filter = "Ficheros (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            'Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            .FileName = String.Empty '"D:\Nube OneDrive\OneDrive\Documentos\Empresas\Saime\Txt Ingresos\Generados" 
            .CheckPathExists = True
            If Directory.Exists(_InitialDirectory) Then
                .InitialDirectory = _InitialDirectory
            End If

            If .ShowDialog(Me) = DialogResult.OK Then
                _Nombre_Archivo_SExtencion = System.IO.Path.GetFileNameWithoutExtension(.SafeFileName)
                _Ubic_Archivo = System.IO.Path.GetDirectoryName(.FileName)

                _Nombre_Archivo_CExtencion = .SafeFileName
                _Ubic_Archivo = .FileName
            Else
                Beep()
                ToastNotification.Show(Me, "NO SE SELECCIONO NINGUN ARCHIVO", My.Resources.cross,
                                       3 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
                Return
            End If
        End With

        _Tbl_Productos_Levantar.Clear()

        Txt_Nombre_Archivo.Text = _Ubic_Archivo

        Dim sr As New System.IO.StreamReader(_Ubic_Archivo)
        Dim _Texto = sr.ReadToEnd()
        sr.Close()

        _Texto = _Texto.Trim
        _Texto = Replace(_Texto, ChrW(26), "")
        _Texto = Replace(_Texto, vbLf, "")

        Dim _Arreglo_Doc() As String = _Texto.Split(vbCrLf)
        Dim _Filas = _Arreglo_Doc.GetUpperBound(0)

        If String.IsNullOrEmpty(_Arreglo_Doc(_Filas)) Then
            _Filas -= 1
        End If

        'Dim _Arreglo_Cd(_Filas) As String

        Dim _Desde = 0

        If Chk_Primera_Fila_Es_encabezado.Checked Then
            _Desde = 1
        End If

        'For i = _Desde To _Filas
        '    _Arreglo_Cd(i) = NuloPorNro(_Arreglo(i, 0), "")
        'Next

        Dim _Problemas As Integer
        Dim _SinProbremas As Integer

        Sb_Habilitar_Deshabilitar_Comandos(False, True)
        Circular_Progres_Val.Maximum = _Filas

        Dim _Contador As Integer = 0
        Dim i = 0

        For i = _Desde To _Filas

            Dim _Error = String.Empty

            System.Windows.Forms.Application.DoEvents()

            Dim _Fila_Doc = Split(_Arreglo_Doc(i), ",")

            Dim _Codigo As String
            Dim _Descripcion As String
            Dim _CantidadUd1 As Double
            Dim _CantidadUd2 As Double
            Dim _UdTrans As Integer
            Dim _Precio As Double
            Dim _Bodega As String

            Try
                _Codigo = NuloPorNro(Replace(_Fila_Doc(0), """", ""), "")
                _CantidadUd1 = Replace(_Fila_Doc(1), """", "")
                _CantidadUd2 = Replace(_Fila_Doc(2), """", "")
                _Precio = Replace(_Fila_Doc(3), """", "")
                _Bodega = NuloPorNro(Replace(_Fila_Doc(4), """", ""), "")
            Catch ex As Exception
                _Error = ex.Message
            End Try

            If String.IsNullOrEmpty(_Error) Then

                Consulta_sql = "Select Top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _RowProducto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

                If Not (_RowProducto Is Nothing) Then

                    Dim _Nmarca As String = _RowProducto.Item("NMARCA").ToString.Trim
                    Dim _Cantidad As Double

                    If String.IsNullOrEmpty(_Nmarca) Then
                        _UdTrans = 1
                        _Cantidad = _CantidadUd1
                    Else
                        _UdTrans = 2
                        _Cantidad = _CantidadUd2
                    End If

                    _Descripcion = _RowProducto.Item("NOKOPR").ToString.Trim

                    _Error = Fx_Agregar_Producto(_RowProducto, _Cantidad, _UdTrans, _Precio, _Bodega)

                    If String.IsNullOrEmpty(_Error) Then
                        _SinProbremas += 1
                    Else
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & ", Código [" & _Codigo & "]",
                        _Txt_Log, False)
                        _Problemas += 1
                    End If

                Else

                    If String.IsNullOrEmpty(_Codigo) Then
                        _Descripcion = "#CODVACIO#"
                    Else
                        _Descripcion = "#NO EXISTE#"
                    End If

                    If _Descripcion = "#NO EXISTE#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: El producto no existe, Código [" & _Codigo & "]",
                                    _Txt_Log, False)
                        _Problemas += 1
                    ElseIf _Descripcion = "#CODVACIO#" Then
                        Sb_AddToLog("Fila Nro :" & i + 1, "Problema: Código en blanco",
                                   _Txt_Log, False)
                        _Problemas += 1
                    End If

                End If

            Else

                Sb_AddToLog("Fila Nro :" & i + 1, "Problema: " & _Error & "Código: [" & _Codigo & "]",
                 _Txt_Log, False)
                _Problemas += 1

            End If

            If CBool(_Problemas) Then
                Circular_Progres_Porc.ProgressColor = Color.Red
                Circular_Progres_Val.ProgressColor = Color.Red
            End If

            If _Cancelar Then
                Exit For
            End If

            System.Windows.Forms.Application.DoEvents()

            _Contador += 1

            If _Filas = 0 Then
                Circular_Progres_Porc.Value = 1
            Else
                Circular_Progres_Porc.Value = ((_Contador * 100) / _Filas)
            End If

            Circular_Progres_Val.Value += 1
            Circular_Progres_Val.ProgressText = Circular_Progres_Val.Value

            Lbl_Procesando.Text = "Leyendo fila " & i + 1 & " de " & _Filas + 1 & ". Estado Ok: " & _SinProbremas &
                                  ", Problemas: " & _Problemas & ", Producto: " & Trim(_Descripcion)

        Next

        Try

            If _Cancelar Then
                _Limpiar = True
                Return
            End If

            _Limpiar = False

            If CBool(_Problemas) Then

                Dim _Leyend As String
                Dim _Palabra As String = Trim(UCase(Letras(_Problemas)))

                If _Problemas = 1 Then
                    _Leyend = "Existe " & _Problemas & " línea con problema en el archivo de lectura"
                Else
                    _Leyend = "Existen " & _Problemas & " líneas con problemas en el archivo de lectura"
                End If

                MessageBoxEx.Show(Me, _Leyend & vbCrLf &
                                  "a continuación se mostrar una lista con los errores",
                                  "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Dim Fm As New Frm_Archivo_TXT
                Fm.Pro_Nombre_Archivo = "Error_LevLista_X_Codigo.txt"
                Fm.Pro_Texto_Log = _Txt_Log.Text
                Fm.ShowDialog(Me)
                Fm.Dispose()

                _Tbl_Productos_Levantar.Clear()

                'CrearArchivoTxt(AppPath() & "\Data\" & RutEmpresa & "\Temp\", "Error_LevLista.txt", _Txt_Log.Text, False)
                'Process.Start("notepad.exe", AppPath() & "\Data\" & RutEmpresa & "\Temp\Error_LevLista.txt")

            End If

            If CBool(_Tbl_Productos_Levantar.Rows.Count) Then
                Me.Close()
            End If

        Catch ex As Exception

        Finally

            Sb_Habilitar_Deshabilitar_Comandos(True, False)
            Txt_Nombre_Archivo.Text = String.Empty
            _Txt_Log.Text = String.Empty

        End Try

    End Sub

    Function Fx_Agregar_Producto(_RowProducto As DataRow,
                                 _Cantidad As Double,
                                 _UdTrans As Integer,
                                 _Precio As Double,
                                 _Bodega As String) As String

        Dim _Error = String.Empty
        Dim _Codigo = _RowProducto.Item("KOPR")
        Dim _Descripcion = _RowProducto.Item("NOKOPR")

        Try

            If Rdb_Bodega_Documento.Checked Then
                _Bodega = _CodBodega
            End If

            Dim _Existe As Boolean = CBool(_Sql.Fx_Cuenta_Registros("TABBO", "EMPRESA = '" & Mod_Empresa & "' And KOSU = '" & _Codsucursal & "' And KOBO = '" & _CodBodega & "'"))

            If Not _Existe Then
                Throw New System.Exception("No existe la bodega: " & _CodBodega)
            End If

            _Existe = CBool(_Sql.Fx_Cuenta_Registros("TABPRE", "KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"))

            If Not _Existe Then
                Throw New System.Exception("No existe en lista: " & _CodLista)
            End If

            If Rdb_Precio_Lista.Checked Then

                Consulta_sql = "Select Top 1 *,(Select top 1 MELT From TABPP Where KOLT = '" & _CodLista & "') as MELT From TABPRE
                                Where KOLT = '" & _CodLista & "' And KOPR = '" & _Codigo & "'"
                Dim _RowPrecios = _Sql.Fx_Get_DataRow(Consulta_sql)

                Dim _Ecuacion As String
                Dim _Melt As String = _RowPrecios.Item("MELT")

                If _UdTrans = 1 Then _Ecuacion = _RowPrecios.Item("ECUACION").ToString.Trim
                If _UdTrans = 2 Then _Ecuacion = _RowPrecios.Item("ECUACIONU2").ToString.Trim

                If _UdTrans <> 1 And _UdTrans <> 2 Then
                    Throw New System.Exception("La Unidad de transacción debe ser 1 o 2")
                End If

                _Precio = Fx_Funcion_Ecuacion_Random(Me, "", _Ecuacion, _Codigo, _UdTrans, _RowPrecios, 0, 0, 0)

                If _NetoBruto = "B" And _Melt = "N" Then

                    Consulta_sql = "Select Isnull(Sum(POIM),0) As Impuesto From TABIM" & Space(1) &
                                   "Where KOIM In (Select KOIM From TABIMPR Where KOPR = '" & _Codigo & "')"
                    Dim _RowImpuestos = _Sql.Fx_Get_DataRow(Consulta_sql)

                    Dim _PorIva As Double = _RowProducto.Item("POIVPR")
                    Dim _PorIla As Double = _RowImpuestos.Item("Impuesto")

                    Dim _Iva = _PorIva / 100
                    Dim _Ila = _PorIla / 100

                    Dim _Impuestos As Double = 1 + (_Iva + _Ila)

                    _Precio = Math.Round(_Precio * _Impuestos, 0)

                End If

            End If

            Dim NewFila As DataRow
            NewFila = _Tbl_Productos_Levantar.NewRow
            With NewFila

                .Item("Codigo") = _Codigo
                .Item("Descripcion") = _Descripcion
                .Item("Cantidad") = _Cantidad
                .Item("UdTrans") = _UdTrans
                .Item("Precio") = _Precio
                .Item("Bodega") = _Bodega

                _Tbl_Productos_Levantar.Rows.Add(NewFila)

            End With
        Catch ex As Exception
            _Error = ex.Message
        End Try

        Return _Error

    End Function

    Sub Sb_Habilitar_Deshabilitar_Comandos(_Habilitar As Boolean,
                                           _Habilitar_Cancelar As Boolean)

        _Cancelar = False

        Panel1.Enabled = _Habilitar
        Panel2.Enabled = _Habilitar
        Chk_Primera_Fila_Es_encabezado.Enabled = _Habilitar

        Btn_Buscar_Archivo_Excel.Enabled = _Habilitar
        Btn_Archivo_Ayuda_Excel.Enabled = _Habilitar

        Me.ControlBox = _Habilitar

        Circular_Progres_Porc.ProgressColor = Color.SteelBlue
        Circular_Progres_Val.ProgressColor = Color.SteelBlue
        Circular_Progres_Porc.Maximum = 100

        Circular_Progres_Porc.Value = 0
        Circular_Progres_Val.Value = 0

        Btn_Cancelar.Visible = _Habilitar_Cancelar
        Lbl_Procesando.Visible = _Habilitar_Cancelar

        Me.Refresh()

    End Sub

    Private Sub Btn_Archivo_Ayuda_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Archivo_Ayuda_Excel.Click

        Dim _Nom_Excel As String

        Consulta_sql = "Select 'Caracter [13]' As 'Código','Númerico' As 'Cantidad'," &
                       "'1 o 2' As 'Unidad transacción','Númerico' As 'Precio','Caracter [3]' As 'Bodega'"

        _Nom_Excel = "Ejemplo levantamiento productos masivamente"

        ExportarTabla_JetExcel(Consulta_sql, Me, _Nom_Excel)

    End Sub

    Private Sub Btn_Buscar_Archivo_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo_Excel.Click
        Sb_Importar_Productos_Excel()
    End Sub

    Private Sub Btn_Buscar_Archivo_Txt_Click(sender As Object, e As EventArgs) Handles Btn_Buscar_Archivo_Txt.Click
        Sb_Importar_Productos_Txt()
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
    End Sub
End Class
