Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.SqlClient

Public Class Frm_InvParc_06_ProcesarDatos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos As DataTable

    Dim _Row_GDI_Ajuste_Cero As DataRow
    Dim _Row_GRI_Ajuste_Cero As DataRow
    Dim _Row_GRI_Ajuste_Definitivo As DataRow

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String

    Dim _Datos_Procesados As Boolean

    Dim _Ajuste_PM As Boolean
    Dim _Row_InvParcial_Inventarios As DataRow

    Enum TipoGrabacion
        Con_Numeración = 0
        EnBlanco = 1
        Puros_Ceros = 2
    End Enum

    Public ReadOnly Property Pro_Row_GDI_Ajuste_Cero() As DataRow
        Get
            Return _Row_GDI_Ajuste_Cero
        End Get
    End Property
    Public ReadOnly Property Pro_Row_GRI_Ajuste_Cero() As DataRow
        Get
            Return _Row_GRI_Ajuste_Cero
        End Get
    End Property
    Public ReadOnly Property Pro_Row_GRI_Ajuste_Definitivo() As DataRow
        Get
            Return _Row_GRI_Ajuste_Definitivo
        End Get
    End Property
    Public ReadOnly Property Pro_Datos_Procesados() As Boolean
        Get
            Return _Datos_Procesados
        End Get
    End Property

    Public Sub New(ByVal Row_InvParcial_Inventarios As DataRow,
                   ByVal Tbl_Productos As DataTable,
                   ByVal Fecha_Ajuste As Date,
                   ByVal Ajuste_PM As Boolean,
                   ByVal Dejar_Doc_Final_Del_Dia As Boolean)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_InvParcial_Inventarios = Row_InvParcial_Inventarios
        _Tbl_Productos = Tbl_Productos
        DtFechaInv.Value = Fecha_Ajuste
        _Ajuste_PM = Ajuste_PM

        Chk_Dejar_Doc_Final_Del_Dia.Checked = Dejar_Doc_Final_Del_Dia

    End Sub

    Private Sub Frm_InvParc_06_ProcesarDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _Empresa = _Row_InvParcial_Inventarios.Item("Empresa")
        _Sucursal = _Row_InvParcial_Inventarios.Item("Sucursal")
        _Bodega = _Row_InvParcial_Inventarios.Item("Bodega")

        Chk_CambiarCostoEnLCProducto.Enabled = _Ajuste_PM
        Chk_CambiarCostoEnLCProducto.Visible = _Ajuste_PM

        If _Ajuste_PM Then
            AddHandler BtnProcesar.Click, AddressOf Sb_Procesar_Ajuste_PM
        Else
            AddHandler BtnProcesar.Click, AddressOf Sb_Procesar_Ajuste_Stock
        End If

    End Sub

    Private Sub AddToLog(ByVal Accion As String,
                         ByVal Descripcion As String)
        TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()
    End Sub

#Region "AJUSTE STOCK"

    Sub Sb_Procesar_Ajuste_Stock()

        _Datos_Procesados = Fx_Procesar_Ajustes(_Tbl_Productos) ', _Emp, _Suc)

        If _Datos_Procesados Then

            Dim _Fecha_Hora As String =
            Format(DtFechaInv.Value, "yyyyMMdd") & "_" & Now.TimeOfDay.Hours & numero_(Now.TimeOfDay.Minutes, 2)

            Dim _Fecha_Lev_Hora As String =
            Format(Date.Now, "yyyyMMdd") & "_" & Now.TimeOfDay.Hours & numero_(Now.TimeOfDay.Minutes, 2)

            Dim Nombre_Archivo As String = _Fecha_Lev_Hora & "_" & _Fecha_Hora

            If Not Directory.Exists(AppPath() & "\Data\" & RutEmpresa & "\Ajustes_Inv") Then
                System.IO.Directory.CreateDirectory(AppPath() & "\Data\" & RutEmpresa & "\Ajustes_Inv")
            End If

            Dim _File As String = AppPath() & "\Data\" & RutEmpresa & "\Ajustes_Inv\Ajuste_" & Nombre_Archivo & ".txt" 'Documento_vta

            Dim sw As New System.IO.StreamWriter(_File)
            sw.WriteLine(TxtLog.Text)
            sw.Close()

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "CodigoPr", False, False, "'")

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.Pro_Ejecutar_Automaticamente = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

            Dim _Nro_GDI_Stock_Cero As String
            Dim _Nro_GRI_Stock_Cero As String
            Dim _Nro_GRI_Ajuste As String

            If Not (_Row_GDI_Ajuste_Cero Is Nothing) Then
                _Nro_GDI_Stock_Cero = _Row_GDI_Ajuste_Cero.Item("NUDO")
                _Nro_GDI_Stock_Cero = "Guía de ajuste deja Stock en Cero GDI: " & _Nro_GDI_Stock_Cero & vbCrLf
            End If

            If Not (_Row_GRI_Ajuste_Cero Is Nothing) Then
                _Nro_GRI_Stock_Cero = _Row_GRI_Ajuste_Cero.Item("NUDO")
                _Nro_GRI_Stock_Cero = "Guía de ajuses deja Stock en Cero GRI: " & _Nro_GRI_Stock_Cero & vbCrLf
            End If

            If Not (_Row_GRI_Ajuste_Definitivo Is Nothing) Then
                _Nro_GRI_Ajuste = _Row_GRI_Ajuste_Definitivo.Item("NUDO")
                _Nro_GRI_Ajuste = "Guía Ajuste definitiva, carga Stock GRI: " & _Nro_GRI_Ajuste & vbCrLf
            End If


            MessageBoxEx.Show(Me, "Proceso Generado correctamente" & vbCrLf & vbCrLf &
                                  "Guías: " & vbCrLf &
                                  _Nro_GDI_Stock_Cero & _Nro_GRI_Stock_Cero & _Nro_GRI_Ajuste,
                                  "Ajuste de inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        End If
    End Sub

#End Region

#Region "AJUSTE PM"
    Sub Sb_Procesar_Ajuste_PM()



        'Consulta_sql = "Select KOSU,KOBO From TABBO Where EMPRESA = '" & ModEmpresa & "'"
        'Dim _TblBodegas As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)
        Dim _SQLQuery = String.Empty

        'For Each _FBod As DataRow In _TblBodegas.Rows

        Dim _Sucursal As String '= _FBod("KOSU")
        Dim _Bodega As String '= _FBod("KOBO")

        _Datos_Procesados = Fx_Procesar_Ajustes(_Tbl_Productos)


        If _Datos_Procesados Then

            Dim _IdMaeedo_GRI = _Row_GRI_Ajuste_Definitivo.Item("IDMAEEDO")

            Consulta_sql = "Select * From MAEDDO Where IDMAEEDO = " & _IdMaeedo_GRI

            Dim _TblDetalle_GRI As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)


            For Each _Fila As DataRow In _TblDetalle_GRI.Rows

                Dim _Codigo As String = _Fila.Item("KOPRCT")
                Dim _Pm As Double = _Fila.Item("PPPRNERE1")

                Consulta_sql = "Select top 1 * From MAEPR Where KOPR = '" & _Codigo & "'"
                Dim _TblProducto As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

                Dim _Rtu As Double = _TblProducto.Rows(0).Item("RLUD")
                Dim _ListaCosto As String = Mid(_TblProducto.Rows(0).Item("LISCOSTO"), 6, 3)

                Dim _PMNew_Ud1 = De_Num_a_Tx_01(_Pm, , 5)
                Dim _PMNew_Ud2 = De_Num_a_Tx_01(_Pm * _Rtu, , 5)

                Dim _FechaPM As String = Format(_Fila.Item("FEEMLI"), "yyyyMMdd")
                Dim _Empresa As String = _Fila.Item("EMPRESA")
                Dim _Idmaeddo = _Fila.Item("IDMAEDDO")

                _SQLQuery += "UPDATE MAEDDO  SET PPPRPM = " & _PMNew_Ud1 & " ,COSTOTRIB = 0.00000" & vbCrLf &
                             "WHERE IDMAEDDO = " & _Idmaeddo & " AND ARPROD<>'COMON' AND ARPROD<>'CIFRS'" & vbCrLf & vbCrLf &
                             "UPDATE MAEPREM SET PM  = " & _PMNew_Ud1 & ",FEPM = '" & _FechaPM & "'" & vbCrLf &
                             "WHERE EMPRESA='" & _Empresa & "' AND KOPR='" & _Codigo & "'" & vbCrLf & vbCrLf &
                             "UPDATE MAEPR SET PM = " & _PMNew_Ud1 & ",FEPM = '" & _FechaPM & "'" & vbCrLf &
                             "WHERE KOPR='" & _Codigo & "'" & vbCrLf & vbCrLf &
                             "UPDATE MAEDDO SET PPPRPM = (SELECT TOP 1 PPPRPM" & vbCrLf &
                             "FROM MAEDDO AS CRIAS" & vbCrLf &
                             "WHERE (CRIAS.IDMAEEDO = MAEDDO.IDMAEEDO)" & vbCrLf &
                             "AND CRIAS.LILG = 'CR'" & vbCrLf &
                             "AND CRIAS.NULILG = MAEDDO.NULIDO" & vbCrLf &
                             "ORDER BY CRIAS.NULIDO DESC )" & vbCrLf &
                             "WHERE MAEDDO.KOPRCT = '" & _Codigo & "'  AND MAEDDO.LILG = 'GR' "

                If Chk_CambiarCostoEnLCProducto.Checked Then

                    _SQLQuery += "UPDATE TABPRE SET PP01UD = " & _PMNew_Ud1 & ",PP02UD = " & _PMNew_Ud2 & vbCrLf &
                                 "WHERE KOLT = '" & _ListaCosto & "' AND KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf
                End If

            Next

            _SQLQuery = "Update MAEEDO Set SUBTIDO = '' Where IDMAEEDO =" & _IdMaeedo_GRI & vbCrLf & vbCrLf &
                        "Update MAEEDOOB Set OBDO = 'Documento ajusta PPM de los productos, especial BakApp.'" & vbCrLf &
                        "Where IDMAEEDO =" & _IdMaeedo_GRI & vbCrLf & vbCrLf &
                        "Update MAEDDO SET ARCHIRST = 'POTL',TIDOPA = 'OTL'" & vbCrLf &
                        "WHERE IDMAEEDO = " & _IdMaeedo_GRI & vbCrLf & vbCrLf & _SQLQuery

        End If
        'Next

        If Not String.IsNullOrEmpty(_SQLQuery) Then
            If _Sql.Ej_consulta_IDU(Consulta_sql) Then

                MessageBoxEx.Show(Me, "PPM actualizado correctamente para los productos de la lista" & vbCrLf &
                                  "Ahora debe consolidar el stock de estos productos", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "Codigo", False, False, "'")

                Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
                Fm.ShowDialog(Me)
                Me.Close()
            End If
        End If

    End Sub
#End Region '

    Function Z_Fx_Generar_Inventario(ByVal tb As DataTable)
        Exit Function
        Dim myTrans As SqlClient.SqlTransaction
        Dim Comando As SqlClient.SqlCommand

        Dim SQLq As String


        Progreso_Porc.Maximum = 100

        Try

            Dim Nro As String = "Invp0003"

            If Fx_Tiene_Permiso(Me, Nro) Then

                Dim Fecha As String = FechaInv
                Dim Codigo As String
                Dim Descripcion As String
                Dim Orden As String

                Dim Tabla As New DataTable
                Dim Observaciones As String
                Dim Dr As DataRow

                Consulta_sql = "SELECT * FROM Zw_TmpInv_InvParcial " & vbCrLf &
                               "Where Levantado = 0 and FechaInv = '" & Fecha & "'" & vbCrLf &
                               "Order by Semilla"
                Dim SQLGrilla = Consulta_sql

                Tabla = _Sql.Fx_Get_Tablas(Consulta_sql)
                tb = Tabla
                'ProgressBar1.Style = ProgressBarStyle.Continuous
                Progreso_Cont.Maximum = Tabla.Rows.Count

                AddToLog("Iniciando Analisis", "-----------------------------------------")
                AddToLog("Iniciando Analisis", "Revisando si existen productos que procesar...")

                Dim cn3 As New SqlConnection
                Dim SQL_ServerClass As New Class_SQL(Cadena_ConexionSQL_Server)


                If Tabla.Rows.Count > 0 Then

                    SQL_ServerClass.Sb_Abrir_Conexion(cn3)
                    myTrans = cn3.BeginTransaction()

                    AddToLog("Consolidación de Stock...", "Preparandose para la consilidación de Stock")
                    Dim Contador As Integer

                    For i = 0 To Tabla.Rows.Count - 1
                        System.Windows.Forms.Application.DoEvents()

                        Dr = Tabla.Rows(i)
                        'Emp = Dr.Item("Empresa").ToString
                        'Suc = Dr.Item("Sucursal").ToString
                        'Bod = Dr.Item("Bodega").ToString
                        Codigo = Dr.Item("CodigoPr").ToString
                        Descripcion = Dr.Item("Descripcion").ToString
                        Orden = Dr.Item("Semilla").ToString

                        LblEstado.Text = "Consolidando Stock, " & i + 1 & " de " & Tabla.Rows.Count & ",Producto: " & Descripcion & ""

                        Consulta_sql = My.Resources._23_ConsultasSQL.Consolidación_de_Stock_por_producto.ToString

                        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
                        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
                        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
                        Consulta_sql = Replace(Consulta_sql, "#@Codigo#", Codigo)
                        Consulta_sql = Replace(Consulta_sql, "#Int#", Orden)
                        Consulta_sql = Replace(Consulta_sql, "#FechaInv#", Fecha)

                        _Sql.Ej_consulta_IDU(Consulta_sql)
                        Contador += 1
                        Progreso_Porc.Value = ((Contador * 100) / Tabla.Rows.Count) 'Mas
                        Progreso_Cont.Value += 1
                    Next

                    LblEstado.Text = "Productos consolidados correctamente, Stock físico"
                    AddToLog("Consolidación de Stock...", "Stock consolidaddo correctamente")
                    System.Windows.Forms.Application.DoEvents()


                    Progreso_Cont.Value = 0
                    Progreso_Porc.Value = 0


                    Observaciones = "Ajuste BakApp"

                    Dim _Caprco As Double
                    'GRI
                    _Caprco = Fx_Suma_cantidades("ConsolidStockUd1*-1",
                                                 _Global_BaseBk & "Zw_TmpInv_InvParcial",
                                                 "Levantado = 0 and FechaInv = '" & FechaInv & "' and ConsolidStockUd1 < 0")

                    Dim Rt_Em As String = RutEmpresa

                    If _Caprco > 0 Then

                        AddToLog("Dejar Stock en Cero", "Generando GRI de ajuste para dejar Stock en cero...")
                        System.Windows.Forms.Application.DoEvents()


                        Consulta_sql = My.Resources._23_ConsultasSQL.Deja_Stock_Cero
                        Consulta_sql = Replace(Consulta_sql, "#Fecha#", FechaInv)
                        Consulta_sql = Replace(Consulta_sql, "#Filtro#", "and ConsolidStockUd1 < 0")

                        'Generar_Documento_Ajuste("GRI", _
                        '                         RutEmpresa, _
                        '                         ModSucursal, _
                        '                         "", _
                        '                         ModListaPrecioCosto, _
                        '                         _Fecha_Inv, _
                        '                         Consulta_sql)

                    End If

                    'GDI
                    _Caprco = Fx_Suma_cantidades("ConsolidStockUd1",
                                                 _Global_BaseBk & "Zw_TmpInv_InvParcial",
                                                 "Levantado = 0 and FechaInv = '" & FechaInv &
                                                 "' and ConsolidStockUd1 > 0")

                    If _Caprco > 0 Then

                        AddToLog("Dejar Stock en Cero", "Generando GDI de ajuste para dejar Stock en cero...")
                        System.Windows.Forms.Application.DoEvents()


                        Consulta_sql = My.Resources._23_ConsultasSQL.Deja_Stock_Cero
                        Consulta_sql = Replace(Consulta_sql, "*-1", "")
                        Consulta_sql = Replace(Consulta_sql, "#Fecha#", FechaInv)

                        Consulta_sql = Replace(Consulta_sql, "#Filtro#", "and ConsolidStockUd1 > 0")

                        ' Generar_Documento_Ajuste("GDI", _
                        '                          RutEmpresa, _
                        '                          ModSucursal, _
                        '                          "", _
                        '                          ModListaPrecioCosto, _
                        '                          _Fecha_Inv, _
                        '                          Consulta_sql)
                    End If

                    AddToLog("Dejar Stock en Cero", "Los Stock ya estan en cero ")
                    System.Windows.Forms.Application.DoEvents()


                    _Caprco = Fx_Suma_cantidades("CantidadUd1",
                                                _Global_BaseBk & "Zw_TmpInv_InvParcial",
                                                "Levantado = 0 and FechaInv = '" & FechaInv &
                                                "' and CantidadUd1 > 0")

                    If _Caprco > 0 Then

                        AddToLog("Insertar Stock...", "Preparando GRI de Ajuste definitiva")
                        System.Windows.Forms.Application.DoEvents()

                        Consulta_sql = My.Resources._23_ConsultasSQL.Genera_GRI_Definitiva
                        Consulta_sql = Replace(Consulta_sql, "#Fecha#", FechaInv)



                        ' Generar_Documento_Ajuste("GRI", _
                        '                         RutEmpresa, _
                        '                         ModSucursal, _
                        '                         "", _
                        '                         ModListaPrecioCosto, _
                        '                         _Fecha_Inv, _
                        '                         Consulta_sql)



                        AddToLog("Insertar Stock...", "GRI gerenerada correctamente")
                        System.Windows.Forms.Application.DoEvents()

                        AddToLog("Ajuste completo", "Los Stock ya estan ajustados correctamente")
                        System.Windows.Forms.Application.DoEvents()


                    End If



                    Consulta_sql = "UPDATE Zw_TmpInv_InvParcial set Levantado = 1" & vbCrLf &
                                   "Where Levantado = 0 and FechaInv = '" & Fecha & "'"

                    Comando = New SqlClient.SqlCommand(Consulta_sql, cn3)
                    Comando.Transaction = myTrans
                    Comando.CommandTimeout = 0
                    Comando.ExecuteNonQuery()

                    AddToLog("Desbloquear productos", "Revisando productos bloquedados")
                    System.Windows.Forms.Application.DoEvents()

                    For Each row As DataRow In tb.Rows
                        'aqui trabajas con el valor de la celda
                        Dim Codi As String = row.Item("CodigoPr").ToString
                        Consulta_sql = "UPDATE MAEPR SET ATPR = '' WHERE KOPR = '" & Trim(Codi) & "'"

                        Comando = New SqlClient.SqlCommand(Consulta_sql, cn3)
                        Comando.Transaction = myTrans
                        Comando.ExecuteNonQuery()

                    Next

                    AddToLog("Desbloquear productos", "Productos desbloqueados correctamente")
                    System.Windows.Forms.Application.DoEvents()

                    myTrans.Commit()
                    SQL_ServerClass.Sb_Cerrar_Conexion(cn3)

                    Return True

                Else

                    MensajeSinPermiso(Nro)

                End If

            End If


        Catch ex As Exception
            'myTrans.Rollback()
            MessageBoxEx.Show(ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'SQL_ServerClass.Sb_Cerrar_Conexion(cn3)
            AddToLog("PROBLEMAS DE EJECUCION!!!!", "Transaccion desecha")
            Return False
        End Try
    End Function

    Enum Enum_Tido_Doc_Ajuste
        GDI_Stock_Cero
        GRI_Stock_Cero
        GRI_Ajuste
    End Enum

    Function Fx_Generar_Guia_De_Ajuste(ByVal _Tipo_Documento As Enum_Tido_Doc_Ajuste) As DataRow

        Dim _New_Idmaeedo As Integer
        Consulta_sql = "Select Top 1 * From CONFIGP Where EMPRESA = '" & ModEmpresa & "'"
        Dim _Row_Configp As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Koen = _Row_Configp.Item("RUT")

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "'"
        Dim _Row_Entidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim _Tido = String.Empty
        Dim _Campo_Cantidad = String.Empty

        Dim _Doc As Integer
        Dim _Observaciones = String.Empty

        Select Case _Tipo_Documento
            Case Enum_Tido_Doc_Ajuste.GDI_Stock_Cero
                _Tido = "GDI"
                _Campo_Cantidad = "Dif_GDI_Ud1"
                _Doc = 4
                _Observaciones = "Ajuste de Stock generado desde BakApp, Documento deja Stock en Cero."
            Case Enum_Tido_Doc_Ajuste.GRI_Stock_Cero
                _Tido = "GRI"
                _Campo_Cantidad = "Dif_GRI_Ud1"
                _Doc = 5
                _Observaciones = "Ajuste de Stock generado desde BakApp, Documento deja Stock en Cero."
            Case Enum_Tido_Doc_Ajuste.GRI_Ajuste
                _Tido = "GRI"
                _Campo_Cantidad = "CantidadUd1"
                _Doc = 5
                _Observaciones = "Ajuste de Stock generado desde BakApp, Documento de ajuste definitivo. Ingreso de stock."
        End Select

        Dim Fm As New Frm_Formulario_Documento(_Tido, _Doc, False, False, False,
                                               True, Chk_Dejar_Doc_Final_Del_Dia.Checked)

        Fm.Pro_RowEntidad = _Row_Entidad
        Fm.Sb_Crear_Documento_Interno_Con_Tabla(Me, _Tbl_Productos, DtFechaInv.Value,
                                                "CodigoPr", _Campo_Cantidad, "CostoUnitUd1", _Observaciones, False, False)
        _New_Idmaeedo = Fm.Fx_Grabar_Documento(False)
        Fm.Dispose()

        If CBool(_New_Idmaeedo) Then
            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _New_Idmaeedo
            Dim _Row As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)
            Return _Row
        Else
            Return Nothing
        End If

    End Function

    Function Generar_Documento_Ajuste(
                           ByVal _TipoDoc As String,
                           ByVal _Entidad_Doc As String,
                           ByVal _EntidadSuc_Doc As String,
                           ByVal _Nombre_Entidad As String,
                           ByVal _Lista As String,
                           ByVal FechaInv As Date,
                           ByVal _Tbl_DetalleDoc As DataTable,
                           ByVal Es_GRI_Ajuste_Definitivo As Boolean,
                           ByVal Progreso_Porc As Object,
                           ByVal Progreso_Cont As Object,
                           ByVal _Observacion As String,
                           ByVal _Empresa_Ajuste As String,
                           ByVal _Sucursal_Ajuste As String)

        Dim _FechaInv As String = Format(FechaInv, "yyyyMMdd")
        Dim Dt_Documento As New Ds_Matriz_Documentos 'DatosBakApp '("Pubs")

        Dim NewFila As DataRow
        NewFila = Dt_Documento.Tables("Encabezado_Doc").NewRow
        With NewFila

            .Item("Modalidad") = Modalidad
            .Item("Empresa") = _Empresa
            .Item("Sucursal") = _Sucursal
            .Item("TipoDoc") = _TipoDoc
            .Item("NroDocumento") = "XXXXXXXXXX"
            .Item("CodEntidad") = _Entidad_Doc
            .Item("CodSucEntidad") = _EntidadSuc_Doc
            .Item("Nombre_Entidad") = _Nombre_Entidad
            .Item("CodEntidadFisica") = "" 'Entidad_Fisica_Doc
            .Item("CodSucEntidadFisica") = "" 'NuloPorNro(EntidadSuc_Fisica_Doc, String.Empty)
            .Item("CodSucEntidadFisica") = "" 'NuloPorNro(Nombre_EntidadFisica, String.Empty)
            .Item("ListaPrecios") = _Lista
            .Item("CodFuncionario") = FUNCIONARIO
            .Item("NomFuncionario") = Nombre_funcionario_activo
            .Item("FechaEmision") = FechaInv
            .Item("Fecha_1er_Vencimiento") = FechaInv
            .Item("FechaUltVencimiento") = FechaInv
            .Item("FechaRecepcion") = FechaInv
            .Item("Cuotas") = 0
            .Item("Dias_1er_Vencimiento") = 0
            .Item("Dias_Vencimiento") = 0
            .Item("Moneda_Doc") = "" '_Moneda_Doc
            .Item("Valor_Dolar") = 0 'Valor_Dolar
            .Item("DocEn_Neto_Bruto") = "N" ' NETO
            .Item("TipoMoneda") = "N"  ' -- Tipo Moneda del documento: Nacional/Extranjera
            .Item("Centro_Costo") = "" 'Centro_Costo
            .Item("Contacto_Ent") = String.Empty
            .Item("TotalNetoDoc") = 0
            .Item("TotalIvaDoc") = 0
            .Item("TotalIlaDoc") = 0
            .Item("TotalBrutoDoc") = 0
            .Item("CantTotal") = 0
            .Item("CantDesp") = 0

            Dt_Documento.Tables("Encabezado_Doc").Rows.Add(NewFila)
        End With

        NewFila = Dt_Documento.Tables("Observaciones_Doc").NewRow
        With NewFila

            .Item("Observaciones") = _Observacion

            Dt_Documento.Tables("Observaciones_Doc").Rows.Add(NewFila)

        End With



        'Dim Tbl_Detalle As DataTable
        'Tbl_Detalle = get_Tablas(Sql_DetalleDoc, cn1)

        Dim _CantidadUd1, _cantidadUd2 As Double



        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _Tbl_DetalleDoc.Rows.Count

        Dim Contador As Integer = 0

        For Each Fila As DataRow In _Tbl_DetalleDoc.Rows
            System.Windows.Forms.Application.DoEvents()

            Dim _Cantidad As Double
            Dim _Codigo As String = Fila.Item("CodigoPr")

            Consulta_sql = "Select * From MAEPR Where KOPR = '" & _Codigo & "'"
            Dim _RowProducto As DataRow = _Sql.Fx_Get_Tablas(Consulta_sql).Rows(0)

            Dim _Rtu As String = _RowProducto.Item("RLUD")

            _CantidadUd1 = Fila.Item("Stock_Ud1")
            _cantidadUd2 = Fila.Item("Stock_Ud2")

            If Es_GRI_Ajuste_Definitivo Then
                _Cantidad = Fila.Item("CantidadUd1")
                _CantidadUd1 = _Cantidad
                _cantidadUd2 = _Cantidad * _Rtu
            Else
                If _TipoDoc = "GDI" Then
                    _Cantidad = _CantidadUd1 'Fila.Item("Dif_GDI_Ud1")
                Else
                    _Cantidad = _CantidadUd1 'Fila.Item("Dif_GRI_Ud1")
                End If
            End If

            If _CantidadUd1 <> 0 Or _cantidadUd2 <> 0 Then


                Dim _Descripcion As String = Fila.Item("Descripcion")

                'Dim _Cantidad As Double = Fila.Item("Cantidad")
                Dim _Precio As Double = Fila.Item("CostoUnitUd1")
                Dim _Iva As Double = _RowProducto.Item("POIVPR") '_Sql.Fx_Trae_Dato(, "POIVPR", "MAEPR", "KOPR ='" & _Codigo & "'", True) 'Fila.Item("Iva")
                Dim _Ila As Double = 0 'Fila.Item("Ila")
                Dim _Prct As String = 0 'Fila.Item("Prct")
                Dim _Tict As String = String.Empty 'Fila.Item("Tict")
                Dim _Tipr As String = _RowProducto.Item("TIPR") '_Sql.Fx_Trae_Dato(, "TIPR", "MAEPR", "KOPR ='" & _Codigo & "'")
                Dim _EsNeto As Boolean = True 'Fila.Item("EsNeto")
                Dim _Tido As String = _TipoDoc 'Fila.Item("Tido")
                Dim _ListaPrecio As String = _Lista 'Fila.Item("Lista")

                Dim _Empresa As String = _Empresa_Ajuste
                Dim _Sucursal As String = Fila.Item("Sucursal") ' _Sucursal_Ajuste
                Dim _Bodega As String = Fila.Item("Bodega") '_Bodega_Ajuste

                Dim _UdTrans As Integer = 1 'Fila.Item("UdTrans")
                Dim _UnTrans As String = _RowProducto.Item("UD01PR") '_Sql.Fx_Trae_Dato(, "UD01PR", "MAEPR", "KOPR ='" & _Codigo & "'") 'Fila.Item("UnTrans")
                Dim _Ud1Linea As String = _RowProducto.Item("UD01PR") '_Sql.Fx_Trae_Dato(, "UD01PR", "MAEPR", "KOPR ='" & _Codigo & "'") 'Fila.Item("Ud1Linea")
                Dim _Ud2Linea As String = _RowProducto.Item("UD02PR") '_Sql.Fx_Trae_Dato(, "UD02PR", "MAEPR", "KOPR ='" & _Codigo & "'") 'Fila.Item("Ud2Linea")


                Traer_Producto_al_Detalle(Dt_Documento,
                                          _Codigo,
                                          _Descripcion,
                                          _Rtu,
                                          _Cantidad,
                                          _CantidadUd1,
                                          _cantidadUd2,
                                          _Precio,
                                          _Iva,
                                          _Ila,
                                          _Prct,
                                          _Tict,
                                          _Tipr,
                                          _EsNeto,
                                          _Tido,
                                          _Lista,
                                          _Empresa,
                                          _Sucursal,
                                          _Bodega,
                                          _UdTrans,
                                          _Ud1Linea,
                                          _Ud2Linea)
            End If


            Contador += 1
            Progreso_Porc.Value = ((Contador * 100) / _Tbl_DetalleDoc.Rows.Count) 'Mas
            Progreso_Cont.Value += 1

        Next

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

        'Traer_Producto_al_Detalle Dt_Documento

        Dim Neto As Double = 0
        Dim Iva As Double = 0
        Dim Ila As Double = 0
        Dim Bruto As Double = 0

        Dim Cant As Double = 0
        Dim CantDesp As Double = 0

        Dim Tict As String
        ' Dim Col As Integer = Grilla.CurrentCell.ColumnIndex

        'Dim Tbl_Dt As DataTable = Dt_Documento.Tables("DetalleDocumento")

        For Each row As DataRow In Dt_Documento.Tables("Detalle_Doc").Rows

            Neto += NuloPorNro(row.Item("ValNetoLinea"), 0)
            Iva += NuloPorNro(row.Item("ValIvaLinea"), 0)
            Ila += NuloPorNro(row.Item("ValIlaLinea"), 0)
            Bruto += NuloPorNro(row.Item("ValBrutoLinea"), 0)

            Cant += NuloPorNro(row.Item("CantUd1"), 0)
            CantDesp += NuloPorNro(row.Item("CDespUd1"), 0)

        Next

        Bruto = Math.Round(Neto, 0) + Math.Round(Iva, 0) + Math.Round(Ila, 0)

        Dim CambiaNroOrigen As Boolean = True
        Dim TipGrab As Integer
        Dim NrNumeroDoco As String = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa &
                                        "' AND MODALIDAD = '" & Modalidad & "'") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)
        Dim Continua As Boolean = True

        If String.IsNullOrEmpty(Trim(NrNumeroDoco)) Then
            NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa &
                           "' AND MODALIDAD = '  '") 'FUNCIONARIO & numero_(Trim(Str(CantOCCFuncionario)), 7)
            CambiaNroOrigen = False
            TipGrab = TipoGrabacion.EnBlanco

        ElseIf NrNumeroDoco = "0000000000" Then
            NrNumeroDoco = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')", "TIDO = '" & _TipoDoc & "'")
            CambiaNroOrigen = False
            TipGrab = TipoGrabacion.Puros_Ceros
        Else
            CambiaNroOrigen = True
            TipGrab = TipoGrabacion.Con_Numeración
        End If

        'Continua = True
        Contador = 0

        While True
            Dim R As Integer = _Sql.Fx_Cuenta_Registros("MAEEDO", "TIDO = '" & _TipoDoc & "' AND NUDO = '" & NrNumeroDoco & "'")
            If R = 0 Then
                'Continua = False
                Exit While
            Else

                If TipGrab = TipoGrabacion.Con_Numeración Then

                    Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = dbo.ProxNumero('" & NrNumeroDoco &
                                   "') WHERE EMPRESA = '" & ModEmpresa &
                                   "' AND  MODALIDAD = '" & Modalidad & "'"
                    _Sql.Ej_consulta_IDU(Consulta_sql)

                    If CambiaNroOrigen Then
                        NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa &
                                                 "' AND MODALIDAD = '" & Modalidad & "'")
                    End If

                ElseIf TipGrab = TipoGrabacion.EnBlanco Then
                    NrNumeroDoco = _Sql.Fx_Trae_Dato("CONFIEST", _TipoDoc, "EMPRESA = '" & ModEmpresa & "' AND MODALIDAD = '  '")

                ElseIf TipGrab = TipoGrabacion.Puros_Ceros Then
                    NrNumeroDoco = _Sql.Fx_Trae_Dato("MAEEDO", "COALESCE(MAX(NUDO),'0000000000')", "TIDO = '" & _TipoDoc & "'")

                    Consulta_sql = "select dbo.ProxNumero('" & NrNumeroDoco & "') as Nro"
                    Dim TblPaso = _Sql.Fx_Get_Tablas(Consulta_sql)
                    Dim Fila As DataRow = TblPaso.Rows(0)

                    NrNumeroDoco = Fila.Item("Nro").ToString

                End If

            End If
            Contador += 1

            If Contador = 10 Then

                Dim info As New TaskDialogInfo("Grabar documento",
                            eTaskDialogIcon.Stop,
                            "El documento no se puede guardar correctamente",
                            "Favor colocar la numeración correspondiente en Modalidad de trabajo " & Modalidad & vbCrLf &
                            "vuelva a intentar la grabación." & vbCrLf &
                            "El Nro que se esta intentado guarda Nro " & NrNumeroDoco & " ya exite en el sistema",
                            eTaskDialogButton.Close _
                            , eTaskDialogBackgroundColor.Red, Nothing, Nothing, Nothing, Nothing, Nothing)
                Dim result As eTaskDialogResult = TaskDialog.Show(info)

                Return 0

            End If

        End While

        Dim customerRow() As Data.DataRow
        customerRow = Dt_Documento.Tables("Encabezado_Doc").Select("TipoDoc = '" & _TipoDoc & "'")

        customerRow(0)("NroDocumento") = NrNumeroDoco
        customerRow(0)("Es_Electronico") = 0
        customerRow(0)("TotalNetoDoc") = Math.Round(Neto, 0)
        customerRow(0)("TotalIvaDoc") = Math.Round(Iva, 0)
        customerRow(0)("TotalIlaDoc") = Math.Round(Ila, 0)
        customerRow(0)("TotalBrutoDoc") = Math.Round(Bruto, 0)
        customerRow(0)("CantTotal") = Cant
        customerRow(0)("CantDesp") = Cant

        'Dt_Documento.WriteXml(AppPath(True) & _TipoDoc & ".XML")

        Dt_Documento.WriteXml(AppPath() & "\Data\" & RutEmpresa & "\" & _TipoDoc & ".XML") 'Documento_vta
        Dim New_Doc_Idmaeedo As Integer

        'Try
        Dim New_Doc As New Clase_Crear_Documento()
        Dim Documento As String

        Dim _Es_ValeTransitorio As Boolean = False

        New_Doc_Idmaeedo = New_Doc.Fx_Crear_Documento(_TipoDoc,
                                                      NrNumeroDoco,
                                                      False,
                                                      True,
                                                      Dt_Documento,
                                                      True)

        If CBool(New_Doc_Idmaeedo) Then

            If TipGrab = TipoGrabacion.Con_Numeración Then
                Consulta_sql = "UPDATE CONFIEST SET " & _TipoDoc & " = dbo.ProxNumero('" & NrNumeroDoco &
                               "') WHERE EMPRESA = '" & ModEmpresa &
                               "' AND  MODALIDAD = '" & Modalidad & "'"
                _Sql.Ej_consulta_IDU(Consulta_sql)
            End If

            Return New_Doc_Idmaeedo

        End If



    End Function

    Function Traer_Producto_al_Detalle(
                                        ByVal _New_Ds_Documento As DataSet,
                                        ByVal _Codigo As String,
                                        ByVal _Descripcion As String,
                                        ByVal _Rtu As String,
                                        ByVal _Cantidad As Double,
                                        ByVal _CantidadUd1 As Double,
                                        ByVal _CantidadUd2 As Double,
                                        ByVal _Precio As Double,
                                        ByVal _Iva As Double,
                                        ByVal _Ila As Double,
                                        ByVal _Prct As String,
                                        ByVal _Tict As String,
                                        ByVal _Tipr As String,
                                        ByVal _EsNeto As Boolean,
                                        ByVal _Tido As String,
                                        ByVal _ListaPrecio As String,
                                        ByVal _Empresa As String,
                                        ByVal _Sucursal As String,
                                        ByVal _Bodega As String,
                                        ByVal _UdTrans As Integer,
                                        ByVal _Ud1Linea As String,
                                        ByVal _Ud2Linea As String)

        Dim CodAlternativo As String = String.Empty

        Dim _PrecioNeto As Double
        Dim _PrecioBruto As Double

        Dim _TipoValor As String

        Dim PmLinea As Double = _Sql.Fx_Trae_Dato("MAEPREM", "PM",
                                                   "KOPR = '" & _Codigo & "'", True)
        Dim PmSucLinea As Double = _Sql.Fx_Trae_Dato("MAEPMSUC", "PMSUC",
                                   "KOPR = '" & _Codigo &
                                   "' AND EMPRESA = '" & ModEmpresa &
                                   "' AND KOSU = '" & _Sucursal & "'", True)


        Dim _UnTrans As String

        If _UdTrans = 1 Then
            _UnTrans = _Ud1Linea
        Else
            _UnTrans = _Ud2Linea
        End If

        Dim _PrecioNetoUd As Double
        Dim _PrecioBrutoUd As Double

        Dim NetoRealUd1 = 0
        Dim NetoRealUd2 = 0

        Dim UbicacionBod = _Sql.Fx_Trae_Dato("TABBOPR", "DATOSUBIC",
                                        "EMPRESA = '" & ModEmpresa &
                                        "' AND KOSU = '" & _Sucursal &
                                        "' AND KOBO = '" & _Bodega &
                                        "' AND KOPR = '" & _Codigo & "'")


        Dim VtaStock = True

        Dim Lincondest As Boolean
        Dim Total As Double

        Dim _Impuestos = 1 + ((_Iva + _Ila) / 100)

        If _EsNeto Then
            _TipoValor = "N"
            _PrecioNeto = _Precio
        Else
            _TipoValor = "B"
            _PrecioNeto = Math.Round(_Precio / _Impuestos, 3)
            _PrecioBruto = _Precio
        End If

        If _UdTrans = 1 Then
            _PrecioNetoUd = _PrecioNeto
            _PrecioBrutoUd = _PrecioBruto
        Else
            _PrecioNetoUd = _PrecioNeto * _Rtu
            _PrecioBrutoUd = _PrecioBruto * _Rtu
        End If


        Dim _TotalNeto As Double = Math.Round(_PrecioNeto * _Cantidad, 3)
        Dim _TotalIva,
            _TotalIla As Double
        Dim _TotalBruto As Double = Math.Round((_TotalNeto * _Impuestos), 0)


        If _EsNeto Then ' SI VALORES SON NETOS

            _TotalIva = (Math.Round(_TotalNeto * (_Iva / 100), 5))
            _TotalIla = (Math.Round(_TotalNeto * (_Ila / 100), 5))
            _TotalBruto = Math.Round((_TotalNeto * _Impuestos), 0)
            _PrecioBruto = Math.Round(_PrecioNeto * _Impuestos, 0)

        Else            ' SI VALORES SON BRUTOS

            _TotalNeto = Math.Round(_TotalBruto / _Impuestos, 5)
            _TotalIva = (Math.Round(_TotalNeto * (_Iva / 100), 5))
            _TotalIla = (Math.Round(_TotalNeto * (_Ila / 100), 5))
            _PrecioNeto = Math.Round(_Precio / _Impuestos, 3)

        End If

        ' Dim _CantidadUd1, _CantidadUd2 As Double
        Dim _PrecioNetoRealUd1, _PrecioNetoRealUd2 As Double

        '_CantidadUd1 = _Cantidad
        '_CantidadUd2 = _Cantidad * _Rtu

        If _Cantidad > 0 Then
            _PrecioNetoRealUd1 = Math.Round(_TotalNeto / _CantidadUd1, 5)
            _PrecioNetoRealUd2 = Math.Round(_TotalNeto / _CantidadUd2, 5)
        Else
            _PrecioNetoRealUd1 = 0
            _PrecioNetoRealUd2 = 0
        End If


        Dim NewFila As DataRow
        NewFila = _New_Ds_Documento.Tables("Detalle_Doc").NewRow
        With NewFila

            '.Item("Empresa") = _Empresa
            .Item("Sucursal") = _Sucursal
            .Item("Bodega") = _Bodega
            .Item("Codigo") = _Codigo
            .Item("Descripcion") = _Descripcion
            .Item("Cantidad") = _Cantidad
            .Item("DescuentoPorc") = 0
            .Item("DescuentoValor") = 0
            .Item("CodLista") = _ListaPrecio
            .Item("Lincondest") = True
            .Item("Prct") = _Prct
            .Item("TipoValor") = _TipoValor
            .Item("Precio") = _Precio
            .Item("DescuentoPorc") = 0
            .Item("DescuentoValor") = 0
            .Item("Tipr") = _Tipr
            .Item("Rtu") = _Rtu
            .Item("Tict") = _Tict
            .Item("UnTrans") = _UdTrans
            .Item("UdTrans") = _UnTrans
            .Item("Prct") = _Prct
            .Item("Ud01PR") = _Ud1Linea
            .Item("Ud02PR") = _Ud2Linea
            .Item("PmSucLinea") = PmSucLinea
            .Item("PmLinea") = PmLinea
            .Item("Lincondest") = True

            .Item("NroDscto") = 0

            .Item("Operacion") = ""
            .Item("Potencia") = 0


            .Item("DsctoRealPorc") = 0
            .Item("PrecioNetoUd") = _PrecioNetoUd
            .Item("PrecioNetoUdLista") = _PrecioNetoUd

            .Item("PrecioBrutoUd") = _PrecioBrutoUd
            .Item("PrecioBrutoUdLista") = _PrecioBrutoUd
            .Item("CantUd1") = _CantidadUd1
            .Item("CantUd2") = _CantidadUd2
            .Item("DsctoNeto") = 0
            .Item("DsctoBruto") = 0

            .Item("PorIva") = _Iva
            .Item("PorIla") = _Ila

            .Item("ValIvaLinea") = _TotalIva
            .Item("ValIlaLinea") = _TotalIla
            .Item("ValNetoLinea") = _TotalNeto
            .Item("ValBrutoLinea") = _TotalBruto
            .Item("PrecioNetoRealUd1") = _PrecioNetoRealUd1
            .Item("PrecioNetoRealUd2") = _PrecioNetoRealUd2

            _New_Ds_Documento.Tables("Detalle_Doc").Rows.Add(NewFila)
        End With



    End Function

    Private Function Stock_Fi_A_Una_Fecha_X_Producto(ByVal _Codigo As String,
                                                ByVal _Empresa As String,
                                                ByVal _Sucursal As String,
                                                ByVal _Bodega As String,
                                                ByVal _Fecha As Date) As Double()

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_TblStockConsolid")

        Consulta_sql = My.Resources._23_ConsultasSQL.Consolidacion_Stock_Fisico_X_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha, "yyyyMMdd"))

        Dim Tbl As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_TblStockConsolid")

        Dim Stock_(1) As Double

        If Tbl.Rows.Count > 0 Then
            Stock_(0) = Tbl.Rows(0).Item("CantidadUd1")
            Stock_(1) = Tbl.Rows(0).Item("CantidadUd2")
        Else
            Stock_(0) = 0
            Stock_(1) = 0
        End If

        Return Stock_

    End Function

    Function Fx_Procesar_Ajustes(ByVal Tbl_Detalle_Aj As DataTable)

        Try

            'Dim Nro As String = "Invp0003"
            'If Fx_Tiene_Permiso(Me, Nro) Then

            Dim Fecha As String = FechaInv

            Dim Orden As String

            Dim Tabla As New DataTable
            Dim Observaciones As String
            Dim Dr As DataRow

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = Tbl_Detalle_Aj.Rows.Count

            AddToLog("Iniciando Analisis", "-----------------------------------------")
            AddToLog("Iniciando Analisis", "Revisando si existen productos que procesar...")
            AddToLog("Consolidación de Stock...", "Preparandose para la consilidación de Stock")

            Dim Contador As Integer = 0


            For Each Fila As DataRow In Tbl_Detalle_Aj.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo As String = Fila.Item("CodigoPr")
                Dim _Descripcion As String = Fila.Item("Descripcion")

                Dim _CantidadUd1 As Double = Fila.Item("CantidadUd1")
                Dim _CantidadUd2 As Double = Fila.Item("CantidadUd2")

                Dim _ConsolidStockUd1, _ConsolidStockUd2 As Double

                Dim _Dif_GDI_Ud1 As Double = 0
                Dim _Dif_GRI_Ud1 As Double = 0


                LblEstado.Text = "Consolidando Stock, " & Contador + 1 & " de " &
                                 Tbl_Detalle_Aj.Rows.Count & ",Producto: " & _Descripcion & ""

                Dim _Stock_Fi(1) As Double
                Dim _Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
                Dim _Dif As Double

                '_Suc = Fila.Item("Sucursal")
                '_Bod = Fila.Item("Bodega")

                _Stock_Fi = Stock_Fi_A_Una_Fecha_X_Producto(_Codigo, _Empresa, _Sucursal, _Bodega, DtFechaInv.Value)

                _Dif = _Stock_Fi(0) '- _CantidadUd1

                If _Dif > 0 Then
                    _Dif_GDI_Ud1 = _Dif
                Else
                    _Dif_GRI_Ud1 = _Dif * -1
                End If

                Fila.Item("Dif_GDI_Ud1") = _Dif_GDI_Ud1
                Fila.Item("Dif_GRI_Ud1") = _Dif_GRI_Ud1

                Dim _Stock_Ud1 As Double = Math.Round(_Stock_Fi(0), 5)
                Dim _Stock_Ud2 As Double = Math.Round(_Stock_Fi(1), 5)

                If _Stock_Ud1 <> _Stock_Ud2 Then

                    If _Stock_Ud1 = 0 Then
                        If _Stock_Ud2 <> 0 Then
                            Fila.Item("Dif_GDI_Ud1") = 1
                        End If
                    End If

                    If CBool(_Dif_GRI_Ud1) Then
                        _Stock_Ud1 = _Stock_Ud1 * -1
                        If _Stock_Ud2 > 0 Then
                            _Stock_Ud2 = _Stock_Ud2 * -1
                        End If
                    End If

                Else

                    If _Stock_Ud1 < 0 Then _Stock_Ud1 = _Stock_Ud1 * -1
                    If _Stock_Ud2 < 0 Then _Stock_Ud2 = _Stock_Ud2 * -1

                End If

                ' SI EL AJUSTE ES POSITIVO EN LA UNIDAD 1 Y NEGATIVO EN LA UNIDAD 2
                ' EL SISTEMA DEJARA LAS CANTIDADES TAL CUAL, PARA QUE EL AJUSTE SEA UN CERO ABSOLUTO.

                Fila.Item("Stock_Ud1") = _Stock_Ud1
                Fila.Item("Stock_Ud2") = _Stock_Ud2


                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Tbl_Detalle_Aj.Rows.Count) 'Mas
                Progreso_Cont.Value += 1


            Next

            'Exit Function
            LblEstado.Text = "Productos consolidados correctamente, Stock físico"
            AddToLog("Consolidación de Stock...", "Stock consolidaddo correctamente")
            System.Windows.Forms.Application.DoEvents()

            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0


            AddToLog("Dejar Stock en Cero", "Generando Guias de Ajuste para dejar Stock en cero...")
            System.Windows.Forms.Application.DoEvents()


            ' ********* GDI DE AJUSTE DEJA STOCK EN CERO

            Dim GDI_Object As Object
            'GDI_Object = Tbl_Detalle_Aj.Compute("Sum(Dif_GDI_Ud1)", "CodigoPr <> ''") ')Dif_GDI_Ud1 > 0")
            'GDI_Object = Tbl_Detalle_Aj.Compute("Sum(Dif_GDI_Ud1)", "Dif_GDI_Ud1 > 0") ')")

            For Each _Fila_GDI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GDI_Ud1 = _Fila_GDI.Item("Dif_GDI_Ud1")
                GDI_Object += Dif_GDI_Ud1
            Next

            Dim GDI_Ajuste_Cero, GRI_Ajuste_Cero, GRI_Ajuste_Definitivo As String

            If CBool(GDI_Object) Then

                AddToLog("Dejar Stock en Cero", "Generando GDI de Ajuste para dejar Stock en cero...")
                System.Windows.Forms.Application.DoEvents()

                _Row_GDI_Ajuste_Cero = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GDI_Stock_Cero)

                If (_Row_GDI_Ajuste_Cero Is Nothing) Then 'NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GDI de ajuste a cero!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GDI_Ajuste_Cero.Item("IDMAEEDO")
                    Dim _Nro_GDI_Stock_Cero = _Row_GDI_Ajuste_Cero.Item("NUDO")

                    For Each _Fila_GDI As DataRow In Tbl_Detalle_Aj.Rows

                        Dim _Dif_GDI_Ud1 As Boolean = CBool(_Fila_GDI.Item("Dif_GDI_Ud1"))

                        If _Dif_GDI_Ud1 Then
                            _Fila_GDI.Item("GDI_Idmaeedo_Aj") = _Idmaeedo
                            _Fila_GDI.Item("Nro_GDI_Stock_Cero") = "GDI-" & _Nro_GDI_Stock_Cero
                        End If

                    Next

                    AddToLog("Dejar Stock en Cero", "GDI Nro: " & _Nro_GDI_Stock_Cero & ", Generada correctamente")
                    System.Windows.Forms.Application.DoEvents()
                End If



            End If

            ' ********* GRI DE AJUSTE DEJA STOCK EN CERO

            Dim GRI_Object As Object

            For Each _Fila_GRI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GRI_Ud1 = _Fila_GRI.Item("Dif_GRI_Ud1")
                GRI_Object += Dif_GRI_Ud1
            Next

            If CBool(GRI_Object) Then

                AddToLog("Dejar Stock en Cero", "Generando GRI de Ajuste para dejar Stock en cero...")
                System.Windows.Forms.Application.DoEvents()

                _Row_GRI_Ajuste_Cero = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Stock_Cero)

                If (_Row_GRI_Ajuste_Cero Is Nothing) Then 'If NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GRI de ajuste a cero!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GRI_Ajuste_Cero.Item("IDMAEEDO")
                    Dim _Nro_GRI_Stock_Cero = _Row_GRI_Ajuste_Cero.Item("NUDO")

                    For Each _Fila_GRI As DataRow In Tbl_Detalle_Aj.Rows

                        Dim _Dif_GRI_Ud1 As Boolean = CBool(_Fila_GRI.Item("Dif_GRI_Ud1"))

                        If _Dif_GRI_Ud1 Then
                            _Fila_GRI.Item("GRI_Idmaeedo_Aj") = _Idmaeedo
                            _Fila_GRI.Item("Nro_GRI_Stock_Cero") = "GRI-" & _Nro_GRI_Stock_Cero
                        End If

                    Next

                    AddToLog("Dejar Stock en Cero", "GRI Nro: " & _Nro_GRI_Stock_Cero & ", Generada correctamente")
                    System.Windows.Forms.Application.DoEvents()
                End If


            End If


            ' ********* GRI DE AJUSTE DEFINITIVA

            Dim GRI_Def_Object As Double ' Object
            'GRI_Def_Object = Tbl_Detalle_Aj.Compute("Sum(CantidadUd1)", "CantidadUd1 > 0")

            For Each Fl As DataRow In Tbl_Detalle_Aj.Rows
                Dim Cant = Fl.Item("CantidadUd1")
                GRI_Def_Object += Cant
            Next


            If CBool(GRI_Def_Object) Then

                AddToLog("GRI AJUSTE DEFINITIVA", "Generando GRI de ajuste definitiva...")
                System.Windows.Forms.Application.DoEvents()

                _Row_GRI_Ajuste_Definitivo = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Ajuste)

                If (_Row_GRI_Ajuste_Definitivo Is Nothing) Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GRI de ajuste stock definitivo!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else


                    Dim _Idmaeedo As Integer = _Row_GRI_Ajuste_Definitivo.Item("IDMAEEDO")
                    Dim _Nro_GRI_Ajuste_Stock = _Row_GRI_Ajuste_Definitivo.Item("NUDO")

                    For Each _Fila_GRI_Aj As DataRow In Tbl_Detalle_Aj.Rows

                        Dim _Gri_Def_Object As Boolean = CBool(_Fila_GRI_Aj.Item("CantidadUd1"))

                        If _Gri_Def_Object Then
                            _Fila_GRI_Aj.Item("IDMAEEDO_Aj") = _Idmaeedo
                            _Fila_GRI_Aj.Item("Nro_GRI_Ajuste_Stock") = "GRI-" & _Nro_GRI_Ajuste_Stock
                        End If

                    Next


                    AddToLog("GRI AJUSTE DEFINITIVA", "GRI Nro: " & _Nro_GRI_Ajuste_Stock & ", Generada correctamente")
                    System.Windows.Forms.Application.DoEvents()
                End If


            End If


            AddToLog("Respaldando información", "Termanando el proceso...")
            System.Windows.Forms.Application.DoEvents()


            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = Tbl_Detalle_Aj.Rows.Count

            Contador = 0


            'REPASA NUEVAMENTE TODOS LOS PRODUCTOS Y ACTUALIZA LOS STOCK EN LA TABLA MAEST

            For Each Fila As DataRow In Tbl_Detalle_Aj.Rows

                System.Windows.Forms.Application.DoEvents()

                With Fila

                    Dim _Codigo As String = .Item("CodigoPr")
                    Dim _Descripcion As String = .Item("Descripcion")

                    Dim _CodBarras As String = .Item("CodBarras")
                    Dim _Rtu As String = .Item("Rtu")
                    Dim _CantidadUd1 As String = .Item("CantidadUd1")
                    Dim _CantidadUd2 As String = .Item("CantidadUd2")
                    Dim _CostoUnitUd1 As String = .Item("CostoUnitUd1")
                    Dim _TotalCostoUd1 As String = .Item("TotalCostoUd1")
                    Dim _Dif_GRI_Ud1 As Double = .Item("Dif_GRI_Ud1")
                    Dim _Dif_GDI_Ud1 As Double = .Item("Dif_GDI_Ud1")

                    Dim _GDI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GDI_Idmaeedo_Aj"), 0)
                    Dim _GRI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GRI_Idmaeedo_Aj"), 0)
                    Dim _IDMAEEDO_Aj As Integer = NuloPorNro(.Item("IDMAEEDO_Aj"), 0)

                    Dim _Nro_GDI_Stock_Cero = .Item("Nro_GDI_Stock_Cero")
                    Dim _Nro_GRI_Stock_Cero = .Item("Nro_GRI_Stock_Cero")
                    Dim _Nro_GRI_Ajuste_Stock = .Item("Nro_GRI_Ajuste_Stock")

                    Dim _Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")

                    If Not ChkDejaStockCero.Checked Then

                        Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TmpInv_InvParcial (Empresa,Sucursal,Bodega,CodigoPr," &
                                       "CodBarras,Descripcion,Rtu,CantidadUd1,CantidadUd2,CostoUnitUd1," &
                                       "TotalCostoUd1,FechaInv,HoraInv," &
                                       "Levantado,DejaStockCero," &
                                       "GDI_Idmaeedo_Aj,Nro_GDI_Stock_Cero," &
                                       "GRI_Idmaeedo_Aj,Nro_GRI_Stock_Cero," &
                                       "IDMAEEDO_Aj,Nro_GRI_Ajuste_Stock) Values " & vbCrLf &
                                       "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _CodBarras &
                                       "','" & _Descripcion & "'," & De_Num_a_Tx_01(_Rtu, 5) &
                                       "," & De_Num_a_Tx_01(_CantidadUd1, 5) & "," & De_Num_a_Tx_01(_CantidadUd2, 5) &
                                       "," & De_Num_a_Tx_01(_CostoUnitUd1, 5) & "," & De_Num_a_Tx_01(_TotalCostoUd1, 5) &
                                       ",'" & _Fecha & "',Getdate(),1,0" &
                                       "," & _GDI_Idmaeedo_Aj & ",'" & _Nro_GDI_Stock_Cero &
                                       "'," & _GRI_Idmaeedo_Aj & ",'" & _Nro_GRI_Stock_Cero &
                                       "'," & _IDMAEEDO_Aj & ",'" & _Nro_GRI_Ajuste_Stock & "')" & vbCrLf &
                                       "UPDATE MAEPR SET ATPR = '' WHERE KOPR = '" & _Codigo & "'"

                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial Set TotalCostoUd1 = CostoUnitUd1*CantidadUd1" & vbCrLf &
                                   "TotalCostoUd2 = CostoUnitUd1*(CantidadUd1*Rtu)"

                    'Consulta_sql = "UPDATE MAEPR SET ATPR = '' WHERE KOPR = '" & _Codigo & "'"
                    ' _Sql.Ej_consulta_IDU(Consulta_Sql)


                    LblEstado.Text = "Desocultando productos... , " & Contador + 1 & " de " &
                                     Tbl_Detalle_Aj.Rows.Count & ",Producto: " & _Descripcion & ""



                End With


                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Tbl_Detalle_Aj.Rows.Count) 'Mas
                Progreso_Cont.Value += 1

            Next

            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

            Return True
        Catch ex As Exception
            'myTrans.Rollback()
            MessageBoxEx.Show(ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            AddToLog("PROBLEMAS DE EJECUCION!!!!", "Transaccion desecha")
            Return False
        End Try
    End Function

    Private Sub Frm_InvParc_06_ProcesarDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class
