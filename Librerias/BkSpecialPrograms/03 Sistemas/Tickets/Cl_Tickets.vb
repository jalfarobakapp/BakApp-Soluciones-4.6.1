Imports System.Data.SqlClient

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
        Tickets.CodProducto = String.Empty

    End Sub

    Sub Sb_Llenar_Ticket(_Id_Ticket As Integer)

        Consulta_sql = "Select *,NOKOFU From " & _Global_BaseBk & "Zw_Stk_Tickets" & vbCrLf &
                       "Left Join TABFU On KOFU = CodFuncionario_Crea" & vbCrLf &
                       "Where Id = " & _Id_Ticket
        Dim _Row_Ticket As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Tickets.Id = _Id_Ticket

        If Not IsNothing(_Row_Ticket) Then

            With Tickets

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
                .FechaCierre = NuloPorNro(_Row_Ticket.Item("FechaCierre"), Now)

            End With

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

        Tickets.Numero = Fx_NvoNro_OT()
        Tickets.Estado = "ABIE"

        If Tickets.Asignado Then
            Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Stk_AgentesVsTipos Where CodAgente = '" & Tickets.CodAgente & "'"
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
                           ",CodProducto = '" & Tickets.CodProducto & "'" &
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

End Class

Namespace Tickets_Db

    Public Class Tickets

        Public Property Id As Integer
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
        Public Property FechaCierre As DateTime
        Public Property New_Id_TicketAc As Integer
        Public Property Id_Padre As Integer
        Public Property CodProducto As String

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

    End Class

End Namespace
