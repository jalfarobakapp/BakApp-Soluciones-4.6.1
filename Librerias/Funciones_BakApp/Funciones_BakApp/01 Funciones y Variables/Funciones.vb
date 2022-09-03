Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Imports System.Net
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports System.Globalization
Imports System.Text.RegularExpressions


Public Module Funciones

    Public cn1 As New SqlConnection
    Public cn2 As New SqlConnection
    Public cn3 As New SqlConnection

    Public Cm As SqlCommand

    Public tb As DataTable
    Public tb2 As DataTable
    Public tb3 As DataTable

    Public ds As New DataSet
    Public ds2 As New DataSet

    Public da As SqlDataAdapter

    '---------------------------- ACCESS

    Public cn1Access As OleDbConnection
    Public dbDataTable As Data.DataTable
    Public dbDataSet As Data.DataSet
    Public dbD As OleDbDataAdapter

    Public comand As OleDb.OleDbCommand


    Public PickingActivo As Boolean
    Public _MTS_Lista_activo As Boolean


    Public Function Hora_Grab_fx(ByVal _EsAjuste As Boolean) As String

        Dim _HH_sistem As Date

        _HH_sistem = FechaDelServidor()

        Dim _HH, _MM, _SS As Double

        _HH = _HH_sistem.Hour
        _MM = _HH_sistem.Minute
        _SS = _HH_sistem.Second

        If _EsAjuste Then
            _HH = 23 : _MM = 59 : _SS = 59
        End If

        Dim _HoraGrab As String = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _HoraGrab

    End Function

    Function Fx_Genera_Licencia_BakApp(ByVal _RutEmpresa As String, _
                                        ByVal _FechaCaduca As Date, _
                                        ByVal _CantLicencias As Integer, _
                                        ByVal _Palabra_X As String) As String()

        Dim _Llave1, _Llave2, _Llave3, _Llave4 As String

        _Llave1 = Encripta_md5(Trim(_RutEmpresa) & _Palabra_X)
        _Llave2 = Encripta_md5(Format(_FechaCaduca, "yyyyMMdd"))
        _Llave3 = Encripta_md5(_CantLicencias & _Palabra_X)
        _Llave4 = Encripta_md5(_Llave1 & _Llave2 & _Llave3 & _Palabra_X)

        Dim Licencia(3) As String

        Licencia(0) = _Llave1
        Licencia(1) = _Llave2
        Licencia(2) = _Llave3
        Licencia(3) = _Llave4

        Return Licencia

    End Function


    Sub Sbb_Corrector_ortografico(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CType(sender, TextBox).Text.Length > 0 Then
            Dim _WordApp As New Word.Application
            _WordApp.Visible = False
            Dim _doc As Word.Document = _WordApp.Documents.Add
            Dim _range As Word.Range
            _range = _doc.Range
            _range.Text = CType(sender, TextBox).Text
            _doc.Activate()
            _doc.CheckSpelling()
            Dim _chars() As Char = {CType(vbCr, Char), CType(vbLf, Char)}
            CType(sender, TextBox).Text = _doc.Range().Text.Trim(_chars)
            _doc.Close(SaveChanges:=False)
            _WordApp.Quit()
        End If

    End Sub


    Function ActualizaLaGrilla(ByVal Grilla As DataGridView, _
                               ByVal tabla As DataTable, _
                               ByVal ConsultaSQL As String, _
                               ByVal cn As SqlConnection, _
                               Optional ByVal Autoalineacion As Boolean = True, _
                               Optional ByVal MostrarMensaje As Boolean = False)

        Ejecutar_consulta_SQL(ConsultaSQL, cn)

        tb = New DataTable
        da.Fill(tb) ' ---  aca se carga la tabla de la base access completa

        If tb.Rows.Count > 0 Then
            Grilla.DataSource = tb
            If Autoalineacion = True Then _
                Grilla.AutoSizeColumnsMode = _
                DataGridViewAutoSizeColumnsMode.AllCells
        Else
            Grilla.DataSource = Nothing
            If MostrarMensaje = True Then
                MsgBox("No existen datos que mostrar", MsgBoxStyle.Exclamation, "Buscar registros")
            End If
        End If

        Grilla.Refresh()

    End Function

    Sub Formato_Generico_Grilla(ByVal _Grilla As DataGridView, _
                                ByVal _Alto As Integer, _
                                ByVal _Fuente As Font, _
                                ByVal _Colores As Color, _
                                ByVal _ScrollBars As ScrollBars, _
                                ByVal _VerEncFila As Boolean, _
                                ByVal _SeleccionarTodaLaFila As Boolean, _
                                ByVal _Multiselect As Boolean)

        With _Grilla

            .RowHeadersVisible = _VerEncFila
            .RowTemplate.Height = _Alto

            .DefaultCellStyle.Font = _Fuente 'Font("Tahoma", 7)
            .AlternatingRowsDefaultCellStyle.Font = _Fuente 'Font("Tahoma", 7)

            '.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Blue
            '.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Yellow

            .DefaultCellStyle.SelectionForeColor = Color.White
            '.DefaultCellStyle.SelectionBackColor = Color.Orange
            .AlternatingRowsDefaultCellStyle.BackColor = _Colores

            .RowTemplate.Resizable = DataGridViewTriState.False
            .ScrollBars = _ScrollBars

            If _SeleccionarTodaLaFila Then
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Else
                .SelectionMode = DataGridViewSelectionMode.CellSelect
            End If

            .MultiSelect = _Multiselect

        End With

    End Sub

    Public Function Sb_Enviar_Doc_Por_Mail(ByVal _IdMaeedo_Doc As String, _
                                      ByVal _Email_Para As String, _
                                      ByVal _Encabezado_Cuerpo As String, _
                                      ByVal _Pie_Cuerpo As String, _
                                      ByVal _Form_Origen As Object) As Boolean


        Dim Crea_Htm As New Clase_Crear_Documento_Htm
        Dim _Ruta As String = AppPath() & "\Data\" & RutEmpresa & "\Tmp"

        Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _IdMaeedo_Doc
        Dim _Enc_Documento As DataTable = get_Tablas(Consulta_sql, cn1)

        If CBool(_Enc_Documento.Rows.Count) Then

            Dim _Nudo As String = _Enc_Documento.Rows(0).Item("NUDO")
            Dim _Tido As String = _Enc_Documento.Rows(0).Item("TIDO")
            Dim _TipoDoc As String = Trim(trae_dato(tb, cn1, "NOTIDO", "TABTIDO", "TIDO = '" & _Tido & "'"))
            Dim _Estado As String = _Enc_Documento.Rows(0).Item("ESDO")

            If _Estado = "N" Then
                MessageBoxEx.Show(_Form_Origen, "Documento NULO, no se puede adjuntar", _
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            If Crea_Htm.Fx_Crear_Documento_Htm(_IdMaeedo_Doc, _Ruta) Then

                ' Acento en Html
                'á = &aacute
                'é = &eacute
                'í = &iacute
                'ó = &oacute
                'ú = &uacute
                'ñ = &ntilde
                'Ñ = &Ntilde

                Dim fic As String = _Ruta & "\Documento.Htm"
                Dim _Cuerpo_Html = LeeArchivo(fic)

                Dim Envio_Occ_Mail As New Class_Outlook

                _Cuerpo_Html = Replace(_Cuerpo_Html, "&aacute", "á")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&eacute", "é")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&iacute", "í")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&oacute", "ó")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&uacute", "ú")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&ntilde", "ñ")
                _Cuerpo_Html = Replace(_Cuerpo_Html, "&Ntilde", "Ñ")

                Dim _Para As String = _Email_Para '"jalfaro@bakapp.cl"
                Dim _Adjunto As String = _Ruta & "\Documento.Htm"
                Dim _Cuerpo As String = _Encabezado_Cuerpo & vbCrLf & vbCrLf & _Cuerpo_Html & vbCrLf & vbCrLf & _Pie_Cuerpo
                Dim _Asunto As String = _TipoDoc & " Nro " & _Nudo

                Envio_Occ_Mail.Sb_Crear_Correo_Outlook(_Para, _Adjunto, _Asunto, _Cuerpo, True)
            End If
            Return True
        Else
            MessageBoxEx.Show(_Form_Origen, "No se encontro el documento", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function



    Function UpdateDatabase(ByVal dt As DataTable, _
                            ByVal sql As String, _
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

    Public Sub Conectar_SQL(ByVal Servidor As String, _
                                 ByVal BaseDatos As String, _
                                 ByVal Usuario As String, _
                                 ByVal Clave As String, _
                                 ByVal cn As SqlConnection, _
                                 Optional ByVal Cadena_conec As String = "")

        ' La cadena de conexión
        Dim sCnn As String
        If Cadena_conec = "" Then
            sCnn = "data source = " & Servidor & "; initial catalog = " & BaseDatos & _
                                 "; user id = " & Usuario & "; password = " & Clave
        Else
            sCnn = Cadena_conec
        End If

        Try
            If cn.State = ConnectionState.Open Then
                ' Cerrar conexion
                cn.Close()
            End If
            cn.ConnectionString = sCnn
            cn.Open()

            MsgBox("Conexión exitosa", MsgBoxStyle.Information, "Conexión")

        Catch ex As SqlClient.SqlException 'Exception
            MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
                            ex.Message, "Conectar con la base", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ConectarAccess(ByVal nombreBaseDatos As String, _
                           ByVal cnAccess As OleDbConnection)

        Try

            Dim DirectorioTemp As String

            If LeeArchivo(AppPath(True) & "Ini.txt") = "" Then
                DirectorioTemp = AppPath(True) & "Data\" & nombreBaseDatos
            Else
                DirectorioTemp = "C:\BakApp\Data\" & nombreBaseDatos
            End If


            cnAccess = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
                                              DirectorioTemp)
            cnAccess.Open()
        Catch e As Exception
            MessageBox.Show("Error al crear la conexión:" & vbCrLf & e.Message)
            'Exit Function
        End Try

    End Function



    Function ValidarExistenciaDeCodigo(ByVal Codigo As String, _
                                       ByVal Campo As String, _
                                       Optional ByVal MostrarMensaje As Boolean = True)
        If trae_dato(tb, cn1, Campo, "MAEPR", Campo & " = '" & Codigo & "'") <> "" Then

            If MostrarMensaje = True Then
                MessageBoxEx.Show("¡Código de producto ya existe!", "Código principal", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Txt.Focus()
            End If
            Return True
        Else
            Return False
        End If
    End Function





    'consultas insert,delete,update
    Public Function Ej_consulta_IDUaccess(ByVal consulta As String, _
                                            Optional ByVal NombreBaseDeDatos As String = "Tmptools.mdb", _
                                            Optional ByVal Ruta As String = "") As Boolean
        Dim objCon As New ClaseConectaAccess
        Try
            objCon.abrirConexion(NombreBaseDeDatos, Ruta)
            objCon.consultaAccion(consulta)
            objCon.cerrarConexion()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Public Function getIp() As String

        Dim valorIp As String

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) _
                    i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

        Return valorIp


        Exit Function
        'Dim ip As System.Net.IPHostEntry
        'ip = Dns.GetHostEntry(My.Computer.Name)

        'Dim valorIp As String

        'valorIp = ""

        'For Each valor As IPAddress In ip.AddressList
        'valorIp = valor.ToString()
        'Next

        'getIp = valorIp

    End Function




    Public Sub Ejecutar_consulta_SQLaccess(ByVal SQL As String, _
                                           Optional ByVal NombreBaseDeDatos As String = "Tmptools.mdb", _
                                           Optional ByVal Ruta As String = "")

        Dim objCon As New ClaseConectaAccess

        Try
            'dbD = New OleDbDataAdapter(SQL, Ruta)
            objCon.ConsultaSelectAccess(SQL, NombreBaseDeDatos, Ruta)
        Catch ex As Exception
            MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
                            ex.Message, "Conectar con la base", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function Ejecutar_consulta_SQL(ByVal SQL As String, _
                                     ByVal Cnn As SqlConnection, _
                                     Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                     Optional ByVal CadenaLocal As String = "", Optional ByVal MostrarError As Boolean = True) As Boolean
        Try
            SQL_ServerClass.AbrirConexion_SQLServer(Cnn, BaseConexion, CadenaLocal, MostrarError)
            'System.Windows.Forms.Application.DoEvents()
            da = New SqlDataAdapter(SQL, Cnn)
            da.SelectCommand.CommandTimeout = 8000
            SQL_ServerClass.CerrarConexion(Cnn)
            Return True
        Catch ex As Exception
            If MostrarError = True Then
                MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
                                ex.Message, "Conectar con la base", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Try

    End Function

    Public Function Ej_consulta_IDU(ByVal ConsultaSql As String, _
                                    ByVal cn As SqlConnection, _
                                    Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                    Optional ByVal CadenaLocal As String = "", Optional ByVal MostrarError As Boolean = True) As Boolean
        Try
            'Abrimos la conexión con la base de datos
            SQL_ServerClass.AbrirConexion_SQLServer(cn, BaseConexion, CadenaLocal)
            'System.Windows.Forms.Application.DoEvents()
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ConsultaSql
            cmd.CommandTimeout = 0
            cmd.Connection = cn

            cmd.ExecuteNonQuery()
            'Cerramos la conexión con la base de datos
            SQL_ServerClass.CerrarConexion(cn)
            System.Windows.Forms.Application.DoEvents()
            Return True
        Catch ex As Exception
            If MostrarError = True Then
                MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                       , MsgBoxStyle.Critical, "Modificar tabla")
                MsgBox(ex.Message)
            End If
            Return False
        End Try

    End Function

    

    Sub ActualizarPrecioBkRandom(ByVal Lista As String)

        Consulta_sql = "INSERT INTO Zw_ListaPreProducto (Lista, Codigo, Formula, Redondear, Precio, Margen, DsctoMax)" & vbCrLf & _
                           "SELECT KOLT,KOPR,'',1,0,MG01UD,DTMA01UD FROM TABPRE" & vbCrLf & _
                           "WHERE KOLT = '" & Lista & "'" & vbCrLf & _
                           "And KOPR Not In (Select Codigo From Zw_ListaPreProducto Where Lista = '" & Lista & "')"
        Ej_consulta_IDU(Consulta_sql, cn1)

    End Sub



    Function numero_(ByVal Num As String, ByVal d As Integer) As String
        Dim i As Integer
        Dim nro As String
        nro = Len(RTrim$(Num))

        For i = nro To d - 1
            Num = "0" & Num
        Next

        Return RTrim$(Num)
    End Function

    Function CargarGrillasDeSeleccion(ByVal Tabla As String, _
                                     ByVal SQL As String) As String
        Try


            'Ejecutar_consulta_SQL(SQL, cn1)
            'tb2 = New DataTable

            tb2 = get_Tablas(Consulta_sql, cn1)
            'da.Fill(tb2)

            Dim dr As DataRow
            Dim Codigo As String
            Dim Descripcion As String


            If tb2.Rows.Count > 0 Then

                Consulta_sql = "DELETE * FROM TmpTablasDeSeleccion WHERE Tabla = '" & Tabla & "'"
                Ej_consulta_IDUaccess(Consulta_sql)

                For i = 0 To tb2.Rows.Count - 1
                    dr = tb2.Rows(i)

                    Codigo = dr.Item(0).ToString()
                    Descripcion = dr.Item(1).ToString()

                    Consulta_sql = "INSERT INTO TmpTablasDeSeleccion (Tabla,Codigo,Descripcion) Values" & vbCrLf & _
                                   "('" & Tabla & "','" & Codigo & "','" & Descripcion & "')"
                    Ej_consulta_IDUaccess(Consulta_sql)

                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function


    Sub ShowContextMenu(ByVal cm As ButtonItem)
        Dim pt As Point = Control.MousePosition
        cm.Popup(pt)
    End Sub


    Function Cuenta_registros(ByVal Tabla As String, _
                              Optional ByVal condicion As String = "", _
                              Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal) As String
        Try

            Dim Como As String = " WHERE "

            If condicion = String.Empty Then Como = String.Empty
            Dim SQL As String = "SELECT COUNT(*) as TOTAL FROM " & Tabla & Como & condicion
            Ejecutar_consulta_SQL(SQL, cn1, BaseConexion)
            tb = New DataTable
            da.Fill(tb)
            Dim dr As DataRow = tb.Rows(tb.Rows.Count - 1)
            Dim total As Long
            total = dr("TOTAL").ToString
            Return total
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try

    End Function

    Function QuitaEspacios_ParaCodigos(ByVal s As String, _
                           ByVal lon As Integer) As String

        Dim arr(lon - 1) As Char '= s.ToCharArray
        arr = s.ToCharArray
        Dim Contador = arr.Length - 1
        Dim _palabra As String

        ' arr = s.ToCharArray

        Do While (Contador >= 0)

            Dim _Asc As Integer
            Dim _Letra As String = arr(Contador)
            _Asc = Asc(_Letra)

            If _Asc <> 160 Then
                If Contador = arr.Length - 1 Then
                    _palabra = s
                Else
                    _palabra = Mid(s, 1, Contador)
                End If

                Exit Do
            End If

            If Contador = 0 Then

            End If

            Contador -= 1
        Loop

        Return _palabra
        ' Return corre
    End Function


    Function Cuenta_registrosAccess(ByVal Tabla As String, _
                                    ByVal Campo As String, _
                                    Optional ByVal condicion As String = "", _
                                    Optional ByVal NombreBaseDeDatos As String = "Tmptools.mdb") As String
        Try

            Dim Como As String = " WHERE "

            If condicion = "" Then Como = ""
            Dim SQL As String = "SELECT * FROM " & Tabla & Como & condicion
            Ejecutar_consulta_SQLaccess(SQL, NombreBaseDeDatos)

            tb = New DataTable
            dbD.Fill(tb)

            Return tb.Rows.Count

            'If tb.Rows.Count > 0 Then
            'Dim dr As DataRow = tb.Rows(tb.Rows.Count - 1)
            'Dim total As Long
            'total = dr(0).ToString
            'Return total
            'Else
            'Return 0
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try

    End Function



    Function CadenaConexionSQL(ByVal NombreConexion As String, _
                               ByVal DsConexion As DataSet)

        Dim Cadena = "data source = #SV#; initial catalog = #BD#; user id = #US#; password = #PW#"

        Dim SV, PT, BD, US, PW As String

        Dim Tbl As New DataTable
        Tbl = DsConexion.Tables(0)

        Dim Reg As Integer = 0
        Dim Contador As Integer

        For Each Fila As DataRow In Tbl.Rows

            If Fila.Item("NombreConexion").ToString = NombreConexion Then
                SV = Fila.Item("Servidor").ToString 'trae_datoAccess(tb, "Servidor", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                PT = Fila.Item("Puerto").ToString 'trae_datoAccess(tb, "Puerto", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                US = Fila.Item("Usuario").ToString 'trae_datoAccess(tb, "Usuario", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                PW = Fila.Item("Clave").ToString 'trae_datoAccess(tb, "Clave", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")
                BD = Fila.Item("BaseDeDatos").ToString 'trae_datoAccess(tb, "BaseDeDatos", "Tmp_Conexiones", "NombreConexion = '" & Rut & "'", , "TmpConexionBD.mdb")

                If Trim(PT) <> "" Then
                    SV = Trim(SV & "," & PT)
                End If

                Cadena = Replace(Cadena, "#SV#", SV)
                Cadena = Replace(Cadena, "#BD#", BD)
                Cadena = Replace(Cadena, "#US#", US)
                Cadena = Replace(Cadena, "#PW#", PW)
            End If

        Next

        Return Cadena

    End Function

    Function FechaDelServidor() As Date
        SQL_ServerClass.AbrirConexion_SQLServer(cn3)
        Dim cmd = New SqlCommand("select getdate()", cn3)
        Dim Fecha_Servidor As Date = cmd.ExecuteScalar()
        SQL_ServerClass.CerrarConexion(cn3)
        Return Fecha_Servidor
    End Function


    Function Fx_Trae_Permiso_Bk(ByVal _CodUsuario As String, _
                                ByVal _CodPremiso As String) As DataTable

        Dim _Tbl As DataTable

        Consulta_sql = "Select * From " & _Global_BaseBk & "ZW_PermisosVsUsuarios" & vbCrLf & _
                       "Where CodPermiso = '" & _CodPremiso & "' And CodUsuario = '" & _CodUsuario & "'"

        _Tbl = get_Tablas(Consulta_sql, cn1)

        Return _Tbl

    End Function

    Function MensajeSinPermiso(ByVal Nro As String, _
                               Optional ByVal _CodUsuario As String = "", _
                               Optional ByVal _NomUsuario As String = "")

        Dim _Mensaje As String
        Dim NombrePermiso As String = trae_dato(tb, cn1, "DescripcionPermiso", _
                                                _Global_BaseBk & "ZW_Permisos", "CodPermiso = '" & Nro & "'")

        If String.IsNullOrEmpty(Trim(_CodUsuario)) Then
            _Mensaje = "Usted no posee permisos para realizar esta acción, permiso: " & Nro
        Else
            _Mensaje = _NomUsuario & vbCrLf & _
                       "No posee permisos para realizar esta acción, permiso: " & Nro
        End If

        If String.IsNullOrEmpty(Trim(_CodUsuario)) Then
            _Mensaje = "Usted no posee permisos para realiza esta acción"
        Else
            _Mensaje = _NomUsuario & vbCrLf & _
                       "No posee permisos para realiza esta acción"
        End If

        Dim info As New TaskDialogInfo("Permisos de usuarios", _
                                       eTaskDialogIcon.ShieldStop, _
                                       "PERMISO: " & Nro, _
                                       _Mensaje & vbCrLf & _
                                       "Para ejecutar esta acción se necesita el permiso indicado. " & vbCrLf & _
                                       "Descripción: " & vbCrLf & vbCrLf & NombrePermiso & vbCrLf, eTaskDialogButton.Ok _
                                       , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing) ', "BakApp", My.Resources.BakApp)
        Dim result As eTaskDialogResult = TaskDialog.Show(info)

        '        MsgBox("Usted no posee permisos para realiza esta acción" & vbCrLf & "Permiso Nro: " & Nro & " - " & NombrePermiso, MsgBoxStyle.Critical, "Permiso denegado")


    End Function

    Enum _Tipo_Boton
        Imagen
        Boton
        Texto
        Combo_Box
    End Enum

    Function InsertarBotonenGrilla(ByVal Grilla As Object, _
                                  ByVal NombreBoton As String, _
                                  ByVal TextoBoton As String, _
                                  ByVal NombreColumna As String, _
                                  ByVal Nrocolumna As Integer, _
                                  Optional ByVal TipoBoton As _Tipo_Boton = _Tipo_Boton.Boton)

        Dim column As Object

        Select Case TipoBoton
            Case _Tipo_Boton.Boton

                column = New DataGridViewButtonColumn()

                With column
                    .Name = NombreBoton
                    .HeaderText = NombreColumna
                    .Text = TextoBoton
                    .UseColumnTextForButtonValue = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Imagen

                column = New DataGridViewImageColumn

                With column
                    .Name = NombreBoton
                    .HeaderText = NombreColumna
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Texto

                column = New DataGridViewTextBoxColumn

                With column
                    .Name = NombreBoton
                    .HeaderText = NombreColumna
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

            Case _Tipo_Boton.Combo_Box

                column = New DataGridViewComboBoxColumn

                With column
                    .Name = NombreBoton
                    .HeaderText = NombreColumna
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

        End Select

        Grilla.Columns.Insert(Nrocolumna, column) 'Está en la segunda fila

    End Function


    Function listado_seleccionado(ByVal CheckedListBox As CheckedListBox, _
                                  Optional ByVal cr As String = "'") As String

        'listado_seleccionado
        'trae_codigo_busqueda
        Dim sb As New System.Text.StringBuilder
        Dim i As Integer = 0

        For Each item In CheckedListBox.CheckedItems

            sb.Append(cr & trae_codigo_busqueda(item) & cr)
            If i < CheckedListBox.CheckedItems.Count - 1 Then sb.Append(",")
            i += 1
        Next
        If sb.ToString = "" Then
            Return "''"
        Else
            'MsgBox(sb.ToString)
            Return sb.ToString
        End If



    End Function

    Function trae_codigo_busqueda(ByVal descripcion) As String
        Dim codigo As String
        Select Case descripcion
            Case "Guia venta" : codigo = "GDV"
            Case "Factura venta nacional" : codigo = "FCV"
            Case "Factura exportación" : codigo = "FEV"
            Case "Boleta venta" : codigo = "BLV"
            Case "Nota credito venta" : codigo = "NCV"
            Case "Guia compra" : codigo = "GRC"
            Case "Factura compra nacional" : codigo = "FCC"
                'Case "Factura exportación" : codigo = "FEV"
                'Case "Boleta venta" : codigo = "BLV"
            Case "Nota credito compra" : codigo = "NCC"
            Case "Nota de venta" : codigo = "NVV"
            Case "Cotizaci" : codigo = "COV"


        End Select
        Return codigo
    End Function

    Public Function Ruta_conexion(ByVal Ruta As String) As String
        Try

            Dim texto As String
            Dim sr As New System.IO.StreamReader(Ruta)
            texto = sr.ReadToEnd()
            sr.Close()
            Return texto
        Catch ex As Exception

        End Try
    End Function

    Public Function LeeArchivo(ByVal Ruta As String) As String
        Dim texto As String
        Dim sr As New System.IO.StreamReader(Ruta)
        texto = sr.ReadToEnd()
        sr.Close()
        Return texto
    End Function

    Public Function Chequear_todo(ByVal CheckedListBox As CheckedListBox, _
                           ByVal estado As Boolean)

        'Dim sb As New System.Text.StringBuilder
        'Dim i As Integer = 0

        For i = 0 To CheckedListBox.Items.Count - 1 'SelectedIndices
            CheckedListBox.SetItemChecked(i, estado)
        Next
    End Function

    Public Function Encripta_md5(ByVal TextoAEncriptar As String) As String
        Dim vlo_MD5 As New MD5CryptoServiceProvider
        Dim vlby_Byte(), vlby_Hash() As Byte
        Dim vls_TextoEncriptado As String = ""

        'Convierte texto a encriptar a Bytes
        vlby_Byte = System.Text.Encoding.UTF8.GetBytes(TextoAEncriptar)

        'Aplicación del algoritmo hash
        vlby_Hash = vlo_MD5.ComputeHash(vlby_Byte)

        'Convierte la matriz de byte en una cadena
        For Each vlby_Aux As Byte In vlby_Hash
            vls_TextoEncriptado += vlby_Aux.ToString("x2")
        Next

        'Retorno de función
        Return vls_TextoEncriptado
    End Function

    Public Function trae_dato(ByVal tb As DataTable, _
                              ByVal Cnn As SqlConnection, _
                              ByVal CAMPO As String, _
                              ByVal TABLA As String, _
                              Optional ByVal condicion As String = "", _
                              Optional ByVal DevNumero As Boolean = False, _
                              Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                              Optional ByVal CadenaLocal As String = "", _
                              Optional ByVal MostrarError As Boolean = True, _
                              Optional ByVal Valor_Si_No_Encuentra As String = "") As String
        Try

            If condicion <> "" Then
                condicion = " WHERE " & condicion
            End If

            If DevNumero Then Valor_Si_No_Encuentra = 0

            SQL_ServerClass.AbrirConexion_SQLServer(Cnn)

            Dim Sqlconsulta As String = "SELECT TOP (1) " & CAMPO & " AS CAMPO FROM " & TABLA & condicion & ""
            Ejecutar_consulta_SQL(Sqlconsulta, Cnn, BaseConexion, CadenaLocal, MostrarError)
            tb = New DataTable
            da.Fill(tb)

            Dim cuenta As Long = tb.Rows.Count

            If cuenta = 0 Then
                If DevNumero Then
                    Return Val(Valor_Si_No_Encuentra)
                Else
                    Return Valor_Si_No_Encuentra
                End If
            Else
                'Dim dr As DataRow = tb.Rows(0)
                Dim _Campo = tb.Rows(0).Item("CAMPO").ToString 'dr("CAMPO").ToString

                If IsDBNull(_Campo) Then
                    If DevNumero Then
                        Return 0
                    Else
                        Return Val(Valor_Si_No_Encuentra)
                    End If
                Else
                    If DevNumero Then
                        If IsNumeric(_Campo) Then
                            Return _Campo
                        Else
                            Return Val(Valor_Si_No_Encuentra)
                        End If

                    Else
                        Return _Campo
                    End If
                    'Return RTrim(dr("CAMPO").ToString)
                End If
            End If


        Catch ex As Exception

        End Try

    End Function

    Public Function Fx_Tipo_Grab_Modalidad(ByVal _TipoDoc As String, _
                                           ByVal _NrNumeroDoco As String) As String


        'Dim _NrNumeroDoco As String = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
        '                              "' AND MODALIDAD = '" & Modalidad & "'") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)

        Dim Continua As Boolean = True

        If String.IsNullOrEmpty(Trim(_NrNumeroDoco)) Then

            '_NrNumeroDoco = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
            '               "' AND MODALIDAD = '  '") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)
            Return "EnBlanco"
            '_CambiarNroOrigen_Modalidad = False
            '_TipGrab = 0 'TipoGrabacion.EnBlanco

        ElseIf _NrNumeroDoco = "0000000000" Then

            '_NrNumeroDoco = trae_dato(tb, cn1, "COALESCE(MAX(NUDO),'0000000000')", "MAEEDO", "TIDO = '" & _TipoDoc & "'")
            Return "Puros_Ceros"
            '_CambiarNroOrigen_Modalidad = False
            '_TipGrab = 1 'TipoGrabacion.Puros_Ceros

        Else
            Return "Con_Numeración"
            '_CambiarNroOrigen_Modalidad = True
            '_TipGrab = 2 'TipoGrabacion.Con_Numeración
        End If

    End Function

    Public Function Traer_Numero_Documento(ByVal _TipoDoc As String, _
                                           Optional ByVal _NumeroDoc As String = "", _
                                           Optional ByVal _Modalidad_Seleccionada As String = "", _
                                           Optional ByVal _Mostrar_Mensaje As Boolean = True, _
                                           Optional ByVal _Cambiar_Numeracion As Boolean = True)

        Dim _Existe_Doc As Integer
        Dim _TipGrab As String
        Dim _Arr_Nudo(1) As String

        Dim _NrNumeroDoco As String

        If String.IsNullOrEmpty(_Modalidad_Seleccionada) Then
            _Modalidad_Seleccionada = Modalidad
        End If

        If String.IsNullOrEmpty(Trim(_NumeroDoc)) Then
            _NrNumeroDoco = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
                                         "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)
        Else
            _NrNumeroDoco = _NumeroDoc
        End If

        _Existe_Doc = Cuenta_registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

        _TipGrab = Fx_Tipo_Grab_Modalidad(_TipoDoc, _NrNumeroDoco)

        Dim Contador = 0

        If _TipGrab = "EnBlanco" Then

            _NrNumeroDoco = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
                   "' AND MODALIDAD = '  '")

            If _Cambiar_Numeracion Then
                _Existe_Doc = Cuenta_registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)
                    Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = '" & _Proximo_Nro & "'" & vbCrLf & _
                                   "WHERE EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '"

                    Ej_consulta_IDU(Consulta_sql, cn1)

                    _NrNumeroDoco = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
                                             "' AND MODALIDAD = '  '")

                    _Existe_Doc = Cuenta_registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Loop
            End If

        ElseIf _TipGrab = "Puros_Ceros" Then

            _NrNumeroDoco = trae_dato(tb, cn1, "COALESCE(MAX(NUDO),'0000000000')", "MAEEDO", "TIDO = '" & _TipoDoc & "'")
            _NrNumeroDoco = Fx_Rellena_ceros(_NrNumeroDoco, 10, True)

            _Existe_Doc = 0

        ElseIf _TipGrab = "Con_Numeración" Then

            If _Cambiar_Numeracion Then
                Do While CBool(_Existe_Doc)

                    Dim _Proximo_Nro As String = Fx_Proximo_NroDocumento(_NrNumeroDoco, 10)
                    Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = '" & _Proximo_Nro & "' WHERE EMPRESA = '" & ModEmpresa & _
                                   "' AND  MODALIDAD = '" & _Modalidad_Seleccionada & "'"
                    Ej_consulta_IDU(Consulta_sql, cn1)

                    _NrNumeroDoco = trae_dato(tb, cn1, _TipoDoc, "CONFIEST", "EMPRESA = '" & ModEmpresa & _
                                             "' AND MODALIDAD = '" & _Modalidad_Seleccionada & "'")

                    _Existe_Doc = Cuenta_registros("MAEEDO", "TIDO = '" & _TipoDoc & "' And NUDO = '" & _NrNumeroDoco & "'")

                Loop
            End If

            End If

        If _Cambiar_Numeracion Then

            If CBool(_Existe_Doc) Then

                If _Mostrar_Mensaje Then

                    Dim info As New TaskDialogInfo("Grabar documento", _
                              eTaskDialogIcon.Stop, _
                              "El documento no se puede guardar correctamente", _
                              "Favor colocar la numeración correspondiente en Modalidad de trabajo " & _Modalidad_Seleccionada & vbCrLf & _
                              "vuelva a intentar la grabación." & vbCrLf & _
                              "El documento " & _TipoDoc & " Nro " & _NrNumeroDoco & " ya exite en el sistema", _
                              eTaskDialogButton.Close _
                              , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                    Dim result As eTaskDialogResult = TaskDialog.Show(info)

                End If

                _NrNumeroDoco = String.Empty

            End If

        End If

        Return _NrNumeroDoco

    End Function

    Function Fx_Proximo_NroDocumento(ByVal _NrNumeroDoco As String, ByVal _Cant_Caracteres As Integer) As String

        If String.IsNullOrEmpty(_NrNumeroDoco) Then
            _NrNumeroDoco = StrDup(_Cant_Caracteres, "0")
        End If

        Dim _Pos As Integer = 0
        Dim _Prefijo As String
        Dim _Cadena As String = String.Empty
        Dim _NvoNumero1 As Integer
        Dim _NvoNumero2 As String

        Do While _Pos < _Cant_Caracteres
            _Pos += 1
            Dim _Caracter As String = Right(_NrNumeroDoco, (_Cant_Caracteres + 1) - _Pos)

            If IsNumeric(_Caracter) Then
                _Prefijo = Left(_NrNumeroDoco, _Pos - 1)
                _Cadena = Right(_NrNumeroDoco, (_Cant_Caracteres + 1) - _Pos)
                Exit Do
            End If

        Loop

        _NvoNumero1 = CInt(_Cadena) + 1
        _NvoNumero2 = _Prefijo & numero_(_NvoNumero1, Len(_Cadena))

        Return _NvoNumero2

    End Function

    Public Function trae_Mayor_o_Menor_Valor(ByVal tb As DataTable, _
                          ByVal Cnn As SqlConnection, _
                          ByVal CAMPO As String, _
                          ByVal TABLA As String, _
                          ByVal CampoOrden As String, _
                          Optional ByVal Tipo As String = "Mayor") As String

        Dim Sqlconsulta As String

        ' Mayor
        If Tipo = "Mayor" Then
            Sqlconsulta = "SELECT TOP (1) " & CAMPO & " AS CAMPO FROM " & TABLA & " ORDER BY [" & CampoOrden & "] DESC"
        ElseIf Tipo = "Menor" Then
            Sqlconsulta = "SELECT TOP (1) " & CAMPO & " AS CAMPO FROM " & TABLA & " ORDER BY [" & CampoOrden & "]"
        End If

        Ejecutar_consulta_SQL(Sqlconsulta, Cnn)
        tb = New DataTable
        da.Fill(tb)

        'select nombre from tabla order by posicion asc limit 0,1

        Dim cuenta As Long = tb.Rows.Count

        If cuenta = 0 Then
            Return ""
        Else

            Dim dr As DataRow = tb.Rows(0)
            If IsDBNull(dr("CAMPO").ToString) Then
                Return ""
            Else
                Return RTrim(dr("CAMPO").ToString)
            End If

        End If
    End Function

    Public Function trae_datoAccess(ByVal tb As DataTable, _
                             ByVal CAMPO As String, _
                             ByVal TABLA As String, _
                             Optional ByVal condicion As String = "", _
                             Optional ByVal DevNumero As Boolean = False, _
                             Optional ByVal NombreBaseDeDatos As String = "Tmptools.mdb") As String
        Try

            If condicion <> "" Then
                condicion = " WHERE " & condicion
            End If

            Dim Sqlconsulta As String = "SELECT " & CAMPO & " AS CAMPO FROM " & TABLA & condicion & ""
            Ejecutar_consulta_SQLaccess(Sqlconsulta, NombreBaseDeDatos)

            tb = New DataTable
            ' Dim dad As New db
            Dim dsT As New DataSet
            dbD.Fill(tb) '(dsT, "Tabla")

            Dim cuenta As Long = tb.Rows.Count 'tb.Rows.Count

            If cuenta = 0 Then
                Return ""
            Else
                Dim dr As DataRow = tb.Rows(0) 'tb.Rows(0)

                If IsDBNull(dr("CAMPO").ToString) Then
                    Return ""
                    If DevNumero = True Then
                        Return 0
                    End If
                Else
                    Return RTrim(dr("CAMPO").ToString)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Function RutDigito(ByVal numero As String) As String

        Dim cuenta, Suma, resto, Digito As Integer
        Dim dig As Decimal
        Suma = 0
        cuenta = 2

        Do
            dig = numero Mod 10
            numero = Int(numero / 10)
            Suma = Suma + (dig * cuenta)
            cuenta = cuenta + 1
            If cuenta = 8 Then cuenta = 2
        Loop Until numero = 0

        resto = Suma Mod 11
        Digito = 11 - resto

        Select Case Digito
            Case 10 : Return "K"
            Case 11 : Return "0"
            Case Else : Return Trim(Str(Digito))
        End Select

    End Function

    Function VerificaDigito(ByVal RUT As String) As Boolean
        Try

            Dim Rt(1) As String
            Rt = Split(RUT, "-")

            Dim DigitoVerdadero, Digi As String
            DigitoVerdadero = UCase(RutDigito(Rt(0)))
            Digi = UCase(Rt(1))


            If Trim(Digi) = Trim(DigitoVerdadero) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SumarDatodeGrilla( _
       ByVal nombre_Columna As String, _
       ByVal Dgv As DataGridView, _
       Optional ByVal Resta As Integer = 1) As Double

        Dim total As Double = 0
        Dim valor As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"
        Try
            For i As Integer = 0 To Dgv.RowCount - Resta

                'MsgBox(Dgv.Item(nombre_Columna.ToLower, i).Value)

                valor = De_Txt_a_Num_01(Dgv.Item(nombre_Columna.ToLower, i).Value, 2, "")

                'valor = CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
                total = total + valor
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor
        Return total

    End Function

    Public Function trae_ultimo_Doc(ByVal tb As DataTable, _
                              ByVal Cnn As SqlConnection, _
                              ByVal CAMPO As String, _
                              ByVal TABLA As String, _
                              ByVal condicion As String) As String

        Dim Sqlconsulta As String = "SELECT TOP (1) " & CAMPO & " AS CAMPO FROM " & TABLA & " WHERE " & condicion & " order by desc"
        Ejecutar_consulta_SQL(Sqlconsulta, Cnn)
        tb = New DataTable
        da.Fill(tb)

        Dim cuenta As Long = tb.Rows.Count

        If cuenta = 0 Then
            Return ""
        Else

            Dim dr As DataRow = tb.Rows(0)
            If IsDBNull(dr("CAMPO").ToString) Then
                Return ""
            Else
                Return RTrim(dr("CAMPO").ToString)
            End If

        End If
    End Function

    Public Function Suma_cantidades(ByVal tb As DataTable, _
                                    ByVal Cnn As SqlConnection, _
                                    ByVal CAMPO As String, _
                                    ByVal TABLA As String, _
                                    Optional ByVal condicion As String = "", _
                                    Optional ByVal Decimales As Integer = 0) As Double

        Dim Suma As Double

        If condicion <> "" Then
            condicion = " Where " & condicion
        End If

        Dim Sqlconsulta As String = "SELECT ROUND(SUM(" & CAMPO & ")," & Decimales & ") AS CAMPO FROM " & TABLA & condicion & ""
        Ejecutar_consulta_SQL(Sqlconsulta, Cnn)
        tb = New DataTable
        da.Fill(tb)

        Dim cuenta As Long = tb.Rows.Count
        Dim dr As DataRow = tb.Rows(0)

        Suma = NuloPorNro(dr("CAMPO"), 0)

        Return Suma

        If cuenta = 0 Then
            Return 0
        Else

            If IsDBNull(dr("CAMPO").ToString) Then
                Return 0
            Else
                Return RTrim(dr("CAMPO").ToString)
            End If

        End If
    End Function

    Public Function Suma_cantidadesAccess(ByVal tb As DataTable, _
                                          ByVal CAMPO As String, _
                                          ByVal TABLA As String, _
                                          Optional ByVal condicion As String = "", _
                                          Optional ByVal Decimales As Integer = 0, _
                                          Optional ByVal NombreBaseDeDatos As String = "Tmptools.mdb") As String

        Try


            If condicion <> "" Then
                condicion = " Where " & condicion
            End If

            Dim Sqlconsulta As String = "SELECT ROUND(SUM(" & CAMPO & ")," & Decimales & ") AS CAMPO FROM " & TABLA & condicion & ""
            Ejecutar_consulta_SQLaccess(Sqlconsulta, NombreBaseDeDatos)

            tb = New DataTable

            ' tb = New DataTable
            ' Dim dad As New db
            Dim dsT As New DataSet
            dbD.Fill(tb) '(dsT, "Tabla")

            Dim cuenta As Long = tb.Rows.Count 'tb.Rows.Count


            If cuenta = 0 Then
                Return 0
            Else

                Dim dr As DataRow = tb.Rows(0)
                If IsDBNull(dr("CAMPO").ToString) Or dr("CAMPO").ToString = "" Then
                    'MsgBox(dr("CAMPO").ToString)
                    Return 0
                Else
                    Return RTrim(dr("CAMPO").ToString)
                End If

            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function Llenartabladepasofiltros(ByVal Tabla As String, _
                                      ByVal Codigo As String, _
                                      ByVal Descripcion As String, _
                                      ByVal Condicion As String, _
                                      Optional ByVal TablaBK As String = "", _
                                      Optional ByVal Informe As String = "")

        If TablaBK = "" Then TablaBK = Tabla

        Consulta_sql = "DELETE * FROM TmpFiltros WHERE Tipo = '" & TablaBK & "'"
        Ej_consulta_IDUaccess(Consulta_sql)

        Consulta_sql = "SELECT " & Codigo & " as CODIGO," & Trim(Descripcion) & " AS DESCRIPCION " & _
                       "FROM " & Tabla & " " & Condicion

        Dim TablaPs = get_Tablas(Consulta_sql, cn1)

        For Each Dtr As DataRow In TablaPs.Rows

            Dim Chk = False
            Dim Cod = Trim(Dtr.Item("CODIGO").ToString)
            Dim Desc = Trim(Dtr.Item("DESCRIPCION").ToString)

            If Cuenta_registros("Zw_TblFiltro_InfxUs", _
                              "Funcionario = '" & FUNCIONARIO & "' And " & _
                              "Informe = '" & Informe & "' And " & _
                              "Tabla = '" & TablaBK & "' And Codigo = '" & Cod & "'") = 1 Then

                Chk = True
            End If

            Consulta_sql = "INSERT INTO TmpFiltros (Tickeado,Tipo,Codigo,Descripcion) " & _
                           "VALUES (" & Chk & ",'" & TablaBK & "','" & Cod & "','" & Desc & "'" & ")"

            Ej_consulta_IDUaccess(Consulta_sql)

        Next

        If TablaPs.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If


    End Function


    Sub Eliminar_Campos( _
        ByVal dt As DataTable, ByVal Id As String)
        Try

            ' Seleccionamos todas las filas del objeto DataTable
            ' donde el campo ROL sea igual al valor pasado al
            ' procedimiento.
            '"Id = " & IdTipoConexion
            Dim filter As String = String.Format("Id = " & Id)
            Dim rows() As DataRow = dt.Select(filter)

            ' Número de registros seleccionados.
            '
            Dim totalValoresIguales As Integer = rows.Count

            ' Eliminamos todos los registros menos el último.
            '
            For Each row In rows

                'If (totalValoresIguales = 1) Then Exit For

                dt.Rows.Remove(row)

                'totalValoresIguales -= 1

            Next

            ' Aceptamos los cambios en el objeto DataTable.      
            '
            dt.AcceptChanges()
        Catch ex As Exception

        End Try

    End Sub


    ' ESTA FUNCION CONVIERTE UN VALOR NULO EN UN NUMERO POR EJEMPLO CERO
    Public Function NuloPorNro(Of T)(ByVal value As T, ByVal defaultValue As T) As T

        Dim obj1 As Object = value
        Dim obj2 As Object = defaultValue

        Try
            If ((obj1 Is DBNull.Value) OrElse (obj1 Is Nothing)) Then
                ' Es NULL; devolvemos el valor por defecto siempre
                ' y cuando éste tampoco sea NULL.
                '
                If (Not obj2 Is DBNull.Value) Then
                    Return defaultValue

                Else
                    Return Nothing

                End If

            Else
                ' No es NULL ni Nothing; devolvemos el valor pasado.
                '

                Return value

            End If

        Catch ex As Exception
            Return Nothing

        End Try

    End Function

    Function Trae_CostoUc(ByVal Codigo As String, ByVal Unidad As Integer) As Double
        Dim CostoUc As Double
        CostoUc = trae_dato(tb, cn1, "PPUL0" & Unidad, "MAEPREM", _
                            "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)
        Return CostoUc
    End Function

    Function Trae_PM(ByVal Codigo As String) As Double
        Dim CostoPm As Double
        CostoPm = trae_dato(tb, cn1, "PM", "MAEPREM", "KOPR = '" & Codigo & "' and EMPRESA = '" & ModEmpresa & "'", True)
        Return CostoPm
    End Function

    Function Trae_PM_Suc(ByVal Codigo As String) As Double
        Dim CostoPmSuc As Double
        CostoPmSuc = trae_dato(tb, cn1, "PMSUC", "MAEPMSUC", _
                            "KOPR = '" & Codigo & _
                            "' and EMPRESA = '" & ModEmpresa & "' And KOSU = '" & ModSucursal & "'", True)
        Return CostoPmSuc
    End Function


    Function RevisarEstadoEntidad(ByVal Endo As String, ByVal Suendo As String) As Boolean

        If Endo = Nothing Then
            Endo = "1" : Suendo = ""
        End If

        Dim Bloqueda As Boolean = trae_dato(tb, cn1, "BLOQUEADO", "MAEEN", "KOEN = '" & Endo & "' and SUEN = '" & Suendo & "'")

        If Bloqueda Then
            MessageBoxEx.Show("Entidad bloqueada para realizar Compras y Ventas", "Dirijase a tesoreria", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        If Bloqueda = False Then Return True

    End Function


    Public Function Trae_lista_de_datos(ByVal sel As String, _
                                        ByVal Campo As String, _
                                        ByVal tb As DataTable, _
                                        ByVal Cnn As SqlConnection) As String()

        Dim Arreglo() As String

        Try

            Ejecutar_consulta_SQL(sel, Cnn)
            tb = New DataTable
            da.Fill(tb)
            ReDim Arreglo(tb.Rows.Count - 1)

            Dim k As Integer = -1
            For i As Integer = 0 To tb.Rows.Count - 1
                Dim s As String = tb.Rows(i).Item(Campo).ToString()
                Arreglo(i) = s
                k += 1
            Next
            If k = -1 Then Return Nothing
            ReDim Preserve Arreglo(k)
            Return Arreglo

        Catch ex As Exception
            MessageBox.Show(ex.Message, _
                            "Error al recuperar las bases de la instancia indicada", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function trae_Ultimo_ID(ByVal tb As DataTable, _
                              ByVal Cnn As SqlConnection _
                              ) As Integer

        Dim Sqlconsulta As String = "SELECT @@IDENTITY AS 'Identity'"
        Ejecutar_consulta_SQL(Sqlconsulta, Cnn)
        tb = New DataTable
        da.Fill(tb)

        Dim cuenta As Long = tb.Rows.Count

        If cuenta = 0 Then
            Return 0
        Else

            Dim dr As DataRow = tb.Rows(0)
            If IsDBNull(dr("Identity").ToString) Then
                Return 0
            Else
                Return RTrim(dr("Identity").ToString)
            End If

        End If
    End Function

    Public Function abre_formulario(ByVal form_hijo As Form, ByVal form_padre As Form) As Boolean
        'Dim Mdiform As New form_hijo
        form_hijo.MdiParent = form_padre
        form_hijo.MdiParent.Show()
        form_hijo.Visible = True
    End Function

    Public Function Primerdiadelmes(ByVal fecha As Date) As Date
        Dim rtn As New Date
        rtn = fecha 'Date.Now
        rtn = rtn.AddDays(-rtn.Day + 1)
        Return rtn
    End Function

    Public Function ultimodiadelmes(ByVal fecha As Date) As Date
        Dim rtn As New Date
        rtn = fecha.Date ' fecha 'Date.Now
        rtn = rtn.AddDays(-rtn.Day + 1).AddMonths(1).AddDays(-1)
        Return rtn
    End Function

    Function llenar_combobox(ByVal listado() As String, ByVal Combo As ComboBox)
        Try

            Combo.Items.Clear()
            If Not listado Is Nothing Then
                Combo.Items.AddRange(listado)
            End If
        Catch ex As Exception

        End Try

    End Function

    Function llenar_listbox(ByVal sel As String, _
                            ByVal campo As String, _
                            ByVal lista As ListBox, _
                            ByVal tb As DataTable, _
                            ByVal Cnn As SqlConnection)
        lista.Items.Clear()
        Try
            Ejecutar_consulta_SQL(sel, Cnn)
            tb = New DataTable
            da.Fill(tb)

            Dim dr As DataRow = tb.Rows(0)

            For i As Integer = 0 To tb.Rows.Count - 1
                lista.Items.Add(tb.Rows(i).Item(campo).ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Function llenar_arrglo_by(ByVal sel As String, _
                              ByVal campopadre As String, _
                              ByVal campohijo As String, _
                              ByVal tb As DataTable, _
                              ByVal Cnn As SqlConnection) As String(,)


        Dim Arreglo(,) As String

        Try

            Ejecutar_consulta_SQL(sel, Cnn)
            tb = New DataTable
            da.Fill(tb)
            ReDim Arreglo(tb.Rows.Count - 1, 2)

            Dim k As Integer = -1
            Dim dr As DataRow = tb.Rows(0)

            Dim Padre As String
            Dim Hijo As String

            'If IsDBNull(dr(campopadre).ToString) Then

            For i As Integer = 0 To tb.Rows.Count - 1
                Padre = tb.Rows(i).Item(campopadre).ToString()
                Hijo = RTrim(tb.Rows(i).Item(campohijo).ToString())

                Arreglo(i, 0) = Padre
                Arreglo(i, 1) = Hijo

                k += 1
            Next
            If k = -1 Then Return Nothing
            ReDim Preserve Arreglo(k, k)
            Return Arreglo

        Catch ex As Exception
            MessageBox.Show(ex.Message, _
                            "Error al recuperar las bases de la instancia indicada", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Function es_numero(ByVal numero As String) As Boolean

        Dim w As Integer
        Dim lineax As String

        w = 0

        Select Case RTrim$(Mid(numero, 1, 1)) & RTrim$(Mid(numero, 2, 1))
            Case "00" : w = 1
            Case "01" : w = 1
            Case "02" : w = 1
            Case "03" : w = 1
            Case "04" : w = 1
            Case "05" : w = 1
            Case "06" : w = 1
            Case "07" : w = 1
            Case "08" : w = 1
            Case "09" : w = 1
        End Select

        If w = 1 Then
            es_numero = False
            Exit Function
        End If

        For w = 1 To Len(numero)
            lineax = RTrim$(Mid(numero, w, 1))

            If lineax = "" Then
                es_numero = False
                Exit Function
            End If

            If InStr("-.,1234567890", RTrim$(lineax)) = 0 Then
                es_numero = False
                Exit Function
            Else
                es_numero = True
            End If
        Next


    End Function

    Function SoloNumeros(ByVal Keyascii As Short, _
                        Optional ByVal _Solo_Nros As Boolean = True) As Short


        Dim _Sd = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator

        Dim T As String = Chr(Keyascii)
        ' Dim dd '= InStr("1234567890,.-", T)

        If _Solo_Nros Then
            'dd = InStr("1234567890", T)
            If InStr("1234567890", Chr(Keyascii)) = 0 Then
                SoloNumeros = 0
            Else
                SoloNumeros = Keyascii
            End If
        Else
            ' dd = InStr("1234567890,.-", T)
            If InStr("1234567890,.-", Chr(Keyascii)) = 0 Then
                SoloNumeros = 0
            Else
                SoloNumeros = Keyascii
            End If
        End If



        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Function SoloNumerosSinPuntosNiComas(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosSinPuntosNiComas = 0
        Else
            SoloNumerosSinPuntosNiComas = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosSinPuntosNiComas = Keyascii
            Case 13
                SoloNumerosSinPuntosNiComas = Keyascii
        End Select
    End Function



    Function SoloLetrasNumeros(ByVal Keyascii As Short) As Short
        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890,.-", Chr(Keyascii)) = 0 Then
            SoloLetrasNumeros = 0
        Else
            SoloLetrasNumeros = Keyascii
        End If
    End Function


    Function CreateXMLFile(ByVal ds As DataSet, _
                           ByVal fileNameXML As String, _
                           ByVal fileNameStyleSheetXSL As String, _
                           ByVal overWrite As Boolean) As Boolean

        '*******************************************************************
        ' Nombre: CreateXMLFile
        ' por Enrique Martínez Montejo - 24/06/2006
        '
        ' Versión: 1.0     (Compatible con Framework 1.0, 1.1 y 2.0)    
        '
        ' Finalidad: Crear un archivo XML con el contenido existente
        '            en un objeto DataSet.
        '
        ' Entradas:
        '
        '     ds: DataSet. Un objeto DataSet válido.
        '
        '     fileNameXML:
        '         String. Ruta y nombre del archivo XML de salida.
        '
        '    fileNameStyleSheetXSL:
        '         String. Ruta y nombre, si procede, de la hoja de
        '         de estilo del lenguaje extensible a la cual se
        '         vinculará el archivo XML.
        '         Si no desea especificar ninguna hoja de estilo, pase
        '         al procedimiento una cadena de longitud cero ("").
        '
        '     overWrite:
        '         Boolean. De ser False, y existir el archivo XML,
        '         se pedirá confirmación para sobrescribir el archivo.
        '
        '*******************************************************************

        ' Verificamos los parámetros pasados al procedimiento.
        '
        If ((ds Is Nothing) OrElse (fileNameXML = "")) Then
            MessageBox.Show("Parámetros incorrectos.", _
                            "Crear XML", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Si el archivo existe, pedimos confirmación para sobrescribirlo,
        ' siempre y cuando no se haya especificado explícitamente.
        '
        If ((overWrite = False) AndAlso (System.IO.File.Exists(fileNameXML) = True)) Then
            If MessageBox.Show("Ya existe un archivo con el mismo nombre " & _
                               "en la ruta indicada. " & vbCrLf & vbCrLf & _
                               "¿Desea sobrescribirlo?", _
                               "Crear XML", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        ' A fin de controlar la posible excepción que se puede
        ' dar al no poder obtener acceso al archivo.
        '
        Try
            ' Creamos un objeto FileStream para escritura.
            '
            Dim fs As New System.IO.FileStream(fileNameXML, System.IO.FileMode.Create)

            ' Creamos un objeto XmlTextWriter para el
            ' objeto FileStream.
            '
            Dim xtw As New System.Xml.XmlTextWriter(fs, System.Text.Encoding.Unicode)

            ' Procesamos las instrucciones, indicando la hoja de estilos,
            ' si procede, al comienzo del archivo XML.
            '
            With xtw
                .WriteProcessingInstruction("xml", "version='1.0'")
                .WriteProcessingInstruction("xml-stylesheet", _
                                            "type='text/xsl' href='" & _
                                            fileNameStyleSheetXSL & _
                                            "'")
                ' Escribimos los datos del objeto DataSet en el archivo XML.
                '
                ds.WriteXml(xtw)

                ' Cerramos el objeto
                '
                .Close()
            End With

            MessageBox.Show("Se ha creado con éxito el archivo XML.", _
                            "Crear XML", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As IO.IOException
            MessageBox.Show(ex.Message, _
                            "Crear XML", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show(ex.Message, _
                            "Crear XML", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return True

    End Function


    Function CrearArchivoTxt(ByVal Ruta As String, _
                             ByVal NombreArchivo As String, _
                             ByVal Cuerpo As String, _
                             Optional ByVal _Mostrar_OK As Boolean = True)
        Try

            Dim _Palo = Right(Ruta, 1)

            If _Palo <> "\" Then
                Ruta += "\"
            End If

            Dim RutaArchivo As String = Ruta & NombreArchivo

            Dim oSW As New System.IO.StreamWriter(RutaArchivo)

            oSW.WriteLine(Cuerpo)
            oSW.Close()

            If _Mostrar_OK Then
                MessageBoxEx.Show("Archivo guardado correctamente en el siguiente directorio:" & vbCrLf & _
                                  RutaArchivo, "Crear archivo txt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'aqui creo el archivo oculto,,, si no se pone este instrucion no pasa nada .. solo es para 
            'asignarles caracteristicas a los archivos 
            'quitalo como comentario y calalo
            'SetAttr(RutaArchivo, vbHidden)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Public Function Fx_Licencia(ByVal _Formulario As Form, ByVal _RutEmpresa As String) As Boolean

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Licencia Where Rut = '" & _RutEmpresa & "'"
        Dim _TblLicencia As DataTable = get_Tablas(Consulta_sql, cn1)


        If CBool(_TblLicencia.Rows.Count) Then
            With _TblLicencia.Rows(0)
                Dim _Rut = .Item("Rut")
                Dim _Fecha_caduca As Date = .Item("Fecha_caduca")
                Dim _Cant_licencias = .Item("Cant_licencias")

                Dim _Llave1 As String = .Item("Llave1")
                Dim _Llave2 As String = .Item("Llave2")
                Dim _Llave3 As String = .Item("Llave3")
                Dim _Llave4 As String = .Item("Llave4")

                Dim _LLaves = Fx_Genera_Licencia_BakApp(_Rut, _Fecha_caduca, _Cant_licencias, "b4s1ng4")

                Dim _Llave1_R = _LLaves(0)
                Dim _Llave2_R = _LLaves(1)
                Dim _Llave3_R = _LLaves(2)
                Dim _Llave4_R = _LLaves(3) '= Encripta_md5(_Llave1 & _Llave2 & _Llave3)

                Dim _Dias = DateDiff(DateInterval.Day, FechaDelServidor, _Fecha_caduca)

                If _Dias > 0 Then

                    If _Dias < 10 Then
                        MessageBoxEx.Show(_Formulario, "Faltan " & _Dias & " días para que caduque la licencia", "Licencia", _
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return True
                    End If

                Else
                    MessageBoxEx.Show(_Formulario, "Sistema sin licencias de uso", "Licencia Expirada", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                If _Llave1_R <> _Llave1 Or _
                   _Llave2_R <> _Llave2 Or _
                   _Llave3_R <> _Llave3 Or _
                   _Llave4_R <> _Llave4 Then

                    MessageBoxEx.Show(_Formulario, "Licencia corrupta", "Error en base de datos", _
                                      MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    Return True
                End If


            End With

        Else

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Licencia (Rut,Razon,NombreCorto,Direccion,Giro,Ciudad,Pais,Telefonos) " & vbCrLf & _
                           "Select TOP 1 RUT,RAZON,NCORTO,DIRECCION,GIRO,CIUDAD,PAIS,TELEFONOS" & vbCrLf & _
                           "From CONFIGP Where EMPRESA = '01'"
            Ej_consulta_IDU(Consulta_sql, cn1)

            MessageBoxEx.Show(_Formulario, "No existe llave para el uso del sistema", "Validación BakApp", _
                              MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function




    ' Función que retorna un objeto DataTable para 
    'enlazarlo con el combobox y visualizar las tablas
    Public Function get_Tablas(ByVal Consulta_sql As String, _
                               ByVal Cnn As SqlConnection, _
                              Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal) As DataTable

        Try
            SQL_ServerClass.AbrirConexion_SQLServer(Cnn)
            Dim dt As DataTable = New DataTable()

            Ejecutar_consulta_SQL(Consulta_sql, Cnn, BaseConexion)
            da.Fill(dt)
            SQL_ServerClass.CerrarConexion(Cnn)
            ' retornar el dataTable
            Return dt

            ' errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function

    Public Function _Global_Fx_Cambio_en_la_Grilla(ByVal _Tbl_Grilla As DataTable, _
                                                   Optional ByVal _Rev_Insertas As Boolean = True, _
                                                   Optional ByVal _Rev_Eliminadas As Boolean = True, _
                                                   Optional ByVal _Rev_Modificada As Boolean = True) As Boolean

        Dim _Modificado As Boolean

        For Each _Fila As DataRow In _Tbl_Grilla.Rows
            Select Case _Fila.RowState
                Case DataRowState.Added
                    If _Rev_Insertas Then _Modificado = True
                Case DataRowState.Deleted
                    If _Rev_Eliminadas Then _Modificado = True
                Case DataRowState.Detached
                    _Modificado = True
                Case DataRowState.Modified
                    If _Rev_Modificada Then _Modificado = True
            End Select

            If _Modificado Then Exit For
        Next

        Return _Modificado

    End Function


    Public Sub Sb_AddToLog(ByVal Accion As String, _
                           ByVal Descripcion As String, _
                           ByVal TxtLog As Object, _
                           Optional ByVal _Incluir_FechaHora As Boolean = True)
        If _Incluir_FechaHora Then
            TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        Else
            TxtLog.Text += Accion & " (" & Descripcion & ")" & vbCrLf
        End If

        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()

    End Sub


    Function Generar_Filtro_IN_Arreglo(ByVal Arreglo() As String, _
                                       ByVal EsNumero As Boolean)

        Dim Cadena As String = String.Empty
        Dim Separador As String = ""

        If EsNumero Then
            Separador = "#"
        Else
            Separador = "@"
        End If

        'If (Tabla Is Nothing) Then Return "()"

        Dim i = 0
        For Each Valor As String In Arreglo
            If Not String.IsNullOrEmpty(Valor) Then
                Cadena = Cadena & Separador & Trim(Valor) & Separador '& Coma
                i += 1
            End If
        Next

        If EsNumero Then
            Cadena = Replace(Cadena, "##", ",")
            Cadena = Replace(Cadena, "#", "")
        Else
            Cadena = Replace(Cadena, "@@", "@,@")
            Cadena = Replace(Cadena, "@", "'")
        End If

        Cadena = "(" & Cadena & ")"

        Return Cadena

    End Function

    Sub OcultarEncabezadoGrilla(ByVal Grilla As DataGridView, _
                                Optional ByVal Activar_Orden_Automatico As Boolean = False, _
                                Optional ByVal _Ancho1raColumna As Integer = 15, _
                                Optional ByVal _ReadOnly As Boolean = True)

        With Grilla
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = .ColumnCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 0 To NCol - 1

                Dim NomColumna = .Columns(i).Name.ToString()
                Dim TipoColumna = .Columns(i).CellType.ToString 'DataGrid.Columns(i - 1).ValueType.ToString()

                .Columns(i).Visible = False
                .Columns(i).ReadOnly = _ReadOnly

                If Activar_Orden_Automatico Then
                    .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                End If

            Next

            '.RowHeadersWidth = _Ancho1raColumna

        End With

    End Sub

    Public Function Get_DataSet(ByVal Consulta_sql As String, _
                                ByVal Cnn As SqlConnection, _
                                Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal) As DataSet

        Try
            SQL_ServerClass.AbrirConexion_SQLServer(Cnn)
            Dim dt As DataTable = New DataTable()

            Ejecutar_consulta_SQL(Consulta_sql, Cnn, BaseConexion)
            Dim DataSt As New DataSet
            da.Fill(DataSt)
            SQL_ServerClass.CerrarConexion(Cnn)
            ' retornar el dataTable
            Return DataSt
            ' errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return Nothing

    End Function


    Function Rellenar(ByVal Cadena As String, _
                      ByVal CantCaracteres As Integer, _
                      ByVal Relleno As String, Optional ByVal Derecha As Boolean = True) As String
        Dim i As Integer
        Dim nro As String
        nro = Len(Cadena)

        Dim Cantidad As Integer = CantCaracteres - nro

        If Cantidad > 0 Then
            For i = 0 To Cantidad - 1
                If Derecha = True Then
                    Cadena = Cadena & Relleno
                Else
                    Cadena = Relleno & Cadena
                End If
            Next
        End If

        Return Cadena
    End Function

    Public Function imprimir_barra(ByVal Puerto As String, _
                                   ByVal unoxuno As Boolean, _
                                   ByVal Texto_etiqueta As String, _
                                   ByVal Codigo_principal As String, _
                                   ByVal Codigo_tecnico As String, _
                                   ByVal Codigo_rapido As String, _
                                   ByVal Descripcion As String, _
                                   Optional ByVal Precio_cambiado As String = "", _
                                   Optional ByVal Precio_ud1 As String = "", _
                                   Optional ByVal Precio_ud2 As String = "", _
                                   Optional ByVal Fecha_mod As String = "", _
                                   Optional ByVal Fecha_impresion As String = "", _
                                   Optional ByVal Ubicacion As String = "", _
                                   Optional ByVal Bodega As String = "", _
                                   Optional ByVal Tido As String = "", _
                                   Optional ByVal Nudo As String = "")

        'Dim fic As String = texto '"C:\Ejemplo1.prn"
        Dim texto As String = ""

        'Dim sr As New System.IO.StreamReader(fic)
        texto = Texto_etiqueta


        Codigo_tecnico = trae_dato(tb, cn1, "KOPRTE", "MAEPR", "KOPR = '" & Codigo_principal & "'")
        Codigo_rapido = trae_dato(tb, cn1, "KOPRRA", "MAEPR", "KOPR = '" & Codigo_principal & "'")

        texto = Replace(texto, "<CODIGO_PR>", Trim(Codigo_principal))
        texto = Replace(texto, "<CODIGO_TC>", Trim(Codigo_tecnico))
        texto = Replace(texto, "<CODIGO_RA>", Trim(Codigo_rapido))

        Descripcion = Replace(Descripcion, Chr(34), "")

        texto = Replace(texto, "<DESCRIPCION_PR>", Descripcion)

        Dim Desc0125 = Mid(Descripcion, 1, 25)
        texto = Replace(texto, "<DESCRIPCION_1-25>", Desc0125)


        Dim Desc2650 = Mid(Descripcion, 26, 50)
        texto = Replace(texto, "<DESCRIPCION_26-50>", Desc2650)


        texto = Replace(texto, "<UBICACION>", Ubicacion)
        texto = Replace(texto, "<TIDO>", Tido)
        texto = Replace(texto, "<NUDO>", Nudo)

        If unoxuno = True Then
            texto = Replace(texto, "<PRECIO_CMD>", Replace(Precio_ud1, ",", "."))
        Else
            texto = Replace(texto, "<PRECIO_CMD>", Replace(Precio_cambiado, ",", "."))
        End If

        texto = Replace(texto, "<PRECIO_UD1>", Replace(Precio_ud1, ",", "."))
        texto = Replace(texto, "<PRECIO_UD2>", Replace(Precio_ud2, ",", "."))

        texto = Replace(texto, "<FECHA_MODIFICACION>", Fecha_mod)
        texto = Replace(texto, "<FECHA_IMPRESION>", Fecha_impresion)
        'texto = Replace(texto, "<CANT_ETIQUETAS>", "0987654321")
        'sr.Close()

        'MsgBox(Codigo_rapido & " - " & Codigo_tecnico & " - " & Descripcion)
        ' Exit Function

        Dim fic As String = AppPath(True) & "Barra.prn"

        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(texto)
        sw.Close()

        '----------------------------------------------------------------------

        'Dim psi = New ProcessStartInfo(AppPath(True) & "Imprimir.bat")

        'Dim psi = New ProcessStartInfo("C:\Imprimir.bat")
        'psi.WorkingDirectory = "C:\" 'AppPath(True)
        'psi.WindowStyle = ProcessWindowStyle.Normal
        'Process.Start("C:\Imprimir.bat")
        System.IO.File.Copy("Barra.prn", Puerto)
        'System.IO.File.Copy("Barra.prn", "lpt1")

    End Function

    Public Function imprimir_Codigo_de_barras( _
                                   ByVal Puerto As String, _
                                   ByVal unoxuno As Boolean, _
                                   ByVal Texto_etiqueta As String, _
                                   ByVal Codigo_principal As String, _
                                   Optional ByVal Precio_cambiado As String = "", _
                                   Optional ByVal ListaPrecioCosto As String = "", _
                                   Optional ByVal Decimales As Integer = 0, _
                                   Optional ByVal Fecha_mod As String = "", _
                                   Optional ByVal Fecha_impresion As String = "", _
                                   Optional ByVal Empresa As String = "", _
                                   Optional ByVal Sucursal As String = "", _
                                   Optional ByVal Bodega As String = "", _
                                   Optional ByVal Tido As String = "", _
                                   Optional ByVal Nudo As String = "")

        Dim texto As String = Texto_etiqueta

        Dim Descripcion = trae_dato(tb, cn1, "NOKOPR", "MAEPR", "KOPR = '" & Codigo_principal & "'")
        Dim Codigo_tecnico = trae_dato(tb, cn1, "KOPRTE", "MAEPR", "KOPR = '" & Codigo_principal & "'")
        Dim Codigo_rapido = trae_dato(tb, cn1, "KOPRRA", "MAEPR", "KOPR = '" & Codigo_principal & "'")

        Dim Ubicacion = trae_dato(tb, cn1, "DATOSUBIC", "TABBOPR", "EMPRESA = '" & Empresa & _
                                           "' AND KOSU = '" & Sucursal & _
                                           "' AND KOBO = '" & Bodega & "' KOPR = '" & Codigo_principal & "'")

        texto = Replace(texto, "<CODIGO_PR>", Trim(Codigo_principal))
        texto = Replace(texto, "<CODIGO_TC>", Trim(Codigo_tecnico))
        texto = Replace(texto, "<CODIGO_RA>", Trim(Codigo_rapido))

        Descripcion = Replace(Descripcion, Chr(34), "")

        texto = Replace(texto, "<DESCRIPCION_PR>", Descripcion)

        Dim Desc_0125 = Mid(Descripcion, 1, 25)
        texto = Replace(texto, "<DESCRIPCION_1-25>", Desc_0125)

        Dim Desc_2650 = Mid(Descripcion, 26, 50)
        texto = Replace(texto, "<DESCRIPCION_26-50>", Desc_2650)


        texto = Replace(texto, "<UBICACION>", Ubicacion)
        texto = Replace(texto, "<TIDO>", Tido)
        texto = Replace(texto, "<NUDO>", Nudo)


        Dim Precio_ud1 As Double = trae_dato(tb, cn1, "PP01UD", "TABPRE", "KOLT = '" & ListaPrecioCosto & _
                                           "' AND KOPR = '" & Codigo_principal & "'", True)

        Dim Precio_ud2 As Double = trae_dato(tb, cn1, "PP02UD", "TABPRE", "KOLT = '" & ListaPrecioCosto & _
                                           "' AND KOPR = '" & Codigo_principal & "'", True)

        Dim p1 = FormatCurrency(Precio_ud1, Decimales)
        Dim p2 = FormatCurrency(Precio_ud2, Decimales)

        texto = Replace(texto, "<PRECIO_UD1>", p1)
        texto = Replace(texto, "<PRECIO_UD2>", p2)
        'Precio_ud1 = Math.Round(Precio_ud1, Decimales)
        'Precio_ud2 = Math.Round(Precio_ud2, Decimales)

        If unoxuno = True Then
            texto = Replace(texto, "<PRECIO_CMD>", Replace(Precio_ud1, ",", "."))
        Else
            texto = Replace(texto, "<PRECIO_CMD>", Replace(Precio_cambiado, ",", "."))
        End If


        texto = Replace(texto, "<FECHA_MODIFICACION>", Fecha_mod)
        texto = Replace(texto, "<FECHA_IMPRESION>", Fecha_impresion)

        Dim fic As String

        If LeeArchivo(AppPath(True) & "Ini.txt") = "" Then
            fic = AppPath(True) & "Barra.prn"
        Else
            fic = "C:\BakApp\Barra.prn"
        End If



        Dim sw As New System.IO.StreamWriter(fic)
        'MsgBox(fic)
        sw.WriteLine(texto)
        sw.Close()
        System.IO.File.Copy(fic, Puerto)
        'System.IO.File.Copy("Barra.prn", "lpt1")

    End Function

    Public Function De_Num_a_Tx_01(ByVal lNumero As Double, _
                               Optional ByVal bEntero As Boolean = False, _
                               Optional ByVal nDecimales As Integer = 2) As String
        '-------------------------------------------------§§§----'
        ' FUNCION PARA CONVERTIR UN NUMERO EN TEXTO
        '-------------------------------------------------§§§----'
        '
        On Error GoTo fin
        '
        Dim sNumero As String
        Dim nLong1 As Integer
        Dim nCont1 As Integer
        '
        If bEntero = True Then
            sNumero = CStr(Format(lNumero, "########0"))
            ''
        Else
            Select Case nDecimales
                Case -1 : sNumero = CStr(Format(lNumero, "########0.#########"))
                Case 1 : sNumero = CStr(Format(lNumero, "########0.#"))
                Case 2 : sNumero = CStr(Format(lNumero, "########0.0#"))
                Case 3 : sNumero = CStr(Format(lNumero, "########0.00#"))
                Case 4 : sNumero = CStr(Format(lNumero, "########0.000#"))
                Case 5 : sNumero = CStr(Format(lNumero, "########0.0000#"))
                Case 6 : sNumero = CStr(Format(lNumero, "########0.00000#"))
                Case 7 : sNumero = CStr(Format(lNumero, "########0.000000#"))
                Case 8 : sNumero = CStr(Format(lNumero, "########0.0000000#"))
                Case 9 : sNumero = CStr(Format(lNumero, "########0.00000000#"))
                Case 9 : sNumero = CStr(Format(lNumero, "########0.00000000#"))
                Case 10 : sNumero = CStr(Format(lNumero, "########0.000000000#"))
                Case 11 : sNumero = CStr(Format(lNumero, "########0.0000000000#"))
                Case 12 : sNumero = CStr(Format(lNumero, "########0.00000000000#"))
                Case Else : sNumero = CStr(Format(lNumero, "########0.00#"))
            End Select
            ''
        End If
        '
        nLong1 = Len(sNumero)
        '
        For nCont1 = 1 To nLong1
            If Mid$(sNumero, nCont1, 1) = "," Then Mid(sNumero, nCont1, 1) = "."
            ''
        Next nCont1
        '
        If bEntero = True Then
            De_Num_a_Tx_01 = sNumero
            ''
        ElseIf InStr(sNumero, ".") > 0 Then
            If (Len(sNumero) = InStr(sNumero, ".")) And (nDecimales = -1) Then
                De_Num_a_Tx_01 = Mid$(sNumero, 1, InStr(sNumero, ".") - 1)
                ''
            Else
                De_Num_a_Tx_01 = sNumero
                ''
            End If
            ''
        Else
            De_Num_a_Tx_01 = sNumero & ".0"
            ''
        End If
        '
        Exit Function
        '
fin:
        De_Num_a_Tx_01 = "###.###"
        ''
    End Function

    '‘———————————————— -§§§— - ’
    '‘ FUNCION PARA CONVERTIR UN TEXTO EN NUMERO DECIMAL
    '‘———————————————— -§§§— - ’

    Public Function De_Txt_a_Num_01(ByVal sTexto As String, _
                                       Optional ByVal nDecimales As Integer = 3, _
                                       Optional ByVal sP_Formato_Decimal As String = "") As Double
        '-------------------------------------------------§§§----'
        ' FUNCION PARA CONVERTIR UN TEXTO EN NUMERO DECIMAL
        '-------------------------------------------------§§§----'
        '
        Dim bCte2 As Boolean
        '
        Dim nContador1 As Integer
        Dim nContador2 As Integer
        Dim nLong_Total As Integer
        Dim nPos_Punto As Integer
        Dim nCte1 As Integer
        Dim nDecimal As Integer
        '
        Dim lNumeruco As Double
        '
        Dim sNumero As String
        Dim sL_Aux_01 As String
        '
        Dim sL_Array_Pto_01() As String
        Dim sL_Array_Coma_01() As String
        '
        On Error GoTo Error_Numero
        '
        '-------------------------------------------------§§§----'
        Select Case sP_Formato_Decimal
            Case "."    ' USAMOS "." COMO SEPARADOR DE DECIMALES
                ' Y LA "," LA ELIMINAMOS
                sL_Array_Pto_01 = Split(sTexto, ".")
                sL_Array_Coma_01 = Split(sTexto, ",")
                '
                sL_Aux_01 = ""
                For nContador1 = LBound(sL_Array_Coma_01) To UBound(sL_Array_Coma_01)
                    sL_Aux_01 = sL_Aux_01 & sL_Array_Coma_01(nContador1)
                    ''
                Next nContador1
                '
                sTexto = sL_Aux_01
                ''
            Case ","    ' USAMOS "," COMO SEPARADOR DE DECIMALES
                ' Y EL "." LE ELIMINAMOS
                sL_Array_Pto_01 = Split(sTexto, ".")
                sL_Array_Coma_01 = Split(sTexto, ",")
                '
                sL_Aux_01 = ""
                For nContador1 = LBound(sL_Array_Pto_01) To UBound(sL_Array_Pto_01)
                    sL_Aux_01 = sL_Aux_01 & sL_Array_Pto_01(nContador1)
                    ''
                Next nContador1
                '
                sTexto = sL_Aux_01
                ''
        End Select
        '-------------------------------------------------§§§----'
        '
        lNumeruco = 0
        '
        If nDecimales >= 0 Then
            nDecimal = nDecimales
            ''
        Else
            nDecimal = 3
            ''
        End If
        '
        sTexto = Trim(sTexto)
        '
        If InStr(1, sTexto, "-") > 0 Then
            'Es un numero negativo
            bCte2 = True
            sTexto = Mid$(sTexto, 2)
            ''
        ElseIf InStr(1, sTexto, "+") > 0 Then
            'Es un numero positivo (con signo)
            bCte2 = False
            sTexto = Mid$(sTexto, 2)
            ''
        Else
            'Es un numero positivo
            bCte2 = False
            ''
        End If
        '
        nLong_Total = Len(sTexto)
        '
        For nContador1 = 1 To nLong_Total
            If Mid(sTexto, nContador1, 1) = "," Then Mid(sTexto, nContador1, 1) = "."
            ''
        Next nContador1
        '
        If InStr(1, sTexto, ".") <= 0 Then sTexto = sTexto & ".0"
        '
        nPos_Punto = InStr(1, sTexto, ".")
        '
        nContador2 = 0
        For nContador1 = 1 To nLong_Total
            If Mid$(sTexto, nContador1, 1) <> "." Then
                'No estamos en el caracte "."
                If nContador1 < nPos_Punto And nPos_Punto <> 0 Then
                    nCte1 = 1
                    ''
                Else
                    nContador2 = nContador2 + 1
                    nCte1 = 0
                    ''
                End If
                '
                sNumero = Mid$(sTexto, nContador1, 1)
                '
                If nContador2 > nDecimal Then
                    If sNumero > 5 Then lNumeruco = lNumeruco + (CSng(1) * (10 ^ (nPos_Punto - nContador1 - nCte1 + 1)))
                    nContador1 = nLong_Total
                    ''
                Else
                    lNumeruco = lNumeruco + (CSng(sNumero) * (10 ^ (nPos_Punto - nContador1 - nCte1)))
                    ''
                End If
                ''
            End If
            ''
        Next nContador1
        '
        If bCte2 = True Then
            De_Txt_a_Num_01 = (-1) * lNumeruco
            ''
        Else
            De_Txt_a_Num_01 = (1) * lNumeruco
            ''
        End If
        '
        If (nDecimales >= 0) Then De_Txt_a_Num_01 = Round(De_Txt_a_Num_01, nDecimales)
        '
        Exit Function
        '
Error_Numero:
        '
        '-------------------------------------------------§§§----'
        ' ERROR DE NUMERO
        '-------------------------------------------------§§§----'
        '
        De_Txt_a_Num_01 = -1.75E+308
        ''
    End Function


    ' función que retorna el total  
    Function SumarDatosDeGrilla(ByVal nombre_Columna As String, _
                                        ByVal Dgv As DataGridView) As Double

        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"  
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                total = total + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor  
        Return total

    End Function

    Function Sb_Llenar_Combos(ByVal _Arreglo(,) As String, ByVal _ComboBox As Object) As DataTable

        caract_combo(_ComboBox)

        Dim dt As New DataTable("Tabla1")
        Dim dr As DataRow
        Dim rs As New DataSet("Ds")

        'creamos las mismas columnas que hay en el dataset
        dt.Columns.Add("Padre", System.Type.[GetType]("System.String"))
        dt.Columns.Add("Hijo", System.Type.[GetType]("System.String"))

        Dim _Filas As Integer = (_Arreglo.Length / 2) - 1

        For i = 0 To _Filas
            Dim _Padre = _Arreglo(i, 0)
            Dim _Hijo = _Arreglo(i, 1)
            dr = dt.NewRow() : dr("Padre") = _Padre : dr("Hijo") = _Hijo : dt.Rows.Add(dr)
        Next
        rs.Tables.Add(dt)


        With _ComboBox
            .DataSource = Nothing
            .DataSource = dt
        End With

    End Function

    Function caract_combo(ByVal combo As Object, _
                          Optional ByVal Padre As String = "Padre", _
                          Optional ByVal Hijo As String = "Hijo")
        With combo
            '.datasourse = Nothing
            .ValueMember = Padre
            .DisplayMember = Hijo

            .AutoCompleteSource = AutoCompleteSource.ListItems
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .DropDownStyle = ComboBoxStyle.DropDownList

        End With
    End Function

    Function CMDCargaCombo(ByVal Combo As ComboBox, _
                           ByVal ConsultaSQl As String, _
                           ByVal Cnn As SqlConnection)
        Try

            'Cmbsucursal.DataSource = Nothing
            'Cmbbodega.DataSource = Nothing
            'Combo.DataSource = Nothing

            caract_combo(Combo)

            'Consulta_sql = "SELECT distinct Ubic_Columna AS Padre,Ubic_Columna AS Hijo FROM W_TmpUbicacionesBodega " & _
            '               "WHERE CodEmpresa = '" & CodEmpresa & "' AND CodSucursal = '" & CodSucursal & "' " & _
            '               "AND CodBodega = '" & CodBodega & "' AND Pasillo = '" & CodPasilloEstante & "' " & _
            '               "AND Ubic_Fila = '" & CodFila & "'"

            Combo.DataSource = get_Tablas(ConsultaSQl, cn1)

        Catch ex As Exception
            '     Nivel1 = "" : Nivel2 = "" : Nivel3 = ""
            '     Cmbnivel2.DataSource = Nothing
            '     Cmbnivel3.DataSource = Nothing
        End Try

    End Function

    Public Sub cargar_ListView( _
        ByRef ListView As ListView, _
        ByVal sql As String, _
        ByVal cn As SqlConnection)

        Try
            ' Crea y abre una nueva conexión
            'Using cn As New SqlConnection(cs & db)

            'cn.Open()

            ' propiedades del SqlCommand
            Dim comando As New SqlCommand

            With comando
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = cn
            End With

            Dim da As New SqlDataAdapter ' Crear nuevo SqlDataAdapter
            Dim dataset As New DataSet ' Crear nuevo dataset

            da.SelectCommand = comando

            ' llenar el dataset
            da.Fill(dataset, "tabla")

            ' Propiedades del ListView
            With ListView
                .Items.Clear()
                .Columns.Clear()
                .View = View.Details
                .GridLines = True
                .FullRowSelect = True
                ' añadir los nombres de columnas
                For c As Integer = 0 To dataset.Tables("tabla").Columns.Count - 1
                    .Columns.Add(dataset.Tables("tabla").Columns(c).Caption)
                Next
            End With

            ' Añadir los registros de la tabla
            With dataset.Tables("tabla")
                For f As Integer = 0 To .Rows.Count - 1

                    Dim dato As New ListViewItem(.Rows(f).Item(0).ToString)
                    ' recorrer las columnas
                    For c As Integer = 1 To .Columns.Count - 1
                        dato.SubItems.Add(.Rows(f).Item(c).ToString())
                    Next
                    ListView.Items.Add(dato)
                Next
            End With
            'End Using
            ' errores
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Function llena_tabla_sola(ByVal Arreglo(,) As String)

        Dim dt As New DataTable
        dt.Columns.Add("Padre")
        dt.Columns.Add("Hijo")

        Dim dr As DataRow = dt.NewRow

        ' LBound(Arreglo)

        For i = 0 To Arreglo.GetUpperBound(0)
            dr = dt.NewRow
            dr("Padre") = Arreglo(i, 0)
            dr("Hijo") = Arreglo(i, 1)
            dt.Rows.Add(dr)
            dt.AcceptChanges()
        Next

        Return dt
    End Function

    Public Function CADENA_A_BUSCAR(ByVal cadena As String, _
                             ByVal CAMPO As String, _
                             Optional ByVal _And_Or As String = "And") As String

        Dim linea1, linea2 As String
        Dim CONCATENA As String = ""
        Dim w As Integer

        For w = 1 To Len(cadena)
            linea1 = UCase(RTrim$(Mid(cadena, w, 1)))
            linea2 = LCase(linea1)

            If linea1 = "" Then
                CONCATENA = CONCATENA & "%' " & _And_Or & vbCrLf & CAMPO
            Else
                CONCATENA = CONCATENA & "[" & linea1 & linea2 & "]"
            End If
        Next
        CADENA_A_BUSCAR = CONCATENA
        'MsgBox CONCATENA
    End Function

    Function Cuentadias(ByVal FechaInicio As Date, _
                    ByVal FechaFin As Date, _
                    ByVal Diadelasemana As FirstDayOfWeek) As Integer

        Dim n As Integer
        Dim Fechaini As Date = FechaInicio

        Do Until FechaFin < Fechaini

            If Weekday(Fechaini) = Diadelasemana Then
                n = n + 1
            End If
            Fechaini = Fechaini.AddDays(1)
        Loop
        Return n

    End Function

    Function Inventariado(ByVal CodigoPrincipal As String, _
                      ByVal CodigoRapido As String, _
                      ByVal CodigoTecnico As String, _
                      ByVal CodBarraPR As String, _
                      ByVal DescripcionPR As String, _
                      ByVal CantidadInventariada As String, _
                      ByVal CodUbicacion As String, _
                      ByVal CodEmpresa As String, _
                      ByVal CodSucursal As String, _
                      ByVal CodBodega As String, _
                      ByVal DescripcionUbicacion As String, _
                      ByVal FuncionarioResponzable As String, _
                      ByVal FuncionarioContador As String, _
                     Optional ByVal ActualizarUbicBodega As Boolean = False) As Boolean
        Dim Fecha As String = Format(Now, "yyyyMMdd")

        Try

            Consulta_sql = "INSERT INTO W_TmpProductosInventariados (IdBodega,CodEmpresa,CodSucursal,CodBodega,SemillaUbicacion," & _
                           "UbicacionBodega,Codproducto,Codrapido,Codtecnico,DescripcionProducto,CodBarras,FechaInventario," & _
                           "CantidadInventariada,VecesInventariado,Observaciones,Responzable,Contador)" & vbCrLf & _
                           "VALUES (" & IdBodega & ",'" & CodEmpresa & "','" & CodSucursal & "','" & CodBodega & _
                           "'," & CodUbicacion & ",'" & DescripcionUbicacion & "','" & CodigoPrincipal & _
                           "'," & CodigoRapido & ",'" & CodigoTecnico & "','" & DescripcionPR & "','" & CodBarraPR & _
                           "',Getdate()," & CantidadInventariada & ",1,'" & ObservacionesInv & _
                           "','" & FuncionarioResponzable & "')"
            Ej_consulta_IDU(Consulta_sql, cn1)


            If ActualizarUbicBodega = True Then
                Consulta_sql = "UPDATE TABBOPR SET DATOSUBIC = '" & Mid(DescripcionUbicacion, 1, 20) & _
                               "' WHERE EMPRESA = '" & CodEmpresa & "' AND KOSU = '" & CodSucursal & _
                               "' AND KOBO = '" & CodSucursal & "' AND KOPR = '" & CodigoPrincipal & "'"
                Ej_consulta_IDU(Consulta_sql, cn1)
            End If
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function



    Function BuscarDatoEnGrilla(ByVal TextoABuscar As String, _
                                ByVal Columna As String, ByRef grid As DataGridView) As Boolean

        TextoABuscar = UCase(TextoABuscar)

        Dim encontrado As Boolean = False
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value.ToString() = TextoABuscar Then
                        row.Selected = True
                        Return True
                    End If
                Next
            Next
        Else
            Dim Descripcion As String
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False
                Descripcion = UCase(Trim(row.Cells(Columna).Value.ToString()))

                If BuscarTextoGrilla(Descripcion, TextoABuscar) Then
                    grid.ClearSelection()
                    grid.FirstDisplayedScrollingRowIndex = row.Index.ToString
                    grid.CurrentCell = grid.Rows(row.Index.ToString).Cells(Columna)
                    grid.Refresh()
                    row.Selected = True
                    Return True
                End If

            Next
        End If
        Return encontrado
    End Function




    Private Function BuscarTextoGrilla(ByVal Texto As String, ByVal Busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto, Busqueda)
        If i > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function TablaDePasoFiltro(ByVal cn As SqlConnection, _
                              ByVal TablaDePAso As String, _
                              ByVal Accion As String)
        'ZZW_TblPasoFiltro" & FUNCIONARIO & "
        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='" & TablaDePAso & "') BEGIN " & vbCrLf & _
                           "DROP TABLE " & TablaDePAso & " End " & vbCrLf

        If Accion = "Crear" Then
            Consulta_sql = Consulta_sql & "CREATE TABLE [dbo].[" & TablaDePAso & "]" & _
                          "([Codigo] [char](4) NOT NULL ) ON [PRIMARY]"
        End If
        Ej_consulta_IDU(Consulta_sql, cn)

    End Function

    Public Function TablaDePasoFiltroEntidades(ByVal cn As SqlConnection, ByVal Accion As String)

        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='ZZW_TblPasoEntExcluidas" & FUNCIONARIO & "') BEGIN " & vbCrLf & _
                           "DROP TABLE ZZW_TblPasoEntExcluidas" & FUNCIONARIO & " End " & vbCrLf


        If Accion = "Crear" Then
            Consulta_sql = Consulta_sql & "CREATE TABLE [dbo].[ZZW_TblPasoEntExcluidas" & FUNCIONARIO & "]" & _
                           "([Codigo] [char](10) NOT NULL,[Sucursal] [char](20) NOT NULL,[Razon] [varchar](50) NOT NULL ) ON [PRIMARY]"
        End If
        Ej_consulta_IDU(Consulta_sql, cn)

    End Function

    Public Function TablaDePasoVarianza(ByVal cn As SqlConnection, ByVal Accion As String)


        Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='W_VARIANZA_PASO" & FUNCIONARIO & "') BEGIN " & vbCrLf & _
                           "DROP TABLE W_VARIANZA_PASO" & FUNCIONARIO & " End " & vbCrLf


        If Accion = "Crear" Then
            Consulta_sql = Consulta_sql & "CREATE TABLE [dbo].[W_VARIANZA_PASO" & FUNCIONARIO & "]" & _
                           "([Valor] [Float] NULL) ON [PRIMARY]"
        End If
        Ej_consulta_IDU(Consulta_sql, cn)
    End Function

    Public Function TablaDePasoFechas(ByVal cn As SqlConnection, ByVal Accion As String)
        Try

            Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='ZZW_TblPasoFechas" & FUNCIONARIO & "') " & vbCrLf & _
                           "DROP TABLE ZZW_TblPasoFechas" & FUNCIONARIO & vbCrLf & _
                           "IF EXISTS (SELECT * FROM sysobjects WHERE name='IX_ZZW_TblPasoFechas" & FUNCIONARIO & "') " & vbCrLf & _
                           "DROP INDEX ZZW_TblPasoFechas" & FUNCIONARIO & ".IX_ZZW_TblPasoFechas" & FUNCIONARIO & vbCrLf & _
                           "IF EXISTS (SELECT * FROM sysobjects WHERE name='IX1_ZZW_TblPasoFechas" & FUNCIONARIO & "') " & _
                           "DROP INDEX ZZW_TblPasoFechas" & FUNCIONARIO & ".IX1_ZZW_TblPasoFechas" & FUNCIONARIO & vbCrLf

            If Accion = "Crear" Then
                Consulta_sql = Consulta_sql & "CREATE TABLE [dbo].[ZZW_TblPasoFechas" & FUNCIONARIO & _
                               "]([Rango] [char](2) NOT NULL ,[Fecha1] [Date] NOT NULL,[Fecha2] [Date] NOT NULL ) ON [PRIMARY]" & vbCrLf & _
                               "CREATE UNIQUE NONCLUSTERED INDEX [IX_ZZW_TblPasoFechas" & FUNCIONARIO & _
                               "] ON [dbo].[ZZW_TblPasoFechas" & FUNCIONARIO & "] ([Fecha1])" & vbCrLf & _
                               "CREATE UNIQUE NONCLUSTERED INDEX [IX1_ZZW_TblPasoFechas" & FUNCIONARIO & _
                               "] ON [dbo].[ZZW_TblPasoFechas" & FUNCIONARIO & "] ([Fecha1])"
            End If

            'MsgBox(Consulta_sql)
            Ej_consulta_IDU(Consulta_sql, cn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Function GrabarFiltros(ByVal TablaDePaso As String)

        Consulta_sql = "SELECT * FROM TmpFiltros WHERE Tickeado = True AND Tipo = '" & TipoFiltro & "'"
        Ejecutar_consulta_SQLaccess(Consulta_sql)

        Dim TblDetalle As DataTable = New DataTable
        dbD.Fill(TblDetalle)

        Dim dr As DataRow '= 'TblDetalle.Rows(0)
        Dim Filas As Long

        Filas = TblDetalle.Rows.Count
        If Filas > 0 Then

            Consulta_sql = "TRUNCATE TABLE " & TablaDePaso
            Ej_consulta_IDU(Consulta_sql, cn1)

            For i As Integer = 0 To Filas - 1
                dr = TblDetalle.Rows(i)
                Dim Codigo As String
                Codigo = dr.Item("CODIGO").ToString
                Consulta_sql = "INSERT INTO " & TablaDePaso & " (Codigo) VALUES ('" & Trim(Codigo) & "')"
                Ej_consulta_IDU(Consulta_sql, cn1)

            Next
        End If

    End Function

    Public Function EliminarTablasDePaso()
        'TablaDePasoFiltro(cn1, TablaDePasoBodegas, "")
        'TablaDePasoFiltro(cn1, TablaDePasoProEstrellas, "")
        'TablaDePasoFiltroEntidades(cn1, "")
        'TablaDePasoFechas(cn1, "")
        'TablaDePasoFiltro(cn1, "W_PASO_STOCKPR" & FUNCIONARIO, "")
        TablaDePasoFiltro(cn1, "W_PERIODO_PASO" & FUNCIONARIO, "")
        TablaDePasoFiltro(cn1, "W_PERIODO_PASOPrecio" & FUNCIONARIO, "")
        TablaDePasoFiltro(cn1, "W_VARIANZA_PASO" & FUNCIONARIO, "") '
        TablaDePasoFiltro(cn1, "Zw_Tbl_PasoOCC" & FUNCIONARIO, "")
    End Function


    Function VisualizarFormulario(ByVal Formulario As Object, _
                                  ByVal FormularioPadre As Form, _
                                  Optional ByVal VerEnShowDialong As Boolean = True, _
                                  Optional ByVal EsMDI As Boolean = False _
                                  )

        If EsMDI = True Then
            Formulario.MdiParent = FormularioPadre
            If Formulario Is Nothing Then
                Formulario.Show()
            ElseIf Not Formulario.Visible Then
                Formulario.Show()
            Else
                Formulario.Focus()
            End If
        Else

            If VerEnShowDialong = True Then
                If Formulario Is Nothing Then
                    Formulario.ShowDialog(FormularioPadre)
                ElseIf Not Formulario.Visible Then
                    Formulario.ShowDialog(FormularioPadre)
                Else
                    Formulario.Focus()
                End If
            Else
                If Formulario Is Nothing Then
                    Formulario.Show()
                ElseIf Not Formulario.Visible Then
                    Formulario.Show()
                Else
                    Formulario.Focus()
                End If
            End If
        End If


    End Function

    Public Sub _Configuracion_Regional_(Optional ByVal _Moneda As String = "$")

        'despues en el load del formulario inicial de la aplicacion escriben esto 

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CL")
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = _Moneda
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        ' SEPARADOR DE DECIMALES MONEDA
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        ' SEPARADOR DE DECIMALES EN NUMEROS
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."

    End Sub


    Public Sub Validar_Keypress_Nros_Grilla(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  
        'With Grilla
        'Dim Cabeza = .Columns(.CurrentCell.ColumnIndex).Name
        'Dim Codigo = .Rows(.CurrentRow.Index).Cells("Codigo").Value
        'Dim Descripcion = .Rows(.CurrentRow.Index).Cells("Descripcion").Value
        Dim caracter As Char = e.KeyChar

        If e.KeyChar = "."c Then
            ' si se pulsa la coma se convertirá en punto
            'e.Handled = True
            SendKeys.Send(",")
            e.KeyChar = ","c
            caracter = ","
        End If

        ' comprobar si la celda en edición corresponde a la columna 1 o 2
        'If Cabeza = "CantComprar" Then
        ' Obtener caracter  

        ' referencia a la celda  
        Dim txt As TextBox = CType(sender, TextBox)

        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        If (Char.IsNumber(caracter)) Or _
        (caracter = ChrW(Keys.Back)) Or _
        (caracter = ",") And _
        (txt.Text.Contains(",") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        'End If
        'End With
    End Sub

    Public Function Fx_Rellena_ceros(ByVal _NroDoc As String, _
                                    ByVal _NroCaracateres As Integer, _
                                    Optional ByVal _Suma_uno As Boolean = False) As String

        Dim _Contador = 1
        Dim _Tot_carac = Len(_NroDoc)


        Do While _Contador < _NroCaracateres
            Dim _Pl = Microsoft.VisualBasic.Strings.Right(_NroDoc, _Contador)
            If Not IsNumeric(_Pl) Then
                Exit Do
            End If

            _Contador += 1
        Loop

        Dim _Cadena As String
        Dim _Cadena2 = Microsoft.VisualBasic.Strings.Right(_NroDoc, _Contador - 1)

        If _Cadena2 = _NroDoc Then
            _Cadena = numero_(_Cadena2, _NroCaracateres)
            Return _Cadena
        End If


        Dim _Cadena1 = Mid(_NroDoc, 1, _Tot_carac - (_Contador - 1))

        If _Suma_uno Then _Cadena2 += 1

        If String.IsNullOrEmpty(_Cadena2) Then
            Return _Cadena1
        End If

        Dim _nr = Len(_Cadena1)

        _Cadena = _Cadena1 & numero_(_Cadena2, _NroCaracateres - _nr)

        Return _Cadena

    End Function

    Function _Dev_HoraGrab(ByVal Hora As String)

        Dim _HH, _MM, _SS As Double
        Dim _Horagrab As Integer

        _HH = Mid(Hora, 1, 2)
        _MM = Mid(Hora, 4, 2)
        _SS = Mid(Hora, 7, 2)

        _Horagrab = Math.Round((_HH * 3600) + (_MM * 60) + _SS, 0)

        Return _Horagrab

    End Function

    Function Trae_Datos_Entidad(ByVal _CodEntidad As String, _
                                ByVal _CodSucursal As String) As DataTable

        Consulta_sql = "Select *," & _
                       "(Select NOKOCI From TABCI Where KOPA = PAEN And KOCI = CIEN) As CIUDAD," & _
                       "(Select NOKOCM From TABCM Where KOPA = PAEN And KOCI = CIEN And KOCM = CMEN) As COMUNA" & vbCrLf & _
                       "From MAEEN" & vbCrLf & _
                       "Where KOEN = '" & _CodEntidad & "' And SUEN = '" & _CodSucursal & "'"

        Dim Tbl_ As DataTable = get_Tablas(Consulta_sql, cn1)

        Return Tbl_

    End Function

    Function Fx_Dias_Habiles(ByVal _Fecha_inicial As Date, ByVal _Fecha_final As Date) As Integer

        Dim dias As Integer
        _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial) 'agrego un dia adicional para la cuenta ya veraz porque 

        Dim dha As Integer = DateDiff(DateInterval.Day, _Fecha_inicial, _Fecha_final)

        Dim _Dia As Integer
        For _x = 0 To dha '- 1
            _Dia = Weekday(_Fecha_inicial)
            If _Dia <> "1" And _Dia <> "7" Then
                dias += 1
            End If
            _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial)
        Next

        Return dias

    End Function

    Enum Opcion_Dias
        Habiles
        Lunes
        Marte
        Miercoles
        Jueves
        Viernes
        Sabado
        Domingo
        Todos
    End Enum

    Function Fx_Cuenta_Dias(ByVal _Fecha_inicial As Date, _
                            ByVal _Fecha_final As Date, _
                            ByVal _Dias_a_contar As Opcion_Dias) As Integer

        Dim dias As Integer
        _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial) 'agrego un dia adicional para la cuenta ya veraz porque 

        Dim dha As Integer = DateDiff(DateInterval.Day, _Fecha_inicial, _Fecha_final)

        Dim _Dia As Integer
        For _x = 0 To dha '- 1
            _Dia = Weekday(_Fecha_inicial)

            Select Case _Dias_a_contar
                Case Opcion_Dias.Habiles
                    If _Dia <> "1" And _Dia <> "7" Then
                        dias += 1
                    End If
                Case Opcion_Dias.Todos
                    dias = dha 'dias += 1
                    Exit For
                Case Else
                    If _Dia = _Dias_a_contar Then
                        dias += 1
                    End If
            End Select

            _Fecha_inicial = DateAdd(DateInterval.Day, 1, _Fecha_inicial)

        Next

        Return dias

    End Function

    Function Fx_Crea_Tabla_Con_Filtro(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable

        Dim rows As DataRow()

        Dim dtNew As DataTable

        ' copy table structure
        dtNew = dt.Clone()

        ' sort and filter data
        rows = dt.Select(filter, sort)

        ' fill dtNew with selected rows

        For Each dr As DataRow In rows
            dtNew.ImportRow(dr)
        Next

        ' return filtered dt
        Return dtNew

    End Function

    ' Dim _Existe As Boolean = System.IO.File.Exists(Directorio & RutEmpresa & "\Configuracion_Local\Base_BakApp.xml")

    Function Fx_Revisar_Nombre_Equipo_BakApp(ByVal _Formulario As Form, _
                                             ByVal _Dir_Empresa As String, _
                                             ByVal _Rut_Empresa As String, _
                                             ByVal _Nombre_Equipo As String) As Boolean

        Dim _Ds As New DatosBakApp

        Dim _Existe = System.IO.File.Exists(_Dir_Empresa & "\Nombre_Equipo.xml")

        If Not _Existe Then

            MessageBoxEx.Show(_Formulario, "El equipo no está registrado en el sistema" & vbCrLf & _
                              "Debe ingresar un nombre al equipo (se sugiere dejar el mismo nombre por defecto)", _
                              "Llave de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)

            _Nombre_Equipo = InputBox_Bk(_Formulario, "Debe ingresar un nombre al equipo" & vbCrLf & _
                                         "(se sugiere dejar el mismo)" & vbCrLf & _
                                         "Ingrese nombre de la estación de trabajo", _
                                         "El equipo no está registrado en el sistema", _Nombre_Equipo, False, _
                                         _Tipo_Mayus_Minus.Normal, 0, True, _Tipo_Imagen.Texto, False)

            If _Nombre_Equipo = "@@Accion_Cancelada##" Then
                Return False
            Else

                Dim _Sigue As Boolean
                Dim _Nro = 0

                Do
                    Dim _Reg = Cuenta_registros(_Global_BaseBk & "Zw_EstacionesBkp", "NombreEquipo = '" & _Nombre_Equipo & "'")

                    If CBool(_Reg) Then
                        _Nombre_Equipo = _Nombre_Equipo & "_" & numero_(_Nro + 1, 2)
                        _Sigue = True
                    Else
                        _Sigue = False
                    End If

                Loop While _Sigue



                Dim NewFila As DataRow
                NewFila = _Ds.Tables("Tbl_Nombre_Equipo").NewRow
                With NewFila
                    .Item("Nombre_Equipo") = _Nombre_Equipo
                End With

                _Ds.Tables("Tbl_Nombre_Equipo").Rows.Add(NewFila)
                _Ds.WriteXml(_Dir_Empresa & "\Nombre_Equipo.xml")
            End If
            Return True
        Else
            Return True
            ' _Ds.Clear()
            ' _Ds.ReadXml(_Dir_Empresa & "\Nombre_Equipo.xml")
            'Fx_Revisar_Nombre_Equipo_BakApp
        End If

    End Function


    Function Fx_Validar_Email(ByVal email As String) As Boolean

        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)

    End Function

    Function Fx_Validar_Sitio_Web(ByVal _Sitio As String) As String 'As Boolean

        Dim Peticion As System.Net.WebRequest
        Dim Respuesta As System.Net.HttpWebResponse

        Dim _Respuestas As String

        Try
            Peticion = System.Net.WebRequest.Create(_Sitio) 'La direccion debe tener el formato ('http://www.direccion.com, es, net, org, vns, etc...))
            Respuesta = Peticion.GetResponse()
            _Respuestas = Respuesta.StatusDescription
            ' Return True
        Catch ex As System.Net.WebException
            _Respuestas = ex.Message
            If ex.Status = Net.WebExceptionStatus.NameResolutionFailure Then

                'Return False
            End If
        End Try

        Return _Respuestas

    End Function

    Sub Sb_Txt_KeyPress_Solo_Numeros(ByVal sender As System.Object, _
                                     ByVal e As System.Windows.Forms.KeyPressEventArgs)


        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

        Return
        Dim _Texto = CType(sender, TextBox)

        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

        Dim caracter As Char = e.KeyChar

        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
        ' es el separador decimal, y que no contiene ya el separador  
        If (Char.IsNumber(caracter)) Or _
        (caracter = ChrW(Keys.Back)) Or _
        (caracter = ",") And _
        (_Texto.Text.Contains(",") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

#Region "CAMBIAR COLOR DE PALABRA EN TEXTO"

    Sub Sb_Cambiar_Color(ByVal _Posicion As Integer, _
                         ByVal _Texto As DevComponents.DotNetBar.Controls.RichTextBoxEx, _
                         ByVal _Tbl As DataTable, _
                         Optional ByVal _Campo As String = "CodigoTabla")

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Fx As String = Trim(_Fila.Item(_Campo))

            _Fx = QuitaEspacios_ParaCodigos(_Fx, Len(_Fx))

            Fx_Cambiar_Color(_Fx, Color.Blue, _Texto, _Posicion)

        Next

        _Texto.ForeColor = Color.Black

        '_Texto.SelectionStart = _Posicion
        '_Texto.SelectionLength = 0

    End Sub

    Private Function Fx_Cambiar_Color(ByVal _Palabra As String, _
                                      ByVal _Color As Color, _
                                      ByVal _Texto As DevComponents.DotNetBar.Controls.RichTextBoxEx, _
                                      ByVal _Posicion As Long) As Boolean

        Dim _Fx = _Palabra
        Dim _LargoFx = Len(_Fx)

        Dim _Cadena As String = _Texto.Text

        For i = 0 To _Posicion '_Texto.TextLength

            Dim _Resto = _Texto.TextLength - i

            If _Resto > _LargoFx Then
                Dim _Cadena_Extraida = _Cadena.Substring(i, _LargoFx)
                If _Cadena_Extraida = _Fx Then

                    Dim currentFont As System.Drawing.Font = _Texto.SelectionFont
                    'Dim newFontStyle As System.Drawing.FontStyle

                    With _Texto
                        .Select(i, _LargoFx)
                        _Texto.SelectionColor = _Color
                        .SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold)
                        '.Select(0, 0)
                    End With
                    i += 1
                End If
            End If

        Next

    End Function


#End Region

    Function Fx_Validar_Impresora(ByVal _Impresora As String) As Boolean

        Dim pd As New PrintDocument

        For i = 1 To PrinterSettings.InstalledPrinters.Count '– 1

            Dim _Impresora_De_Lista = PrinterSettings.InstalledPrinters.Item(i - 1).ToString '_Lista_Impresoras.Items.Item(i - 1).ToString

            If Trim(_Impresora) = Trim(_Impresora_De_Lista) Then
                Return True
            End If

        Next

    End Function



End Module








