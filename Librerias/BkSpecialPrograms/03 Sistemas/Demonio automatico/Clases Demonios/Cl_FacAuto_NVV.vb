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
    Public Property CualquierNVV As Boolean
    Public Property SoloDeSucModalidad As Boolean
    Public Property CantDocFacturanXProceso As Integer
    Public Property FcOrden_Llegada As Boolean
    Public Property FcOrden_ItemMenosMas As Boolean
    Public Property CodFunFactura As String
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
                       "Where Fecha_Facturar = '" & Format(_Fecha_Revision, "yyyyMMdd") & "' And Informacion like 'No existe tasa de cambio para la fecha%'"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

    End Sub

    Sub Sb_Traer_NVV_De_Picking_A_Facturar()

        Dim _Empresa As String = _Sql.Fx_Trae_Dato("CONFIEST", "EMPRESA", "MODALIDAD = '" & Modalidad_Fac & "'",, False)
        Dim _Esucursal As String = _Sql.Fx_Trae_Dato("CONFIEST", "ESUCURSAL", "MODALIDAD = '" & Modalidad_Fac & "'",, False)

        Dim _CondicionSuc = String.Empty
        Dim _CondicionFunFac = " And CodFuncionario_Factura <> ''"

        If SoloDeSucModalidad Then
            _CondicionSuc = " And ((Empresa = '" & _Empresa & "' And Sucursal = '" & _Esucursal & "')" & vbCrLf
            '_CondicionSuc = "And ((Empresa = '" & _Empresa & "' And Sucursal = '" & _Esucursal & "') Or (ModalidadFactura = '" & Modalidad_Fac & "'))" & vbCrLf
        End If

        If Not String.IsNullOrWhiteSpace(CodFunFactura) Then
            _CondicionFunFac = "And CodFuncionario_Factura In " & CodFunFactura
        End If

        Consulta_Sql = "Select TOP 20 Idmaeedo,Id,DocEmitir,Fecha_Facturar,CodFuncionario_Factura,PagarAuto,Idmaedpce_Paga,CodFuncionario_Paga" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Stmp_Enc" & vbCrLf &
                       "Where Facturar = 1 And Estado = 'COMPL' And EnvFacAutoBk = 0" & _CondicionSuc & _CondicionFunFac &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set EnvFacAutoBk = 1" & vbCrLf &
                       "Where Idmaeedo In (Select Idmaeedo From #Paso)" & vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Demonio_FacAuto (Idmaeedo_NVV,Nudo_NVV,Modalidad_Fac,Fecha_Facturar,Facturar,DesdePickeo,Id_Pickeo,DocEmitir,CerrarDespFact,CodFuncionario_Factura,PagarAuto,Idmaedpce_Paga,CodFuncionario_Paga)" & vbCrLf &
                       "Select Edo.IDMAEEDO As 'Idmaeedo_NVV',Edo.NUDO As 'Nudo_NVV','" & Modalidad_Fac & "' As 'Modalidad_Fac',Fecha_Facturar As Fecha_Facturar,1 As 'Facturar'," & vbCrLf &
                       "1 As 'DesdePickeo',#Paso.Id As 'Id_Pickeo',#Paso.DocEmitir As 'DocEmitir',1 As 'CerrarDespFact',CodFuncionario_Factura,PagarAuto,Idmaedpce_Paga,CodFuncionario_Paga" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join #Paso On #Paso.Idmaeedo = Edo.IDMAEEDO" & vbCrLf &
                       vbCrLf &
                       "Drop Table #Paso"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 0,ErrorGrabar = 0,Informacion = ''" & vbCrLf &
                       "Where Fecha_Facturar = '" & Format(_Fecha_Revision, "yyyyMMdd") & "' And Informacion like 'No existe tasa de cambio para la fecha%'"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

    End Sub

    Sub Sb_Traer_NVV_De_NVVAuto_A_Facturar()

        Dim _Empresa As String = _Sql.Fx_Trae_Dato("CONFIEST", "EMPRESA", "MODALIDAD = '" & Modalidad_Fac & "'",, False)
        Dim _Esucursal As String = _Sql.Fx_Trae_Dato("CONFIEST", "ESUCURSAL", "MODALIDAD = '" & Modalidad_Fac & "'",, False)

        Dim _CondicionSuc = String.Empty

        If SoloDeSucModalidad Then
            _CondicionSuc = "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Esucursal & "'"
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set Facturar = 0" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Nv" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Entidades Ent" & vbCrLf &
                       "On Nv.Endo_Ori = Ent.CodEntidad And Nv.Suendo_Ori = Ent.CodSucEntidad" & vbCrLf &
                       "Where NVVGenerada = 1 And Facturar = 1 And Ent.FacAuto = 0"
        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Select TOP 20 Idmaeedo_NVV As Idmaeedo,DocEmitir,Cast('" & Format(_Fecha_Revision, "yyyyMMdd") & "' As datetime) As Fecha_Facturar,CodFuncionario_Factura,Modalidad_Fac" & vbCrLf &
                       "Into #Paso" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_NVVAuto Nv" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Entidades Ent" & vbCrLf &
                       "On Nv.Endo_Ori = Ent.CodEntidad And Nv.Suendo_Ori = Ent.CodSucEntidad " & vbCrLf &
                       "Where NVVGenerada = 1 And Facturar = 1 And DocEmitir <> '' And EnvFacAutoBk = 0 And Ent.FacAuto = 1" & _CondicionSuc & vbCrLf &
                       vbCrLf &
                       "Update " & _Global_BaseBk & "Zw_Demonio_NVVAuto Set EnvFacAutoBk = 1" & vbCrLf &
                       "Where Idmaeedo_NVV In (Select Idmaeedo From #Paso)" & vbCrLf &
                       vbCrLf &
                       "Insert Into " & _Global_BaseBk & "Zw_Demonio_FacAuto (Idmaeedo_NVV,Nudo_NVV,Modalidad_Fac,Fecha_Facturar,Facturar,DesdeNVVAuto,DocEmitir,CerrarDespFact,CodFuncionario_Factura)" & vbCrLf &
                       "Select Edo.IDMAEEDO As 'Idmaeedo_NVV',Edo.NUDO As 'Nudo_NVV',Case When #Paso.Modalidad_Fac <> '' Then #Paso.Modalidad_Fac Else '" & Modalidad_Fac & "' End As 'Modalidad_Fac',Fecha_Facturar,1 As 'Facturar'," & vbCrLf &
                       "1 As 'DesdeNVVAuto',#Paso.DocEmitir As 'DocEmitir',1 As 'CerrarDespFact',CodFuncionario_Factura" & vbCrLf &
                       "From MAEEDO Edo" & vbCrLf &
                       "Inner Join #Paso On #Paso.Idmaeedo = Edo.IDMAEEDO" & vbCrLf &
                       vbCrLf &
                       "Drop Table #Paso"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 1,ErrorGrabar = 0,Informacion = ''" & vbCrLf &
                       "Where Fecha_Facturar = '" & Format(_Fecha_Revision, "yyyyMMdd") & "' And Informacion like 'No existe tasa de cambio para la fecha%'"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 1,ErrorGrabar = 0,Informacion = ''" & vbCrLf &
                       "Where ErrorGrabar = 1 And Informacion = '' And DesdeNVVAuto = 1"

        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

    End Sub

    ''' <summary>
    ''' Este método cambia la empresa, sucursal y bodega de los documentos que se encuentran en el demonio de facturación automática
    ''' Se utiliza para corregir documentos que se encuentran con la empresa, sucursal y bodega equivocada
    ''' 
    ''' Se debe ejecutar una vez que se hayan corregido los datos de las tablas MAEEDO y MAEDDO
    ''' Por el momento solo es para la empresa 02 MeatGarden de SeaGarden
    ''' </summary>
    Sub Sb_Cambiar_EmpSucBod()

        Consulta_Sql = "Select Distinct Idmaeedo,Tido,Nudo,Empresa,Sucursal,Bodega From " & _Global_BaseBk & "Zw_Docu_Det" & vbCrLf &
                       "Where Idmaeedo In (Select Zenc.Idmaeedo From " & _Global_BaseBk & "Zw_Stmp_Enc Zenc" & vbCrLf &
                       "Inner Join " & _Global_BaseBk & "Zw_Docu_Det Zd On Zenc.Idmaeedo = Zd.Idmaeedo" & vbCrLf &
                       "Where Facturar = 1 And Estado = 'COMPL' And EnvFacAutoBk = 0 And Zd.Empresa = '02' And Zenc.Empresa = '01')"
        Dim _Tbl_Det As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        For Each _Fila As DataRow In _Tbl_Det.Rows

            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo")
            Dim _Tido As String = _Fila.Item("Tido").ToString.Trim
            Dim _Nudo As String = _Fila.Item("Nudo").ToString.Trim
            Dim _Empresa As String = _Fila.Item("Empresa").ToString.Trim
            Dim _Sucursal As String = _Fila.Item("Sucursal").ToString.Trim
            Dim _Bodega As String = _Fila.Item("Bodega").ToString.Trim

            Consulta_Sql = "Declare @Idmaeedo Int = " & _Idmaeedo & vbCrLf &
                           "Update MAEEDO Set EMPRESA = '" & _Empresa & "',SUDO = '" & _Sucursal & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update MAEDDO Set EMPRESA = '" & _Empresa & "',SULIDO = '" & _Sucursal & "',BOSULIDO = '" & _Bodega & "' Where IDMAEEDO = @Idmaeedo" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Despachos Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "',Bodega = '" & _Bodega &
                                "' Where Id_Despacho In (Select Id_Despacho From " & _Global_BaseBk & "Zw_Despachos_Doc WHERE (Idrst = @Idmaeedo) AND (Archidrst = 'MAEEDO'))" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set Empresa = '" & _Empresa & "',Sucursal = '" & _Sucursal & "' Where Idmaeedo = @Idmaeedo" & vbCrLf &
                           "Update " & _Global_BaseBk & "Zw_Docu_Ent Set Empresa = '" & _Empresa & "' Where Idmaeedo = @Idmaeedo"
            _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql, False)

            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                Log_Registro += _Sql.Pro_Error & vbCrLf
            End If

        Next

    End Sub

    Sub Sb_Facturar_Automaticamente_NVV(_Formulario As Form, ByRef Lbl_FacAuto As Object)

        Dim _FechaEmision As Date = FechaDelServidor()

        Consulta_Sql = "Select Top 20 * From " & _Global_BaseBk & "Zw_Demonio_FacAuto Where Facturar = 1"
        Dim _Tbl_Doc_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        If CBool(_Tbl_Doc_Facturar.Rows.Count) Then

            Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Doc_Facturar, "", "Id", True, False, "")
            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 0, Facturando = 1 Where Id In " & _Filtro
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

                Dim _Mensaje As LsValiciones.Mensajes = Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario,
                                                                                                      "FCV",
                                                                                                      _Idmaeedo,
                                                                                                      _Fecha_Emision,
                                                                                                      _Modalidad_Fac,
                                                                                                      False)

                If _Mensaje.EsCorrecto Then

                    _Idmaeedo_Fcv = _Mensaje.Id

                    Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Fcv
                    Dim _Row_Factura As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        Log_Registro += _Sql.Pro_Error & vbCrLf
                    End If

                    Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito
                    _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Mod_Modalidad, _Idmaeedo_Fcv)

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 1" &
                                   ",Idmaeedo_FCV = " & _Row_Factura.Item("IDMAEEDO") &
                                   ",Nudo_Fcv = '" & _Row_Factura.Item("NUDO") & "'" &
                                   ",Fecha_Facturado = '" & Format(_Fecha_Emision, "yyyyMMdd") & "'" &
                                   ",Informacion = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += "NVV: " & _Nudo_Nvv & " facturada correctamente. FCV-" & _Row_Factura.Item("NUDO") & vbCrLf
                    Else
                        Log_Registro += _Sql.Pro_Error
                    End If

                Else

                    Log_Registro += _Mensaje.Mensaje & vbCrLf

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 0" &
                                   ",ErrorGrabar = 1" &
                                   ",Informacion = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Sql.Pro_Error
                    End If

                End If

                System.Windows.Forms.Application.DoEvents()

            Next

        End If

    End Sub

    Sub Sb_Facturar_Automaticamente_NVV_New(_Formulario As Form, ByRef Lbl_FacAuto As Object)

        Dim _FechaEmision As Date = FechaDelServidor()

        Dim _IpEquipo As String = Fx_GetLocalIPAddress() 'Fx_Get_Ip()

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Facturar = 1, Facturando = 0" & vbCrLf &
                       "Where NombreEquipo = '" & Nombre_Equipo & "' And Facturando = 1 And IpEquipo = '" & _IpEquipo & "'"
        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto  Set CantItem = (Select COUNT(*) From MAEDDO Where IDMAEEDO = Idmaeedo_NVV)" & vbCrLf &
                       "Where CantItem = 0 And Facturar = 1"
        _Sql.Ej_consulta_IDU(Consulta_Sql, False)

        Dim _Orden = String.Empty

        If FcOrden_ItemMenosMas Then
            _Orden = "Order By CantItem"
        End If

        Consulta_Sql = "Select Top " & CantDocFacturanXProceso & " * From " & _Global_BaseBk & "Zw_Demonio_FacAuto Where Facturar = 1" & vbCrLf & _Orden
        Dim _Tbl_Doc_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
            Log_Registro += _Sql.Pro_Error
            Return
        End If

        If CBool(_Tbl_Doc_Facturar.Rows.Count) Then

            Dim _Filtro As String = Generar_Filtro_IN(_Tbl_Doc_Facturar, "", "Id", True, False, "")

            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                           "Facturar = 0, Facturando = 1,NombreEquipo = '" & Nombre_Equipo & "',IpEquipo = '" & _IpEquipo & "'" & vbCrLf &
                           "Where Id In " & _Filtro

            If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                Log_Registro += _Sql.Pro_Error & vbCrLf
            End If

            For Each _Fila As DataRow In _Tbl_Doc_Facturar.Rows

                Dim _Id As Integer = _Fila.Item("Id")
                Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo_NVV")
                Dim _Fecha_Emision As Date = _Fila.Item("Fecha_Facturar") '_FechaEmision
                Dim _Idmaeedo_Fcv As Integer
                Dim _DesdePickeo As Boolean = _Fila.Item("DesdePickeo")
                Dim _DocEmitir As String = _Fila.Item("DocEmitir")
                Dim _CerrarDespFact As Boolean = _Fila.Item("CerrarDespFact")
                Dim _Id_Pickeo As Integer = _Fila.Item("Id_Pickeo")
                Dim _CodFuncionario_Factura As String = _Fila.Item("CodFuncionario_Factura").ToString.Trim
                Dim _DesdeNVVAuto As Boolean = _Fila.Item("DesdeNVVAuto")
                Dim _Modalidad_Fac As String = _Fila.Item("Modalidad_Fac")

                Dim _Nudo_Nvv As String = _Fila.Item("Nudo_Nvv")
                Dim _Empresa As String = _Sql.Fx_Trae_Dato("MAEEDO", "EMPRESA", "IDMAEEDO = " & _Idmaeedo,, False)

                If Not IsNothing(Lbl_FacAuto) Then
                    Lbl_FacAuto.Text = "Facturando Nota de venta Nro: " & _Nudo_Nvv
                End If

                If String.IsNullOrWhiteSpace(_Modalidad_Fac) Then
                    _Modalidad_Fac = Modalidad_Fac
                End If

                System.Windows.Forms.Application.DoEvents()

                If String.IsNullOrEmpty(_DocEmitir) Then
                    _DocEmitir = "FCV"
                End If

                Dim _Mensaje As LsValiciones.Mensajes

                If _DesdePickeo Then
                    _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente_Pickeo(_Formulario, _DocEmitir, _Idmaeedo, _Fecha_Emision, _Empresa, _Modalidad_Fac, _CerrarDespFact, _Id_Pickeo)
                Else
                    _Mensaje = Fx_Crear_Documento_Desde_Otro_Automaticamente2(_Formulario, _DocEmitir, _Idmaeedo, _Fecha_Emision, _Empresa, _Modalidad_Fac, _CerrarDespFact)
                End If

                If _Mensaje.EsCorrecto Then

                    _Idmaeedo_Fcv = _Mensaje.Id

                    If Not String.IsNullOrEmpty(_CodFuncionario_Factura) Then
                        Consulta_Sql = "Update MAEEDO Set KOFUDO = '" & _CodFuncionario_Factura & "' Where IDMAEEDO = " & _Idmaeedo_Fcv
                        _Sql.Ej_consulta_IDU(Consulta_Sql, False)
                    End If


                    If _Sql.Fx_Existe_Tabla("[@WMS_GATEWAY_TRANSFERENCIA]") Then

                        Consulta_Sql = "Select Top 1 * From [@WMS_GATEWAY_TRANSFERENCIA] Where IDMAEEDO = " & _Idmaeedo
                        Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

                        If Not IsNothing(_Row) Then
                            Consulta_Sql = "Update [@WMS_GATEWAY_TRANSFERENCIA] Set UPLOAD = 3 Where IDMAEEDO = " & _Idmaeedo
                            If _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_Sql) Then
                                _Mensaje.Mensaje += ".  - Se deja el campo UPLOAD = 3 en la tabla [@WMS_GATEWAY_TRANSFERENCIA]"
                            Else
                                _Mensaje.Mensaje += ".  - Problema al editar la tabla [@WMS_GATEWAY_TRANSFERENCIA]: " & _Sql.Pro_Error
                            End If
                        Else
                            _Mensaje.Mensaje += ".  - No se encontro registro en la tabla [@WMS_GATEWAY_TRANSFERENCIA]"
                        End If

                    End If

                    'Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Fcv
                    Dim _Row_Factura As DataRow = _Mensaje.Tag '_Sql.Fx_Get_DataRow(Consulta_Sql)

                    Dim _Cl_Imprimir As New Cl_Enviar_Impresion_Diablito

                    If Not String.IsNullOrEmpty(_CodFuncionario_Factura) Then
                        _Cl_Imprimir.CodFuncionario = _CodFuncionario_Factura
                    End If

                    _Cl_Imprimir.Fx_Enviar_Impresion_Al_Diablito(Mod_Modalidad, _Idmaeedo_Fcv)

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 1" &
                                   ",Idmaeedo_FCV = " & _Row_Factura.Item("IDMAEEDO") &
                                   ",Nudo_Fcv = '" & _Row_Factura.Item("NUDO") & "'" &
                                   ",Fecha_Facturado = '" & Format(_Fecha_Emision, "yyyyMMdd") & "'" &
                                   ",Informacion = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                                   ",FechaHoraFacturado = Getdate()" & vbCrLf &
                                   ",IpEquipo = '" & _IpEquipo & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += "NVV: " & _Nudo_Nvv & " facturada correctamente. " & _Row_Factura.Item("TIDO") & "-" & _Row_Factura.Item("NUDO") & vbCrLf
                    Else
                        Log_Registro += _Sql.Pro_Error
                    End If

                    Dim _Error_PDF = Fx_Guargar_PDF_Automaticamente_Por_Doc_Modalidad(_Row_Factura.Item("IDMAEEDO"), Mod_Empresa, Modalidad_Fac)

                    If Not String.IsNullOrEmpty(_Error_PDF) Then
                        Log_Registro += _Error_PDF
                        'MessageBoxEx.Show(Me, _Error_PDF, "Error al querer grabar PDF automático", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Else

                    _Mensaje.Mensaje = Replace(_Mensaje.Mensaje, "'", "''")

                    Log_Registro += _Mensaje.Mensaje & vbCrLf

                    Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                                   " NombreEquipo = '" & _Nombre_Equipo & "'" &
                                   ",Facturando = 0" &
                                   ",Facturado = 0" &
                                   ",ErrorGrabar = 1" &
                                   ",Informacion = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                                   "Where Id = " & _Id
                    If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                        Log_Registro += _Sql.Pro_Error
                    End If

                End If

                System.Windows.Forms.Application.DoEvents()

            Next

        End If

    End Sub

    Sub Sb_Pagar_Documentos()

        Dim _IpEquipo As String = Fx_GetLocalIPAddress()

        Consulta_Sql = "Select Fa.Id,Edo.TIDO,Td.NOTIDO,Fa.Idmaeedo_FCV,Edo.NUDO,Fa.Idmaedpce_Paga,Fa.CodFuncionario_Paga" & vbCrLf &
                       "From " & _Global_BaseBk & "Zw_Demonio_FacAuto Fa" & vbCrLf &
                       "Inner Join MAEEDO Edo On Edo.IDMAEEDO = Fa.Idmaeedo_FCV" & vbCrLf &
                       "Left Join TABTIDO Td On Td.TIDO = Edo.TIDO" & vbCrLf &
                       "Where NombreEquipo = '" & Nombre_Equipo & "' And IpEquipo = '" & _IpEquipo & "' And PagarAuto = 1 And Facturado = 1 And Edo.TIDO In ('FCV','BLV')"
        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

        If Not CBool(_Tbl.Rows.Count) Then
            Return
        End If

        Dim _Filtro_Pagar As String = Generar_Filtro_IN(_Tbl, "", "Id", True, False, "")

        Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set PagarAuto = 0 Where Id In " & _Filtro_Pagar
        If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
            Log_Registro += _Sql.Pro_Error & vbCrLf
        End If

        For Each _Fila As DataRow In _Tbl.Rows

            Dim _Id As Integer = _Fila.Item("Id")
            Dim _Notido As String = _Fila.Item("NOTIDO").ToString.Trim.ToLower
            Dim _Tido As String = _Fila.Item("TIDO").ToString.Trim
            Dim _Idmaeedo As Integer = _Fila.Item("Idmaeedo_FCV")
            Dim _Idmaedpce_Paga As Integer = _Fila.Item("Idmaedpce_Paga")
            Dim _CodFuncionario_Paga As String = _Fila.Item("CodFuncionario_Paga").ToString.Trim

            If _Tido <> "BLV" And _Tido <> "FCV" Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                               "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'El documento no es una boleta o factura'" & vbCrLf &
                               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If
                Continue For

            End If


            Dim _Cl_Pagar As New Clas_Pagar
            Dim _Maedpce As MAEDPCE
            Dim _Mensaje As LsValiciones.Mensajes

            Consulta_Sql = "Select *,VABRDO-VAABDO As 'TOTSALDO' From MAEEDO Where IDMAEEDO = " & _Idmaeedo
            Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If IsNothing(_Row_Maeedo) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
               "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'No se encontro el documentos en la tabla MAEEDO, IDMAEEDO =  " & _Idmaeedo & "'" & vbCrLf &
               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If
                Continue For

            End If

            Dim _Saldo As Double = _Row_Maeedo.Item("TOTSALDO")

            If _Saldo <= 0 Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                               "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'La " & _Notido & " no tiene saldo a pagar'" & vbCrLf &
                               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If
                Continue For

            End If

            Consulta_Sql = "Select TOP 1 * From MAEDPCE Where IDMAEDPCE = " & _Idmaedpce_Paga
            Dim _Row_Maedpce As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

            If IsNothing(_Row_Maedpce) Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
               "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'No se encontro el documentos en la tabla MAEDPCE, IDMAEDPCE =  " & _Idmaedpce_Paga & "'" & vbCrLf &
               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If
                Continue For

            End If


            Dim _Vadp As Double = _Row_Maedpce.Item("VADP")
            Dim _Vaasdpce As Double = _Row_Maedpce.Item("VAASDP")

            Dim _SaldoPago As Double = _Row_Maedpce.Item("VADP") - _Row_Maedpce.Item("VAASDP")

            If _SaldoPago <= 0 Then
                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                               "Error_Paga = 1,PagarAuto = 0,Pagada = 0,Informacion_Paga = 'El documento de pago no tiene saldo para pagar'" & vbCrLf &
                               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If
                Continue For
            End If

            If _Saldo > _SaldoPago Then
                _Saldo = _SaldoPago
            End If

            _Maedpce = New MAEDPCE With {
            .IDMAEDPCE = _Row_Maedpce.Item("IDMAEDPCE"),
            .TIDP = _Row_Maedpce.Item("TIDP"),
            .EMPRESA = _Row_Maedpce.Item("EMPRESA"),
            .ENDP = _Row_Maedpce.Item("ENDP"),
            .EMDP = _Row_Maedpce.Item("EMDP"),
            .SUEMDP = _Row_Maedpce.Item("SUEMDP"),
            .CUDP = _Row_Maedpce.Item("CUDP"),
            .NUCUDP = _Row_Maedpce.Item("NUCUDP"),
            .FEEMDP = _Row_Maedpce.Item("FEEMDP"),
            .FEVEDP = _Row_Maedpce.Item("FEVEDP"),
            .MODP = _Row_Maedpce.Item("MODP"),
            .TIMODP = _Row_Maedpce.Item("TIMODP"),
            .TAMODP = _Row_Maedpce.Item("TAMODP"),
            .VADP = _Row_Maedpce.Item("VADP"),
            .VAASDP = _Saldo,
            .VAVUDP = 0,
            .ESASDP = _Row_Maedpce.Item("ESASDP"),
            .ESPGDP = _Row_Maedpce.Item("ESPGDP"),
            .SUREDP = _Row_Maedpce.Item("SUREDP"),
            .CJREDP = _Row_Maedpce.Item("CJREDP"),
            .KOFUDP = _Row_Maedpce.Item("KOFUDP"),
            .REFANTI = _Row_Maedpce.Item("REFANTI"),
            .KOTU = _Row_Maedpce.Item("KOTU"),
            .VAABDP = _Row_Maedpce.Item("VAABDP"),
            .CUOTAS = _Row_Maedpce.Item("CUOTAS"),
            .ARCHIRSD = _Row_Maedpce.Item("ARCHIRSD"),
            .IDRSD = _Row_Maedpce.Item("IDRSD"),
            .KOTNDP = _Row_Maedpce.Item("KOTNDP"),
            .SUTNDP = _Row_Maedpce.Item("SUTNDP")
            }

            Dim _Fecha_Asignacion_Pago As Date = FechaDelServidor()
            Dim _Ls_Maedpce As New List(Of MAEDPCE)

            _Ls_Maedpce.Add(_Maedpce)

            _Mensaje = _Cl_Pagar.Fx_Pagar_Documento(_Idmaeedo, _Ls_Maedpce, _Fecha_Asignacion_Pago)

            If _Mensaje.EsCorrecto Then

                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set Pagada = 1 Where Id = " & _Id
                _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If

            Else

                _Mensaje.Mensaje = Replace(_Mensaje.Mensaje, " '", "''")
                Log_Registro += _Mensaje.Mensaje & vbCrLf
                Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Demonio_FacAuto Set " &
                               ",PagarAuto = 0" &
                               ",Pagada = 0" &
                               ",Error_Paga = 1" &
                               ",Informacion_Paga = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                               "Where Id = " & _Id
                If Not _Sql.Ej_consulta_IDU(Consulta_Sql, False) Then
                    Log_Registro += _Sql.Pro_Error
                End If

            End If

        Next

    End Sub

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente(_Formulario As Form,
                                                           _Tido_Destino As String,
                                                           _Idmaeedo_Origen As Integer,
                                                           _Fecha_Emision As DateTime,
                                                           _Modalidad As String,
                                                           _Mostrar_Mensaje As Boolean) As LsValiciones.Mensajes

        Dim _New_Idmaeedo As Integer
        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Modalidad_Old = Mod_Modalidad

        Try

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, Mod_Empresa, _Modalidad, _Tido_Destino, _Mostrar_Mensaje)

            If IsNothing(_RowFormato) Then
                Throw New System.Exception("No existe formato de documento para la modalidad")
            End If

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            If Not IsNothing(_Row_Documento) Then

                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes

                _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Nothing,,, False)

                If Not _Msj_Tsc.EsCorrecto Then

                    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                    Throw New System.Exception(_Mensaje.Mensaje)

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

                Mod_Modalidad = _Modalidad

                Dim Fm_Post As New Frm_Formulario_Documento("FCV", csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)
                Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento, True, False)
                _New_Idmaeedo = Fm_Post.Pro_Idmaeedo
                Fm_Post.Sb_Activar_Orden_De_Despacho(_New_Idmaeedo)
                Fm_Post.Dispose()

            End If

            If CBool(_New_Idmaeedo) Then
                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Facturada Ok."
                _Mensaje.Id = _New_Idmaeedo
            Else
                Throw New System.Exception("No fue posible generar la factura")
            End If

        Catch ex As Exception
            _Mensaje.Detalle = "Error al grabar"
            _Mensaje.Mensaje = ex.Message
        Finally
            Mod_Modalidad = _Modalidad_Old
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente2(_Formulario As Form,
                                                           _Tido_Destino As String,
                                                           _Idmaeedo_Origen As Integer,
                                                           _Fecha_Emision As DateTime,
                                                           _Empresa As String,
                                                           _Modalidad As String,
                                                           _CerrarDespFact As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes
        Dim _Modalidad_Old = Mod_Modalidad

        Try

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "MODALIDAD = '" & _Modalidad & "'")

            If _Reg = 0 Then
                Throw New System.Exception("No existe la modalidad " & _Modalidad)
            End If

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _Tido_Destino, False)

            If IsNothing(_RowFormato) Then
                Throw New System.Exception("No existe formato de documento para la modalidad")
            End If

            Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
            Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

            Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

            If Not IsNothing(_Row_Documento) Then

                Dim _Meardo = _Row_Documento.Item("MEARDO")
                Dim _Tido = _Row_Documento.Item("TIDO")
                Dim _Nudo = _Row_Documento.Item("NUDO")

                Dim _Msj_Tsc As LsValiciones.Mensajes

                _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Nothing,,, False)

                If Not _Msj_Tsc.EsCorrecto Then

                    _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                    Throw New System.Exception(_Mensaje.Mensaje)

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

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                "Select *,Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End As 'Cantidad'," & vbCrLf &
                                "CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori'," & vbCrLf &
                                "Case WHEN UDTRPR = 1 Then " & _CampoPrecio & " Else " & _CampoPrecio & "*RLUDPR End AS 'Precio'," & vbCrLf &
                                "0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta" & vbCrLf &
                                "From MAEDDO  With ( NOLOCK )" & vbCrLf &
                                "Where IDMAEEDO = " & _Idmaeedo_Origen & "  AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''" & vbCrLf &
                                "Order by IDMAEEDO,IDMAEDDO" & vbCrLf &
                                "Select * From MAEIMLI" & vbCrLf &
                                "Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                "Select * From MAEDTLI" & vbCrLf &
                                "Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

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

                Mod_Modalidad = _Modalidad

                Dim Fm_Post As New Frm_Formulario_Documento(_Tido_Destino, csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)
                Fm_Post.Sb_Limpiar(_Modalidad)
                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)

                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False, csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento,
                                                             True, False,,, False)

                If _Msj_GrabarDoc.EsCorrecto Then
                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                End If

                Fm_Post.Dispose()

            End If

            If _Msj_GrabarDoc.EsCorrecto Then

                If _CerrarDespFact Then

                    Dim Cerrar_Doc As New Clas_Cerrar_Documento

                    Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo_Origen)

                    Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

                    If String.IsNullOrEmpty(_Sql.Pro_Error) Then

                        Dim _Tbl_Maeddo = _Ds.Tables(1)

                        If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo_Origen, _Tbl_Maeddo) Then

                        End If

                    End If

                End If

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql)

                _Mensaje.EsCorrecto = True
                _Mensaje.Detalle = "Documento: " & _Row.Item("TIDO") & "-" & _Row.Item("NUDO") & " grabado con exito"
                _Mensaje.Mensaje = "Nota de venta gestionada correctamente Ok."
                _Mensaje.Id = _Msj_GrabarDoc.Id
                _Mensaje.Tag = _Row

            Else
                Throw New System.Exception("No fue posible generar la factura")
            End If

        Catch ex As Exception
            _Mensaje.Detalle = "Error al grabar documento"
            _Mensaje.Mensaje = ex.Message
        Finally
            Mod_Modalidad = _Modalidad_Old
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_Pickeo(_Formulario As Form,
                                                                  _TidoDocEmitir As String,
                                                                  _Idmaeedo_Origen As Integer,
                                                                  _Fecha_Emision As DateTime,
                                                                  _Empresa As String,
                                                                  _Modalidad As String,
                                                                  _CerrarDespFact As Boolean,
                                                                  _Id_Pickeo As Integer) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If _TidoDocEmitir <> "GDV" And _TidoDocEmitir <> "FCV" And _TidoDocEmitir <> "BLV" Then
                _Mensaje.Mensaje = "Error"
                Throw New System.Exception("El Tido Destino esta vacío o no corresponde: (" & _TidoDocEmitir & "), solo puede ser: BLV, FCV y GDV")
            End If

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _Reg As Integer = _Sql.Fx_Cuenta_Registros("CONFIEST", "EMPRESA = '" & _Empresa & "' And MODALIDAD = '" & _Modalidad & "'", False)

            If _Reg = 0 Then
                Throw New System.Exception(_Sql.Pro_Error)
            End If

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _TidoDocEmitir, False)

            If Not IsNothing(_RowFormato) Then

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    _Mensaje.Mensaje = "Error"
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                If Not IsNothing(_Row_Documento) Then

                    Dim _Meardo = _Row_Documento.Item("MEARDO")
                    Dim _Tido = _Row_Documento.Item("TIDO")
                    Dim _Nudo = _Row_Documento.Item("NUDO")

                    Dim _Msj_Tsc As LsValiciones.Mensajes

                    _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Nothing,,, False)

                    If Not _Msj_Tsc.EsCorrecto Then

                        _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                        Throw New System.Exception(_Msj_Tsc.Mensaje)

                    End If


                    Consulta_Sql = "SELECT IDMAEEDO FROM MAEDDO WHERE IDMAEEDO = " & _Idmaeedo_Origen & " AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''"

                    Dim _Tbl_Saldo_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        _Mensaje.Mensaje = "Error"
                        Throw New System.Exception(_Sql.Pro_Error)
                    End If

                    If CBool(_Tbl_Saldo_Facturar.Rows.Count) Then

                        'Dim _Empresa As String = Mod_Empresa
                        'Dim _Sucursal As String = Mod_Sucursal
                        'Dim _Bodega As String = Mod_Bodega

                        Dim _CampoPrecio As String

                        If _Meardo = "N" Then ' Neto
                            _CampoPrecio = "PPPRNE"
                        Else ' Bruto
                            _CampoPrecio = "PPPRBR"
                        End If

                        Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                       vbCrLf &
                                       "Select Distinct Ddo.*," & vbCrLf &
                                       "Case TIPR" & vbCrLf &
                                       "When 'SSN' Then Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End" & vbCrLf &
                                       "Else Case PRCT" & vbCrLf &
                                       "When 0 Then Case When UDTRPR = 1 Then Det.Caprco1_Real Else Det.Caprco2_Real End" & vbCrLf &
                                       "Else Case When UDTRPR = 1 Then CAPRCO1-CAPREX1 ELSE CAPRCO2-CAPREX2 End" & vbCrLf &
                                       "End" & vbCrLf &
                                       "End As 'Cantidad'," & vbCrLf &
                                       "Case PRCT When 0 Then Det.Caprco1_Real Else CAPRCO1-CAPREX1 End As 'CantUd1_Pickea'," & vbCrLf &
                                       "Case PRCT When 0 Then Det.Caprco2_Real Else CAPRCO1-CAPREX1 End As 'CantUd2_Pickea'," & vbCrLf &
                                       "Cast(1 As Bit) As DesdePickeo," & vbCrLf &
                                       "CAPRCO1-CAPREX1 As 'CantUd1_Dori',CAPRCO2-CAPREX2 As 'CantUd2_Dori'," & vbCrLf &
                                       "--Case WHEN UDTRPR = 1 Then PPPRNE Else PPPRNE*RLUDPR End AS 'Precio'," & vbCrLf &
                                       "PPPRNE AS 'Precio'," & vbCrLf &
                                       "0 As Id_Oferta,'' As Oferta,0 As Es_Padre_Oferta,0 As Padre_Oferta,0 As Hijo_Oferta,0 As Cantidad_Oferta,0 As Porcdesc_Oferta," & vbCrLf &
                                       "Isnull(Det.RtuVariable,0) As 'RtuVariable'" & vbCrLf &
                                       "From MAEDDO Ddo With ( NOLOCK )" & vbCrLf &
                                       "Left Join " & _Global_BaseBk & "Zw_Stmp_Det Det On Ddo.IDMAEDDO = Det.Idmaeddo" & vbCrLf &
                                       "Where IDMAEEDO = " & _Idmaeedo_Origen & " AND ( ESLIDO<>'C' OR ESFALI='I' ) --AND TICT = ''" & vbCrLf &
                                       "Order by IDMAEEDO,IDMAEDDO " & vbCrLf &
                                       vbCrLf &
                                       "Select * From MAEIMLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                       vbCrLf &
                                       "Select * From MAEDTLI Where IDMAEEDO = " & _Idmaeedo_Origen & vbCrLf &
                                       vbCrLf &
                                       "Select TOP 1 * From MAEEDOOB Where IDMAEEDO = " & _Idmaeedo_Origen

                        'Falta revisar el campo SUBTIDO, ya que al parecer se guardan datos dependiendo del tipo de FCC por ejemplo si tiene derecho a credito fiscal
                        'Falta campo FECHATRIB = Fecha de ingreso

                        ' SUBTIDO
                        '-- 001 Sin derecho a credito fiscal y Sin documento contiene activo fijo
                        '-- 000 Documento contiene activo fijo y Sin derecho a credito fiscal
                        '-- 101 Conderecho a credito fiscal y documento contiene activo fijo
                        '-- 100 Con derecho a credito fiscal y sin documento contiene activo fijo
                        '-- '' -- No incluye este documento en el libro de compras 

                        Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

                        Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

                        If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                            _Mensaje.Mensaje = "Error"
                            Throw New System.Exception(_Sql.Pro_Error)
                        End If

                        Dim Fm_Post As New Frm_Formulario_Documento(_TidoDocEmitir,
                                                                    csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)


                        Fm_Post.ModEmpresa_Doc = _Empresa
                        Fm_Post.ModModalidad_Doc = _Modalidad
                        'If Fm_Post.MensajeRevFolio.EsCorrecto Then
                        Dim _Msj_Limpiar As LsValiciones.Mensajes

                        _Msj_Limpiar = Fm_Post.Fx_Limpiar(_Modalidad)

                        If _Msj_Limpiar.EsCorrecto Then

                            Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)

                            _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False,
                                                                         csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento,
                                                                         True, False,,, False)

                            If CBool(_Msj_GrabarDoc.Id) Then
                                Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                            End If
                            Fm_Post.Dispose()

                        Else

                            Throw New System.Exception(_Msj_Limpiar.Mensaje)

                        End If

                        If Not _Msj_GrabarDoc.EsCorrecto Then 'Not CBool(_New_Idmaeedo) Then

                            _Mensaje.Mensaje = _Msj_GrabarDoc.Mensaje.Replace(vbCrLf, ". ")
                            _Mensaje.Mensaje = "No fue posible realizar la grabación de la Factura. " & _Mensaje.Mensaje

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " &
                                           "ProblemaFac = 1" &
                                           ",Log_Error = '" & _Mensaje.Mensaje & "'" & vbCrLf &
                                           "Where Id = " & _Id_Pickeo
                            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                            _Mensaje.Detalle = "Error al grabar documento"
                            Throw New System.Exception(_Mensaje.Mensaje)

                        End If

                        If _CerrarDespFact Then

                            Dim Cerrar_Doc As New Clas_Cerrar_Documento

                            Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo_Origen)

                            Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

                            If String.IsNullOrEmpty(_Sql.Pro_Error) Then

                                Dim _Tbl_Maeddo = _Ds.Tables(1)

                                If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo_Origen, _Tbl_Maeddo) Then

                                End If

                            End If

                        End If

                        Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Msj_GrabarDoc.Id
                        Dim _Row_Maeedo As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

                        _Tido = String.Empty
                        _Nudo = String.Empty

                        If Not IsNothing(_Row_Maeedo) Then

                            _Tido = _Row_Maeedo.Item("TIDO")
                            _Nudo = _Row_Maeedo.Item("NUDO")

                            Consulta_Sql = "Update " & _Global_BaseBk & "Zw_Stmp_Enc Set " &
                                           "Estado = 'FACTU'" &
                                           ",IdmaeedoGen = " & _Msj_GrabarDoc.Id &
                                           ",TidoGen = '" & _Tido &
                                           "',NudoGen = '" & _Nudo & "'" & vbCrLf &
                                           "Where Id = " & _Id_Pickeo
                            _Sql.Ej_consulta_IDU(Consulta_Sql, False)

                        End If

                        _Mensaje.EsCorrecto = True
                        _Mensaje.Id = _Msj_GrabarDoc.Id
                        _Mensaje.Fecha = FechaDelServidor()
                        _Mensaje.Mensaje = "Documento creado correctamente"
                        _Mensaje.Detalle = "Se crea el documento: " & _Tido & "-" & _Nudo
                        _Mensaje.Tag = _Row_Maeedo

                        'End If

                    Else

                        _Mensaje.Mensaje = "Documento cerrado"
                        Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")

                    End If

                    'End If
                End If

            Else

                _Mensaje.Mensaje = "Información"
                Throw New System.Exception("Debe configurar el formato de salida en la configuración por modalidad de trabajo")

            End If

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

    Function Fx_Crear_Documento_Desde_Otro_Automaticamente_DesdeNvvAuto(_Formulario As Form,
                                                                        _TidoDocEmitir As String,
                                                                        _Idmaeedo_Origen As Integer,
                                                                        _Fecha_Emision As DateTime,
                                                                        _Empresa As String,
                                                                        _Modalidad As String,
                                                                        _CerrarDespFact As Boolean) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            If _TidoDocEmitir <> "GDV" And _TidoDocEmitir <> "FCV" And _TidoDocEmitir <> "BLV" Then
                _Mensaje.Mensaje = "Error"
                Throw New System.Exception("El Tido Destino esta vacío o no corresponde: (" & _TidoDocEmitir & "), solo puede ser: BLV, FCV y GDV")
            End If

            Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)

            Dim _RowFormato As DataRow = Fx_Formato_Modalidad(_Formulario, _Empresa, _Modalidad, _TidoDocEmitir, False)

            If Not IsNothing(_RowFormato) Then

                Consulta_Sql = "Select * From MAEEDO Where IDMAEEDO = " & _Idmaeedo_Origen
                Dim _Row_Documento As DataRow = _Sql.Fx_Get_DataRow(Consulta_Sql, False)

                If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                    _Mensaje.Mensaje = "Error"
                    Throw New System.Exception(_Sql.Pro_Error)
                End If

                If Not IsNothing(_Row_Documento) Then

                    Dim _Meardo = _Row_Documento.Item("MEARDO")
                    Dim _Tido = _Row_Documento.Item("TIDO")
                    Dim _Nudo = _Row_Documento.Item("NUDO")

                    Dim _Msj_Tsc As LsValiciones.Mensajes

                    _Msj_Tsc = Fx_Revisar_Tasa_Cambio(Nothing,,, False)

                    If Not _Msj_Tsc.EsCorrecto Then

                        _Mensaje.ErrorDeConexionSQL = _Msj_Tsc.ErrorDeConexionSQL
                        Throw New System.Exception(_Msj_Tsc.Mensaje)

                    End If

                    Consulta_Sql = "SELECT IDMAEEDO FROM MAEDDO WHERE IDMAEEDO = " & _Idmaeedo_Origen & " AND ( ESLIDO<>'C' OR ESFALI='I' ) AND TICT = ''"

                    Dim _Tbl_Saldo_Facturar As DataTable = _Sql.Fx_Get_DataTable(Consulta_Sql, False)

                    If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                        _Mensaje.Mensaje = "Error"
                        Throw New System.Exception(_Sql.Pro_Error)
                    End If

                    If CBool(_Tbl_Saldo_Facturar.Rows.Count) Then

                        'Dim _Empresa As String = Mod_Empresa
                        Dim _Sucursal As String = Mod_Sucursal
                        Dim _Bodega As String = Mod_Bodega

                        Dim _Permiso = "Bo" & _Empresa & _Sucursal & _Bodega

                        If Not Fx_Tiene_Permiso(_Permiso, FUNCIONARIO) Then

                            Dim _Bod = _Global_Row_Configuracion_Estacion.Item("NOKOBO")

                            _Mensaje.Mensaje = "VALIDACION"
                            Throw New System.Exception("NO ESTA AUTORIZADO PARA EFECTUAR DOCUMENTOS DESDE LA BODEGA DE ESTA MODALIDAD" & vbCrLf & vbCrLf &
                                              "BODEGA: " & _Bodega & " - " & _Bod)

                        End If

                        If Fx_Tiene_Permiso(_Permiso, FUNCIONARIO) Then

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

                            Dim _Msj_GrabarDoc As New LsValiciones.Mensajes

                            Dim _Ds_Maeedo_Origen As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

                            If Not String.IsNullOrEmpty(_Sql.Pro_Error) Then
                                _Mensaje.Mensaje = "Error"
                                Throw New System.Exception(_Sql.Pro_Error)
                            End If

                            Dim Fm_Post As New Frm_Formulario_Documento(_TidoDocEmitir,
                                                                        csGlobales.Enum_Tipo_Documento.Venta, False,,,,,, True)

                            'If Fm_Post.MensajeRevFolio.EsCorrecto Then
                            Dim _Msj_Limpiar As LsValiciones.Mensajes

                            _Msj_Limpiar = Fm_Post.Fx_Limpiar(_Modalidad)

                            If _Msj_Limpiar.EsCorrecto Then

                                Fm_Post.Sb_Crear_Documento_Desde_Otros_Documentos(_Formulario, _Ds_Maeedo_Origen, False, False, _Fecha_Emision, False, True)

                                _Msj_GrabarDoc = Fm_Post.Fx_Grabar_Documento(False,
                                                                             csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_de_Grabacion.Nuevo_documento,
                                                                             True, False,,, False)

                                If CBool(_Msj_GrabarDoc.Id) Then
                                    Fm_Post.Sb_Activar_Orden_De_Despacho(_Msj_GrabarDoc.Id)
                                End If
                                Fm_Post.Dispose()
                            Else

                                Throw New System.Exception(_Msj_Limpiar.Mensaje)

                            End If

                            If Not _Msj_GrabarDoc.EsCorrecto Then 'Not CBool(_New_Idmaeedo) Then

                                _Mensaje.Mensaje = _Msj_GrabarDoc.Mensaje.Replace(vbCrLf, ". ")
                                _Mensaje.Mensaje = "No fue posible realizar la grabación de la Factura. " & _Mensaje.Mensaje
                                _Mensaje.Detalle = "Error al grabar documento"

                                Throw New System.Exception(_Mensaje.Mensaje)

                            End If

                            If _CerrarDespFact Then

                                Dim Cerrar_Doc As New Clas_Cerrar_Documento

                                Consulta_Sql = Replace(My.Resources.Recursos_Ver_Documento.Traer_Documento_Random, "#Idmaeedo#", _Idmaeedo_Origen)

                                Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_Sql, True, False)

                                If String.IsNullOrEmpty(_Sql.Pro_Error) Then

                                    Dim _Tbl_Maeddo = _Ds.Tables(1)

                                    If Cerrar_Doc.Fx_Cerrar_Documento(_Idmaeedo_Origen, _Tbl_Maeddo) Then

                                    End If

                                End If

                            End If

                            _Mensaje.EsCorrecto = True
                            _Mensaje.Id = _Msj_GrabarDoc.Id
                            _Mensaje.Fecha = FechaDelServidor()
                            _Mensaje.Mensaje = "Documento creado correctamente"
                            _Mensaje.Detalle = "Se crea el documento: " & _Tido & "-" & _Nudo

                        End If

                    Else

                        _Mensaje.Mensaje = "Documento cerrado"
                        Throw New System.Exception("Nota de venta Nro: " & _Nudo & " se encuentra cerrado completamente")

                    End If

                    'End If
                End If

            Else

                _Mensaje.Mensaje = "Información"
                Throw New System.Exception("Debe configurar el formato de salida en la configuración por modalidad de trabajo")

            End If

        Catch ex As Exception
            _Mensaje.Mensaje = ex.Message
        End Try

        Return _Mensaje

    End Function

End Class

'Public Class EstadoFacturacion

'    Public Property Facturada As Boolean
'    Public Property Idmaeedo_FCV As Integer
'    Public Property MensajeError As String
'    Public Property ErrorEnProceso As Boolean

'End Class
