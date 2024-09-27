'Imports Lib_Bakapp_VarClassFunc
Imports DevComponents.DotNetBar



Public Class Frm_Vales_Listado_Espera

    Dim _Sql As New Class_SQL(Cadena_ConexionSQL_Server)
    Dim Consulta_sql As String

    Dim _Fecha_Desde, _
        _Fecha_Hasta As Date

    Dim _Segundos = 1
    Public _Tiempo_Actualizacion As Integer

    Dim _Path = AppPath() & "\Data\" & RutEmpresa & "\Vales_despacho\Config_Estacion.xml"
    Dim _Datos_Conf As New Ds_Vales


    Private Sub Frm_Vales_Listado_Espera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sb_Load()
    End Sub

    Sub Sb_Load()
        Lbl_TiempoRest.Text = String.Empty
        'DtpFecha.Value = Date.Now
        _Fecha_Desde = Date.Now
        _Fecha_Hasta = Date.Now

        Me.StartPosition = FormStartPosition.CenterScreen
       Sb_Formato_Generico_Grilla(Grilla, 20, New Font("Tahoma", 8), Color.AliceBlue, ScrollBars.Vertical, False, False, False)

        _Datos_Conf.Clear()
        _Datos_Conf.ReadXml(_Path)

        Dim _Fila As DataRow = _Datos_Conf.Tables("Tbl_Configuracion").Rows(0)

        Chk_VerMarcadas.Checked = _Fila.Item("Chk_VerMarcadas")
        Chk_VerActivas.Checked = _Fila.Item("Chk_VerActivas")
        Chk_VerCerradas.Checked = _Fila.Item("Chk_VerCerradas")
        Chk_VerNulas.Checked = _Fila.Item("Chk_VerNulas")

        Rdb_Retira_Cliente.Checked = _Fila.Item("Rdb_Retira_Cliente")
        Rdb_Despacho_Domicilio.Checked = _Fila.Item("Rdb_Despacho_Domicilio")
        Rdb_Ambos.Checked = _Fila.Item("Rdb_Ambos")

        'Lbl_Impresora.Text = _Fila.Item("Impresora_pred")
        _Tiempo_Actualizacion = _Fila.Item("Segundos_Actualizacion")

        Sb_InsertarBotonenGrilla(Grilla, "BtnImagen", "Est", "Imagen", 0, _Tipo_Boton.Imagen)

        Sb_Actualizar_Listado(Fx_SQL_Filtro)

    End Sub

    Function Fx_SQL_Filtro() As String

        Dim _Filtro_Consulta As String
        Dim _Filtro_Tipo_Entrega As String
        Dim _Filtro_Fechas As String
        Dim _Filtro_Estados As String

        If Rdb_Retira_Cliente.Checked Then
            Me.Text = "Listado de documentos pendientes de retiro de cliente"
            _Filtro_Tipo_Entrega = "And Tipo_Entrega = 'C'"
        ElseIf Rdb_Despacho_Domicilio.Checked Then
            Me.Text = "Listado de documentos pendientes de despacho a domicilio"
            _Filtro_Tipo_Entrega = "And Tipo_Entrega = 'D'"
        ElseIf Rdb_Ambos.Checked Then
            Me.Text = "Listado de documentos pendientes de retiro o despacho"
            _Filtro_Tipo_Entrega = String.Empty
        End If

        Dim _Ano_1 = _Fecha_Desde.Year
        Dim _Mes_1 = _Fecha_Desde.Month
        Dim _Dia_1 = _Fecha_Desde.Day

        Dim _Ano_2 = _Fecha_Hasta.Year
        Dim _Mes_2 = _Fecha_Hasta.Month
        Dim _Dia_2 = _Fecha_Hasta.Day

        _Filtro_Fechas = "And Fecha_Emision BETWEEN CONVERT(DATETIME, '" & _Ano_1 & "-" & _Mes_1 & "-" & _Dia_1 & " 00:00:00', 102)" & vbCrLf & _
                         "And CONVERT(DATETIME, '" & _Ano_2 & "-" & _Mes_2 & "-" & _Dia_2 & " 23:59:59', 102)"



        Dim _Estados(3) As String

        If Chk_VerMarcadas.Checked Then _Estados(0) = "M" Else _Estados(0) = String.Empty
        If Chk_VerActivas.Checked Then _Estados(1) = "A" Else _Estados(1) = String.Empty
        If Chk_VerCerradas.Checked Then _Estados(2) = "C" Else _Estados(2) = String.Empty
        If Chk_VerNulas.Checked Then _Estados(3) = "N" Else _Estados(3) = String.Empty

        'M' -- Marcada en caja para ser trabajada, aun no rebaja stock
        'A' Then 'Activo'  -- Marcada por Despacho, devuelve el stock del documento a la bodega para hacer GDV
        'C' Then 'Cerrado' -- Completa con todos los productos despachados, sin saldo
        'N' Then 'Nulo'    -- Nula, no se puede volver a usar el vale, se debe crear otro para el documento.


        _Filtro_Estados = Generar_Filtro_IN_Arreglo(_Estados, False)

        If _Filtro_Estados = "()" Then
            _Filtro_Estados = "''"
            _Filtro_Estados = "And Estado = 'X'"
        Else
            _Filtro_Estados = "And Estado In " & _Filtro_Estados
        End If


        _Filtro_Consulta = _Filtro_Tipo_Entrega & vbCrLf & _
                           _Filtro_Fechas & vbCrLf & _
                           _Filtro_Estados


        Consulta_sql = My.Resources.Rsc_Vales.Sql_Query_Vales_Listado
        Consulta_sql = Replace(Consulta_sql, "#Filtro_Consulta#", _Filtro_Consulta)

        Return Consulta_sql

    End Function

    Sub Sb_Actualizar_Listado(ByVal _Sql_Filtro As String)

        Consulta_sql = "Update Zw_Vales_Enc Set Estado = 'C' " & vbCrLf & _
                       "Where (Select Case " & vbCrLf & _
                       "When Id_Doc_As <> 0 Then (Select Case When CAPREX > 0 Then CAPREX/CAPRCO Else 0 End From MAEEDO" & vbCrLf & _
                       "Where IDMAEEDO = Id_Doc_As)" & vbCrLf & _
                       "Else 0" & vbCrLf & _
                        "End ) = 1"
        _Sql.Ej_consulta_IDU(Consulta_sql)

        Grilla.DataSource = _Sql.Fx_Get_DataTable(Consulta_sql)

        Sb_Formato_Grilla(Grilla)

    End Sub


    Sub Sb_Formato_Grilla(ByVal Grilla As DataGridView)

        OcultarEncabezadoGrilla(Grilla, True)
        'Grilla.DataSource
        With Grilla ' ancho 853

            .Columns("BtnImagen").Visible = True
            .Columns("BtnImagen").Width = 50
            .Columns("BtnImagen").HeaderText = ""
            .Columns("BtnImagen").DisplayIndex = 0

            .Columns("Tipo").Visible = True
            .Columns("Tipo").Width = 100
            .Columns("Tipo").HeaderText = "Documento"
            .Columns("Tipo").DisplayIndex = 1

            .Columns("NroDoc_Doc_As").Visible = True
            .Columns("NroDoc_Doc_As").Width = 80
            .Columns("NroDoc_Doc_As").HeaderText = "Número"
            .Columns("NroDoc_Doc_As").DisplayIndex = 2

            .Columns("Fecha_Emision").Visible = True
            .Columns("Fecha_Emision").HeaderText = "Fecha"
            .Columns("Fecha_Emision").Width = 70
            .Columns("Fecha_Emision").DisplayIndex = 3

            .Columns("Hora_Emision").Visible = True
            .Columns("Hora_Emision").HeaderText = "Hora"
            .Columns("Hora_Emision").Width = 70
            .Columns("Hora_Emision").DefaultCellStyle.Format = "hh:mm:ss"
            .Columns("Hora_Emision").DisplayIndex = 4

            .Columns("Razon").Visible = True
            .Columns("Razon").HeaderText = "Cliente"
            .Columns("Razon").Width = 280
            .Columns("Razon").DisplayIndex = 5

            .Columns("PorcCumplimiento").Visible = True
            .Columns("PorcCumplimiento").Width = 70
            .Columns("PorcCumplimiento").HeaderText = "% Entrega"
            .Columns("PorcCumplimiento").DefaultCellStyle.Format = "###,##.## %"
            .Columns("PorcCumplimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("PorcCumplimiento").DisplayIndex = 6

            .Columns("NroVale").Visible = True
            .Columns("NroVale").HeaderText = "Nro Vale"
            .Columns("NroVale").Width = 80
            .Columns("NroVale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("NroVale").DisplayIndex = 7

            .Columns("NomEstado").Visible = True
            .Columns("NomEstado").HeaderText = "Estado"
            .Columns("NomEstado").Width = 60
            .Columns("NomEstado").DisplayIndex = 8

            Dim _i = 0
            For Each row As DataGridViewRow In .Rows
                _i = row.Index
                Dim _Estado As String = row.Cells("Estado").Value
                Dim _Tipo_Entrega As String = row.Cells("Tipo_Entrega").Value
                '.Rows.Item(_i).Cells("Estado").Style.ForeColor = Color.Red
                '.Rows.Item(_i).DefaultCellStyle.BackColor = Color.Yellow ' Color.Coral

                If _Tipo_Entrega = "C" Then
                    Select Case _Estado
                        Case "M"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._shipment
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.Yellow
                        Case "A"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._shipment_ok
                        Case "C"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._shipment_lock
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "N"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._shipment_delete
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.LightGray
                    End Select
                ElseIf _Tipo_Entrega = "D" Then
                    Select Case _Estado
                        Case "M"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._transport
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.Yellow
                        Case "A"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._transport_ok
                        Case "C"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._transport_lock
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.LightGreen
                        Case "N"
                            .Rows.Item(_i).Cells("BtnImagen").Value = My.Resources.Rsc_Vales._transport_delete
                            .Rows.Item(_i).DefaultCellStyle.BackColor = Color.LightGray
                    End Select
                End If
                .Rows.Item(_i).Cells("Estado").Style.Font = New Font("Tahoma", 8, FontStyle.Bold)


                '.Rows.Item().Cells("BtnImagen").Value = My.Resources_rounded_green
            Next

            .Refresh()
            .Enabled = CBool(.RowCount)
        End With

    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub Grilla_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grilla.CellDoubleClick

        Dim _NroVale As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("NroVale").Value
        Dim _Tipo_Entrega As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Tipo_Entrega").Value
        Dim _Estado As String = Grilla.Rows(Grilla.CurrentRow.Index).Cells("Estado").Value

        If _Estado = "N" Then
            Beep()
            ToastNotification.Show(Me, "DOCUMENTO NULO", My.Resources.cross, _
                                   2 * 1000, eToastGlowColor.Red, eToastPosition.MiddleCenter)
            Return
        End If

        If _Tipo_Entrega = "C" Then
            If Not Fx_Tiene_Permiso(Me, "Vale0013") Then Return
        ElseIf _Tipo_Entrega = "D" Then
            If Not Fx_Tiene_Permiso(Me, "Vale0014") Then Return
        End If

        Sw_RevisionAutomatica.Value = False

        Dim Fm As New Frm_Vales_Ficha_Doc
        Fm._NroVale_activo = _NroVale
        Fm.ShowDialog(Me)


        Sw_RevisionAutomatica.Value = True
        Sb_Actualizar_Listado(Fx_SQL_Filtro)


    End Sub

    Private Sub BtnImprimirListadoActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirListadoActual.Click
        If Fx_Tiene_Permiso(Me, "Vale0012") Then

        End If
    End Sub


    Private Sub BtnExportarExcelListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcelListado.Click

        If Fx_Tiene_Permiso(Me, "Vale0015") Then

            'Sb_Actualizar_Listado(Fx_SQL_Filtro)
            Dim _TblExcel As DataTable = Grilla.DataSource
            ExportarTabla_JetExcel_Tabla(_TblExcel, Me, "Vales_por_mercaderia_pendiente")

        End If

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Sb_Actualizar_Listado(Fx_SQL_Filtro)
    End Sub


    Private Sub Sw_RevisionAutomatica_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sw_RevisionAutomatica.ValueChanged
        CirProg_RevisionAutomatica.IsRunning = Sw_RevisionAutomatica.Value
        Timer1.Enabled = Sw_RevisionAutomatica.Value

        If Sw_RevisionAutomatica.Value Then
            Sb_Actualizar_Listado(Fx_SQL_Filtro)
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim Rest As Integer = _Tiempo_Actualizacion - _Segundos
        Lbl_TiempoRest.Text = Rest

        If _Segundos = _Tiempo_Actualizacion Then
            Sb_Actualizar_Listado(Fx_SQL_Filtro)
            _Segundos = 0
        End If

        _Segundos += 1


    End Sub

    Private Sub Btn_Configuracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Configuracion.Click
        If Fx_Tiene_Permiso(Me, "Vale0018") Then
            Dim Fm As New Frm_Configuracion_vales
            Fm.ShowDialog(Me)
            Sb_Load()
        End If
    End Sub

    Private Sub Btn_Buscar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar_documento.Click
        If Fx_Tiene_Permiso(Me, "Vale0020") Then
            Dim Fm As New Frm_Vales_Listado_Espera_Filtro
            Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True
            Fm.Rdb_Vale_todos.Checked = False
            Fm.Rdb_Vale_Uno.Checked = True

            Fm.Chk_VerMarcadas.Checked = Chk_VerMarcadas.Checked
            Fm.Chk_VerActivas.Checked = Chk_VerActivas.Checked
            Fm.Chk_VerCerradas.Checked = Chk_VerCerradas.Checked
            Fm.Chk_VerNulas.Checked = Chk_VerNulas.Checked
            Fm.Rdb_Retira_Cliente.Checked = Rdb_Retira_Cliente.Checked
            Fm.Rdb_Despacho_Domicilio.Checked = Rdb_Despacho_Domicilio.Checked
            Fm.Rdb_Ambos.Checked = Fm.Rdb_Ambos.Checked


            Fm._SoloBuscar = True
            Fm.ShowDialog(Me)

            If Fm._Filtrar Then
                Sw_RevisionAutomatica.Value = False
                Lbl_TiempoRest.Text = String.Empty
                Sb_Actualizar_Listado(Fm._Filtro_SQL)
            Else
                Sw_RevisionAutomatica.Value = True
            End If
        End If
    End Sub

    Private Sub Btn_BusquedaAvanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BusquedaAvanzada.Click
        If Fx_Tiene_Permiso(Me, "Vale0021") Then
            Dim Fm As New Frm_Vales_Listado_Espera_Filtro
            Fm.Rdb_Fecha_Emision_Desde_Hasta.Checked = True

            Fm.Chk_VerMarcadas.Checked = Chk_VerNulas.Checked
            Fm.Chk_VerActivas.Checked = Chk_VerActivas.Checked
            Fm.Chk_VerCerradas.Checked = Chk_VerCerradas.Checked
            Fm.Chk_VerNulas.Checked = Chk_VerNulas.Checked
            Fm.Rdb_Retira_Cliente.Checked = Rdb_Retira_Cliente.Checked
            Fm.Rdb_Despacho_Domicilio.Checked = Rdb_Despacho_Domicilio.Checked
            Fm.Rdb_Ambos.Checked = Fm.Rdb_Ambos.Checked

            Fm.ShowDialog(Me)

            If Fm._Filtrar Then
                Sw_RevisionAutomatica.Value = False
                Lbl_TiempoRest.Text = String.Empty
                Sb_Actualizar_Listado(Fm._Filtro_SQL)
            Else
                Sw_RevisionAutomatica.Value = True
            End If
        End If
    End Sub
End Class