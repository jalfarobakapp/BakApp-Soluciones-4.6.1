Imports System.IO
Imports BkSpecialPrograms.LsValiciones
Imports DevComponents.DotNetBar

Public Class Frm_Crear_Guias_De_Ajuste_De_Stock

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Tbl_Productos As DataTable

    Dim _Row_GDI_Ajuste As DataRow
    Dim _Row_GRI_Ajuste As DataRow
    Dim _Row_GRI_Ajuste_Definitivo As DataRow

    Dim _Empresa As String
    Dim _Sucursal As String
    Dim _Bodega As String

    Dim _Datos_Procesados As Boolean

    Dim _Ajuste_PM As Boolean
    Dim _Row_InvParcial_Inventarios As DataRow

    Dim Frm_Doc As Frm_Formulario_Documento
    Enum TipoGrabacion
        Con_Numeración = 0
        EnBlanco = 1
        Puros_Ceros = 2
    End Enum

    Public ReadOnly Property Pro_Row_GDI_Ajuste_Cero() As DataRow
        Get
            Return _Row_GDI_Ajuste
        End Get
    End Property

    Public ReadOnly Property Pro_Row_GRI_Ajuste_Cero() As DataRow
        Get
            Return _Row_GRI_Ajuste
        End Get
    End Property

    Public ReadOnly Property Pro_Datos_Procesados() As Boolean
        Get
            Return _Datos_Procesados
        End Get
    End Property

    Private _IdInventario As Integer

    Public Sub New(Row_InvParcial_Inventarios As DataRow,
                   Tbl_Productos As DataTable,
                   Fecha_Ajuste As Date,
                   Ajuste_PM As Boolean,
                   Dejar_Doc_Final_Del_Dia As Boolean,
                   _IdInventario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Row_InvParcial_Inventarios = Row_InvParcial_Inventarios
        _Tbl_Productos = Tbl_Productos
        DtFechaInv.Value = Fecha_Ajuste
        _Ajuste_PM = Ajuste_PM
        Me._IdInventario = _IdInventario

        Chk_Dejar_Doc_Final_Del_Dia.Checked = Dejar_Doc_Final_Del_Dia

        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Crear_Guias_De_Ajuste_De_Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Empresa = _Row_InvParcial_Inventarios.Item("Empresa")
        _Sucursal = _Row_InvParcial_Inventarios.Item("Sucursal")
        _Bodega = _Row_InvParcial_Inventarios.Item("Bodega")

        Btn_Cancelar.Visible = False

    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As EventArgs) Handles Btn_Procesar.Click

        If ChkDejaStockCero.Checked Then
            _Datos_Procesados = Fx_Procesar_Ajustes_DejaStockCero(_Tbl_Productos)
        Else
            _Datos_Procesados = Fx_Procesar_Ajustes(_Tbl_Productos)
        End If

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

            Sb_ConsolidarStock()

            Dim _Nro_GDI_Ajuste As String
            Dim _Nro_GRI_Ajuste As String

            If Not (_Row_GDI_Ajuste Is Nothing) Then
                _Nro_GDI_Ajuste = _Row_GDI_Ajuste.Item("NUDO")
                _Nro_GDI_Ajuste = "Guía de ajuste GDI: " & _Nro_GDI_Ajuste & vbCrLf
            End If

            If Not (_Row_GRI_Ajuste Is Nothing) Then
                _Nro_GRI_Ajuste = _Row_GRI_Ajuste.Item("NUDO")
                _Nro_GRI_Ajuste = "Guía de ajuste GRI: " & _Nro_GRI_Ajuste & vbCrLf
            End If

            Dim _Msg As String

            If String.IsNullOrEmpty(_Nro_GDI_Ajuste) And String.IsNullOrEmpty(_Nro_GRI_Ajuste) Then
                _Msg = "No fue necesario generar guías de ajuste"
            Else
                _Msg = "Proceso Generado correctamente" & vbCrLf & vbCrLf &
                                              "Guías: " & vbCrLf &
                                              _Nro_GDI_Ajuste & _Nro_GRI_Ajuste
            End If

            MessageBoxEx.Show(Me, _Msg, "Ajuste de inventario", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        End If

    End Sub

    Private Sub Sb_ConsolidarStock()

        Dim Chk_Confirmar_Lectura As New Command
        Chk_Confirmar_Lectura.Checked = False
        Chk_Confirmar_Lectura.Name = "Chk_Confirmar_Lectura"
        Chk_Confirmar_Lectura.Text = "CONFIRMO CONSOLIDAR EL STOCK"

        Dim _Opciones As Command = Chk_Confirmar_Lectura

        Dim _Info As New TaskDialogInfo("Consolidar Stock",
                                        eTaskDialogIcon.Help,
      "¿Desea consolidar el stock de los productos inventariados?", "",
      eTaskDialogButton.Yes + eTaskDialogButton.No, eTaskDialogBackgroundColor.Red, Nothing, Nothing,
      _Opciones, Nothing, Nothing)

        Dim _Resultado As eTaskDialogResult = TaskDialog.Show(_Info)

        If _Resultado = eTaskDialogResult.Yes Then

            If Not Chk_Confirmar_Lectura.Checked Then
                MessageBoxEx.Show(Me, "Debe confirmar la lectura de la alerta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Sb_ConsolidarStock()
                Return
            End If

            Dim _Filtro_Productos As String = Generar_Filtro_IN(_Tbl_Productos, "", "CodigoPr", False, False, "'")

            Dim Fm As New Frm_Consolidacion_Stock_PP(_Filtro_Productos)
            Fm.Pro_Ejecutar_Automaticamente = True
            Fm.ShowDialog(Me)
            Fm.Dispose()

        Else

            If Chk_Confirmar_Lectura.Checked Then

                If MessageBoxEx.Show(Me, "Confirmo la consolidación del stock, pero se indicó que NO." & vbCrLf &
                                     "Debe desmarcar la opción ""CONFIRMO CONSOLIDAR EL STOCK""." & vbCrLf &
                                     "Si NO desea consolidar el stock y luego seleccionar NO", "Validación",
                                     MessageBoxButtons.OK, MessageBoxIcon.Stop) Then
                    Sb_ConsolidarStock()
                End If

            End If

        End If

    End Sub

    Private Sub AddToLog(Accion As String,
                         Descripcion As String)
        TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()
    End Sub

    Function Fx_Procesar_Ajustes(Tbl_Detalle_Aj As DataTable)

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

            Dim Fecha As String = FechaInv
            Dim Tabla As New DataTable

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

                Dim _Dif_GDI_Ud1 As Double = 0
                Dim _Dif_GRI_Ud1 As Double = 0


                LblEstado.Text = "Consolidando Stock, " & Contador + 1 & " de " &
                                 Tbl_Detalle_Aj.Rows.Count & ",Producto: " & _Descripcion & ""

                Dim _Stock_Fi(1) As Double
                Dim _Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
                Dim _Dif As Double

                _Stock_Fi = Stock_Fi_A_Una_Fecha_X_Producto(_Codigo, _Empresa, _Sucursal, _Bodega, DtFechaInv.Value)

                _Dif = _Stock_Fi(0) - _CantidadUd1

                If _Dif > 0 Then
                    _Dif_GDI_Ud1 = _Dif
                ElseIf _Dif < 0 Then
                    _Dif_GRI_Ud1 = _Dif * -1
                ElseIf _Dif = 0 Then
                    _Dif_GDI_Ud1 = 0
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


            AddToLog("Guias de ajuste", "Generando Guias de Ajuste...")
            System.Windows.Forms.Application.DoEvents()


            ' ********* GDI DE AJUSTE GDI EN CASO DE SER NECESARIA

            Dim GDI_Object As Object

            For Each _Fila_GDI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GDI_Ud1 = _Fila_GDI.Item("Dif_GDI_Ud1")
                GDI_Object += Dif_GDI_Ud1
            Next

            If CBool(GDI_Object) Then

                AddToLog("Ajuste de Stock", "Generando GDI de Ajuste...")
                System.Windows.Forms.Application.DoEvents()

                _Mensaje = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GDI_Stock_Cero)

                'If Not _Mensaje.EsCorrecto Then
                '    Return False
                'End If

                _Row_GDI_Ajuste = _Mensaje.Tag 'Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GDI_Stock_Cero)

                If (_Row_GDI_Ajuste Is Nothing) Then 'NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GDI de ajuste!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GDI_Ajuste.Item("IDMAEEDO")
                    Dim _Nro_GDI_Stock_Cero = _Row_GDI_Ajuste.Item("NUDO")

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

            ' ********* GRI DE AJUSTE GDI EN CASO DE SER NECESARIA

            Dim GRI_Object As Object

            For Each _Fila_GRI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GRI_Ud1 = _Fila_GRI.Item("Dif_GRI_Ud1")
                GRI_Object += Dif_GRI_Ud1
            Next

            If CBool(GRI_Object) Then

                AddToLog("Ajuste de stock", "Generando GRI de Ajuste...")
                System.Windows.Forms.Application.DoEvents()

                _Mensaje = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Stock_Cero)

                'If Not _Mensaje.EsCorrecto Then
                '    Return False
                'End If

                _Row_GRI_Ajuste = _Mensaje.Tag

                If (_Row_GRI_Ajuste Is Nothing) Then 'If NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GRI de ajuste!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GRI_Ajuste.Item("IDMAEEDO")
                    Dim _Nro_GRI_Stock_Cero = _Row_GRI_Ajuste.Item("NUDO")

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
                    Dim _CantidadUd1 As Double = .Item("CantidadUd1")
                    Dim _CantidadUd2 As Double = .Item("CantidadUd2")
                    Dim _CostoUnitUd1 As String = .Item("CostoUnitUd1")
                    Dim _TotalCostoUd1 As String = .Item("TotalCostoUd1")
                    Dim _Dif_GRI_Ud1 As Double = .Item("Dif_GRI_Ud1")
                    Dim _Dif_GDI_Ud1 As Double = .Item("Dif_GDI_Ud1")

                    Dim _GDI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GDI_Idmaeedo_Aj"), 0)
                    Dim _GRI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GRI_Idmaeedo_Aj"), 0)
                    Dim _IDMAEEDO_Aj As Integer = NuloPorNro(.Item("IDMAEEDO_Aj"), 0)

                    Dim _Foto_Stock_Ud1 As Double = .Item("Stock_Ud1")
                    Dim _Foto_Stock_Ud2 As Double = .Item("Stock_Ud2")

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
                                       "IDMAEEDO_Aj,Nro_GRI_Ajuste_Stock,Foto_Stock_Ud1,Foto_Stock_Ud2) Values " & vbCrLf &
                                       "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _CodBarras &
                                       "','" & _Descripcion & "'," & De_Num_a_Tx_01(_Rtu, 5) &
                                       "," & De_Num_a_Tx_01(_CantidadUd1, 5) & "," & De_Num_a_Tx_01(_CantidadUd2, 5) &
                                       "," & De_Num_a_Tx_01(_CostoUnitUd1, 5) & "," & De_Num_a_Tx_01(_TotalCostoUd1, 5) &
                                       ",'" & _Fecha & "',Getdate(),1,0" &
                                       "," & _GDI_Idmaeedo_Aj & ",'" & _Nro_GDI_Stock_Cero &
                                       "'," & _GRI_Idmaeedo_Aj & ",'" & _Nro_GRI_Stock_Cero &
                                       "'," & _IDMAEEDO_Aj & ",'" & _Nro_GRI_Ajuste_Stock &
                                       "'," & De_Num_a_Tx_01(_Foto_Stock_Ud1, 5) &
                                       "," & De_Num_a_Tx_01(_Foto_Stock_Ud2, 5) & ")" & vbCrLf &
                                       "UPDATE MAEPR SET ATPR = '' WHERE KOPR = '" & _Codigo & "'"
                        _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)

                    End If

                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial Set TotalCostoUd1 = CostoUnitUd1*CantidadUd1" & vbCrLf &
                                   "TotalCostoUd2 = CostoUnitUd1*(CantidadUd1*Rtu)"

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

    Function Fx_Procesar_Ajustes_DejaStockCero(Tbl_Detalle_Aj As DataTable)

        Dim _Mensaje As LsValiciones.Mensajes

        Try

            Dim Fecha As String = FechaInv
            Dim Tabla As New DataTable

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = Tbl_Detalle_Aj.Rows.Count

            AddToLog("Iniciando Analisis", "-----------------------------------------")
            AddToLog("Iniciando Analisis", "Revisando si existen productos que procesar...")
            AddToLog("Consolidación de Stock...", "Preparandose para la consilidación de Stock")

            Dim Contador As Integer = 0

            ChkDejaStockCero.Enabled = False
            Chk_CambiarCostoEnLCProducto.Enabled = False
            Chk_ConsolidarStockAlFinalizar.Enabled = False
            Chk_ConsolidarStockAlFinalizar.Enabled = False
            Btn_Procesar.Enabled = False
            Btn_Cancelar.Visible = True


            For Each Fila As DataRow In Tbl_Detalle_Aj.Rows

                System.Windows.Forms.Application.DoEvents()

                Dim _Codigo As String = Fila.Item("CodigoPr")
                Dim _Descripcion As String = Fila.Item("Descripcion")

                Dim _CantidadUd1 As Double = Fila.Item("CantidadUd1")
                Dim _CantidadUd2 As Double = Fila.Item("CantidadUd2")

                Dim _Dif_GDI_Ud1 As Double = 0
                Dim _Dif_GRI_Ud1 As Double = 0


                Dim _Stock_Fi(1) As Double
                Dim _Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")
                Dim _Dif As Double

                Dim _Stock_Ud1 As Double = Math.Round(_Stock_Fi(0), 5)
                Dim _Stock_Ud2 As Double = Math.Round(_Stock_Fi(1), 5)

                If CBool(_IdInventario) Then

                    _Dif = Fila.Item("Stock_Ud1")

                    _Stock_Ud1 = Fila.Item("Stock_Ud1")
                    _Stock_Ud2 = Fila.Item("Stock_Ud2")

                Else

                    LblEstado.Text = "Consolidando Stock, " & Contador + 1 & " de " &
                                 Tbl_Detalle_Aj.Rows.Count & ",Producto: " & _Descripcion & ""

                    _Stock_Fi = Stock_Fi_A_Una_Fecha_X_Producto(_Codigo, _Empresa, _Sucursal, _Bodega, DtFechaInv.Value)

                    _Dif = _Stock_Fi(0)

                    _Stock_Ud1 = Math.Round(_Stock_Fi(0), 5)
                    _Stock_Ud2 = Math.Round(_Stock_Fi(1), 5)

                End If

                If _Dif > 0 Then
                    _Dif_GDI_Ud1 = _Dif
                ElseIf _Dif < 0 Then
                    _Dif_GRI_Ud1 = _Dif * -1
                ElseIf _Dif = 0 Then
                    _Dif_GDI_Ud1 = 0
                End If

                Fila.Item("Dif_GDI_Ud1") = _Dif_GDI_Ud1
                Fila.Item("Dif_GRI_Ud1") = _Dif_GRI_Ud1

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

            If Chk_ConsolidarStockAlFinalizar.Checked Then
                'Exit Function
                LblEstado.Text = "Productos consolidados correctamente, Stock físico"
                AddToLog("Consolidación de Stock...", "Stock consolidaddo correctamente")
            End If

            System.Windows.Forms.Application.DoEvents()

            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0


            AddToLog("Guias de ajuste", "Generando Guias de Ajuste...")
            System.Windows.Forms.Application.DoEvents()


            ' ********* GDI DE AJUSTE GDI EN CASO DE SER NECESARIA

            Dim GDI_Object As Object

            For Each _Fila_GDI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GDI_Ud1 = _Fila_GDI.Item("Dif_GDI_Ud1")
                GDI_Object += Dif_GDI_Ud1
            Next

            If CBool(GDI_Object) Then

                AddToLog("Ajuste de Stock", "Generando GDI de Ajuste...")
                System.Windows.Forms.Application.DoEvents()

                '_Row_GDI_Ajuste = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GDI_Stock_Cero)

                _Mensaje = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GDI_Stock_Cero)

                'If Not _Mensaje.EsCorrecto Then
                '    Return False
                'End If

                _Row_GDI_Ajuste = _Mensaje.Tag

                If (_Row_GDI_Ajuste Is Nothing) Then 'NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GDI de ajuste!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GDI_Ajuste.Item("IDMAEEDO")
                    Dim _Nro_GDI_Stock_Cero = _Row_GDI_Ajuste.Item("NUDO")

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

            ' ********* GRI DE AJUSTE GDI EN CASO DE SER NECESARIA

            Dim GRI_Object As Object

            For Each _Fila_GRI As DataRow In Tbl_Detalle_Aj.Rows
                Dim Dif_GRI_Ud1 = _Fila_GRI.Item("Dif_GRI_Ud1")
                GRI_Object += Dif_GRI_Ud1
            Next

            If CBool(GRI_Object) Then

                AddToLog("Ajuste de stock", "Generando GRI de Ajuste...")
                System.Windows.Forms.Application.DoEvents()

                '_Row_GRI_Ajuste = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Stock_Cero)

                _Mensaje = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Stock_Cero)

                'If Not _Mensaje.EsCorrecto Then
                '    Return False
                'End If

                _Row_GRI_Ajuste = _Mensaje.Tag

                If (_Row_GRI_Ajuste Is Nothing) Then 'If NroDoc = Nothing Then
                    AddToLog("Proceso interrumpido", "Problema en la generación de Guía GRI de ajuste!")
                    AddToLog("Proceso interrumpido", "Fin del proceso")
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                Else

                    Dim _Idmaeedo As Integer = _Row_GRI_Ajuste.Item("IDMAEEDO")
                    Dim _Nro_GRI_Stock_Cero = _Row_GRI_Ajuste.Item("NUDO")

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


            '_Row_GRI_Ajuste_Definitivo = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Ajuste)

            _Mensaje = Fx_Generar_Guia_De_Ajuste(Enum_Tido_Doc_Ajuste.GRI_Ajuste)

            'If Not _Mensaje.EsCorrecto Then
            '    Return False
            'End If

            _Row_GRI_Ajuste_Definitivo = _Mensaje.Tag

            If (_Row_GRI_Ajuste_Definitivo Is Nothing) Then 'NroDoc = Nothing Then
                AddToLog("Proceso interrumpido", "Problema en la generación de Guía GRI de ajuste!")
                AddToLog("Proceso interrumpido", "Fin del proceso")
                System.Windows.Forms.Application.DoEvents()
                Return False
            Else

                Dim _Idmaeedo As Integer = _Row_GRI_Ajuste_Definitivo.Item("IDMAEEDO")
                Dim _Nro_GRI_AjusteDef = _Row_GRI_Ajuste_Definitivo.Item("NUDO")

                For Each _Fila_GRI_Def As DataRow In Tbl_Detalle_Aj.Rows

                    Dim _GRI_Ud1 As Boolean = CBool(_Fila_GRI_Def.Item("CantidadUd1"))

                    If _GRI_Ud1 Then
                        _Fila_GRI_Def.Item("IDMAEEDO_Aj") = _Idmaeedo
                        _Fila_GRI_Def.Item("Nro_GRI_Ajuste_Stock") = "GRI-" & _Nro_GRI_AjusteDef
                    End If

                Next

                AddToLog("Graba GRI Ajuste definitiva", "GRI Nro: " & _Nro_GRI_AjusteDef & ", Generada correctamente")
                System.Windows.Forms.Application.DoEvents()
            End If


            AddToLog("Respaldando información", "Terminando el proceso...")
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
                    Dim _CantidadUd1 As Double = .Item("CantidadUd1")
                    Dim _CantidadUd2 As Double = .Item("CantidadUd2")
                    Dim _CostoUnitUd1 As String = .Item("CostoUnitUd1")
                    Dim _TotalCostoUd1 As String = .Item("TotalCostoUd1")
                    Dim _Dif_GRI_Ud1 As Double = .Item("Dif_GRI_Ud1")
                    Dim _Dif_GDI_Ud1 As Double = .Item("Dif_GDI_Ud1")

                    Dim _GDI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GDI_Idmaeedo_Aj"), 0)
                    Dim _GRI_Idmaeedo_Aj As Integer = NuloPorNro(.Item("GRI_Idmaeedo_Aj"), 0)
                    Dim _IDMAEEDO_Aj As Integer = NuloPorNro(.Item("IDMAEEDO_Aj"), 0)

                    Dim _Foto_Stock_Ud1 As Double = .Item("Stock_Ud1")
                    Dim _Foto_Stock_Ud2 As Double = .Item("Stock_Ud2")

                    Dim _Nro_GDI_Stock_Cero = .Item("Nro_GDI_Stock_Cero")
                    Dim _Nro_GRI_Stock_Cero = .Item("Nro_GRI_Stock_Cero")
                    Dim _Nro_GRI_Ajuste_Stock = .Item("Nro_GRI_Ajuste_Stock")

                    Dim _Fecha As String = Format(DtFechaInv.Value, "yyyyMMdd")


                    Consulta_sql = "Insert Into " & _Global_BaseBk & "Zw_TmpInv_InvParcial (Empresa,Sucursal,Bodega,CodigoPr," &
                                   "CodBarras,Descripcion,Rtu,CantidadUd1,CantidadUd2,CostoUnitUd1," &
                                   "TotalCostoUd1,FechaInv,HoraInv," &
                                   "Levantado,DejaStockCero," &
                                   "GDI_Idmaeedo_Aj,Nro_GDI_Stock_Cero," &
                                   "GRI_Idmaeedo_Aj,Nro_GRI_Stock_Cero," &
                                   "IDMAEEDO_Aj,Nro_GRI_Ajuste_Stock,Foto_Stock_Ud1,Foto_Stock_Ud2) Values " & vbCrLf &
                                   "('" & _Empresa & "','" & _Sucursal & "','" & _Bodega & "','" & _Codigo & "','" & _CodBarras &
                                   "','" & _Descripcion & "'," & De_Num_a_Tx_01(_Rtu, 5) &
                                   "," & De_Num_a_Tx_01(_CantidadUd1, 5) & "," & De_Num_a_Tx_01(_CantidadUd2, 5) &
                                   "," & De_Num_a_Tx_01(_CostoUnitUd1, 5) & "," & De_Num_a_Tx_01(_TotalCostoUd1, 5) &
                                   ",'" & _Fecha & "',Getdate(),1,0" &
                                   "," & _GDI_Idmaeedo_Aj & ",'" & _Nro_GDI_Stock_Cero &
                                   "'," & _GRI_Idmaeedo_Aj & ",'" & _Nro_GRI_Stock_Cero &
                                   "'," & _IDMAEEDO_Aj & ",'" & _Nro_GRI_Ajuste_Stock &
                                   "'," & De_Num_a_Tx_01(_Foto_Stock_Ud1, 5) &
                                   "," & De_Num_a_Tx_01(_Foto_Stock_Ud2, 5) & ")" & vbCrLf &
                                   "UPDATE MAEPR SET ATPR = '' WHERE KOPR = '" & _Codigo & "'"
                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(Consulta_sql)


                    Consulta_sql = "Update " & _Global_BaseBk & "Zw_TmpInv_InvParcial Set TotalCostoUd1 = CostoUnitUd1*CantidadUd1" & vbCrLf &
                                   "TotalCostoUd2 = CostoUnitUd1*(CantidadUd1*Rtu)"

                    LblEstado.Text = "Desocultando productos... , " & Contador + 1 & " de " &
                                     Tbl_Detalle_Aj.Rows.Count & ",Producto: " & _Descripcion & ""

                End With

                System.Windows.Forms.Application.DoEvents()
                Contador += 1
                Progreso_Porc.Value = ((Contador * 100) / Tbl_Detalle_Aj.Rows.Count) 'Mas
                Progreso_Cont.Value += 1

            Next

            Return True
        Catch ex As Exception
            'myTrans.Rollback()
            MessageBoxEx.Show(ex.Message, "Transaccion desecha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'SQL_ServerClass.Sb_Cerrar_Conexion(cn2)
            AddToLog("PROBLEMAS DE EJECUCION!!!!", "Transaccion desecha")
            Return False
        Finally

            ChkDejaStockCero.Enabled = True
            Chk_CambiarCostoEnLCProducto.Enabled = True
            Chk_ConsolidarStockAlFinalizar.Enabled = True
            Chk_ConsolidarStockAlFinalizar.Enabled = True
            Btn_Procesar.Enabled = True
            Btn_Cancelar.Visible = False

            Progreso_Porc.Value = 0
            Progreso_Cont.Value = 0

        End Try
    End Function

    Enum Enum_Tido_Doc_Ajuste
        GDI_Stock_Cero
        GRI_Stock_Cero
        GRI_Ajuste
    End Enum

    Function Fx_Generar_Guia_De_Ajuste(_Tipo_Documento As Enum_Tido_Doc_Ajuste) As LsValiciones.Mensajes

        Dim _Mensaje As New LsValiciones.Mensajes

        Try

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
                    _Doc = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Despacho_Interna ' 4
                    _Observaciones = "Ajuste de Stock generado desde BakApp, Documento deja Stock en Cero."
                Case Enum_Tido_Doc_Ajuste.GRI_Stock_Cero
                    _Tido = "GRI"
                    _Campo_Cantidad = "Dif_GRI_Ud1"
                    _Doc = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna '5
                    _Observaciones = "Ajuste de Stock generado desde BakApp, Documento deja Stock en Cero."
                Case Enum_Tido_Doc_Ajuste.GRI_Ajuste
                    _Tido = "GRI"
                    _Campo_Cantidad = "CantidadUd1"
                    _Doc = csGlobales.Mod_Enum_Listados_Globales.Enum_Tipo_Documento.Guia_Recepcion_Interna
                    _Observaciones = "Ajuste de Stock generado desde BakApp, Documento de ajuste definitivo. Ingreso de stock."
            End Select

            AddToLog("Generando documento " & _Tido, _Observaciones)

            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0

            Progreso_Porc.Maximum = 100
            Progreso_Cont.Maximum = _Tbl_Productos.Rows.Count

            Frm_Doc = New Frm_Formulario_Documento(_Tido, _Doc, False, False, False,
                                                   True, Chk_Dejar_Doc_Final_Del_Dia.Checked)
            Frm_Doc.ForzarDecimalesEnUnidadesEnteras = True
            Frm_Doc.Pro_RowEntidad = _Row_Entidad
            Frm_Doc.Sb_Crear_Documento_Interno_Con_Tabla(Me, _Tbl_Productos, DtFechaInv.Value,
                                                    "CodigoPr", _Campo_Cantidad, "CostoUnitUd1",
                                                    _Observaciones,
                                                    False, False,,,
                                                    Progreso_Porc, Progreso_Cont, _Tbl_Productos.Rows.Count, LblEstado, False)

            LblEstado.Text = String.Empty
            Progreso_Cont.Value = 0
            Progreso_Porc.Value = 0

            If Frm_Doc.Cancelar Then
                _Mensaje.Cancelado = True
                Throw New System.Exception("Acción cancelada por el usuario")
            End If

            Frm_Doc.NoConsolidarNuncaStock = Not Chk_ConsolidarStockAlFinalizar.Checked

            AddToLog("Generando documento " & _Tido, "Se creara la " & _Tido & ", espere por favor...")

            Dim Fm_Espera As New Frm_Form_Esperar
            Fm_Espera.Pro_Texto = "GRABANDO DOCUMENTO, POR FAVOR ESPERE..."
            Fm_Espera.BarraCircular.IsRunning = True
            Fm_Espera.Show()

            Dim _Msj_Doc As LsValiciones.Mensajes = Frm_Doc.Fx_Grabar_Documento(False)

            Fm_Espera.Close()
            Fm_Espera.Dispose()
            Fm_Espera = Nothing

            Frm_Doc.Dispose()

            Dim _Row As DataRow

            If Not _Msj_Doc.EsCorrecto Then
                Throw New System.Exception(_Msj_Doc.Mensaje)
            End If

            Consulta_sql = "Select Top 1 * From MAEEDO Where IDMAEEDO = " & _Msj_Doc.Id
            _Row = _Sql.Fx_Get_DataRow(Consulta_sql)

            _Mensaje.EsCorrecto = True
            _Mensaje.Detalle = "Documento generado correctamente"
            _Mensaje.Tag = _Row
            _Mensaje.Icono = MessageBoxIcon.Information

        Catch ex As Exception
            _Mensaje.EsCorrecto = False
            _Mensaje.Detalle = "Problema al generar documento"
            _Mensaje.Mensaje = ex.Message
            _Mensaje.Icono = MessageBoxIcon.Stop
        End Try

        Return _Mensaje

    End Function

    Private Function Stock_Fi_A_Una_Fecha_X_Producto(_Codigo As String,
                                                _Empresa As String,
                                                _Sucursal As String,
                                                _Bodega As String,
                                                _Fecha As Date) As Double()

        _Sql.Sb_Eliminar_Tabla_De_Paso("Zw_TblStockConsolid")

        Consulta_sql = My.Resources._23_ConsultasSQL.Consolidacion_Stock_Fisico_X_producto
        Consulta_sql = Replace(Consulta_sql, "#Empresa#", _Empresa)
        Consulta_sql = Replace(Consulta_sql, "#Sucursal#", _Sucursal)
        Consulta_sql = Replace(Consulta_sql, "#Bodega#", _Bodega)
        Consulta_sql = Replace(Consulta_sql, "#@Codigo#", _Codigo)
        Consulta_sql = Replace(Consulta_sql, "#Fecha#", Format(_Fecha, "yyyyMMdd"))

        Dim Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

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

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Frm_Doc.Cancelar = True
    End Sub

End Class
