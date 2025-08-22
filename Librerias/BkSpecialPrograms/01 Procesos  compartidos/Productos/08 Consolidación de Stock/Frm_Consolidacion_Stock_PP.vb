Imports DevComponents.DotNetBar

Public Class Frm_Consolidacion_Stock_PP

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _TblProductos As DataTable
    Dim _Codigo, _Descripcion As String
    Dim _Cancelar As Boolean

    Dim _Tbl_Foto_Stock As DataTable

    Dim _Ejecutar_Automaticamente As Boolean
    Dim _Filtro_In_Productos As String
    Dim _Consolidacion_terminada As Boolean

    Public ReadOnly Property Pro_Consolidacion_terminada() As Boolean
        Get
            Return _Consolidacion_terminada
        End Get
    End Property
    Public Property Pro_Ejecutar_Automaticamente() As Boolean
        Get
            Return _Ejecutar_Automaticamente
        End Get
        Set(value As Boolean)
            _Ejecutar_Automaticamente = value
        End Set
    End Property

    Public Sub New(Filtro_In_Productos As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _Filtro_In_Productos = Filtro_In_Productos

        Consulta_sql = "Select * From MAEPR Where KOPR In " & Filtro_In_Productos
        _TblProductos = _Sql.Fx_Get_DataTable(Consulta_sql)


        Sb_Color_Botones_Barra(Bar2)

    End Sub

    Private Sub Frm_Consolidacion_Stock_PP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Tiempo_Accion_Automatico.Enabled = _Ejecutar_Automaticamente
    End Sub

    Sub Sb_Consolidar_Stock(Tabla_Producto As DataTable)

        Dim _SqlQuery As String

        BtnCancelar.Enabled = True
        BtnProcesar.Enabled = False
        Me.ControlBox = False

        _Cancelar = False

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = Tabla_Producto.Rows.Count
        Barra_Progreso.Maximum = Tabla_Producto.Rows.Count

        Dim _Contador As Integer = 0
        Dim _Contador_Consolidados As Integer = 0
        Dim _Cant_Productos As Integer = Tabla_Producto.Rows.Count

        Dim _Consolidar_Stock As New Class_Consolidar_Stock()

        AddToLog("Consolidación Stock", FormatNumber(_TblProductos.Rows.Count, 0) & " Productos")

        For Each _Fila As DataRow In Tabla_Producto.Rows

            Dim _consolidado As Boolean

            System.Windows.Forms.Application.DoEvents()

            Dim _Codigo As String = Trim(_Fila.Item("KOPR"))
            Dim _Descripcion As String = Trim(_Fila.Item("NOKOPR"))

            Dim _Dif_GDI_Ud1 As Double = 0
            Dim _Dif_GRI_Ud1 As Double = 0

            Dim _FECHA As Date = FechaDelServidor()

            Consulta_sql = "SELECT EMPRESA,KOSU,KOBO FROM TABBOPR" & Space(1) &
                           "WHERE KOPR = '" & _Codigo & "'" & vbCrLf &
                           "AND EMPRESA+KOSU+KOBO IN (SELECT DISTINCT EMPRESA+SULIDO+BOSULIDO" & Space(1) &
                           "FROM MAEDDO WHERE KOPRCT = '" & _Codigo & "' And EMPRESA = '" & Mod_Empresa & "')"
            Dim _TblBodegasPP As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            LblEstado.Text = "Producto: " & _Codigo & " - " & _Descripcion

            Dim _Stock_ConsUd1 As Double = 0
            Dim _Stock_ConsUd2 As Double = 0

            Dim _Con_Diferencias As Boolean

            If CBool(_TblBodegasPP.Rows.Count) Then

                For Each _Fila_Bod As DataRow In _TblBodegasPP.Rows

                    _SqlQuery = String.Empty

                    Dim _Empresa As String = _Fila_Bod.Item("EMPRESA")
                    Dim _Sucursal As String = _Fila_Bod.Item("KOSU")
                    Dim _Bodega As String = _Fila_Bod.Item("KOBO")

                    If _Consolidar_Stock.Fx_Consolidar_Stock_x_producto_Unico(_Empresa, _Sucursal, _Bodega, _Fila,
                                                                              _Con_Diferencias, Chk_Reservar_Ventas_Pendientes_Bakapp.Checked) Then
                        _consolidado = True
                        _Consolidar_Stock.Fx_Consolidar_Stock_x_producto_Unico_Bakapp(_Empresa, _Sucursal, _Bodega, _Fila)

                    Else

                        _consolidado = False

                    End If

                Next

            End If

            System.Windows.Forms.Application.DoEvents()

            _Contador += 1
            Progreso_Porc.Value = ((_Contador * 100) / _Cant_Productos)
            Progreso_Cont.Value += 1
            Barra_Progreso.Value += 1

            Barra_Progreso.Text = "Consolidando Stock, " & FormatNumber(_Contador + 1, 0) & " de " &
                           FormatNumber(_Cant_Productos, 0)

            If _Cancelar Then
                AddToLog("Consolidación Stock", "Acción cancelada por el usuario")
                MessageBoxEx.Show(Me, "Acción cancelada por el usuario" & vbCrLf &
                                  "Total productos consolidados " & _Contador_Consolidados,
                                  "Cancelar conolidación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit For
            End If

            If _consolidado Then

                Consulta_sql = My.Resources._SQLquery.Consolidacion_Total_MAEPR_MAEPREM_X_producto
                Consulta_sql = Replace(Consulta_sql, "#Empresa#", Mod_Empresa)
                Consulta_sql = Replace(Consulta_sql, "#Codigo#", _Codigo)

                Consulta_sql = Replace(Consulta_sql, "#Tabla_Paso#", _Consolidar_Stock.Pro_Tabla_Paso)
                _Sql.Ej_consulta_IDU(Consulta_sql)

                If _Con_Diferencias Then
                    AddToLog(Trim(_Codigo), _Descripcion & " Consolidado OK, con diferencias!!")
                Else
                    AddToLog(Trim(_Codigo), _Descripcion & " Consolidado OK!!")
                End If
                _Con_Diferencias = False
                _Contador_Consolidados += 1
            End If

        Next

        AddToLog("Consolidación Stock", "Fin consolidación")

        Dim _Tbl_Productos As DataTable = _Consolidar_Stock.Pro_Tbl_Productos_Diferencia

        If _Tbl_Productos.Rows.Count Then
            Dim _Nombre_Archivo As String = "Consolidacion_Stock_" & Format(FechaDelServidor, "yyyyMMdd")
            Dim _Ruta_Archivo As String = String.Empty
            Fx_ExportarTabla_JetExcel_Tabla_Grabar_En_Directorio_Tmp(_Tbl_Productos, _Nombre_Archivo, _Ruta_Archivo)
            AddToLog("Archivo de detalle", _Ruta_Archivo)
        End If

        System.Windows.Forms.Application.DoEvents()

        Barra_Progreso.Text = String.Empty
        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0
        Barra_Progreso.Value = 0

        BtnCancelar.Enabled = False
        BtnProcesar.Enabled = True
        Me.ControlBox = True

        If Not _Ejecutar_Automaticamente Then

            MessageBoxEx.Show(Me, FormatNumber(_Contador_Consolidados, 0) & " Productos consolidados correctamente",
                              "Consolidación stock físico", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim Fm As New Frm_Archivo_TXT
            Fm.Pro_Nombre_Archivo = "Consolidacion_Stock_Bakapp_" & Format(FechaDelServidor, "yyyy_MM_dd" & "_" & _Cant_Productos & "_Prod") & ".txt"
            Fm.Pro_Texto_Log = TxtLog.Text
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If

        If Not _Cancelar Then

            _Consolidacion_terminada = True

        End If

        Me.Close()

    End Sub

    Private Function Stock_A_Una_Fecha_X_Producto(_Row_Producto As DataRow,
                                                  _Empresa As String,
                                                  _Sucursal As String,
                                                  _Bodega As String,
                                                  _Fecha As Date,
                                                  _SQLquery As String) As Double()

        Dim Stock_(1) As Double

        If Not (_Row_Producto Is Nothing) Then

            Dim _Codigo = _Row_Producto.Item("KOPR")
            Dim _Rtu = _Row_Producto.Item("RLUD")

            Dim _Redondeo As Integer

            If _Rtu = 1 Then
                _Redondeo = 0
            Else
                _Redondeo = 5
            End If

            _SQLquery = Replace(_SQLquery, "#Empresa#", _Empresa)
            _SQLquery = Replace(_SQLquery, "#Sucursal#", _Sucursal)
            _SQLquery = Replace(_SQLquery, "#Bodega#", _Bodega)
            _SQLquery = Replace(_SQLquery, "#@Codigo#", _Codigo)
            _SQLquery = Replace(_SQLquery, "#Fecha#", Format(_Fecha, "yyyyMMdd"))
            _SQLquery = Replace(_SQLquery, "Zw_TblStockConsolid", "#Zw_TblStockConsolid")

            Dim Tbl As DataTable = _Sql.Fx_Get_DataTable(_SQLquery)


            If Tbl.Rows.Count > 0 Then

                Stock_(0) = Math.Round(Tbl.Rows(0).Item("CantidadUd1"), _Redondeo)
                Stock_(1) = Math.Round(Tbl.Rows(0).Item("CantidadUd2"), _Redondeo)

            Else

                Stock_(0) = 0
                Stock_(1) = 0

            End If

        Else

            Stock_(0) = 0
            Stock_(1) = 0

        End If

        Return Stock_

    End Function

    Private Sub BtnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles BtnProcesar.Click
        Sb_Consolidar_Stock(_TblProductos)
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        _Cancelar = True
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub AddToLog(Accion As String,
                         Descripcion As String)

        If String.IsNullOrEmpty(Accion) And String.IsNullOrEmpty(Descripcion) Then
            TxtLog.Text += "" & vbCrLf
        Else
            If Not String.IsNullOrEmpty(Descripcion) Then Descripcion = "(" & Descripcion & ")"
            TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & Space(1) & Descripcion & vbCrLf
        End If

        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()

    End Sub

    Private Sub Tiempo_Accion_Automatico_Tick(sender As System.Object, e As System.EventArgs) Handles Tiempo_Accion_Automatico.Tick
        Tiempo_Accion_Automatico.Enabled = False
        If Not (_TblProductos Is Nothing) Then
            Sb_Consolidar_Stock(_TblProductos)
        End If
    End Sub

    Sub Sb_Reservar_Stock_Pedido_Desde_NVV_Bakapp_Con_Permisos_Pendientes()

        Dim _SqlQuery As String



        Consulta_sql = "Select * From " & _Global_BaseBk & "Zw_Casi_DocEnc" & vbCrLf &
                       "Where Id_DocEnc In (Select Id_Casi_DocEnc From " & _Global_BaseBk & "Zw_Remotas" & vbCrLf &
                       "Where NroRemota In (Select NroRemota From " & _Global_BaseBk & "Zw_Remotas_En_Cadena_02_Det Where NroRemota <> '') And CodFuncionario_Autoriza = '')"

        Dim _Tbl_DocEnc As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)
        Dim _Tbl_DocDet As DataTable

        If CBool(_Tbl_DocEnc.Rows.Count) Then

            AddToLog("", "")
            AddToLog("*** PRODUCTOS RESERVADOS NUEVAMENTE POR ESTAR PENDIENTES DE PERMISOS REMOTOS BAKAP ***", "")
            AddToLog("", "")

            For Each _Fila_Enc As DataRow In _Tbl_DocEnc.Rows

                Dim _Id_DocEnc As Integer = _Fila_Enc.Item("Id_DocEnc")

                Consulta_sql = "Select '" & Mod_Empresa & "' As Empresa,Sucursal,Bodega,Codigo,Descripcion,Ud01PR,CantUd1,Ud02PR,CantUd2" & vbCrLf &
                               "From " & _Global_BaseBk & "Zw_Casi_DocDet" & vbCrLf &
                               "Where Id_DocEnc = " & _Id_DocEnc
                _Tbl_DocDet = _Sql.Fx_Get_DataTable(Consulta_sql)

                _SqlQuery = String.Empty

                For Each _Fila As DataRow In _Tbl_DocDet.Rows

                    Dim _Ud01PR As String = _Fila.Item("Ud01PR")
                    Dim _Ud02PR As String = _Fila.Item("Ud02PR")

                    Dim _CantUd1 As String = De_Num_a_Tx_01(_Fila.Item("CantUd1"), True, 5)
                    Dim _CantUd2 As String = De_Num_a_Tx_01(_Fila.Item("CantUd2"), True, 5)

                    Dim _Empresa As String = _Fila.Item("Empresa")
                    Dim _Sucursal_Li As String = _Fila.Item("Sucursal")
                    Dim _Bodega As String = _Fila.Item("Bodega")
                    Dim _Codigo As String = _Fila.Item("Codigo")
                    Dim _Descripcion As String = _Fila.Item("Descripcion")

                    _SqlQuery += "UPDATE MAEST SET STOCNV1 = STOCNV1 +" & _CantUd1 & "," &
                                 "STOCNV2 = STOCNV2 + " & _CantUd2 & vbCrLf &
                                 "WHERE EMPRESA='" & _Empresa &
                                 "' AND KOSU='" & _Sucursal_Li &
                                 "' AND KOBO='" & _Bodega &
                                 "' AND KOPR='" & _Codigo & "'" & vbCrLf &
                                 "UPDATE MAEPREM SET STOCNV1 = STOCNV1 +" & _CantUd1 & "," &
                                 "STOCNV2 = STOCNV2 + " & _CantUd2 & vbCrLf &
                                 "WHERE EMPRESA='" & _Empresa &
                                 "' AND KOPR='" & _Codigo & "'" & vbCrLf &
                                 "UPDATE MAEPR SET STOCNV1 = STOCNV1 +" & _CantUd1 & "," &
                                 "STOCNV2 = STOCNV2 + " & _CantUd2 & vbCrLf &
                                 "WHERE KOPR='" & _Codigo & "'" & vbCrLf & vbCrLf

                    AddToLog(Trim(_Codigo), _Descripcion & ":" & _Ud01PR & " = " & _CantUd1 & ", " & _Ud02PR & " = " & _CantUd2)

                Next

                If Not String.IsNullOrEmpty(_SqlQuery) Then
                    _Sql.Fx_Eje_Condulta_Insert_Update_Delte_TRANSACCION(_SqlQuery)
                End If

            Next

        End If

    End Sub

End Class
