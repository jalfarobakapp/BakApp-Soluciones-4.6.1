Imports DevComponents.DotNetBar
Imports System.Windows.Forms
Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Instalar_Sistema
    Public _Tablas_Creadas As Boolean

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Function Fx_Revisar_Tabla(ByVal _Formulario As Form, _
                              ByVal _Tabla As String)

        'Dim _Reg As Boolean = CBool(Cuenta_registros("INFORMATION_SCHEMA.TABLES", "TABLE_NAME = '" & _Global_BaseBk & _Tabla & "'"))
        Dim _Base = Replace(_Global_BaseBk, ".dbo.", "")

        Consulta_sql = "USE [" & _Base & "]" & vbCrLf & _
                       "Select TABLE_NAME From INFORMATION_SCHEMA.TABLES Where TABLE_NAME = '" & _Tabla & "'"

        Dim _TblTablasSis As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblTablasSis.Rows.Count) Then

            Return True
            ' Creo una tabla en la base de datos con la nueva estructura
            Dim _SqlPaso As String
            _SqlPaso = My.Resources.Rs_Actualizar_Sistema.Zw_EstacionesBkp
            _SqlPaso = Replace(_SqlPaso, "#Tabla#", "TblPaso_Rev")
            _Sql.Ej_consulta_IDU(Consulta_sql)


            'Traigo ambas tablas para comprar los campos de cada una con un bucle
            Consulta_sql = My.Resources.Rs_Actualizar_Sistema.SqlQuery_Trae_Tabla

            Consulta_sql = Replace(Consulta_sql, "#Tabla_Original#", _Tabla)
            Consulta_sql = Replace(Consulta_sql, "#Tabla_Nueva#", "TblPaso_Rev")

            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim _TblOriginal As DataTable = _Ds.Tables(0)
            Dim _TblNueva As DataTable = _Ds.Tables(1)


            For Each _Fila_Nueva As DataRow In _TblNueva.Rows

                For Each _Fila_Original As DataRow In _TblOriginal.Rows

                Next

            Next

        Else

            Select Case _Tabla
                Case "Zw_EstacionesBkp"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_EstacionesBkp
                Case "Zw_Licencia_Mod"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_Licencia_Mod
                Case "ZW_SOC_Detalle"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_SOC_Detalle
                Case "ZW_SOC_Encabezado"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_SOC_Encabezado
                Case "ZW_SOC_Ent_Cadena"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_SOC_Ent_Cadena
                Case "ZW_SOC_Log"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_SOC_Log
                Case "ZW_SOC_Obs"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_SOC_Obs
                Case "Zw_TblFiltro_InfxUs"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_TblFiltro_InfxUs
                Case "ZW_PermisosADM"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.ZW_PermisosADM
                Case "Zw_Turnos"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_Turnos
                Case "Zw_TablaDeCaracterizaciones"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_TablaDeCaracterizaciones
                Case "Zw_MrVsPro"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_MrVsPro
                Case "Zw_Prod_Asociacion"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_Prod_Asociacion
                Case "Zw_TblArbol_Asociaciones"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_TblArbol_Asociaciones
                Case "Zw_ListaPreGlobal"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_ListaPreGlobal
                Case "Zw_ListaPreCosto"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_ListaPreCosto
                Case "Zw_ListaPreProducto"
                    Consulta_sql = My.Resources.Rs_Actualizar_Sistema.Zw_ListaPreProducto
                Case Else
                    MessageBoxEx.Show(_Formulario, "No se creo la tabla " & _Tabla, "Crear Tabla", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
            End Select


            Consulta_sql = Replace(Consulta_sql, "#Base#", _Base)
            Consulta_sql = Replace(Consulta_sql, "#Tabla#", _Tabla)

            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                MessageBoxEx.Show(_Formulario, "[" & _Tabla & "]", "Crear tabla de sistema",
                                  Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)

                If _Tabla = "ZW_PermisosADM" Then
                    MessageBoxEx.Show(_Formulario, "Clave de administrador: admin", "Administrador",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Return True
            End If
        End If


    End Function

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

        Dim _Tabla As String

        _Tabla = "Zw_EstacionesBkp"
        Sb_AddToLog("Crear tabla :", "[" & _Tabla & "]", TxtLog)
        _Tablas_Creadas = Fx_Revisar_Tabla(Me, _Tabla)

        Return
        _Tabla = "Zw_EstacionesBkp"
        Sb_AddToLog("Crear tabla :", "[" & _Tabla & "]", TxtLog)
        Fx_Revisar_Tabla(Me, _Tabla)




    End Sub
End Class