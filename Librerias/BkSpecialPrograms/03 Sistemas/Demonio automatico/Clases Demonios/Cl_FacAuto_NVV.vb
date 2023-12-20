Public Class Cl_FacAuto_NVV

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_Sql As String


    Public Property Fecha_Revision As Date
    Public Property Modalidad_Fac As String
    Public Property Fac_Lunes As Boolean
    Public Property Fac_Martes As Boolean
    Public Property Fac_Miercoles As Boolean
    Public Property Fac_Jueves As Boolean
    Public Property Fac_Viernes As Boolean
    Public Property Fac_Sabado As Boolean
    Public Property Fac_Domingo As Boolean
    Public Property FA_1Dia As Boolean
    Public Property FA_1Semana As Boolean
    Public Property FA_1Mes As Boolean
    Public Property FA_1Todas As Boolean
    Public Property Nombre_Equipo As String
    Public Property Log_Registro As String
    Public Property Procesando As Boolean
    Public Property Ejecutar As Boolean

    Public Sub New()
    End Sub

    Sub Sb_Traer_NVV_A_Facturar()

        Dim _Filtro_Fecha As String = String.Empty

        If Not FA_1Todas Then

            Dim _Dias As Integer

            If FA_1Dia Then _Dias = 1
            If FA_1Semana Then _Dias = 7
            If FA_1Mes Then _Dias = 30

            Dim _Fecha_Desde As Date = DateAdd(DateInterval.Day, -_Dias, _Fecha_Revision)

            _Filtro_Fecha = Space(1) & "And FEEMDO >= '" & Format(_Fecha_Desde, "yyyyMMdd") & "'" & Space(1)

        End If

        Consulta_Sql = "Insert Into " & _Global_BaseBk & "Zw_Demonio_FacAuto (Idmaeedo_NVV,Nudo_NVV,Modalidad_Fac,Fecha_Facturar,Facturar)" & vbCrLf &
                       "Select TOP 20 Edo.IDMAEEDO,Edo.NUDO,'" & _Modalidad_Fac & "','" & Format(_Fecha_Revision, "yyyyMMdd") & "',1" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Entidades Ent " &
                       "On Edo.ENDO = Ent.CodEntidad And Edo.SUENDO = Ent.CodSucEntidad " &
                       "Where TIDO = 'NVV' And Ent.FacAuto = 1 " & _Filtro_Fecha & " And ESDO = ''" & vbCrLf &
                       "And IDMAEEDO Not In (Select Idmaeedo_NVV From " & _Global_BaseBk & "Zw_Demonio_FacAuto " &
                       "Where Fecha_Facturar = '" & Format(_Fecha_Revision, "yyyyMMdd") & "')"
        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 1,ErrorGrabar = 0,Informacion = ''" & vbCrLf &
                       "Where Fecha_Facturar = '" & Format(_Fecha_Revision, "yyyyMMdd") & "' And Informacion like 'No existe taza de cambio para la fecha%'"
        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

    End Sub

    Sub Sb_Facturar_Automaticamente_NVV(_Formulario As Form, ByRef Lbl_FacAuto As Object)

        Dim _FechaEmision As Date = FechaDelServidor()

        Consulta_Sql = "Select Top 10 * From " & _Global_BaseBk & "Zw_Demonio_FacAuto Where Facturar = 1"
        Dim _Tbl_Doc_Facturar As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

        If CBool(_Tbl_Doc_Facturar.Rows.Count) Then

            Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Doc_Facturar, "", "Id", True, False, "")
            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar= 0, Facturando = 1 Where Id In " & _Filtro
            If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                Log_Registro += _Sql.Pro_Error & vbCrLf
            End If

            For Each _Fila As DataRow In _Tbl_Doc_Facturar.Rows

                Dim _Id As Integer = _Fila.Item("Id")
                Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo_NVV")
                Dim _Fecha_Emision As Date = _FechaEmision
                Dim _Idmaeedo_Fcv As Integer

                Dim _Nudo_Nvv As String = _Fila.Item("Nudo_Nvv")

                If Not IsNothing(Lbl_FacAuto) Then
                    Lbl_FacAuto.Text = "Facturando Nota de venta Nro: " & _Nudo_Nvv
                End If

                System.Windows.Forms.Application.DoEvents()

                Dim _EstadoFacturacion As EstadoFacturacion = Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario,
                                                                                                            "FCV",
                                                                                                            _Idmaeedo,
                                                                                                            _Fecha_Emision,
                                                                                                            _Modalidad_Fac,
                                                                                                            False)

                If _EstadoFacturacion.Facturada Then

                    _Idmaeedo_Fcv = _EstadoFacturacion.Idmaeedo_FCV

                    Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Fcv
                    Dim _Row_Factura As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                    Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
                    _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Modalidad, _Idmaeedo_Fcv)

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 1" &
                                   ",Idmaeedo_FCV = " & _Row_Factura.Item("IDMAEEDO") &
                                   ",Nudo_Fcv = '" & _Row_Factura.Item("NUDO") & "'" &
                                   ",Fecha_Facturado = '" & Format(_Fecha_Emision, "yyyyMMdd") & "'" &
                                   ",Informacion = '" & _EstadoFacturacion.MensajeError & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += "NVV: " & _Nudo_Nvv & " facturada correctamente. FCV-" & _Row_Factura.Item("NUDO") & vbCrLf
                    Else
                        Log_Registro += _Sql.Pro_Error
                    End If

                Else

                    Log_Registro += _EstadoFacturacion.MensajeError & vbCrLf

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 0" &
                                   ",ErrorGrabar = 1" &
                                   ",Informacion = '" & _EstadoFacturacion.MensajeError & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Sql.Pro_Error
                    End If

                End If

                System.Windows.Forms.Application.DoEvents()

            Next

        End If

    End Sub

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario As Form,
                                                           _Tido_Destino As String,
                                                           _Idmaeedo_Origen As Integer,
                                                           _Fecha_Emision As DateTime,
                                                           _Modalidad As String,
                                                           _Mostrar_Mensaje As Boolean) As EstadoFacturacion

        Dim _New_Idmaeedo As Integer
        Dim _EstadoFacturacion As New EstadoFacturacion
        Dim _Modalidad_Old = Modalidad

        Try

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Modalidad, _Tido_Destino, _Mostrar_Mensaje)

            If IsNothing(_RowFormato) Then
                Throw New System.Exception("No existe formato de documento para la modalidad")
            End If

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Documento) Then

                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                If Not Fx_Revisar_Taza_Cambio(Nothing) Then
                    Throw New System.Exception("No existe taza de cambio para la fecha: " & FechaDelServidor.ToShortDateString)
                End If

                If Not Fx_Se_Puede_Trasladar_Para_Crear_Otro_Documento(_Idmaeedo_Origen) Then
                    Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")
                End If

                Dim _CampoPrecio As String

                If _Meardo = "N" Then ' Neto
                    _CampoPrecio = "PPPRNE"
                Else ' Bruto
                    _CampoPrecio = "PPPRBR"
                End If

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & "
                                            Select *,CAse When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad',
                                            CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori',
                                            Case WHEN UDTRPR = 1 Then " & _CampoPrecio & " Else " & _CampoPrecio & "*RLUDPR End AS 'Precio',
                                            0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta
                                            From MAEDDO  With ( NOLOCK ) 
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''
                                            Order by IDMAEEDO,IDMAEDDO 
                                            Select * From MAEIMLI
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                            Select * From MAEDTLI
                                            Where IDMAEEDO = " & _Idmaeedo_Origen & " 
                                            Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

                'Falta revisar el campo SUBTIDO, ya que al parecer se guardan datos dependiendo del tipo de FCC por ejemplo si tiene derecho a credito fiscal
                'Falta campo FECHATRIB = Fecha de ingreso

                ' SUBTIDO
                '-- 001 Sin derecho a credito fiscal y Sin documento contiene activo fijo
                '-- 000 Documento contiene activo fijo y Sin derecho a credito fiscal
                '-- 101 Conderecho a credito fiscal y documento contiene activo fijo
                '-- 100 Con derecho a credito fiscal y sin documento contiene activo fijo
                '-- '' -- No incluye este documento en el libro de compras 
                'x
                Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql)

                Modalidad = _Modalidad

                Dim Fm_Post As New Frm_Formulario_Documento("FCV", csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
                _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
                Fm_Post.Sb_Activar_Orden_De_Despacho(_New_Idmaeedo)
                Fm_Post.Dispose()

            End If

            If CBool(_New_Idmaeedo) Then
                _EstadoFacturacion.Facturada = True
                _EstadoFacturacion.MensajeError = "Facturada Ok."
                _EstadoFacturacion.Idmaeedo_FCV = _New_Idmaeedo
            Else
                Throw New System.Exception("No fue posible generar la factura")
            End If

        Catch ex As Exception
            _EstadoFacturacion.ErrorEnProceso = True
            _EstadoFacturacion.MensajeError = ex.Message
        Finally
            Modalidad = _Modalidad_Old
        End Try

        Return _EstadoFacturacion

    End Function

End Class

Public Class EstadoFacturacion

    Public Property Facturada As Boolean
    Public Property Idmaeedo_FCV As Integer
    Public Property MensajeError As String
    Public Property ErrorEnProceso As Boolean

End Class
