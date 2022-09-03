'Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
'Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports Docs.Excel

Imports Microsoft.Office.Interop
Imports System.Data.OleDb


#Region "CLASES"

Public Class SQL_Server


    Sub Sb_Abrir_Conexion_SQLServer(ByVal ConexionSQL As SqlConnection, _
                                    ByVal _BaseDatos_SQL As String, _
                                    Optional ByVal MostrarError As Boolean = True)

        Dim _sCnn = "data source = " & Servidor_SQL & "; initial catalog = " & _BaseDatos_SQL & _
                             "; user id = " & Usuario_SQL & "; password = " & Clave_SQL

        Try
            If ConexionSQL.State = ConnectionState.Open Then
                ConexionSQL.Close()
            End If

            ConexionSQL.ConnectionString = _sCnn
            ConexionSQL.Open()

        Catch ex As SqlClient.SqlException 'Exception
            If MostrarError = True Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub



    Sub AbrirConexion_SQLServer(ByVal ConexionSQL As SqlConnection, _
                                Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                Optional ByVal CadenaLocal As String = "", Optional ByVal MostrarError As Boolean = True)

        'Dim ConexionSQL As SqlConnection
        Dim sCnn As String = ""

        If String.IsNullOrEmpty(Servidor_SQL) Then
            If BaseConexion = 1 Then
                sCnn = Cadena_ConexionSQL_Server
            ElseIf BaseConexion = 2 Then
                sCnn = Cadena_ConexionSQL_Server_Base_Paso
            ElseIf BaseConexion = 3 Then
                sCnn = CadenaLocal
            End If
        Else
            sCnn = "data source = " & Servidor_SQL & "; initial catalog = " & BaseDatos_SQL & _
                                 "; user id = " & Usuario_SQL & "; password = " & Clave_SQL
        End If

        Try
            If ConexionSQL.State = ConnectionState.Open Then
                ' Cerrar conexion
                ConexionSQL.Close()
            End If

            ConexionSQL.ConnectionString = sCnn
            ConexionSQL.Open()
            'MsgBox(sCnn)

        Catch ex As SqlClient.SqlException 'Exception
            If MostrarError = True Then
                MsgBox(ex.Message)
                'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
                '                ex.Message, "Conectar con la base", _
                '                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Try
    End Sub

    Sub CerrarConexion(ByVal ConexionSQL As SqlConnection)
        Try
            If ConexionSQL.State = ConnectionState.Open Then
                '' Cerrar conexion
                ConexionSQL.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "PROCEDIMIENTO QUE EJECUTA INSERT, UPDATE Y DELETE EN LA BASE DE DATOS DE SQL"
    Public Function Ej_consulta_IDU(ByVal ConsultaSql As String, _
                                    ByVal cn As SqlConnection, _
                                    Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal)
        Try
            AbrirConexion_SQLServer(cn, BaseConexion)
            Dim cmd As System.Data.SqlClient.SqlCommand
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.Connection = cn
            cmd.CommandText = _
                ConsultaSql
            'cmd = New System.Data.SqlServerCe.SqlCeCommand(sqlCreateTableStatement, connection)
            cmd.ExecuteNonQuery()
            CerrarConexion(cn)
        Catch ex As Exception
            MsgBox("No se realizo la operación: Insert, Update o Delete..." _
                   , MsgBoxStyle.Critical, "Modificar Datos Motor SQL Server")
            MsgBox(ex.Message)
        End Try

    End Function
#End Region

#Region "PROCEDIMIENTO QUE EJECUTA UN COMADO SELECT EN LA BASE Y TRAE COMO RESULTADO UNA TABLA CON REGISTROS"
    Function LlenarTabla_SQLServer(ByVal SQL As String, _
                                   ByVal Cnn As SqlConnection, _
                                   Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal) As DataTable
        Try
            Dim DSCE As New DataSet
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            da = New SqlDataAdapter(SQL, Cnn)
            tb = New DataTable
            da.Fill(tb)
            Return tb

        Catch ex As Exception
            MsgBox(ex.Message)
            'MessageBox.Show("ERROR al conectar o recuperar los datos:" & vbCrLf & _
            '                ex.Message, "Conectar con la base", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
#End Region

#Region "PROCEDIMIENTO PARA EDITAR TABLA DE SQL DESDE UNA GRILLA"

    Function ActualizarGrillaUpInsDel(ByVal ConsultaSQLGrilla As String, _
                                      ByVal Grilla As Object, _
                                      ByVal Cnn As SqlConnection, _
                                      Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal, _
                                      Optional ByVal EsGrilla As Boolean = True)
        Try
            'Abrimos la conexión con SQL
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            Dim dt As DataTable

            If EsGrilla Then
                dt = DirectCast(Grilla.DataSource, DataTable)
            Else
                dt = Grilla
            End If

            ' Procedemos a actualizar la base de datos.
            Dim n As Integer = UpInsDelDatabase(dt, ConsultaSQLGrilla, Cnn)
            CerrarConexion(Cnn)
            Return n
            'MessageBox.Show("Nº de registros afectados: " & CStr(n))
        Catch ex As Exception
            ' Se ha producido un error
            CerrarConexion(Cnn)
            MessageBox.Show(ex.Message)

        End Try
    End Function


    Function ActualizaTablaSQLUpInsDel(ByVal ConsultaSQLGrilla As String, _
                                       ByVal dt As DataTable, _
                                       ByVal Cnn As SqlConnection, _
                                       Optional ByVal BaseConexion As Integer = ArchivoConexion.BasePrincipal)
        Try
            'Abrimos la conexión con SQL
            AbrirConexion_SQLServer(Cnn, BaseConexion)
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.

            'Dim dt As DataTable = DirectCast(Grilla.DataSource, DataTable)
            ' Procedemos a actualizar la base de datos.
            Dim n As Integer = UpInsDelDatabase(dt, ConsultaSQLGrilla, Cnn)
            CerrarConexion(Cnn)
            Return n
            'MessageBox.Show("Nº de registros afectados: " & CStr(n))
        Catch ex As Exception
            ' Se ha producido un error
            CerrarConexion(Cnn)
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Function UpInsDelDatabase(ByVal dt As DataTable, _
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

#End Region

End Class

Public Class ClaseConectaAccess


    Public strConexion As String
    Public cnnConex As OleDb.OleDbConnection
    Public comand As OleDb.OleDbCommand
    Public dtrDatos As OleDb.OleDbDataReader
    Public Cb As OleDbCommandBuilder

    Public dbDataAdapter As OleDbDataAdapter


    Sub abrirConexion(Optional ByVal nombreBaseDatos As String = "Tmptools.mdb", Optional ByVal Ruta As String = "")
        Try



            Ruta = AppPath(True) & "Data"

            strConexion = ("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
                                               Ruta & "\" & nombreBaseDatos)
            '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ".\tu bd"
            cnnConex = New OleDb.OleDbConnection(strConexion)
            cnnConex.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'consultas insert,delete,update
    Sub consultaAccion(ByVal consulta As String) 'para hacer las consultar

        Try
            comand = New OleDb.OleDbCommand(consulta, cnnConex)
            System.Windows.Forms.Application.DoEvents()
            comand.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Function ConsultaSelectAccess(ByVal SQL As String, _
                                  Optional ByVal nombreBaseDatos As String = "Tmptools.mdb", _
                                  Optional ByVal Ruta As String = "")




        Ruta = AppPath(True) & "Data"
       
        strConexion = ("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
                                           Ruta & "\" & nombreBaseDatos)

        'abrirConexion()
        'strConexion = ("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
        '                                       AppPath(True) & "Data\" & nombreBaseDatos)
        ' Comprobar si hay algún error
        Try

            'dbD = New OleDbDataAdapter(SQL, Ruta)
            ' Crear un nuevo objeto del tipo DataAdapter
            'Dim cnn As New OleDbConnection(sCnn)
            dbD = New OleDbDataAdapter(SQL, strConexion)
            'Return dbDataAdapter
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function


    Sub cerrarConexion()
        Try
            cnnConex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



End Class

Public Class CrearDocumentoRandom

    Dim Codempresa As String
    Dim Codsucursal As String
    Dim NuevoNroDocumento As String
    Dim CodEntidad As String
    Dim Nudonodefi As Integer
    Dim Tipodocumento As String


    Dim NULIDO As String
    Dim BOSULIDO As String
    Dim KOPRCT As String
    Dim RLUDPR As String
    Dim TIPR As String

    'DIM ARCHIRST AS string = ''
    Dim SULIDO As String
    Dim KOFULIDO As String
    Dim CAPRCO1 As String
    Dim CAPRAD1 As String
    Dim CAPREX1 As String
    Dim CAPRNC1 As String
    Dim UD01PR As String
    Dim UDTRPR As String
    Dim CAPRCO2 As String
    Dim CAPRAD2 As String
    Dim CAPREX2 As String
    Dim CAPRNC2 As String
    Dim UD02PR As String
    Dim KOLTPR As String
    Dim MOPPPR As String
    Dim TIMOPPPR As String
    Dim TAMOPPPR As String
    Dim PPPRNELT As String
    Dim PPPRNE As String
    Dim PPPRBRLT As String
    Dim PPPRBR As String
    Dim PODTGLLI As String
    Dim POIMGLLI As String
    Dim VADTNELI As String
    Dim VADTBRLI As String
    Dim POIVLI As String
    Dim VAIVLI As String
    Dim VAIMLI As String
    Dim VANELI As String
    Dim VABRLI As String
    Dim FEEMLI As String
    Dim FEERLI As String

    Dim PPPRPM As String
    Dim PPPRNERE1 As String
    Dim PPPRNERE2 As String
    Dim NOKOPR As String
    Dim PPOPPR As String
    Dim LINCONDESP As String
    Dim PPPRPMSUC As String

    Sub GrabarDatos(ByVal Empresa As String, _
                        ByVal Sucursal As String, _
                        ByVal Bodega As String, _
                        ByVal ListaDeCosto As String, _
                        ByVal TIDO As String, _
                        ByVal BarEncabezados As Object, _
                        ByVal BarDetalle As Object, _
                        ByVal TxtProducto As TextBox, _
                        ByVal TxtProveedor As TextBox, _
                        ByVal TablaDePaso As String)

        Consulta_sql = "SELECT CodEntidad, CodSucursal FROM " & TablaDePaso & " WHERE Marca = '' and Fcc <> ''"
        Ejecutar_consulta_SQL(Consulta_sql, cn1)

        Dim tb1 = New DataTable
        da.Fill(tb1)

        Dim dfd As DataRow

        Dim CanFilas As Long = tb1.Rows.Count

        BarEncabezados.Maximum = CanFilas

        If tb1.Rows.Count > 0 Then

            Dim CodEnt As String
            Dim SucEnt As String

            For i As Integer = 0 To tb1.Rows.Count - 1
                System.Windows.Forms.Application.DoEvents()
                dfd = tb1.Rows(i)
                CodEnt = dfd.Item("CodEntidad").ToString
                SucEnt = dfd.Item("CodSucursal").ToString

                Dim Sigue As Long = 0

                Sigue = Cuenta_registros(TablaDePaso, "Marca = '' and CodEntidad = '" & CodEnt & _
                                         "' and CodSucursal = '" & SucEnt & "'")


                While Sigue <> 0

                    Consulta_sql = "TRUNCATE TABLE Tbl_PasoGrab"
                    Ej_consulta_IDU(Consulta_sql, cn1)

                    Consulta_sql = "SELECT top 20 CodEntidad, CodSucursal, Codigo, Comprar, CostoFcc,RazonSocial " & _
                                   "FROM " & TablaDePaso & vbCrLf & _
                                   "WHERE CodEntidad = '" & CodEnt & "' and CodSucursal = '" & SucEnt & "' " & _
                                   "and Marca = ''"
                    Ejecutar_consulta_SQL(Consulta_sql, cn1)

                    tb2 = New DataTable
                    da.Fill(tb2)

                    Dim dfd2 As DataRow '
                    Dim CodEnt2 As String
                    Dim SucEnt2 As String
                    Dim CodigoPR As String
                    Dim CantidadPR As String
                    Dim CostoPR As String

                    If tb2.Rows.Count > 0 Then
                        For u As Integer = 0 To tb2.Rows.Count - 1
                            dfd2 = tb2.Rows(u)
                            CodEnt2 = dfd2.Item("CodEntidad").ToString
                            SucEnt2 = dfd2.Item("CodSucursal").ToString
                            CodigoPR = dfd2.Item("Codigo").ToString
                            CantidadPR = De_Num_a_Tx_01(dfd2.Item("Comprar").ToString, False, 2)
                            CostoPR = De_Num_a_Tx_01(dfd2.Item("CostoFcc").ToString, False, 2)

                            TxtProveedor.Text = dfd2.Item("RazonSocial").ToString

                            Consulta_sql = "INSERT INTO Tbl_PasoGrab (ENDO,SUENDO,KOPR,CANTIDAD,PRECIO,BOSULIDO) VALUES " & _
                                           "('" & CodEnt2 & "','" & SucEnt2 & "','" & CodigoPR & _
                                           "'," & CantidadPR & "," & CostoPR & ",'" & Bodega & "')"
                            Ej_consulta_IDU(Consulta_sql, cn1)

                            Consulta_sql = "UPDATE " & TablaDePaso & " SET Marca = 'X' WHERE " & _
                                           "CodEntidad = '" & CodEnt & _
                                           "' and CodSucursal = '" & SucEnt & _
                                           "' and Codigo = '" & CodigoPR & "'"
                            Ej_consulta_IDU(Consulta_sql, cn1)


                        Next
                        Dim Nro As String
                        Nro = numero_(Val(trae_dato(tb, cn1, "COALESCE(MAX(NUDO),'0000000000')+1", "MAEEDO  WITH ( NOLOCK )", _
                                        "TIDO='OCC'  AND EMPRESA = '" & Empresa & "'")), 10)


                        'GrabarDocumentoRandom(cn1, Empresa, Sucursal, TIDO, Nro, CodEnt, SucEnt, ListaDeCosto, BarDetalle)


                    End If

                    Sigue = Cuenta_registros("Tbl_PasoCompras", "Marca = '' and CodEntidad = '" & CodEnt & _
                                         "' and CodSucursal = '" & SucEnt & "'")

                End While
                BarEncabezados.Value += 1
            Next
            BarEncabezados.value = 0
            MsgBox("Proceso terminado correctamemte", MsgBoxStyle.Information, "Generer Ordenes de Compra")
        Else
            MsgBox("No hay mas datos que insertar", MsgBoxStyle.Information, "Generar Ordenes de Compra")
        End If

    End Sub

    Function GrabarDocumentoRandom(ByVal Cnn As SqlConnection, _
                                   ByVal EMPRESA As String, _
                                   ByVal SUCURSAL As String, _
                                   ByVal TIDO As String, _
                                   ByVal NUDO As String, _
                                   ByVal ENDO As String, _
                                   ByVal SUENDO As String, _
                                   ByVal LISTADEPRECIO As String, _
                                   ByVal BAR As Object, _
                                   ByVal TablaDePaso As String)

        Dim Cadena_Conexion As String = _
                     Ruta_conexion(AppPath(True) & "Cadena_conexion.txt")
        Conectar_SQL("", "", "", "", cn2, Cadena_Conexion)


        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim IDMAEEDO As String

        Try


            myTrans = cn2.BeginTransaction()

            CrearEncabezadoInsertar(EMPRESA, TIDO, NUDO, ENDO)
            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                IDMAEEDO = dfd1("Identity")
            End While
            dfd1.Close()

            Consulta_sql = "SELECT * FROM " & TablaDePaso
            Ejecutar_consulta_SQL(Consulta_sql, cn1)

            'Comando.Transaction = myTrans
            'Dim dfd As SqlDataReader = Comando.ExecuteReader()
            'dfd = Comando.ExecuteReader()

            'Dim i As Integer = 0
            Dim CantidadTotal As String = 0
            Dim TotalNeto As String = 0
            Dim TotalIva As String = 0
            Dim TotalBruto As String = 0

            tb = New DataTable
            da.Fill(tb)

            Dim dfd As DataRow '
            Dim CantFilas As Long = tb.Rows.Count
            BAR.Maximum = CantFilas
            Dim RTU As Double

            For i As Integer = 0 To tb.Rows.Count - 1
                System.Windows.Forms.Application.DoEvents()
                dfd = tb.Rows(i)
                NULIDO = numero_(i + 1, 5)
                BOSULIDO = dfd.Item("BOSULIDO").ToString
                KOPRCT = dfd.Item("KOPR").ToString
                RTU = trae_dato(tb, cn1, "RLUD", "MAEPR", "KOPR = '" & KOPRCT & "'")
                RLUDPR = De_Num_a_Tx_01(RTU, False, 3)

                ' ARCHIRST  = ''
                SULIDO = SUCURSAL 'Codsucursal '
                KOFULIDO = FUNCIONARIO ' Codigo de funcionario
                CAPRCO1 = De_Num_a_Tx_01(dfd.Item("CANTIDAD").ToString, False, 2) ' Cantidad de primera Unidad
                TIPR = trae_dato(tb, cn1, "TIPR", "MAEPR", "KOPR = '" & KOPRCT & "'") ' Unidad 1
                CantidadTotal = CantidadTotal + Val(CAPRCO1)

                CAPRAD1 = 0 ' Cantidad que mueve Stock Fisico, sefún el producto.
                CAPREX1 = 0 ' Cantidad 
                CAPRNC1 = 0 ' Cantidad de Nota de credito
                UD01PR = trae_dato(tb, cn1, "UD01PR", "MAEPR", "KOPR = '" & KOPRCT & "'") ' Unidad 1
                UDTRPR = dfd.Item("UnidadDeTransaccion").ToString ' Unidad de la transaccion
                CAPRCO2 = De_Num_a_Tx_01(Val(CAPRCO1) * RTU, False, 2) ' Cantidad de la segunda unidad
                CAPRAD2 = 0
                CAPREX2 = 0
                CAPRNC2 = 0
                UD02PR = trae_dato(tb, cn1, "UD02PR", "MAEPR", "KOPR = '" & KOPRCT & "'")
                KOLTPR = LISTADEPRECIO
                MOPPPR = trae_dato(tb, cn1, "KOMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                TIMOPPPR = trae_dato(tb, cn1, "TIMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                TAMOPPPR = trae_dato(tb, cn1, "VAMO", "TABMO", "NOKOMO LIKE '%PESO%'")
                PPPRNELT = 0 ' trae_dato(tb,cn1,"" 
                PPPRNE = De_Num_a_Tx_01(dfd.Item("PRECIO").ToString, False, 2)
                PPPRBRLT = 0 ' PRECIO BRUTO DE LA LISTA
                PPPRBR = De_Num_a_Tx_01(PPPRNE * (1 + (POIVLI / 100)), False, 2) ' PRECIO BRUTO DE LA TRANSACCION
                PODTGLLI = 0 'PORCENTAJE DE DESCUENTO DE LA LINEA
                POIMGLLI = 0 'PORCENTAJE DE IMPUESTOS DE LA LINEA
                VADTNELI = 0 'VALOR DE DESCUENTO NETO DE LINEA
                VADTBRLI = 0 'VALOR DE DESCUENTO BRUTO DE LINEA
                POIVLI = trae_dato(tb, cn1, "POIVPR", "MAEPR", "KOPR = '" & KOPRCT & "'") ' Unidad 1
                VAIVLI = De_Num_a_Tx_01(PPPRNE * (POIVLI / 100), False, 2)
                VAIMLI = 0
                VANELI = De_Num_a_Tx_01(Val(CAPRCO1) * Val(PPPRNE), False, 2)
                VABRLI = De_Num_a_Tx_01(Val(VANELI) + De_Txt_a_Num_01(Val(VAIVLI), 2), False, 2)
                FEEMLI = Format(Now.Date, "yyyyMMdd") '""20121127"
                FEERLI = Format(Now.Date, "yyyyMMdd")

                PPPRPM = De_Num_a_Tx_01(trae_dato(tb, cn1, "PM", "MAEPREM", "KOPR = '" & KOPRCT & "'"), False, 2)
                PPPRNERE1 = PPPRNE
                PPPRNERE2 = De_Num_a_Tx_01(Val(PPPRNE * RLUDPR), False, 2)
                NOKOPR = trae_dato(tb, cn1, "NOKOPR", "MAEPR", "KOPR = '" & KOPRCT & "'")
                PPOPPR = PPPRNE
                LINCONDESP = 0
                PPPRPMSUC = 0


                'TxtProducto.Text = NOKOPR
                System.Windows.Forms.Application.DoEvents()

                TotalNeto = De_Num_a_Tx_01(Val(De_Txt_a_Num_01(TotalNeto, 2) + De_Txt_a_Num_01(VANELI, 2)), False, 0)

                CrearDetalle(IDMAEEDO, "", EMPRESA, TIDO, NUDO, ENDO, SUENDO, NULIDO, SULIDO, BOSULIDO, FUNCIONARIO, KOPRCT, _
                              RLUDPR, UDTRPR, CAPRCO1, CAPRAD1, CAPREX1, CAPRNC1, UD01PR, CAPRCO2, CAPRAD2, CAPREX2, CAPRNC2, UD02PR, _
                              KOLTPR, MOPPPR, TIMOPPPR, TAMOPPPR, PPPRNELT, PPPRNE, PPPRBRLT, PPPRBR, PODTGLLI, VADTNELI, _
                              VADTBRLI, POIVLI, VAIVLI, VAIMLI, VANELI, VABRLI, FEEMLI, FEERLI, PPPRPM, PPPRNERE1, PPPRNERE2, _
                              NOKOPR, PPOPPR, LINCONDESP, PPPRPMSUC, "0", "", "SI", "", "", "0", "", TIPR)

                'Clipboard.Clear()
                'Clipboard.SetText(Consulta_sql) 'Txtleyenda
                'MsgBox("El texto se encuentra en el portapapeles", vbInformation, "Copiar")

                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)


                'Clipboard.Clear()
                'Clipboard.SetText(Consulta_sql) 'Txtleyenda
                'MsgBox("El texto se encuentra en el portapapeles", vbInformation, "Copiar")

                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                BAR.Value += 1
                System.Windows.Forms.Application.DoEvents()
                'MsgBox(i)
                ' i = +1
            Next


            BAR.value = 0

            TotalNeto = TotalNeto
            TotalIva = De_Num_a_Tx_01(Math.Round(De_Txt_a_Num_01(TotalNeto, 2) * (De_Txt_a_Num_01(POIVLI, 0) / 100), 0), False, 0)
            TotalBruto = De_Num_a_Tx_01(Math.Round(De_Txt_a_Num_01(TotalNeto, 2) + De_Txt_a_Num_01(TotalIva, 2), 0), False, 0)

            myTrans.Commit()
            cn2.Close()

            CrearEncabezadoActualizar(IDMAEEDO, SUENDO, "", "I", SUCURSAL, "AD", Format(Now.Date, "yyyyMMdd"), FUNCIONARIO, _
                                      "", "S", CantidadTotal, 0, 0, 0, "N", "$", "N", 1, 1, 0, 0, 0, 0, TotalIva, 0, 0, TotalNeto, _
                                      TotalBruto, 0, 0, Format(Now.Date, "yyyyMMdd"), Format(Now.Date, "yyyyMMdd"), 0, 0, _
                                     "", Format(Now.Date, "yyyyMMdd"), "", "", 1, "", Format(Now.Date, "yyyyMMdd"), "", "", "", "", 0, "", 0, 0, _
                                     "", Format(Now.Date, "yyyyMMdd"), "", "", "", 1, 47143, "", "", 0, "", 0, "", "", Format(Now.Date, "yyyyMMdd"), _
                                     0, "", 0, Format(Now.Date, "yyyyMMdd"), 0, "")

            'Clipboard.Clear()
            'Clipboard.SetText(Consulta_sql) 'Txtleyenda
            'MsgBox("El texto se encuentra en el portapapeles", vbInformation, "Copiar")

            Ej_consulta_IDU(Consulta_sql, cn1)
            Dim FechaDoc As String = Format(Now.Date, "dd/MM/yyyy")

            Consulta_sql = "INSERT INTO MAEEDOOB ( IDMAEEDO,OBDO,OCDO,CPDO,DIENDESP,MOTIVO,TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5,TEXTO6," & _
                           "TEXTO7,TEXTO8,TEXTO9,TEXTO10,TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,TEXTO16,TEXTO17,TEXTO18," & _
                           "TEXTO19,TEXTO20,TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27,TEXTO28,TEXTO29,TEXTO30," & _
                           "TEXTO31,TEXTO32,CARRIER,BOOKING,LADING,AGENTE,MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE," & _
                           "KOPAD,KOCID,KOCMD,FECHAD,HORAD,OBDOEXPO,PLACAPAT) " & _
                           "VALUES ( " & IDMAEEDO & ",'DOCUMENTO GENERADO AUTOMATICAMENTE POR SISTEMA SATELITE " & FechaDoc & "','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',NULL,'','','','',NULL,'','','')"
            Ej_consulta_IDU(Consulta_sql, cn1)

            Dim Cantproducto As String
            Dim RazonSocial As String

            Dim Neto As String
            Dim Iva As String
            Dim Total As String

            RazonSocial = trae_dato(tb, cn1, "NOKOEN", "MAEEN", "KOEN = '" & ENDO & "' AND SUEN = '" & SUENDO & "'")

            Neto = trae_dato(tb, cn1, "VANEDO", "MAEEDO", "TIDO = '" & TIDO & "' AND NUDO = '" & NUDO & "'")
            Iva = trae_dato(tb, cn1, "VAIVDO", "MAEEDO", "TIDO = '" & TIDO & "' AND NUDO = '" & NUDO & "'")
            Total = trae_dato(tb, cn1, "VABRDO", "MAEEDO", "TIDO = '" & TIDO & "' AND NUDO = '" & NUDO & "'")
            Cantproducto = trae_dato(tb, cn1, "CAPRCO", "MAEEDO", "TIDO = '" & TIDO & "' AND NUDO = '" & NUDO & "'")

            'laFecha = Format(Me.txtfecha.text, "dd/mm/yyyy")

            ' strSQL = "INSERT INTO tablaLaQueSea (fecha_dia), VALUES (#" & laFecha & "#)"

            Consulta_sql = "INSERT INTO TmpDocumentosGenerados (TipoDoc,NumeroDoc,FechaDoc,CodEntidad,CodSucursal,RazonSocial" & _
                           ",Cantproducto,Neto,Iva,Total) VALUES ('" & TIDO & "','" & NUDO & "',#" & FechaDoc & _
                           "#,'" & ENDO & "','" & SUENDO & "','" & RazonSocial & "'," & Cantproducto & _
                           "," & Neto & "," & Iva & "," & Total & ")"


            'MsgBox(Consulta_sql)
            Ej_consulta_IDUaccess(Consulta_sql)



            'MsgBox("DOC GUARDADO CORRECTAMENTE")

        Catch ex As Exception
            MsgBox(ex.Message)
            myTrans.Rollback()
            MsgBox("Transaccion desecha")
            cn2.Close()

        End Try
    End Function

    Private Function CrearEncabezadoInsertar(ByVal EMPRESA As String, ByVal TIDO As String, ByVal NUDO As String, _
                             ByVal ENDO As String, Optional ByVal NUDONODEFI As Integer = 0, _
                             Optional ByVal TIDOELEC As Integer = 0)
        Consulta_sql = "INSERT INTO MAEEDO ( EMPRESA,TIDO,NUDO,ENDO,NUDONODEFI,TIDOELEC ) VALUES " & _
                       "( '" & EMPRESA & "','" & TIDO & "','" & NUDO & "','" & ENDO & "'," & NUDONODEFI & ",0 ) "
        Return Consulta_sql
    End Function

    Private Function CrearEncabezadoActualizar(ByVal IDMAEEDO As String, ByVal SUENDO As String, ByVal ENDOFI As String, ByVal TIGEDO As String, _
    ByVal SUDO As String, ByVal LUVTDO As String, ByVal FEEMDO As String, ByVal KOFUDO As String, ByVal ESDO As String, ByVal ESPGDO As String, _
    ByVal CAPRCO As String, ByVal CAPRAD As String, ByVal CAPREX As String, ByVal CAPRNC As String, ByVal MEARDO As String, ByVal MODO As String, _
    ByVal TIMODO As String, ByVal TAMODO As String, ByVal NUCTAP As String, ByVal VACTDTNEDO As String, ByVal VACTDTBRDO As String, ByVal NUIVDO As String, _
    ByVal POIVDO As String, ByVal VAIVDO As String, ByVal NUIMDO As String, ByVal VAIMDO As String, ByVal VANEDO As String, ByVal VABRDO As String, _
    ByVal POPIDO As String, ByVal VAPIDO As String, ByVal FE01VEDO As String, ByVal FEULVEDO As String, ByVal NUVEDO As String, ByVal VAABDO As String, _
    ByVal MARCA As String, ByVal FEER As String, ByVal NUTRANSMI As String, ByVal NUCOCO As String, ByVal KOTU As String, ByVal LIBRO As String, ByVal LCLV As String, _
    ByVal ESFADO As String, ByVal KOTRPCVH As String, ByVal NULICO As String, ByVal PERIODO As String, ByVal NUDONODEFI As String, ByVal TRANSMASI As String, _
    ByVal POIVARET As String, ByVal VAIVARET As String, ByVal RESUMEN As String, ByVal LAHORA As String, ByVal KOFUAUDO As String, ByVal KOOPDO As String, _
    ByVal ESPRODDO As String, ByVal DESPACHO As String, ByVal HORAGRAB As String, ByVal RUTCONTACT As String, ByVal SUBTIDO As String, ByVal TIDOELEC As String, _
    ByVal ESDOIMP As String, ByVal CUOGASDIF As String, ByVal BODESTI As String, ByVal PROYECTO As String, ByVal FECHATRIB As String, ByVal NUMOPERVEN As String, _
    ByVal BLOQUEAPAG As String, ByVal VALORRET As String, ByVal FLIQUIFCV As String, ByVal VADEIVDO As String, ByVal KOCANAL As String)



        Consulta_sql = _
        "UPDATE MAEEDO SET " & _
        "SUENDO = '" & SUENDO & "'," & _
        "ENDOFI = '" & ENDOFI & "'," & _
        "TIGEDO = '" & TIGEDO & "'," & _
        "SUDO = '" & SUDO & "'," & _
        "LUVTDO = '" & LUVTDO & "'," & _
        "FEEMDO = '" & FEEMDO & "'," & _
        "KOFUDO = '" & KOFUDO & "'," & _
        "ESDO = '" & ESDO & "'," & _
        "ESPGDO = '" & ESPGDO & "'," & _
        "CAPRCO = " & CAPRCO & "," & _
        "CAPRAD = " & CAPRAD & "," & _
        "CAPREX = " & CAPREX & "," & _
        "CAPRNC = " & CAPRNC & "," & _
        "MEARDO = '" & MEARDO & "'," & _
        "MODO = '" & MODO & "'," & _
        "TIMODO = '" & TIMODO & "'," & _
        "TAMODO = " & TAMODO & "," & _
        "NUCTAP = " & NUCTAP & "," & _
        "VACTDTNEDO = " & VACTDTNEDO & "," & _
        "VACTDTBRDO = " & VACTDTBRDO & "," & _
        "NUIVDO = " & NUIVDO & "," & _
        "POIVDO = " & POIVDO & "," & _
        "VAIVDO = " & VAIVDO & "," & _
        "NUIMDO = " & NUIMDO & "," & _
        "VAIMDO = " & VAIMDO & "," & _
        "VANEDO = " & VANEDO & "," & _
        "VABRDO = " & VABRDO & "," & _
        "POPIDO = " & POPIDO & "," & _
        "VAPIDO = " & VAPIDO & "," & _
        "FE01VEDO = '" & FE01VEDO & "'," & _
        "FEULVEDO = '" & FEULVEDO & "'," & _
        "NUVEDO = " & NUVEDO & "," & _
        "VAABDO = " & VAABDO & "," & _
        "MARCA = '" & MARCA & "'," & _
        "FEER = '" & FEER & "'," & _
        "NUTRANSMI = '" & NUTRANSMI & "'," & _
        "NUCOCO = '" & NUCOCO & "'," & _
        "KOTU = '" & KOTU & "'," & _
        "LIBRO = '" & LIBRO & "'," & _
        "ESFADO = '" & ESFADO & "'," & _
        "KOTRPCVH = '" & KOTRPCVH & "'," & _
        "NULICO = '" & NULICO & "'," & _
        "PERIODO = '" & PERIODO & "'," & _
        "NUDONODEFI = " & NUDONODEFI & "," & _
        "TRANSMASI = '" & TRANSMASI & "'," & _
        "POIVARET = " & POIVARET & "," & _
        "VAIVARET = " & VAIVARET & "," & _
        "RESUMEN = '" & RESUMEN & "'," & _
        "LAHORA = '" & LAHORA & "'," & _
        "KOFUAUDO = '" & KOFUAUDO & "'," & _
        "KOOPDO = '" & KOOPDO & "'," & _
        "ESPRODDO = '" & ESPRODDO & "'," & _
        "DESPACHO = " & DESPACHO & "," & _
        "HORAGRAB = " & HORAGRAB & "," & _
        "RUTCONTACT = '" & RUTCONTACT & "'," & _
        "SUBTIDO = '" & SUBTIDO & "'," & _
        "TIDOELEC = " & TIDOELEC & "," & _
        "ESDOIMP = '" & ESDOIMP & "'," & _
        "CUOGASDIF = " & CUOGASDIF & "," & _
        "BODESTI = '" & BODESTI & "'," & _
        "PROYECTO = '" & PROYECTO & "'," & _
        "NUMOPERVEN = " & NUMOPERVEN & "," & _
        "BLOQUEAPAG = '" & BLOQUEAPAG & "'," & _
        "VALORRET = " & VALORRET & "," & _
        "VADEIVDO = " & VADEIVDO & "," & _
        "KOCANAL = '" & KOCANAL & "' " & _
        "WHERE IDMAEEDO=" & IDMAEEDO

        '"LCLV = '" & LCLV & "'," & _ NULL   SE GRABARAN VALORES NULOS EN ESTOS CAMPOS
        '"FECHATRIB = '" & FECHATRIB & "'," & _ NULL
        '"FLIQUIFCV = '" & FLIQUIFCV & "'," & _

        Return Consulta_sql

    End Function

    Private Function CrearDetalle(ByVal IDMAEEDO As String, _
    ByVal ARCHIRST As String, _
    ByVal EMPRESA As String, _
    ByVal TIDO As String, _
    ByVal NUDO As String, _
    ByVal ENDO As String, _
    ByVal SUENDO As String, _
    ByVal NULIDO As String, _
    ByVal SULIDO As String, _
    ByVal BOSULIDO As String, _
    ByVal KOFULIDO As String, _
    ByVal KOPRCT As String, _
    ByVal RLUDPR As String, _
    ByVal UDTRPR As String, _
    ByVal CAPRCO1 As String, _
    ByVal CAPRAD1 As String, _
    ByVal CAPREX1 As String, _
    ByVal CAPRNC1 As String, _
    ByVal UD01PR As String, _
    ByVal CAPRCO2 As String, _
    ByVal CAPRAD2 As String, _
    ByVal CAPREX2 As String, _
    ByVal CAPRNC2 As String, _
    ByVal UD02PR As String, _
    ByVal KOLTPR As String, _
    ByVal MOPPPR As String, _
    ByVal TIMOPPPR As String, _
    ByVal TAMOPPPR As String, _
    ByVal PPPRNELT As String, _
    ByVal PPPRNE As String, _
    ByVal PPPRBRLT As String, _
    ByVal PPPRBR As String, _
    ByVal PODTGLLI As String, _
    ByVal VADTNELI As String, _
    ByVal VADTBRLI As String, _
    ByVal POIVLI As String, _
    ByVal VAIVLI As String, _
    ByVal VAIMLI As String, _
    ByVal VANELI As String, _
    ByVal VABRLI As String, _
    ByVal FEEMLI As String, _
    ByVal FEERLI As String, _
    ByVal PPPRPM As String, _
    ByVal PPPRNERE1 As String, _
    ByVal PPPRNERE2 As String, _
    ByVal NOKOPR As String, _
    ByVal PPOPPR As String, _
    ByVal LINCONDESP As String, _
    ByVal PPPRPMSUC As String, _
    Optional ByVal IDRST As String = "0", _
    Optional ByVal ENDOFI As String = "", _
    Optional ByVal LILG As String = "SI", _
    Optional ByVal LUVTLIDO As String = "", _
    Optional ByVal NULILG As String = "", _
    Optional ByVal PRCT As String = "0", _
    Optional ByVal TICT As String = "", _
    Optional ByVal TIPR As String = "", _
    Optional ByVal NUSEPR As String = "", _
    Optional ByVal NUDTLI As String = "0", _
    Optional ByVal NUIMLI As String = "0", _
    Optional ByVal POIMGLLI As String = "0", _
    Optional ByVal TIGELI As String = "I", _
    Optional ByVal EMPREPA As String = "", _
    Optional ByVal TIDOPA As String = "", _
    Optional ByVal NUDOPA As String = "", _
    Optional ByVal ENDOPA As String = "", _
    Optional ByVal NULIDOPA As String = "", _
    Optional ByVal LLEVADESP As String = "0", _
    Optional ByVal OPERACION As String = "", _
    Optional ByVal CODMAQ As String = "", _
    Optional ByVal ESLIDO As String = "", _
    Optional ByVal ESFALI As String = "", _
    Optional ByVal CAFACO As String = "0", _
    Optional ByVal CAFAAD As String = "0", _
    Optional ByVal CAFAEX As String = "0", _
    Optional ByVal CMLIDO As String = "0", _
    Optional ByVal NULOTE As String = "", _
    Optional ByVal FVENLOTE As String = "", _
    Optional ByVal ARPROD As String = "", _
    Optional ByVal NULIPROD As String = "", _
    Optional ByVal NUCOCO As String = "", _
    Optional ByVal NULICO As String = "", _
    Optional ByVal PERIODO As String = "", _
    Optional ByVal FCRELOTE As String = "", _
    Optional ByVal SUBLOTE As String = "", _
    Optional ByVal ALTERNAT As String = "", _
    Optional ByVal PRENDIDO As String = "0", _
    Optional ByVal OBSERVA As String = "", _
    Optional ByVal KOFUAULIDO As String = "", _
    Optional ByVal KOOPLIDO As String = "", _
    Optional ByVal MGLTPR As String = "0", _
    Optional ByVal TIPOMG As String = "0", _
    Optional ByVal ESPRODLI As String = "", _
    Optional ByVal CAPRODCO As String = "0", _
    Optional ByVal CAPRODAD As String = "0", _
    Optional ByVal CAPRODEX As String = "0", _
    Optional ByVal CAPRODRE As String = "0", _
    Optional ByVal TASADORIG As String = "0", _
    Optional ByVal CUOGASDIF As String = "0", _
    Optional ByVal PROYECTO As String = "", _
    Optional ByVal POTENCIA As String = "0", _
    Optional ByVal HUMEDAD As String = "0", _
    Optional ByVal IDTABITPRE As String = "0", _
    Optional ByVal IDODDGDV As String = "0", _
    Optional ByVal PODEIVLI As String = "0", _
    Optional ByVal VADEIVLI As String = "0", _
    Optional ByVal PRIIDETIQ As String = "0", _
    Optional ByVal KOLORESCA As String = "", _
    Optional ByVal KOENVASE As String = "")

        FCRELOTE = "'" & Format(Now.Date, "yyyyMMdd") & "'"
        FVENLOTE = FCRELOTE


        Consulta_sql = "INSERT INTO MAEDDO(IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,ENDOFI,LILG,NULIDO,SULIDO,LUVTLIDO,BOSULIDO,KOFULIDO,NULILG,PRCT,TICT,TIPR," & _
                        "NUSEPR,KOPRCT,UDTRPR,RLUDPR,CAPRCO1,CAPRAD1,CAPREX1,CAPRNC1,UD01PR,CAPRCO2,CAPRAD2,CAPREX2,CAPRNC2,UD02PR,KOLTPR,MOPPPR,TIMOPPPR," & _
                        "TAMOPPPR,PPPRNELT,PPPRNE,PPPRBRLT,PPPRBR,NUDTLI,PODTGLLI,VADTNELI,VADTBRLI,POIVLI,VAIVLI,NUIMLI,POIMGLLI,VAIMLI,VANELI,VABRLI,TIGELI," & _
                        "EMPREPA,TIDOPA,NUDOPA,ENDOPA,NULIDOPA,LLEVADESP,FEEMLI,FEERLI,PPPRPM,OPERACION,CODMAQ,ESLIDO,PPPRNERE1,PPPRNERE2,ESFALI,CAFACO,CAFAAD," & _
                        "CAFAEX,CMLIDO,NULOTE,FVENLOTE,ARPROD,NULIPROD,NUCOCO,NULICO,PERIODO,FCRELOTE,SUBLOTE,NOKOPR,ALTERNAT,PRENDIDO,OBSERVA,KOFUAULIDO,KOOPLIDO, " & _
                        "MGLTPR,PPOPPR,TIPOMG,ESPRODLI,CAPRODCO,CAPRODAD,CAPRODEX,CAPRODRE,TASADORIG,CUOGASDIF,PROYECTO,POTENCIA,HUMEDAD,IDTABITPRE,IDODDGDV," & _
                        "LINCONDESP,PODEIVLI,VADEIVLI,PRIIDETIQ,KOLORESCA,KOENVASE,PPPRPMSUC) " & _
                        "VALUES ( " & IDMAEEDO & ",'" & ARCHIRST & "'," & IDRST & ",'" & EMPRESA & "','" & TIDO & "','" & NUDO & "','" & ENDO & "','" & SUENDO & "','" & ENDOFI & "','" & LILG & "','" & NULIDO & "','" & SULIDO & "','" & LUVTLIDO & "','" & BOSULIDO & "','" & KOFULIDO & "','" & NULILG & "'," & PRCT & ",'" & TICT & "','" & TIPR & "'," & _
                        "'" & NUSEPR & "','" & KOPRCT & "'," & UDTRPR & "," & RLUDPR & "," & CAPRCO1 & "," & CAPRAD1 & "," & CAPREX1 & "," & CAPRNC1 & ",'" & UD01PR & "'," & CAPRCO2 & "," & CAPRAD2 & "," & CAPREX2 & "," & CAPRNC2 & ",'" & UD02PR & "','TABPP" & KOLTPR & "','" & MOPPPR & "','" & TIMOPPPR & "'," & _
                        TAMOPPPR & "," & PPPRNELT & "," & PPPRNE & "," & PPPRBRLT & "," & PPPRBR & "," & NUDTLI & "," & PODTGLLI & "," & VADTNELI & "," & VADTBRLI & "," & POIVLI & "," & VAIVLI & "," & NUIMLI & "," & POIMGLLI & "," & VAIMLI & "," & VANELI & "," & VABRLI & ",'" & TIGELI & "'," & _
                        "'" & EMPREPA & "','" & TIDOPA & "','" & NUDOPA & "','" & ENDOPA & "','" & NULIDOPA & "'," & LLEVADESP & ",'" & FEEMLI & "','" & FEERLI & "'," & PPPRPM & ",'" & OPERACION & "','" & CODMAQ & "','" & ESLIDO & "'," & PPPRNERE1 & "," & PPPRNERE2 & ",'" & ESFALI & "'," & CAFACO & "," & CAFAAD & "," & _
                        CAFAEX & "," & CMLIDO & ",'" & NULOTE & "'," & FVENLOTE & ",'" & ARPROD & "','" & NULIPROD & "','" & NUCOCO & "','" & NULICO & "','" & PERIODO & "'," & FCRELOTE & ",'" & SUBLOTE & "','" & NOKOPR & "','" & ALTERNAT & "'," & PRENDIDO & ",'" & OBSERVA & "','" & KOFUAULIDO & "','" & KOOPLIDO & "'," & _
                        MGLTPR & "," & PPOPPR & "," & TIPOMG & ",'" & ESPRODLI & "'," & CAPRODCO & "," & CAPRODAD & "," & CAPRODEX & "," & CAPRODRE & "," & TASADORIG & "," & CUOGASDIF & ",'" & PROYECTO & "'," & POTENCIA & "," & HUMEDAD & "," & IDTABITPRE & "," & IDODDGDV & "," & _
                        LINCONDESP & "," & PODEIVLI & "," & VADEIVLI & "," & PRIIDETIQ & ",'" & KOLORESCA & "','" & KOENVASE & "'," & PPPRPMSUC & ")"
        Return Consulta_sql


    End Function

    Private Function InsertaDescuentosEnDetalle(ByVal IDMAEEDO As Integer, _
                                        ByVal NULIDO As String, _
                                        ByVal KODT As String, _
                                        ByVal PODT As Double, _
                                        ByVal VADT As Double, _
                                        ByVal LILG As String, _
                                        ByVal OPERA As String, _
                                        ByVal UNITAR As Double)

        Consulta_sql = "INSERT INTO MAEDTLI( IDMAEEDO,NULIDO,KODT,PODT,VADT,LILG,OPERA,UNITAR) VALUES " & _
        "( " & IDMAEEDO & ",'" & NULIDO & "','" & KODT & "'," & PODT & "," & VADT & ",'" & LILG & "','" & OPERA & "'," & UNITAR & ")"

        Return Consulta_sql
    End Function

    Private Function InsertarObservacionDocumento()
        Consulta_sql = "INSERT INTO MAEEDOOB ( IDMAEEDO,OBDO,OCDO,CPDO,DIENDESP,MOTIVO,TEXTO1,TEXTO2,TEXTO3,TEXTO4,TEXTO5," & _
                       "TEXTO6,TEXTO7,TEXTO8,TEXTO9,TEXTO10,TEXTO11,TEXTO12,TEXTO13,TEXTO14,TEXTO15,TEXTO16,TEXTO17,TEXTO18," & _
                       "TEXTO19,TEXTO20,TEXTO21,TEXTO22,TEXTO23,TEXTO24,TEXTO25,TEXTO26,TEXTO27,TEXTO28,TEXTO29,TEXTO30,TEXTO31," & _
                       "TEXTO32,CARRIER,BOOKING,LADING,AGENTE,MEDIOPAGO,TIPOTRANS,KOPAE,KOCIE,KOCME,FECHAE,HORAE,KOPAD,KOCID," & _
                       "KOCMD,FECHAD,HORAD,OBDOEXPO,PLACAPAT)" & _
                       "VALUES ( 99550,'OBSERVACIONES EN EL DOCUMENTO','','30 60 90 DIAS','','','','','','','','','','','',''," & _
                       "'','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',NULL,''," & _
                       "'','','',NULL,'','','')"
        Return Consulta_sql

    End Function




End Class

Public Class OCCenKASIEDO

    Function CrearDocumento(ByVal TablaDePaso As String, _
                       ByVal Empresa As String, _
                       ByVal Tido As String, _
                       ByVal Nudo As String, _
                       ByVal Endo As String, _
                       ByVal Suendo As String, _
                       ByVal Sudo As String, _
                       ByVal Fecha As Date, _
                       ByVal Kofudo As String, _
                       ByVal Vaivdo As String, _
                       ByVal Vaimdo As String, _
                       ByVal Vanedo As String, _
                       ByVal Vabrdo As String, _
                       ByVal NroDocumentoTMP As String, _
                       ByVal Sulido As String, _
                       ByVal Bosulido As String, _
                       ByVal ListaDeCostos As String, _
                       ByVal LineasXdocumento As Integer, _
                       ByVal LineaGenerada As String) As Boolean

        'Dim Cadena_Conexion As String = _
        'Ruta_conexion(AppPath(True) & "Cadena_conexion.txt")
        'Conectar_SQL("", "", "", "", cn2, Cadena_Conexion)

        SQL_ServerClass.AbrirConexion_SQLServer(cn2)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim IDMAEEDO As String
        Dim Ano As String = Fecha.Year
        Dim Mes As String = numero_(Fecha.Month, 2)
        Dim Dia As String = numero_(Fecha.Day, 2)

        Try


            myTrans = cn2.BeginTransaction()

            Consulta_sql = _
             "INSERT INTO KASIEDO( EMPRESA,TIDO,NUDO,ENDO,SUENDO,ENDOFI,TIGEDO,SUDO,LUVTDO,FEEMDO,KOFUDO,ESDO,ESPGDO,CAPRCO,CAPRAD,CAPREX,CAPRNC,MEARDO,MODO,TIMODO,TAMODO," & _
             "NUCTAP,VACTDTNEDO,VACTDTBRDO,NUIVDO,POIVDO,VAIVDO,NUIMDO,VAIMDO,VANEDO,VABRDO,POPIDO,VAPIDO,FE01VEDO,FEULVEDO,NUVEDO,VAABDO,MARCA,FEER,NUTRANSMI,NUCOCO,KOTU," & _
             "LIBRO, LCLV, ESFADO, KOTRPCVH, NULICO, PERIODO, NUDONODEFI, TRANSMASI, POIVARET, VAIVARET, RESUMEN, LAHORA, KOFUAUDO, KOOPDO, ESPRODDO, DESPACHO, HORAGRAB, RUTCONTACT, SUBTIDO, " & _
             "TIDOELEC,ESDOIMP,CUOGASDIF,BODESTI,PROYECTO,FECHATRIB,NUMOPERVEN,BLOQUEAPAG,VALORRET,FLIQUIFCV,VADEIVDO,KOCANAL,KOCRYPT)" & _
             "VALUES ( '" & Empresa & "','" & Tido & "','" & Nudo & "','" & Endo & "','" & Suendo & "','','I','" & Sulido & _
             "','',{d '" & Ano & "-" & Mes & "-" & Dia & "'},'" & Kofudo & "','','S',0.00000,0.00000,0.00000,0.00000,'N','$','N',524.12000," & _
             "0.00000,0.00000,0.00000,0.00000,0.00000," & Vaivdo & ",0.00000," & Vaimdo & "," & Vanedo & "," & Vabrdo & _
             ",0.00000,0.00000,{d '" & Ano & "-" & Mes & "-" & Dia & "'},{d '" & Ano & "-" & Mes & "-" & Dia & "'}," & _
             "1.00000,0.00000,'',NULL,'','','','" & NroDocumentoTMP & "',NULL,'','','','',0,'',0.00000,0.00000,'',{d '" & Ano & "-" & Mes & "-" & Dia & "'},'','','',0,0,'','',0,'',0,'',''," & _
             "NULL,0,'',0.00000,{d '" & Ano & "-" & Mes & "-" & Dia & "'},0.00000,'','442E6F06FFD5FFAE0D0387AB9DC374')"


            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New SqlCommand("SELECT @@IDENTITY AS 'Identity'", cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                IDMAEEDO = dfd1("Identity")
            End While
            dfd1.Close()

            Consulta_sql = "SELECT TOP " & LineasXdocumento & " * FROM " & TablaDePaso & _
                          " where LineaGenerada = '" & LineaGenerada & "'"
            Ejecutar_consulta_SQL(Consulta_sql, cn1)

            tb = New DataTable
            da.Fill(tb)

            Dim dfd As DataRow '
            Dim CantFilas As Long = tb.Rows.Count

            'BAR.Maximum = CantFilas
            Dim Tipr As String
            Dim Items As String

            Dim CostoUnitarioUD1 As Double
            Dim CostoUnitarioUD2 As Double
            Dim UnidadDeTransaccion As Integer
            Dim UD1, UD2 As String
            Dim UDtransaccion As String
            Dim RTU As Double
            Dim Iva As Double
            Dim TipoImpuesto As String
            Dim Impuesto As Double
            Dim CantidadUD1 As Double
            Dim CantidadUD2 As Double
            Dim Potencia As Double
            Dim CodProducto As String
            Dim Descripcion As String
            Dim Nmarca As String
            Dim Operacion As String = ""

            Dim CostoNetoTransaccion As Double
            Dim CostoBrutoTransaccion As Double

            Dim PorcentajeDscto As Double
            Dim ValorDscto As Double

            Dim TotalILA As Double
            Dim TotalIva As Double
            Dim TotalNeto As Double
            Dim TotalBruto As Double

            For i As Integer = 0 To tb.Rows.Count - 1

                'System.Windows.Forms.Application.DoEvents()
                dfd = tb.Rows(i)

                Items = dfd.Item("Items").ToString

                CodProducto = dfd.Item("Codigo").ToString
                Descripcion = dfd.Item("Codigo").ToString

                Tipr = trae_dato(tb, cn1, "TIPR", "MAEPR", "KOPR = '" & CodProducto & "'")
                UD1 = trae_dato(tb, cn1, "UD01PR", "MAEPR", "KOPR = '" & CodProducto & "'")
                UD2 = trae_dato(tb, cn1, "UD02PR", "MAEPR", "KOPR = '" & CodProducto & "'")
                RTU = trae_dato(tb, cn1, "RLUD", "MAEPR", "KOPR = '" & CodProducto & "'")

                UDtransaccion = dfd.Item("UnidadTransaccion").ToString

                CostoUnitarioUD1 = dfd.Item("CostoUd1").ToString
                CostoUnitarioUD2 = dfd.Item("CostoUd2").ToString

                If UnidadDeTransaccion = 1 Then
                    CostoNetoTransaccion = CostoUnitarioUD1
                    CostoBrutoTransaccion = 0
                Else
                    CostoNetoTransaccion = CostoUnitarioUD2
                    CostoBrutoTransaccion = 0
                End If

                CantidadUD1 = dfd.Item("CantidadUD1").ToString
                CantidadUD2 = dfd.Item("CantidadUD2").ToString
                Impuesto = dfd.Item("PorcentajeImpuesto").ToString
                Iva = dfd.Item("PorcentajeIva").ToString
                PorcentajeDscto = dfd.Item("PorcDscto").ToString
                ValorDscto = dfd.Item("ValorDscto").ToString
                TotalILA = dfd.Item("TotalILA").ToString
                TotalIva = dfd.Item("TotalIva").ToString
                TotalNeto = dfd.Item("TotalNeto").ToString
                TotalBruto = dfd.Item("TotalBruto").ToString
                Operacion = dfd.Item("Operacion").ToString
                Descripcion = dfd.Item("Descripcion").ToString
                Potencia = dfd.Item("Potencia").ToString
                Sulido = dfd.Item("Sucursal").ToString
                Bosulido = dfd.Item("Bodega").ToString

                Dim Nulido As String
                Nulido = numero_(i + 1, 5)

                Consulta_sql = _
                 "INSERT INTO KASIDDO( IDMAEDDO,IDMAEEDO,ARCHIRST,IDRST,EMPRESA,TIDO,NUDO,ENDO,SUENDO,ENDOFI,LILG,NULIDO,SULIDO,LUVTLIDO,BOSULIDO,KOFULIDO,NULILG,PRCT,TICT,TIPR," & _
                 "NUSEPR,KOPRCT,UDTRPR,RLUDPR,CAPRCO1,CAPRAD1,CAPREX1,CAPRNC1,UD01PR,CAPRCO2,CAPRAD2,CAPREX2,CAPRNC2,UD02PR,KOLTPR,MOPPPR,TIMOPPPR,TAMOPPPR,PPPRNELT,PPPRNE," & _
                 "PPPRBRLT, PPPRBR, NUDTLI, PODTGLLI, VADTNELI, VADTBRLI, POIVLI, VAIVLI, NUIMLI, POIMGLLI, VAIMLI, VANELI, VABRLI, TIGELI, EMPREPA, TIDOPA, NUDOPA, ENDOPA, NULIDOPA, LLEVADESP, " & _
                 "FEEMLI,FEERLI,PPPRPM,OPERACION,CODMAQ,ESLIDO,PPPRNERE1,PPPRNERE2,ESFALI,CAFACO,CAFAAD,CAFAEX,CMLIDO,NULOTE,FVENLOTE,ARPROD,NULIPROD,NUCOCO,NULICO,PERIODO," & _
                 "FCRELOTE,SUBLOTE,NOKOPR,ALTERNAT,PRENDIDO,OBSERVA,KOFUAULIDO,KOOPLIDO,MGLTPR,PPOPPR,TIPOMG,ESPRODLI,CAPRODCO,CAPRODAD,CAPRODEX,CAPRODRE,TASADORIG,CUOGASDIF," & _
                 "PROYECTO,POTENCIA,HUMEDAD,IDTABITPRE,IDODDGDV,LINCONDESP,PODEIVLI,VADEIVLI,PRIIDETIQ,KOLORESCA,KOENVASE,PPPRPMSUC,PPPRPMIFRS) " & _
                 "VALUES(0," & IDMAEEDO & ",'',0,'01','','','','','','SI','" & Nulido & "','" & Sulido & "','','" & Bosulido & _
                 "','" & Kofudo & "','',0,'','" & Tipr & "','','" & CodProducto & "'," & UDtransaccion & "," & De_Num_a_Tx_01(RTU, False, 5) & _
                 "," & De_Num_a_Tx_01(CantidadUD1, False, 5) & ",0.00000,0.00000,0.00000,'" & UD1 & "'," & De_Num_a_Tx_01(CantidadUD2, False, 5) & _
                 ",0.00000,0.00000,0.00000,'" & UD2 & "','TABPP" & ListaDeCostos & _
                 "','$','N',1.00000," & De_Num_a_Tx_01(CostoNetoTransaccion, False, 5) & "," & De_Num_a_Tx_01(CostoNetoTransaccion, False, 5) & "," & De_Num_a_Tx_01(CostoBrutoTransaccion, False, 5) & "," & De_Num_a_Tx_01(CostoBrutoTransaccion, False, 5) & _
                 ",0.00000," & De_Num_a_Tx_01(PorcentajeDscto, False, 5) & "," & De_Num_a_Tx_01(ValorDscto, False, 5) & ",0.00000," & Iva & "," & De_Num_a_Tx_01(TotalIva, False, 5) & "," & _
                 "0.00000," & De_Num_a_Tx_01(Impuesto, False, 5) & "," & De_Num_a_Tx_01(TotalILA, False, 5) & "," & De_Num_a_Tx_01(TotalNeto, False, 5) & "," & De_Num_a_Tx_01(TotalBruto, False, 5) & ",'I','','','','',''" & _
                 ",0.00000,NULL,NULL,0.00000,'" & Operacion & "','','',0.00000,0.00000,'',0.00000,0.00000,0.00000,0.00000," & _
                 "'',NULL,'','','','','',NULL,'','" & Descripcion & "','',0,'','','',0.00000,0.00000,0.00000,'',0.00000," & _
                 "0.00000,0.00000,0.00000,0.00000,0,''," & De_Num_a_Tx_01(Potencia, False, 5) & ",0.00000,0,0,0,0.00000,0.00000,0,'','',0.00000,0.00000)"

                'System.Windows.Forms.Application.DoEvents()
                Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                TipoImpuesto = trae_dato(tb2, cn1, "KOIM", "TABIMPR", "KOPR = '" & CodProducto & "'")

                If TipoImpuesto <> "" Then
                    Consulta_sql = "INSERT INTO KASIIMLI( IDMAEIMLI,IDMAEEDO,NULIDO,KOIMLI,POIMLI,VAIMLI,LILG) VALUES " & _
                                   "(0," & IDMAEEDO & ",'" & numero_(i + 1, 5) & "','" & TipoImpuesto & "'," & De_Num_a_Tx_01(Impuesto, False, 5) & _
                                   "," & De_Num_a_Tx_01(TotalILA, False, 5) & ",'')"


                    'System.Windows.Forms.Application.DoEvents()
                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                    Consulta_sql = "UPDATE KASIDDO SET NUIMLI = 1" & vbCrLf & _
                                       "WHERE IDMAEEDO = " & IDMAEEDO & " AND NULIDO = '" & Nulido & "'"
                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()


                End If

                If ValorDscto > 0 Then
                    Consulta_sql = "SELECT * FROM TmpTablaDescuentosDocumento WHERE Items = '" & Items & "' order by Orden"
                    Ejecutar_consulta_SQLaccess(Consulta_sql)

                    Dim Tbl1 As New DataTable
                    dbD.Fill(Tbl1)

                    Dim Kodt As String
                    Dim Podt, Vadt As String

                    If Tbl1.Rows.Count > 0 Then
                        Dim Fila As DataRow
                        For x = 0 To Tbl1.Rows.Count - 1
                            Fila = Tbl1.Rows(x)

                            Kodt = Fila.Item("CodDescuento").ToString
                            Podt = Fila.Item("PorcentajeDscto").ToString
                            Vadt = Fila.Item("ValorDscto").ToString

                            Consulta_sql = "INSERT INTO KASIDTLI (IDMAEDTLI,IDMAEEDO,NULIDO,KODT,PODT,VADT,LILG,OPERA,UNITAR) VALUES " & vbCrLf & _
                                           "(0," & IDMAEEDO & ",'" & Nulido & "','" & Kodt & "'," & Podt & _
                                           "," & Vadt & ",'','',0)"
                            Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        Next

                        Consulta_sql = "UPDATE KASIDDO SET NUDTLI = " & Tbl1.Rows.Count & vbCrLf & _
                                       "WHERE IDMAEEDO = " & IDMAEEDO & " AND NULIDO = '" & Nulido & "'"
                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    End If

                End If


                'Consulta_sql = "UPDATE " & TablaDePaso & " SET LineaGenerada = 'S' WHERE Codigo = '" & CodProducto & "'"
                'Comando = New SqlClient.SqlCommand(Consulta_sql, cn2)
                'Comando.Transaction = myTrans
                'Comando.ExecuteNonQuery()

                'BAR.Value += 1
                'System.Windows.Forms.Application.DoEvents()
                'MsgBox(i)
                ' i = +1
            Next

            myTrans.Commit()
            SQL_ServerClass.CerrarConexion(cn2)

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            myTrans.Rollback()
            MsgBox("Transaccion desecha")
            SQL_ServerClass.CerrarConexion(cn2)
            Return False

        End Try
    End Function

End Class

Public Module OrdenDeCompra

    Function CrearDetalleDeOCC(ByVal CodigoEntidad As String, _
                               ByVal ListaDePrecios As String, _
                               ByVal CodProveedor As String, _
                               ByVal Empresa As String, _
                               ByVal Sucursal As String, _
                               ByVal Bodega As String, _
                               ByVal DsctoUltCompra As Boolean, _
                               ByVal ChkUnidad As Boolean, _
                               ByVal BarraCircularar As Object)
        Try


            Consulta_sql = "IF EXISTS (SELECT * FROM sysobjects WHERE name='Zw_Tbl_PasoOCC" & FUNCIONARIO & "') BEGIN " & _
                               "DROP TABLE Zw_Tbl_PasoOCC" & FUNCIONARIO & " End"
            Ej_consulta_IDU(Consulta_sql, cn1)

            Consulta_sql = "CREATE TABLE [dbo].[Zw_Tbl_PasoOCC" & FUNCIONARIO & "](" & vbCrLf & _
                           "[Items] [char](2) NULL," & vbCrLf & _
                           "[Codigo] [char](13) NOT NULL," & vbCrLf & _
                           "[Descripcion] [varchar](50) NULL," & vbCrLf & _
                           "[UnidadTransaccion] [float] NULL," & vbCrLf & _
                           "[UDtransaccion] [char](2) NULL," & vbCrLf & _
                           "[CantidadUd1] [float] NULL," & vbCrLf & _
                           "[CostoUd1] [float] NULL," & vbCrLf & _
                           "[CantidadUd2] [float] NULL," & vbCrLf & _
                           "[CostoUd2] [float] NULL," & vbCrLf & _
                           "[PorcentajeImpuesto] [float] NULL," & vbCrLf & _
                           "[PorcentajeIVA] [float] NULL," & vbCrLf & _
                           "[TotalILA] [float] NULL," & vbCrLf & _
                           "[TotalIva] [float] NULL," & vbCrLf & _
                           "[TotalNeto] [float] NULL," & vbCrLf & _
                           "[PorcDscto] [float] NULL," & vbCrLf & _
                           "[ValorDscto] [float] NULL," & vbCrLf & _
                           "[TotalBruto] [float] NULL," & vbCrLf & _
                           "[Potencia] [float] NULL," & vbCrLf & _
                           "[Operacion] [varchar](10) NULL," & vbCrLf & _
                           "[Empresa] [varchar](2) NULL," & vbCrLf & _
                           "[Sucursal] [varchar](3) NULL," & vbCrLf & _
                           "[Bodega] [varchar](3) NULL," & vbCrLf & _
                           "[LineaGenerada] [varchar](2) NULL," & vbCrLf & _
                           "CONSTRAINT [PKZw_Tbl_PasoOCC" & FUNCIONARIO & "] PRIMARY KEY CLUSTERED ([Codigo] Asc)" & vbCrLf & _
                           "WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & vbCrLf & _
                           ") ON [PRIMARY]" ' & vbCrLf & "GO" & vbCrLf & "SET ANSI_PADDING OFF" & vbCrLf & "GO"

            Ej_consulta_IDU(Consulta_sql, cn1)


            Consulta_sql = "DELETE * FROM TmpTablaDescuentosDocumento"
            Ej_consulta_IDUaccess(Consulta_sql)

            Dim Unidad, UD As String

            If ChkUnidad = True Then
                Unidad = "StockUd1" : UD = "UD1"
            Else
                Unidad = "StockUd2" : UD = "UD2"
            End If


            'W_PASO_AUDITORIASTOCK1

            Consulta_sql = "SELECT * FROM W_PASO_AUDITORIASTOCK1" & FUNCIONARIO & " WHERE CantCoprar > 0"
            Ejecutar_consulta_SQL(Consulta_sql, cn1)

            Dim TablaDetalle As New DataTable
            da.Fill(TablaDetalle)

            Dim Fila As DataRow
            Dim Filas As Long = TablaDetalle.Rows.Count

            Dim CostoUnitarioUD1 As Double
            Dim CostoUnitarioUD2 As Double
            Dim UnidadDeTransaccion As Integer
            Dim UDtransaccion As String
            Dim RTU As Double
            Dim Iva As Double
            Dim TipoImpuesto As String
            Dim Impuesto As Double
            Dim CantidadUD1 As Double
            Dim CantidadUD2 As Double
            Dim Potencia As Double
            Dim CodProducto As String
            Dim Descripcion As String
            Dim Nmarca As String
            Dim Operacion As String = ""
            Dim Items As String

            Dim TotalILA As Double
            Dim TotalIva As Double
            Dim TotalNeto As Double
            Dim TotalBruto As Double

            Dim Contador = 0
            With BarraCircularar

                .Maximum = 100 ' .Value = ((Contador * 100) / Tabla.Rows.Count)

                If Filas > 0 Then
                    For i = 0 To Filas - 1
                        Fila = TablaDetalle.Rows(i)
                        Items = numero_(i + 1, 2)
                        CodProducto = Fila.Item("Codigo").ToString
                        Descripcion = Fila.Item("Descripcion").ToString

                        RTU = trae_dato(tb, cn1, "RLUD", "MAEPR", "KOPR = '" & CodProducto & "'")

                        Nmarca = trae_dato(tb, cn1, "NMARCA", "MAEPR", "KOPR = '" & CodProducto & "'")

                        CostoUnitarioUD1 = trae_dato(tb, cn1, "PP01UD", "TABPRE", "KOPR = '" & CodProducto & "' AND KOLT = '" & ListaDePrecios & "'")
                        CostoUnitarioUD2 = Math.Round(RTU * CostoUnitarioUD1, 0)

                        If Nmarca = "" Then
                            UnidadDeTransaccion = 1
                            CantidadUD1 = Fila.Item("CantCoprar").ToString
                            CantidadUD2 = Fila.Item("CantCoprar").ToString
                            TotalNeto = Math.Round(CantidadUD1 * CostoUnitarioUD1, 0)
                        Else
                            If UnidadDeTransaccionActual = 1 Then
                                CantidadUD1 = Fila.Item("CantCoprar").ToString
                                CantidadUD2 = CantidadUD1 / RTU
                            Else
                                CantidadUD2 = Fila.Item("CantCoprar").ToString
                                CantidadUD1 = CantidadUD2 * RTU
                            End If

                            UnidadDeTransaccion = 2
                            TotalNeto = Math.Round(CantidadUD2 * CostoUnitarioUD2, 0)

                        End If



                        ''' ACA CALCULAR LOS DESCUENTOS
                        Dim ValorDescuento As Double = 0
                        Dim PorcDescuento As Double = 0
                        Dim TotalNetoCDscto As Double = TotalNeto

                        If DsctoUltCompra = True Then
                            TotalNetoCDscto = BuscarUltimoDscto(CodigoEntidad, CodProducto, Items, TotalNeto)
                        Else
                            TotalNetoCDscto = CalcularDescuentosEnEscala(CodigoEntidad, CodProducto, Items, _
                                                                         TotalNeto, ListaDePrecios)
                        End If

                        ValorDescuento = TotalNeto - TotalNetoCDscto
                        'TotalNetoCDscto = TotalNeto - ValorDescuento

                        If ValorDescuento > 0 Then
                            PorcDescuento = Math.Round((ValorDescuento * 100) / TotalNeto, 5)
                        End If

                        UDtransaccion = trae_dato(tb, cn1, "UD0" & UnidadDeTransaccion & "PR", "MAEPR", "KOPR = '" & CodProducto & "'")
                        Dim pto As String = trae_dato(tb, cn1, "RECARGO", "TABRECPR", "KOPR = '" & CodProducto & "' AND KOEN = '" & CodProveedor & "'")
                        If pto = "" Then pto = 0
                        Potencia = pto

                        If Potencia > 0 Then
                            Operacion = "RECA"
                        End If

                        Iva = trae_dato(tb, cn1, "POIVPR", "MAEPR", "KOPR = '" & CodProducto & "'")
                        TipoImpuesto = trae_dato(tb, cn1, "KOIM", "TABIMPR", "KOPR = '" & CodProducto & "'")

                        If TipoImpuesto = "" Then
                            Impuesto = 0
                        Else
                            Impuesto = trae_dato(tb, cn1, "POIM", "TABIM", "KOIM = '" & TipoImpuesto & "'")
                        End If


                        TotalIva = TotalNetoCDscto * (Iva / 100)
                        TotalILA = TotalNetoCDscto * (Impuesto / 100)

                        TotalBruto = Math.Round(TotalNetoCDscto, 0) + Math.Round(TotalILA, 0) + Math.Round(TotalIva)

                        Consulta_sql = "INSERT INTO Zw_Tbl_PasoOCC" & FUNCIONARIO & " (Items,Codigo,Descripcion,UDtransaccion,UnidadTransaccion,CantidadUd1," & _
                                       "CostoUd1,CantidadUd2,CostoUd2,PorcentajeImpuesto,PorcentajeIVA,TotalILA," & vbCrLf & _
                                       "TotalIva,TotalNeto,PorcDscto,ValorDscto,TotalBruto,Potencia,Operacion,Empresa,Sucursal,Bodega,LineaGenerada) VALUES " & _
                                       "('" & Items & "','" & CodProducto & "','" & Descripcion & "','" & UDtransaccion & "'," & UnidadDeTransaccion & _
                                       "," & De_Num_a_Tx_01(CantidadUD1, False, 2) & "," & De_Num_a_Tx_01(CostoUnitarioUD1, False, 2) & _
                                       "," & De_Num_a_Tx_01(CantidadUD2, False, 2) & "," & De_Num_a_Tx_01(CostoUnitarioUD2, False, 2) & _
                                       "," & De_Num_a_Tx_01(Impuesto, False, 2) & "," & De_Num_a_Tx_01(Iva, False, 2) & _
                                       "," & De_Num_a_Tx_01(TotalILA, False, 2) & "," & De_Num_a_Tx_01(TotalIva, False, 2) & _
                                       "," & De_Num_a_Tx_01(TotalNetoCDscto, False, 2) & "," & De_Num_a_Tx_01(PorcDescuento, False, 5) & _
                                       "," & De_Num_a_Tx_01(ValorDescuento, False, 0) & "," & De_Num_a_Tx_01(TotalBruto, False, 0) & _
                                       "," & De_Num_a_Tx_01(Potencia, False, 2) & ",'" & Operacion & _
                                       "','" & CodEmpresa & "','" & CodSucursal & "','" & CodBodega & "','N')"
                        Ej_consulta_IDU(Consulta_sql, cn1)


                        'PorcDscto
                        'ValorDscto
                        Contador += 1
                        .Value = ((Contador * 100) / Filas)
                    Next
                End If
            End With
            'MsgBox("ok")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Function BuscarUltimoDscto(ByVal CodigoEntidad As String, _
                               ByVal CodProducto As String, _
                               ByVal Items As String, _
                               ByVal TotalNeto As Double) As Double

        Consulta_sql = "SELECT TOP (1) ISNULL(MAEDDO_1.TIDO, '') AS Tipo, ISNULL(MAEDDO_1.NUDO, '') AS Numero, ISNULL(dbo.MAEEN.NOKOEN, '') AS [Razón Social], " & vbCrLf & _
                                   "ISNULL(MAEDDO_1.FEEMLI, '') AS Fecha, MAEDDO_1.PODTGLLI AS Porc_Dscto, MAEDDO_1.IDMAEEDO, MAEDDO_1.NULIDO" & vbCrLf & _
                                   "FROM dbo.MAEDDO AS MAEDDO_1 LEFT OUTER JOIN" & vbCrLf & _
                                   "dbo.MAEEN ON MAEDDO_1.ENDO = dbo.MAEEN.KOEN AND MAEDDO_1.SUENDO = dbo.MAEEN.SUEN CROSS JOIN" & vbCrLf & _
                                   "dbo.MAEPR" & vbCrLf & _
                                   "WHERE (MAEDDO_1.KOPRCT = '" & CodProducto & "') " & vbCrLf & _
                                   "AND (MAEDDO_1.TIDO = 'FCC') AND (dbo.MAEEN.KOEN = '" & CodigoEntidad & "') ORDER BY Fecha DESC"

        Dim Descuento As Double
        Dim TotalConDscto As Double = TotalNeto

        Dim NumeroLinea, Idmaeedo, CodDescuento As String
        Dim Tlb As New DataTable
        Tlb = get_Tablas(Consulta_sql, cn1)

        If Tlb.Rows.Count > 0 Then
            Dim Fila As DataRow
            Fila = Tlb.Rows(0)
            NumeroLinea = Fila.Item("NULIDO").ToString
            Idmaeedo = Fila.Item("IDMAEEDO").ToString

            Consulta_sql = "SELECT KODT,PODT FROM MAEDTLI WHERE IDMAEEDO = " & Idmaeedo & " AND NULIDO = '" & NumeroLinea & "'"
            Dim Tlb2 As New DataTable
            Tlb2 = get_Tablas(Consulta_sql, cn1)

            If Tlb2.Rows.Count > 0 Then
                Dim Fila2 As DataRow
                For I = 0 To Tlb2.Rows.Count - 1
                    Fila2 = Tlb2.Rows(I)
                    Dim NroDscto As String
                    Dim ValorDescuento As Double

                    'CodDescuento = De_Txt_a_Num_01(Fila2.Item("KODT").ToString, 3)
                    CodDescuento = Fila2.Item("KODT").ToString

                    Descuento = De_Txt_a_Num_01(Fila2.Item("PODT").ToString, 5)
                    NroDscto = De_Num_a_Tx_01(Descuento, False, 5)
                    Descuento = Descuento / 100
                    ValorDescuento = Math.Round(TotalConDscto * Descuento, 0)
                    TotalConDscto = Math.Round(TotalConDscto - ValorDescuento)

                    Consulta_sql = "INSERT INTO TmpTablaDescuentosDocumento (Items,Orden,CodDescuento,PorcentajeDscto,ValorDscto)" & _
                                   " values ('" & Items & "'," & I + 1 & ",'" & CodDescuento & "','" & NroDscto & "'," & ValorDescuento & ")"
                    Ej_consulta_IDUaccess(Consulta_sql)

                Next

            End If
        End If
        Return TotalConDscto
    End Function

    Function CalcularDescuentosEnEscala(ByVal CodigoEntidad As String, _
                               ByVal CodProducto As String, _
                               ByVal Items As String, _
                               ByVal TotalNeto As Double, _
                               ByVal ListaCosto As String) As Double


        Dim Descuento As Double
        Dim ValorDsctoLista As Double
        Dim TotalConDscto As Double = TotalNeto
        Dim NombreDscto As String

        Consulta_sql = "SELECT Dimension from Zw_TablaDeDimensiones where TipoDsctoRecargo = 'D' order by Orden"
        Dim Tlb As New DataTable

        Tlb = get_Tablas(Consulta_sql, cn1)

        If Tlb.Rows.Count > 0 Then
            Dim Fila As DataRow
            Dim Contador As Integer = 1

            For i = 0 To Tlb.Rows.Count - 1
                Fila = Tlb.Rows(i)
                NombreDscto = Fila.Item("Dimension").ToString
                ValorDsctoLista = trae_dato(tb, cn1, NombreDscto, "TABPRE", _
                                            "KOLT = '" & ListaCosto & "' and KOPR = '" & CodProducto & "'")

                If ValorDsctoLista > 0 Then
                    Dim NroDscto As String
                    Dim ValorDescuento As Double

                    Descuento = ValorDsctoLista
                    NroDscto = De_Num_a_Tx_01(Descuento, False, 5)
                    Descuento = Descuento / 100
                    ValorDescuento = Math.Round(TotalConDscto * Descuento, 0)
                    TotalConDscto = Math.Round(TotalConDscto - ValorDescuento)

                    Consulta_sql = "INSERT INTO TmpTablaDescuentosDocumento (Items,Orden,CodDescuento,PorcentajeDscto,ValorDscto)" & _
                                   " values ('" & Items & "'," & Contador & ",'" & NombreDscto & "','" & NroDscto & "'," & ValorDescuento & ")"
                    Ej_consulta_IDUaccess(Consulta_sql)
                    Contador = Contador + 1
                End If

            Next
        End If
        Return TotalConDscto
    End Function

End Module

Public Class Exportar_excel

    Public Sub Exportar_Excel(ByVal ds As DataSet, _
                               ByVal Nombre_hoja As String, _
                               ByVal ProgressBar As Object)
        '/////////////////////////////
        '// Creamos el Objeto Excel
        '/////////////////////////////
        Dim m_Excel
        Dim objLibroExcel
        Dim objHojaExcel
        m_Excel = CreateObject("Excel.Application")
        objLibroExcel = m_Excel.Workbooks.Add()
        objHojaExcel = objLibroExcel.Worksheets(1)
        objHojaExcel.Name = Nombre_hoja
        objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
        objHojaExcel.Activate()

        '/////////////////////////////////////////////////////////
        '// Definimos dos variables para controlar fila y columna
        '/////////////////////////////////////////////////////////

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        '/////////////////////////////////////////////////
        '// Armamos la linea con los títulos de columnas
        '/////////////////////////////////////////////////

        objHojaExcel.Range("A1").Select()
        For Each dc In ds.Tables(0).Columns
            objHojaExcel.Range(nombreColumna(columna) & 1).Value = dc.ColumnName
            columna += 1
        Next
        fila += 1

        '/////////////////////////////////////////////
        '// Le damos formato a la fila de los títulos
        '/////////////////////////////////////////////

        Dim objRango As Excel.Range = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & "1")
        objRango.Font.Bold = True
        objRango.Cells.Interior.ColorIndex = 35

        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        objRango.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        '//////////////////////////////////////////
        '// Cargamos todas las filas del datatable
        '//////////////////////////////////////////

        ProgressBar.Maximum = ds.Tables(0).Rows.Count
        columna = 1
        ProgressBar.Value = 0

        For Each dr In ds.Tables(0).Rows
            columna = 1
            For Each dc In ds.Tables(0).Columns

                If es_numero(dr(dc.ColumnName).ToString) = False Then
                    objHojaExcel.Range(nombreColumna(columna) & fila).Value = "'" & dr(dc.ColumnName).ToString
                Else
                    objHojaExcel.Range(nombreColumna(columna) & fila).Value = De_Txt_a_Num_01(dr(dc.ColumnName).ToString, 3, "")
                End If
                columna += 1
            Next
            fila += 1
            ProgressBar.Value += 1
        Next

        '//////////////////////////////////////
        '// Ajustamos automaticamente el ancho
        '// de todas las columnas utilizada
        '//////////////////////////////////////

        objRango = objHojaExcel.Range("A1:" & nombreColumna(ds.Tables(0).Columns.Count) & ds.Tables(0).Rows.Count.ToString)
        objRango.Select()
        objRango.Columns.AutoFit()

        '/////////////////////////////////////
        '// Le decimos a Excel que se muestre
        '/////////////////////////////////////
        'MsgBox("Exportación a Excel completa", MsgBoxStyle.Information, ".:: solovb.net ::.")

        m_Excel.Visible = True
        ProgressBar.Value = 0
    End Sub

    Public Function nombreColumna(ByVal numero As Integer) As String
        Dim columna(256) As String

        columna(1) = "A"
        columna(2) = "B"
        columna(3) = "C"
        columna(4) = "D"
        columna(5) = "E"
        columna(6) = "F"
        columna(7) = "G"
        columna(8) = "H"
        columna(9) = "I"
        columna(10) = "J"
        columna(11) = "K"
        columna(12) = "L"
        columna(13) = "M"
        columna(14) = "N"
        columna(15) = "O"
        columna(16) = "P"
        columna(17) = "Q"
        columna(18) = "R"
        columna(19) = "S"
        columna(20) = "T"
        columna(21) = "U"
        columna(22) = "V"
        columna(23) = "W"
        columna(24) = "X"
        columna(25) = "Y"
        columna(26) = "Z"
        columna(27) = "AA"
        columna(28) = "AB"
        columna(29) = "AC"
        columna(30) = "AD"
        columna(31) = "AE"
        columna(32) = "AF"
        columna(33) = "AG"
        columna(34) = "AH"
        columna(35) = "AI"
        columna(36) = "AJ"
        columna(37) = "AK"
        columna(38) = "AL"
        columna(39) = "AM"
        columna(40) = "AN"
        columna(41) = "AO"
        columna(42) = "AP"
        columna(43) = "AQ"
        columna(44) = "AR"
        columna(45) = "AS"
        columna(46) = "AT"
        columna(47) = "AU"
        columna(48) = "AV"
        columna(49) = "AW"
        columna(50) = "AX"
        columna(51) = "AY"
        columna(52) = "AZ"
        columna(53) = "BA"
        columna(54) = "BB"
        columna(55) = "BC"
        columna(56) = "BD"
        columna(57) = "BE"
        columna(58) = "BF"
        columna(59) = "BG"
        columna(60) = "BH"
        columna(61) = "BI"
        columna(62) = "BJ"
        columna(63) = "BK"
        columna(64) = "BL"
        columna(65) = "BM"
        columna(66) = "BN"
        columna(67) = "BO"
        columna(68) = "BP"
        columna(69) = "BQ"
        columna(70) = "BR"
        columna(71) = "BS"
        columna(72) = "BT"
        columna(73) = "BU"
        columna(74) = "BV"
        columna(75) = "BW"
        columna(76) = "BX"
        columna(77) = "BY"
        columna(78) = "BZ"
        columna(79) = "CA"
        columna(80) = "CB"
        columna(81) = "CC"
        columna(82) = "CD"
        columna(83) = "CE"
        columna(84) = "CF"
        columna(85) = "CG"
        columna(86) = "CH"
        columna(87) = "CI"
        columna(88) = "CJ"
        columna(89) = "CK"
        columna(90) = "CL"
        columna(91) = "CM"
        columna(92) = "CN"
        columna(93) = "CO"
        columna(94) = "CP"
        columna(95) = "CQ"
        columna(96) = "CR"
        columna(97) = "CS"
        columna(98) = "CT"
        columna(99) = "CU"
        columna(100) = "CV"
        columna(101) = "CW"
        columna(102) = "CX"
        columna(103) = "CY"
        columna(104) = "CZ"
        columna(105) = "DA"
        columna(106) = "DB"
        columna(107) = "DC"
        columna(108) = "DD"
        columna(109) = "DE"
        columna(110) = "DF"
        columna(111) = "DG"
        columna(112) = "DH"
        columna(113) = "DI"
        columna(114) = "DJ"
        columna(115) = "DK"
        columna(116) = "DL"
        columna(117) = "DM"
        columna(118) = "DN"
        columna(119) = "DO"
        columna(120) = "DP"
        columna(121) = "DQ"
        columna(122) = "DR"
        columna(123) = "DS"
        columna(124) = "DT"
        columna(125) = "DU"
        columna(126) = "DV"
        columna(127) = "DW"
        columna(128) = "DX"
        columna(129) = "DY"
        columna(130) = "DZ"
        columna(131) = "EA"
        columna(132) = "EB"
        columna(133) = "EC"
        columna(134) = "ED"
        columna(135) = "EE"
        columna(136) = "EF"
        columna(137) = "EG"
        columna(138) = "EH"
        columna(139) = "EI"
        columna(140) = "EJ"
        columna(141) = "EK"
        columna(142) = "EL"
        columna(143) = "EM"
        columna(144) = "EN"
        columna(145) = "EO"
        columna(146) = "EP"
        columna(147) = "EQ"
        columna(148) = "ER"
        columna(149) = "ES"
        columna(150) = "ET"
        columna(151) = "EU"
        columna(152) = "EV"
        columna(153) = "EW"
        columna(154) = "EX"
        columna(155) = "EY"
        columna(156) = "EZ"
        columna(157) = "FA"
        columna(158) = "FB"
        columna(159) = "FC"
        columna(160) = "FD"
        columna(161) = "FE"
        columna(162) = "FF"
        columna(163) = "FG"
        columna(164) = "FH"
        columna(165) = "FI"
        columna(166) = "FJ"
        columna(167) = "FK"
        columna(168) = "FL"
        columna(169) = "FM"
        columna(170) = "FN"
        columna(171) = "FO"
        columna(172) = "FP"
        columna(173) = "FQ"
        columna(174) = "FR"
        columna(175) = "FS"
        columna(176) = "FT"
        columna(177) = "FU"
        columna(178) = "FV"
        columna(179) = "FW"
        columna(180) = "FX"
        columna(181) = "FY"
        columna(182) = "FZ"
        columna(183) = "GA"
        columna(184) = "GB"
        columna(185) = "GC"
        columna(186) = "GD"
        columna(187) = "GE"
        columna(188) = "GF"
        columna(189) = "GG"
        columna(190) = "GH"
        columna(191) = "GI"
        columna(192) = "GJ"
        columna(193) = "GK"
        columna(194) = "GL"
        columna(195) = "GM"
        columna(196) = "GN"
        columna(197) = "GO"
        columna(198) = "GP"
        columna(199) = "GQ"
        columna(200) = "GR"
        columna(201) = "GS"
        columna(202) = "GT"
        columna(203) = "GU"
        columna(204) = "GV"
        columna(205) = "GW"
        columna(206) = "GX"
        columna(207) = "GY"
        columna(208) = "GZ"
        columna(209) = "HA"
        columna(210) = "HB"
        columna(211) = "HC"
        columna(212) = "HD"
        columna(213) = "HE"
        columna(214) = "HF"
        columna(215) = "HG"
        columna(216) = "HH"
        columna(217) = "HI"
        columna(218) = "HJ"
        columna(219) = "HK"
        columna(220) = "HL"
        columna(221) = "HM"
        columna(222) = "HN"
        columna(223) = "HO"
        columna(224) = "HP"
        columna(225) = "HQ"
        columna(226) = "HR"
        columna(227) = "HS"
        columna(228) = "HT"
        columna(229) = "HU"
        columna(230) = "HV"
        columna(231) = "HW"
        columna(232) = "HX"
        columna(233) = "HY"
        columna(234) = "HZ"
        columna(235) = "IA"
        columna(236) = "IB"
        columna(237) = "IC"
        columna(238) = "ID"
        columna(239) = "IE"
        columna(240) = "IF"
        columna(241) = "IG"
        columna(242) = "IH"
        columna(243) = "II"
        columna(244) = "IJ"
        columna(245) = "IK"
        columna(246) = "IL"
        columna(247) = "IM"
        columna(248) = "IN"
        columna(249) = "IO"
        columna(250) = "IP"
        columna(251) = "IQ"
        columna(252) = "IR"
        columna(253) = "IS"
        columna(254) = "IT"
        columna(255) = "IU"
        columna(256) = "IV"

        Return columna(numero)
    End Function
End Class

Public Class CrearProducto

    Dim myTrans As SqlClient.SqlTransaction
    Dim Comando As SqlClient.SqlCommand

    Dim NewEmpresaPR As String ' Empresa
    Dim NewSucursalPR As String ' Sucursal 
    Dim NewBodegaPR As String ' Bodega

    Dim NewCodAlternativoProveedorProducto As String ' Codigo Alternativo
    Dim NewCodProveedorProducto As String ' Codigo entidad
    Dim NewCodigoImpuesto As String ' Codigo del impuesto del producto
    Dim NewCodigoListaPR As String ' Codigo de lista de precios que se guardara en TABPRE


    

    Function RevisarTablaPaso(ByVal SqlQuery As String) As DataTable
        Dim TblPaso As DataTable
        Ejecutar_consulta_SQLaccess(SqlQuery)
        TblPaso = New DataTable
        dbD.Fill(TblPaso) ' ---  aca se carga la tabla de la base access completa
        Return TblPaso
    End Function

    Function EjecutarComando(ByVal Cn As SqlConnection)
        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn)
        Comando.Transaction = myTrans
        Comando.ExecuteNonQuery()
    End Function



End Class

Public Class Importar_excel

    Public Function Importar_Excel_Array(ByVal Direccion_Archivo_XLS As String, _
                                         ByVal Extencion_ As String, _
                                         Optional ByVal Hoja As Integer = 0)

        ExcelWorkbook.SetLicenseCode("SA014N-E4113A-E1ALDA-101800")
        Dim Workbook As Object

        Dim Ext_ As String = LCase(Extencion_)

        If Ext_ = "xls" Then
            Workbook = ExcelWorkbook.ReadXLSX(Direccion_Archivo_XLS)
        ElseIf Ext_ = "xlsx" Then
            Workbook = ExcelWorkbook.ReadXLSX(Direccion_Archivo_XLS)
        End If

        Dim Filas As Double = Workbook.Worksheets(Hoja).Rows.Count
        Dim Columnas As Double = Workbook.Worksheets(Hoja).Columns.Count

        Dim Arreglo(Filas - 1, Columnas - 1) As String


        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Precio")

        For i As Integer = 1 To Filas  ' Workbook.Worksheets(0).Rows.Count

            For cl As Integer = 0 To Columnas - 1
                Arreglo(i - 1, cl) = Workbook.Worksheets(Hoja).Cells(i - 1, cl).Value
            Next

        Next i

        Return Arreglo

    End Function



End Class


#End Region


Public Module AdapterAccess

    Function ActualizarGrillaAccess(ByVal Grilla As DataGridView, _
                                    ByVal sql1 As String, _
                                    Optional ByVal nombreBaseDatos As String = "Tmptools.mdb")
        'Dim sql1 As String = ConsultaSQLGrilladePaso

        Try
            ' Referenciamos el objeto DataTable enlazado
            ' con el control DataGridView.
            '
            Dim dt As DataTable = DirectCast(Grilla.DataSource, DataTable)
            ' Procedemos a actualizar la base de datos.
            '

            Dim Ruta As String = AppPath(True) & "Data"
            Dim strConexion As String = ("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & _
                                               Ruta & "\" & nombreBaseDatos)

            Dim n As Integer = GrabarCambiosTblAccess(dt, sql1, strConexion)
            'MsgBox(strConexion)

            'MessageBox.Show("Nº de registros afectados: " & CStr(n))

        Catch ex As Exception
            ' Se ha producido un error
            '
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Function GrabarCambiosTblAccess(ByRef DatosGrilla As DataTable, ByVal sqlStr As String, ByVal connStr As String) As Long
        'Open a connection to the database for updating
        Dim changes As Integer
        Dim dataAdapter As New OleDb.OleDbDataAdapter(sqlStr, connStr)
        Dim commandBuilder As New OleDb.OleDbCommandBuilder(dataAdapter)
        'Update the database with changes from the data table
        Try


            With dataAdapter
                .InsertCommand = commandBuilder.GetInsertCommand
                .DeleteCommand = commandBuilder.GetDeleteCommand()
                .UpdateCommand = commandBuilder.GetUpdateCommand()
            End With

            ' Procedemos a actualizar la base de datos, devolviendo
            ' el número de registros afectados.
            '
            'Return da.Update(dt)


            changes = dataAdapter.Update(DatosGrilla)
            'changes = dataAdapter.Update(DatosGrilla)

        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show("DETAILED: " & ex.ToString)
            MessageBox.Show("GENERAL: " & ex.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        dataAdapter.Dispose()
        'Display the number of changes made

        Return changes
        'If changes > 0 Then
        ' MsgBox(CStr(changes) & " changed rows were stored in the database.")
        ' Else
        ' MsgBox("No changes made.")
        ' End If
    End Function

    Public Class ExporExcelGrilla

        Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean

            'Creamos las variables
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            Try
                'Añadimos el Libro al programa, y la hoja al libro
                exLibro = exApp.Workbooks.Add
                exHoja = exLibro.Worksheets.Add()

                ' ¿Cuantas columnas y cuantas filas?
                Dim NCol As Integer = ElGrid.ColumnCount
                Dim NRow As Integer = ElGrid.RowCount

                'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
                For i As Integer = 1 To NCol
                    exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                    'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
                Next

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                    Next
                Next
                'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.Item(1).HorizontalAlignment = 3
                exHoja.Columns.AutoFit()


                'Aplicación visible
                exApp.Application.Visible = True

                exHoja = Nothing
                exLibro = Nothing
                exApp = Nothing

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                'http://programaciontotal.blogspot.com
                Return False
            End Try

            Return True

        End Function
    End Class

End Module
