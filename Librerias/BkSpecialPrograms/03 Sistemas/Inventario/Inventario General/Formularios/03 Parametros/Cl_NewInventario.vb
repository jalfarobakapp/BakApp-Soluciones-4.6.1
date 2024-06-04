Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class Cl_NewInventario

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property Zw_TmpInv_History As New Zw_TmpInv_History

    Public Sub New()

    End Sub

    Function Fx_Llenar_Zw_Inv_Inventario(_Id As Integer) As LsValiciones.Mensajes

        Dim _Mensaje_Stem As New LsValiciones.Mensajes

        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_TmpInv_History Where IdInventario = " & _Id
        Dim _Row_Enc As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        With Zw_TmpInv_History

            If IsNothing(_Row_Enc) Then

                _Mensaje_Stem.EsCorrecto = False
                _Mensaje_Stem.Mensaje = "No se encontro el registro en la tabla Zw_TmpInv_History con el Id " & _Id

                Return _Mensaje_Stem

            End If

            .IdInventario = _Row_Enc.Item("IdInventario")
            .Empresa = _Row_Enc.Item("Empresa")
            .Nombre_Empresa = _Row_Enc.Item("Nombre_Empresa")
            .Sucursal = _Row_Enc.Item("Sucursal")
            .Nombre_Sucursal = _Row_Enc.Item("Nombre_Sucursal")
            .Bodega = _Row_Enc.Item("Bodega")
            .Nombre_Bodega = _Row_Enc.Item("Nombre_Bodega")
            .FuncionarioCargo = _Row_Enc.Item("FuncionarioCargo")
            .NombreFuncionario = _Row_Enc.Item("NombreFuncionario")
            .NombreInventario = _Row_Enc.Item("NombreInventario")
            .Estado = _Row_Enc.Item("Estado")
            .Fecha_Inventario = _Row_Enc.Item("Fecha_Inventario")
            .FechaCierre = NuloPorNro(_Row_Enc.Item("FechaCierre"), Nothing)

        End With

        _Mensaje_Stem.EsCorrecto = True
        _Mensaje_Stem.Mensaje = "Registro encontrado."

        Return _Mensaje_Stem

    End Function

    Function Fx_Crear_Inventario() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_TmpInv_History

                Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TmpInv_History " &
                               "(Ano,Mes,Dia,Fecha_Inventario,Empresa,Sucursal,Bodega,Nombre_Empresa,Nombre_Sucursal," &
                               "Nombre_Bodega,NombreInventario,FuncionarioCargo,NombreFuncionario,Estado) Values " &
                               "('" & .Ano & "','" & .Mes & "','" & .Dia & "','" & Format(.Fecha_Inventario, "yyyyMMdd") & "'" &
                               ",'" & .Empresa & "','" & .Sucursal & "','" & .Bodega & "'" &
                               ",'" & .Nombre_Empresa & "','" & .Nombre_Sucursal & "','" & .Nombre_Bodega & "'" &
                               ",'" & .NombreInventario & "','" & .FuncionarioCargo & "','" & .NombreFuncionario & "'" &
                               "," & Convert.ToInt32(.Estado) & ")"

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

                Comando = New System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY AS 'Identity'", Cn2)
                Comando.Transaction = myTrans
                Dim dfd1 As System.Data.SqlClient.SqlDataReader = Comando.ExecuteReader()
                While dfd1.Read()
                    .IdInventario = dfd1("Identity")
                End While
                dfd1.Close()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Id = Zw_TmpInv_History.IdInventario
            _Mensaje.Detalle = "Documento grabado correctamente"
            _Mensaje.Mensaje = "Se crea Inventario " & Zw_TmpInv_History.NombreInventario
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
            Zw_TmpInv_History.IdInventario = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_Editar_Inventario() As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Consulta_sql = String.Empty

        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim Cn2 As New SqlConnection
        Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)

        SQL_ServerClass.Sb_Abrir_Conexion(Cn2)

        Try

            myTrans = Cn2.BeginTransaction()

            With Zw_TmpInv_History

                Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_History Set " & vbCrLf &
                               "NombreInventario = '" & .NombreInventario & "'" & vbCrLf &
                               ",FuncionarioCargo = '" & .FuncionarioCargo & "'" & vbCrLf &
                               ",NombreFuncionario = '" & .NombreFuncionario & "'" & vbCrLf &
                               "Where IdInventario = " & .IdInventario

                Comando = New SqlClient.SqlCommand(Consulta_sql, Cn2)
                Comando.Transaction = myTrans
                Comando.ExecuteNonQuery()

            End With

            myTrans.Commit()
            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Editar"
            _Mensaje.Mensaje = "Datos actualizados correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception

            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
            Zw_TmpInv_History.IdInventario = 0

            If Not IsNothing(myTrans) Then
                myTrans.Rollback()
            End If

            SQL_ServerClass.Sb_Cerrar_Conexion(Cn2)

        End Try

        Return _Mensaje

    End Function

    Function Fx_CrearFoto(_IdInventario As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_TmpInvFotoInventario", "IdInventario = " & _IdInventario)

            If CBool(_Reg) Then
                _Mensaje.Detalle = "Validación"
                Throw New System.Exception("No es posible tomar una foto del stock de la bodega, ya que existen datos de" & vbCrLf &
                                           "una foto anterior. Para poder obtener una nueva foto, primero debes eliminar" & vbCrLf &
                                           "la anterior.")
            End If

            With Zw_TmpInv_History

                Consulta_sql = My.Resources._Procedimientos_Inv.Inv_Invetario_Creae_Foto_Stock
                Consulta_sql = Replace(Consulta_sql, "#Ano#", .Ano)
                Consulta_sql = Replace(Consulta_sql, "#Mes#", .Mes)
                Consulta_sql = Replace(Consulta_sql, "#Dia#", .Dia)
                Consulta_sql = Replace(Consulta_sql, "#IdBodega#", 0)
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", .Empresa)
                Consulta_sql = Replace(Consulta_sql, "#Sucursal#", .Sucursal)
                Consulta_sql = Replace(Consulta_sql, "#Bodega#", .Bodega)
                Consulta_sql = Replace(Consulta_sql, "#IdInventario#", _IdInventario)
                Consulta_sql = Replace(Consulta_sql, "ZW_TmpInvFotoInventario", _Global_BaseBk & "ZW_TmpInvFotoInventario")

            End With

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Mensaje.Detalle = "Error al tomar foto stock"
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Tomar foto stock"
            _Mensaje.Mensaje = "Foto del stock de la bodega creado correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Function Fx_EliminarFoto(_Formulario As Form, _IdInventario As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            _Mensaje.Detalle = "Eliminar Foto Stock"

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros(_Global_BaseBk & "ZW_TmpInvFotoInventario", "IdInventario = " & _IdInventario)

            If Not CBool(_Reg) Then
                Throw New System.Exception("No se encontró ninguna Foto Stock en la base de datos para este inventario que pueda ser eliminada.")
            End If

            Dim _Autorizado As Boolean

            Dim Fm_Pass As New Frm_Clave_Administrador
            Fm_Pass.ShowDialog(_Formulario)
            _Autorizado = Fm_Pass.Pro_Autorizado
            Fm_Pass.Dispose()

            If Not _Autorizado Then
                Throw New System.Exception("Clave de administrador invalida.")
            End If

            If MessageBoxEx.Show(_Formulario, "¿Esta seguro de querer eliminar la foto tomada del stock de la bodega?" & vbCrLf &
                    "Nota:El proceso no podrá ser interrumpido y no es posible revertirlo",
                    "Cerrar Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                _Mensaje.Cancelado = True
                Throw New System.Exception("Acción cancelada por el usuario, no se elimina la Foto Stock")
            End If

            Consulta_sql = "Delete " & _Global_BaseBk & "ZW_TmpInvFotoInventario Where IdInventario = " & _IdInventario

            If Not _Sql.Ej_consulta_IDU(Consulta_sql) Then
                _Mensaje.Detalle = "Error al tomar foto stock"
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Datos eliminados correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

End Class
