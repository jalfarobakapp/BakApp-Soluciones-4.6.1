Imports System.Data.SqlClient
Imports System.IO
Imports DevComponents.DotNetBar


Public Class Frm_Adjuntar_Archivos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Campo_Key As String
    Dim _Log As String

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"
    Dim _Arreglo_Archivos(0) As String

    Dim _Tabla As String
    Dim _Campo As String
    Dim _Codigo_Id As String

    Public Property Otra_Condicion As String
    Public Property Pedir_Permiso As Boolean
    Public Property SoloLectura As Boolean

    Public Sub New(Tabla As String, Campo As String, Codigo_Id As String)

        ' Esta llamada es exigida por el diseñador.

        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Tabla = Tabla
        _Campo = Campo
        _Codigo_Id = Codigo_Id

        If Not Directory.Exists(_Path) Then
            System.IO.Directory.CreateDirectory(_Path)
        End If

        _Pedir_Permiso = True

        Sb_Color_Botones_Barra(Bar1)

    End Sub

    Private Sub Frm_Adjuntar_Archivos_Documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Listv_Archivos.FullRowSelect = True
        Sb_Actualizar_ListView()

        Btn_Subir_Archivos.Visible = Not SoloLectura
        Btn_Agregar_Observacion.Visible = Not SoloLectura
        Btn_Mnu_Eliminar_Archivo.Visible = Not SoloLectura
        Btn_Eliminar_Archivos.Visible = Not SoloLectura
        Btn_Subir_Archivos2.Enabled = Not SoloLectura
        Btn_Agregar_Observacion2.Enabled = Not SoloLectura

    End Sub

    Private Sub Sb_Actualizar_ListView()

        Consulta_sql = "Select Id, " & _Campo & ", Nombre_Archivo, Fecha,DATALENGTH(Archivo) As Tamano,CodFuncionario" & vbCrLf &
                       "From " & _Global_BaseBk & _Tabla & vbCrLf &
                       "Where " & _Campo & " = '" & _Codigo_Id & "'" & vbCrLf & _Otra_Condicion

        Dim _TblArchivos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Listv_Archivos.Items.Clear()

        '0 = Excel
        '1 = Pdf
        '2 = Word
        '3 = Txt
        '4 = Jpg
        '5 = Otros
        '6 = Bmp

        ' Recorrer las columnas  

        For Each _Fila As DataRow In _TblArchivos.Rows

            Dim _Archivo As String = _Fila.Item("Nombre_Archivo")

            Dim _Extencion = Split(_Archivo, ".")
            Dim _Ext As String
            Dim _Imagen As Integer

            Dim _Extn = Split(_Archivo, ".")
            Dim _l = _Extn.Length - 1
            _Ext = _Extn(_l)

            Select Case UCase(_Ext)

                Case "XLS", "XLSX"
                    _Imagen = 0
                Case "PDF"
                    _Imagen = 1
                Case "DOC", "DOCX", "RTF"
                    _Imagen = 2
                Case "TXT"
                    _Imagen = 3
                Case "JPG", "PNG", "JPEG"
                    _Imagen = 4
                Case "BMP"
                    _Imagen = 6
                Case "MSG"
                    _Imagen = 7
                Case Else
                    _Imagen = 5

            End Select

            Dim _s = _Fila(1)

            Dim _Id As Integer = _Fila.Item("Id")
            Dim _Tamano = _Fila.Item("Tamano")
            Dim _Fecha = _Fila.Item("Fecha")
            Dim _CodFuncionario = _Fila.Item("CodFuncionario")
            Dim _Size

            'Mostrar en Kilobytes si es menor de un megabyte 

            If _Tamano < 1048576 Then
                _Tamano = _Tamano / 1024
                _Size = FormatNumber(_Tamano, 2) & " KB" 'Math.Round(Val(_Fila.Item("Size")) / 1000, 2) & " KB"
            Else
                _Tamano = _Tamano / 1024 / 1024
                _Size = FormatNumber(_Tamano, 2) & " MB"
            End If

            Dim _NewFila As ListViewItem = New ListViewItem(_Archivo, _Imagen)
            _NewFila.SubItems.Add(_Size)
            _NewFila.SubItems.Add(_Fecha)
            _NewFila.SubItems.Add(_CodFuncionario)
            _NewFila.SubItems.Add(_Id)

            Listv_Archivos.Items.Add(_NewFila)

        Next

    End Sub

    Private Sub Btn_Subir_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Subir_Archivos.Click, Btn_Subir_Archivos2.Click

        If _Pedir_Permiso Then
            If Not Fx_Tiene_Permiso(Me, "Doc00032") Then
                Return
            End If
        End If

        Try

            Dim oFD As New OpenFileDialog

            With oFD

                .Title = "Seleccionar archivo"
                .Multiselect = True

                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    Dim _i = 0

                    Dim _Size_Archivos(.FileNames.Length - 1)
                    For Each _Ruta As String In .SafeFileNames
                        _Size_Archivos(_i) = _Ruta
                        _i += 1
                    Next
                    _i = 0

                    Dim _Ruta_Archivos(.FileNames.Length - 1)
                    For Each _Ruta As String In .FileNames
                        _Ruta_Archivos(_i) = _Ruta
                        _i += 1
                    Next
                    _i = 0

                    Sb_Trabajando(True)

                    For Each _Archivo As String In .SafeFileNames

                        Dim _Ruta As String = _Ruta_Archivos(_i)
                        Dim _InfoArchivo As New FileInfo(_Ruta)
                        Dim _Tamano As String
                        Dim _Subir_Archivo = True

                        If _InfoArchivo.Length > 5242880 Then '1048576 Then

                            Dim Size = _InfoArchivo.Length / 1024 / 1024
                            _Tamano = FormatNumber(Size, 2) + " MB"  'FormatNumber(tamanoFicheros, 2) + " KB" 

                            If MessageBoxEx.Show(Me, "El archivo que quiere levantar es demasiado pesado" & vbCrLf &
                                            "¿Está seguro de levantar este archivo, la operación podría tardar varios minutos?" & vbCrLf & vbCrLf &
                                            "Archivo:   " & _Archivo & " " & _Tamano,
                                            "Archivo supera el máximo permitido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then

                                AddToLog("Subir archivo", "Problema: " & _Archivo)
                                AddToLog("Subir archivo", "Archivo muy pesado: " & _Tamano)
                                _Subir_Archivo = False
                            End If

                            'tamanoFicheros = tamanoFicheros / 1024 / 1024
                            'lInfoAdjuntos.Text = "Tamaño: " & 
                            'FormatNumber(tamanoFicheros, 1) + " MB" 
                        End If

                        Dim _Nombre_Archivo = _InfoArchivo.Name


                        Dim _Id As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & _Tabla, "Id",
                                             _Campo & " = '" & _Codigo_Id & "' And Nombre_Archivo = '" & _Nombre_Archivo & "'", True)

                        If CBool(_Id) Then
                            If MessageBoxEx.Show(Me, "Archivo: " & _Nombre_Archivo & vbCrLf &
                                                 "¿Desea reemplazarlo?", "El archivo ya existe",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then

                                Consulta_sql = "Delete " & _Global_BaseBk & _Tabla & " Where Id = " & _Id
                                _Sql.Ej_consulta_IDU(Consulta_sql)
                            Else
                                _Subir_Archivo = False
                            End If
                        End If

                        If _Subir_Archivo Then
                            Fx_Grabar_Observacion_Adjunta(_Ruta, _Nombre_Archivo, True)
                        End If

                        _i += 1
                    Next

                End If

            End With

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Sb_Actualizar_ListView()
            Sb_Trabajando(False)
        End Try

    End Sub

    Function Fx_Grabar_Observacion_Adjunta(_Ruta As String,
                                           _Nombre_Archivo As String,
                                           _En_Construccion As Boolean) As Boolean

        Dim blob As Byte()

        If Not _Sql.Fx_Exite_Campo(_Global_BaseBk & _Tabla, "En_Construccion") Then
            _En_Construccion = False
        End If

        Try
            blob = IO.File.ReadAllBytes(_Ruta)

            Dim cn As New SqlConnection
            Dim sCnn = Cadena_ConexionSQL_Server
            cn.ConnectionString = sCnn

            If _En_Construccion Then
                Consulta_sql = "Insert Into " & _Global_BaseBk & _Tabla & " (" & _Campo & ",Nombre_Archivo,Fecha,Archivo,CodFuncionario,En_Construccion) Values " &
                           "(@" & _Campo & ",@Nombre_Archivo,Getdate(),@Archivo,@CodFuncionario,@En_Construccion)"
            Else
                Consulta_sql = "Insert Into " & _Global_BaseBk & _Tabla & " (" & _Campo & ",Nombre_Archivo,Fecha,Archivo,CodFuncionario) Values " &
                           "(@" & _Campo & ",@Nombre_Archivo,Getdate(),@Archivo,@CodFuncionario)"
            End If



            Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
            ' Crear la consulta T-SQL para insertar un nuevo registro.
            cmd.CommandText = Consulta_sql

            ' Añadir el único parámetro de entrada existente.
            cmd.Parameters.AddWithValue("@" & _Campo, _Codigo_Id)
            cmd.Parameters.AddWithValue("@Nombre_Archivo", _Nombre_Archivo)
            cmd.Parameters.AddWithValue("@CodFuncionario", FUNCIONARIO)

            If _En_Construccion Then cmd.Parameters.AddWithValue("@En_Construccion", _En_Construccion)

            ' La función ReadBinaryFile tal cual se encuentra implementada no devolverá un valor Nothing,
            ' pero muestro cómo especificar un valor NULL al parámetro de entrada si el valor del campo
            ' binario fuese Nothing. Para insertar un valor NULL, el campo de la tabla lo tiene que permitir.

            cmd.Parameters.AddWithValue("@Archivo", If(blob IsNot Nothing, blob, CObj(DBNull.Value)))
            cn.Open()

            Dim c As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            Dim _Grabar As Integer = cmd.ExecuteNonQuery()
            Me.Cursor = c

            AddToLog("Subir archivo", "Ok: " & _Nombre_Archivo)

            Return True

        Catch ex As Exception
            AddToLog("Subir archivo", "Problema: " & _Nombre_Archivo)
            AddToLog("Subir archivo", "Error SQL: " & ex.Message)
            ' MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        Me.Refresh()

    End Function

    Sub Sb_Trabajando(ByVal _Trabajando As Boolean)

        If _Trabajando Then
            Me.Enabled = False
        Else
            Me.Enabled = True
        End If

        Barra_Progreso.Visible = _Trabajando
        Me.Refresh()

    End Sub

    Private Sub Btn_Descargar_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Descargar_Archivos.Click, Btn_Descargar_Archivos2.Click

        If CBool(Listv_Archivos.SelectedItems.Count) Then

            Dim _Directorio_Destino = Fx_Seleccionar_Directorio()

            If Not String.IsNullOrEmpty(_Directorio_Destino) Then

                Dim _Lista As ListViewItem = New ListViewItem()

                _Log = String.Empty
                AddToLog("Decargando archivos", "Directorio: " & _Directorio_Destino)
                Dim _Bajados As Integer

                Sb_Trabajando(True)

                For Each _Fila As ListViewItem In Listv_Archivos.SelectedItems

                    Dim _Archivo = _Fila.Text
                    Dim _Semilla = CInt(_Fila.SubItems.Item(4).Text)

                    If Fx_Extrae_Archivo_desde_BD(_Semilla, _Archivo, _Directorio_Destino) Then
                        _Bajados += 1
                        AddToLog("Ok", "..\" & _Archivo)
                    Else
                        AddToLog("No se pudo descargar el archivo", _Archivo)
                    End If

                Next

                If CBool(_Bajados) Then
                    Shell("explorer.exe " & _Directorio_Destino, AppWinStyle.NormalFocus)
                End If

            End If

        Else

            Beep()
            ToastNotification.Show(Me, "No hay archivos seleccionados", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

        Sb_Trabajando(False)

    End Sub

    Private Sub AddToLog(ByVal Accion As String,
                         ByVal Descripcion As String)
        _Log += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        'TxtLog.Select(_Log.Length - 1, 0)
        'TxtLog.ScrollToCaret()
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Function Fx_Seleccionar_Directorio()

        Dim _Directorio As New FolderBrowserDialog

        With _Directorio

            .Reset() ' resetea

            ' leyenda
            .Description = "Seleccionar una carpeta "
            ' Path " Mis documentos "

            Dim _SPath As String '= Txt_Directorio_Seleccionado.Text

            'If String.IsNullOrEmpty(Txt_Directorio_Seleccionado.Text) Then
            _SPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            'End If

            .SelectedPath = _SPath 'Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            ' deshabilita el botón " crear nueva carpeta "
            .ShowNewFolderButton = True
            '.RootFolder = Environment.SpecialFolder.Desktop
            '.RootFolder = Environment.SpecialFolder.StartMenu

            Dim ret As DialogResult = .ShowDialog ' abre el diálogo
            Dim _Directorio_Seleccionado As String = .SelectedPath

            .Dispose()
            ' si se presionó el botón aceptar ...
            If ret = Windows.Forms.DialogResult.OK Then
                Return _Directorio_Seleccionado
            Else
                Return ""
            End If

        End With

    End Function

    Function Fx_Extrae_Archivo_desde_BD(ByVal _Id As Integer,
                                        ByVal _Nombre_Archivo As String,
                                        ByVal _Dir_Temp As String) As Boolean

        Dim data As Byte() = Nothing

        Try
            ' Construimos los correspondientes objetos para
            ' conectarnos a la base de datos de SQL Server,
            ' utilizando la seguridad integrada de Windows NT.
            '
            Using cn As New SqlConnection
                Dim sCnn = Cadena_ConexionSQL_Server
                cn.ConnectionString = sCnn
                Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
                ' Seleccionamos únicamente el campo que contiene
                ' los documentos, filtrándolo mediante su
                ' correspondiente campo identificador.
                '
                cmd.CommandText = "Select Archivo From " & _Global_BaseBk & _Tabla & " Where Id = " & _Id
                ' Abrimos la conexión.
                cn.Open()
                ' Creamos un DataReader.
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                ' Leemos el registro.
                dr.Read()
                ' El tamaño del búfer debe ser el adecuado para poder
                ' escribir en el archivo todos los datos leídos.
                '
                ' Si el parámetro 'buffer' lo pasamos como Nothing, obtendremos
                ' la longitud del campo en bytes.
                '
                Dim bufferSize As Integer = Convert.ToInt32(dr.GetBytes(0, 0, Nothing, 0, 0))

                ' Creamos el array de bytes. Como el índice está
                ' basado en cero, la longitud del array será la
                ' longitud del campo menos una unidad.
                '
                data = New Byte(bufferSize - 1) {}

                ' Leemos el campo.
                '
                dr.GetBytes(0, 0, data, 0, bufferSize)

                ' Cerramos el objeto DataReader, e implícitamente la conexión.
                '
                dr.Close()

            End Using

            ' Procedemos a crear el archivo, en el ejemplo
            ' un documento de Microsoft Word.
            '
            Sb_WriteBinaryFile(Me, _Dir_Temp & "\" & _Nombre_Archivo, data)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Shared Sub Sb_WriteBinaryFile(ByVal _Formulario As Form,
                                          ByVal _Ruta_Archivo As String,
                                          ByVal data As Byte())

        ' Comprobación de los valores de los parámetros.
        '
        If (String.IsNullOrEmpty(_Ruta_Archivo)) Then _
            Throw New ArgumentException("No se ha especificado el archivo de destino.", "fileName")

        If (data Is Nothing) Then _
            Throw New ArgumentException("Los datos no son válidos para crear un archivo.", "data")

        ' Crear el archivo. Se producirá una excepción si ya existe
        ' un archivo con el mismo nombre.

        Dim _Existe As Boolean = File.Exists(_Ruta_Archivo)

        If _Existe Then
            If MessageBoxEx.Show(_Formulario, "¿Desea reemplazarlo?" & vbCrLf & vbCrLf &
                                _Ruta_Archivo, "Este archivo ya existe",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                File.Delete(_Ruta_Archivo)
            Else
                Return
            End If
        End If

        Using fs As New IO.FileStream(_Ruta_Archivo, IO.FileMode.CreateNew, IO.FileAccess.Write)

            ' Crea el escritor para la secuencia.
            Dim bw As New IO.BinaryWriter(fs)

            ' Escribir los datos en la secuencia.
            bw.Write(data)

        End Using

    End Sub

    Private Sub Btn_Mnu_Eliminar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Eliminar_Archivo.Click, Btn_Eliminar_Archivos.Click

        If CBool(Listv_Archivos.SelectedItems.Count) Then

            Dim _Mensaje As String
            If Listv_Archivos.SelectedItems.Count = 1 Then
                _Mensaje = "este archivo"
            Else
                _Mensaje = "estos archivos"
            End If

            Dim _Archivo_Otro_Usuario As Boolean

            For Each _Fila As ListViewItem In Listv_Archivos.SelectedItems

                Dim _CodFuncionario = _Fila.SubItems.Item(3).Text

                If FUNCIONARIO <> _CodFuncionario Then
                    _Archivo_Otro_Usuario = True
                    Exit For
                End If

            Next

            If _Archivo_Otro_Usuario Then
                If Not Fx_Tiene_Permiso(Me, "Doc00034") Then
                    Return
                End If
            End If

            If MessageBoxEx.Show(Me, "Esta seguro de querer eliminar " & _Mensaje, "Eliminar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim _Lista As ListViewItem = New ListViewItem()
                _Log = String.Empty

                AddToLog("Eliminando archivo(s)", "Archivos seleccionados " & Listv_Archivos.SelectedItems.Count)
                Sb_Trabajando(True)

                For Each _Fila As ListViewItem In Listv_Archivos.SelectedItems

                    Dim _Archivo = _Fila.Text
                    Dim _Id = CInt(_Fila.SubItems.Item(4).Text)

                    Consulta_sql = "Delete " & _Global_BaseBk & _Tabla & " Where Id = " & _Id

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then
                        AddToLog("Eliminado", "..\" & _Archivo)
                    Else
                        AddToLog("Problema", "No es posible elimar este archivo: " & _Archivo)
                    End If

                Next

                Sb_Actualizar_ListView()

            End If

        Else

            Beep()
            ToastNotification.Show(Me, "No hay archivos seleccionados", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

        Sb_Trabajando(False)

    End Sub


    Private Sub Btn_Mnu_Descargar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Descargar_Archivo.Click

        Dim _Nombre_Archivo = Listv_Archivos.SelectedItems(0).Text
        Dim _Id = Listv_Archivos.SelectedItems(0).SubItems(4).Text
        Dim _Archivo As String = _Path & "\" & _Nombre_Archivo

        Try
            System.IO.File.Delete(_Archivo)
        Catch ex As Exception
        End Try

        If Fx_Extrae_Archivo_desde_BD(_Id, _Nombre_Archivo, _Path) Then

            If _Nombre_Archivo.ToLower.Contains(".rtf") Then
                ''ss
                Dim _Observaciones_Rtf As New DevComponents.DotNetBar.Controls.RichTextBoxEx

                _Observaciones_Rtf.LoadFile(_Archivo)
                File.Delete(_Archivo)

                Dim Fm As New Frm_Adjuntar_Arch_Rtf(_Tabla, _Campo, _Codigo_Id)
                Fm.Text = "ADJUNTAR OBSERVACION O PEGAR IMAGEN..." 'UCase(Btn_Informacion_Proximos_Vencimientos.Text)
                Fm.Rtf_Observaciones.Rtf = _Observaciones_Rtf.Rtf
                Fm.Btn_Grabar.Visible = False
                Fm.ShowDialog(Me)
                Fm.Dispose()

            Else

                Try

                    Me.Enabled = False
                    System.Diagnostics.Process.Start(_Archivo)

                Catch ex As Exception
                    MessageBoxEx.Show(ex.Message, "Problema al abrir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Shell("explorer.exe " & _Path, AppWinStyle.NormalFocus)

                Finally
                    Me.Enabled = True
                End Try

            End If

        End If

        Sb_Trabajando(False)

    End Sub

    Private Sub Frm_Adjuntar_Archivos_X_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F5 Then
            Sb_Actualizar_ListView()
        End If
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Actualizar_ListView()
    End Sub

    Private Sub Frm_Adjuntar_Archivos_X_Productos_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Sb_Eliminar_Archivos_Temporales()
    End Sub

    Private Sub Btn_Agregar_Observacion_Click(sender As Object, e As EventArgs) Handles Btn_Agregar_Observacion.Click, Btn_Agregar_Observacion2.Click

        If _Pedir_Permiso Then
            If Not Fx_Tiene_Permiso(Me, "Doc00032") Then
                Return
            End If
        End If

        Dim _Observaciones_Rtf As DevComponents.DotNetBar.Controls.RichTextBoxEx
        Dim _Grabar As Boolean
        Dim _Nombre_Archivo As String
        Dim _Dir_Temp = _Path

        _Observaciones_Rtf = New DevComponents.DotNetBar.Controls.RichTextBoxEx

        Dim _Ruta_y_Archivo As String
        Dim _Nombre_Archivo_Ext As String

        Dim Fm As New Frm_Adjuntar_Arch_Rtf(_Tabla, _Campo, _Codigo_Id)
        Fm.Text = "ADJUNTAR OBSERVACION O PEGAR IMAGEN..."
        _Grabar = Fm.Grabar
        _Nombre_Archivo = Fm.Nombre_Archivo
        Fm.ShowDialog(Me)
        _Grabar = Fm.Grabar
        _Nombre_Archivo = Fm.Nombre_Archivo
        _Observaciones_Rtf.Rtf = Fm.Rtf_Observaciones.Rtf
        _Ruta_y_Archivo = Fm.Ruta_y_Archivo
        _Nombre_Archivo_Ext = Fm.Nombre_Archivo_Ext

        If _Grabar Then

            Fx_Grabar_Observacion_Adjunta(_Ruta_y_Archivo, _Nombre_Archivo_Ext, True)

            Sb_Eliminar_Archivos_Temporales()

            Beep()
            ToastNotification.Show(Me, "OBSERVACIONES ACTUALIZADAS CORRECTAMENTE", My.Resources.ok_button,
                               2 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)

            Sb_Actualizar_ListView()

        End If

        Fm.Dispose()

    End Sub

    Private Sub Sb_Eliminar_Archivos_Temporales()

        For Each fichero As String In Directory.GetFiles(_Path)
            Try
                File.Delete(fichero)
            Catch ex As Exception

            End Try
        Next

    End Sub

    Private Sub Listv_Archivos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Listv_Archivos.MouseDoubleClick

        If CBool(Listv_Archivos.SelectedIndices.Count) Then
            Call Btn_Mnu_Descargar_Archivo_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Listv_Archivos_MouseDown(sender As Object, e As MouseEventArgs) Handles Listv_Archivos.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If CBool(Listv_Archivos.SelectedItems.Count) Then
                If Listv_Archivos.SelectedIndices.Count = 1 Then
                    ShowContextMenu(Menu_Contextual_Fila)
                End If
                'ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If Listv_Archivos.SelectedIndices.Count > 1 Then
                    ShowContextMenu(Menu_Contextual_Filas)
                End If

            Else
                ShowContextMenu(Menu_Contextual_Subir)
            End If

        End If

    End Sub

End Class
