Imports System.Data.SqlClient
Imports System.IO
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Frm_Rc_06_Aviso_Cliente

    Dim _Row_Producto As DataRow
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Id_Reclamo As Integer
    Dim _Cl_Reclamo As New Cl_Reclamo
    Dim _Grabar As Boolean
    Dim _Aceptado As Boolean
    Dim _Rechazado As Boolean
    Dim _Enviado As Boolean
    Dim _Accion As Cl_Reclamo.Enum_Accion
    Dim _Row_Email_Aviso As DataRow

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
    Public ReadOnly Property Pro_Aceptado As Boolean
        Get
            Return _Aceptado
        End Get
    End Property
    Public ReadOnly Property Pro_Rechazado As Boolean
        Get
            Return _Rechazado
        End Get
    End Property
    Public ReadOnly Property Pro_Enviado As Boolean
        Get
            Return _Enviado
        End Get
    End Property

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        If Global_Thema = Enum_Themas.Oscuro Then
            Btn_Archivos_Adjuntos.ForeColor = Color.White
            Btn_Enviar_Correo.ForeColor = Color.White
            Txt_Asunto.FocusHighlightEnabled = False
            Txt_Cc.FocusHighlightEnabled = False
            Txt_Para.FocusHighlightEnabled = False
            Txt_Respuesta.FocusHighlightEnabled = False
        End If

    End Sub

    Private Sub Frm_Rc_06_Aviso_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Id_Reclamo = _Cl_Reclamo.Id_Reclamo

        Try
            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso 
                            Where Estado = 'AVI' And Tipo_Reclamo = '" & _Cl_Reclamo.Pro_Row_Reclamo.Item("Tipo_Reclamo") & "' And Accion = 'Aceptar'"
            _Row_Email_Aviso = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Nombre_Correo = Trim(_Row_Email_Aviso.Item("Nombre_Correo"))

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo  = '" & _Nombre_Correo & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Txt_Asunto.Text = _Row_Correo.Item("Asunto")
            _Cl_Reclamo.Sb_Llenar_Variables_Mensaje(Txt_Asunto.Text)

            Txt_Para.Text = _Cl_Reclamo.Pro_Row_Reclamo.Item("Email_Contacto")
            _Cl_Reclamo.Sb_Llenar_Variables_Mensaje(Txt_Para.Text)

            Dim _CuerpoMensaje As String = _Row_Correo.Item("CuerpoMensaje")
            _Cl_Reclamo.Sb_Llenar_Variables_Mensaje(_CuerpoMensaje)

            Txt_Respuesta.Text = _CuerpoMensaje

        Catch ex As Exception
            MessageBoxEx.Show(Me, "Falta configuración de correo de aviso al cliente", "Falta correo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        Txt_Respuesta.ReadOnly = True

    End Sub

    Private Sub Btn_Archivos_Adjuntos_Click(sender As Object, e As EventArgs) Handles Btn_Archivos_Adjuntos.Click

        Dim Fm As New Frm_Rc_05_Validacion
        Fm.Pro_Cl_Reclamo = _Cl_Reclamo
        Fm.Btn_Resolucion.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub
    Private Sub Btn_Enviar_Correo_Click(sender As Object, e As EventArgs) Handles Btn_Enviar_Correo.Click

        If Fx_Tiene_Permiso(Me, "Rcl00006") Then

            If Fx_Se_Puede_Enviar_El_Correo() Then

                Dim _Nombre_Correo = Trim(_Row_Email_Aviso.Item("Nombre_Correo"))

                Dim _Error_Envio As String

                Dim Fm_Espera As New Frm_Form_Esperar
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show()

                If Fx_Enviar_Correo_Al_Cliente(_Nombre_Correo, Txt_Para.Text, Txt_Asunto.Text, Txt_Cc.Text, _Error_Envio) Then

                    Dim _Observacion As String = "Para: " & Txt_Para.Text & ",CC: " & Txt_Cc.Text & ", Asunto = '" & Txt_Asunto.Text & "'; " & vbCrLf &
                                              Txt_Respuesta.Text

                    _Observacion = Replace(_Observacion, "'", "''")

                    If _Cl_Reclamo.Estado = "AVI" Then

                        _Enviado = True

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo Set Estado = 'GES'" & vbCrLf &
                                       "Where Id_Reclamo = " & _Id_Reclamo & vbCrLf &
                                       "Insert Into " & _Global_BaseBk & "Zw_Reclamo_Estados (Id_Reclamo,Estado,CodFuncionario,Observacion) Values " &
                                       "(" & _Id_Reclamo & ",'AVI','" & FUNCIONARIO & "','" & _Observacion & "')"

                        If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then

                            _Cl_Reclamo.Sb_Cargar_Reclamo(_Id_Reclamo)
                            Me.Close()

                        End If

                    Else

                        MessageBoxEx.Show(Me, "Correo reenviado nuevamente al cliente", "Enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()

                    End If

                Else
                    MessageBoxEx.Show(Me, _Error_Envio, "Error al enviar el correo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Fm_Espera.Dispose()

            End If

        End If

    End Sub
    Private Function Fx_Se_Puede_Enviar_El_Correo() As Boolean

        If Not String.IsNullOrEmpty(Trim(Txt_Para.Text)) Then

            Dim _Email = Split(Txt_Para.Text, ";")

            For Each _Para As String In _Email
                If Not Fx_Validar_Email(_Para) Then
                    Beep()
                    ToastNotification.Show(Me, "VALIDACION DE EMAIL PARA" & vbCrLf &
                                           "Formato Ej: micorreo@correo.com",
                                           Imagenes_32x32.Images.Item("Warning.png"),
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                    Txt_Para.Focus()
                    Return False
                End If
            Next


        Else
            Beep()
            ToastNotification.Show(Me, "DEBE INDICAR EL MAIL DEL CLIENTE",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Para.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(Trim(Txt_Cc.Text)) Then

            Dim _Email = Split(Txt_Para.Text, ";")

            For Each _Cc As String In _Email
                If Not Fx_Validar_Email(Txt_Cc.Text) Then
                    Beep()
                    ToastNotification.Show(Me, "VALIDACION DE EMAIL CC." & vbCrLf &
                                           "Formato Ej: micorreo@correo.com",
                                           Imagenes_32x32.Images.Item("Warning.png"),
                                           2 * 1000, eToastGlowColor.Red,
                                           eToastPosition.MiddleCenter)
                    Txt_Cc.Focus()
                    Return False
                End If
            Next
        End If

        If String.IsNullOrEmpty(Txt_Asunto.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA EL ASUNTO",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Asunto.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Txt_Respuesta.Text) Then
            Beep()
            ToastNotification.Show(Me, "FALTA LA RESPUESTA",
                                   Imagenes_32x32.Images.Item("Warning.png"),
                                   2 * 1000, eToastGlowColor.Red,
                                   eToastPosition.MiddleCenter)
            Txt_Respuesta.Focus()
            Return False
        End If

        Return True

    End Function
    Function Fx_Enviar_Correo_Al_Cliente(_Nombre_Correo As String, _Para As String, _Asunto As String, _Cc As String, ByRef _Error As String) As Boolean

        Dim _Enviar = True
        Dim _Intentos As Integer

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Reclamo = " & _Id_Reclamo & " And Estado = 'VAL'"
        Dim _Tbl_Adjuntos As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim _Archivos_Adjuntos(0) As String
        Dim _i = 0

        If CBool(_Tbl_Adjuntos.Rows.Count) Then

            ReDim Preserve _Archivos_Adjuntos(_Tbl_Adjuntos.Rows.Count - 1)

            For Each _Archivo As DataRow In _Tbl_Adjuntos.Rows

                Dim _Id_Archivos = _Archivo.Item("Id_Archivos")
                Dim _Nombre_Archivo = _Archivo.Item("Nombre_Archivo")
                Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"
                Dim _Archivo_djunto As String = _Path & "\" & _Nombre_Archivo

                Try
                    System.IO.File.Delete(_Archivo_djunto)
                Catch ex As Exception
                End Try

                If Fx_Extrae_Archivo_desde_BD(_Id_Archivos, _Nombre_Archivo, _Path) Then
                    _Archivos_Adjuntos(_i) = _Archivo_djunto
                    _i += 1
                End If

            Next

        Else
            _Archivos_Adjuntos = Nothing
        End If

        Dim _Crea_Html As New Clase_Crear_Documento_Htm
        Dim _Ruta_Html As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Correos" & vbCrLf &
                        "Where Nombre_Correo = '" & _Nombre_Correo & "'"
        Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If _Row_Correo IsNot Nothing Then

            Dim _Remitente = Trim(_Row_Correo.Item("Remitente"))

            Dim _Host = _Row_Correo.Item("Host")
            Dim _Puerto = _Row_Correo.Item("Puerto")
            Dim _Contrasena = Trim(_Row_Correo.Item("Contrasena"))

            Dim _CuerpoMensaje = _Row_Correo.Item("CuerpoMensaje")
            _Cl_Reclamo.Sb_Llenar_Variables_Mensaje(_CuerpoMensaje)
            _CuerpoMensaje = Replace(_CuerpoMensaje, Chr(13), "<br/>")

            Dim _SSL = _Row_Correo.Item("SSL")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Envío de correo automático por BakApp…"
            End If

            Dim EnviarCorreo As New Frm_Correos_Conf

            Dim _Correo_Enviado As Boolean = EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                                         _Remitente,
                                                                         _Contrasena,
                                                                         _Para,
                                                                         _CC,
                                                                         _Asunto,
                                                                         _CuerpoMensaje,
                                                                         _Archivos_Adjuntos,
                                                                         _Puerto,
                                                                         _SSL,
                                                                         False)

            _Error = EnviarCorreo.Pro_Error
            EnviarCorreo.Dispose()

            Return _Correo_Enviado

        End If

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
            Dim _Ruta_Archivo = _Dir_Temp & "\" & _Nombre_Archivo

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
                File.Delete(_Ruta_Archivo)
            End If

            Using fs As New IO.FileStream(_Ruta_Archivo, IO.FileMode.CreateNew, IO.FileAccess.Write)

                ' Crea el escritor para la secuencia.
                Dim bw As New IO.BinaryWriter(fs)

                ' Escribir los datos en la secuencia.
                bw.Write(data)

            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function


End Class