Imports System.Data.SqlClient
Imports System.IO
Imports BkReclamos
Imports BkSpecialPrograms
Imports DevComponents.DotNetBar

Public Class Cl_Reclamo

    Dim Consulta_sql As String
    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

    Dim _Id_Reclamo As Integer
    Dim _Estado As String
    Dim _Sub_Estado As String
    Dim _Codigo_Accion As String
    Dim _Row_Entidad As DataRow
    Dim _Row_Contacto As DataRow
    Dim _Row_Reclamo As DataRow
    Dim _Row_Producto As DataRow
    Dim _Tbl_Estados As DataTable
    Dim _Tbl_Preguntas As DataTable
    Dim _Row_Resolucion As DataRow
    Dim _Path_Temporales As String

    Dim _Accion As Enum_Accion
    Enum Enum_Accion
        Nuevo
        Editar
        Revisar
    End Enum

    Dim _Estados As Enum_Estados
    Enum Enum_Estados
        Ingresado
        Revision_Espera
        Recopilacion_Informacion
        Resolucion
        Validacion
        Aviso_Cliente
        Gestionar_Reclamo
        Todos
    End Enum

    'Dim _Sub_Estados As Enum_Sub_Estados
    'Enum Enum_Sub_Estados
    '    a01_Recepcion_Mercaderia
    '    a02_Revision_Devolucion
    '    a03_Destruccion_Mercaderia
    '    a04_Reproceso_Mercaderia
    '    a05_Envio_Bodega_Venta
    '    a06_Recepcion_Acta_Cliente
    'End Enum

    Public Property Pro_Row_Entidad As DataRow
        Get
            Return _Row_Entidad
        End Get
        Set(value As DataRow)
            _Row_Entidad = value
        End Set
    End Property
    Public Property Pro_Row_Contacto As DataRow
        Get
            Return _Row_Contacto
        End Get
        Set(value As DataRow)
            _Row_Contacto = value
        End Set
    End Property
    Public Property Pro_Row_Reclamo As DataRow
        Get
            Return _Row_Reclamo
        End Get
        Set(value As DataRow)
            _Row_Reclamo = value
        End Set
    End Property
    Public Property Pro_Accion As Enum_Accion
        Get
            Return _Accion
        End Get
        Set(value As Enum_Accion)
            _Accion = value
        End Set
    End Property
    Public Property Pro_Row_Producto As DataRow
        Get
            Return _Row_Producto
        End Get
        Set(value As DataRow)
            _Row_Producto = value
        End Set
    End Property
    Public Property Pro_Tbl_Estados As DataTable
        Get
            Return _Tbl_Estados
        End Get
        Set(value As DataTable)
            _Tbl_Estados = value
        End Set
    End Property
    Public Property Pro_Tbl_Preguntas As DataTable
        Get
            Return _Tbl_Preguntas
        End Get
        Set(value As DataTable)
            _Tbl_Preguntas = value
        End Set
    End Property
    Public Property Pro_Row_Resolucion As DataRow
        Get
            Return _Row_Resolucion
        End Get
        Set(value As DataRow)
            _Row_Resolucion = value
        End Set
    End Property
    Public Property Id_Reclamo As Integer
        Get
            Return _Id_Reclamo
        End Get
        Set(value As Integer)
            _Id_Reclamo = value
        End Set
    End Property
    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = Trim(value)
        End Set
    End Property
    Public Property Sub_Estado As String
        Get
            Return _Sub_Estado
        End Get
        Set(value As String)
            _Sub_Estado = value
        End Set
    End Property
    Public ReadOnly Property Path_Temporales As String
        Get
            Return _Path_Temporales
        End Get
    End Property
    Public Property Estados As Enum_Estados
        Get
            Return _Estados
        End Get
        Set(value As Enum_Estados)
            _Estados = value
        End Set
    End Property
    Public Property Codigo_Accion As String
        Get
            Return _Codigo_Accion
        End Get
        Set(value As String)
            _Codigo_Accion = value
        End Set
    End Property

    'Public Property Sub_Estados As Enum_Sub_Estados
    '    Get
    '        Return _Sub_Estados
    '    End Get
    '    Set(value As Enum_Sub_Estados)
    '        _Sub_Estados = value
    '    End Set
    'End Property

    Public Sub New()

        Sb_Actualizar_Tabla_Estado()

        _Path_Temporales = AppPath() & "\Data\" & RutEmpresa & "\Tmp\Descargas_BakApp"

        If Not Directory.Exists(_Path_Temporales) Then
            System.IO.Directory.CreateDirectory(_Path_Temporales)
        End If

    End Sub

    Sub Sb_Actualizar_Tabla_Estado()

        Dim _Tabla = "SIS_RECLAMOS_ESTADO"
        Dim _DescripcionTabla = "Sistema de Reclamos Estados"

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
                        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','ING','INGRESADO',1)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
                "Values ('" & _Tabla & "','" & _DescripcionTabla & "','RVE','REVISION (ESPERA)',2)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','RCI','RECOPILACION INFORMACION',3)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','RSL','RESOLUCION',4)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','VAL','VALIDACION RECLAMO',5)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','AVI','AVISO CLIENTE',6)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','GES','GESTION CAMBIO Y DEV.',7)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','ACI','ALERTA CIERRE',8)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones(Tabla,DescripcionTabla,CodigoTabla,NombreTabla,Orden) " &
        "Values ('" & _Tabla & "','" & _DescripcionTabla & "','CIE','CERRADO',9)"
        _Sql.Ej_consulta_IDU(Consulta_sql, False)

    End Sub

    Sub Sb_Cargar_Reclamo(_Id_Reclamo As Integer)

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
        Dim Consulta_Sql As String

        Consulta_Sql = "Select Id_Reclamo,Empresa,Numero,
                        Estado,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_ESTADO' And CodigoTabla = Estado) As Estado_Reclamo,
                        Sub_Estado,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_SUBESTADO' And CodigoTabla = Sub_Estado) As Sub_Estado_Reclamo,
                        Sucursal,Isnull(RTRIM(LTRIM(REPLACE(SuIn.NOKOSU,'SUCURSAL',''))),'??') As Sucursal_Ingreso,
                        Codigo_Accion,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_ACCION' And CodigoTabla = Codigo_Accion) As Accion,
                        Fecha_Emision As Fecha,Fecha_Emision As Hora,
                        Tipo_Reclamo,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_TIPO' And CodigoTabla = Tipo_Reclamo) As Tipo_De_Reclamo,
                        Sub_Tipo_Reclamo,
                        (SELECT TOP 1 NombreTabla From " & _Global_BaseBk & "Zw_TablaDeCaracterizaciones 
                        Where Tabla = 'SIS_RECLAMOS_SUBTIPO' And CodigoTabla = Tipo_Reclamo And Padre_Tabla = 'SIS_RECLAMOS_TIPO') As Nombre_Sub_Tipo_De_Reclamo,
                        Rut_Contacto,Nombre_Contacto,Email_Contacto,Telefono_Contacto,
                        CodEntidad,SucEntidad,Rut_Entidad As Rut,Isnull(NOKOEN,'??') As Razon,
                        Cod_Vendedor,Isnull(NOKOFU,'??') As Vendedor,
                        Codigo,Descripcion,Fecha_Elab,Cantidad,
                        Descripcion_Reclamo,Suc_Elaboracion,Isnull(RTRIM(LTRIM(REPLACE(SuEl.NOKOSU,'SUCURSAL',''))),'??') As Sucursal_Elab,Observacion
                        From " & _Global_BaseBk & "Zw_Reclamo
                        Left Join MAEEN On KOEN = CodEntidad And SUEN = SucEntidad
                        Left Join TABSU SuEl On SuEl.EMPRESA = Empresa And SuEl.KOSU = Suc_Elaboracion
                        Left Join TABSU SuIn On SuIn.EMPRESA = Empresa And SuIn.KOSU = Sucursal
                        Left Join TABFU On KOFU = Cod_Vendedor 
                        Where Id_Reclamo = " & _Id_Reclamo &
                        vbCrLf & "
                        Select *,NOKOFU AS Nombre_Funcionario_Autoriza From " & _Global_BaseBk & "Zw_Reclamo_Estados
                        Left Join TABFU On KOFU = CodFuncionario
                        Where Id_Reclamo = " & _Id_Reclamo &
                        vbCrLf & "
                        Select * From " & _Global_BaseBk & "Zw_Reclamo_Resolucion 
                        Where Id_Reclamo = " & _Id_Reclamo

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)


        _Row_Reclamo = _Ds.Tables(0).Rows(0)
        _Tbl_Estados = _Ds.Tables(1)

        'If Not IsNothing(_Ds.Tables(2)) Then
        If CBool(_Ds.Tables(2).Rows.Count) Then
            _Row_Resolucion = _Ds.Tables(2).Rows(0)
        End If
        'End If

        Id_Reclamo = _Id_Reclamo
        Estado = Trim(_Row_Reclamo.Item("Estado"))
        Sub_Estado = Trim(_Row_Reclamo.Item("Sub_Estado"))
        Codigo_Accion = _Row_Reclamo.Item("Codigo_Accion")

    End Sub

    Sub Sb_Enviar_Correo(_Formulario As Form, _Estado As String, _Tipo_Reclamo As String, _Es_Aceptado As Boolean)

        Dim _Error As String
        Dim _Accion As String

        If _Es_Aceptado Then
            _Accion = "Aceptar"
        Else
            _Accion = "Rechazar"
        End If

        Dim _Nombre_Correo As String

        Try

            Dim _Suc_Elaboracion = _Row_Reclamo.Item("Suc_Elaboracion")

            Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Reclamo_Email_Aviso 
                            Where Estado = '" & _Estado & "' And Tipo_Reclamo = '" & _Tipo_Reclamo & "' " &
                                "And Accion = '" & _Accion & "' And Suc_Elaboracion = '" & _Suc_Elaboracion & "'"
            Dim _Row_Email_Aviso As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Nombre_Correo = Trim(_Row_Email_Aviso.Item("Nombre_Correo"))

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Correos Where Nombre_Correo  = '" & _Nombre_Correo & "'"
            Dim _Row_Correo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row_Correo) Then

                Throw New System.Exception("No existe correo vinculado a esta acción" & vbCrLf &
                                           "Debe configurar el correo de salida en la configuración del sistema de reclamos")

            Else

                Dim _Para = _Row_Email_Aviso.Item("Para")
                Dim _CC = String.Empty ' _Row_Correo.Item("CC")
                Dim _Asunto = _Row_Correo.Item("Asunto")

                '_Para = "jalfaro@bakapp.cl;jorgealfarogzlz@gmail.com;david.munoz@molineraheredia.com"

                If String.IsNullOrEmpty(_Para) Then
                    If Not InputBox_Bk(_Formulario, "Ingrese el destinatario", "Envío de correo de aviso", _Para, False,,, True, _Tipo_Imagen.Correo) Then
                        Return
                    End If
                End If

                If String.IsNullOrEmpty(_Asunto) Then
                    If Not InputBox_Bk(_Formulario, "Ingrese el asunto", "Envío de correo de aviso", _Asunto, False,,, True, _Tipo_Imagen.Correo) Then
                        Return
                    End If
                End If

                Dim Fm_Espera As New Frm_Form_Esperar
                Fm_Espera.Pro_Texto = "ENVIANDO EL CORREO, POR FAVOR ESPERE..."
                Fm_Espera.BarraCircular.IsRunning = True
                Fm_Espera.Show()

                _Formulario.Enabled = False

                Dim _Enviado As Boolean = Fx_Enviar_Correo(_Nombre_Correo, _Para, _Asunto, _CC, _Estado, _Error)

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Reclamo_Estados Set 
                            Mail_Enviado = " & CInt(_Enviado) & ", Mail_Fecha_Envio = Getdate(),Mail_Para = '" & _Para & "',Mail_CC = '" & _CC & "',Mail_Error = '" & _Error & "'
                            Where Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Estado & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)

                Fm_Espera.Dispose()

                _Formulario.Enabled = True

                _Error = Replace(_Error, "'", "''")

            End If

        Catch ex As Exception
            MessageBoxEx.Show(_Formulario, ex.Message & vbCrLf & vbCrLf & "El reclamo de todas forma fue grabado",
                              "Enviar correo (Problema)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    Function Fx_Enviar_Correo(_Nombre_Correo As String,
                              _Para As String,
                              _Asunto As String,
                              _Cc As String,
                              _Estado As String,
                              ByRef _Error As String) As Boolean

        Dim _Enviar = True

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Reclamo_Archivos Where Id_Reclamo = " & _Id_Reclamo & " And Estado = '" & _Estado & "'"
        Dim _Tbl_Adjuntos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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
            _CuerpoMensaje = Replace(_CuerpoMensaje, Chr(13), "<br/>")
            Sb_Llenar_Variables_Mensaje(_CuerpoMensaje)

            Dim _SSL = _Row_Correo.Item("SSL")

            If String.IsNullOrEmpty(_Asunto) Then
                _Asunto = "Envío de correo automático por BakApp…Sistema de Reclamos"
            End If
            Sb_Llenar_Variables_Mensaje(_Asunto)

            Dim EnviarCorreo As New Frm_Correos_Conf

            Dim _Correo_Enviado As Boolean = EnviarCorreo.Fx_Enviar_Mail(_Host,
                                                                         _Remitente,
                                                                         _Contrasena,
                                                                         _Para,
                                                                         _Cc,
                                                                         _Asunto,
                                                                         _CuerpoMensaje,
                                                                         _Archivos_Adjuntos,
                                                                         _Puerto,
                                                                         _SSL,
                                                                         False)

            _Error = EnviarCorreo.Pro_Error
            _Error = Replace(_Error, "'", "''")
            EnviarCorreo.Dispose()

            Return _Correo_Enviado

        End If

    End Function
    Private Function Fx_Extrae_Archivo_desde_BD(ByVal _Id As Integer,
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

    Sub Sb_Llenar_Variables_Mensaje(ByRef _Mensaje As String)

        _Mensaje = Replace(_Mensaje, "<RCL_Numero>", Fx_Parametro_Vs_Variable("<RCL_Numero>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Estado>", Fx_Parametro_Vs_Variable("<RCL_Estado>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Estado_Reclamo>", Fx_Parametro_Vs_Variable("<RCL_Estado_Reclamo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Tipo_Reclamo>", Fx_Parametro_Vs_Variable("<RCL_Tipo_Reclamo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Tipo_De_Reclamo>", Fx_Parametro_Vs_Variable("<RCL_Tipo_De_Reclamo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Nombre_Sub_Tipo_De_Reclamo>", Fx_Parametro_Vs_Variable("<RCL_Nombre_Sub_Tipo_De_Reclamo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Rut>", Fx_Parametro_Vs_Variable("<RCL_Rut>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Razon>", Fx_Parametro_Vs_Variable("<RCL_Razon>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Codigo>", Fx_Parametro_Vs_Variable("<RCL_Codigo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Descripcion>", Fx_Parametro_Vs_Variable("<RCL_Descripcion>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Cod_Vendedor>", Fx_Parametro_Vs_Variable("<Cod_Vendedor>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Vendedor>", Fx_Parametro_Vs_Variable("<RCL_Vendedor>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Descripcion_Reclamo>", Fx_Parametro_Vs_Variable("<RCL_Descripcion_Reclamo>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Respuesta_Cliente>", Fx_Parametro_Vs_Variable("<RCL_Respuesta_Cliente>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Cantidad,0>", Fx_Parametro_Vs_Variable("<RCL_Cantidad,0>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Cantidad,1>", Fx_Parametro_Vs_Variable("<RCL_Cantidad,1>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Cantidad,2>", Fx_Parametro_Vs_Variable("<RCL_Cantidad,2>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Fecha_Elab>", Fx_Parametro_Vs_Variable("<RCL_Fecha_Elab>"))
        _Mensaje = Replace(_Mensaje, "<RCL_Dias_Avance>", Fx_Parametro_Vs_Variable("<RCL_Dias_Avance>"))

    End Sub
    Private Function Fx_Parametro_Vs_Variable(_Parametro As String) As String

        Try

            Dim _Vl = Split(Replace(Replace(_Parametro, "<", ""), ">", ""), ",")

            Dim _Valor = Replace(_Vl(0), "RCL_", "")

            Select Case _Parametro
                Case "<RCL_Numero>",
                     "<RCL_Estado>",
                     "<RCL_Estado_Reclamo>",
                     "<RCL_Tipo>",
                     "<RCL_Tipo_De_Reclamo>",
                     "<RCL_Sub_Tipo_De_Reclamo>",
                     "<RCL_Nombre_Sub_Tipo_De_Reclamo>",
                     "<RCL_Rut>",
                     "<RCL_Razon>",
                     "<RCL_Codigo>",
                     "<RCL_Descripcion>",
                     "<RCL_Cod_Vendedor>",
                     "<RCL_Vendedor>",
                     "<RCL_Descripcion_Reclamo>"
                    Return NuloPorNro(_Row_Reclamo.Item(_Valor), "")

                Case "<RCL_Respuesta_Cliente>"

                    If Not IsNothing(_Row_Resolucion) Then
                        Return NuloPorNro(_Row_Resolucion.Item(_Valor), "")
                    End If

                Case "<RCL_Cantidad,0>"

                    Return FormatNumber(_Row_Reclamo.Item(_Valor), 0)

                Case "<RCL_Cantidad,1>"

                    Return FormatNumber(_Row_Reclamo.Item(_Valor), 1)

                Case "<RCL_Cantidad,2>"

                    Return FormatNumber(_Row_Reclamo.Item(_Valor), 2)

                Case "<RCL_Fecha_Elab>"

                    Return FormatDateTime(_Row_Reclamo.Item(_Valor), DateFormat.ShortDate)

                Case "<RCL_Motivo_Rechazo>"

                    Dim _Motivo_Rechazo = _Row_Resolucion.Item("Motivo_Rechazo")
                    Return _Motivo_Rechazo

                Case "<RCL_Dias_Avance>"

                    Dim _Fecha_Hoy As Date = FechaDelServidor()
                    Dim _Fecha_Rcl As Date = _Row_Reclamo.Item("Fecha")
                    Dim _Dias_Avance = DateDiff(DateInterval.Day, _Fecha_Rcl, _Fecha_Hoy)

                    If _Dias_Avance = 0 Then _Dias_Avance = 1

                    Return _Dias_Avance

            End Select

        Catch ex As Exception
            MsgBox("Error", vbOK, ex.Message)
        End Try

    End Function

End Class
