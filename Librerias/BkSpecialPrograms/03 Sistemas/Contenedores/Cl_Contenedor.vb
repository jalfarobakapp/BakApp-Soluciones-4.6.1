﻿Imports System.Data.SqlClient

Public Class Cl_Contenedor

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_Contenedor As New Zw_Contenedor
    Public Property Zw_Contenedor_DocTom As New Zw_Contenedor_DocTom
    Public Property Ls_Zw_Contenedor_StockProd As New List(Of Zw_Contenedor_StockProd)

    Public Sub New()
        Zw_Contenedor = New Zw_Contenedor
    End Sub

    Function Fx_Llenar_Contenedor(_IdCont As Integer) As Zw_Contenedor

        Dim _Zw_Contenedor As New Zw_Contenedor

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor Where IdCont = " & _IdCont
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With _Zw_Contenedor

            If Not IsNothing(_Row) Then

                .IdCont = _Row.Item("IdCont")
                .Empresa = _Row.Item("Empresa")
                .Contenedor = _Row.Item("Contenedor")
                .NombreContenedor = _Row.Item("NombreContenedor")
                .Tido_Rela = _Row.Item("Tido_Rela")
                .Nudo_Rela = _Row.Item("Nudo_Rela")
                .Idmaeedo_Rela = _Row.Item("Idmaeedo_Rela")
                .Estado = _Row.Item("Estado")

            End If

        End With

        Return _Zw_Contenedor

    End Function

    Function Fx_Llenar_Contenedor(_Contenedor As String) As Zw_Contenedor

        Dim _Zw_Contenedor As New Zw_Contenedor

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor Where Contenedor = '" & _Contenedor & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return Nothing
        End If

        With _Zw_Contenedor

            .IdCont = _Row.Item("IdCont")
            .Empresa = _Row.Item("Empresa")
            .Contenedor = _Row.Item("Contenedor")
            .NombreContenedor = _Row.Item("NombreContenedor")
            .Tido_Rela = _Row.Item("Tido_Rela")
            .Nudo_Rela = _Row.Item("Nudo_Rela")
            .Idmaeedo_Rela = _Row.Item("Idmaeedo_Rela")
            .Estado = _Row.Item("Estado")

        End With

        Return _Zw_Contenedor

    End Function

    Function Fx_Llenar_Contenedor(_Idmaeedo_Rela As Integer, _Tido_Rela As String, _Nudo_Rela As String) As Zw_Contenedor

        Dim _Zw_Contenedor As New Zw_Contenedor

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor" & vbCrLf &
                       "Where Idmaeedo_Rela = " & _Idmaeedo_Rela & " And Tido_Rela = '" & _Tido_Rela & "' And Nudo_Rela  = '" & _Nudo_Rela & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With _Zw_Contenedor

            If Not IsNothing(_Row) Then

                .IdCont = _Row.Item("IdCont")
                .Empresa = _Row.Item("Empresa")
                .Contenedor = _Row.Item("Contenedor")
                .NombreContenedor = _Row.Item("NombreContenedor")
                .Tido_Rela = _Row.Item("Tido_Rela")
                .Nudo_Rela = _Row.Item("Nudo_Rela")
                .Idmaeedo_Rela = _Row.Item("Idmaeedo_Rela")
                .Estado = _Row.Item("Estado")

            End If

        End With

        Return _Zw_Contenedor

    End Function

    Function Fx_Llenar_ContenedorTomado(_IdCont As Integer, _Contenedor As String)

        Dim _Zw_Contenedor_DocTom As New Zw_Contenedor_DocTom

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Contenedor_DocTom Where IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "'"
        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        If IsNothing(_Row) Then
            Return _Zw_Contenedor_DocTom
        End If

        With _Zw_Contenedor_DocTom
            .Id = _Row.Item("Id")
            .IdCont = _Row.Item("IdCont")
            .Contenedor = _Row.Item("Contenedor")
            .CodFuncionario = _Row.Item("CodFuncionario")
            .Fecha_Hora = _Row.Item("Fecha_Hora")
            .NombreEquipo = _Row.Item("NombreEquipo")
            .Id_DocEnc = _Row.Item("Id_DocEnc")
        End With

        Return _Zw_Contenedor_DocTom

    End Function

    Function Fx_Tomar_Contenedor(_Zw_Contenedor As Zw_Contenedor) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Tomar contenedor"

        Try

            With _Zw_Contenedor

                Dim _Zw_Contenedor_DocTom As Zw_Contenedor_DocTom = Fx_Llenar_ContenedorTomado(.IdCont, .Contenedor)

                If _Zw_Contenedor_DocTom.Id <> 0 Then ' Not IsNothing(_Zw_Contenedor_DocTom) Then

                    Dim _Funcionario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Zw_Contenedor_DocTom.CodFuncionario & "'")

                    Throw New System.Exception("El Contenedor ya fue tomado por otro funcionario" & vbCrLf &
                                               "Funcionario: " & _Zw_Contenedor_DocTom.CodFuncionario & " - " & _Funcionario & ", Equipo: " & _Zw_Contenedor_DocTom.NombreEquipo)
                End If

                Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Contenedor_DocTom (IdCont,Contenedor,CodFuncionario,Fecha_Hora,NombreEquipo) Values " &
                               "(" & .IdCont & ",'" & .Contenedor & "','" & FUNCIONARIO & "',Getdate(),'" & _NombreEquipo & "')"

                If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, _Mensaje.Id) Then
                    Throw New System.Exception("Error al tomar el contenedor" & vbCrLf & _Sql.Pro_Error)
                End If

                _Zw_Contenedor_DocTom = Fx_Llenar_ContenedorTomado(.IdCont, .Contenedor)

                _Mensaje.Mensaje = "Contenedor Tomado Correctamente"
                _Mensaje.EsCorrecto = True
                _Mensaje.Tag = _Zw_Contenedor_DocTom
                _Mensaje.Icono = MessageBoxIcon.Information

            End With

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_Contenedor(_Zw_Contenedor As Zw_Contenedor) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Crear contenedor"

        Try

            With _Zw_Contenedor

                Dim _Zw_Contenedor2 As Zw_Contenedor = Fx_Llenar_Contenedor(.Contenedor)

                If Not IsNothing(_Zw_Contenedor2) Then
                    Throw New System.Exception("El Contenedor ya existe")
                End If

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Contenedor (Empresa,Contenedor,NombreContenedor,Tido_Rela,Idmaeedo_Rela,Estado) Values " &
                               "('" & .Empresa & "','" & .Contenedor & "','" & .NombreContenedor & "','" & .Tido_Rela & "'," & .Idmaeedo_Rela & ",'" & .Estado & "')"
                If Not _Sql.Ej_Insertar_Trae_Identity(Consulta_sql, .IdCont) Then
                    Throw New System.Exception("Error al crear el contenedor" & vbCrLf & _Sql.Pro_Error)
                End If

                _Zw_Contenedor = Fx_Llenar_Contenedor(.IdCont)

                _Mensaje.Mensaje = "Contenedor Creado Correctamente"
                _Mensaje.EsCorrecto = True
                _Mensaje.Icono = MessageBoxIcon.Information
                _Mensaje.Id = .IdCont
                _Mensaje.Tag = _Zw_Contenedor

            End With

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Editar_Contenedor(_Zw_Contenedor As Zw_Contenedor) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Editar contenedor"

        Try

            With Zw_Contenedor

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Contenedor Set " &
                               "NombreContenedor = '" & .NombreContenedor & "'" &
                               ",Idmaeedo_Rela = " & .Idmaeedo_Rela &
                               ",Tido_Rela = '" & .Tido_Rela & "'" &
                               ",Nudo_Rela = '" & .Nudo_Rela & "'" &
                               ",Estado = '" & .Estado & "'" & vbCrLf &
                               "Where IdCont = " & .IdCont

                If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                    Throw New System.Exception("Error al editar el contenedor" & vbCrLf & _Sql.Pro_Error)
                End If

                _Mensaje.Mensaje = "Contenedor Editado Correctamente"
                _Mensaje.EsCorrecto = True
                _Mensaje.Icono = MessageBoxIcon.Information
                _Mensaje.Tag = Fx_Llenar_Contenedor(.IdCont)

            End With

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Eliminar_Contenedor(_Zw_Contenedor As Zw_Contenedor) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Eliminar contenedor"

        Try

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Contenedor Where IdCont = " & _Zw_Contenedor.IdCont
            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                Throw New System.Exception("Error al eliminar el contenedor" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Contenedor Eliminado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Relacionar_Contenedor_Documento(_Idmaeedo As Integer, _IdCont As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Relacionar contenedor con documento"

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            Consulta_sql = "Select IDMAEEDO,TIDO,NUDO From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            If IsNothing(_Row) Then
                Throw New System.Exception("Documento no encontrado")
            End If

            Dim _Contenedor As New Zw_Contenedor

            _Contenedor = Fx_Llenar_Contenedor(_IdCont)

            If IsNothing(_Contenedor) Then
                Throw New System.Exception("Contenedor no encontrado")
            End If

            If Not String.IsNullOrWhiteSpace(_Contenedor.Tido_Rela) Then
                Throw New System.Exception("El Contenedor ya tiene un documento relacionado" & vbCrLf &
                                           "Documento: " & _Contenedor.Tido_Rela & "-" & _Contenedor.Nudo_Rela)
            End If

            Consulta_sql = "Select EMPRESA,KOPRCT,Sum(CAPRCO1) As CAPRCO1,Sum(CAPRCO2) As CAPRCO2" & vbCrLf &
                           "From MAEDDO Where IDMAEEDO = " & _Idmaeedo & vbCrLf &
                           "Group By EMPRESA,KOPRCT"
            Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Ls_Zw_Contenedor_StockProd As New List(Of Zw_Contenedor_StockProd)

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _ZwCntd As New Zw_Contenedor_StockProd

                With _ZwCntd
                    .IdCont = 0
                    .Empresa = _Fila("EMPRESA")
                    .IdCont = _IdCont
                    .Contenedor = _Contenedor.Contenedor
                    .Codigo = _Fila("KOPRCT")
                    .StcfiUd1 = _Fila("CAPRCO1")
                    .StcfiUd2 = _Fila("CAPRCO2")
                    .StcCompUd1 = 0
                    .StcCompUd2 = 0
                End With

                _Ls_Zw_Contenedor_StockProd.Add(_ZwCntd)

            Next

            myTrans = Cn2.BeginTransaction()

            _Contenedor.Tido_Rela = _Row.Item("TIDO")
            _Contenedor.Nudo_Rela = _Row.Item("NUDO")
            _Contenedor.Idmaeedo_Rela = _Row.Item("IDMAEEDO")

            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Contenedor Set " &
                           "Tido_Rela = '" & _Contenedor.Tido_Rela & "'" &
                           ",Nudo_Rela = '" & _Contenedor.Nudo_Rela & "'" &
                           ",Idmaeedo_Rela = " & _Contenedor.Idmaeedo_Rela & vbCrLf &
                           "Where IdCont = " & _IdCont

            Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
            Comando.Transaction = myTrans
            Comando.ExecuteNonQuery()

            'Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
            'Comando.Transaction = myTrans
            'Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
            'While dfd1.Read()
            '    .Id = dfd1("Identity")
            'End While
            'dfd1.Close()

            For Each _Producto As Zw_Contenedor_StockProd In _Ls_Zw_Contenedor_StockProd

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Contenedor_StockProd (Empresa,IdCont,Contenedor,Codigo," &
                               "StcfiUd1,StcfiUd2,StcCompUd1,StcCompUd2) Values " &
                               "('" & _Producto.Empresa & "'," & _Producto.IdCont & ",'" & _Producto.Contenedor & "','" & _Producto.Codigo & "'" &
                               "," & De_Num_a_Tx_01(_Producto.StcfiUd1, False, 5) &
                               "," & De_Num_a_Tx_01(_Producto.StcfiUd2, False, 5) &
                               "," & _Producto.StcCompUd1 & "," & _Producto.StcCompUd2 & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            Next

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.Mensaje = "Documento Relacionado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error

            If Not IsNothing(myTrans) Then myTrans.Rollback()

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Soltar_Contenedor_Tomado(_Zw_Contenedor As Zw_Contenedor) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Soltar contenedor tomado"

        Try

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Contenedor_DocTom Where IdCont = " & _Zw_Contenedor.IdCont

            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception("Error al soltar el contenedor tomado" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Contenedor Soltado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Soltar_Contenedor_Tomado() As LsValiciones.Mensajes

        Dim _NombreEquipo As String = _Global_Row_EstacionBk.Item("NombreEquipo")

        Dim _Mensaje As New LsValiciones.Mensajes

        _Mensaje.Detalle = "Soltar contenedor tomado"

        Try

            Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Contenedor_DocTom Where NombreEquipo = '" & _NombreEquipo & "'"

            If Not _Sql.Ej_consulta_IDU(Consulta_sql, False) Then
                Throw New System.Exception("Error al soltar el contenedor tomado" & vbCrLf & _Sql.Pro_Error)
            End If

            _Mensaje.Mensaje = "Contenedor Soltado Correctamente"
            _Mensaje.EsCorrecto = True
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Quitar_Contenedor_De_Documento(_Empresa As String, _IdCont As Integer, _Contenedor As String) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        _Mensaje.Detalle = "Quitar contenedor"

        Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "Zw_Contenedor_StockProd",
                                                       "Empresa = '" & _Empresa & "' And IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "' And StcCompUd1+StcCompUd2 <> 0")

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Docu_Det Where IdCont = " & _IdCont & " And Contenedor = '" & _Contenedor & "'"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Try

            If CBool(_Reg) Or CBool(_Tbl.Rows.Count) Then
                Throw New System.Exception("No se puede quitar el contenedor de la OCC, ya que existen COV asociadas")
            End If


            With Zw_Contenedor

                Dim _Zw_Contenedor_DocTom As Zw_Contenedor_DocTom = Fx_Llenar_ContenedorTomado(.IdCont, .Contenedor)

                If _Zw_Contenedor_DocTom.Id <> 0 Then

                    Dim _Funcionario As String = _Sql.Fx_Trae_Dato("TABFU", "NOKOFU", "KOFU = '" & _Zw_Contenedor_DocTom.CodFuncionario & "'")

                    Throw New System.Exception("No se puede quitar el contenedor de la OCC" & vbCrLf &
                                               "Esta tomado por : " & _Zw_Contenedor_DocTom.CodFuncionario & " - " & _Funcionario.ToString.Trim & " en el PC " & _Zw_Contenedor_DocTom.NombreEquipo)
                End If


                Consulta_sql = "Update " & _Global_BaseBk & "Zw_Contenedor Set " &
                               "NombreContenedor = '" & .NombreContenedor & "'" &
                               ",Idmaeedo_Rela = 0" &
                               ",Tido_Rela = ''" &
                               ",Nudo_Rela = ''" &
                               "Where IdCont = " & .IdCont & vbCrLf &
                               "Delete " & _Global_BaseBk & "Zw_Contenedor_StockProd Where Empresa = '" & _Empresa & "' And IdCont = " & .IdCont & " And Contenedor ='" & _Contenedor & "'"

                If Not _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql, False) Then
                    Throw New System.Exception("Error al editar el contenedor" & vbCrLf & _Sql.Pro_Error)
                End If

                _Mensaje.Mensaje = "Contenedor Quitado Correctamente"
                _Mensaje.EsCorrecto = True
                _Mensaje.Icono = MessageBoxIcon.Information
                _Mensaje.Tag = Fx_Llenar_Contenedor(.IdCont)

            End With

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.EsCorrecto = False
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

End Class
