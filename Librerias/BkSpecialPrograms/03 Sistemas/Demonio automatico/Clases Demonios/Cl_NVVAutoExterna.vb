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
                               "Where Id_Enc = " & _Id_Enc

                Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql)

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

                Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                Fm.Pro_Ejecutar_Automaticamente = True
                Fm.TopMost = True
                Fm.ShowDialog(_Formulario)
                Fm.Dispose()

                If Not String.IsNullOrEmpty(Log_Registro) Then
                    Log_Registro += vbCrLf
                End If

                Dim _NLog_Registro As String = Fx_Crear_NVV(_Formulario, _Id_Enc)

                If Not String.IsNullOrEmpty(_NLog_Registro) Then

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set " &
                                   "Nudo_NVV = 'XXXXXXXXXX',Feemdo_NVV = Getdate(),Observaciones = '" & _NLog_Registro & "'" & vbCrLf &
                                   "Where Id_Enc = " & _Id_Enc
                    _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        _NLog_Registro = _NLog_Registro & vbCrLf & _Sql.Pro_Error
                    End If

                    Log_Registro += _NLog_Registro

                End If

            Next

        End If

    End Sub

    Function Fx_Crear_NVV(_Formulario As Form, _Id_Enc As Integer) As String

        Dim _Modalidad_Old As String = Modalidad
        Dim _LogR As String = String.Empty

        Try

            Consulta_Sql = "Select * From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Where Id_Enc = " & _Id_Enc
            Dim _Row_Encabezado As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            If IsNothing(_Row_Encabezado) Then
                Throw New System.Exception("No se encuentra el Id_Enc = " & _Id_Enc & " en la tabla Zw_Demonio_NVVAuto")
            End If

            Dim _Endo As String = _Row_Encabezado.Item("Endo_Ori")
            Dim _Suendo As String = _Row_Encabezado.Item("Suendo_Ori")
            Dim _NudoOCC_Ori As String = _Row_Encabezado.Item("NudoOCC_Ori")

            Consulta_Sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Endo & "' And SUEN = '" & _Suendo & "'"
            Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            If IsNothing(_Row_Entidad) Then
                Throw New System.Exception("No se encuentra la entidad: " & _Endo.ToString.Trim & "-" & _Suendo.ToString.Trim)
            End If

            Dim _Tido As String = "NVV"
            Dim _Fecha_Emision As DateTime = FechaDelServidor()

            Consulta_Sql = "Select *,1 As Precio From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Where Id_Enc = " & _Id_Enc
            Dim _Tbl_Productos As DataTable = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            If _Tbl_Productos.Rows.Count = 0 Then
                Throw New System.Exception("No se encuentran registros para la tabla Zw_Demonio_NVVAutoDet con el Id_Enc = " & _Id_Enc)
            End If

            Consulta_Sql = "Select * From CONFIEST Where EMPRESA = '" & ModEmpresa & "' And MODALIDAD = '" & Modalidad_NVV & "'"
            Dim _Row_Modalidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            Dim _Sucursal As String = _Row_Modalidad.Item("ESUCURSAL")
            Dim _Bodega As String = _Row_Modalidad.Item("EBODEGA")

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Set " &
                           "Empresa = '" & ModEmpresa & "',Sucursal = '" & _Sucursal & "',Bodega = '" & _Bodega & "' Where Id_Enc = " & _Id_Enc
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            Consulta_Sql = "Select Nvd.Id_Det As Id,Nvd.Codigo,Cantidad,STFI1,STFI2,STOCNV1,STOCNV2,STDV1,STDV2,ISNULL(Pst.StComp1,0) As StComp1,ISNULL(Pst.StComp2,0) As StComp2,
    (STFI1-STOCNV1-STDV1-ISNULL(Pst.StComp1,0)) As 'StDisp1',(STFI2-STOCNV2-STDV2-ISNULL(Pst.StComp2,0)) As 'StDisp2',
	Case 
		When Untrans = 1 Then 
			Case 
				When STFI1 <=0 Then 0 
				Else 
					Case 
						When (STFI1-STOCNV1-STDV1-ISNULL(Pst.StComp1,0)-Cantidad) >= 0 Then Cantidad 
						When STFI1-STOCNV1-STDV1-ISNULL(Pst.StComp1,0) > 0 Then STFI1-STOCNV1-STDV1-ISNULL(Pst.StComp1,0) 
						Else 0
					End 
				End 
				When Untrans = 2 Then 
			Case 
				When STFI2 <=0 Then 0 
				Else 
					Case 
						When (STFI2-STOCNV2-STDV2-ISNULL(Pst.StComp2,0)-Cantidad) >= 0 Then Cantidad 
						When STFI2-STOCNV2-STDV2-ISNULL(Pst.StComp2,0) > 0 Then STFI2-STOCNV2-STDV2-ISNULL(Pst.StComp2,0) 
						Else 0
					End 
				End 
		End	As CntPedida 
Into #Paso
From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Nvd
Inner Join MAEST On EMPRESA = Empresa And KOSU = Sucursal And KOBO = Bodega And KOPR = Codigo
Left Join " & _Global_BaseBk & "Zw_Prod_Stock Pst On EMPRESA = Pst.Empresa And KOSU = Pst.Sucursal And KOBO = Pst.Bodega And KOPR = Pst.Codigo
Where Id_Enc = " & _Id_Enc & "

Update " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Set Stfi1 = STFI1,Stfi2 = STFI2,Stocnv1 = STOCNV1,Stocnv2 = STOCNV2,Stdv1 = STDV1,Stdv2 = STDV2,
StComp1 = #Paso.StComp1,StComp2 = #Paso.StComp2,CantidadDefinitiva = CntPedida
From #Paso Inner Join " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet On Id = Id_Det

Drop table #Paso"
            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            Consulta_Sql = "Select *,1 As Precio From " & _Global_BaseBk & "Zw_Demonio_NVVAutoDet Where Id_Enc = " & _Id_Enc & " And CantidadDefinitiva > 0"
            _Tbl_Productos = _Sql.Fx_Get_Tablas(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)

            If _Tbl_Productos.Rows.Count = 0 Then

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then Throw New System.Exception(_Sql.Pro_Error)
                Throw New System.Exception("Todos los productos están sin Stock suficiente para la OCC-" & _NudoOCC_Ori)

            End If


            Modalidad = Modalidad_NVV

            Dim Fm As New Frm_Formulario_Documento(_Tido,
                                                   csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Venta,
                                                   False, False, False, False, False)
            Fm.Sb_Limpiar(Modalidad_NVV)
            Fm.Pro_RowEntidad = _Row_Entidad
            Fm.Sb_Crear_Documento_Interno_Con_Tabla(_Formulario, _Tbl_Productos, _Fecha_Emision,
                                                    "Codigo", "CantidadDefinitiva", "Precio", "Observacion", False, True,, True)
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
                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                Consulta_Sql = "Update MAEEDOOB Set OBDO = 'Documento generado desde diablito automático desde OCC Nro: " & _Row_Encabezado.Item("NudoOCC_Ori") & "'" & vbCrLf &
                               "Where IDMAEEDO = " & _New_Idmaeedo
                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

            End If


        Catch ex As Exception
            _LogR = ex.Message
        Finally
            Modalidad = _Modalidad_Old
        End Try

        Return _LogR

    End Function

End Class
