Imports DevComponents.DotNetBar

Public Class Cl_NVVAutoExterna

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String

    Public Property Modalidad_NVV As String
    Public Property Nombre_Equipo As String
    Public Property Log_Registro As String
    Public Property Procesando As Boolean
    Public Property Ejecutar As Boolean

    Public Sub New()

    End Sub

    Sub Sb_Procesar_NVV(_Formulario As Form)

        Log_Registro = String.Empty

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Where GenerarNVV = 1"
        Dim _Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        If CBool(_Tbl.Rows.Count) Then

            Dim _Filtro_Id_Enc As String = Generar_Filtro_IN(_Tbl, "", "Id_Enc", True, False)

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set GenerarNVV = 0 Where Id_Enc In " & _Filtro_Id_Enc
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            For Each _Fila As DataRow In _Tbl.Rows

                Dim _Id_Enc As Integer = _Fila.Item("Id_Enc")

                Consulta_Sql = "Select Codigo,'Descripcion' From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet" & vbCrLf &
                               "Where Id_Enc = " & _Filtro_Id_Enc

                Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

                Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                Fm.Pro_Ejecutar_Automaticamente = True
                Fm.TopMost = True
                Fm.ShowDialog(_Formulario)
                Fm.Dispose()

                Fx_Crear_NVV(_Formulario, _Id_Enc)

            Next

        End If

    End Sub

    Function Fx_Crear_NVV(_Formulario As Form, _Id_Enc As Integer)

        Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Where Id_Enc = " & _Id_Enc
        Dim _Row_Encabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Endo As String = _Row_Encabezado.Item("Endo_Ori")
        Dim _Suendo As String = _Row_Encabezado.Item("Suendo_Ori")

        Consulta_Sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

        Dim _Tido As String = "NVV"
        Dim _Fecha_Emision As DateTime = FechaDelServidor()

        Consulta_Sql = "Select *,1 As Precio From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Where Id_Enc = " & _Id_Enc
        Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

        Dim _Modalidad_Old As String = Modalidad

        Modalidad = Modalidad_NVV

        Dim Fm As New Frm_Formulario_Documento(_Tido,
                                               csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                               False, False, False, False, False)
        Fm.Sb_Limpiar(Modalidad_NVV)
        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Formulario, _Tbl_Productos, _Fecha_Emision,
                                                "Codigo", "Cantidad", "Precio", "Observacion", False, True,, True)
        'Fm.Pro_Bodega_Destino = _Bod_Destino
        Dim _New_Idmaeedo = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        If CBool(_New_Idmaeedo) Then

            Consulta_Sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set " &
                           "NVVGenerada = 1" &
                           ",Idmaeedo_NVV = " & _Row.Item("IDMAEEDO") &
                           ",Nudo_NVV = '" & _Row.Item("NUDO") & "'" &
                           ",Feemdo_NVV = '" & Format(_Row.Item("FEEMDO"), "yyyyMMdd") & "'" & vbCrLf &
                            "Where Id_Enc = " & _Id_Enc
            _Sql.Ej_consulta_IDU(Consulta_Sql)

            Consulta_Sql = "Update MAEEDOOB Set OBDO = 'Documento generado desde diablito automático desde OCC Nro: " & _Row_Encabezado.Item("NudoOCC_Ori") & "'" & vbCrLf &
                           "Where IDMAEEDO = " & _New_Idmaeedo
            _Sql.Ej_consulta_IDU(Consulta_Sql)

        End If

        Modalidad = _Modalidad_Old

    End Function

End Class
