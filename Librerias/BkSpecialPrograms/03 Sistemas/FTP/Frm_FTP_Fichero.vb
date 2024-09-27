Imports DevComponents.DotNetBar

Public Class Frm_FTP_Fichero

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _Fichero As String
    Private _Abrir_carpeta_despues_de_descargar As Boolean
    Private _Archivo_No_Se_Puede_Borrar As String
    Private _Permitir_Pisar_Archivos As Boolean

    Private _Id_Ftp As Integer
    Private _Tipo_Ftp As Cl_Ftp.eTipo_Ftp
    Private _RowProducto As DataRow

    Public Property Ftp As New Cl_Ftp
    Public Property ModoProducto As Boolean
    Public Property ModoConfiguracion As Boolean
    Public Property Codigo As String
    Public Property GestionRealizada As Boolean

    Public Sub New(_Id_Ftp As Integer, _Tipo_Ftp As Cl_Ftp.eTipo_Ftp)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me._Id_Ftp = _Id_Ftp
        Me._Tipo_Ftp = _Tipo_Ftp

        Sb_Color_Botones_Barra(Bar1)
        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_FTP_Fichero_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If ModoProducto Then

            Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR = '" & Codigo & "'"
            _RowProducto = _Sql.Fx_Get_DataRow(Consulta_sql)

            Me.Text = "FTP - " & _RowProducto.Item("KOPR").ToString.Trim & " - " & _RowProducto("NOKOPR").ToString.Trim

        End If

        Ftp.Fx_Llenar_Host(_Id_Ftp)

        With Ftp.Zw_Ftp_Conexiones
            Txt_Usuario.Text = .Usuario
            Txt_Clave.Text = .Clave
            Txt_Host.Text = .Host
            Txt_Puerto.Text = .Puerto
            Txt_Fichero.Text = .Fichero
        End With

        If ModoProducto Then
            Txt_Usuario.Enabled = False
            Txt_Clave.Enabled = False
            Txt_Host.Enabled = False
            Txt_Puerto.Enabled = False
            Txt_Host.PasswordChar = "*"
            Txt_Puerto.PasswordChar = "*"
            Txt_Usuario.PasswordChar = "*"
            Btn_Descargar_Archivos.Enabled = False
        End If

        Txt_Fichero.ReadOnly = True

        'Txt_Usuario.Text = "productos@bakapp.cl"
        'Txt_Clave.Text = "JvBa$O$=mQFo"
        'Txt_Host.Text = "ftp.bakapp.cl"
        'Txt_Puerto.Text = "21"

        '_Fichero = "ftp://ftp.bakapp.cl"
        'Txt_Fichero.Text = _Fichero

        _Fichero = Txt_Fichero.Text '"ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text & "/" & Txt_Fichero.Text

        If CBool(_Id_Ftp) Then

            If ModoProducto Then

                Txt_Fichero.Text = Ftp.Zw_Ftp_Conexiones.Fichero & Ftp.Zw_Ftp_Conexiones.Carpeta_Imagenes & "/" & Codigo.Trim

                If Not Ftp.Fx_Existe_Directorio2(Txt_Fichero.Text.Trim) Then
                    Ftp.Fx_Crear_Directorio(Txt_Fichero.Text.Trim)
                End If

            Else
                Txt_Fichero.Text = Ftp.Zw_Ftp_Conexiones.Fichero & "/" & Ftp.Zw_Ftp_Conexiones.Tipo
            End If

            'Txt_Fichero.Text = Ftp.Zw_Ftp_Conexiones.Fichero & "/" & Ftp.Zw_Ftp_Conexiones.Tipo

            Sb_Ver_FTP(True)

        End If

        Btn_Volver.Enabled = Not ModoProducto

    End Sub

    Private Sub Sb_Llenar_Lista(_Lista_Archivos)

        If IsNothing(_Lista_Archivos) Then
            Return
        End If

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

            If _Archivo = ".." And ModoProducto Then
                Continue For
            End If

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
                Case Else

                    Dim esCarpeta As Boolean = Ftp.Fx_Existe_Directorio(Txt_Fichero.Text & "/" & _Archivo).EsCorrecto

                    If esCarpeta Or _Archivo = ".." Then
                        _Imagen = 7
                    Else
                        _Imagen = 5
                    End If

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
            Dim _Dir = "ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text))

            If _Ftp.Fx_Verificar_Conexion_FTP(Me, Txt_Host.Text, Txt_Puerto.Text) Then

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
                                                         Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text), True, 100, True)
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

            Dim _SPath As String = Txt_Fichero.Text

            If String.IsNullOrEmpty(Txt_Fichero.Text) Then
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

                Dim _Dir = "ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text
                Dim _Carpeta = "SCN Negocios"

                Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text))

                _Ftp.Zw_Ftp_Conexiones = Ftp.Zw_Ftp_Conexiones

                If _Ftp.Fx_Verificar_Conexion_FTP(Me, Txt_Host.Text, Txt_Puerto.Text) Then

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

                        _Fichero = Txt_Fichero.Text

                        If _Ftp.Fx_Existe_Archivo(_Fichero & "/" & _Archivo) Then

                            If _Permitir_Pisar_Archivos Then
                                _Subir = _Ftp.Fx_Subir_Fichero(_Ruta_Local, _Fichero & "/" & _Archivo)
                            Else
                                AddToLog("Problema", "Archivo [" & _Archivo & "] ya existe, no se puede levantar archivos con el mismo nombre")
                            End If

                        Else
                            _Subir = _Ftp.Fx_Subir_Fichero(_Ruta_Local, _Fichero & "/" & _Archivo)
                        End If

                        If String.IsNullOrEmpty(_Subir) Then

                            'If ModoProducto Then

                            '    Fx_GrabarSQL()

                            '    'Dim _Url As String = Ftp.Zw_Ftp_Conexiones.Url_public & Ftp.Zw_Ftp_Conexiones.Carpeta_Imagenes & "/" & Codigo.Trim & "/" & _Archivo

                            '    'Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Imagenes (Codigo,Desde_URL,Direccion_Imagen,DesdeFtp,Id_FTP) Values " &
                            '    '               "('" & Codigo & "',1,'" & _Url & "',1," & Ftp.Zw_Ftp_Conexiones.Id & ")"
                            '    '_Sql.Ej_consulta_IDU(Consulta_sql)

                            'End If

                            AddToLog("Subir archivo", "Ok: " & _Archivo)
                        Else
                            AddToLog("Subir archivo", _Subir)
                        End If
                        _i += 1
                    Next

                    GestionRealizada = True

                End If

            End If

        End With

        Sb_Ver_FTP()
        Sb_Trabajo_FTP(False)

    End Sub

    Function Fx_GrabarSQL()

        For Each fila As ListViewItem In List_Carpeta_FTP.Items

            ' Acceder a los datos de cada fila
            Dim _Archivo As String = fila.Text

            Dim _Url As String = Ftp.Zw_Ftp_Conexiones.Url_public & Ftp.Zw_Ftp_Conexiones.Carpeta_Imagenes & "/" & Codigo.Trim & "/" & _Archivo

            Dim _Reg = CBool(_Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Prod_Imagenes", "Codigo = '" & Codigo & "' And Direccion_Imagen = '" & _Url & "'"))

            If Not _Reg Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Imagenes (Codigo,Desde_URL,Direccion_Imagen,DesdeFtp,Id_FTP) Values " &
                               "('" & Codigo & "',1,'" & _Url & "',1," & Ftp.Zw_Ftp_Conexiones.Id & ")"
                _Sql.Ej_consulta_IDU(Consulta_sql)

            End If

        Next

    End Function

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

            Dim _Dir = "ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text))

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
            Dim _Dir = "ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text))

            If _Ftp.Fx_Verificar_Conexion_FTP(Me, Txt_Host.Text, Txt_Puerto.Text) Then

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

            'Dim _Dir = "ftp://" & Txt_Host.Text & ":" & Txt_Puerto.Text
            Dim _Carpeta = "SCN Negocios"

            'Dim _Ftp As New Class_FTP(_Dir, Trim(Txt_Usuario.Text), Trim(Txt_Clave.Text))

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = Ftp.Fx_Probar_Conexion_FTP

            If Not _Mensaje.EsCorrecto Then
                Throw New Exception(_Mensaje.Mensaje)
            End If

            _Mensaje = Ftp.Fx_Existe_Directorio(Ftp.Zw_Ftp_Conexiones.Fichero)

            If Not _Mensaje.EsCorrecto Then
                Throw New Exception(_Mensaje.Mensaje)
            End If

            'Dim _Fichero = Replace(Txt_Fichero.Text, Codigo, "")

            _Mensaje = _Ftp.Fx_Obtener_Archivos_Directorio(Txt_Fichero.Text)

            If Not _Mensaje.EsCorrecto Then
                Throw New Exception(_Mensaje.Mensaje)
            End If

            Sb_Llenar_Lista(_Mensaje.Tag)
            If _Mostrar_Log Then AddToLog("Conexión Ftp", "Conexión establecida...")

            If ModoProducto Then
                Fx_GrabarSQL()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Problemas de conexión...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Sb_Trabajo_FTP(False)
            Me.Enabled = True
        End Try
    End Sub

    Private Sub Btn_ProbConexion_Click(sender As Object, e As EventArgs) Handles Btn_ProbConexion.Click

        With Ftp.Zw_Ftp_Conexiones

            .Usuario = Trim(Txt_Usuario.Text)
            .Clave = Trim(Txt_Clave.Text)
            .Host = Trim(Txt_Host.Text)
            .Puerto = Trim(Txt_Puerto.Text)
            .Fichero = Trim(Txt_Fichero.Text)

        End With

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim _Mensaje As LsValiciones.Mensajes = Ftp.Fx_Probar_Conexion_FTP

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

    End Sub

    Private Sub Btn_Grabar_Click(sender As Object, e As EventArgs) Handles Btn_Grabar.Click

        With Ftp.Zw_Ftp_Conexiones

            .Usuario = Trim(Txt_Usuario.Text)
            .Clave = Trim(Txt_Clave.Text)
            .Host = Trim(Txt_Host.Text)
            .Puerto = Trim(Txt_Puerto.Text)
            .Fichero = Trim(Txt_Fichero.Text)
            .Carpeta_Archivos = "Archivos"
            .Carpeta_Imagenes = "Imagenes"

        End With

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim _Mensaje As LsValiciones.Mensajes = Ftp.Fx_Probar_Conexion_FTP

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        If Not _Mensaje.EsCorrecto Then
            MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
            Return
        End If

        If Not Ftp.Fx_Existe_Directorio2(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _Tipo_Ftp.ToString) Then

            _Mensaje = Ftp.Fx_Crear_Directorio(Ftp.Zw_Ftp_Conexiones.Fichero & "/" & _Tipo_Ftp.ToString)

            If Not _Mensaje.EsCorrecto Then
                MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)
                Return
            End If

        End If

        'If _Tipo = Class_FTP.Tipo.Producto Then

        Ftp.Zw_Ftp_Conexiones.Tipo = _Tipo_Ftp.ToString

        'End If

        _Mensaje = Ftp.Fx_Grabar_Host()

        MessageBoxEx.Show(Me, _Mensaje.Mensaje, _Mensaje.Detalle, MessageBoxButtons.OK, _Mensaje.Icono)

        If _Mensaje.EsCorrecto Then
            Me.Close()
        End If

    End Sub

    Private Sub List_Carpeta_FTP_DoubleClick(sender As Object, e As EventArgs) Handles List_Carpeta_FTP.DoubleClick

        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try

            ' Obtener el nombre de la carpeta seleccionada en el control List_Carpeta_FTP
            Dim carpetaSeleccionada As String = List_Carpeta_FTP.FocusedItem.Text

            _Fichero = Txt_Fichero.Text & "/" & carpetaSeleccionada

            If carpetaSeleccionada = ".." Then

                Dim _Carpeta = Split(Txt_Fichero.Text, "/")
                Dim _CarpetaPadre As String = ""

                For i As Integer = 0 To _Carpeta.Length - 2
                    _CarpetaPadre &= _Carpeta(i) & "/"
                Next

                'Txt_Fichero.Text = _CarpetaPadre
                _Fichero = _CarpetaPadre

                Dim variable As String = _Fichero
                _Fichero = variable.Substring(0, variable.Length - 1)

            End If

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Ftp.Fx_Obtener_Archivos_Directorio(_Fichero)
            If Not _Mensaje.EsCorrecto Then
                'MessageBoxEx.Show(Me, _Mensaje.Mensaje, "Problemas de conexión...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            Txt_Fichero.Text = _Fichero

            Sb_Llenar_Lista(_Mensaje.Tag)

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Btn_Volver_Click(sender As Object, e As EventArgs) Handles Btn_Volver.Click

        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Try

            Dim _Carpeta = Split(Txt_Fichero.Text, "/")
            Dim _CarpetaPadre As String = ""

            For i As Integer = 0 To _Carpeta.Length - 2
                _CarpetaPadre &= _Carpeta(i) & "/"
            Next

            _Fichero = _CarpetaPadre

            Dim variable As String = _Fichero
            _Fichero = variable.Substring(0, variable.Length - 1)

            Dim _Mensaje As LsValiciones.Mensajes

            _Mensaje = _Ftp.Fx_Obtener_Archivos_Directorio(_Fichero)

            If Not _Mensaje.EsCorrecto Then
                Return
            End If

            Txt_Fichero.Text = _Fichero

            Sb_Llenar_Lista(_Mensaje.Tag)

        Catch ex As Exception
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class
