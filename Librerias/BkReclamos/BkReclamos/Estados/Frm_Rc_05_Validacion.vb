Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports BkSpecialPrograms


Public Class Frm_Rc_05_Validacion

    Dim _Row_Producto As DataRow
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean

    Public Property Pro_Cl_Reclamo As Cl_Reclamo
        Get
            Return _Cl_Reclamo
        End Get
        Set(value As Cl_Reclamo)
            _Cl_Reclamo = value
        End Set
    End Property
    Public ReadOnly Property Pro_Grabar As Boolean
        Get
            Return _Grabar
        End Get
    End Property

    Dim _Arreglo_Archivos(0) As String


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla_Archivos, 18, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, True, True, True)

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Refresh.ForeColor = Color.White
            Btn_Resolucion.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Adjuntar_Archivos_X_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Id_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Id_Reclamo")

        Sb_InsertarBotonenGrilla(Grilla_Archivos, "BtnImagen", "TD", "TD", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Grilla()

        AddHandler Grilla_Archivos.MouseDown, AddressOf Sb_Grilla_Detalle_MouseDown
        AddHandler Grilla_Archivos.RowPostPaint, AddressOf Sb_Grilla_Detalle_RowPostPaint

        Select Case _Cl_Reclamo.Estado
            Case "VAL", "AVI"

                Dim _Tipo_Reclamo = _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo")
                Dim _Tiene_Permiso As Boolean = Fx_Tiene_Permiso(Me, "RclVal" & _Tipo_Reclamo,, False)

                Btn_Mnu_Eliminar_Archivo.Enabled = _Tiene_Permiso
                Btn_Subir_Archivos.Enabled = _Tiene_Permiso

            Case Else
                Btn_Mnu_Eliminar_Archivo.Enabled = False
                Btn_Subir_Archivos.Enabled = False
        End Select

    End Sub

    Private Sub Sb_Actualizar_Grilla()

        Consulta_sql = "Select Id_Archivos,Id_Reclamo,Nombre_Archivo,DATALENGTH(Archivo) As Tamano,Cast('' As Varchar(50)) As Size" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Reclamo_Archivos" & vbCrLf &
                       "Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'VAL'"

        Dim _TblArchivos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        With Grilla_Archivos

            .DataSource = _TblArchivos

            OcultarEncabezadoGrilla(Grilla_Archivos, True)

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").HeaderText = "TD"
            .Columns("BtnImagen").Width = 50

            .Columns("Nombre_Archivo").Visible = True
            .Columns("Nombre_Archivo").HeaderText = "Nombre del archivo"
            .Columns("Nombre_Archivo").Width = 430

            .Columns("Size").Visible = True
            .Columns("Size").HeaderText = "Size"
            .Columns("Size").Width = 80
            .Columns("Size").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            '.Columns("Fecha").Visible = True
            '.Columns("Fecha").HeaderText = "Fecha creación"
            '.Columns("Fecha").Width = 100
            '.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With

        For Each _Fila As DataGridViewRow In Grilla_Archivos.Rows

            Dim _Nombre_Archivo As String = _Fila.Cells("Nombre_Archivo").Value
            Dim _Tamano = _Fila.Cells("Tamano").Value
            Dim _Size As String

            Dim _Extencion = Split(_Nombre_Archivo, ".")
            Dim _Ext As String
            Dim _Imagen As Integer

            Dim _Extn = Split(_Nombre_Archivo, ".")
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

            If _Tamano < 1048576 Then
                _Tamano = _Tamano / 1024
                _Size = FormatNumber(_Tamano, 2) & " KB" 'Math.Round(Val(_Fila.Item("Size")) / 1000, 2) & " KB"
            Else
                _Tamano = _Tamano / 1024 / 1024
                _Size = FormatNumber(_Tamano, 2) & " MB"
            End If

            _Fila.Cells("Size").Value = _Size
            _Fila.Cells("BtnImagen").Value = Imagenes.Images.Item(_Imagen)

        Next

    End Sub

    Private Sub Btn_Subir_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Subir_Archivos.Click


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
                                                "Archivo: " & _Archivo & " " & _Tamano,
                                                "Archivo supera el máximo permitido", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> Windows.Forms.DialogResult.Yes Then

                                'AddToLog("Subir archivo", "Problema: " & _Archivo)
                                'AddToLog("Subir archivo", "Archivo muy pesado: " & _Tamano)
                                _Subir_Archivo = False
                            End If

                            'tamanoFicheros = tamanoFicheros / 1024 / 1024
                            'lInfoAdjuntos.Text = "Tamaño: " & 
                            'FormatNumber(tamanoFicheros, 1) + " MB" 
                        End If

                        'Dim _Id_Reclamo = _Row_Producto.Item("Id_Reclamo")
                        Dim _Nombre_Archivo = _InfoArchivo.Name


                        Dim _Id_Archivos As Integer = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Reclamo_Archivos", "Id_Archivos",
                                                 "Id_Reclamo = " & _Id_Reclamo & " And Nombre_Archivo = '" & _Nombre_Archivo & "' And Estado = 'VAL'",
                                                 True)

                        If CBool(_Id_Archivos) Then
                            If MessageBoxEx.Show(Me, "Archivo: " & _Nombre_Archivo & vbCrLf &
                                                     "¿Desea reemplazarlo?", "El archivo ya existe",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then

                                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Archivos = " & _Id_Archivos
                                _Sql.Ej_consulta_IDU(Consulta_sql)
                            Else
                                _Subir_Archivo = False
                            End If
                        End If

                        If _Subir_Archivo Then
                            Fx_Grabar_Observacion_Adjunta(_Ruta, _Nombre_Archivo)
                        End If

                        _i += 1
                    Next

                End If

            End With

        Catch ex As Exception
            MessageBoxEx.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Sb_Actualizar_Grilla()
            Sb_Trabajando(False)
        End Try

    End Sub

    Private Sub Sb_Grilla_Detalle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual)
                End If
            End With
        End If
    End Sub

    Function Fx_Grabar_Observacion_Adjunta(ByVal _Ruta As String,
                                           ByVal _Nombre_Archivo As String) As Boolean

        'Dim _Codigo = _Row_Producto.Item("KOPR")
        Dim blob As Byte()
        Try
            blob = IO.File.ReadAllBytes(_Ruta)

            Dim cn As New SqlConnection
            Dim sCnn = Cadena_ConexionSQL_Server
            cn.ConnectionString = sCnn

            Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
            ' Crear la consulta T-SQL para insertar un nuevo registro.
            cmd.CommandText = "INSERT INTO " & _Global_BaseBk &
                              "Zw_Reclamo_Archivos (Id_Reclamo,Nombre_Archivo,Archivo,Estado) VALUES " &
                              "(@Id_Reclamo,@Nombre_Archivo,@Archivo,@Estado)"

            ' Añadir el único parámetro de entrada existente.
            cmd.Parameters.AddWithValue("@Id_Reclamo", _Id_Reclamo)
            cmd.Parameters.AddWithValue("@Nombre_Archivo", _Nombre_Archivo)
            cmd.Parameters.AddWithValue("@Estado", "VAL")

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

        Catch ex As Exception

            ' MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

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

    Private Sub Btn_Descargar_Archivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Descargar_Archivos.Click

        If CBool(Grilla_Archivos.SelectedRows.Count) Then

            Dim _Directorio_Destino = Fx_Seleccionar_Directorio()

            If Not String.IsNullOrEmpty(_Directorio_Destino) Then

                Dim _Bajados As Integer

                Sb_Trabajando(True)

                For Each _Fila As DataGridViewRow In Grilla_Archivos.SelectedRows

                    Dim _Nombre_Archivo = _Fila.Cells("Nombre_Archivo").Value
                    Dim _Id_Archivos = _Fila.Cells("Id_Archivos").Value

                    If Fx_Extrae_Archivo_desde_BD(_Id_Archivos, _Nombre_Archivo, _Directorio_Destino) Then
                        _Bajados += 1
                    Else
                        'AddToLog("No se pudo descargar el archivo", _Archivo)
                    End If

                Next

                If CBool(_Bajados) Then
                    Shell("explorer.exe " & _Directorio_Destino, AppWinStyle.NormalFocus)
                End If
            End If

        Else

            Beep()
            ToastNotification.Show(Me, "No hay archivos seleccionados", Imagenes.Images.Item("cross.png"),
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)

        End If

        Sb_Trabajando(False)

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
                cmd.CommandText = "SELECT Archivo From " & _Global_BaseBk & "Zw_Reclamo_Archivos WHERE Id_Archivos = " & _Id
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

    Private Sub Btn_Mnu_Eliminar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Eliminar_Archivo.Click

        For Each _Fila As DataGridViewRow In Grilla_Archivos.SelectedRows

            Dim _Nombre_Archivo = _Fila.Cells("Nombre_Archivo").Value
            Dim _Id = _Fila.Cells("Id_Archivos").Value

            Consulta_sql += "Delete " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Archivos = " & _Id & vbCrLf

        Next

        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
        Sb_Actualizar_Grilla()

    End Sub

    Private Sub Btn_Mnu_Descargar_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Descargar_Archivo.Click

        Dim _Fila As DataGridViewRow = Grilla_Archivos.Rows(Grilla_Archivos.CurrentRow.Index)
        Dim _i = _Arreglo_Archivos.Length - 1

        Dim _Nombre_Archivo = _Fila.Cells("Nombre_Archivo").Value
        Dim _Id_Archivos = _Fila.Cells("Id_Archivos").Value
        Dim _Path = _Cl_Reclamo.Path_Temporales
        Dim _Archivo As String = _Path & "\" & _Nombre_Archivo

        Try
            System.IO.File.Delete(_Archivo)
        Catch ex As Exception
        End Try

        If Fx_Extrae_Archivo_desde_BD(_Id_Archivos, _Nombre_Archivo, _Path) Then
            Me.Enabled = False
            Try
                System.Diagnostics.Process.Start(_Archivo)
                _Arreglo_Archivos(_i) = _Path & "\" & _Nombre_Archivo
                ReDim Preserve _Arreglo_Archivos(_i + 1)
            Catch ex As Exception
                MessageBoxEx.Show(ex.Message, "Problema al abrir el archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Shell("explorer.exe " & _Path, AppWinStyle.NormalFocus)
            Finally
                Me.Enabled = True
            End Try
        End If

    End Sub

    Private Sub Grilla_Archivos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla_Archivos.CellDoubleClick
        Call Btn_Mnu_Descargar_Archivo_Click(Nothing, Nothing)
    End Sub

    Private Sub Frm_Adjuntar_Archivos_X_Productos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyValue = Keys.F5 Then
            Sb_Actualizar_Grilla()
        End If
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Sb_Actualizar_Grilla()
    End Sub

    Private Sub Frm_Adjuntar_Archivos_X_Productos_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        For Each _Archivos In _Arreglo_Archivos
            Try
                System.IO.File.Delete(_Archivos)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Btn_Resolucion_Click(sender As Object, e As EventArgs) Handles Btn_Resolucion.Click

        Dim _Aceptado As Boolean
        Dim _Rechazado As Boolean

        'Dim _Accion As Cl_Reclamo.Enum_Accion

        'If _Cl_Reclamo.Estado = "VAL" Then
        '_Accion = Cl_Reclamo.Enum_Accion.Nuevo
        'Else
        '_Accion = Cl_Reclamo.Enum_Accion.Editar
        'End If

        Dim Fm As New Frm_Rc_04_Resolucion(Cl_Reclamo.Enum_Accion.Editar)
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Aprobar.Visible = True
        Fm.Btn_Rechazar.Visible = True
        Fm.Btn_Ver_Motivo_Rechazo.Visible = False
        Fm.ShowDialog(Me)
        _Aceptado = Fm.Pro_Aceptado
        _Rechazado = Fm.Pro_Rechazado
        Fm.Dispose()

        If _Aceptado Or _Rechazado Then
            _Grabar = True
            Me.Close()
        End If

    End Sub

End Class