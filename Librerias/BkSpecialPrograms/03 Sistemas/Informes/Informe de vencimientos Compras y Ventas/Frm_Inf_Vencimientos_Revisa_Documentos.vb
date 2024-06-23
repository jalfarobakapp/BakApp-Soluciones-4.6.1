'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Inf_Vencimientos_Revisa_Documentos

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Grilla As DataGridView
    Dim _Revisado As Boolean
    Dim _Cancelar As Boolean


    Public Property Pro_Grilla() As DataGridView
        Get
            Return _Grilla
        End Get
        Set(ByVal value As DataGridView)
            _Grilla = value
        End Set
    End Property
    Public ReadOnly Property Pro_Revisado() As Boolean
        Get
            Return _Revisado
        End Get
    End Property

    Public Sub New(ByVal Grilla As DataGridView)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _Grilla = Grilla

        If Global_Thema = Enum_Themas.Oscuro Then
            BtnProcesar.ForeColor = Color.White
            Btn_Cancelar.ForeColor = Color.White
        End If

    End Sub

    Private Sub Frm_Inf_Vencimientos_Revisa_Documentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Txt_Cantidad.KeyPress, AddressOf Sb_KeyPress
    End Sub

    Sub Sb_Procesar()
        Try

            BtnProcesar.Enabled = False
            Me.ControlBox = False
            Btn_Cancelar.Enabled = True

            Me.Refresh()

            _Cancelar = False

            'For Each _Fila As DataGridViewRow In _Grilla.Rows
            '_Fila.DefaultCellStyle.ForeColor = Color.Black
            '_Fila.DefaultCellStyle.BackColor = Color.White
            'If _Fila.Cells("Chk").Value = False Then
            '_Fila.DefaultCellStyle.BackColor = Color.Azure
            'End If
            'Next

            If Not Chk_Revisar_solo_devoluciones.Checked Then
                If CBool(Val(Txt_Cantidad.Text)) Then
                    Sb_Revisar_Stock_VS_Cantidad(Txt_Cantidad.Text, True)
                Else
                    MessageBoxEx.Show(Me, "Debe indicar la cantidad de stock mínimo de rotación para saber que documentos marcar",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            If _Cancelar Then
                _Revisado = True
            Else
                Sb_Revisar_FCC_GDD_NCC()
                _Revisado = True
            End If


            If MessageBoxEx.Show(Me, "¿Desea cerrar este formulario?", "Proceso terminado",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If

        Catch ex As Exception
            MessageBoxEx.Show(ex.Message, "Problema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            BtnProcesar.Enabled = True
            Me.ControlBox = True
            Btn_Cancelar.Enabled = False
        End Try

        Me.Refresh()

    End Sub

    Private Sub Frm_Inf_Vencimientos_Revisa_Documentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesar.Click
        Sb_Procesar()
    End Sub


#Region "PROCESOS DE REVISION DE DOCUMENTOS"

#Region "REVISAR GDD VS NCC"

    Sub Sb_Revisar_FCC_GDD_NCC()

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _Grilla.Rows.Count

        AddToLog("", "")
        AddToLog("REVISION DE TRAZAVILIDAD DEVOLUCIONES (FCC->GDD->NCC)", "INICIO")

        Me.Text = "REVISION DE TRAZAVILIDAD DEVOLUCIONES (FCC->GDD->NCC)"

        For Each _Fila As DataGridViewRow In _Grilla.Rows

            Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

            System.Windows.Forms.Application.DoEvents()
            Dim _Documento As String = _Fila.Cells("TIDO").Value & "-" & _Fila.Cells("NUDO").Value


            Consulta_sql = "SELECT TIDO,NUDO,IDMAEDDO From MAEDDO Where IDMAEEDO = " & _Idmaeedo

            Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            For Each _FDetalle As DataRow In _TblDetalle.Rows

                Dim _Tido As String = _FDetalle.Item("TIDO")
                Dim _Nudo As String = _FDetalle.Item("NUDO")
                Dim _Idmaeddo_FCC As Integer = _FDetalle.Item("IDMAEDDO")

                LblEstado.Text = "Revisando documento: " & _Tido & "-" & _Nudo

                Consulta_sql = "SELECT * FROM MAEDDO" & vbCrLf &
                               "WHERE IDRST = " & _Idmaeddo_FCC & " AND ARCHIRST = 'MAEDDO' AND TIDO = 'GDD' AND ESLIDO = ''"

                Dim _TblGdd As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                System.Windows.Forms.Application.DoEvents()

                If CBool(_TblGdd.Rows.Count) Then

                    Dim _Idmaeddo_GDD As Integer = _FDetalle.Item("IDMAEDDO")

                    'Dim _Reg
                    'CAST( 0 AS Bit) AS SOSPECHA_STOCK,CAST( 0 AS Float) AS SOSPECHA_DEVOLUCION,  

                    'If _Unidad = 1 Then
                    'If _Cantidad_Ud1 <= _Stock_Ud1 Then
                    _Fila.Cells("SOSPECHA_DEVOLUCION").Value = True
                    _Fila.DefaultCellStyle.ForeColor = Color.White
                    _Fila.DefaultCellStyle.BackColor = Color.Red
                    AddToLog("Revisado", "Sospechoso: " & _Documento)
                    _Fila.Cells("Chk").Value = False
                    Exit For
                    'End If
                    'Else
                    'If _Cantidad_Ud2 <= _Stock_Ud2 Then
                    '_Fila.Cells("SOSPECHA_STOCK").Value = True
                    '_Fila.DefaultCellStyle.BackColor = Color.Yellow
                    'Exit For
                    'End If
                    'End If

                End If

            Next

            _Fila.Cells("REVISADO_PAGAR").Value = True

            Progreso_Porc.Value = ((_Fila.Index * 100) / _Grilla.Rows.Count) 'Mas
            Progreso_Cont.Value += 1

            If _Cancelar Then
                If MessageBoxEx.Show(Me, "¿Esta seguro de cancelar el proceso?", "Cancelar",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    AddToLog("", "")
                    AddToLog("ACCION CANCELADA POR EL USUARIO", "CANCELAR")
                    AddToLog("", "")
                    Exit For
                Else
                    _Cancelar = False
                    Btn_Cancelar.Enabled = True
                End If
            End If


        Next


        AddToLog("", "")
        AddToLog("REVISION DE TRAZAVILIDAD", "FIN")

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

    End Sub

#End Region

#Region "REVISAR STOCK"

    Sub Sb_Revisar_Stock_VS_Cantidad(ByVal _Min_Rotacion_Anual As Double,
                                     ByVal _Revisar_Stock_Relacionados As Boolean)

        Progreso_Porc.Maximum = 100
        Progreso_Cont.Maximum = _Grilla.Rows.Count

        AddToLog("REVISION DE CANTIDAD VS STOCK", "INICIO")
        Me.Text = "REVISION DE CANTIDAD VS STOCK, Documentos: " & _Grilla.Rows.Count

        For Each _Fila As DataGridViewRow In _Grilla.Rows
            System.Windows.Forms.Application.DoEvents()

            Dim _Documento As String = _Fila.Cells("TIDO").Value & "-" & _Fila.Cells("NUDO").Value

            Dim _Idmaeedo As Integer = _Fila.Cells("IDMAEEDO").Value

            Consulta_sql = "SELECT TICT,PRCT,TIPR,KOPRCT,NOKOPR,UDTRPR,CAPRCO1,CAPRCO2 From MAEDDO Where IDMAEEDO = " & _Idmaeedo
            Dim _TblDetalle As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

            Dim _Cont_dt = 1

            'AddToLog("Revisando", "Documento: " & _Documento)

            Dim _Sospechoso As Boolean

            '_Fila.DefaultCellStyle.BackColor = Color.White
            '_Fila.Cells("Chk").Value = False

            Dim _Chk As Boolean = _Fila.Cells("Chk").Value
            Dim _Revisado_Pagar As Boolean = _Fila.Cells("REVISADO_PAGAR").Value

            If Not _Revisado_Pagar Then

                For Each _FDetalle As DataRow In _TblDetalle.Rows

                    Dim _Codigo As String = _FDetalle.Item("KOPRCT")
                    Dim _Descripcion As String = _FDetalle.Item("NOKOPR")
                    Dim _Unidad As Integer = _FDetalle.Item("UDTRPR")
                    Dim _Cantidad_Ud1 As Double = _FDetalle.Item("CAPRCO1")
                    Dim _Cantidad_Ud2 As Double = _FDetalle.Item("CAPRCO2")

                    Dim _Stock_Ud1_Rem, _Stock_Ud2_Rem As Double

                    LblEstado.Text = "Revisando documento: " & _Documento & ", Item: " & _Cont_dt & " de " & _TblDetalle.Rows.Count &
                                       ", " & _Codigo & " - " & _Descripcion

                    'Consulta_sql = "SELECT KOPR FROM MAEPR WHERE KOPR = '" & _Codigo & "'" & vbCrLf & vbCrLf & _
                    '               "UNION" & vbCrLf & _
                    '               "SELECT KOPR FROM TABREMP WHERE KOPRREM = '" & _Codigo & "' AND KOPR <> '" & _Codigo & "' "
                    '
                    'Dim _TblProductos As DataTable = _SQL.Fx_Get_Tablas(Consulta_sql)


                    Dim Fm As New Frm_EstadisticaProducto(_Codigo)
                    Fm.Sb_Actualizar_Estadisticas_Un_Solo_Producto(Fm.Pro_Row_Producto)
                    Dim _Tbl_Mov As DataTable = Fm.Pro_Tbl_Moviminetos_Acumulados 'Fm._Tbl_Movimientos_Acumulados
                    Dim _Rot_Anual As Double = _Tbl_Mov.Rows(1).Item("Ult.12 Meses")
                    Fm.Dispose()


                    If _Revisar_Stock_Relacionados Then

                        Consulta_sql = "SELECT ISNULL(SUM(STFI1),0) AS STFI1,ISNULL(SUM(STFI2),0) AS STFI2" & vbCrLf &
                                       "FROM MAEST Where KOPR IN " &
                                       "(Select Distinct KOPRREM From TABREMP Where KOPR = '" & _Codigo & "' And KOPRREM <> '" & _Codigo & "')"

                        Dim _Tbl As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)

                        If CBool(_Tbl.Rows.Count) Then
                            _Stock_Ud1_Rem = _Tbl.Rows(0).Item("STFI1")
                            _Stock_Ud2_Rem = _Tbl.Rows(0).Item("STFI2")

                            If Not CBool(_Stock_Ud1_Rem + _Stock_Ud2_Rem) Then
                                _Revisar_Stock_Relacionados = False
                            End If
                        End If

                    End If

                    Consulta_sql = "SELECT ISNULL(SUM(STFI1),0) AS STFI1,ISNULL(SUM(STFI2),0) AS STFI2" & vbCrLf &
                                   "FROM MAEST Where KOPR = '" & _Codigo & "'"
                    Dim _TblStock As DataTable = _Sql.Fx_Get_DataTable(Consulta_sql)


                    If CBool(_TblStock.Rows.Count) Then

                        Dim _Stock_Ud1 As Double = _TblStock.Rows(0).Item("STFI1") + _Stock_Ud1_Rem
                        Dim _Stock_Ud2 As Double = _TblStock.Rows(0).Item("STFI2") + _Stock_Ud2_Rem

                        'CAST( 0 AS Bit) AS SOSPECHA_STOCK,CAST( 0 AS Float) AS SOSPECHA_DEVOLUCION,  

                        If _Rot_Anual <= _Min_Rotacion_Anual Then
                            If _Unidad = 1 Then
                                If _Cantidad_Ud1 <= _Stock_Ud1 Then
                                    _Descripcion += ",Unidad 1 Cantidad: " & _Cantidad_Ud1 & ", Stock: " & _Stock_Ud1 & ", Rotación anual: " & _Rot_Anual
                                    _Fila.Cells("SOSPECHA_STOCK").Value = True

                                    If _Revisar_Stock_Relacionados Then
                                        _Fila.DefaultCellStyle.BackColor = Color.Orange
                                    Else
                                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                                    End If

                                End If
                            Else
                                If _Cantidad_Ud2 <= _Stock_Ud2 Then
                                    _Descripcion += ",Unidad 2 Cantidad: " & _Cantidad_Ud2 & ", Stock: " & _Stock_Ud2 & ", Rotación anual: " & _Rot_Anual
                                    _Fila.Cells("SOSPECHA_STOCK").Value = True

                                    If _Revisar_Stock_Relacionados Then
                                        _Fila.DefaultCellStyle.BackColor = Color.Orange
                                    Else
                                        _Fila.DefaultCellStyle.BackColor = Color.Yellow
                                    End If

                                End If
                            End If
                        End If

                    End If

                    _Sospechoso = _Fila.Cells("SOSPECHA_STOCK").Value

                    If _Sospechoso Then Exit For

                    System.Windows.Forms.Application.DoEvents()
                    _Cont_dt += 1

                Next

                _Grilla.CurrentCell = _Grilla.Rows(_Fila.Index).Cells("TIDO")

                If _Sospechoso Then
                    AddToLog("Revisado", "Documento: " & _Documento & ", SOSPECHOSO")
                    _Fila.DefaultCellStyle.BackColor = Color.Yellow
                    _Fila.Cells("Chk").Value = False
                Else
                    AddToLog("Revisado", "Documento: " & _Documento & ", O.K.")
                    _Fila.Cells("Chk").Value = True
                    _Fila.DefaultCellStyle.ForeColor = Color.Black
                    _Fila.DefaultCellStyle.BackColor = Color.White
                End If

                'AddToLog("", "")

            End If

            _Fila.Cells("REVISADO_PAGAR").Value = True

            System.Windows.Forms.Application.DoEvents()
            Progreso_Porc.Value = ((_Fila.Index * 100) / _Grilla.Rows.Count) 'Mas
            Progreso_Cont.Value += 1

            If _Cancelar Then
                If MessageBoxEx.Show(Me, "¿Esta seguro de cancelar el proceso?", "Cancelar",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Exit For
                Else
                    Btn_Cancelar.Enabled = True
                    _Cancelar = False
                End If
            End If

        Next

        Progreso_Cont.Value = 0
        Progreso_Porc.Value = 0

    End Sub



#End Region

    Private Sub AddToLog(ByVal Accion As String,
                         ByVal Descripcion As String)

        If String.IsNullOrEmpty(Trim(Accion) & Trim(Descripcion)) Then
            TxtLog.Text += vbCrLf
        Else
            TxtLog.Text += DateTime.Now.ToString() & " - " & Accion & " (" & Descripcion & ")" & vbCrLf
        End If

        TxtLog.Select(TxtLog.Text.Length - 1, 0)
        TxtLog.ScrollToCaret()

    End Sub


    Private Sub Sb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        ' Si se pulsa la tecla Intro, pasar al siguiente
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
        ElseIf e.KeyChar = ","c Then
            ' si se pulsa la coma se convertirá en punto
            e.Handled = True
            SendKeys.Send(".")
        ElseIf e.KeyChar = "-"c Then
            e.Handled = True
            SendKeys.Send("")
        End If
    End Sub


#End Region

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        _Cancelar = True
        Btn_Cancelar.Enabled = False
    End Sub

End Class
