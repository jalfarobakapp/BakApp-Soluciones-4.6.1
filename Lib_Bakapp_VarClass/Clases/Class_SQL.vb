Imports System.Data.SqlClient
Imports System.IO

Public Class Class_SQL

    Dim _SQL_String_conexion As String

    Dim _Cn As New SqlConnection

    Dim _Error As String

    Public ReadOnly Property Pro_Error() As String
        Get
            Return _Error
        End Get
    End Property

    Public Sub New(ByVal SQL_String_conexion As String)
        _SQL_String_conexion = SQL_String_conexion
    End Sub

    Function Ej_consulta_IDU(ByVal ConsultaSql As String, _
                            Optional ByVal MostrarError As Boolean = True) As Boolean
        Try
            'Abrimos la conexión con la base de datos

            Sb_Abrir_Conexion(_Cn)
            'System.Windows.Forms.Application.DoEvents()
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ConsultaSql
            cmd.CommandTimeout = 0
            cmd.Connection = _Cn

            cmd.ExecuteNonQuery()
            'Cerramos la conexión con la base de datos

            Sb_Cerrar_Conexion(_Cn)

            Application.DoEvents()
            Return True
        Catch ex As Exception
            _Error = ex.Message
            If MostrarError = True Then
                MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                       , MsgBoxStyle.Critical, "Modificar tabla")
                MsgBox(ex.Message)
            End If
            Return False
        End Try

    End Function

    Function Ej_Insertar_Trae_Identity(ByVal ConsultaSql As String, _
                                       ByRef _Identity As Integer, _
                                       Optional ByVal MostrarError As Boolean = True) As Boolean
        Try
            'Abrimos la conexión con la base de datos

            Sb_Abrir_Conexion(_Cn)
            'System.Windows.Forms.Application.DoEvents()
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ConsultaSql
            cmd.CommandTimeout = 0
            cmd.Connection = _Cn

            cmd.ExecuteNonQuery()
            'Cerramos la conexión con la base de datos

            cmd = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", _Cn)

            Dim dfd1 As SqlDataReader = cmd.ExecuteReader()
            While dfd1.Read()
                _Identity = dfd1("Identity")
            End While
            dfd1.Close()

            Sb_Cerrar_Conexion(_Cn)

            System.Windows.Forms.Application.DoEvents()
            Return True
        Catch ex As Exception
            _Error = ex.Message
            If MostrarError = True Then
                MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                       , MsgBoxStyle.Critical, "Modificar tabla")
                MsgBox(ex.Message)
            End If
            Return False
        End Try

    End Function

    Function Fx_Get_Tablas(ByVal _Consulta_sql As String, _
                           Optional ByVal _Mostrar_Error As Boolean = True) As DataTable

        Dim _Tbl As New DataTable

        Try
            Sb_Abrir_Conexion(_Cn)

            Dim _SqlDa As New SqlDataAdapter

            _SqlDa = New SqlDataAdapter(_Consulta_sql, _Cn)
            _SqlDa.SelectCommand.CommandTimeout = 8000

            _SqlDa.Fill(_Tbl)
            Sb_Cerrar_Conexion(_Cn)

            ' retornar el dataTable
            Return _Tbl

            ' errores
        Catch ex As Exception
            _Error = String.Empty
            If _Mostrar_Error Then MsgBox(ex.Message.ToString)
        End Try

        Return Nothing

    End Function

    Function Fx_Get_DataRow(ByVal _Consulta_sql As String, _
                            Optional ByVal _Mostrar_Error As Boolean = True) As DataRow

        Try

            Dim _Tbl As DataTable = Fx_Get_Tablas(_Consulta_sql, _Mostrar_Error)

            If CBool(_Tbl.Rows.Count) Then
                Return _Tbl.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function Fx_Get_DataSet(ByVal _Consulta_sql As String, _
                            ByVal _Ds As DataSet, _
                            ByVal _Nombre_Tabla As String) As DataSet

        Dim _Tbl As New DataTable

        Try
            Sb_Abrir_Conexion(_Cn)


            Dim daAuthors As New SqlDataAdapter(_Consulta_sql, _Cn)
            daAuthors.SelectCommand.CommandTimeout = 8000

            daAuthors.Fill(_Ds, _Nombre_Tabla)
            Sb_Cerrar_Conexion(_Cn)

            ' retornar el dataTable
            Return _Ds

            ' errores
        Catch ex As Exception
            _Error = String.Empty
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function

    Function Fx_Get_DataSet(ByVal Consulta_sql As String) As DataSet

        Try
            Sb_Abrir_Conexion(_Cn)

            Dim dt As DataTable = New DataTable()

            Dim _SqlDa As New SqlDataAdapter
            Dim _DataSt As New DataSet

            _SqlDa = New SqlDataAdapter(Consulta_sql, _Cn)
            _SqlDa.SelectCommand.CommandTimeout = 8000

            _SqlDa.MissingSchemaAction = MissingSchemaAction.AddWithKey
            _SqlDa.Fill(_DataSt)

            Sb_Cerrar_Conexion(_Cn)

            Return _DataSt
            ' errores
        Catch ex As Exception
            _Error = String.Empty
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function

    Function Fx_Extrae_Archivo_desde_BD(ByVal _Tabla As String, _
                                        ByVal _Campo As String, _
                                        ByVal _Condicion As String, _
                                        ByVal _Nom_Archivo As String, _
                                        ByVal _Dir_Temp As String) As Boolean

        Dim data As Byte() = Nothing

        Try
            ' Construimos los correspondientes objetos para
            ' conectarnos a la base de datos de SQL Server,
            ' utilizando la seguridad integrada de Windows NT.
            '
            Using cn As New SqlConnection
                Dim sCnn = _SQL_String_conexion
                cn.ConnectionString = sCnn
                Dim cmd As SqlCommand = cn.CreateCommand 'cnn.CreateCommand()
                ' Seleccionamos únicamente el campo que contiene
                ' los documentos, filtrándolo mediante su
                ' correspondiente campo identificador.
                '
                cmd.CommandText = "SELECT " & _Campo & " From " & _Tabla & " WHERE " & _Condicion
                ' Abrimos la conexión.
                cn.Open()
                ' Creamos un DataReader.
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                cmd.CommandTimeout = 8000
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
            If File.Exists(_Dir_Temp & "\" & _Nom_Archivo) Then File.Delete(_Dir_Temp & "\" & _Nom_Archivo)

            Using fs As New IO.FileStream(_Dir_Temp & "\" & _Nom_Archivo, IO.FileMode.CreateNew, IO.FileAccess.Write)

                ' Crea el escritor para la secuencia.
                Dim bw As New IO.BinaryWriter(fs)

                ' Escribir los datos en la secuencia.
                bw.Write(data)

            End Using


            'Sb_WriteBinaryFile(Me, _Dir_Temp & "\" & _Nom_Archivo, data)
            Return True
        Catch ex As Exception
            _Error = String.Empty
            MessageBox.Show(ex.Message)
        End Try

    End Function

    'System.Windows.Forms.Application.DoEvents()
    Sub Sb_Abrir_Conexion(ByVal _Cn As SqlConnection)

        _Error = String.Empty

        Try
            If _Cn.State = ConnectionState.Open Then
                ' Cerrar conexion
                _Cn.Close()
            End If

            _Cn.ConnectionString = _SQL_String_conexion
            _Cn.Open()
            'MsgBox(sCnn)

        Catch ex As SqlClient.SqlException 'Exception
            _Error = ex.Message
            MsgBox(ex.Message)
            'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
            '                ex.Message, "Conectar con la base", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub Sb_Cerrar_Conexion(ByVal _Cn As SqlConnection)
        Try
            If _Cn.State = ConnectionState.Open Then
                '' Cerrar conexion
                _Cn.Close()
            End If
        Catch ex As Exception
            _Error = String.Empty
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(ByVal Consulta_sql As String) As Boolean

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim _Fijar As Boolean
        Dim _Cn As New SqlConnection

        Try


            Sb_Abrir_Conexion(_Cn)
            myTrans = _Cn.BeginTransaction()


            Comando = New SqlClient.SqlCommand(Consulta_sql, _Cn)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            '**********************************'**********************************


            myTrans.Commit()
            Sb_Cerrar_Conexion(_Cn)

            _Fijar = True
            Return _Fijar

        Catch ex As Exception
            _Error = String.Empty
            'Consulta_sql = "ROLLBACK TRANSACTION"
            'Ej_consulta_IDU(Consulta_sql, cn1)
            MsgBox(ex.Message)
        Finally

            If Not _Fijar Then
                myTrans.Rollback()
            End If

        End Try


    End Function

    Function Fx_Trae_Dato(ByVal _Tabla As String, _
                         ByVal _Campo As String, _
                         Optional ByVal _Condicion As String = "", _
                         Optional ByVal _DevNumero As Boolean = False, _
                         Optional ByVal _MostrarError As Boolean = True, _
                         Optional ByVal _Dato_Default As String = "", _
                         Optional ByVal _Es_Boolean As Boolean = False) As String
        Try

            Dim _Valor
            Dim _Valor_Si_No_Encuentra As String

            If Not String.IsNullOrEmpty(_Condicion) Then
                _Condicion = vbCrLf & "And " & _Condicion
            End If

            If _DevNumero Then

            End If
            'Then Valor_Si_No_Encuentra = 0

            Dim _Sql As String = "SELECT TOP (1) " & _Campo & " AS CAMPO FROM " & _Tabla & vbCrLf & _
                                 "Where 1 > 0" & _Condicion


            Dim _Tbl As DataTable = Fx_Get_Tablas(_Sql)

            Dim cuenta As Long = _Tbl.Rows.Count

            If CBool(_Tbl.Rows.Count) Then

                _Valor = _Tbl.Rows(0).Item("CAMPO")

                If _Es_Boolean Then
                    _Valor = CBool(_Valor)
                Else
                    If _DevNumero Then
                        _Valor = NuloPorNro(_Valor, 0)
                    Else
                        _Valor = NuloPorNro(_Valor, "")
                    End If
                End If

                

            Else
                If _Es_Boolean Then
                    _Valor = False
                Else
                    If _DevNumero Then
                        _Valor = 0
                    Else
                        _Valor = ""
                    End If
                End If
            End If

            If String.IsNullOrEmpty(_Valor) Then
                _Valor = _Dato_Default
            End If

            Return _Valor


        Catch ex As Exception
            _Error = String.Empty
            If _MostrarError Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!!")
            Else
                Return ex.Message
            End If
        End Try

    End Function

    Function Fx_Cuenta_Registros(ByVal _Tabla As String, _
                                 Optional ByVal _Condicion As String = "") As Double

        If Not String.IsNullOrEmpty(_Condicion) Then
            _Condicion = vbCrLf & "And " & _Condicion
        End If

        Dim _Sql As String = "Select Count(*) As Cuenta From " & _Tabla & " Where 1 > 0 " & _Condicion

        Dim _RowTabpre As DataRow = Fx_Get_DataRow(_Sql)

        Dim _Cuenta As Double

        If (_RowTabpre Is Nothing) Then
            _Cuenta = 0
        Else
            _Cuenta = _RowTabpre.Item("Cuenta")
        End If

        Return _Cuenta

    End Function

    Function Fx_SqlDataReader(ByVal Consulta_sql As String) As SqlDataReader

        Sb_Abrir_Conexion(_Cn)
        Dim _Comando As SqlClient.SqlCommand

        _Comando = New SqlCommand(Consulta_sql, _Cn)
        Dim _Sql_DReader As SqlDataReader = _Comando.ExecuteReader()

        Return _Sql_DReader

    End Function

    Sub Sb_Eliminar_Tabla_De_Paso(ByVal _Tabla_Paso As String)

        Dim _ConsultaSql As String = "BEGIN TRY" & vbCrLf & _
                                     "DROP TABLE " & _Tabla_Paso & vbCrLf & _
                                     "End Try" & vbCrLf & _
                                     "BEGIN CATCH" & vbCrLf & _
                                     "END CATCH"

        Ej_consulta_IDU(_ConsultaSql, False)
        'Ej_consulta_IDU("Delete " & _Tabla_Paso, False)
    End Sub

    Enum Enum_Type
        _String
        _Double
        _Boolean
        _Date
        _ComboBox
    End Enum

    Sub Sb_Parametro_Informe_Sql(ByRef _Objeto As Object, _
                                 ByVal _Informe As String, _
                                 ByVal _Campo As String, _
                                 ByVal _Tipo As Enum_Type, _
                                 ByRef _Valor_x_defecto As String, _
                                 Optional ByVal _Actualizar As Boolean = False, _
                                 Optional ByVal _Grupo As String = "")

        Dim Consulta_sql As String
        Dim _Row_Fila As DataRow
        Dim _Valor

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Insertar_dato = True

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Tmp_Prm_Informes" & vbCrLf & _
                       "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _Informe & "' And Campo = '" & _Campo & "' And NombreEquipo = '" & _NombreEquipo & "'"
        _Row_Fila = Fx_Get_DataRow(Consulta_sql)

        If (_Row_Fila Is Nothing) Then

            Select Case _Tipo
                Case Enum_Type._String, Enum_Type._ComboBox
                    _Valor = _Valor_x_defecto
                Case Enum_Type._Double
                    _Valor = De_Txt_a_Num_01(_Valor_x_defecto)
                Case Enum_Type._Boolean
                    _Valor = CBool(_Valor_x_defecto)
                Case Enum_Type._Date
                    _Valor = CDate(_Valor_x_defecto)
            End Select

            If _Insertar_dato Then
                Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Tmp_Prm_Informes (Funcionario,Informe,Campo,Tipo,Valor,Grupo,NombreEquipo) VALUES" & Space(1) & _
                          "('" & FUNCIONARIO & "','" & _Informe & "','" & _Campo & "','" & Replace(_Tipo.ToString, "_", "") & "'," & _
                          "'" & _Valor & "','" & _Grupo & "','" & _NombreEquipo & "')"
                Ej_consulta_IDU(Consulta_sql)
            End If

        Else

            Select Case _Tipo
                Case Enum_Type._String, Enum_Type._ComboBox
                    _Valor = _Row_Fila.Item("Valor")
                Case Enum_Type._Double
                    _Valor = De_Txt_a_Num_01(_Row_Fila.Item("Valor"))
                Case Enum_Type._Boolean
                    _Valor = CBool(_Row_Fila.Item("Valor"))
                Case Enum_Type._Date
                    _Valor = CDate(_Row_Fila.Item("Valor"))
            End Select

            If _Actualizar Then
                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Tmp_Prm_Informes Set Valor = '" & _Valor_x_defecto & "'" & vbCrLf & _
                               "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _Informe & "' And Campo = '" & _Campo & "' And NombreEquipo = '" & _NombreEquipo & "'"
                Ej_consulta_IDU(Consulta_sql)
                'Return
            End If

        End If

        If Not (_Objeto Is Nothing) Then
            Select Case _Tipo
                Case Enum_Type._String
                    _Objeto.Text = _Valor
                Case Enum_Type._Double
                    _Objeto.Value = De_Txt_a_Num_01(_Valor)
                Case Enum_Type._Date
                    _Objeto.Value = CDate(_Valor)
                Case Enum_Type._Boolean
                    _Objeto.Checked = _Valor
                Case Enum_Type._ComboBox
                    _Objeto.SelectedValue = _Valor
            End Select
        End If

        _Valor_x_defecto = _Valor

    End Sub

    Sub Sb_Actualizar_Filtro_Tmp(ByVal _Tbl As DataTable, ByVal _Informe As String, ByVal _Filtro As String)

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")
        Dim Consulta_sql As String

        If Not _Tbl Is Nothing Then
            If _Tbl.Rows.Count Then

                Consulta_sql = "Delete From " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda" & vbCrLf &
                               "Where Funcionario = '" & FUNCIONARIO & "' And Informe = '" & _Informe & "'" & Space(1) &
                               "And Filtro = '" & _Filtro & "' And NombreEquipo = '" & _NombreEquipo & "'" & vbCrLf

                For Each _Fila As DataRow In _Tbl.Rows
                    Dim _Chk = CInt(_Fila.Item("Chk")) * -1
                    Dim _Codigo = _Fila.Item("Codigo")
                    Dim _Descripcion = _Fila.Item("Descripcion")
                    Consulta_sql += "INSERT INTO " & _Global_BaseBk & "Zw_Tmp_Filtros_Busqueda (Funcionario,Informe,Filtro,Chk,Codigo,Descripcion,NombreEquipo) VALUES" & Space(1) &
                                    "('" & FUNCIONARIO & "','" & _Informe & "','" & _Filtro & "'," & _Chk & ",'" & _Codigo & "','" & _Descripcion & "','" & _NombreEquipo & "')" & vbCrLf
                Next

                Ej_consulta_IDU(Consulta_sql)

            End If
        End If

    End Sub

    Function Fx_Existe_Tabla(ByVal _Tabla As String) As Boolean

        Dim _ConsultaSql As String

        _ConsultaSql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                       "WHERE TABLE_NAME = '" & _Tabla & "'"
        Dim _Tbl As DataTable = Fx_Get_Tablas(_ConsultaSql)

        Return _Tbl.Rows.Count

    End Function

    Function Fx_Exite_Campo(ByVal _Tabla As String, ByVal _Campo As String) As Boolean

        Dim _ConsultaSql As String

        _ConsultaSql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS" & vbCrLf &
                       "WHERE COLUMN_NAME = '" & _Campo & "' AND TABLE_NAME = '" & _Tabla & "'"
        Dim _Tbl As DataTable = Fx_Get_Tablas(_ConsultaSql)

        Return CBool(_Tbl.Rows.Count)

    End Function

    Function Fx_Agregar_Campo_En_Tabla(ByVal _Tabla As String,
                                       ByVal _Campo As String,
                                       ByVal _Tipo As String,
                                       ByVal _Largo As Integer,
                                       ByVal _Null As Boolean)

        Dim _Nulo As String

        If _Null Then
            _Nulo = "NULL"
        Else
            _Nulo = "Not Null"
        End If

        Dim _ConsultaSql = "ALTER TABLE dbo.doc_exa ADD column_b VARCHAR(20) NULL"

    End Function


    Function ActualizarGrillaUpInsDel(ByVal Consulta_Sql As String,
                                      ByVal Grilla As Object,
                                      Optional ByVal EsGrilla As Boolean = True)
        Dim Cn As SqlConnection

        Try

            'Abrimos la conexión con SQL
            Sb_Abrir_Conexion(Cn)

            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            Dim dt As DataTable

            If EsGrilla Then
                dt = DirectCast(Grilla.DataSource, DataTable)
            Else
                dt = Grilla
            End If

            ' Procedemos a actualizar la base de datos.
            Dim n As Integer = UpInsDelDatabase(dt, Consulta_Sql, Cn)
            Sb_Cerrar_Conexion(Cn)
            Return n
            'MessageBox.Show("Nº de registros afectados: " & CStr(n))
        Catch ex As Exception
            ' Se ha producido un error
            Sb_Cerrar_Conexion(Cn)
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Function UpInsDelDatabase(ByVal dt As DataTable,
                              ByVal sql As String,
                              ByVal cn As SqlConnection) As Integer

        ' Si el valor del objeto DataTable es Nothing, provocamos
        ' una excepción.
        '
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException()

        Try

            Dim da As New SqlDataAdapter(sql, cn)

            ' Creamos un objeto CommandBuilder para configurar los comandos
            ' apropiados del adaptador de datos. Se requiere que la tabla
            ' de la base de datos tenga establecida su correspondiente
            ' clave principal.
            '
            Dim cb As New SqlCommandBuilder(da)

            With da
                .InsertCommand = cb.GetInsertCommand()
                .DeleteCommand = cb.GetDeleteCommand()
                .UpdateCommand = cb.GetUpdateCommand()
            End With

            ' Procedemos a actualizar la base de datos, devolviendo
            ' el número de registros afectados.
            '
            Return da.Update(dt)

            'End Using

        Catch ex As Exception
            Throw
            MsgBox(ex.Message)
        End Try

    End Function

End Class
