Imports System.Data.SqlClient
Imports BkSpecialPrograms.Tickets_Db

Public Class Cl_Tickets

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Tickets As Tickets_Db.Tickets

    Public Sub New()

        Tickets = New Tickets_Db.Tickets
        Tickets.Numero = String.Empty
        Tickets.Prioridad = String.Empty
        Tickets.Asunto = String.Empty
        Tickets.Descripcion = String.Empty

        Tickets.Tickets_Producto = New Tickets_Producto
        Tickets.Tickets_Producto.Codigo = String.Empty
        Tickets.Tickets_Producto.Descripcion = String.Empty

    End Sub

    Sub Sb_Llenar_Ticket(_Id_Ticket As Integer)

        Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario_Crea" & vbCrLf &
                       "Where Id = " & _Id_Ticket
        Dim _Row_Ticket As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Tickets.Id = _Id_Ticket

        If Not IsNothing(_Row_Ticket) Then

            With Tickets

                .Empresa = _Row_Ticket.Item("Empresa")
                .Sucursal = _Row_Ticket.Item("Sucursal")
                .Numero = _Row_Ticket.Item("Numero")
                .Id_Area = _Row_Ticket.Item("Id_Area")
                .Id_Tipo = _Row_Ticket.Item("Id_Tipo")
                .Prioridad = _Row_Ticket.Item("Prioridad")
                .FechaCreacion = _Row_Ticket.Item("FechaCreacion")
                .CodFuncionario_Crea = _Row_Ticket.Item("CodFuncionario_Crea")
                .Asunto = _Row_Ticket.Item("Asunto")
                .Descripcion = _Row_Ticket.Item("Descripcion")
                .Asignado = _Row_Ticket.Item("Asignado")
                .AsignadoGrupo = _Row_Ticket.Item("AsignadoGrupo")
                .Id_Grupo = _Row_Ticket.Item("Id_Grupo")
                .AsignadoAgente = _Row_Ticket.Item("AsignadoAgente")
                .CodAgente = _Row_Ticket.Item("CodAgente")
                .Estado = _Row_Ticket.Item("Estado")
                .UltAccion = _Row_Ticket.Item("UltAccion")
                .CodFuncionario_Cierra = _Row_Ticket.Item("UltAccion")
                .FechaCierre = NuloPorNro(_Row_Ticket.Item("FechaCierre"), Now)
                .Id_Padre = _Row_Ticket.Item("Id_Padre")

            End With

            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_Tickets_Producto Where Id_Ticket = " & _Id_Ticket
            Dim _Row_Ticket_Producto As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If Not IsNothing(_Row_Ticket_Producto) Then

                With Tickets.Tickets_Producto

                    .Empresa = _Row_Ticket_Producto.Item("Empresa")
                    .Sucursal = _Row_Ticket_Producto.Item("Sucursal")
                    .Bodega = _Row_Ticket_Producto.Item("Bodega")
                    .Codigo = _Row_Ticket_Producto.Item("Codigo")
                    .Descripcion = _Row_Ticket_Producto.Item("Descripcion")
                    .Rtu = _Row_Ticket_Producto.Item("Rtu")
                    .UdMedida = _Row_Ticket_Producto.Item("UdMedida")
                    .Ud1 = _Row_Ticket_Producto.Item("Ud1")
                    .Ud2 = _Row_Ticket_Producto.Item("Ud2")
                    .Stfi1 = _Row_Ticket_Producto.Item("Stfi1")
                    .Stfi2 = _Row_Ticket_Producto.Item("Stfi2")
                    .Cantidad = _Row_Ticket_Producto.Item("Cantidad")
                    .FechaRev = _Row_Ticket_Producto.Item("FechaRev")
                    .RevInventario = _Row_Ticket_Producto.Item("RevInventario")
                    .AjusInventario = _Row_Ticket_Producto.Item("AjusInventario")
                    .SobreStock = _Row_Ticket_Producto.Item("SobreStock")

                End With

            End If

        End If

    End Sub

    Function Fx_NvoNro_OT() As String

        Dim _NvoNro_OT As String

        Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

        Dim _TblPaso = _Sql.Fx_Get_Tablas("Select Max(Numero) As Numero From " & _Global_BaseBk & "Zw_Stk_Tickets")

        Dim _Ult_Nro_OT As String = NuloPorNro(_TblPaso.Rows(0).Item("Numero"), "")

        If String.IsNullOrEmpty(Trim(_Ult_Nro_OT)) Then
            _Ult_Nro_OT = "#Tk-000000"
        End If

        _NvoNro_OT = Fx_Proximo_NroDocumento(_Ult_Nro_OT, 10)

        Return _NvoNro_OT

    End Function

    Function Fx_Grabar_Nuevo_Tickets() As String

        'Return "."

        Tickets.Numero = Fx_NvoNro_OT()
        Tickets.Estado = "ABIE"

        If Tickets.Asignado Then

            If Tickets.AsignadoGrupo Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_GrupoVsAgente Where Id_Grupo = '" & Tickets.Id_Grupo & "'"
            End If

            If Tickets.AsignadoAgente Then
                Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where CodAgente = '" & Tickets.CodAgente & "'"
            End If

        Else
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where Id_Area = " & Tickets.Id_Area & " And Id_Tipo = " & Tickets.Id_Tipo
        End If

        Dim _Tbl_Agentes As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets (Numero,Estado,Asunto,Descripcion,FechaCreacion) Values " &
                       "('" & Tickets.Numero & "','" & Tickets.Estado & "','" & Tickets.Asunto & "','" & Tickets.Descripcion & "',Getdate())"

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Imports System.Data
            'Imports System.Data.SqlClient

            Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
            Comando.Transaction = myTrans
            Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            While dfd1.Read()
                Tickets.Id = dfd1("Identity")
            End While
            dfd1.Close()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set " & vbCrLf &
                           "Id_Area = " & Tickets.Id_Area &
                           ",Id_Tipo = " & Tickets.Id_Tipo &
                           ",Prioridad = '" & Tickets.Prioridad & "'" &
                           ",CodFuncionario_Crea = '" & Tickets.CodFuncionario_Crea & "'" &
                           ",Asunto = '" & Tickets.Asunto & "'" &
                           ",Descripcion = '" & Tickets.Descripcion & "'" &
                           ",Asignado = " & Convert.ToInt32(Tickets.Asignado) &
                           ",AsignadoGrupo = " & Convert.ToInt32(Tickets.AsignadoGrupo) &
                           ",Id_Grupo = " & Tickets.Id_Grupo &
                           ",Id_Padre = '" & Tickets.Id_Padre & "'" &
                           "Where Id = " & Tickets.Id
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones Set " &
                           "Id_Ticket = " & Tickets.Id &
                           ",Accion = 'MENS'" &
                           ",Descripcion = '" & Tickets.Descripcion & "'" &
                           ",Fecha = Getdate()" &
                           ",En_Construccion = 0" & vbCrLf &
                           "Where Id = " & Tickets.New_Id_TicketAc
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Set En_Construccion = 0" & vbCrLf &
                           "Where Id_TicketAc = " & Tickets.New_Id_TicketAc
            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            With Tickets.Tickets_Producto

                If Not String.IsNullOrEmpty(.Codigo) Then

                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Producto (Id_Ticket,Empresa,Sucursal,Bodega," &
                                   "Codigo,Descripcion,Rtu,UdMedida,Ud1,Ud2,Stfi1,Stfi2,Cantidad,FechaRev,RevInventario,AjusInventario," &
                                   "SobreStock) Values " &
                                   "(" & Tickets.New_Id_TicketAc & ",'" & .Empresa & "','" & .Sucursal & "','" & .Bodega &
                                   "','" & .Codigo & "','" & .Descripcion & "'," & De_Num_a_Tx_01(.Rtu, False, 5) &
                                   "," & .UdMedida & ",'" & .Ud1 & "','" & .Ud2 &
                                   "'," & De_Num_a_Tx_01(.Stfi1, False, 5) &
                                   "," & De_Num_a_Tx_01(.Stfi2, False, 5) &
                                   "," & De_Num_a_Tx_01(.Cantidad, False, 5) &
                                   ",'" & Format(.FechaRev, "yyyyMMdd") &
                                   "'," & Convert.ToInt32(.RevInventario) &
                                   "," & Convert.ToInt32(.AjusInventario) &
                                   "," & Convert.ToInt32(.SobreStock) & ")"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                    Comando.Transaction = myTrans
                    Comando.ExecuteNonQuery()

                End If

            End With

            For Each _Fila As DataRow In _Tbl_Agentes.Rows

                Dim _CodAgente As String = _Fila.Item("CodAgente")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Asignado (Id_Ticket,CodAgente,Activo) Values (" & Tickets.Id & ",'" & _CodAgente & "',1)"
                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        Catch ex As Exception

            Fx_Grabar_Nuevo_Tickets = ex.Message
            Tickets.Id = 0
            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

    End Function

    Function Fx_Grabar_Nueva_Accion(_CodFuncionario As String, _Mensaje As Boolean) As Integer

        Dim _Accion As String

        If _Mensaje Then
            _Accion = "MENS"
        Else
            _Accion = "RESP"
        End If

        Dim _Id_TicketAc As Integer

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand


        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones (Id_Ticket,Accion,Descripcion,Fecha,CodFuncionario,En_Construccion) Values " &
                           "(" & Tickets.Id & ",'" & _Accion & "','',Getdate(),'" & _CodFuncionario & "',1)"
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

    Function Fx_Cerrar_Ticket(_CodFuncionario As String,
                              _Descripcion As String,
                              _Cierra_Ticket As Boolean,
                              _Solicita_Cierre As Boolean,
                              _CreaNewTicket As Boolean,
                              _AnulaTicket As Boolean) As Mensaje_Ticket

        Dim _Mensaje_Ticket As New Tickets_Db.Mensaje_Ticket
        Dim _Tickets_Acciones As New Tickets_Db.Tickets_Acciones

        Dim _Estado As String

        With _Tickets_Acciones

            .Descripcion = _Descripcion
            .CodFuncionario = _CodFuncionario

            If _Cierra_Ticket Then
                _Estado = "CERR"
            End If
            If _Solicita_Cierre Then
                _Estado = "SOLC"
                .Accion = "SOLC"
            End If
            If _AnulaTicket Then
                _Estado = "NULO"
                .Accion = "NULO"
            End If

            .Cierra_Ticket = _Cierra_Ticket
            .Solicita_Cierre = _Solicita_Cierre
            .AnulaTicket = _AnulaTicket

        End With


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

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Stk_Tickets Set Estado = '" & _Estado & "'" & _FechaCierre & vbCrLf &
                           "Where Id = " & Tickets.Id

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            If _AnulaTicket Then

                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Stk_Tickets_Archivos Where Id_Ticket = " & Tickets.Id

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End If

            Dim _Campo_FunAg As String

            If Tickets.CodFuncionario_Crea = _CodFuncionario Then
                _Campo_FunAg = "CodFuncionario"
            Else
                _Campo_FunAg = "CodAgente"
            End If

            Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Stk_Tickets_Acciones (Id_Ticket,Accion,Descripcion,Fecha," & _Campo_FunAg & ",En_Construccion,Cierra_Ticket,Solicita_Cierre,CreaNewTicket,AnulaTicket) Values " &
                           "(" & Tickets.Id & ",'" & _Tickets_Acciones.Accion & "','" & _Tickets_Acciones.Descripcion & "',Getdate(),'" & _Tickets_Acciones.CodFuncionario & "',0" &
                           "," & Convert.ToInt32(_Cierra_Ticket) &
                           "," & Convert.ToInt32(_Solicita_Cierre) &
                           "," & Convert.ToInt32(_CreaNewTicket) &
                           "," & Convert.ToInt32(_AnulaTicket) & ")"
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

            _Tickets_Acciones.Id = _Id_TicketAc

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Ticket.EsCorrecto = True

            If _Cierra_Ticket Then _Mensaje_Ticket.Mensaje = "Ticket cerrado correctamente"
            If _Solicita_Cierre Then _Mensaje_Ticket.Mensaje = "Solicitud de cierre enviada correctamente"
            If _AnulaTicket Then _Mensaje_Ticket.Mensaje = "Ticket anulado correctamente"

            _Mensaje_Ticket.Tickets_Acciones = _Tickets_Acciones

        Catch ex As Exception

            _Id_TicketAc = 0
            myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje_Ticket.EsCorrecto = False
            _Mensaje_Ticket.Mensaje = ex.Message
            _Mensaje_Ticket.Tickets_Acciones = Nothing

        End Try

        Return _Mensaje_Ticket

    End Function

End Class

Namespace Tickets_Db

    Public Class Tickets

        Public Property Id As Integer
        Public Property Empresa As String
        Public Property Sucursal As String
        Public Property Numero As String
        Public Property Id_Area As Integer
        Public Property Id_Tipo As Integer
        Public Property Prioridad As String
        Public Property FechaCreacion As DateTime
        Public Property CodFuncionario_Crea As String
        Public Property Asunto As String
        Public Property Descripcion As String
        Public Property Asignado As Boolean
        Public Property AsignadoGrupo As Boolean
        Public Property Id_Grupo As Integer
        Public Property AsignadoAgente As Boolean
        Public Property CodAgente As String
        Public Property Estado As String
        Public Property UltAccion As String
        Public Property CodFuncionario_Cierra As String
        Public Property FechaCierre As DateTime
        Public Property Id_Padre As Integer
        Public Property New_Id_TicketAc As Integer
        Public Property Tickets_Producto As Tickets_Producto

    End Class

    Public Class Tickets_Acciones

        Public Property Id As Integer
        Public Property Id_Ticket As Integer
        Public Property Accion As String
        Public Property Descripcion As String
        Public Property Fecha As DateTime
        Public Property CodFuncionario As String
        Public Property CodAgente As String
        Public Property En_Construccion As Boolean
        Public Property Visto As Boolean
        Public Property Cierra_Ticket As Boolean
        Public Property Solicita_Cierre As Boolean
        Public Property CreaNewTicket As Boolean
        Public Property AnulaTicket As Boolean

    End Class

    Public Class Mensaje_Ticket

        Public Property EsCorrecto As Boolean
        Public Property Mensaje As String
        Public Property Tickets_Acciones As Tickets_Acciones

    End Class

    Public Class Tickets_Producto

        Public Property Id As Integer
        Public Property Id_Ticket As Integer
        Public Property Empresa As String
        Public Property Sucursal As String
        Public Property Bodega As String
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Rtu As Double
        Public Property UdMedida As Integer
        Public Property Ud1 As String
        Public Property Ud2 As String
        Public Property Stfi1 As Double
        Public Property Stfi2 As Double
        Public Property Cantidad As Double
        Public Property FechaRev As DateTime
        Public Property RevInventario As Boolean
        Public Property AjusInventario As Boolean
        Public Property SobreStock As Boolean

    End Class

End Namespace
