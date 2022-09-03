'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar

Public Class Frm_Infor_Ent_Estado_Creditos_Vigentes

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Private _dv As New DataView

    Public Property Pro_TxtDescripcion() As String
        Get
            Return TxtDescripcion.Text
        End Get
        Set(ByVal value As String)
            TxtDescripcion.Text = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Sb_Formato_Generico_Grilla(Grilla, 15, New Font("Tahoma", 7), Color.AliceBlue, ScrollBars.Both, False, False, False)

    End Sub


    Private Sub Frm_Infor_Ent_Estado_Creditos_Vigentes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Consulta_sql = "Select IDMAEEDO,VABRDO-VAABDO,FEEMDO,FEULVEDO,* From MAEEDO" & vbCrLf &
                       "Where IDMAEEDO Not In (Select IDMAEEDO From MAEVEN) And TIDO In " &
                       "('BLV','BLX','BSV','ESC','FCV','FDB','FDV','FDX','FDZ','FEE','FEV','FVL','FVT','FVX','FVZ','NCE','NCV','NCX','NCZ','NEV','RIN') " &
                       "And VABRDO > VAABDO Order by NUDO"
        Dim _TblDocSinVenci As DataTable = _Sql.Fx_Get_Tablas(Consulta_sql)

        If CBool(_TblDocSinVenci.Rows.Count) Then

            Dim _FiltroIdEdo As String = Generar_Filtro_IN(_TblDocSinVenci, "", "IDMAEEDO", False, False, "")

            Consulta_sql = "Insert Into MAEVEN (IDMAEEDO,FEVE,ESPGVE,VAVE,VAABVE)" & vbCrLf &
                           "Select IDMAEEDO,FEULVEDO,'',VABRDO,VAABDO" & vbCrLf &
                           "From MAEEDO Where IDMAEEDO In " & _FiltroIdEdo
            _Sql.Ej_consulta_IDU(Consulta_sql, False)

        End If

        Sb_Actualiar_Grilla()

        AddHandler TxtDescripcion.TextChanged, AddressOf TxtDescripcion_TextChanged
        AddHandler Grilla.ColumnHeaderMouseClick, AddressOf Grilla_ColumnHeaderMouseClick
        AddHandler Grilla.MouseDown, AddressOf Grilla_MouseDown

        If Not String.IsNullOrEmpty(TxtDescripcion.Text) Then
            Call TxtDescripcion_TextChanged(Nothing, Nothing)
        End If

    End Sub

    Sub Sb_Actualiar_Grilla()

        Consulta_sql = My.Resources.Recursos_Inf.SQLQuery_Informe_de_estado_de_creditos_vigentes_on_line

        ',,,,,,,
        ',,,,

        Dim _Ds As DataSet = _Sql.Fx_Get_DataSet(Consulta_sql)
        _dv.Table = _Ds.Tables(0)

        With Grilla

            OcultarEncabezadoGrilla(Grilla, True)

            .DataSource = _dv

            .Columns("KOEN").HeaderText = "Entidad"
            .Columns("KOEN").Width = 70
            .Columns("KOEN").Visible = True

            .Columns("SUEN").HeaderText = "Suc."
            .Columns("SUEN").Width = 40
            .Columns("SUEN").Visible = True

            .Columns("NOKOEN").HeaderText = "Razón Social"
            .Columns("NOKOEN").Width = 230
            .Columns("NOKOEN").Visible = True

            .Columns("CONDICION").HeaderText = "Condición"
            .Columns("CONDICION").Width = 180
            .Columns("CONDICION").Visible = True

            .Columns("SIN_DOC").HeaderText = "CR S/Documentar"
            .Columns("SIN_DOC").Width = 85
            .Columns("SIN_DOC").Visible = True
            .Columns("SIN_DOC").DefaultCellStyle.Format = "$ ###,##"
            .Columns("SIN_DOC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("DEUDA_VIGENTE").HeaderText = "Deuda Vigente"
            .Columns("DEUDA_VIGENTE").Width = 85
            .Columns("DEUDA_VIGENTE").Visible = True
            .Columns("DEUDA_VIGENTE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("DEUDA_VIGENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VAR_SD").HeaderText = "Variación S/D"
            .Columns("VAR_SD").Width = 85
            .Columns("VAR_SD").Visible = True
            .Columns("VAR_SD").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAR_SD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("DISP_SD").HeaderText = "Disponible S/D"
            .Columns("DISP_SD").Width = 85
            .Columns("DISP_SD").Visible = True
            .Columns("DISP_SD").DefaultCellStyle.Format = "$ ###,##"
            .Columns("DISP_SD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("CR_CHEQUES").HeaderText = "Cr Cheques"
            .Columns("CR_CHEQUES").Width = 85
            .Columns("CR_CHEQUES").Visible = True
            .Columns("CR_CHEQUES").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CR_CHEQUES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("CARTERA").HeaderText = "Cr Cartera"
            .Columns("CARTERA").Width = 85
            .Columns("CARTERA").Visible = True
            .Columns("CARTERA").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CARTERA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("VAR_CH").HeaderText = "Variación Ch"
            .Columns("VAR_CH").Width = 85
            .Columns("VAR_CH").Visible = True
            .Columns("VAR_CH").DefaultCellStyle.Format = "$ ###,##"
            .Columns("VAR_CH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("DISP_CH").HeaderText = "Disponible Ch"
            .Columns("DISP_CH").Width = 85
            .Columns("DISP_CH").Visible = True
            .Columns("DISP_CH").DefaultCellStyle.Format = "$ ###,##"
            .Columns("DISP_CH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("CR_TOTAL").HeaderText = "Cr Total"
            .Columns("CR_TOTAL").Width = 85
            .Columns("CR_TOTAL").Visible = True
            .Columns("CR_TOTAL").DefaultCellStyle.Format = "$ ###,##"
            .Columns("CR_TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("TOT_DEUDA").HeaderText = "Total Deuda"
            .Columns("TOT_DEUDA").Width = 85
            .Columns("TOT_DEUDA").Visible = True
            .Columns("TOT_DEUDA").DefaultCellStyle.Format = "$ ###,##"
            .Columns("TOT_DEUDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns("DISPONIBLE").HeaderText = "Total Disponible"
            .Columns("DISPONIBLE").Width = 85
            .Columns("DISPONIBLE").Visible = True
            .Columns("DISPONIBLE").DefaultCellStyle.Format = "$ ###,##"
            .Columns("DISPONIBLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            'For Each _Fila As DataGridViewRow In .Rows

            'Dim _TipoCredito As String = _Fila.Cells("TipoCredito").Value
            'Dim _Disponible As Double = _Fila.Cells("Disponible").Value

            'If _Disponible < 0 Then
            '_Fila.Cells("Disponible").Style.ForeColor = Color.Red
            'Else
            'If _TipoCredito = "Max. crédito" Then
            '_Fila.Cells("Disponible").Style.ForeColor = Color.DarkGreen
            'End If
            'End If

            'Next

        End With

        Sb_Marcar_Grillas()

    End Sub

    Private Sub TxtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _Descripcion As String = Trim(TxtDescripcion.Text)

        _dv.RowFilter = String.Format("KOEN+NOKOEN+CONDICION Like '%{0}%'", _Descripcion)
        Sb_Marcar_Grillas()

    End Sub

    Private Sub Frm_Infor_Ent_Estado_Creditos_Vigentes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Exportar_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exportar_Excel.Click

        Dim _TblExcel As DataTable
        _TblExcel = Fx_Crea_Tabla_Con_Filtro(_dv.Table, _
                                             "KOEN+NOKOEN+CONDICION Like '%" & TxtDescripcion.Text & "%'", _
                                             "KOEN")

        ExportarTabla_JetExcel_Tabla(_TblExcel, Me, "Estado creditos On-Line")
    End Sub

    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Dim _Cabeza = sender.Columns(CType(sender, DataGridView).CurrentCell.ColumnIndex).Name

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value
        Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value

        Select Case _Cabeza

            'Case "KOEN", "NOKOEN"

            'Dim Fm As New Frm_Crear_Entidad_Mt
            'Fm.LlenarEntidad(_Koen, "")
            'Fm._Crear_Entidad = False
            'Fm._Editar_Entidad = True
            'Fm.ShowDialog(Me)
            'Fm.Dispose()

            Case "CARTERA"
                Call Btn_Ver_Cheques_En_Cartera_Click(Nothing, Nothing)
            Case "DEUDA_VIGENTE", "TOT_DEUDA"
                Sb_Ver_Deuda_Pendiente(_Fila, _Cabeza)
            Case Else
                Call Btn_Ver_Situacion_Cliente_Click(Nothing, Nothing)
        End Select

       

        '


    End Sub


    Sub Sb_Marcar_Grillas()

        Dim _Deuda_Vigente As Double
        Dim _Cartera As Double
        Dim _Tot_Deuda As Double


        With Grilla
            For Each _Fila As DataGridViewRow In .Rows

                _Deuda_Vigente = NuloPorNro(_Fila.Cells("DEUDA_VIGENTE").Value, 0)
                _Cartera = NuloPorNro(_Fila.Cells("CARTERA").Value, 0)
                _Tot_Deuda = NuloPorNro(_Fila.Cells("TOT_DEUDA").Value, 0)

                Select Case _Deuda_Vigente
                    Case Is = 0
                        _Fila.Cells("DEUDA_VIGENTE").Style.ForeColor = Color.Green
                    Case Is > 0
                        _Fila.Cells("DEUDA_VIGENTE").Style.ForeColor = Color.Red
                    Case Is < 0
                        _Fila.Cells("DEUDA_VIGENTE").Style.ForeColor = Color.Green
                End Select

                Select Case _Cartera
                    Case Is = 0
                        _Fila.Cells("CARTERA").Style.ForeColor = Color.Green
                    Case Is > 0
                        _Fila.Cells("CARTERA").Style.ForeColor = Color.Red
                    Case Is < 0
                        _Fila.Cells("CARTERA").Style.ForeColor = Color.Green
                End Select

                Select Case _Tot_Deuda
                    Case Is = 0
                        _Fila.Cells("TOT_DEUDA").Style.ForeColor = Color.Green
                    Case Is > 0
                        _Fila.Cells("TOT_DEUDA").Style.ForeColor = Color.Red
                    Case Is < 0
                        _Fila.Cells("TOT_DEUDA").Style.ForeColor = Color.Green
                End Select


            Next
        End With

        Dim _Descripcion As String = Trim(TxtDescripcion.Text)

        _Deuda_Vigente = NuloPorNro(_dv.Table.Compute("SUM(DEUDA_VIGENTE)", _
                                                 "KOEN+NOKOEN+CONDICION Like '%" & _Descripcion & "%'"), 0)
        _Cartera = NuloPorNro(_dv.Table.Compute("SUM(CARTERA)", _
                                                "KOEN+NOKOEN+CONDICION Like '%" & _Descripcion & "%'"), 0)
        _Tot_Deuda = NuloPorNro(_dv.Table.Compute("SUM(TOT_DEUDA)", _
                                                "KOEN+NOKOEN+CONDICION Like '%" & _Descripcion & "%'"), 0)



        Lbl_Deuda_Vigente.Text = FormatCurrency(_Deuda_Vigente, 0)
        Lbl_Cartera.Text = FormatCurrency(_Cartera, 0)
        Lbl_Tot_Deuda.Text = FormatCurrency(_Tot_Deuda, 0)


    End Sub

    Private Sub Grilla_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Sb_Marcar_Grillas()
    End Sub

    Sub Sb_Ver_Deuda_Pendiente(ByVal _Fila As DataGridViewRow, _
                               ByVal _Cabeza As String)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value

        Dim _Fx_Fecha_Inicio = "19000101"
        Dim _Fx_Fecha_Fin = "22001231"

        Dim _Filtro_Maeedo = "And EDO.ENDO = '" & _Koen & "' AND EDO.SUENDO = '" & _Suen & "'"
        Dim _Filtro_Maedpce = "And DPCE.ENDP = '" & _Koen & "'"

        Consulta_sql = My.Resources.Recursos_Inf_Compras_Vencimiento.Informe_Vencimientos_Ventas_Anuales & vbCrLf & vbCrLf

        Dim Fm As New Frm_Inf_Vencimientos_Detalle_Documentos(_Koen, _Suen, Consulta_sql, _
                                                      _Fx_Fecha_Inicio, _Fx_Fecha_Fin, _
                                                      Frm_Inf_Vencimientos_Detalle_Documentos.Accion.Mostrar_todo, _
                                                      0, Frm_Inf_Vencimientos_Detalle_Documentos.Tipo_Informe.Ventas)

        Fm.Pro_Mover_Fechas = False

        If _Cabeza = "TOT_DEUDA" Then
            Fm.Pro_Chk_Deuda_Efectiva = True
        End If

        Fm.Pro_Filtro_Maeedo = _Filtro_Maeedo
        Fm.Pro_Filtro_Maedpce = _Filtro_Maedpce
        Fm.Pro_Solo_Cheques = True
        Fm.Btn_Marcar_Masivamente_Anotaciones_De_Documentos.Visible = False
        Fm.Chk_Mostrar_Pagos_Pendientes.Visible = False
        Fm.Sb_Generar_Informe()

        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Documentos_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Documentos_Pendientes.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Ver_Deuda_Pendiente(_Fila, "")
    End Sub

    Private Sub Btn_Ver_Cheques_En_Cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Cheques_En_Cartera.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value
        Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value

        Dim Fm As New Frm_Infor_Cheques_En_Cartera_X_Clientes
        Fm.Pro_Filtro_Entidad = _Koen
        Fm.Text = "Cheques en cartera entidad: " & _Nokoen
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Deuda_Total_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Deuda_Total.Click
        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)
        Sb_Ver_Deuda_Pendiente(_Fila, "TOT_DEUDA")
    End Sub


    Private Sub Btn_Ver_Situacion_Cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Situacion_Cliente.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value
        Dim _Nokoen As String = _Fila.Cells("NOKOEN").Value

        Consulta_sql = "Select Top 1 * From MAEEN Where KOEN = '" & _Koen & "' And SUEN = '" & _Suen & "'"
        Dim _RowEntidad As DataRow = _Sql.Fx_Get_DataRow(Consulta_sql)

        Dim Fm As New Frm_InfoEnt_Deudas_Doc_Comerciales(_RowEntidad, 0, 0, 0, 0, True)
        Fm.Btn_CambCodPago.Visible = False
        Fm.ShowDialog(Me)
        Fm.Dispose()

    End Sub

    Private Sub Btn_Ver_Comportamiento_De_Pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ver_Comportamiento_De_Pago.Click

        Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

        Dim _Koen As String = _Fila.Cells("KOEN").Value
        Dim _Suen As String = _Fila.Cells("SUEN").Value



        Dim Fm_E As New Frm_BuscarEntidad_Mt(False)
        Dim _RowEntidad As DataRow = Fx_Traer_Datos_Entidad(_Koen, _Suen)

        If Not (_RowEntidad Is Nothing) Then

            Dim Fm As New Frm_Infor_Ent_Comportamiento_De_Pago
            Fm.Pro_RowEntidad = _RowEntidad
            Fm.ShowDialog(Me)
            Fm.Dispose()

        End If
    End Sub

    Private Sub Grilla_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With sender
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    ShowContextMenu(Menu_Contextual_01)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Mnu_Ficha_Entidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mnu_Ficha_Entidad.Click
        If Fx_Tiene_Permiso(Me, "CfEnt001") Then
            Dim _Fila As DataGridViewRow = Grilla.Rows(Grilla.CurrentRow.Index)

            Dim _Koen = _Fila.Cells("KOEN").Value
            Dim _Suen = _Fila.Cells("SUEN").Value

            Dim Fm As New Frm_Crear_Entidad_Mt
            Fm.Fx_Llenar_Entidad(_Koen, _Suen)
            Fm.Pro_Crear_Entidad = False
            Fm.Pro_Editar_Entidad = True
            Fm.ShowDialog(Me)

            If Fm.Pro_Grabar Then
                Beep()
                ToastNotification.Show(Me, "DATOS ACTUALIZADOS CORRECTAMENTE", My.Resources.ok_button, _
                                       1 * 1000, eToastGlowColor.Green, eToastPosition.MiddleCenter)
            End If

            Fm.Dispose()
        End If
    End Sub
End Class
