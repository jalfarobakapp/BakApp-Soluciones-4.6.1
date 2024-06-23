Imports System.IO

Public Class Clas_Modalidades

    Enum Enum_Modalidad
        General
        Estacion
    End Enum

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Property FormMenu As Object

    Public Function Fx_Sql_Trae_Modalidad(_Modal As Enum_Modalidad,
                                          _Modalidad As String) As DataRow

        If _Modal = Enum_Modalidad.General Then
            _Modalidad = "  "
        End If

        Consulta_sql = My.Resources.Recursos_Configuracion.SqlQuery_Seleccionar_Modalidad
        Consulta_sql = Replace(Consulta_sql, "#Tbl_Configuracion#", _Global_BaseBk & "Zw_Configuracion")
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", ModEmpresa)
        Consulta_sql = Replace(Consulta_sql, "#Modalidad#", _Modalidad)

        Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Return _Fila

    End Function

    Sub Sb_Actualiza_Formatos_X_Modalidad()

        Consulta_sql = "Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And Modalidad <> '  '"

        Consulta_sql = "Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Empresa = '" & ModEmpresa & "' And Modalidad In " &
                       "(Select MODALIDAD From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD Not In " &
                       "(Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad Where Empresa = '" & ModEmpresa & "'))"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Modalidad = _Fila.Item("Modalidad")

            _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad (Empresa,Modalidad,TipoDoc,NombreFormato)" & vbCrLf &
                         "Select '" & ModEmpresa & "','" & _Modalidad & "',TIDO,'' From TABTIDO" & vbCrLf &
                         "Where TIDO Not IN (Select TipoDoc FROM " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & Space(1) &
                         "Where Empresa = '" & ModEmpresa & "' And Modalidad = '" & _Modalidad & "')" & vbCrLf

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
        End If

    End Sub

    Sub Sb_Actualizar_Variables_Modalidad(_Modalidad As String)

        Consulta_sql = "Select top 1 Cest.*,Cfgp.RAZON  
                        From CONFIEST Cest Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA  
                        Where Cest.EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & _Modalidad & "'"

        _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql)

        _Global_Row_Configuracion_General = Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
        _Global_Row_Configuracion_Estacion = Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, _Modalidad)

        Modalidad = _Modalidad

        ModEmpresa = _Global_Row_Modalidad.Item("EMPRESA") '"01"
        ModSucursal = _Global_Row_Modalidad.Item("ESUCURSAL") 'TxtSucursal.Text
        ModBodega = _Global_Row_Modalidad.Item("EBODEGA") 'TxtBodega.Text
        ModCaja = _Global_Row_Modalidad.Item("ECAJA") 'TxtCaja.Text
        ModListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3) 'Mid(TxtLPCompra.Text, 6, 3)
        ModListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3) 'Mid(TxtLPVenta.Text, 6, 3)

        Consulta_sql = "Select * From CONFIGP Where EMPRESA = " & ModEmpresa
        _Global_Row_Configp = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _New_RutEmpresa As String = Trim(_Global_Row_Configp.Item("RUT"))

        If IsNothing(_Global_Row_Empresa) Then
            RazonEmpresa = Trim(_Global_Row_Configp.Item("RAZON"))
            DireccionEmpresa = Trim(_Global_Row_Configp.Item("DIRECCION"))
        Else
            _New_RutEmpresa = Trim(_Global_Row_Empresa.Item("Rut"))
            RazonEmpresa = Trim(_Global_Row_Empresa.Item("Razon"))
            DireccionEmpresa = Trim(_Global_Row_Empresa.Item("Direccion"))
        End If

        If RutEmpresa.Trim <> _New_RutEmpresa.Trim Then

            Dim _Dir_Local As String = Application.StartupPath & "\Data\"

            If Not Directory.Exists(_Dir_Local & _New_RutEmpresa) Then

                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Data\" & _New_RutEmpresa)
                My.Computer.FileSystem.CopyDirectory(_Dir_Local & RutEmpresa, _Dir_Local & _New_RutEmpresa, True)

            End If

        End If

        If Not IsNothing(_Global_Frm_Menu) Then

            _Global_Frm_Menu.Text = "Sistema BakApp. Empresa :" & ModEmpresa & " " & RazonEmpresa & " (" & _New_RutEmpresa & ")" &
                          ", Funcionario Activo: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                          ", Modalidad: " & _Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                          "(Conexión: " & _Global_NombreConexion.Trim & ",Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")

        End If

        If Not IsNothing(FormMenu) Then
            Try
                FormMenu.Lbl_Estatus.Text = "Fun: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                              ", Mod: " & Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                              "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")
            Catch ex As Exception
                FormMenu.Lbl_Estatus.Text = String.Empty
            End Try
        End If

    End Sub

End Class
