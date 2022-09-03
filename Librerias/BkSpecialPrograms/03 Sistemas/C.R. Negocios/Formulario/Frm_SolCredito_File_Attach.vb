Imports DevComponents.DotNetBar

Imports System.IO
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Frm_SolCredito_File_Attach

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    'Dim _Dir_Temp = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Negocios_Cli"
    Dim _NroNegocio As String

    Public Sub New(ByVal NroNegocio As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Formato_Generico_Grilla(Grilla, 22, New Font("Tahoma", 8), Color.AliceBlue, True, True, True)
        _NroNegocio = NroNegocio
    End Sub

    Private Sub Frm_SolCredito_File_Attach_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Número de negocio: " & _NroNegocio
        'InsertarBotonenGrilla(Grilla, "BtnImagen", "File", "File", 0, _Tipo_Boton.Imagen)
        Sb_Llenat_Lista_ListView()
        'Sb_Actualizar_Grilla()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    'Sub Sb_Actualizar_Grilla()

    '    Consulta_sql = "Select Semilla,Nom_Documento From " & _Global_BaseBk & "Zw_Negocios_04_Doc" & vbCrLf & _
    '                   "Where NroNegocio = '" & _NroNegocio & "'"

    '    With Grilla

    '        .DataSource = _Sql.Fx_Get_Tablas(Consulta_sql)

    '        OcultarEncabezadoGrilla(Grilla, True)

    '        .Columns("BtnImagen").Visible = True
    '        .Columns("BtnImagen").HeaderText = "File"
    '        .Columns("BtnImagen").Width = 50

    '        .Columns("Nom_Documento").Visible = True
    '        .Columns("Nom_Documento").HeaderText = "Archivo adjunto"
    '        .Columns("Nom_Documento").Width = 400

    '    End With

    '    For Each _Fila As DataGridViewRow In Grilla.Rows

    'Dim _Imagen As Integer
    'Dim _Nom_Documento As String = _Fila.Cells("Nom_Documento").Value

    '    Dim _Doc = Split(_Nom_Documento, ".")

    '   Dim _Extencion As String = _Doc(_Doc.Length) 'Mid(_Nom_Documento, Len(_Nom_Documento) - 2, 4)



    '          Select Case UCase(_Extencion)

    '             Case "XLS", "XLSX"
    '                 _Imagen = 0
    '             Case "PDF"
    '                _Imagen = 1
    '           Case "DOC", "DOCX", "RTF"
    '                _Imagen = 2
    '            Case "TXT"
    '                _Imagen = 3
    '            Case "JPG", "PNG"
    '                _Imagen = 4
    '            Case "BMP"
    '                _Imagen = 6
    '            Case Else
    '                _Imagen = 5
    '        End Select

    '        _Fila.Cells("BtnImagen").Value = ImageList1.Images.Item(_Imagen)
    '    Next


    ' End Sub

    Private Sub Sb_Llenat_Lista_ListView()

        Consulta_sql = "Select Semilla,Nom_Documento,DATALENGTH(Archivo) as Size,Fecha From " & _Global_BaseBk & "Zw_Negocios_04_Doc" & vbCrLf & _
                       "Where NroNegocio = '" & _NroNegocio & "' And Tipo_Obs = 'ADJUNTO'"

        Dim _TblArchivos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        List_Carpeta_FTP.Items.Clear()

        '0 = Excel
        '1 = Pdf
        '2 = Word
        '3 = Txt
        '4 = Jpg
        '5 = Otros
        '6 = Bmp

        'For f As Integer = 0 To _Lista_Archivos.Count - 1
        ' recorrer las columnas  
        For Each _Fila As DataRow In _TblArchivos.Rows

            ' Dim _Fila = Split(_Lista_Archivos.item(f), ";")
            Dim _Archivo As String = _Fila.Item("Nom_Documento")

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

            Dim _Semilla As Integer = _Fila.Item("Semilla")
            Dim _Tamano = _Fila.Item("Size")
            Dim _Size


            'Mostrar en Kilobytes si es menor de un megabyte 
            If _Tamano < 1048576 Then
                _Tamano = _Tamano / 1024
                _Size = FormatNumber(_Tamano, 2) & " KB" 'Math.Round(Val(_Fila.Item("Size")) / 1000, 2) & " KB"
            Else
                _Tamano = _Tamano / 1024 / 1024
                _Size = FormatNumber(_Tamano, 2) & " MB"
            End If


            Dim _Fecha = _Fila.Item("Fecha")

            Dim _NewFila As ListViewItem = New ListViewItem(_Archivo, _Imagen)
            _NewFila.SubItems.Add(_Size)
            _NewFila.SubItems.Add(_Fecha)
            _NewFila.SubItems.Add(_Semilla)

            List_Carpeta_FTP.Items.Add(_NewFila)
        Next

    End Sub

    Private Sub Btn_Subir_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Subir_Archivos.Click
        Dim oFD As New OpenFileDialog
        With oFD
            .Title = "Seleccionar fichero"
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

                    If _InfoArchivo.Length > 5242880 Then '1048576 Then

                        Dim Size = _InfoArchivo.Length / 1024 / 1024
                        _Tamano = FormatNumber(Size, 2) + " MB"  'FormatNumber(tamanoFicheros, 2) + " KB" 

                        If MessageBoxEx.Show(Me, "El archivo que quiere levantar es demasiado pesado" & vbCrLf & _
                                        "¿Está seguro de levantar este archivo, la operación podría tardar varios minutos?" & vbCrLf & vbCrLf & _
                                        "Archivo: " & _Archivo & " " & _Tamano, _
                                        "Archivo supera el máximo permitido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then


                            AddToLog("Subir archivo", "Problema: " & _Archivo)
                            AddToLog("Subir archivo", "Archivo muy pesado: " & _Tamano)
                            GoTo Seguir
                        End If

                        'tamanoFicheros = tamanoFicheros / 1024 / 1024
                        'lInfoAdjuntos.Text = "Tamaño: " & 
                        'FormatNumber(tamanoFicheros, 1) + " MB" 
                    End If

                    Fx_Grabar_Observacion_Adjunta(_NroNegocio, _Ruta, _Archivo, Tipo_Obs.ADJUNTO)

                    'SQL_ServerClass.CerrarConexion(cn)
Seguir:
                    _i += 1
                Next
                Sb_Llenat_Lista_ListView()
                Sb_Trabajando(False)
            End If

        End With

    End Sub

    Enum Tipo_Obs
        ADJUNTO
        OBS_VENCIMIENTO
        INFORME_FINAL
    End Enum

    Function Fx_Grabar_Observacion_Adjunta(ByVal _NroNegocio As String, _
                                           ByVal _Ruta As String, _
                                           ByVal _Archivo As String, _
                                           ByVal _Tipo_Obs As Tipo_Obs) As Boolean

        Dim blob As Byte()
        Try
            blob = IO.File.ReadAllBytes(_Ruta)

            Dim cn As New SqlConnection
            Dim sCnn = Cadena_ConexionSQL_Server
            cn.ConnectionString = sCnn

            Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
            ' Crear la consulta T-SQL para insertar un nuevo registro.
            cmd.CommandText = "INSERT INTO " & _Global_BaseBk & _
                              "Zw_Negocios_04_Doc (NroNegocio,Nom_Documento,Tipo_Obs,Archivo,Fecha) VALUES " & _
                              "(@NroNegocio,@Nom_Documento,@Tipo_Obs,@Archivo,GetDate())"
            ' Añadir el único parámetro de entrada existente.
            cmd.Parameters.AddWithValue("@NroNegocio", _NroNegocio)
            cmd.Parameters.AddWithValue("@Nom_Documento", _Archivo)
            cmd.Parameters.AddWithValue("@Tipo_Obs", _Tipo_Obs.ToString)
            ' La función ReadBinaryFile tal cual se encuentra implementada no devolverá un valor Nothing,
            ' pero muestro cómo especificar un valor NULL al parámetro de entrada si el valor del campo
            ' binario fuese Nothing. Para insertar un valor NULL, el campo de la tabla lo tiene que permitir.

            cmd.Parameters.AddWithValue("@Archivo", If(blob IsNot Nothing, blob, CObj(DBNull.Value)))
            cn.Open()

            Dim c As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            Dim _Grabar As Integer = cmd.ExecuteNonQuery()
            Me.Cursor = c

            Return True

            AddToLog("Subir archivo", "Ok: " & _Archivo)
        Catch ex As Exception
            AddToLog("Subir archivo", "Problema: " & _Archivo)
            AddToLog("Subir archivo", "Error SQL: " & ex.Message)
            ' MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function


    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        '  Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        '  Dim _Semilla As Integer = _Fila.Cells("Semilla").Value
        '  Dim _Nom_Documento As String = _Fila.Cells("Nom_Documento").Value

        '  Dim _Dir_Temp As String = Fx_Seleccionar_Directorio()

        '  If Not String.IsNullOrEmpty(_Dir_Temp) Then
        'Sb_Extrae_Archivo_desde_BD(_Semilla, _Nom_Documento, _Dir_Temp)
        'End If

    End Sub

    Function Fx_Extrae_Archivo_desde_BD(ByVal _Semilla As Integer, _
                                        ByVal _Nom_Archivo As String, _
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
                cmd.CommandText = "SELECT Archivo From " & _Global_BaseBk & "Zw_Negocios_04_Doc WHERE Semilla = " & _Semilla
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
            Sb_WriteBinaryFile(Me, _Dir_Temp & "\" & _Nom_Archivo, data)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Shared Sub Sb_WriteBinaryFile(ByVal _Formulario As Form, _
                                          ByVal _Ruta_Archivo As String, _
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
            If MessageBoxEx.Show(_Formulario, "¿Desea reemplazarlo?" & vbCrLf & vbCrLf & _
                                _Ruta_Archivo, "Este archivo ya existe", _
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


    Private Sub Btn_Descargar_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Descargar_Archivos.Click


        If CBool(List_Carpeta_FTP.SelectedItems.Count) Then

            Dim _Directorio_Destino = Fx_Seleccionar_Directorio()

            If Not String.IsNullOrEmpty(_Directorio_Destino) Then

                Dim _Lista As ListViewItem = New ListViewItem()
                'Sb_Trabajo_FTP(True)

                TxtLog.Text = String.Empty
                AddToLog("Decargando archivos", "Directorio: " & _Directorio_Destino)
                Dim _Bajados As Integer

                Sb_Trabajando(True)

                For Each _Fila As ListViewItem In List_Carpeta_FTP.SelectedItems

                    Dim _Archivo = _Fila.Text
                    Dim _Semilla = CInt(_Fila.SubItems.Item(3).Text)

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
            ToastNotification.Show(Me, "No hay archivos seleccionados", My.Resources.cross, _
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)


            '            MessageBoxEx.Show(Me, "No hay archivos seleccionados", "Descargar archvios", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


        Sb_Trabajando(False)

    End Sub

    Private Sub AddToLog(ByVal Accion As String, _
                         ByVal Descripcion As String)
        TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        If CBool(List_Carpeta_FTP.SelectedItems.Count) Then

            Dim _Mensaje As String
            If List_Carpeta_FTP.SelectedItems.Count = 1 Then
                _Mensaje = "este archivo"
            Else
                _Mensaje = "estos archivos"
            End If

            If MessageBoxEx.Show(Me, "Esta seguro de querer eliminar " & _Mensaje, "Eliminar", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then


                '        Sb_Trabajo_FTP(True)

                Dim _Lista As ListViewItem = New ListViewItem()
                TxtLog.Text = String.Empty
                AddToLog("Eliminando archivo(s)", "Archivos seleccionados " & List_Carpeta_FTP.SelectedItems.Count)
                Sb_Trabajando(True)

                For Each _Fila As ListViewItem In List_Carpeta_FTP.SelectedItems

                    Dim _Archivo = _Fila.Text
                    Dim _Semilla = CInt(_Fila.SubItems.Item(3).Text)

                    Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Negocios_04_Doc Where Semilla = " & _Semilla

                    If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                        AddToLog("Eliminado", "..\" & _Archivo)
                    Else
                        AddToLog("Problema", "No es posible elimar este archivo: " & _Archivo)
                    End If

                Next

                Sb_Llenat_Lista_ListView()
            End If
        Else

            Beep()
            ToastNotification.Show(Me, "No hay archivos seleccionados", My.Resources.cross, _
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

            ' MessageBoxEx.Show(Me, "No hay archivos seleccionados", "Descargar archvios", _
            '                   MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_Trabajando(False)

    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Llenat_Lista_ListView()
    End Sub

    Private Sub Frm_SolCredito_File_Attach_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Sub Sb_Trabajando(ByVal _Trabajando As Boolean)

        If _Trabajando Then
            Me.Enabled = False
        Else
            Me.Enabled = True
        End If

        Barra_Progreso.Visible = _Trabajando
        Me.Refresh()
    End Sub

End Class