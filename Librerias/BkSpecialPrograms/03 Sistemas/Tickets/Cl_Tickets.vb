Imports System.Data.SqlClient

Public Class Cl_Tickets

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Stk_Tickets As New Zw_Stk_Tickets
    Public Property Zw_Stk_Tickets_Producto As New Zw_Stk_Tickets_Producto
    Public Property Zw_Stk_Tipos As New Zw_Stk_Tipos
    Public Property Zw_Stk_Tickets_Acciones As New Zw_Stk_Tickets_Acciones
    Public Property Ls_Zw_Stk_Tickets_Producto As New List(Of Zw_Stk_Tickets_Producto)


    Public Sub New()

        Zw_Stk_Tickets.Empresa = ModEmpresa
        Zw_Stk_Tickets.Sucursal = ModSucursal
        Zw_Stk_Tickets.Numero = String.Empty
        Zw_Stk_Tickets.Prioridad = String.Empty
        Zw_Stk_Tickets.Asunto = String.Empty
        Zw_Stk_Tickets.Descripcion = String.Empty

        Zw_Stk_Tickets_Producto.Codigo = String.Empty
        Zw_Stk_Tickets_Producto.Descripcion = String.Empty

    End Sub

    Function Fx_Llenar_Ticket(_Id_Ticket As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario_Crea" & vbCrLf &
                       "Where Id = " & _Id_Ticket
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.Detalle = "No se encontro registro"
                Throw New System.Exception("No se encontro el registro en la tabla de Zw_Stk_Tickets con el Id = " & _Id_Ticket)
            End If

            Zw_Stk_Tickets.Id = _Id_Ticket

            With Zw_Stk_Tickets

                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .Numero = _Row.Item("Numero")
                .Id_Area = _Row.Item("Id_Area")
                .Id_Tipo = _Row.Item("Id_Tipo")
                .Prioridad = _Row.Item("Prioridad")
                .FechaCreacion = _Row.Item("FechaCreacion")
                .CodFuncionario_Crea = _Row.Item("CodFuncionario_Crea")
                .Asunto = _Row.Item("Asunto")
                .Descripcion = _Row.Item("Descripcion")
                .Asignado = _Row.Item("Asignado")
                .AsignadoGrupo = _Row.Item("AsignadoGrupo")
                .Id_Grupo = _Row.Item("Id_Grupo")
                .AsignadoAgente = _Row.Item("AsignadoAgente")
                .CodAgente = _Row.Item("CodAgente")
                .Estado = _Row.Item("Estado")
                .UltAccion = _Row.Item("UltAccion")
                .CodFuncionario_Cierra = _Row.Item("UltAccion")
                .FechaCierre = NuloPorNro(_Row.Item("FechaCierre"), Now)
                .Id_Padre = _Row.Item("Id_Padre")
                .Rechazado = _Row.Item("Rechazado")
                .Aceptado = _Row.Item("Rechazado")
                .Id_Raiz = _Row.Item("Id_Raiz")
                .SubNro = _Row.Item("SubNro")
                .Cerraddo = _Row.Item("SubNro")
                .FechaCerrado = _Row.Item("SubNro")

            End With

            _Mensaje.EsCorrecto = True

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function FX_Llenar_Producto(_Id_Ticket As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Zw_Stk_Tickets_Producto As New Zw_Stk_Tickets_Producto

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Where Id_Ticket = " & _Id_Ticket
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.Detalle = "No se encontro registro"
                Throw New System.Exception("No se encontro el registro en la tabla de Zw_Stk_Tickets con el Id_Ticket = " & _Id_Ticket)
            End If

            With _Zw_Stk_Tickets_Producto

                .Id = _Row.Item("Id")
                .Id_Ticket = _Row.Item("Id_Ticket")
                .Id_Raiz = _Row.Item("Id_Raiz")
                .Id_Padre = _Row.Item("Id_Padre")
                .Id_TicketAc = _Row.Item("Id_TicketAc")
                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .Bodega = _Row.Item("Bodega")
                .Codigo = _Row.Item("Codigo")
                .Descripcion = _Row.Item("Descripcion")
                .Rtu = _Row.Item("Rtu")
                .UdMedida = _Row.Item("UdMedida")
                .Um = _Row.Item("Um")
                .Ud1 = _Row.Item("Ud1")
                .Ud2 = _Row.Item("Ud2")
                .StfiEnBodega = _Row.Item("StfiEnBodega")
                .Cantidad = _Row.Item("Cantidad")
                .Diferencia = _Row.Item("Diferencia")
                .FechaRev = _Row.Item("FechaRev")
                .Ubicacion = _Row.Item("Ubicacion")
                .ConfCantCero = _Row.Item("ConfCantCero")

            End With

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Zw_Stk_Tickets_Producto

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function FX_Llenar_Producto_Id(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Zw_Stk_Tickets_Producto As New Zw_Stk_Tickets_Producto

        Try

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Where Id = " & _Id
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                _Mensaje.Detalle = "No se encontro registro"
                Throw New System.Exception("No se encontro el registro en la tabla de Zw_Stk_Tickets con el Id = " & _Id)
            End If

            With _Zw_Stk_Tickets_Producto

                .Id = _Row.Item("Id")
                .Id_Ticket = _Row.Item("Id_Ticket")
                .Id_Raiz = _Row.Item("Id_Raiz")
                .Id_Padre = _Row.Item("Id_Padre")
                .Id_TicketAc = _Row.Item("Id_TicketAc")
                .Empresa = _Row.Item("Empresa")
                .Sucursal = _Row.Item("Sucursal")
                .Bodega = _Row.Item("Bodega")
                .Codigo = _Row.Item("Codigo")
                .Descripcion = _Row.Item("Descripcion")
                .Rtu = _Row.Item("Rtu")
                .UdMedida = _Row.Item("UdMedida")
                .Um = _Row.Item("Um")
                .Ud1 = _Row.Item("Ud1")
                .Ud2 = _Row.Item("Ud2")
                .StfiEnBodega = _Row.Item("StfiEnBodega")
                .Cantidad = _Row.Item("Cantidad")
                .Diferencia = _Row.Item("Diferencia")
                .FechaRev = _Row.Item("FechaRev")
                .Ubicacion = _Row.Item("Ubicacion")
                .ConfCantCero = _Row.Item("ConfCantCero")

            End With

            _Mensaje.EsCorrecto = True
            _Mensaje.Tag = _Zw_Stk_Tickets_Producto

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_Llenar_Tipo(_Id_Tipo As Integer) As Zw_Stk_Tipos

        Dim _Tipo As New Zw_Stk_Tipos

        With _Tipo

            Consulta_sql = "Select Tp.*,Isnull(Tf.NOKOFU,'') As 'Agente',Isnull(Gr.Grupo,'') As Grupo" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos Tp" & vbCrLf &
                       "Left Join TABFU Tf On Tf.KOFU = Tp.CodAgente" & vbCrLf &
                       "Left Join " & _Global_BaseBk & "Zw_Stk_Grupos Gr On Tp.Id_Grupo = Gr.Id" & vbCrLf &
                       "Where Tp.Id = " & _Id_Tipo

            'Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id_Tipo

            Dim _Row_Tipo As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Tipo) Then

                .Id = _Row_Tipo.Item("Id")
                .Id_Area = _Row_Tipo.Item("Id_Area")
                .Tipo = _Row_Tipo.Item("Tipo")
                .ExigeProducto = _Row_Tipo.Item("ExigeProducto")
                .Asignado = _Row_Tipo.Item("Asignado")
                .AsignadoGrupo = _Row_Tipo.Item("AsignadoGrupo")
                .AsignadoAgente = _Row_Tipo.Item("AsignadoAgente")
                .Id_Grupo = _Row_Tipo.Item("Id_Grupo")
                .Grupo = _Row_Tipo.Item("Grupo")
                .CodAgente = _Row_Tipo.Item("CodAgente")
                .Agente = _Row_Tipo.Item("Agente")
                .CieTk_Id_Area = _Row_Tipo.Item("CieTk_Id_Area")
                .CieTk_Id_Tipo = _Row_Tipo.Item("CieTk_Id_Tipo")
                .Inc_Cantidades = _Row_Tipo.Item("Inc_Cantidades")
                .Inc_Fecha = _Row_Tipo.Item("Inc_Fecha")
                .Inc_Hora = _Row_Tipo.Item("Inc_Hora")
                .BodModalXDefecto = _Row_Tipo.Item("BodModalXDefecto")
                .PreguntaCreaNewTicket = _Row_Tipo.Item("PreguntaCreaNewTicket")
                .CerrarAgenteSinPerm = _Row_Tipo.Item("CerrarAgenteSinPerm")
                .RespuestaXDefecto = _Row_Tipo.Item("RespuestaXDefecto")
                .RespuestaXDefectoCerrar = _Row_Tipo.Item("RespuestaXDefectoCerrar")
                .EsTicketUnico = _Row_Tipo.Item("EsTicketUnico")
                .CierraRaiz = _Row_Tipo.Item("CierraRaiz")
                .ExigeDocCerrar = _Row_Tipo.Item("ExigeDocCerrar")
                .TidoDocCerrar = _Row_Tipo.Item("TidoDocCerrar")

            End If

        End With

        Return _Tipo

    End Function

    Function Fx_NvoNro_OT() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_DataTable("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stk_Tickets")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "#Tk-000000"
        End If

        _NvoNro_OT = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _NvoNro_OT

    End Function

    Function Fx_Grabar_Nuevo_Tickets() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        'Throw New System.Exception("An exception has occurred.")

        Try

            Dim dfd1 As System.Data.SqlClient.SqlDataReader
            Dim _Tbl_Agentes As DataTable

            With Zw_Stk_Tickets

                .Empresa = ModEmpresa
                .Sucursal = ModSucursal

                If .Id_Raiz = 0 Then .Numero = Fx_NvoNro_OT()

                .Estado = "ABIE"

                Consulta_sql = String.Empty

                If .Asignado Then

                    If .AsignadoGrupo Then
                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = '" & .Id_Grupo & "'"
                    End If

                    If .AsignadoAgente Then
                        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Agentes Where CodAgente = '" & .CodAgente & "'"
                    End If

                End If


                If Not String.IsNullOrEmpty(Consulta_sql) Then

                    _Tbl_Agentes = _Sql.Fx_Get_DataTable(Consulta_sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        _Mensaje.Detalle = "Error al grabar"
                        Throw New System.Exception(_Sql.Pro_Error)
                    End If

                End If

                myTrans = Cn2.BeginTransaction()

                Comando = New System.Data.SqlClient.SqlCommand("Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Stk_Tickets Where Numero = '" & .Numero & "'", Cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    .SubNro = numero_(dfd1("Cuenta") + 1, 3)
                End While
                dfd1.Close()

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets (Empresa,Sucursal,Numero,Estado,Asunto,Descripcion,FechaCreacion,SubNro) Values " &
                       "('" & .Empresa & "','" & .Sucursal & "','" & .Numero & "','" & .Estado & "','" & .Asunto & "','" & .Descripcion & "',Getdate(),'" & .SubNro & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                dfd1 = Comando.ExecuteReader()
                While dfd1.Read()
                    .Id = dfd1("Identity")
                End While
                dfd1.Close()


                If .Id_Raiz = 0 Then
                    .Id_Raiz = .Id
                End If

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " & vbCrLf &
                               "Id_Area = " & .Id_Area &
                               ",Id_Tipo = " & .Id_Tipo &
                               ",Prioridad = '" & .Prioridad & "'" &
                               ",CodFuncionario_Crea = '" & .CodFuncionario_Crea & "'" &
                               ",Asunto = '" & .Asunto & "'" &
                               ",Descripcion = '" & .Descripcion & "'" &
                               ",Asignado = " & Convert.ToInt32(.Asignado) &
                               ",AsignadoGrupo = " & Convert.ToInt32(.AsignadoGrupo) &
                               ",Id_Grupo = " & .Id_Grupo &
                               ",Id_Padre = '" & .Id_Padre & "'" &
                               ",Id_Raiz = '" & .Id_Raiz & "'" & vbCrLf &
                               "Where Id = " & .Id
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            With Zw_Stk_Tickets_Acciones

                .Id_Ticket = Zw_Stk_Tickets.Id

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " & vbCrLf &
                               "Id_Ticket = " & .Id_Ticket & vbCrLf &
                               ",Accion = '" & .Accion & "'" & vbCrLf &
                               ",Descripcion = '" & .Descripcion & "'" & vbCrLf &
                               ",Fecha = Getdate()" & vbCrLf &
                               ",En_Construccion = 0" & vbCrLf &
                               ",Aceptado = " & Convert.ToInt32(.Aceptado) & vbCrLf &
                               ",CreaNewTicket = " & Convert.ToInt32(.CreaNewTicket) & vbCrLf &
                               ",Cierra_Ticket = " & Convert.ToInt32(.Cierra_Ticket) & vbCrLf &
                               ",CodFunGestiona = '" & .CodFunGestiona & "'" & vbCrLf &
                               ",Id_Raiz = '" & Zw_Stk_Tickets.Id_Raiz & "'" & vbCrLf &
                               ",Id_Ticket_Cierra = '" & .Id_Ticket_Cierra & "'" & vbCrLf &
                               ",Id_Ticket_Crea = '" & .Id_Ticket_Crea & "'" & vbCrLf &
                               ",Asunto = '" & .Asunto & "'" & vbCrLf &
                               ",ConfSinDoc_Cierra = " & Convert.ToInt32(.ConfSinDoc_Cierra) & vbCrLf &
                               ",Motivo_Cierra = '" & .Motivo_Cierra & "'" & vbCrLf &
                               "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With


            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Set Id_Ticket = " & Zw_Stk_Tickets.Id & ", En_Construccion = 0" & vbCrLf &
                           "Where Id_TicketAc = " & Zw_Stk_Tickets_Acciones.Id
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Dim _Id_Producto As Integer = Zw_Stk_Tickets_Producto.Id

            For Each _Prod As Zw_Stk_Tickets_Producto In Ls_Zw_Stk_Tickets_Producto

                With _Prod

                    If .Id_Ticket = 0 Then

                        .Id_Ticket = Zw_Stk_Tickets.Id
                        .Id_Raiz = Zw_Stk_Tickets.Id_Raiz
                        .Numero = Zw_Stk_Tickets.Numero

                        .Id_TicketAc = Zw_Stk_Tickets_Acciones.Id

                        If Not String.IsNullOrEmpty(.Codigo) Then

                            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Producto (Id_Ticket,Id_Raiz,Numero,Empresa,Sucursal,Bodega," &
                                           "Codigo,Descripcion,Rtu,UdMedida,Ud1,Ud2,Um,StfiEnBodega,Cantidad,Diferencia,FechaRev,Ubicacion,Id_TicketAc," &
                                           "Id_Padre,ConfCantCero) Values " &
                                           "(" & .Id_Ticket & "," & .Id_Raiz & ",'" & .Numero & "','" & .Empresa & "','" & .Sucursal & "','" & .Bodega &
                                           "','" & .Codigo & "','" & .Descripcion & "'," & De_Num_a_Tx_01(.Rtu, False, 5) &
                                           "," & .UdMedida & ",'" & .Ud1 & "','" & .Ud2 & "','" & .Um & "'," & De_Num_a_Tx_01(.StfiEnBodega, False, 5) &
                                           "," & De_Num_a_Tx_01(.Cantidad, False, 5) &
                                           "," & De_Num_a_Tx_01(.Diferencia, False, 5) &
                                           ",'" & Format(.FechaRev, "yyyyMMdd HH:mm") &
                                           "','" & .Ubicacion & "'," & .Id_TicketAc & "," & .Id_Padre & "," & Convert.ToInt32(.ConfCantCero) & ")"

                            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                            Comando.Transaction = myTrans
                            Comando.ExecuteNonQuery()

                        End If

                    End If

                End With

            Next

            If Not IsNothing(_Tbl_Agentes) Then

                For Each _Fila As DataRow In _Tbl_Agentes.Rows

                    Dim _CodAgente As String = _Fila.Item("CodAgente")

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado (Id_Ticket,CodAgente,Activo) Values (" & Zw_Stk_Tickets.Id & ",'" & _CodAgente & "',1)"
                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                Next

            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = Zw_Stk_Tickets.Id
            _Mensaje.Detalle = "Grabación correcta"
            _Mensaje.Mensaje = "Se graba correctamente el Ticket " & Zw_Stk_Tickets.Numero & "-" & Zw_Stk_Tickets.SubNro

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Mensaje.Mensaje = ex.Message
            _Mensaje.Resultado = Consulta_sql
            Zw_Stk_Tickets.Id = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Grabar_Nueva_Accion(_CodFuncionario As String, _Mensaje As Boolean, _Rechazar As Boolean) As Integer

        Dim _Accion As String

        If _Mensaje Then
            _Accion = "MENS"
        Else
            _Accion = "RESP"
        End If

        If _Rechazar Then
            _Accion = "RECH"
        End If

        Dim _Id_TicketAc As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones (Id_Ticket,Accion,Descripcion,Fecha,CodFuncionario,En_Construccion,CodFunGestiona) Values " &
                       "(" & Zw_Stk_Tickets.Id & ",'" & _Accion & "','',Getdate(),'" & _CodFuncionario & "',1,'" & _CodFuncionario & "')"
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New System.Data.SqlClient.SqlCommand("Select @@IDENTITY AS 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Id_TicketAc = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Id_TicketAc = 0
            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Id_TicketAc

    End Function

    Function Fx_Grabar_Nueva_Accion2(_Zw_Stk_Tickets_Acciones As Zw_Stk_Tickets_Acciones, _Enconstruccion As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _Id_TicketAc As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With _Zw_Stk_Tickets_Acciones

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones (Id_Ticket,Accion,Descripcion,Fecha,CodAgente," &
                               "CodFuncionario,En_Construccion,CodFunGestiona,Rechazado,Aceptado,Id_Raiz,Id_Ticket_Cierra,Id_Ticket_Crea,Asunto) Values " &
                               "(" & .Id_Ticket & ",'" & .Accion & "','" & .Descripcion & "',Getdate(),'" & .CodAgente & "','" & .CodFuncionario & "'," &
                               Convert.ToInt32(_Enconstruccion) & ",'" & .CodFunGestiona & "'," & Convert.ToInt32(.Rechazado) & "," &
                               Convert.ToInt32(.Aceptado) & "," & .Id_Raiz & "," & .Id_Ticket_Cierra & "," & .Id_Ticket_Crea & ",'" & .Asunto & "')"

            End With

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Comando = New System.Data.SqlClient.SqlCommand("Select @@IDENTITY AS 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Id_TicketAc = dfd1("Identity")
            End While
            dfd1.Close()

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True

        Catch ex As Exception

            _Id_TicketAc = 0
            _Mensaje.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        _Mensaje.Id = _Id_TicketAc

        Return _Mensaje

    End Function

    Function Fx_Cerrar_Ticket(_CodFuncionario As String,
                              _Descripcion As String,
                              _Cierra_Ticket As Boolean,
                              _Solicita_Cierre As Boolean,
                              _CreaNewTicket As Boolean,
                              _AnulaTicket As Boolean,
                              _Aceptado As Boolean,
                              _Rechazado As Boolean,
                              _CierraTicketPadre As Boolean,
                              _CierraTicektRaiz As Boolean,
                               ByRef _Zw_Stk_Tickets_Acciones As Zw_Stk_Tickets_Acciones) As LsValiciones.Mensajes

        Dim _Mensaje_Ticket As New LsValiciones.Mensajes

        Dim _Estado As String

        If _Cierra_Ticket Then
            _Estado = "CERR"
            If _CreaNewTicket Then
                _Estado = "PROC"
            End If
        End If

        If _Solicita_Cierre Then
            _Estado = "SOLC"
        End If

        If _AnulaTicket Then
            _Estado = "NULO"
        End If

        '    ' Acciones y Estados
        '    'CERR = Cierra ticket
        '    'CECR = Cierra ticket y crea nuevo ticket a partir de este
        '    'SOLC = Solicita cierre de ticket
        '    'NULO = Anula ticket
        '    'PROC = TickeT en proceso

        Dim _Id_TicketAc As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Dim _FechaCierre As String

            If _Cierra_Ticket Then
                _FechaCierre = ",FechaCierre = Getdate()"
            End If

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " &
                           "Estado = '" & _Estado & "'" & _FechaCierre & vbCrLf &
                           ",Aceptado = " & Convert.ToInt32(_Aceptado) & vbCrLf &
                           ",Rechazado = " & Convert.ToInt32(_Rechazado) & vbCrLf &
                           "Where Id = " & Zw_Stk_Tickets.Id

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If _AnulaTicket Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_Ticket = " & Zw_Stk_Tickets.Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            '_Zw_Stk_Tickets_Acciones.Id = Zw_Stk_Tickets.Id

            If _CierraTicketPadre Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " &
                               "Estado = '" & _Estado & "'" & _FechaCierre & ",Aceptado = " & Convert.ToInt32(_Aceptado) & vbCrLf &
                               "Where Id = " & Zw_Stk_Tickets.Id_Padre

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If _CierraTicektRaiz Then

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " &
                               "Estado = '" & _Estado & "'" & _FechaCierre & ",Aceptado = " & Convert.ToInt32(_Aceptado) & vbCrLf &
                               "Where Id = " & Zw_Stk_Tickets.Id_Raiz

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            If Not IsNothing(_Zw_Stk_Tickets_Acciones) Then

                With _Zw_Stk_Tickets_Acciones

                    '.Id_Ticket = Zw_Stk_Tickets.Id

                    If CBool(.Id) Then

                        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " & vbCrLf &
                                       "Id_Ticket = " & .Id_Ticket & vbCrLf &
                                       ",Accion = '" & .Accion & "'" & vbCrLf &
                                       ",Descripcion = '" & .Descripcion & "'" & vbCrLf &
                                       ",Fecha = Getdate()" & vbCrLf &
                                       ",En_Construccion = 0" & vbCrLf &
                                       ",Aceptado = " & Convert.ToInt32(.Aceptado) & vbCrLf &
                                       ",CreaNewTicket = " & Convert.ToInt32(.CreaNewTicket) & vbCrLf &
                                       ",Cierra_Ticket = " & Convert.ToInt32(.Cierra_Ticket) & vbCrLf &
                                       ",CodFunGestiona = '" & .CodFunGestiona & "'" & vbCrLf &
                                       ",Id_Raiz = '" & Zw_Stk_Tickets.Id_Raiz & "'" & vbCrLf &
                                       ",Id_Ticket_Cierra = '" & .Id_Ticket_Cierra & "'" & vbCrLf &
                                       ",Id_Ticket_Crea = '" & .Id_Ticket_Crea & "'" & vbCrLf &
                                       ",Asunto = '" & .Asunto & "'" & vbCrLf &
                                       ",Tido_Cierra = '" & .Tido_Cierra & "'" & vbCrLf &
                                       ",Nudo_Cierra = '" & .Nudo_Cierra & "'" & vbCrLf &
                                       ",Idmaeedo_Cierra = " & .Idmaeedo_Cierra & vbCrLf &
                                       ",ConfSinDoc_Cierra = " & Convert.ToInt32(.ConfSinDoc_Cierra) & vbCrLf &
                                       ",Motivo_Cierra = '" & .Motivo_Cierra & "'" & vbCrLf &
                                       "Where Id = " & .Id
                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    Else

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones (Id_Ticket,Accion,Descripcion,Fecha,CodAgente," &
                                   "CodFuncionario,En_Construccion,CodFunGestiona,Rechazado,Aceptado,Id_Raiz,Id_Ticket_Cierra,Id_Ticket_Crea," &
                                   "Asunto,Tido_Cierra,Nudo_Cierra,Idmaeedo_Cierra,ConfSinDoc_Cierra,Motivo_Cierra) Values " &
                                   "(" & .Id_Ticket & ",'" & .Accion & "','" & .Descripcion & "',Getdate(),'" & .CodAgente & "','" & .CodFuncionario & "'," &
                                   Convert.ToInt32(.En_Construccion) & ",'" & .CodFunGestiona & "'," & Convert.ToInt32(.Rechazado) & "," &
                                   Convert.ToInt32(.Aceptado) & "," & .Id_Raiz & "," & .Id_Ticket_Cierra & "," & .Id_Ticket_Crea &
                                   ",'" & .Asunto & "','" & .Tido_Cierra & "','" & .Nudo_Cierra & "'," & .Idmaeedo_Cierra &
                                   "," & Convert.ToInt32(.ConfSinDoc_Cierra) & ",'" & .Motivo_Cierra & "')"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                        Comando = New System.Data.SqlClient.SqlCommand("Select @@IDENTITY AS 'Identity'", Cn2)
                        Comando.Transaction = myTrans
                        Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                        While dfd1.Read()
                            .Id = dfd1("Identity")
                        End While
                        dfd1.Close()

                    End If

                End With

            End If

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Ticket.EsCorrecto = True

            If _Cierra_Ticket Then _Mensaje_Ticket.Mensaje = "Ticket " & Zw_Stk_Tickets.Numero & " cerrado correctamente"
            If _Solicita_Cierre Then _Mensaje_Ticket.Mensaje = "Solicitud de cierre enviada correctamente"
            If _AnulaTicket Then _Mensaje_Ticket.Mensaje = "Ticket #" & Zw_Stk_Tickets.Numero & " anulado correctamente"

        Catch ex As Exception

            _Id_TicketAc = 0

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Ticket.Mensaje = ex.Message
            '_Mensaje_Ticket.Zw_Stk_Tickets_Acciones = Nothing

        End Try

        _Mensaje_Ticket.Id = _Id_TicketAc

        Return _Mensaje_Ticket

    End Function

    Function Fx_Eliminar_Grupo(_Id_Grupo) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Grupos Where Id = " & _Id_Grupo & vbCrLf &
                       "Delete " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = " & _Id_Grupo
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Consulta_sql = "Select Count(*) As Contar From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Where Id_Grupo = " & _Id_Grupo & " And Estado = 'ABIE'"
            Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans

            Dim _Contar As Integer

            Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                _Contar = dfd1("Contar")
            End While
            dfd1.Close()

            If CBool(_Contar) Then
                Throw New System.Exception("No se puede eliminar este grupo ya que tiene ticket asociados que aun están abiertos.")
            End If

            _Mensaje.EsCorrecto = True

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            _Mensaje.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Grabar_Tipo(_Zw_Stk_Tipos As Zw_Stk_Tipos) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        If _Zw_Stk_Tipos.AsignadoAgente Then Consulta_sql = "Select '" & _Zw_Stk_Tipos.CodAgente & "' As CodAgente"
        If _Zw_Stk_Tipos.AsignadoGrupo Then Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = " & _Zw_Stk_Tipos.Id_Grupo

        Dim _Area As String = _Sql.Fx_Trae_Dato(_Global_BaseBk & "Zw_Stk_Areas", "Area", "Id = " & _Zw_Stk_Tipos.Id_Area)

        Dim _Tbl_Grupo As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            If _Zw_Stk_Tipos.Id = 0 Then

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tipos (Id_Area,Tipo) Values " &
                       "(" & _Zw_Stk_Tipos.Id_Area & ",'" & _Zw_Stk_Tipos.Tipo & "')"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Zw_Stk_Tipos.Id = dfd1("Identity")
                End While
                dfd1.Close()

            End If


            Dim _Cuenta As Integer

            For Each _Fl As DataRow In _Tbl_Grupo.Rows

                Consulta_sql = "Select Count(*) As Cuenta From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos" & vbCrLf &
                               "Where Id_Area = " & _Zw_Stk_Tipos.Id_Area & " And Id_Tipo = " & _Zw_Stk_Tipos.Id & " And CodAgente = '" & _Fl.Item("CodAgente") & "'"

                Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    _Cuenta = dfd1("Cuenta")
                End While
                dfd1.Close()

                If Not CBool(_Cuenta) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos (Id_Area,Id_Tipo,CodAgente) Values " &
                           "(" & _Zw_Stk_Tipos.Id_Area & "," & _Zw_Stk_Tipos.Id & ",'" & _Fl.Item("CodAgente") & "')"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If
            Next

            With _Zw_Stk_Tipos

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tipos Set " &
                                "Tipo = '" & .Tipo.Trim & "'" & vbCrLf &
                                ",ExigeProducto = " & Convert.ToInt32(.ExigeProducto) & vbCrLf &
                                ",Asignado = " & Convert.ToInt32(.Asignado) & vbCrLf &
                                ",AsignadoGrupo = " & Convert.ToInt32(.AsignadoGrupo) & vbCrLf &
                                ",AsignadoAgente = " & Convert.ToInt32(.AsignadoAgente) & vbCrLf &
                                ",Id_Grupo = " & .Id_Grupo & vbCrLf &
                                ",CodAgente = '" & .CodAgente & "'" & vbCrLf &
                                ",CieTk_Id_Area = " & .CieTk_Id_Area & vbCrLf &
                                ",CieTk_Id_Tipo = " & .CieTk_Id_Tipo & vbCrLf &
                                ",Inc_Cantidades = " & Convert.ToInt32(.Inc_Cantidades) & vbCrLf &
                                ",Inc_Fecha = " & Convert.ToInt32(.Inc_Fecha) & vbCrLf &
                                ",Inc_Hora = " & Convert.ToInt32(.Inc_Hora) & vbCrLf &
                                ",BodModalXDefecto = " & Convert.ToInt32(.BodModalXDefecto) & vbCrLf &
                                ",PreguntaCreaNewTicket = " & Convert.ToInt32(.PreguntaCreaNewTicket) & vbCrLf &
                                ",CerrarAgenteSinPerm = " & Convert.ToInt32(.CerrarAgenteSinPerm) & vbCrLf &
                                ",RespuestaXDefecto = '" & .RespuestaXDefecto & "'" & vbCrLf &
                                ",RespuestaXDefectoCerrar = '" & .RespuestaXDefectoCerrar & "'" & vbCrLf &
                                ",EsTicketUnico = '" & Convert.ToInt32(.EsTicketUnico) & "'" & vbCrLf &
                                ",CierraRaiz = '" & Convert.ToInt32(.CierraRaiz) & "'" & vbCrLf &
                                ",ExigeDocCerrar = '" & Convert.ToInt32(.ExigeDocCerrar) & "'" & vbCrLf &
                                ",TidoDocCerrar = '" & .TidoDocCerrar & "'" & vbCrLf &
                                "Where Id = " & .Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            Dim _CodPermiso As String = "Tkt" & numero_(_Zw_Stk_Tipos.Id_Area & _Zw_Stk_Tipos.Id, 6)
            Dim _DescripcionPermiso As String = "CREAR TICKET: " & _Area.Trim & ", " & _Zw_Stk_Tipos.Tipo.Trim

            _DescripcionPermiso = Mid(_DescripcionPermiso, 1, 200)

            Consulta_sql = "Select  Count(*) As Cuenta From " & _Global_BaseBk & "ZW_Permisos" & vbCrLf &
                           "Where CodPermiso = '" & _CodPermiso & "'"

            Comando = New System.Data.SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Dim dfd2 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd2.Read()
                _Cuenta = dfd2("Cuenta")
            End While
            dfd2.Close()

            If CBool(_Cuenta) Then
                Consulta_sql = "Update " & _Global_BaseBk & "ZW_Permisos Set DescripcionPermiso = '" & _DescripcionPermiso & "' Where CodPermiso = '" & _CodPermiso & "'"
            Else
                Consulta_sql = "Insert Into " & _Global_BaseBk & "ZW_Permisos (CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso) Values " &
                               "('" & _CodPermiso & "','" & _DescripcionPermiso & "','Ticket','Sistema de Ticket')"
            End If

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()


            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = _Zw_Stk_Tipos.Id

        Catch ex As Exception

            _Mensaje.Mensaje = ex.Message
            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_Descripcion(_Id_Tipo As Integer) As String

        Dim _CantidadesStr = String.Empty
        Dim _FechaRevStr = String.Empty
        Dim _HoraStr = String.Empty
        Dim _Udad = String.Empty
        Dim _Descripcion = String.Empty


        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tipos Where Id = " & _Id_Tipo
        Dim _Row_Tipo = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Inc_Fecha As Boolean = _Row_Tipo.Item("Inc_Fecha")
        Dim _Inc_Hora As Boolean = _Row_Tipo.Item("Inc_Hora")
        Dim _Inc_Cantidades As Boolean = _Row_Tipo.Item("Inc_Cantidades")

        With Zw_Stk_Tickets_Producto

            Dim _Sucursal As String = _Sql.Fx_Trae_Dato("TABSU", "NOKOSU",
                                  "EMPRESA = '" & .Empresa & "' And KOSU = '" & .Sucursal & "'")
            Dim _Bodega As String = _Sql.Fx_Trae_Dato("TABBO", "NOKOBO",
                                "EMPRESA = '" & .Empresa & "' And KOSU = '" & .Sucursal & "' And KOBO = '" & .Bodega & "'")

            _Bodega = _Sucursal.ToString.Trim & " - " & _Bodega.ToString.Trim

            _Udad = .Um
            'If .UdMedida = 1 Then _Udad = .Um
            'If .UdMedida = 2 Then _Udad = .Ud2

            If _Inc_Cantidades Then
                _CantidadesStr = "BODEGA : " & _Bodega & vbCrLf &
                                 "UNIDAD :" & _Udad & vbCrLf &
                                 "UBICACION :" & .Ubicacion & vbCrLf &
                                 "CANTIDAD INVENTARIADA : " & .Cantidad & vbCrLf &
                                 "CANTIDAD EN BODEGA SEGUN SISTEMA : " & .StfiEnBodega & vbCrLf &
                                 "DIFERENCIA : " & .Diferencia & vbCrLf
            End If

            If _Inc_Fecha Then _FechaRevStr = "FECHA : " & CType(.FechaRev, DateTime).ToShortDateString
            If _Inc_Hora Then _HoraStr = "HORA : " & CType(.FechaRev, DateTime).ToShortTimeString

            If _Inc_Fecha AndAlso _Inc_Hora Then
                _FechaRevStr = "FECHA Y HORA : " & CType(.FechaRev, DateTime).ToShortDateString & " - " & CType(.FechaRev, DateTime).ToShortTimeString
                _HoraStr = String.Empty
            End If

            _Descripcion = "PRODUCTO : " & .Codigo.Trim & " - " & .Descripcion.Trim & vbCrLf &
                      _CantidadesStr & _FechaRevStr & _HoraStr

        End With

        Return _Descripcion

    End Function

    Function Fx_CrearCodPermiso(_Id_Area As Integer, _Id_Tipo As Integer, _DescripcionPermiso As String) As LsValiciones.Mensajes

        Dim _Mensaje As LsValiciones.Mensajes

        Try

        Catch ex As Exception

        End Try

        Dim _Row As DataRow

        Dim _CodPermiso As String = String.Empty
        Dim _CodFamilia As String = "Ticket"

        _CodPermiso = "Tkt" & numero_(_Id_Area & _Id_Tipo, 6)

        Consulta_sql = "Select Left((Replace(a.Area + ', ' + t.Tipo, ' ', ''), 200) AS DescripcionPermiso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stk_Tipos t" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Stk_Areas a ON t.Id_Area = a.Id" & vbCrLf &
                       "Where t.Id = " & _Id_Tipo & " AND t.Id_Area = " & _Id_Area

        Dim _Reg = _Sql.Fx_Cuenta_Registros("", "", False)

        Consulta_sql = "Select Semilla,CodPermiso,DescripcionPermiso,CodFamilia,NombreFamiliaPermiso,Descuento,Max_Compra
From ZW_Permisos"

    End Function

End Class

