Imports DevComponents.DotNetBar

Public Class Frm_FTP_Fichero

    Public _Fichero As String
    Public _Abrir_carpeta_despues_de_descargar As Boolean
    Public _Archivo_No_Se_Puede_Borrar As String
    Public _Permitir_Pisar_Archivos As Boolean

    Private Sub Frm_FTP_Fichero_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Sb_Ver_FTP(True)
    End Sub

    Private Sub Sb_Llenat_Lista(_Lista_Archivos)

        ' With List_Carpeta_FTP
        List_Carpeta_FTP.Items.Clear()
        ' .Columns.Clear()
        ' .View = View.Details
        ' .GridLines = True
        ' .FullRowSelect = True
        ' ' añadir los nombres de columnas  
        ' .Columns.Add("Archivo", 55, HorizontalAlignment.Left)
        ' .Columns.Add("Zise", 65, HorizontalAlignment.Left)
        '.Columns.Add("Fecha creación", 90, HorizontalAlignment.Left)
        '' '.Columns.Add("HORARIOS", 140, HorizontalAlignment.Left)
        ' ' .Columns.Add("ALUMNOS", 80, HorizontalAlignment.Left)
        ' End With

        '0 = Excel
        '1 = Pdf
        '2 = Word
        '3 = Txt
        '4 = Jpg
        '5 = Otros
        '6 = Bmp

        For f As Integer = 0 To _Lista_Archivos.Count - 1
            ' recorrer las columnas  

            Dim _Fila = Split(_Lista_Archivos.item(f), ";")
            Dim _Archivo = _Fila(0)

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
                Case "JPG", "PNG"
                    _Imagen = 4
                Case "BMP"
                    _Imagen = 6
                Case Else
                    _Imagen = 5
            End Select

            Dim _s = _Fila(1)

            Dim _Size = Math.Round(Val(_Fila(1)) / 1000, 2) & " KB"
            Dim _Fecha = _Fila(2)
            Dim _NewFila As ListViewItem = New ListViewItem(_Archivo, _Imagen)
            _NewFila.SubItems.Add(_Size)
            _NewFila.SubItems.Add(_Fecha)
            List_Carpeta_FTP.Items.Add(_NewFila)

        Next

    End Sub

    Private Sub Btn_Descargar_Archivos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Descargar_Archivos.Click
        If CBool(List_Carpeta_FTP.SelectedItems.Count) Then
            Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

            If _Ftp.Fx_Verificar_Coneccion_FTP(Me, Txt_Ftp_Host.Text, Txt_Ftp_Puerto.Text) Then

                Dim _Directorio_Destino = Fx_Seleccionar_Directorio()

                If Not String.IsNullOrEmpty(_Directorio_Destino) Then

                    Dim _Lista As ListViewItem = New ListViewItem()
                    Sb_Trabajo_FTP(True)

                    TxtLog.Text = String.Empty
                    AddToLog("Decargando archivos", "Directorio: " & _Directorio_Destino)


                    For Each _Fila As ListViewItem In List_Carpeta_FTP.SelectedItems

                        Dim _Archivo = _Fila.Text
                        Dim _Descarga As String '= _Ftp.Fx_Descargar_Fichero(_Fichero & "/" & _Archivo, _Directorio_Destino)

                        Try
                            My.Computer.Network.DownloadFile(_Fichero & "/" & _Archivo, _Directorio_Destino & "\" & _Archivo,
                                                         Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text), True, 100, True)
                            AddToLog("Ok", "..\" & _Archivo)
                        Catch ex As Exception
                            'MessageBoxEx.Show(ex.Message, "Problema al descargar el archivo", _
                            '                  MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            _Descarga = ex.Message

                            Beep()
                            'ToastNotification.Show(Me, "ERROR DE DESCARGA", My.Resources.cross, _
                            '                        2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

                            Sb_Ver_FTP(False)
                            AddToLog("No se pudo descargar el archivo", _Fichero & "/" & _Archivo)
                            AddToLog("Problema", _Descarga)
                            Exit Sub
                        End Try

                    Next

                    AddToLog("Fin descarga", "...")
                    If _Abrir_carpeta_despues_de_descargar Then
                        Shell("explorer.exe " & _Directorio_Destino, AppWinStyle.NormalFocus)
                    End If

                End If
            End If
        Else

            Beep()
            ToastNotification.Show(Me, "No hay archivos seleccionados", My.Resources.cross,
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)


            '            MessageBoxEx.Show(Me, "No hay archivos seleccionados", "Descargar archvios", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Sb_Trabajo_FTP(False)
    End Sub



    Function Fx_Seleccionar_Directorio()

        Dim _Directorio As New FolderBrowserDialog

        With _Directorio

            .Reset() ' resetea

            ' leyenda
            .Description = "Seleccionar una carpeta "
            ' Path " Mis documentos "

            Dim _SPath As String = Txt_Directorio_Seleccionado.Text

            If String.IsNullOrEmpty(Txt_Directorio_Seleccionado.Text) Then
                _SPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

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

    Private Sub Btn_Subir_Archivos_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Subir_Archivos.Click
        Dim oFD As New OpenFileDialog
        With oFD
            .Title = "Seleccionar fichero"
            .Multiselect = True
            '.Filter = "Ficheros de texto (*.txt;*.ini)|*.txt;*.ini" & _
            '          "|Todos los ficheros (*.*)|*.*"
            '.FileName = Me.txtFichero.Text
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then



                Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
                Dim _Carpeta = "SCN Negocios"

                Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

                If _Ftp.Fx_Verificar_Coneccion_FTP(Me, Txt_Ftp_Host.Text, Txt_Ftp_Puerto.Text) Then

                    Sb_Trabajo_FTP(True)

                    TxtLog.Text = String.Empty
                    AddToLog("Subir archivo", "Archivos seleccionados " & .SafeFileNames.Length)
                    'fichero: Ruta local del fichero
                    'destino: Dirección FTP del destino del fichero. Ej: "ftp://ftp.BAKAPP.cl/Negocios/fichero.txt"
                    'dir: Dirección FTP del directorio donde se almacenará el fichero. Ej: "ftp://ftp.BAKAPP.cl/Negocios"
                    Dim _i = 0
                    Dim _Ruta_Archivos(.FileNames.Length - 1)
                    For Each _Ruta As String In .FileNames
                        _Ruta_Archivos(_i) = _Ruta
                        _i += 1
                    Next
                    _i = 0
                    For Each _Archivo As String In .SafeFileNames

                        Dim _Ruta_Local = _Ruta_Archivos(_i)

                        Dim _Subir As String
                        If _Ftp.Fx_Existe_Archivo(_Fichero & "/" & _Archivo) Then
                            If _Permitir_Pisar_Archivos Then
                                _Subir = _Ftp.Fx_Subir_Fichero(_Ruta_Local, _Fichero & "/" & _Archivo)
                            Else
                                AddToLog("Problema",
                                         "Archivo [" & _Archivo & "] ya existe, no se puede levantar archivos con el mismo nombre")
                            End If
                        Else

                            'My.Computer.Network.UploadFile(_Ruta_Local, _
                            '                               _Fichero & "/" & _Archivo, _
                            '                               Trim(Txt_Ftp_Usuario.Text), _
                            '                               Trim(Txt_Ftp_Contrasena.Text))

                            'Y para bajar un fichero del ftp, como vais a ver tampoco es complicado.
                            'My.Computer.Network.DownloadFile(_Fichero & "/" & _Archivo, _Ruta_Local, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text), True, 100, True)

                            _Subir = _Ftp.Fx_Subir_Fichero(_Ruta_Local, _Fichero & "/" & _Archivo)
                        End If

                        If String.IsNullOrEmpty(_Subir) Then
                            Sb_Ver_FTP()
                            AddToLog("Subir archivo", "Ok: " & _Archivo)
                        Else
                            AddToLog("Subir archivo", _Subir)
                        End If
                        _i += 1
                    Next

                End If
            End If
        End With

        Sb_Trabajo_FTP(False)

    End Sub

    Private Sub AddToLog(Accion As String,
                         Descripcion As String)
        TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()
        System.Windows.Forms.Application.DoEvents()
    End Sub


    Private Sub List_Carpeta_FTP_ItemSelectionChanged(sender As System.Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles List_Carpeta_FTP.ItemSelectionChanged

        If CBool(List_Carpeta_FTP.SelectedItems.Count) Then
            Btn_Eliminar_documento.Enabled = True
            If List_Carpeta_FTP.SelectedItems.Count = 1 Then
                Btn_Renombrar.Enabled = True
            End If
        Else
            Btn_Eliminar_documento.Enabled = False
            Btn_Renombrar.Enabled = False
        End If
    End Sub

    Private Sub Btn_Renombrar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Renombrar.Click

        If List_Carpeta_FTP.SelectedItems.Count = 1 Then
            Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

            Dim _Fila As ListViewItem = List_Carpeta_FTP.SelectedItems.Item(0)
            Dim _Archivo = Split(_Fila.Text, ".")

            Dim _OldName = _Archivo(0)
            Dim _Extencion = _Archivo(_Archivo.Length - 1)


            If UCase(_Archivo_No_Se_Puede_Borrar) = UCase(_OldName) Then
                MessageBoxEx.Show(Me, "Este Archivo no se puede editar, ya que está protegido por el sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim _Aceptado As Boolean

            Dim _NewName As String = _OldName

            _Aceptado = InputBox_Bk(Me, "Ingrese nuevo nombre de archivo" & vbCrLf &
                                    "Sin extención",
                                    "Renombrar archivo",
                                    _NewName,
                                    False,
                                    _Tipo_Mayus_Minus.Normal,
                                    0, True, _Tipo_Imagen.Texto, False)

            If _Aceptado Then

                _NewName = _NewName & "." & _Extencion
                _OldName = _OldName & "." & _Extencion

                If _NewName = _OldName Then Return

                Dim _Existe_Archivo As Boolean = _Ftp.Fx_Existe_Archivo(_Fichero & "/" & _NewName)

                If Not _Existe_Archivo Then
                    TxtLog.Text = String.Empty

                    Dim _Renombrar As String = _Ftp.Fx_Renombrar_Fichero_Ftp(_Fichero & "/" & _OldName, _NewName)

                    If String.IsNullOrEmpty(_Renombrar) Then
                        AddToLog("Renombrar archivos", "[" & _OldName & "] -> [" & _NewName & "]")
                    Else
                        AddToLog("Renombrar archivos", _Renombrar)
                    End If

                    Sb_Ver_FTP()
                Else

                    MessageBoxEx.Show(Me, "No se puede editar la descripción de este archivo" & vbCrLf &
                                      "Ya hay un archivo con este nombre en la lista" & vbCrLf & vbCrLf &
                                      _NewName, "Validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If



            End If
        End If

    End Sub

    Private Sub Btn_Eliminar_documento_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Eliminar_documento.Click

        If CBool(List_Carpeta_FTP.SelectedItems.Count) Then
            Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

            If _Ftp.Fx_Verificar_Coneccion_FTP(Me, Txt_Ftp_Host.Text, Txt_Ftp_Puerto.Text) Then

                Dim _Mensaje As String
                If List_Carpeta_FTP.SelectedItems.Count = 1 Then
                    Dim _Fila As ListViewItem = List_Carpeta_FTP.SelectedItems.Item(0)
                    Dim _Archivo = _Fila.Text

                    If UCase(_Archivo_No_Se_Puede_Borrar) = UCase(_Archivo) Then
                        MessageBoxEx.Show(Me, "Este Archivo no se puede eliminar, ya que está protegido por el sistema", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    _Mensaje = "este archivo"
                Else
                    _Mensaje = "estos archivos"
                End If

                If MessageBoxEx.Show(Me, "Esta seguro de querer eliminar " & _Mensaje, "Eliminar Archivo(s)",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Sb_Trabajo_FTP(True)

                    Dim _Lista As ListViewItem = New ListViewItem()
                    TxtLog.Text = String.Empty
                    AddToLog("Eliminando archivo(s)", "Archivos seleccionados " & List_Carpeta_FTP.SelectedItems.Count)


                    For Each _Fila As ListViewItem In List_Carpeta_FTP.SelectedItems

                        Dim _Archivo = _Fila.Text

                        If UCase(_Archivo_No_Se_Puede_Borrar) <> UCase(_Archivo) Then

                            Dim _Eliminar As String = _Ftp.Fx_Eliminar_Fichero_Ftp(_Fichero & "/" & _Archivo)
                            '_Ftp.Fx_Descargar_Fichero(_Fichero & "/" & _Archivo, _Directorio_Destino)

                            If String.IsNullOrEmpty(_Eliminar) Then
                                Sb_Ver_FTP()
                                AddToLog("Eliminado", "..\" & _Archivo)
                            Else
                                AddToLog("Problema", _Eliminar)
                            End If
                        Else
                            AddToLog("Problema", "El archivo [" & _Archivo & "], no se puede borrar, esta protegido por el sistema")
                        End If
                    Next


                End If
            End If
        Else
            MessageBoxEx.Show(Me, "No hay archivos seleccionados", "Descargar archvios", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Sb_Trabajo_FTP(False)

    End Sub


    Sub Sb_Trabajo_FTP(_Trabajando As Boolean)

        If _Trabajando Then

            CirProgres_FTP.Visible = True
            CirProgres_FTP.IsRunning = True
            System.Windows.Forms.Application.DoEvents()
            Grupo_Configuracion_Ftp.Enabled = False
            Grupo_Estatus.Enabled = False
            Grupo_Fichero.Enabled = False
            Bar1.Enabled = False
            Btn_Eliminar_documento.Enabled = False
            Btn_Renombrar.Enabled = False

        Else

            CirProgres_FTP.Visible = False
            CirProgres_FTP.IsRunning = False
            System.Windows.Forms.Application.DoEvents()
            Grupo_Configuracion_Ftp.Enabled = True
            Grupo_Estatus.Enabled = True
            Grupo_Fichero.Enabled = True
            Bar1.Enabled = True
            Btn_Eliminar_documento.Enabled = True
            Btn_Renombrar.Enabled = True

        End If
    End Sub


    Private Sub Btn_Refresh_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Refresh.Click
        AddToLog("Conexión Ftp", "Reconectando...")
        Sb_Ver_FTP(True)
    End Sub

    Sub Sb_Ver_FTP(Optional _Mostrar_Log As Boolean = False)

        Try
            Me.Enabled = False
            Sb_Trabajo_FTP(True)

            Dim _Dir = "ftp://" & Txt_Ftp_Host.Text & ":" & Txt_Ftp_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Ftp_Usuario.Text), Trim(Txt_Ftp_Contrasena.Text))

            If _Ftp.Fx_Verificar_Coneccion_FTP(Me, Txt_Ftp_Host.Text, Txt_Ftp_Puerto.Text) Then

                If _Ftp.Fx_Existe_Directorio(_Fichero) Then

                    Dim _Lista_Archivos = _Ftp.Fx_Obtener_Archivos_Directorio(_Fichero)
                    Sb_Llenat_Lista(_Lista_Archivos)
                    If _Mostrar_Log Then AddToLog("Conexión Ftp", "Conexión establecida...")

                End If
            End If
        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problemas de conexión...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Sb_Trabajo_FTP(False)
            Me.Enabled = True
        End Try
    End Sub

End Class
