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
                                          _Modalidad As String,
                                          Optional _Mostrar_Error As Boolean = True,
                                          Optional _Empresa As String = "") As DataRow

        If String.IsNullOrEmpty(_Empresa) Then
            _Empresa = Mod_Empresa
        End If

        If _Modal = Enum_Modalidad.General Then
            _Modalidad = "  "
        End If

        'Consulta_sql = My.Resources.Recursos_Configuracion.SqlQuery_Seleccionar_Modalidad
        'Consulta_sql = Replace(Consulta_sql, "#Tbl_Configuracion#", _Global_BaseBk & "Zw_Configuracion")
        'Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        'Consulta_sql = Replace(Consulta_sql, "#Modalidad#", _Modalidad)

        Consulta_sql = "Select CEst.*," & vbCrLf &
           "Csu.NOKOSU, Cbo.NOKOBO, Cja.NOKOCJ," & vbCrLf &
           "Z1.*" & vbCrLf &
           "From dbo.TABBO AS Cbo" & vbCrLf &
           "Right Outer Join CONFIEST AS CEst WITH (NOLOCK) ON Cbo.EMPRESA = CEst.EMPRESA AND Cbo.KOSU = CEst.ESUCURSAL AND Cbo.KOBO = CEst.EBODEGA" & vbCrLf &
           "Left Outer Join TABCJ AS Cja ON CEst.EMPRESA = Cja.EMPRESA AND CEst.ESUCURSAL = Cja.KOSU AND CEst.ECAJA = Cja.KOCJ" & vbCrLf &
           "Left Outer Join TABSU AS Csu ON CEst.ESUCURSAL = Csu.KOSU AND CEst.EMPRESA = Csu.EMPRESA" & vbCrLf &
           "Inner Join " & _Global_BaseBk & "Zw_Configuracion AS Z1 ON CEst.EMPRESA = Z1.Empresa And CEst.MODALIDAD = Z1.Modalidad" & vbCrLf &
           "Where Z1.Modalidad = '" & _Modalidad & "' And Z1.Empresa = '" & _Empresa & "'"

        Dim _Fila As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql, _Mostrar_Error)

        Return _Fila

    End Function

    Sub Sb_Actualiza_Formatos_X_Modalidad(Optional _Mostrar_Error As Boolean = True)

        Consulta_sql = "Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Empresa = '" & Mod_Empresa & "' And Modalidad <> '  '"

        Consulta_sql = "Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion" & vbCrLf &
                       "Where Empresa = '" & Mod_Empresa & "' And Modalidad In " &
                       "(Select MODALIDAD From CONFIEST WITH (NOLOCK) Where EMPRESA = '" & Mod_Empresa & "' And MODALIDAD Not In " &
                       "(Select Modalidad From " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad Where Empresa = '" & Mod_Empresa & "'))"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql, _Mostrar_Error)

        Dim _SqlQuery = String.Empty

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Modalidad = _Fila.Item("Modalidad")

            _SqlQuery += "Insert Into " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad (Empresa,Modalidad,TipoDoc,NombreFormato)" & vbCrLf &
                         "Select '" & Mod_Empresa & "','" & _Modalidad & "',TIDO,'' From TABTIDO" & vbCrLf &
                         "Where TIDO Not IN (Select TipoDoc FROM " & _Global_BaseBk & "Zw_Configuracion_Formatos_X_Modalidad" & Space(1) &
                         "Where Empresa = '" & Mod_Empresa & "' And Modalidad = '" & _Modalidad & "')" & vbCrLf

        Next

        If Not String.IsNullOrEmpty(_SqlQuery) Then
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery, _Mostrar_Error)
        End If

    End Sub

    Sub Sb_Actualizar_Variables_Modalidad(_Modalidad As String,
                                          Optional _Mostrar_Error As Boolean = True,
                                          Optional _Empresa As String = "")

        Try

            If String.IsNullOrEmpty(_Empresa) Then
                _Empresa = Mod_Empresa
            End If

            Consulta_sql = "Select top 1 Cest.*,Cfgp.RAZON  
                        From CONFIEST Cest WITH (NOLOCK) Inner Join CONFIGP Cfgp On Cest.EMPRESA = Cfgp.EMPRESA  
                        Where Cest.EMPRESA = '" & _Empresa & "' And MODALIDAD = '" & _Modalidad & "'"

            _Global_Row_Modalidad = _Sql.Fx_Get_DataRow(Consulta_sql, _Mostrar_Error)

            _Global_Row_Configuracion_General = Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.General, "")
            _Global_Row_Configuracion_Estacion = Fx_Sql_Trae_Modalidad(Clas_Modalidades.Enum_Modalidad.Estacion, _Modalidad)

            Mod_Modalidad = _Modalidad

            Mod_Empresa = _Global_Row_Modalidad.Item("EMPRESA") '"01"
            Mod_Sucursal = _Global_Row_Modalidad.Item("ESUCURSAL") 'TxtSucursal.Text
            Mod_Bodega = _Global_Row_Modalidad.Item("EBODEGA") 'TxtBodega.Text
            Mod_Caja = _Global_Row_Modalidad.Item("ECAJA") 'TxtCaja.Text
            Mod_ListaPrecioVenta = Mid(_Global_Row_Modalidad.Item("ELISTAVEN"), 6, 3) 'Mid(TxtLPCompra.Text, 6, 3)
            Mod_ListaPrecioCosto = Mid(_Global_Row_Modalidad.Item("ELISTACOM"), 6, 3) 'Mid(TxtLPVenta.Text, 6, 3)

            Consulta_sql = "Select * From CONFIGP Where EMPRESA = " & _Empresa
            _Global_Row_Configp = _Sql.Fx_Get_DataRow(Consulta_sql, _Mostrar_Error)

            Dim _New_RutEmpresa As String = _Global_Row_Configp.Item("RUT").ToString.Trim

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

                _Global_Frm_Menu.Text = "Sistema BakApp. Empresa :" & Mod_Empresa & " " & RazonEmpresa & " (" & _New_RutEmpresa & ")" &
                              ", Funcionario Activo: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                              ", Modalidad: " & _Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                              "(Conexión: " & _Global_NombreConexion.Trim & ",Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")

            End If

            If Not IsNothing(FormMenu) Then
                Try
                    FormMenu.Lbl_Estatus.Text = "Fun: " & FUNCIONARIO & "-" & Nombre_funcionario_activo.Trim &
                                  ", Mod: " & Mod_Modalidad & ", BakApp Versión: " & _Global_Version_BakApp & "..." & Space(4) &
                                  "(Base BakApp: " & _Global_BaseBk & "). Estación: " & _Global_Row_EstacionBk.Item("NombreEquipo")
                Catch ex As Exception
                    FormMenu.Lbl_Estatus.Text = String.Empty
                End Try
            End If

        Catch ex As Exception
            FormMenu.Lbl_Estatus.Text = String.Empty
        End Try

    End Sub

End Class
