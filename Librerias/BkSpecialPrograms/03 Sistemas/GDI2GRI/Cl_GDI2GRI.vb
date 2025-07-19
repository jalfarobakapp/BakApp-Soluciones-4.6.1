Public Class Cl_GDI2GRI

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Public Sub New()

    End Sub

    Function Fx_Crear_GDI2GRI(_Formulario As Form,
                              _Modalidad As String,
                              _Sucursal As String,
                              _Bodega_GDI As String,
                              _Fecha_Emision As Date,
                              _Codigo As String,
                              _Cantidad As Double) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & Mod_Empresa & "'"
            Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

            Dim _Koen = _Row_Configp.Item("RUT")

            Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)


            Consulta_sql = "Select KOPR As Codigo," & _Cantidad & " As Cantidad,PM As Precio,'' As Observacion," &
                           "'" & _Sucursal & "' As Sucursal,'" & _Bodega_GDI & "' As Bodega" & vbCrLf &
                           "From MAEPREM" & vbCrLf &
                           "Where KOPR = '" & _Codigo & "'"
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim Fm As New Frm_Formulario_Documento("GDI",
                                           csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna,
                                           False, False, False, False, False)
            Fm.Sb_Limpiar(_Modalidad)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Formulario, _Tbl_Productos, _Fecha_Emision,
                                                    "Codigo", "Cantidad", "Precio", "", False, True,, True)
            Fm.Pro_SubTido = "GTI"
            _Mensaje = Fm.Fx_Grabar_Documento(False)
            Fm.Dispose()

            If Not _Mensaje.EsCorrecto Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al crear la guía de despacho interna"
            _Mensaje.Detalle = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_GRIDesdeGDI(_Formulario As Form,
                                  _Idmaeedo_Ori As Integer,
                                  _Sucursal_Recepcion As String,
                                  _Bodega_Recepcion As String,
                                  _Fecha_Emision As Date) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Dim _New_Idmaeedo As Integer

        Try

            Consulta_sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Ori & vbCrLf &
                           "Select MAEDDO.*,CASE WHEN UDTRPR = 1 THEN CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 END AS 'Cantidad'," & vbCrLf &
                           "CAPRCO1-CAPREX1 AS 'CantUd1_Dori',CAPRCO2-CAPREX2 AS 'CantUd2_Dori'," & vbCrLf &
                           "CASE WHEN UDTRPR = 1 THEN PPPRNE ELSE PPPRNE*RLUDPR END AS 'Precio'," & vbCrLf &
                           "Isnull(Ofer.Id_Oferta,'') As Id_Oferta," & vbCrLf &
                           "Isnull(Ofer.Oferta,'') As Oferta," & vbCrLf &
                           "Isnull(Ofer.Es_Padre_Oferta,0) As Es_Padre_Oferta," & vbCrLf &
                           "Isnull(Ofer.Padre_Oferta,0) As Padre_Oferta," & vbCrLf &
                           "Isnull(Ofer.Hijo_Oferta,0) As Hijo_Oferta," & vbCrLf &
                           "Isnull(Cantidad_Oferta,0) As Cantidad_Oferta," & vbCrLf &
                           "Isnull(Porcdesc_Oferta,0) As Porcdesc_Oferta" & vbCrLf &
                           "From MAEDDO WITH ( NOLOCK )" & vbCrLf &
                           "Left Join " & _Global_BaseBk & "Zw_Linea_Oferta Ofer On Ofer.Idmaeddo = IDMAEDDO" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")  And (ESLIDO <> 'C' OR ESFALI = 'I')" & vbCrLf &
                           "Order by IDMAEEDO,IDMAEDDO" & vbCrLf &
                           "Select * From MAEIMLI" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")" & vbCrLf &
                           "Select * From MAEDTLI" & vbCrLf &
                           "Where IDMAEEDO In (" & _Idmaeedo_Ori & ")" & vbCrLf &
                           "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Ori

            Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)

            Dim Fm_Post As New Frm_Formulario_Documento("GRI", csGlobales.Enum_Tipo_Documento.Guia_Recepcion_Interna, False)
            Fm_Post.Sb_Limpiar(Mod_Modalidad)
            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True,, _Bodega_Recepcion, _Sucursal_Recepcion, True)

            _Mensaje = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
            _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
            Fm_Post.Dispose()

            If Not _Mensaje.EsCorrecto Then
                Throw New System.Exception(_Mensaje.Mensaje)
            End If

            _Mensaje.EsCorrecto = True
            _Mensaje.Mensaje = "Se ha creado la guía de recepción interna correctamente"
            _Mensaje.Icono = MessageBoxIcon.Information
            _Mensaje.Id = _New_Idmaeedo

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Mensaje = "Error al crear la guía de recepción interna"
            _Mensaje.Detalle = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Error

        End Try

        Return _Mensaje

    End Function


End Class
