Imports DevComponents.DotNetBar
'Imports Lib_Bakapp_VarClassFunc

Public Class Frm_Rotacion_Procesar_Productos


    Dim _SQL As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblPasoInforme, _TblPasoInformeMeses, _TblPasoInformeEstacional As String

    Dim _Consulta_Sql_Traer_Productos As String
    Dim _Consulta_Sql_Traer_Productos_Genericos As String
    Dim _Consulta_Sql_Ejecutar_proceso_Asis_compra As String
    Dim _Consulta_Sql_Inserta_Stock_por_producto As String

    'Dim _Fecha_Estudio_Desde, _Fecha_Estudio_Hasta As Date
    'Dim _Fecha_Estacional_Desde, _Fecha_Estacional_Hasta As Date

    Dim _Fecha_Desde As Date
    Dim _Fecha_Hasta As Date

    Dim _FechaInicioEstacional
    Dim _FechaTerminoEstacional

    Dim _Dias_Habiles As Integer
    Dim _Dias_Sabado As Integer
    Dim _Dias_Domingo As Integer
    Dim _Dias_Total As Integer

    Dim _Dias_Habiles_Estacional As Integer
    Dim _Dias_Sabado_Estacional As Integer
    Dim _Dias_Domingo_Estacional As Integer
    Dim _Dias_Total_Estacional As Integer

    Dim _Informe_Procesado As Boolean
    Dim _Cancelar As Boolean

    Dim _TblProductos_Madre As DataTable
    Dim _TblProductos As DataTable


    Dim _Empresa, _Sucursal, _Bodega As String
    Dim _Solo_Una_Bodega As Boolean

#Region "PROPIEDADES"

    Public Property Pro_TblProductos() As DataTable
        Get
            Return _TblProductos
        End Get
        Set(ByVal value As DataTable)
            _TblProductos = value
            Me.Text = "Informe Asistente de compras. Total productos: " & FormatNumber(_TblProductos.Rows.Count, 0)
        End Set
    End Property
    Public Property Pro_TblPasoInforme() As String
        Get
            Return _TblPasoInforme
        End Get
        Set(ByVal value As String)
            _TblPasoInforme = value
        End Set
    End Property
    Public Property Pro_TblPasoInformeMeses()
        Get
            Return _TblPasoInformeMeses
        End Get
        Set(ByVal value)
            _TblPasoInformeMeses = value
        End Set
    End Property
    Public Property Pro_TblPasoInformeEstacional()
        Get
            Return _TblPasoInformeEstacional
        End Get
        Set(ByVal value)
            _TblPasoInformeEstacional = value
        End Set
    End Property
    Public Property Pro_Consulta_Sql_Traer_Productos()
        Get
            Return _Consulta_Sql_Traer_Productos
        End Get
        Set(ByVal value)
            _Consulta_Sql_Traer_Productos = value
        End Set
    End Property
    Public Property Pro_Consulta_Sql_Traer_Productos_Genericos()
        Get
            Return _Consulta_Sql_Traer_Productos_Genericos
        End Get
        Set(ByVal value)
            _Consulta_Sql_Traer_Productos_Genericos = value
        End Set
    End Property
    Public Property Pro_Consulta_Sql_Ejecutar_proceso_Asis_compra()
        Get
            Return _Consulta_Sql_Ejecutar_proceso_Asis_compra
        End Get
        Set(ByVal value)
            _Consulta_Sql_Ejecutar_proceso_Asis_compra = value
        End Set
    End Property
    Public Property Pro_Consulta_Sql_Inserta_Stock_por_producto() As String
        Get
            Return _Consulta_Sql_Inserta_Stock_por_producto
        End Get
        Set(ByVal value As String)
            _Consulta_Sql_Inserta_Stock_por_producto = value
        End Set
    End Property

    Public Property Pro_Fecha_Estudio_Desde() As Date
        Get
            Return _Fecha_Desde
        End Get
        Set(ByVal value As Date)
            _Fecha_Desde = value
        End Set
    End Property
    Public Property Pro_Fecha_Estudio_Hasta() As Date
        Get
            Return _Fecha_Hasta
        End Get
        Set(ByVal value As Date)
            _Fecha_Hasta = value
        End Set
    End Property

    Public ReadOnly Property Pro_Informe_Procesado() As Boolean
        Get
            Return _Informe_Procesado
        End Get
    End Property

    Public Property Pro_TblProductos_Madre() As DataTable
        Get
            Return _TblProductos_Madre
        End Get
        Set(ByVal value As DataTable)
            _TblProductos_Madre = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal Empresa As String, _
                   ByVal Sucursal As String, _
                   ByVal Bodega As String, _
                   ByVal TblProductos As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Empresa = Empresa
        _Sucursal = Sucursal
        _Bodega = Bodega

        If _Bodega <> "" Then
            _Solo_Una_Bodega = True
        End If

        _TblProductos = TblProductos

    End Sub

    Private Sub Frm_06_AsisCompra_Procesar_Informe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Consulta_sql = "INSERT INTO " & _Global_BaseBk & "Zw_Prod_Rotacion (Codigo, Descripcion)" & vbCrLf & _
                      "SELECT KOPR,NOKOPR FROM MAEPR" & vbCrLf & _
                      "WHERE KOPR NOT IN (Select Codigo From " & _Global_BaseBk & "Zw_Prod_Rotacion)"
        _SQL.Ej_consulta_IDU(Consulta_sql)

        Lbl_Producto.Text = ""

        Btn_Cancelar.Enabled = False
        '_TblPasoInforme = "Zw_Prod_Rotacion"

    End Sub


    Function Fx_Generar_Informe() As Boolean

        Me.KeyPreview = False

        _Cancelar = False

        _Dias_Habiles = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        _Dias_Sabado = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Sabado)
        _Dias_Domingo = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Domingo)
        _Dias_Total = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Todos)

        Dim _Cl_Rotacion_Pr As New Clas_Rotacion_X_Productos(Chk_Incluir_Ventas_Entidades_Excluidas.Checked, _
                                                             _Dias_Habiles, _
                                                             _Dias_Sabado, _
                                                             _Dias_Domingo, _
                                                             _Dias_Total, _
                                                             _Fecha_Desde, _
                                                             _Fecha_Hasta)

        _Cl_Rotacion_Pr.Pro_Barra_Progreso = Barra_Progreso_Quiebres_Stock
        _Cl_Rotacion_Pr.Pro_Cancelar = _Cancelar
        _Cl_Rotacion_Pr.Pro_Progreso_Cont = Progreso_Cont
        _Cl_Rotacion_Pr.Pro_Progreso_Porc = Progreso_Porc
        _Cl_Rotacion_Pr.Pro_Log = Lbl_Producto
        ' incorporar el Label LOG

        Try

           Sb_Play_Stop(True)

            _Cl_Rotacion_Pr.Sb_AddToLog("Producto encontrados", _TblProductos.Rows.Count, TxtLog)
            _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Inicio de proceso", TxtLog)

            Dim _Contador As Integer = 0

            Dim _SqlQuery = String.Empty

            Dim _Con_Ent_Excluidas As Integer = CInt(Chk_Incluir_Ventas_Entidades_Excluidas.Checked) * -1

            Dim _Filtro_Productos_Estudio = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")
            Consulta_sql = "Update " & _TblPasoInforme & " Set Procesado = 0" & vbCrLf & _
                           "Where Codigo In " & _Filtro_Productos_Estudio & " And Con_Ent_Excluidas = " & _Con_Ent_Excluidas
            _SQL.Ej_consulta_IDU(Consulta_sql)


            For Each _Fila As DataRow In _TblProductos.Rows

                System.Windows.Forms.Application.DoEvents()
                'AddToLog("Producto", _Contador & " de " & FormatNumber(_TblProductos.Rows.Count, 0))
                Dim _Codigo As String = _Fila.Item("Codigo")


                _SqlQuery = String.Empty

                _SqlQuery = "Update " & _TblPasoInforme & " Set " & _
                            "Fecha_Nacimiento = '" & Format(FechaDelServidor, "yyyyMMdd") & "'," & vbCrLf & _
                            "Dias_Vida_Habiles = 0," & vbCrLf & _
                            "Dias_Vida_Domingos = 0," & vbCrLf & _
                            "Dias_Vida_Sabados = 0," & vbCrLf & _
                            "Dias_Vida_Total = 0," & vbCrLf & _
                            "Dias_Existencia_Habiles = 0," & vbCrLf & _
                            "Dias_Existencia_Sabados = 0," & vbCrLf & _
                            "Dias_Existencia_Domingos = 0," & vbCrLf & _
                            "Dias_Quiebre_Habiles = 0," & vbCrLf & _
                            "Dias_Quiebre_Sabados = 0," & vbCrLf & _
                            "Dias_Quiebre_Domingos = 0" & vbCrLf & _
                            "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf

                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = _TblProductos.Rows.Count


                Consulta_sql = "Select top 1 *," & _
                      "Isnull((Select top 1 NOKORU From TABRU Where KORU = RUPR),'') As Rubro," & _
                      "Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = MRPR),'') As Marca," & _
                      "Isnull((Select Top 1 NOKOZO From TABZO Where KOZO = ZONAPR),'') As Zona," & _
                      "Isnull((Select Top 1 NOKOFM From TABFM Where KOFM = FMPR),'') As Super_Familia," & _
                      "Isnull((Select Top 1 NOKOPF From TABPF Where KOFM = FMPR And KOPF = PFPR),'') As Familia," & _
                      "Isnull((Select Top 1 NOKOHF From TABHF Where KOFM = FMPR And KOPF = PFPR And KOHF = HFPR),'') As Sub_Familia," & _
                      "Isnull((Select Top 1 NOKOCARAC From TABCARAC Where KOTABLA = 'CLALIBPR' And KOCARAC = CLALIBPR),'') As Clasificacion_Libre" & vbCrLf & _
                      "From MAEPR Where KOPR = '" & _Codigo & "'"

                Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
                Dim _TblBodegas As DataTable

                If CBool(_Tbl.Rows.Count) Then

                    Dim _RowProducto As DataRow = _Tbl.Rows(0)
                    Dim _Descripcion = Trim(_RowProducto.Item("NOKOPR"))

                    ' _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo), _Descripcion & " Procesando...", _TxtLog)

                    'Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Stock_History Where Codigo = '" & _Codigo & "'"
                    '_SQL.Ej_consulta_IDU(Consulta_sql)

                    If _Solo_Una_Bodega Then
                        _SqlQuery += _Cl_Rotacion_Pr.Fx_Procesar_Informe_Por_Producto(_RowProducto, _
                                                                                      _Empresa, _Sucursal, _Bodega) & vbCrLf & vbCrLf
                    Else

                        Consulta_sql = "Select DISTINCT EMPRESA,SULIDO AS KOSU,BOSULIDO AS KOBO " & vbCrLf & _
                                       "From MAEDDO WHERE KOPRCT = '" & _Codigo & "'"

                        _TblBodegas = _SQL.Fx_Get_Tablas(Consulta_sql)

                        Consulta_sql = String.Empty


                        If CBool(_TblBodegas.Rows.Count) Then

                            For Each _Fila_Bo As DataRow In _TblBodegas.Rows

                                _Empresa = _Fila_Bo.Item("EMPRESA")
                                _Sucursal = _Fila_Bo.Item("KOSU")
                                _Bodega = _Fila_Bo.Item("KOBO")

                                _SqlQuery += _Cl_Rotacion_Pr.Fx_Procesar_Informe_Por_Producto(_RowProducto, _
                                                                                              _Empresa, _Sucursal, _Bodega) & vbCrLf & vbCrLf

                            Next

                        End If
                    End If

                    If String.IsNullOrEmpty(_SqlQuery) Then
                        _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo), _Descripcion & " No esta asociado a ninguna bodega", TxtLog)
                    Else
                        If _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                            _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo), _Descripcion & " OK", TxtLog)
                        End If
                    End If

                Else
                    _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo), "PROBLEMA!!", TxtLog)
                End If

                _Contador += 1
                Progreso_Porc.Value = ((_Contador * 100) / _TblProductos.Rows.Count)
                Progreso_Cont.Value += 1

                Consulta_sql = "Update " & _TblPasoInforme & " Set " & _
                               "Fecha_Fin = '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'," & vbCrLf & _
                               "Fecha_Ultima_Ejecucion = GetDate()," & vbCrLf & _
                               "RotDiariaUd1_Hab = round(case When SumTotalQtyUd1 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd1/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_y_Sab = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_y_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd1_Hab_Sab_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab = round(case When SumTotalQtyUd2 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd2/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_y_Sab = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_y_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "RotDiariaUd2_Hab_Sab_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                               "Procesado = 1" & vbCrLf & _
                               "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & " And Es_Asociador = 0"

                _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                If _Cancelar Then
                    _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Acción cancelada por el usuario", TxtLog)
                    'MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                    '                  "Ultimo producto procesado: " & _Codigo, "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)


                    Dim _MsCancelar = MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                                                  "¿Desea ver el Log del registro?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)

                    If _MsCancelar = Windows.Forms.DialogResult.Yes Then
                        Call Btn_Revisar_Log_Click(Nothing, Nothing)
                    End If

                    Return False
                End If

            Next

            Return True


        Catch ex As Exception
          
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            Sb_Play_Stop(False)

            Me.KeyPreview = True

        End Try
        Me.Refresh()
    End Function


    Sub Sb_Actualizar_Stock_History()

        Me.KeyPreview = False

        _Cancelar = False

        _Dias_Habiles = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Habiles) 'Fx_Dias_Habiles(_Fecha_Estudio_Desde, _Fecha_Estudio_Hasta)
        _Dias_Sabado = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Sabado)
        _Dias_Domingo = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Domingo)
        _Dias_Total = Fx_Cuenta_Dias(_Fecha_Desde, _Fecha_Hasta, Opcion_Dias.Todos)

        Dim _Cl_Rotacion_Pr As New Clas_Rotacion_X_Productos(Chk_Incluir_Ventas_Entidades_Excluidas.Checked, _
                                                             _Dias_Habiles, _
                                                             _Dias_Sabado, _
                                                             _Dias_Domingo, _
                                                             _Dias_Total, _
                                                             _Fecha_Desde, _
                                                             _Fecha_Hasta)

        _Cl_Rotacion_Pr.Pro_Barra_Progreso = Barra_Progreso_Quiebres_Stock
        _Cl_Rotacion_Pr.Pro_Cancelar = _Cancelar
        _Cl_Rotacion_Pr.Pro_Progreso_Cont = Progreso_Cont
        _Cl_Rotacion_Pr.Pro_Progreso_Porc = Progreso_Porc
        _Cl_Rotacion_Pr.Pro_Log = Lbl_Producto
        ' incorporar el Label LOG

        Try

            Sb_Play_Stop(True)

            _Cl_Rotacion_Pr.Sb_AddToLog("Producto encontrados", _TblProductos.Rows.Count, TxtLog)
            _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Inicio de proceso", TxtLog)

            Dim _Contador As Integer = 0

            Dim _SqlQuery = String.Empty

            Dim _Con_Ent_Excluidas As Integer = CInt(Chk_Incluir_Ventas_Entidades_Excluidas.Checked) * -1


            Dim _FlProductos As String = Generar_Filtro_IN(_TblProductos, "", "Codigo", False, False, "'")

            Consulta_sql = "SELECT KOPR As Codigo FROM MAEPR WHERE KOPR IN" & vbCrLf & _
                           "(Select Distinct KOPRCT As Codigo From MAEDDO Where KOPRCT In " & _FlProductos & Space(1) & _
                           "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' And TIDO NOT IN ('OCC','NVV','NVI','OCI','COV'))"
            Dim _Tbl_ConMovimientos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

            Consulta_sql = "SELECT KOPR As Codigo FROM MAEPR WHERE KOPR NOT IN" & vbCrLf & _
                            "(Select Distinct KOPRCT As Codigo From MAEDDO Where KOPRCT In " & _FlProductos & Space(1) & _
                            "And FEEMLI BETWEEN '" & Format(_Fecha_Desde, "yyyyMMdd") & "' And '" & Format(_Fecha_Hasta, "yyyyMMdd") & "' And TIDO NOT IN ('OCC','NVV','NVI','OCI','COV'))" & vbCrLf & _
                            "AND KOPR IN " & _FlProductos
            Dim _Tbl_SinMovimientos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

            If CBool(_Tbl_SinMovimientos.Rows.Count) Then
                _FlProductos = Generar_Filtro_IN(_Tbl_SinMovimientos, "", "Codigo", False, False, "'")
                Consulta_sql = "Delete " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Where Codigo In " & _FlProductos & vbCrLf & _
                               "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History (Codigo,Fecha_Desde) " & vbCrLf & _
                               "Select KOPR,'" & Format(_Fecha_Desde, "yyyyMMdd") & "' From MAEPR Where KOPR In " & _FlProductos
                _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)
            End If

            _TblProductos = _Tbl_ConMovimientos

            For Each _Fila As DataRow In _TblProductos.Rows

                System.Windows.Forms.Application.DoEvents()
                'AddToLog("Producto", _Contador & " de " & FormatNumber(_TblProductos.Rows.Count, 0))
                Dim _Codigo As String = _Fila.Item("Codigo")


                Progreso_Porc.Maximum = 100
                Progreso_Cont.Maximum = _TblProductos.Rows.Count

                Consulta_sql = "Select top 1 *," & _
                      "Isnull((Select top 1 NOKORU From TABRU Where KORU = RUPR),'') As Rubro," & _
                      "Isnull((Select Top 1 NOKOMR From TABMR Where KOMR = MRPR),'') As Marca," & _
                      "Isnull((Select Top 1 NOKOZO From TABZO Where KOZO = ZONAPR),'') As Zona," & _
                      "Isnull((Select Top 1 NOKOFM From TABFM Where KOFM = FMPR),'') As Super_Familia," & _
                      "Isnull((Select Top 1 NOKOPF From TABPF Where KOFM = FMPR And KOPF = PFPR),'') As Familia," & _
                      "Isnull((Select Top 1 NOKOHF From TABHF Where KOFM = FMPR And KOPF = PFPR And KOHF = HFPR),'') As Sub_Familia," & _
                      "Isnull((Select Top 1 NOKOCARAC From TABCARAC Where KOTABLA = 'CLALIBPR' And KOCARAC = CLALIBPR),'') As Clasificacion_Libre" & vbCrLf & _
                      "From MAEPR Where KOPR = '" & _Codigo & "'"

                Dim _Tbl As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)
                Dim _TblBodegas As DataTable

                If CBool(_Tbl.Rows.Count) Then

                    Dim _RowProducto As DataRow = _Tbl.Rows(0)
                    Dim _Descripcion = Trim(_RowProducto.Item("NOKOPR"))


                    Consulta_sql = "Select DISTINCT EMPRESA,SULIDO AS KOSU,BOSULIDO AS KOBO " & vbCrLf & _
                                   "From MAEDDO WHERE KOPRCT = '" & _Codigo & "'"

                    _TblBodegas = _SQL.Fx_Get_Tablas(Consulta_sql)
                    Consulta_sql = String.Empty


                    Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Where Codigo = '" & _Codigo & "'"
                    Dim _Row_Zw_Prod_Stock_Enc_History As DataRow = _SQL.Fx_Get_DataRow(Consulta_sql)

                    Dim _Fecha_Ult_Revision As Date

                    If _Row_Zw_Prod_Stock_Enc_History Is Nothing Then
                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History (Codigo,Fecha_Desde) Values ('" & _Codigo & "','" & Format(_Fecha_Desde, "yyyyMMdd") & "')"
                        _SQL.Ej_consulta_IDU(Consulta_sql)
                        _Fecha_Ult_Revision = DateAdd(DateInterval.Day, -1, FechaDelServidor)
                    Else
                        _Fecha_Ult_Revision = _Row_Zw_Prod_Stock_Enc_History.Item("Fecha_Ult_Revision")
                    End If

                    If FormatDateTime(_Fecha_Ult_Revision, DateFormat.ShortDate) < FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then


                        If CBool(_TblBodegas.Rows.Count) Then

                            For Each _Fila_Bo As DataRow In _TblBodegas.Rows

                                _Empresa = _Fila_Bo.Item("EMPRESA")
                                _Sucursal = _Fila_Bo.Item("KOSU")
                                _Bodega = _Fila_Bo.Item("KOBO")

                                Dim _sqlqry = String.Empty

                                Consulta_sql = "Select Top 1 * From " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
                                               "Where Codigo = '" & _Codigo & "'" & Space(1) & _
                                               "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "' And Bodega = '" & _Bodega & "'" & vbCrLf & _
                                               "Order by Fecha_Stock Desc"
                                Dim _Row As DataRow = _SQL.Fx_Get_DataRow(Consulta_sql)

                                Dim _Ejecutar As Boolean

                                If Not (_Row Is Nothing) Then

                                    If FormatDateTime(_Fecha_Ult_Revision, DateFormat.ShortDate) <> FormatDateTime(FechaDelServidor(), DateFormat.ShortDate) Then
                                        _Ejecutar = True
                                    Else
                                        _Ejecutar = False
                                    End If

                                Else
                                    _Ejecutar = True
                                End If

                                If _Ejecutar Then
                                    _Cl_Rotacion_Pr.Fx_Dias_Existencia_Stock_En_Bodega(_Codigo, _
                                                                                       _Descripcion, _
                                                                                       _Empresa, _
                                                                                       _Sucursal, _
                                                                                       _Bodega, _
                                                                                       _Fecha_Desde, _
                                                                                       _Fecha_Hasta, _
                                                                                       _Row, _
                                                                                       _Fecha_Ult_Revision)
                                End If

                            Next

                            Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Stock_Enc_History Set Fecha_Ult_Revision = Getdate()" & vbCrLf & _
                                           "Where Codigo = '" & _Codigo & "'"
                            _SQL.Ej_consulta_IDU(Consulta_sql)

                        End If

                    End If

                    _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo), _Descripcion & " OK", TxtLog)

                End If



                _Contador += 1
                Progreso_Porc.Value = ((_Contador * 100) / _TblProductos.Rows.Count)
                Progreso_Cont.Value += 1

                If _Cancelar Then
                    _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Acción cancelada por el usuario", TxtLog)
                    'MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                    '                  "Ultimo producto procesado: " & _Codigo, "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Stop)


                    Dim _MsCancelar = MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                                                  "¿Desea ver el Log del registro?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)

                    If _MsCancelar = Windows.Forms.DialogResult.Yes Then
                        Call Btn_Revisar_Log_Click(Nothing, Nothing)
                    End If
                    Exit For
                End If

            Next


        Catch ex As Exception

            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            Sb_Play_Stop(False)

            Me.KeyPreview = True

        End Try
        Me.Refresh()
    End Sub

    Private Function Fx_Dias_Existencia_Stock_En_Bodega_Old(ByVal _RowProducto As DataRow, _
                                                            ByVal _Empresa As String, _
                                                            ByVal _Sucursal As String, _
                                                            ByVal _Bodega As String, _
                                                            ByVal _Fecha_Desde As Date, _
                                                            ByVal _Fecha_Hasta As Date) As String

        Dim _Codigo = _RowProducto.Item("KOPR")
        'Dim _Descripcion = _RowProducto.Item("NOKOPR")

        Dim _SqlQuery = String.Empty


        Dim _Dias = DateDiff(DateInterval.Day, _Fecha_Desde, _Fecha_Hasta)
        Dim _Fecha As Date = FormatDateTime(_Fecha_Desde, DateFormat.ShortDate)

        Barra_Progreso_Quiebres_Stock.Value = 0
        Barra_Progreso_Quiebres_Stock.Maximum = _Dias

        Consulta_sql = "Select Distinct FEEMLI From MAEDDO" & vbCrLf & _
                       "Where EMPRESA = '" & _Empresa & "' AND SULIDO = '" & _Sucursal & "' And BOSULIDO = '" & _Bodega & "'" & Space(1) & _
                       "And KOPRCT = '" & _Codigo & "' And" & Space(1) & _
                       "FEEMLI between '" & _Fecha_Desde & "' And '" & _Fecha_Hasta & "'"

        Dim _Tbl_Movimientos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

        Dim _Dias_Movimiento As Integer = _Tbl_Movimientos.Rows.Count
        Dim _Contador_Dias_Movimiento = 0
        Dim _Feemli As Date


        Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

        Dim _Fecha_Revision As Date = DateAdd(DateInterval.Day, -1, _Fecha_Desde)

        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
        Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

        Dim _Row_Stock As DataRow = _SQL.Fx_Get_DataRow(Consulta_sql)

        Dim _StockUd1 As Double = _Row_Stock.Item("StockUd1")
        Dim _StockUd2 As Double = _Row_Stock.Item("StockUd2")

        Dim _Dias_Existencia_Habiles = 0
        Dim _Dias_Existencia_Sabados = 0
        Dim _Dias_Existencia_Domingos = 0

        Dim _Dias_Quiebre_Habiles = 0
        Dim _Dias_Quiebre_Sabados = 0
        Dim _Dias_Quiebre_Domingos = 0

        If CBool(_Dias_Movimiento) Then

            _Feemli = FormatDateTime(_Tbl_Movimientos.Rows(0).Item("FEEMLI"), DateFormat.ShortDate)

            For i = 1 To _Dias

                System.Windows.Forms.Application.DoEvents()

                If _Fecha = _Feemli Then

                    _Fecha_Revision = DateAdd(DateInterval.Day, -1, _Fecha)

                    Consulta_sql = My.Resources.Recursos_Asis_Compras.SQLQuery_Saber_Stock_a_una_fecha_X_Producto

                    Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                    Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                    Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                    Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
                    Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha_Revision, "yyyyMMdd"))
                    Consulta_sql = Replace(Consulta_sql, "#Int#", 1)

                    _Row_Stock = _SQL.Fx_Get_DataRow(Consulta_sql)

                    _StockUd1 = _Row_Stock.Item("StockUd1")
                    _StockUd2 = _Row_Stock.Item("StockUd2")

                    _Contador_Dias_Movimiento += 1
                    If _Contador_Dias_Movimiento < _Dias_Movimiento Then
                        _Feemli = _Tbl_Movimientos.Rows(_Contador_Dias_Movimiento).Item("FEEMLI")
                    End If

                End If

                'Lbl_Revisando_Quiebres_De_Stock.Text = "Revisando Historia Stock Bodega: " & _Bodega & ", Fecha: " & FormatDateTime(_Fecha, DateFormat.ShortDate)
                Barra_Progreso_Quiebres_Stock.Text = i

                Dim _Dia = Weekday(_Fecha)

                Dim _Hubo_Stock As Boolean

                If _StockUd1 > 0 Then
                    _Hubo_Stock = True
                Else
                    Dim _Feemli_st = "'" & Format(_Fecha, "yyyyMMdd") & "'"
                    Dim _Reg As Boolean = CBool(_SQL.Fx_Cuenta_Registros("MAEDDO", _
                                          "TIDO In ('FCV','GDV','BLV','FDV')" & Space(1) & _
                                          "And KOPRCT = '" & _Codigo & "' And FEEMLI = " & _Feemli_st))
                    _Hubo_Stock = _Reg
                End If

                Select Case _Dia
                    Case 1
                        '_Dia_Domingo = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Domingos += 1
                        Else
                            If CBool(_Dias_Existencia_Domingos) Then _Dias_Quiebre_Domingos += 1
                        End If
                    Case 7
                        '_Dia_Sabado = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Sabados += 1
                        Else
                            If CBool(_Dias_Existencia_Sabados) Then _Dias_Quiebre_Sabados += 1
                        End If
                    Case Else
                        '_Dia_Habil = 1
                        If _Hubo_Stock Then
                            _Dias_Existencia_Habiles += 1
                        Else
                            If CBool(_Dias_Existencia_Habiles) Then _Dias_Quiebre_Habiles += 1
                        End If
                End Select

                Dim _Fecha_Stock = Format(_Fecha, "yyyyMMdd")

                _Fecha = DateAdd(DateInterval.Day, 1, _Fecha)

                Barra_Progreso_Quiebres_Stock.Value = i

            Next

        End If

        Dim _Con_Ent_Excluidas As Integer = CInt(Chk_Incluir_Ventas_Entidades_Excluidas.Checked) * -1

        _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
                     "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
                     "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
                     "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
                     "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & vbCrLf & _
                     "Where Codigo = '" & _Codigo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                     "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                     "And Bodega = '" & _Bodega & "'" & vbCrLf

        'Next
        'Lbl_Revisando_Quiebres_De_Stock.Text = String.Empty
        Barra_Progreso_Quiebres_Stock.Text = String.Empty
        Return _SqlQuery

    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Btn_Cancelar.Enabled = False
        _Cancelar = True
    End Sub

    Private Sub Frm_06_AsisCompra_Procesar_Informe_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar.Click

        _Informe_Procesado = Fx_Generar_Informe()

        'Sb_Actualizar_Stock_History()
        
        If _Informe_Procesado Then
            'Fx_Calcular_Rotacion_X_Asociacion()
            MessageBoxEx.Show(Me, "Datos actualizados correctamente", "Procesar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Procesar_Asociados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Procesar_Asociados.Click

        If Num_X_Dias.Value = 0 Then
            If MessageBoxEx.Show(Me, "¿Confirma días de rotación ""cero""?", "Rotación mínima", _
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                Return
            End If
        End If

        Fx_Calcular_Rotacion_X_Asociacion()

    End Sub

    Function Fx_Calcular_Rotacion_X_Asociacion() As Boolean

        Me.KeyPreview = False


        Dim _Cl_Rotacion_Pr As New Clas_Rotacion_X_Productos(Chk_Incluir_Ventas_Entidades_Excluidas.Checked, _
                                                             _Dias_Habiles, _
                                                             _Dias_Sabado, _
                                                             _Dias_Domingo, _
                                                             _Dias_Total, _
                                                             _Fecha_Desde, _
                                                             _Fecha_Hasta)

        _Cl_Rotacion_Pr.Pro_Barra_Progreso = Barra_Progreso_Quiebres_Stock
        _Cl_Rotacion_Pr.Pro_Cancelar = _Cancelar
        _Cl_Rotacion_Pr.Pro_Progreso_Cont = Progreso_Cont
        _Cl_Rotacion_Pr.Pro_Progreso_Porc = Progreso_Porc

        Dim _Con_Ent_Excluidas As Integer = CInt(Chk_Incluir_Ventas_Entidades_Excluidas.Checked) * -1

       

     
        Consulta_sql = "Update " & _Global_BaseBk & "Zw_Prod_Stock_History Set Codigo_Nodo_Madre = Isnull((Select Top 1 Codigo_Nodo From " & vbCrLf & "Zw_Prod_Asociacion Z2" & vbCrLf & _
                        "Where Para_filtro = 1 And Codigo_Nodo In (Select Codigo_Nodo From " & _Global_BaseBk & "Zw_TblArbol_Asociaciones Where Nodo_Raiz =121617 ) And Z2.Codigo = Z1.Codigo),0)" & vbCrLf & _
                        "From " & _Global_BaseBk & "Zw_Prod_Stock_History Z1"
        _SQL.Ej_consulta_IDU(Consulta_sql)


        Dim _Tbl_Productos_Estudio = _TblProductos_Madre

        Try

            Sb_Play_Stop(True)

            _Cl_Rotacion_Pr.Sb_AddToLog("", "", _TxtLog)
            '_Cl_Rotacion_Pr.Sb_AddToLog("", "***************************************************************************", _TxtLog)
            _Cl_Rotacion_Pr.Sb_AddToLog("", "PROCESO DE ESTUDIO DE DIAS CON STOCK EN BODEGA Y LOS QUIEBRES DE STOCK POR ASOCIACION", _TxtLog)
            '_Cl_Rotacion_Pr.Sb_AddToLog("", "***************************************************************************", _TxtLog)
            _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Fecha Desde: " & FormatDateTime(_Fecha_Desde, DateFormat.ShortDate) & " Hasta: " & FormatDateTime(_Fecha_Hasta), _TxtLog)

            Dim _Meses_Estudio = DateDiff(DateInterval.Month, _Fecha_Hasta, _Fecha_Desde)

            _Cl_Rotacion_Pr.Sb_AddToLog("Producto encontrados", _Tbl_Productos_Estudio.Rows.Count, TxtLog)
            _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Inicio de proceso", TxtLog)
            _Cl_Rotacion_Pr.Pro_Log = Lbl_Producto

            Dim _Contador As Integer = 0

            Dim _SqlQuery = String.Empty

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Tbl_Productos_Estudio.Rows.Count

            If CBool(_Tbl_Productos_Estudio.Rows.Count) Then
                Dim _Filtro_Productos_Estudio = Generar_Filtro_IN(_Tbl_Productos_Estudio, "", "Codigo", False, False, "'")
                Consulta_sql = "Update " & _TblPasoInforme & " Set Procesado = 0" & vbCrLf & _
                               "Where Codigo In " & _Filtro_Productos_Estudio & " And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & " And Es_Asociador = 1"
                _SQL.Ej_consulta_IDU(Consulta_sql)
            End If

            For Each _Fila As DataRow In _Tbl_Productos_Estudio.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo_Nodo = _Fila.Item("Codigo")

                _SqlQuery = String.Empty

                _Contador += 1
                Progreso_Porc.Value = ((_Contador * 100) / _Tbl_Productos_Estudio.Rows.Count) 'Mas
                Progreso_Cont.Value += 1


                Dim _Filtro_Prod_Hermanos As String
                Dim _Tbl_Productos_Hermanos As DataTable

                ' PRODUCTOS ASOCIADOS POR CARPETAS
                If True Then 'Rdb_Aso_Tbl_Asociacion.Checked Then
                    Consulta_sql = "Select KOPR,NOKOPR From MAEPR Where KOPR IN (" & vbCrLf & _
                                   "Select Codigo" & Space(1) & _
                                   "From " & _Global_BaseBk & "Zw_Prod_Asociacion" & Space(1) & _
                                   "Where Codigo_Nodo = '" & _Codigo_Nodo & "')"
                    'ElseIf Rdb_Aso_Reemplazo.Checked Then
                    '    Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo_Rev & "'" & vbCrLf & vbCrLf & _
                    '                   "UNION" & vbCrLf & _
                    '                   "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo_Rev & "' AND KOPR <> '" & _Codigo_Rev & "'"
                End If


                Dim _TblProductos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

                Dim _Tbl_Productos_Asociados As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)

                Dim _Filtro_Prod_Asoc = Generar_Filtro_IN(_Tbl_Productos_Asociados, "", "KOPR", False, False, "'")


                Dim _TblBodegas As DataTable


                If CBool(_Tbl_Productos_Asociados.Rows.Count) Then

                    Consulta_sql = "Select Top 1 * From " & _TblPasoInforme & vbCrLf & _
                                   "Where Codigo = '" & _Codigo_Nodo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & " And Es_Asociador = 1"
                    Dim _Row_Producto As DataRow = _SQL.Fx_Get_DataRow(Consulta_sql)

                    Dim _Procesado As Boolean = _Row_Producto.Item("Procesado")
                    Dim _Descripcion = _SQL.Fx_Trae_Dato(_Global_BaseBk & "Zw_TblArbol_Asociaciones", "Descripcion", "Codigo_Nodo = " & _Codigo_Nodo) ' "1" 'Trim(NuloPorNro(_Fila.Item("Descripcion"), ""))

                    If Not _Procesado Then

                        _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " Procesando...", TxtLog)

                        Consulta_sql = "Select DISTINCT EMPRESA,SULIDO AS KOSU,BOSULIDO AS KOBO " & vbCrLf & _
                                       "From MAEDDO WHERE KOPRCT In " & _Filtro_Prod_Asoc
                        _TblBodegas = _SQL.Fx_Get_Tablas(Consulta_sql)

                        If CBool(_TblBodegas.Rows.Count) Then

                            For Each _Fila_Bo As DataRow In _TblBodegas.Rows

                                _Empresa = _Fila_Bo.Item("EMPRESA")
                                _Sucursal = _Fila_Bo.Item("KOSU")
                                _Bodega = _Fila_Bo.Item("KOBO")

                                Consulta_sql = "Select Top 1 * From " & _TblPasoInforme & vbCrLf & _
                                               "Where Codigo = '" & _Codigo_Nodo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas
                                Dim _Campo_Rotacion = "RotDiariaUd1_Hab"

                                Dim _Row_Rotacion As DataRow = _SQL.Fx_Get_DataRow(Consulta_sql)
                                Dim _Rotacion As Double = _Row_Rotacion.Item("RotDiariaUd1_Hab")

                                Dim _Stock_Minimo As Double = Num_X_Dias.Value 'Math.Round(_Rotacion * Num_X_Dias.Value, 2)

                                Consulta_sql = "Select Distinct Codigo_Nodo_Madre,Fecha_Quiebre," & vbCrLf & _
                                               "Sum(StockUd1) as StockUd1," & vbCrLf & _
                                               "Cast(Dia_Habil As Int) As Dia_Habil," & vbCrLf & _
                                               "Cast(Dia_Sabado As Int) As Dia_Sabado," & vbCrLf & _
                                               "Cast(Dia_Domingo As Int) As Dia_Domingo" & vbCrLf & _
                                               "Into #Paso" & vbCrLf & _
                                               "From " & _Global_BaseBk & "Zw_Prod_Stock_History" & vbCrLf & _
                                               "Where Empresa = '" & _Empresa & "'" & Space(1) & _
                                               "And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                                               "And Bodega = '" & _Bodega & "' And Codigo_Nodo_Madre = '" & _Codigo_Nodo & "'" & vbCrLf & _
                                               "Group by Codigo_Nodo_Madre,Fecha_Quiebre,Dia_Habil,Dia_Sabado,Dia_Domingo" & vbCrLf & _
                                               "Select 'Total' As Estado,Sum(Dia_Habil) As Dia_Habil,Sum(Dia_Sabado) As Dia_Sabado,Sum(Dia_Domingo) As Dia_Domingo" & vbCrLf & _
                                               "From #Paso" & vbCrLf & _
                                               "Group by Codigo_Nodo_Madre" & vbCrLf & _
                                               "--Union" & vbCrLf & _
                                               "Select 'Stock' As Estado,Sum(Dia_Habil) As Dia_Habil,Sum(Dia_Sabado) As Dia_Sabado,Sum(Dia_Domingo) As Dia_Domingo" & vbCrLf & _
                                               "From #Paso" & vbCrLf & _
                                               "Where StockUd1 > 0" & vbCrLf & _
                                               "Group by Codigo_Nodo_Madre" & vbCrLf & _
                                               "--Union" & vbCrLf & _
                                               "Select 'Quiebres' As Estado,Sum(Dia_Habil) As Dia_Habil,Sum(Dia_Sabado) As Dia_Sabado,Sum(Dia_Domingo) As Dia_Domingo" & vbCrLf & _
                                               "From #Paso" & vbCrLf & _
                                               "Where StockUd1 <= 0" & vbCrLf & _
                                               "Group by Codigo_Nodo_Madre " & vbCrLf & _
                                               "Drop table #Paso"

                                Dim _Ds_Historia As DataSet = _SQL.Fx_Get_DataSet(Consulta_sql)

                                Dim _Dias_Existencia_Habiles
                                Dim _Dias_Existencia_Sabados
                                Dim _Dias_Existencia_Domingos

                                Dim _Dias_Quiebre_Habiles
                                Dim _Dias_Quiebre_Sabados
                                Dim _Dias_Quiebre_Domingos

                                If CBool(_Ds_Historia.Tables(1).Rows.Count) Then
                                    _Dias_Existencia_Habiles = _Ds_Historia.Tables(0).Rows(0).Item("Dia_Habil")
                                    _Dias_Existencia_Sabados = _Ds_Historia.Tables(0).Rows(0).Item("Dia_Sabado")
                                    _Dias_Existencia_Domingos = _Ds_Historia.Tables(0).Rows(0).Item("Dia_Domingo")
                                End If

                                If CBool(_Ds_Historia.Tables(2).Rows.Count) Then
                                    _Dias_Quiebre_Habiles = _Ds_Historia.Tables(1).Rows(0).Item("Dia_Habil")
                                    _Dias_Quiebre_Sabados = _Ds_Historia.Tables(1).Rows(0).Item("Dia_Sabado")
                                    _Dias_Quiebre_Domingos = _Ds_Historia.Tables(1).Rows(0).Item("Dia_Domingo")
                                End If

                                _SqlQuery += "Update " & _Global_BaseBk & "Zw_Prod_Rotacion Set" & vbCrLf & _
                                             "Dias_Existencia_Habiles = " & De_Num_a_Tx_01(_Dias_Existencia_Habiles, True) & "," & vbCrLf & _
                                             "Dias_Existencia_Sabados = " & De_Num_a_Tx_01(_Dias_Existencia_Sabados, True) & "," & vbCrLf & _
                                             "Dias_Existencia_Domingos = " & De_Num_a_Tx_01(_Dias_Existencia_Domingos, True) & "," & vbCrLf & _
                                             "Dias_Quiebre_Habiles = " & De_Num_a_Tx_01(_Dias_Quiebre_Habiles, True) & "," & vbCrLf & _
                                             "Dias_Quiebre_Sabados = " & De_Num_a_Tx_01(_Dias_Quiebre_Sabados, True) & "," & vbCrLf & _
                                             "Dias_Quiebre_Domingos = " & De_Num_a_Tx_01(_Dias_Quiebre_Domingos, True) & vbCrLf & _
                                             "Where Codigo = '" & _Codigo_Nodo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & vbCrLf & _
                                             "And Empresa = '" & _Empresa & "' And Sucursal = '" & _Sucursal & "'" & Space(1) & _
                                             "And Bodega = '" & _Bodega & "'" & vbCrLf

                                '_SqlQuery += _Cl_Rotacion_Pr.Fx_Dias_Existencia_Stock_En_Bodega(_Codigo_Rev, _
                                '                                                                _Tbl_Productos_Asociados, _
                                '                                                                _Empresa, _
                                '                                                                _Sucursal, _
                                '                                                                _Bodega, _
                                '                                                                _Stock_Minimo, True) & vbCrLf & vbCrLf




                            Next

                        End If


                        If String.IsNullOrEmpty(_SqlQuery) Then
                            _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " No está asociado a ninguna bodega", TxtLog)
                        Else
                            If _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery) Then
                                _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " OK", TxtLog)
                            Else
                                _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " Error: " & _SQL.Pro_Error, TxtLog)
                            End If
                        End If

                       
                        Consulta_sql = "Update " & _TblPasoInforme & " Set " & _
                                       "Fecha_Inicio = '" & Format(_Fecha_Desde, "yyyyMMdd") & "'," & vbCrLf & _
                                       "Fecha_Fin = '" & Format(_Fecha_Hasta, "yyyyMMdd") & "'," & vbCrLf & _
                                       "Fecha_Ultima_Ejecucion = GetDate()," & vbCrLf & _
                                       "RotDiariaUd1_Hab = round(case When SumTotalQtyUd1 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd1/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd1_Hab_y_Sab = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd1_Hab_y_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd1_Hab_Sab_Dom = round(case When SumTotalQtyUd1 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd1/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd2_Hab = round(case When SumTotalQtyUd2 > 0 and Dias_Existencia_Habiles > 0 then SumTotalQtyUd2/Dias_Existencia_Habiles else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd2_Hab_y_Sab = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados) else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd2_Hab_y_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                                       "RotDiariaUd2_Hab_Sab_Dom = round(case When SumTotalQtyUd2 > 0 and (Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) > 0 then SumTotalQtyUd2/(Dias_Existencia_Habiles+Dias_Existencia_Sabados+Dias_Existencia_Domingos) else 0 end,5)," & vbCrLf & _
                                       "Procesado = 1" & vbCrLf & _
                                       "Where Codigo = '" & _Codigo_Nodo & "' And Con_Ent_Excluidas = " & _Con_Ent_Excluidas & " And Es_Asociador = 1"


                        If Not _SQL.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql) Then
                            _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " Error: " & _SQL.Pro_Error, TxtLog)
                        End If


                    Else
                        _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), _Descripcion & " Procesando...", TxtLog)
                    End If

                Else
                    _Cl_Rotacion_Pr.Sb_AddToLog(Trim(_Codigo_Nodo), "PROBLEMA!!", TxtLog)
                End If


                If _Cancelar Then
                    _Cl_Rotacion_Pr.Sb_AddToLog("Proceso", "Acción cancelada por el usuario", TxtLog)
                    Dim _MsCancelar = MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf & _
                                       "Ultimo producto procesado: " & _Codigo_Nodo & vbCrLf & vbCrLf & _
                                       "¿Desea ver el Log del registro?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)

                    If _MsCancelar = Windows.Forms.DialogResult.Yes Then
                        Call Btn_Revisar_Log_Click(Nothing, Nothing)
                    End If

                    Return False

                End If

            Next

            MessageBoxEx.Show(Me, "FIN DEL PROCESO", _
                                  "PROCESAR ROTACION", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True


        Catch ex As Exception
            'MsgBox(ex.Message)
            'myTrans.Rollback()
            MessageBoxEx.Show(Me, ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

            Sb_Play_Stop(False)
            Me.KeyPreview = True

        End Try

            Me.Refresh()

    End Function

    Private Sub Btn_Revisar_Log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Revisar_Log.Click

        Dim Fm As New Frm_Archivo_TXT
        Fm.Pro_Nombre_Archivo = "Log_Calc_Rotacion.txt"
        Fm.Pro_Texto_Log = TxtLog.Text
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub


    Sub Sb_Play_Stop(ByVal _Play As Boolean)

        If _Play Then _Cancelar = False

        Btn_Procesar.Enabled = Not _Play
        Me.ControlBox = Not _Play
        Btn_Revisar_Log.Enabled = Not _Play
        Btn_Procesar_Asociados.Enabled = Not _Play
        Btn_Cancelar.Enabled = Not _Play

        Progreso_Porc.Value = 0
        Progreso_Cont.Value = 0
        Barra_Progreso_Quiebres_Stock.Value = 0

    End Sub

End Class